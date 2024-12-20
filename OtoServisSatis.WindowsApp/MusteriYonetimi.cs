using DevExpress.Utils.DirectXPaint;
using DevExpress.XtraEditors; // DevExpress mesaj kutuları için
using OtoServisSatis.BL;
using OtoServisSatis.Entities;
using System;
using System.Linq;
using System.Windows.Forms;

namespace OtoServisSatis.WindowsApp
{
    public partial class MusteriYonetimi : Form
    {
        public MusteriYonetimi()
        {
            InitializeComponent();
        }

        private MusteriManager manager = new MusteriManager();
        private AracManager aracManager = new AracManager();

        // Verileri yükleme metodu
        void Yukle()
        {
            try
            {
                // Müşteri verilerini yükle
                var musteriler = manager.GetAll();
                if (musteriler == null || !musteriler.Any())
                {
                    XtraMessageBox.Show("Veritabanında müşteri kaydı bulunamadı.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvMusteriler.DataSource = null;
                }
                else
                {
                    dgvMusteriler.DataSource = musteriler;
                }

                // Araç verilerini yükle
                var araclar = aracManager.GetAll();
                if (araclar == null || !araclar.Any())
                {
                    XtraMessageBox.Show("Veritabanında araç kaydı bulunamadı.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbAracId.DataSource = null;
                }
                else
                {
                    cbAracId.DataSource = araclar;
                    cbAracId.DisplayMember = "Modeli";
                    cbAracId.ValueMember = "Id";
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Veriler yüklenirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Form alanlarını temizleme metodu
        void Temizle()
        {
            try
            {
                var nesneler = groupControl1.Controls.OfType<TextBox>();
                foreach (var item in nesneler)
                {
                    item.Clear();
                }
                lblId.Text = "0";
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Temizleme sırasında bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Form yüklendiğinde çağrılan olay
        private void MusteriYonetimi_Load(object sender, EventArgs e)
        {
            Yukle();
        }

        // Müşteri kaydetme işlemi
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtAdi.Text) || string.IsNullOrWhiteSpace(txtSoyadi.Text) || cbAracId.SelectedValue == null)
                {
                    XtraMessageBox.Show("Lütfen gerekli tüm alanları doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var sonuc = manager.Add(new Musteri
                {
                    Adi = txtAdi.Text,
                    Adres = txtAdres.Text,
                    AracId = Convert.ToInt32(cbAracId.SelectedValue),
                    Email = txtEmail.Text,
                    Notlar = txtNotlar.Text,
                    Soyadi = txtSoyadi.Text,
                    TcNo = txtTcNo.Text,
                    Telefon = txtTelefon.Text
                });

                if (sonuc > 0)
                {
                    Temizle();
                    Yukle();
                    XtraMessageBox.Show("Kayıt başarıyla eklendi!", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    XtraMessageBox.Show("Kayıt eklenemedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Kayıt eklenirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Müşteri güncelleme işlemi
        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblId.Text == "0")
                {
                    XtraMessageBox.Show("Lütfen güncellenecek bir kayıt seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var sonuc = manager.Update(new Musteri
                {
                    Id = Convert.ToInt32(lblId.Text),
                    Adi = txtAdi.Text,
                    Adres = txtAdres.Text,
                    AracId = Convert.ToInt32(cbAracId.SelectedValue),
                    Email = txtEmail.Text,
                    Notlar = txtNotlar.Text,
                    Soyadi = txtSoyadi.Text,
                    TcNo = txtTcNo.Text,
                    Telefon = txtTelefon.Text
                });

                if (sonuc > 0)
                {
                    Temizle();
                    Yukle();
                    XtraMessageBox.Show("Kayıt başarıyla güncellendi!", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    XtraMessageBox.Show("Kayıt güncellenemedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Kayıt güncellenirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Müşteri silme işlemi
        private void bntSil_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblId.Text == "0")
                {
                    XtraMessageBox.Show("Lütfen silinecek bir kayıt seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var confirmResult = XtraMessageBox.Show("Bu kaydı silmek istediğinizden emin misiniz?",
                                                        "Silme Onayı",
                                                        MessageBoxButtons.YesNo,
                                                        MessageBoxIcon.Warning);

                if (confirmResult == DialogResult.Yes)
                {
                    var sonuc = manager.Delete(Convert.ToInt32(lblId.Text));
                    if (sonuc > 0)
                    {
                        Temizle();
                        Yukle();
                        XtraMessageBox.Show("Kayıt başarıyla silindi!", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        XtraMessageBox.Show("Kayıt silinemedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Kayıt silinirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // DataGridView'de bir satır seçildiğinde verileri forma doldurma
        private void dgvMusteriler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvMusteriler.CurrentRow == null || dgvMusteriler.CurrentRow.Cells[0].Value == null)
                {
                    XtraMessageBox.Show("Geçerli bir satır seçilmedi!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var musteri = manager.Find(Convert.ToInt32(dgvMusteriler.CurrentRow.Cells[0].Value));
                if (musteri != null)
                {
                    txtAdi.Text = musteri.Adi;
                    txtAdres.Text = musteri.Adres;
                    txtEmail.Text = musteri.Email;
                    txtNotlar.Text = musteri.Notlar;
                    txtSoyadi.Text = musteri.Soyadi;
                    txtTcNo.Text = musteri.TcNo;
                    txtTelefon.Text = musteri.Telefon;
                    cbAracId.SelectedValue = musteri.AracId;
                    lblId.Text = musteri.Id.ToString();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Hata oluştu! Bilgiler yüklenemedi: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
