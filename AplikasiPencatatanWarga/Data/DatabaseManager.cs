using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace AplikasiPencatatanWarga
{
    public class Warga
    {
        public string NIK { get; set; }
        public string NamaLengkap { get; set; }
        public string TanggalLahir { get; set; }
        public string JenisKelamin { get; set; }
        public string Alamat { get; set; }
        public string Pekerjaan { get; set; }
        public string StatusPerkawinan { get; set; }
    }

    public partial class DatabaseManager
    {
        private string dbPath;
        public DatabaseManager()
        {
            string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string dataFolder = Path.Combine(appDirectory, "Data");
            if (!Directory.Exists(dataFolder))
            {
                Directory.CreateDirectory(dataFolder);
            }
            dbPath = Path.Combine(dataFolder, "warga.db");
            System.Diagnostics.Debug.WriteLine("DB Path: " + dbPath);
            InitializeDatabase();
        }

        public SQLiteConnection GetConnection()
        {
            return new SQLiteConnection($"Data Source={dbPath};Version=3;");
        }

        private void InitializeDatabase()
        {
            if (!File.Exists(dbPath))
            {
                SQLiteConnection.CreateFile(dbPath);
            }
            using (SQLiteConnection conn = GetConnection())
            {
                try
                {
                    conn.Open();
                    // Tabel Warga
                    string createTableWargaQuery = @"
                    CREATE TABLE IF NOT EXISTS Warga (
                        NIK TEXT PRIMARY KEY UNIQUE NOT NULL,
                        NamaLengkap TEXT NOT NULL,
                        TanggalLahir TEXT,
                        JenisKelamin TEXT NOT NULL,
                        Alamat TEXT,
                        Pekerjaan TEXT,
                        StatusPerkawinan TEXT
                    );";
                    using (SQLiteCommand cmd = new SQLiteCommand(createTableWargaQuery, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    // Tabel KegiatanRutin
                    string createTableKegiatanQuery = @"
                    CREATE TABLE IF NOT EXISTS KegiatanRutin (
                        IdKegiatan INTEGER PRIMARY KEY AUTOINCREMENT,
                        NIK_Warga TEXT NOT NULL,
                        NamaKegiatan TEXT NOT NULL,
                        TanggalKegiatan TEXT NOT NULL,
                        Keterangan TEXT,
                        FOREIGN KEY(NIK_Warga) REFERENCES Warga(NIK) ON DELETE CASCADE
                    );";
                    using (SQLiteCommand cmd = new SQLiteCommand(createTableKegiatanQuery, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error saat inisialisasi database: " + ex.Message, ex);
                }
            }
        }

        // CRUD Warga
        public void InsertWarga(Warga warga)
        {
            using var conn = GetConnection();
            conn.Open();
            string query = @"INSERT INTO Warga (NIK, NamaLengkap, TanggalLahir, JenisKelamin, Alamat, Pekerjaan, StatusPerkawinan)
                             VALUES (@NIK, @NamaLengkap, @TanggalLahir, @JenisKelamin, @Alamat, @Pekerjaan, @StatusPerkawinan)";
            using var cmd = new SQLiteCommand(query, conn);
            cmd.Parameters.AddWithValue("@NIK", warga.NIK);
            cmd.Parameters.AddWithValue("@NamaLengkap", warga.NamaLengkap);
            cmd.Parameters.AddWithValue("@TanggalLahir", warga.TanggalLahir);
            cmd.Parameters.AddWithValue("@JenisKelamin", warga.JenisKelamin);
            cmd.Parameters.AddWithValue("@Alamat", warga.Alamat);
            cmd.Parameters.AddWithValue("@Pekerjaan", warga.Pekerjaan);
            cmd.Parameters.AddWithValue("@StatusPerkawinan", warga.StatusPerkawinan);
            cmd.ExecuteNonQuery();
        }

        public void UpdateWarga(Warga warga)
        {
            using var conn = GetConnection();
            conn.Open();
            string query = @"UPDATE Warga SET NamaLengkap=@NamaLengkap, TanggalLahir=@TanggalLahir, JenisKelamin=@JenisKelamin,
                             Alamat=@Alamat, Pekerjaan=@Pekerjaan, StatusPerkawinan=@StatusPerkawinan WHERE NIK=@NIK";
            using var cmd = new SQLiteCommand(query, conn);
            cmd.Parameters.AddWithValue("@NamaLengkap", warga.NamaLengkap);
            cmd.Parameters.AddWithValue("@TanggalLahir", warga.TanggalLahir);
            cmd.Parameters.AddWithValue("@JenisKelamin", warga.JenisKelamin);
            cmd.Parameters.AddWithValue("@Alamat", warga.Alamat);
            cmd.Parameters.AddWithValue("@Pekerjaan", warga.Pekerjaan);
            cmd.Parameters.AddWithValue("@StatusPerkawinan", warga.StatusPerkawinan);
            cmd.Parameters.AddWithValue("@NIK", warga.NIK);
            cmd.ExecuteNonQuery();
        }

        public void DeleteWarga(string nik)
        {
            using var conn = GetConnection();
            conn.Open();
            string query = "DELETE FROM Warga WHERE NIK=@NIK";
            using var cmd = new SQLiteCommand(query, conn);
            cmd.Parameters.AddWithValue("@NIK", nik);
            cmd.ExecuteNonQuery();
        }

        public List<Warga> GetAllWarga()
        {
            var list = new List<Warga>();
            using var conn = GetConnection();
            conn.Open();
            string query = "SELECT * FROM Warga";
            using var cmd = new SQLiteCommand(query, conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Warga
                {
                    NIK = reader["NIK"].ToString(),
                    NamaLengkap = reader["NamaLengkap"].ToString(),
                    TanggalLahir = reader["TanggalLahir"].ToString(),
                    JenisKelamin = reader["JenisKelamin"].ToString(),
                    Alamat = reader["Alamat"].ToString(),
                    Pekerjaan = reader["Pekerjaan"].ToString(),
                    StatusPerkawinan = reader["StatusPerkawinan"].ToString()
                });
            }
            return list;
        }

        public bool IsNikExist(string nik)
        {
            using var conn = GetConnection();
            conn.Open();
            string query = "SELECT COUNT(1) FROM Warga WHERE NIK = @NIK";
            using var cmd = new SQLiteCommand(query, conn);
            cmd.Parameters.AddWithValue("@NIK", nik);
            var count = Convert.ToInt32(cmd.ExecuteScalar());
            return count > 0;
        }

        // CRUD KegiatanRutin
        public bool SaveKegiatan(int idKegiatan, string nikWarga, string namaKegiatan, DateTime tanggalKegiatan, string keterangan)
        {
            using (SQLiteConnection conn = GetConnection())
            {
                try
                {
                    conn.Open();
                    string query;
                    if (idKegiatan == 0) // INSERT
                    {
                        query = @"
                        INSERT INTO KegiatanRutin (NIK_Warga, NamaKegiatan, TanggalKegiatan, Keterangan)
                        VALUES (@nikWarga, @namaKegiatan, @tanggalKegiatan, @keterangan);";
                    }
                    else // UPDATE
                    {
                        query = @"
                        UPDATE KegiatanRutin SET NIK_Warga = @nikWarga, NamaKegiatan = @namaKegiatan,
                        TanggalKegiatan = @tanggalKegiatan, Keterangan = @keterangan
                        WHERE IdKegiatan = @idKegiatan;";
                    }
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        if (idKegiatan != 0)
                        {
                            cmd.Parameters.AddWithValue("@idKegiatan", idKegiatan);
                        }
                        cmd.Parameters.AddWithValue("@nikWarga", nikWarga);
                        cmd.Parameters.AddWithValue("@namaKegiatan", namaKegiatan);
                        cmd.Parameters.AddWithValue("@tanggalKegiatan", tanggalKegiatan.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@keterangan", keterangan);
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show($"Error saat menyimpan kegiatan: {ex.Message}",
                        "Error Database", System.Windows.Forms.MessageBoxButtons.OK,
                        System.Windows.Forms.MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        public DataTable GetAllKegiatan()
        {
            DataTable dt = new DataTable();
            using (SQLiteConnection conn = GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"
                    SELECT k.IdKegiatan, k.NIK_Warga, w.NamaLengkap, k.NamaKegiatan, k.TanggalKegiatan, k.Keterangan
                    FROM KegiatanRutin k
                    JOIN Warga w ON k.NIK_Warga = w.NIK
                    ORDER BY k.TanggalKegiatan DESC;";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show($"Error saat mengambil data kegiatan: {ex.Message}",
                        "Error Database", System.Windows.Forms.MessageBoxButtons.OK,
                        System.Windows.Forms.MessageBoxIcon.Error);
                }
            }
            return dt;
        }

        public bool DeleteKegiatan(int idKegiatan)
        {
            using (SQLiteConnection conn = GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "DELETE FROM KegiatanRutin WHERE IdKegiatan = @idKegiatan;";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@idKegiatan", idKegiatan);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show($"Error saat menghapus kegiatan: {ex.Message}",
                        "Error Database", System.Windows.Forms.MessageBoxButtons.OK,
                        System.Windows.Forms.MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        public List<Tuple<string, string>> GetWargaForComboBox()
        {
            List<Tuple<string, string>> wargaList = new List<Tuple<string, string>>();
            using (SQLiteConnection conn = GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT NIK, NamaLengkap FROM Warga ORDER BY NamaLengkap ASC;";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                wargaList.Add(Tuple.Create(reader.GetString(0), reader.GetString(1)));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show($"Error saat mengambil daftar warga: {ex.Message}",
                        "Error Database", System.Windows.Forms.MessageBoxButtons.OK,
                        System.Windows.Forms.MessageBoxIcon.Error);
                }
            }
            return wargaList;
        }
    }
}