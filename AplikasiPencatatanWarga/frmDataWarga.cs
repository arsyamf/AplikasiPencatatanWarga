using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AplikasiPencatatanWarga
{
    public partial class frmDataWarga : Form
    {
        private DatabaseManager db = new DatabaseManager();

        public frmDataWarga()
        {
            InitializeComponent();
            LoadData();
            dgvWarga.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvWarga.MultiSelect = false;

            btnSimpan.Click += BtnSimpan_Click;
            btnReset.Click += BtnReset_Click;
            btnHapus.Click += BtnHapus_Click;
            btnUbah.Click += BtnUbah_Click;
            dgvWarga.CellClick += DgvWarga_CellClick;
        }

        private void LoadData()
        {
            dgvWarga.DataSource = db.GetAllWarga();
            dgvWarga.ClearSelection();
        }

        private bool ValidasiInput(bool isInsert = true)
        {
            // Validasi NIK
            string nik = txtNIK.Text.Trim();
            if (nik.Length != 16)
            {
                MessageBox.Show("NIK harus 16 karakter.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNIK.Focus();
                return false;
            }
            // Validasi NIK hanya angka
            if (!System.Text.RegularExpressions.Regex.IsMatch(nik, @"^\d{16}$"))
            {
                MessageBox.Show("NIK harus berupa angka saja.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNIK.Focus();
                return false;
            }

            // Cek NIK unik hanya saat insert
            if (isInsert && db.IsNikExist(nik))
            {
                MessageBox.Show("NIK sudah terdaftar.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNIK.Focus();
                return false;
            }

            // Validasi Nama Lengkap
            string nama = txtNamaLengkap.Text.Trim();
            if (string.IsNullOrWhiteSpace(nama))
            {
                MessageBox.Show("Nama Lengkap harus diisi.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNamaLengkap.Focus();
                return false;
            }
            // Validasi Nama hanya huruf dan spasi
            if (!System.Text.RegularExpressions.Regex.IsMatch(nama, @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("Nama Lengkap hanya boleh berisi huruf dan spasi.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNamaLengkap.Focus();
                return false;
            }

            // Validasi Jenis Kelamin
            if (cmbJenisKelamin.SelectedIndex == -1)
            {
                MessageBox.Show("Pilih Jenis Kelamin.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbJenisKelamin.Focus();
                return false;
            }

            // Validasi Alamat
            if (string.IsNullOrWhiteSpace(txtAlamat.Text))
            {
                MessageBox.Show("Alamat harus diisi.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAlamat.Focus();
                return false;
            }

            // Validasi Status Perkawinan
            if (cmbStatusPerkawinan.SelectedIndex == -1)
            {
                MessageBox.Show("Pilih Status Perkawinan.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbStatusPerkawinan.Focus();
                return false;
            }

            return true;
        }

        private void BtnSimpan_Click(object sender, EventArgs e)
        {
            if (!ValidasiInput()) return;

            // Otomatis isi "belum bekerja" jika kosong
            string pekerjaan = string.IsNullOrWhiteSpace(txtPekerjaan.Text) ? "belum bekerja" : txtPekerjaan.Text.Trim();

            try
            {
                var warga = new Warga
                {
                    NIK = txtNIK.Text.Trim(),
                    NamaLengkap = txtNamaLengkap.Text.Trim(),
                    TanggalLahir = dtpTanggalLahir.Value.ToString("yyyy-MM-dd"),
                    JenisKelamin = cmbJenisKelamin.Text,
                    Alamat = txtAlamat.Text.Trim(),
                    Pekerjaan = pekerjaan,
                    StatusPerkawinan = cmbStatusPerkawinan.Text
                };
                db.InsertWarga(warga);
                MessageBox.Show("Data berhasil disimpan.");
                LoadData();
                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menyimpan data: " + ex.Message);
            }
        }

        private void BtnUbah_Click(object sender, EventArgs e)
        {
            if (!ValidasiInput(false)) return;

            // Otomatis isi "belum bekerja" jika kosong
            string pekerjaan = string.IsNullOrWhiteSpace(txtPekerjaan.Text) ? "belum bekerja" : txtPekerjaan.Text.Trim();

            try
            {
                var warga = new Warga
                {
                    NIK = txtNIK.Text.Trim(),
                    NamaLengkap = txtNamaLengkap.Text.Trim(),
                    TanggalLahir = dtpTanggalLahir.Value.ToString("yyyy-MM-dd"),
                    JenisKelamin = cmbJenisKelamin.Text,
                    Alamat = txtAlamat.Text.Trim(),
                    Pekerjaan = pekerjaan,
                    StatusPerkawinan = cmbStatusPerkawinan.Text
                };
                db.UpdateWarga(warga);
                MessageBox.Show("Data berhasil diubah.");
                LoadData();
                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal mengubah data: " + ex.Message);
            }
        }

        private void BtnHapus_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNIK.Text)) return;
            if (MessageBox.Show("Yakin ingin menghapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    db.DeleteWarga(txtNIK.Text.Trim());
                    MessageBox.Show("Data berhasil dihapus.");
                    LoadData();
                    ResetForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal menghapus data: " + ex.Message);
                }
            }
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void ResetForm()
        {
            txtNIK.Text = "";
            txtNamaLengkap.Text = "";
            dtpTanggalLahir.Value = DateTime.Now;
            cmbJenisKelamin.SelectedIndex = -1;
            txtAlamat.Text = "";
            txtPekerjaan.Text = "";
            cmbStatusPerkawinan.SelectedIndex = -1;
            txtNIK.Enabled = true;
        }

        private void DgvWarga_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvWarga.CurrentRow != null)
            {
                txtNIK.Text = dgvWarga.CurrentRow.Cells["NIK"].Value?.ToString();
                txtNamaLengkap.Text = dgvWarga.CurrentRow.Cells["NamaLengkap"].Value?.ToString();
                if (DateTime.TryParse(dgvWarga.CurrentRow.Cells["TanggalLahir"].Value?.ToString(), out var tgl))
                    dtpTanggalLahir.Value = tgl;
                else
                    dtpTanggalLahir.Value = DateTime.Now;
                cmbJenisKelamin.Text = dgvWarga.CurrentRow.Cells["JenisKelamin"].Value?.ToString();
                txtAlamat.Text = dgvWarga.CurrentRow.Cells["Alamat"].Value?.ToString();
                txtPekerjaan.Text = dgvWarga.CurrentRow.Cells["Pekerjaan"].Value?.ToString();
                cmbStatusPerkawinan.Text = dgvWarga.CurrentRow.Cells["StatusPerkawinan"].Value?.ToString();
                txtNIK.Enabled = false;
            }
        }
    }
}
