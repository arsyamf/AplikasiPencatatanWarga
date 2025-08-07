using System;
using System.Windows.Forms;

namespace AplikasiPencatatanWarga
{
    public partial class frmMainMenu : Form
    {
        public frmMainMenu()
        {
            InitializeComponent();
        }

        private void btnDataWarga_Click(object sender, EventArgs e)
        {
            frmDataWarga dataWargaForm = new frmDataWarga();
            dataWargaForm.Show();
        }

        private void btnKegiatanRutin_Click(object sender, EventArgs e)
        {
            frmKegiatanRutin kegiatanRutinForm = new frmKegiatanRutin();
            kegiatanRutinForm.Show();
        }
    }
}
