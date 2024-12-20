using DevExpress.XtraEditors; // DevExpress mesaj kutuları için
using OtoServisSatis.BL;
using OtoServisSatis.Entities;
using System;
using System.Linq;
using System.Windows.Forms;

namespace OtoServisSatis.WindowsApp
{
    public partial class SatisYonetimi : Form
    {
        public SatisYonetimi()
        {
            InitializeComponent();
        }

        private SatisManager manager = new SatisManager();
        private AracManager aracManager = new AracManager();
        private MusteriManager musteriManager = new MusteriManager();

        // Verileri yükleme metodu
        void Yukle()
        {
            try
            {
                // Satış verilerini yükle
                var satislar = manager.GetAll();
                if (satislar == null || !satislar.Any())
                {
                    XtraMessageBox.Show("Veritabanında satış kaydı bulunamadı.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvSatislar.DataSource = null;
                }
                else
                {
                    dgvSatislar.DataSource = satislar;
                }

                // Araç verilerini yükle
                var araclar = aracManager.GetAll();
                if (araclar == null || !araclar.Any())
                {
                    XtraMessageBox.Show("Veritabanında araç kaydı bulunamadı.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbArac.DataSource = null;
                }
                else
                {
                    cbArac.DataSource = araclar;
                    cbArac.DisplayMember = "Modeli";
                    cbArac.ValueMember = "Id";
                }

                // Müşteri verilerini yükle
                var musteriler = musteriManager.GetAll();
                if (musteriler == null || !musteriler.Any())
                {
                    XtraMessageBox.Show("Veritabanında müşteri kaydı bulunamadı.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbMusteri.DataSource = null;
                }
                else
                {
                    cbMusteri.DataSource = musteriler;
                    cbMusteri.DisplayMember = "Adi";
                    cbMusteri.ValueMember = "Id";
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
        private void SatisYonetimi_Load(object sender, EventArgs e)
        {
            Yukle();
        }

        // Satış kaydetme işlemi
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtSatisFiyati.Text) || cbArac.SelectedValue == null || cbMusteri.SelectedValue == null)
                {
                    XtraMessageBox.Show("Lütfen gerekli tüm alanları doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var sonuc = manager.Add(new Satis
                {
                    AracId = Convert.ToInt32(cbArac.SelectedValue),
                    MusteriId = Convert.ToInt32(cbMusteri.SelectedValue),
                    SatisFiyati = Convert.ToDecimal(txtSatisFiyati.Text),
                    SatisTarihi = dtpSatisTarihi.Value
                });

                if (sonuc > 0)
                {
                    Temizle();
                    Yukle();
                    XtraMessageBox.Show("Satış başarıyla kaydedildi!", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    XtraMessageBox.Show("Satış kaydedilemedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Satış kaydedilirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Satış güncelleme işlemi
        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblId.Text == "0")
                {
                    XtraMessageBox.Show("Lütfen güncellenecek bir kayıt seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var sonuc = manager.Update(new Satis
                {
                    Id = Convert.ToInt32(lblId.Text),
                    AracId = Convert.ToInt32(cbArac.SelectedValue),
                    MusteriId = Convert.ToInt32(cbMusteri.SelectedValue),
                    SatisFiyati = Convert.ToDecimal(txtSatisFiyati.Text),
                    SatisTarihi = dtpSatisTarihi.Value
                });

                if (sonuc > 0)
                {
                    Temizle();
                    Yukle();
                    XtraMessageBox.Show("Satış başarıyla güncellendi!", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    XtraMessageBox.Show("Satış güncellenemedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Satış güncellenirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Satış silme işlemi
        private void bntSil_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblId.Text == "0")
                {
                    XtraMessageBox.Show("Lütfen silinecek bir kayıt seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var confirmResult = XtraMessageBox.Show("Bu satışı silmek istediğinizden emin misiniz?",
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
                        XtraMessageBox.Show("Satış başarıyla silindi!", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        XtraMessageBox.Show("Satış silinemedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Satış silinirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // DataGridView'de bir satır seçildiğinde verileri forma doldurma
        private void dgvSatislar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvSatislar.CurrentRow == null || dgvSatislar.CurrentRow.Cells[0].Value == null)
                {
                    XtraMessageBox.Show("Geçerli bir satır seçilmedi!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var satis = manager.Find(Convert.ToInt32(dgvSatislar.CurrentRow.Cells[0].Value));
                if (satis != null)
                {
                    cbArac.SelectedValue = satis.AracId;
                    cbMusteri.SelectedValue = satis.MusteriId;
                    txtSatisFiyati.Text = satis.SatisFiyati.ToString();
                    dtpSatisTarihi.Value = satis.SatisTarihi;
                    lblId.Text = satis.Id.ToString();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Hata oluştu! Kayıt yüklenemedi: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
