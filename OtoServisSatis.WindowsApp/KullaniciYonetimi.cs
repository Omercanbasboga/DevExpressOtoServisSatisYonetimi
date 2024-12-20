using DevExpress.Utils.DirectXPaint;
using OtoServisSatis.BL;
using OtoServisSatis.Entities;
using System;
using System.Linq;
using System.Windows.Forms;

namespace OtoServisSatis.WindowsApp
{
    public partial class KullaniciYonetimi : Form
    {
        private KullaniciManager manager = new KullaniciManager();
        private RoleManager roleManager = new RoleManager();

        public KullaniciYonetimi()
        {
            InitializeComponent();
        }

        void Yukle()
        {
            try
            {
                var sorgu = manager.GetAllByInclude("Rol").ToList(); // Önce sorguyu listeye çevir
                var ozelSorgu = (from k in sorgu
                                 select new
                                 {
                                     Id = k.Id,
                                     Adı = k.Adi,
                                     Soyadı = k.Soyadi,
                                     Email = k.Email,
                                     Telefon = k.Telefon,
                                     Kullanıcı_Adı = k.KullaniciAdi,
                                     Durum = k.AktifMi ? "Aktif" : "Pasif",
                                     Eklenme_Tarihi = k.EklenmeTarihi.ToString("dd.MM.yyyy"),
                                     Rolü = k.Rol != null ? k.Rol.Adi : "Rol Yok"
                                 }).ToList();

                dgvKullanicilar.DataSource = ozelSorgu;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bir hata oluştu: {ex.Message}");
            }
        }

        private void RolleriYukle()
        {
            try
            {
                var roller = roleManager.GetAll(); // Veritabanından rolleri al
                if (roller != null && roller.Count > 0)
                {
                    cbKullaniciRolu.DataSource = roller; // ComboBox'a veri kaynağı olarak atayın
                    cbKullaniciRolu.DisplayMember = "RolAdi"; // ComboBox'ta görüntülenecek alan
                    cbKullaniciRolu.ValueMember = "Id"; // ComboBox'un değer alanı
                }
                else
                {
                    MessageBox.Show("Roller yüklenemedi. Lütfen veritabanını kontrol edin.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Roller yüklenirken bir hata oluştu: {ex.Message}");
            }
        }

        private void Temizle()
        {
            txtAdi.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtKullaniciAdi.Text = string.Empty;
            txtSifre.Text = string.Empty;
            txtSoyadi.Text = string.Empty;
            txtTelefon.Text = string.Empty;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                int islemSonucu = manager.Add(
                    new Kullanici
                    {
                        Adi = txtAdi.Text,
                        AktifMi = cbAktif.Checked,
                        EklenmeTarihi = DateTime.Now,
                        Email = txtEmail.Text,
                        KullaniciAdi = txtKullaniciAdi.Text,
                        RolId = int.Parse(cbKullaniciRolu.SelectedValue.ToString()),
                        Sifre = txtSifre.Text,
                        Soyadi = txtSoyadi.Text,
                        Telefon = txtTelefon.Text
                    }
                );
                if (islemSonucu > 0)
                {
                    Yukle();
                    Temizle();
                    MessageBox.Show("Kayıt Eklendi!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata Oluştu! Kayıt Eklenemedi! {ex.Message}");
            }
        }

        private void KullaniciYonetimi_Load(object sender, EventArgs e)
        {
            RolleriYukle(); // Rolleri yükle
            Yukle(); // Kullanıcıları yükle
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            try
            {
                if (LblId.Text != "0")
                {
                    int kulId = Convert.ToInt32(LblId.Text);
                    int islemSonucu = manager.Update(
                    new Kullanici
                    {
                        Id = kulId,
                        Adi = txtAdi.Text,
                        AktifMi = cbAktif.Checked,
                        EklenmeTarihi = DateTime.Now,
                        Email = txtEmail.Text,
                        KullaniciAdi = txtKullaniciAdi.Text,
                        RolId = int.Parse(cbKullaniciRolu.SelectedValue.ToString()),
                        Sifre = txtSifre.Text,
                        Soyadi = txtSoyadi.Text,
                        Telefon = txtTelefon.Text
                    }
                    );
                    if (islemSonucu > 0)
                    {
                        Yukle();
                        Temizle();
                        MessageBox.Show("Kayıt Güncellendi!");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Hata Oluştu! Kayıt Güncellenemedi!");
            }
        }

       
            private void bntSil_Click(object sender, EventArgs e)
        {
            try
            {
                if (LblId.Text != "0")
                {
                    int kulId = Convert.ToInt32(LblId.Text);

                    // Kullanıcıyı silmek için onay isteyin
                    var confirmResult = MessageBox.Show("Bu kullanıcıyı silmek istediğinizden emin misiniz?",
                                                        "Kullanıcı Silme",
                                                        MessageBoxButtons.YesNo,
                                                        MessageBoxIcon.Question);
                    if (confirmResult == DialogResult.Yes)
                    {
                        int islemSonucu = manager.Delete(kulId);
                        if (islemSonucu > 0)
                        {
                            Yukle(); // Kullanıcı listesi yeniden yüklenir
                            Temizle(); // Form alanları temizlenir
                            MessageBox.Show("Kullanıcı başarıyla silindi!");
                        }
                        else
                        {
                            MessageBox.Show("Kullanıcı silinemedi. Lütfen tekrar deneyin.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen silmek istediğiniz bir kullanıcıyı seçin.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata oluştu: {ex.Message}");
            }
        }

        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvKullanicilar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int kulId = Convert.ToInt32(dgvKullanicilar.CurrentRow.Cells[0].Value);
                if (kulId > 0)
                {
                    var kullanici = manager.Find(kulId);
                    txtAdi.Text = kullanici.Adi;
                    txtEmail.Text = kullanici.Email;
                    txtKullaniciAdi.Text = kullanici.KullaniciAdi;
                    txtSifre.Text = kullanici.Sifre;
                    txtSoyadi.Text = kullanici.Soyadi;
                    txtTelefon.Text = kullanici.Telefon;
                    cbAktif.Checked = kullanici.AktifMi;
                    cbKullaniciRolu.SelectedValue = kullanici.RolId;
                    lblEklenmeTarihi.Text = kullanici.EklenmeTarihi.ToString();
                    LblId.Text = kullanici.Id.ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Hata Oluştu!");
            }
        }
    }
}
