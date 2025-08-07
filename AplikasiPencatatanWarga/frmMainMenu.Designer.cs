namespace AplikasiPencatatanWarga
{
    partial class frmMainMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnDataWarga;
        private System.Windows.Forms.Button btnKegiatanRutin;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnDataWarga = new System.Windows.Forms.Button();
            this.btnKegiatanRutin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // frmMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 300);
            this.Name = "frmMainMenu";
            this.Text = "Menu Utama Aplikasi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            // 
            // btnDataWarga
            // 
            this.btnDataWarga.Name = "btnDataWarga";
            this.btnDataWarga.Text = "Data Warga";
            this.btnDataWarga.Size = new System.Drawing.Size(150, 40);
            this.btnDataWarga.Location = new System.Drawing.Point(125, 70);
            this.btnDataWarga.TabIndex = 0;
            this.btnDataWarga.Click += new System.EventHandler(this.btnDataWarga_Click);
            // 
            // btnKegiatanRutin
            // 
            this.btnKegiatanRutin.Name = "btnKegiatanRutin";
            this.btnKegiatanRutin.Text = "Kegiatan Rutin Warga";
            this.btnKegiatanRutin.Size = new System.Drawing.Size(150, 40);
            this.btnKegiatanRutin.Location = new System.Drawing.Point(125, 140);
            this.btnKegiatanRutin.TabIndex = 1;
            this.btnKegiatanRutin.Click += new System.EventHandler(this.btnKegiatanRutin_Click);
            // 
            // Add controls
            // 
            this.Controls.Add(this.btnDataWarga);
            this.Controls.Add(this.btnKegiatanRutin);
            this.ResumeLayout(false);
        }

        #endregion
    }
}