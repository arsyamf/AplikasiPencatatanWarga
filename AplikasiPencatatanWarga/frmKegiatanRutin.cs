using System;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;

namespace AplikasiPencatatanWarga
{
    public partial class frmKegiatanRutin : Form
    {
        private DatabaseManager dbManager;
        private int selectedKegiatanId = 0;

        public frmKegiatanRutin()
        {
            InitializeComponent();
            dbManager = new DatabaseManager();
            this.Load += frmKegiatanRutin_Load;

            btnSimpan.Click += btnSimpan_Click;
            btnReset.Click += btnReset_Click;
            btnUbah.Click += btnUbah_Click;
            btnHapus.Click += btnHapus_Click;
            dgvKegiatan.CellClick += dgvKegiatan_CellClick;
        }

        private void frmKegiatanRutin_Load(object sender, EventArgs e)
        {
            LoadComboBoxWarga();
            LoadDataToGrid();
            btnHapus.Enabled = false;
            btnUbah.Enabled = false;
        }

        private void LoadComboBoxWarga()
        {
            cmbWarga.Items.Clear();
            var wargaList = dbManager.GetWargaForComboBox();
            foreach (var warga in wargaList)
            {
                cmbWarga.Items.Add($"{warga.Item1} - {warga.Item2}");
            }
        }

        private void LoadDataToGrid()
        {
            dgvKegiatan.DataSource = dbManager.GetAllKegiatan();
            dgvKegiatan.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dgvKegiatan.ClearSelection();
            selectedKegiatanId = 0;
            btnHapus.Enabled = false;
            btnUbah.Enabled = false;
        }

        private void ResetForm()
        {
            cmbWarga.SelectedIndex = -1;
            txtNamaKegiatan.Text = "";
            dtpTanggalKegiatan.Value = DateTime.Now;
            txtKeterangan.Text = "";
            selectedKegiatanId = 0;
            btnHapus.Enabled = false;
            btnUbah.Enabled = false;
            btnSimpan.Enabled = true;
            dgvKegiatan.ClearSelection();
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (cmbWarga.SelectedItem == null || string.IsNullOrWhiteSpace(txtNamaKegiatan.Text))
            {
                MessageBox.Show("NIK/Nama Warga dan Nama Kegiatan harus diisi.", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string selectedWarga = cmbWarga.SelectedItem.ToString();
            string nikWarga = selectedWarga.Split(' ')[0];
            string namaKegiatan = txtNamaKegiatan.Text.Trim();
            DateTime tanggalKegiatan = dtpTanggalKegiatan.Value;
            string keterangan = txtKeterangan.Text.Trim();
            bool success = dbManager.SaveKegiatan(selectedKegiatanId, nikWarga, namaKegiatan, tanggalKegiatan, keterangan);

            if (success)
            {
                MessageBox.Show("Data kegiatan berhasil disimpan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataToGrid();
                ResetForm();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void dgvKegiatan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvKegiatan.Rows[e.RowIndex];
                selectedKegiatanId = Convert.ToInt32(row.Cells["IdKegiatan"].Value);
                string nikWarga = row.Cells["NIK_Warga"].Value.ToString();
                string namaWarga = row.Cells["NamaLengkap"].Value.ToString();
                string comboItem = $"{nikWarga} - {namaWarga}";
                int index = cmbWarga.FindStringExact(comboItem);
                if (index != -1)
                {
                    cmbWarga.SelectedIndex = index;
                }
                txtNamaKegiatan.Text = row.Cells["NamaKegiatan"].Value.ToString();
                dtpTanggalKegiatan.Value = Convert.ToDateTime(row.Cells["TanggalKegiatan"].Value);
                txtKeterangan.Text = row.Cells["Keterangan"].Value.ToString();
                btnHapus.Enabled = true;
                btnUbah.Enabled = true;
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (selectedKegiatanId == 0)
            {
                MessageBox.Show("Pilih data kegiatan yang ingin dihapus.", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult dialogResult = MessageBox.Show($"Anda yakin ingin menghapus kegiatan ini?",
                "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                bool success = dbManager.DeleteKegiatan(selectedKegiatanId);
                if (success)
                {
                    MessageBox.Show("Data kegiatan berhasil dihapus!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataToGrid();
                    ResetForm();
                }
            }
        }

        private void btnUbah_Click(object sender, EventArgs e)
        {
            if (selectedKegiatanId == 0)
            {
                MessageBox.Show("Pilih data kegiatan yang ingin diubah.", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            MessageBox.Show("Silakan ubah data di formulir, lalu klik 'Simpan' untuk memperbarui.", "Siap Mengubah", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
