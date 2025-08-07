namespace AplikasiPencatatanWarga
{
    partial class frmKegiatanRutin
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.GroupBox grpKegiatan;
        private System.Windows.Forms.Label lblWarga;
        private System.Windows.Forms.ComboBox cmbWarga;
        private System.Windows.Forms.Label lblNamaKegiatan;
        private System.Windows.Forms.TextBox txtNamaKegiatan;
        private System.Windows.Forms.Label lblTanggalKegiatan;
        private System.Windows.Forms.DateTimePicker dtpTanggalKegiatan;
        private System.Windows.Forms.Label lblKeterangan;
        private System.Windows.Forms.TextBox txtKeterangan;
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnUbah;
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.DataGridView dgvKegiatan;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            grpKegiatan = new GroupBox();
            lblWarga = new Label();
            cmbWarga = new ComboBox();
            lblNamaKegiatan = new Label();
            txtNamaKegiatan = new TextBox();
            lblTanggalKegiatan = new Label();
            dtpTanggalKegiatan = new DateTimePicker();
            lblKeterangan = new Label();
            txtKeterangan = new TextBox();
            btnSimpan = new Button();
            btnReset = new Button();
            btnUbah = new Button();
            btnHapus = new Button();
            dgvKegiatan = new DataGridView();
            grpKegiatan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKegiatan).BeginInit();
            SuspendLayout();
            // 
            // grpKegiatan
            // 
            grpKegiatan.Controls.Add(lblWarga);
            grpKegiatan.Controls.Add(cmbWarga);
            grpKegiatan.Controls.Add(lblNamaKegiatan);
            grpKegiatan.Controls.Add(txtNamaKegiatan);
            grpKegiatan.Controls.Add(lblTanggalKegiatan);
            grpKegiatan.Controls.Add(dtpTanggalKegiatan);
            grpKegiatan.Controls.Add(lblKeterangan);
            grpKegiatan.Controls.Add(txtKeterangan);
            grpKegiatan.Location = new Point(20, 20);
            grpKegiatan.Name = "grpKegiatan";
            grpKegiatan.Size = new Size(760, 203);
            grpKegiatan.TabIndex = 0;
            grpKegiatan.TabStop = false;
            grpKegiatan.Text = "Input Kegiatan";
            // 
            // lblWarga
            // 
            lblWarga.Location = new Point(20, 30);
            lblWarga.Name = "lblWarga";
            lblWarga.Size = new Size(130, 25);
            lblWarga.TabIndex = 0;
            lblWarga.Text = "NIK/Nama Warga:";
            // 
            // cmbWarga
            // 
            cmbWarga.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbWarga.Location = new Point(160, 27);
            cmbWarga.Name = "cmbWarga";
            cmbWarga.Size = new Size(250, 28);
            cmbWarga.TabIndex = 1;
            // 
            // lblNamaKegiatan
            // 
            lblNamaKegiatan.Location = new Point(20, 70);
            lblNamaKegiatan.Name = "lblNamaKegiatan";
            lblNamaKegiatan.Size = new Size(130, 25);
            lblNamaKegiatan.TabIndex = 2;
            lblNamaKegiatan.Text = "Nama Kegiatan:";
            // 
            // txtNamaKegiatan
            // 
            txtNamaKegiatan.Location = new Point(160, 67);
            txtNamaKegiatan.Name = "txtNamaKegiatan";
            txtNamaKegiatan.Size = new Size(250, 27);
            txtNamaKegiatan.TabIndex = 3;
            // 
            // lblTanggalKegiatan
            // 
            lblTanggalKegiatan.Location = new Point(20, 110);
            lblTanggalKegiatan.Name = "lblTanggalKegiatan";
            lblTanggalKegiatan.Size = new Size(130, 25);
            lblTanggalKegiatan.TabIndex = 4;
            lblTanggalKegiatan.Text = "Tanggal Kegiatan:";
            // 
            // dtpTanggalKegiatan
            // 
            dtpTanggalKegiatan.Location = new Point(160, 110);
            dtpTanggalKegiatan.Name = "dtpTanggalKegiatan";
            dtpTanggalKegiatan.Size = new Size(250, 27);
            dtpTanggalKegiatan.TabIndex = 5;
            // 
            // lblKeterangan
            // 
            lblKeterangan.Location = new Point(434, 30);
            lblKeterangan.Name = "lblKeterangan";
            lblKeterangan.Size = new Size(130, 25);
            lblKeterangan.TabIndex = 6;
            lblKeterangan.Text = "Keterangan:";
            // 
            // txtKeterangan
            // 
            txtKeterangan.Location = new Point(434, 58);
            txtKeterangan.Multiline = true;
            txtKeterangan.Name = "txtKeterangan";
            txtKeterangan.ScrollBars = ScrollBars.Vertical;
            txtKeterangan.Size = new Size(306, 79);
            txtKeterangan.TabIndex = 7;
            // 
            // btnSimpan
            // 
            btnSimpan.Location = new Point(160, 229);
            btnSimpan.Name = "btnSimpan";
            btnSimpan.Size = new Size(100, 35);
            btnSimpan.TabIndex = 1;
            btnSimpan.Text = "Simpan";
            // 
            // btnReset
            // 
            btnReset.Location = new Point(280, 229);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(100, 35);
            btnReset.TabIndex = 2;
            btnReset.Text = "Reset Form";
            // 
            // btnUbah
            // 
            btnUbah.Location = new Point(400, 229);
            btnUbah.Name = "btnUbah";
            btnUbah.Size = new Size(100, 35);
            btnUbah.TabIndex = 3;
            btnUbah.Text = "Ubah";
            // 
            // btnHapus
            // 
            btnHapus.Location = new Point(520, 229);
            btnHapus.Name = "btnHapus";
            btnHapus.Size = new Size(100, 35);
            btnHapus.TabIndex = 4;
            btnHapus.Text = "Hapus";
            // 
            // dgvKegiatan
            // 
            dgvKegiatan.AllowUserToAddRows = false;
            dgvKegiatan.AllowUserToDeleteRows = false;
            dgvKegiatan.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvKegiatan.ColumnHeadersHeight = 29;
            dgvKegiatan.Location = new Point(20, 281);
            dgvKegiatan.Name = "dgvKegiatan";
            dgvKegiatan.ReadOnly = true;
            dgvKegiatan.RowHeadersWidth = 51;
            dgvKegiatan.Size = new Size(760, 322);
            dgvKegiatan.TabIndex = 5;
            // 
            // frmKegiatanRutin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 623);
            Controls.Add(grpKegiatan);
            Controls.Add(btnSimpan);
            Controls.Add(btnReset);
            Controls.Add(btnUbah);
            Controls.Add(btnHapus);
            Controls.Add(dgvKegiatan);
            Name = "frmKegiatanRutin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Pencatatan Kegiatan Rutin";
            grpKegiatan.ResumeLayout(false);
            grpKegiatan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKegiatan).EndInit();
            ResumeLayout(false);
        }

        #endregion
    }
}