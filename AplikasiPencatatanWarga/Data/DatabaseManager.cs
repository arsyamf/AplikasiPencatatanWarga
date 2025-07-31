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
                    string createTableQuery = @"
                    CREATE TABLE IF NOT EXISTS Warga (
                    NIK TEXT PRIMARY KEY UNIQUE NOT NULL,
                    NamaLengkap TEXT NOT NULL,
                    TanggalLahir TEXT,
                    JenisKelamin TEXT NOT NULL,
                    Alamat TEXT,
                    Pekerjaan TEXT,
                    StatusPerkawinan TEXT
                    );";
                    using (SQLiteCommand cmd = new SQLiteCommand(createTableQuery, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    // Lempar exception ke atas, biar UI yang handle
                    throw new Exception("Error saat inisialisasi database: " + ex.Message, ex);
                }
            }
        }

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
    }
}