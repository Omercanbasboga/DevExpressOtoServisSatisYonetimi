using System;
using System.Threading;
using System.Windows.Forms;
using DevExpress.XtraEditors; // XtraMessageBox için

namespace OtoServisSatis.WindowsApp
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            this.KeyPreview = true; // Enter tuşu kontrolü için
        }

        private BL.KullaniciManager kullaniciManager = new BL.KullaniciManager();

        private void btnGiris_Click(object sender, EventArgs e)
        {
            try
            {
                var kullanici = kullaniciManager.Get(k => k.KullaniciAdi == txtKullaniciAdi.Text
                                                       && k.Sifre == txtSifre.Text
                                                       && k.AktifMi == true);

                if (kullanici != null)
                {
                    AnaMenu anaMenu = new AnaMenu();
                    anaMenu.Show();
                    this.Hide();
                }
                else
                {
                    XtraMessageBox.Show("Kullanıcı Girişi Başarısız!", "Giriş Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // Enter tuşu kontrolü
            {
                btnGiris.PerformClick(); // Giriş butonuna basıldı
                e.Handled = true;
            }
        }

        private void btnSifreGosterKapat_Click(object sender, EventArgs e)
        {
            // Şifreyi göster/gizle
            txtSifre.UseSystemPasswordChar = !txtSifre.UseSystemPasswordChar;

            // Göz düğmesinin ikonunu veya metnini değiştir
            btnSifreGosterKapat.Text = txtSifre.UseSystemPasswordChar ? "👁" : "👁‍🗨";
        }

        private void Login_Load(object sender, EventArgs e)
        {
            Thread.Sleep(5000);
        }
    }
}
