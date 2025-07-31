namespace AplikasiPencatatanWarga
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.GroupBox grpDataWarga;
        private System.Windows.Forms.Label lblNIK;
        private System.Windows.Forms.TextBox txtNIK;
        private System.Windows.Forms.Label lblNamaLengkap;
        private System.Windows.Forms.TextBox txtNamaLengkap;
        private System.Windows.Forms.Label lblTanggalLahir;
        private System.Windows.Forms.DateTimePicker dtpTanggalLahir;
        private System.Windows.Forms.Label lblJenisKelamin;
        private System.Windows.Forms.ComboBox cmbJenisKelamin;
        private System.Windows.Forms.Label lblAlamat;
        private System.Windows.Forms.TextBox txtAlamat;
        private System.Windows.Forms.Label lblPekerjaan;
        private System.Windows.Forms.TextBox txtPekerjaan;
        private System.Windows.Forms.Label lblStatusPerkawinan;
        private System.Windows.Forms.ComboBox cmbStatusPerkawinan;
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.Button btnUbah;
        private System.Windows.Forms.DataGridView dgvWarga;

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
            components = new System.ComponentModel.Container();
            this.grpDataWarga = new System.Windows.Forms.GroupBox();
            this.lblNIK = new System.Windows.Forms.Label();
            this.txtNIK = new System.Windows.Forms.TextBox();
            this.lblNamaLengkap = new System.Windows.Forms.Label();
            this.txtNamaLengkap = new System.Windows.Forms.TextBox();
            this.lblTanggalLahir = new System.Windows.Forms.Label();
            this.dtpTanggalLahir = new System.Windows.Forms.DateTimePicker();
            this.lblJenisKelamin = new System.Windows.Forms.Label();
            this.cmbJenisKelamin = new System.Windows.Forms.ComboBox();
            this.lblAlamat = new System.Windows.Forms.Label();
            this.txtAlamat = new System.Windows.Forms.TextBox();
            this.lblPekerjaan = new System.Windows.Forms.Label();
            this.txtPekerjaan = new System.Windows.Forms.TextBox();
            this.lblStatusPerkawinan = new System.Windows.Forms.Label();
            this.cmbStatusPerkawinan = new System.Windows.Forms.ComboBox();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnHapus = new System.Windows.Forms.Button();
            this.btnUbah = new System.Windows.Forms.Button();
            this.dgvWarga = new System.Windows.Forms.DataGridView();

            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Name = "frmMain";
            this.Text = "Aplikasi Pencatatan Data Warga";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            // 
            // grpDataWarga
            // 
            this.grpDataWarga.Text = "Data Warga";
            this.grpDataWarga.Name = "grpDataWarga";
            this.grpDataWarga.Location = new System.Drawing.Point(20, 20);
            this.grpDataWarga.Size = new System.Drawing.Size(760, 220);
            this.grpDataWarga.TabIndex = 0;
            this.grpDataWarga.TabStop = false;

            // 
            // lblNIK
            // 
            this.lblNIK.Text = "NIK:";
            this.lblNIK.Location = new System.Drawing.Point(20, 30);
            this.lblNIK.Size = new System.Drawing.Size(120, 25);

            // 
            // txtNIK
            // 
            this.txtNIK.Name = "txtNIK";
            this.txtNIK.Location = new System.Drawing.Point(150, 27);
            this.txtNIK.Size = new System.Drawing.Size(200, 27);
            this.txtNIK.MaxLength = 16;

            // 
            // lblNamaLengkap
            // 
            this.lblNamaLengkap.Text = "Nama Lengkap:";
            this.lblNamaLengkap.Location = new System.Drawing.Point(400, 30);
            this.lblNamaLengkap.Size = new System.Drawing.Size(120, 25);

            // 
            // txtNamaLengkap
            // 
            this.txtNamaLengkap.Name = "txtNamaLengkap";
            this.txtNamaLengkap.Location = new System.Drawing.Point(530, 27);
            this.txtNamaLengkap.Size = new System.Drawing.Size(200, 27);

            // 
            // lblTanggalLahir
            // 
            this.lblTanggalLahir.Text = "Tanggal Lahir:";
            this.lblTanggalLahir.Location = new System.Drawing.Point(20, 70);
            this.lblTanggalLahir.Size = new System.Drawing.Size(120, 25);

            // 
            // dtpTanggalLahir
            // 
            this.dtpTanggalLahir.Name = "dtpTanggalLahir";
            this.dtpTanggalLahir.Location = new System.Drawing.Point(150, 67);
            this.dtpTanggalLahir.Size = new System.Drawing.Size(200, 27);
            this.dtpTanggalLahir.Format = System.Windows.Forms.DateTimePickerFormat.Long;

            // 
            // lblJenisKelamin
            // 
            this.lblJenisKelamin.Text = "Jenis Kelamin:";
            this.lblJenisKelamin.Location = new System.Drawing.Point(400, 70);
            this.lblJenisKelamin.Size = new System.Drawing.Size(120, 25);

            // 
            // cmbJenisKelamin
            // 
            this.cmbJenisKelamin.Name = "cmbJenisKelamin";
            this.cmbJenisKelamin.Location = new System.Drawing.Point(530, 67);
            this.cmbJenisKelamin.Size = new System.Drawing.Size(200, 28);
            this.cmbJenisKelamin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbJenisKelamin.Items.AddRange(new object[] { "Laki-laki", "Perempuan" });

            // 
            // lblAlamat
            // 
            this.lblAlamat.Text = "Alamat:";
            this.lblAlamat.Location = new System.Drawing.Point(20, 110);
            this.lblAlamat.Size = new System.Drawing.Size(120, 25);

            // 
            // txtAlamat
            // 
            this.txtAlamat.Name = "txtAlamat";
            this.txtAlamat.Location = new System.Drawing.Point(150, 107);
            this.txtAlamat.Size = new System.Drawing.Size(580, 50);
            this.txtAlamat.Multiline = true;
            this.txtAlamat.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;

            // 
            // lblPekerjaan
            // 
            this.lblPekerjaan.Text = "Pekerjaan:";
            this.lblPekerjaan.Location = new System.Drawing.Point(20, 170);
            this.lblPekerjaan.Size = new System.Drawing.Size(120, 25);

            // 
            // txtPekerjaan
            // 
            this.txtPekerjaan.Name = "txtPekerjaan";
            this.txtPekerjaan.Location = new System.Drawing.Point(150, 167);
            this.txtPekerjaan.Size = new System.Drawing.Size(200, 27);

            // 
            // lblStatusPerkawinan
            // 
            this.lblStatusPerkawinan.Text = "Status Perkawinan:";
            this.lblStatusPerkawinan.Location = new System.Drawing.Point(400, 170);
            this.lblStatusPerkawinan.Size = new System.Drawing.Size(120, 25);

            // 
            // cmbStatusPerkawinan
            // 
            this.cmbStatusPerkawinan.Name = "cmbStatusPerkawinan";
            this.cmbStatusPerkawinan.Location = new System.Drawing.Point(530, 167);
            this.cmbStatusPerkawinan.Size = new System.Drawing.Size(200, 28);
            this.cmbStatusPerkawinan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatusPerkawinan.Items.AddRange(new object[] { "Belum Kawin", "Kawin", "Cerai Hidup", "Cerai Mati" });

            // Tambahkan kontrol ke GroupBox
            this.grpDataWarga.Controls.Add(this.lblNIK);
            this.grpDataWarga.Controls.Add(this.txtNIK);
            this.grpDataWarga.Controls.Add(this.lblNamaLengkap);
            this.grpDataWarga.Controls.Add(this.txtNamaLengkap);
            this.grpDataWarga.Controls.Add(this.lblTanggalLahir);
            this.grpDataWarga.Controls.Add(this.dtpTanggalLahir);
            this.grpDataWarga.Controls.Add(this.lblJenisKelamin);
            this.grpDataWarga.Controls.Add(this.cmbJenisKelamin);
            this.grpDataWarga.Controls.Add(this.lblAlamat);
            this.grpDataWarga.Controls.Add(this.txtAlamat);
            this.grpDataWarga.Controls.Add(this.lblPekerjaan);
            this.grpDataWarga.Controls.Add(this.txtPekerjaan);
            this.grpDataWarga.Controls.Add(this.lblStatusPerkawinan);
            this.grpDataWarga.Controls.Add(this.cmbStatusPerkawinan);

            // 
            // btnSimpan
            // 
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Text = "Simpan";
            this.btnSimpan.Location = new System.Drawing.Point(150, 250);
            this.btnSimpan.Size = new System.Drawing.Size(100, 35);

            // 
            // btnReset
            // 
            this.btnReset.Name = "btnReset";
            this.btnReset.Text = "Reset";
            this.btnReset.Location = new System.Drawing.Point(270, 250);
            this.btnReset.Size = new System.Drawing.Size(100, 35);

            // 
            // btnHapus
            // 
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Text = "Hapus";
            this.btnHapus.Location = new System.Drawing.Point(390, 250);
            this.btnHapus.Size = new System.Drawing.Size(100, 35);

            // 
            // btnUbah
            // 
            this.btnUbah.Name = "btnUbah";
            this.btnUbah.Text = "Ubah";
            this.btnUbah.Location = new System.Drawing.Point(510, 250);
            this.btnUbah.Size = new System.Drawing.Size(100, 35);

            // 
            // dgvWarga
            // 
            this.dgvWarga.Name = "dgvWarga";
            this.dgvWarga.Location = new System.Drawing.Point(20, 300);
            this.dgvWarga.Size = new System.Drawing.Size(760, 270);
            this.dgvWarga.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvWarga.ReadOnly = true;
            this.dgvWarga.AllowUserToAddRows = false;
            this.dgvWarga.AllowUserToDeleteRows = false;

            // 
            // Add controls to Form
            // 
            this.Controls.Add(this.grpDataWarga);
            this.Controls.Add(this.btnSimpan);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnHapus);
            this.Controls.Add(this.btnUbah);
            this.Controls.Add(this.dgvWarga);

            this.ResumeLayout(false);
        }

        #endregion
    }
}
