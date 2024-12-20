using OtoServisSatis.BL;
using OtoServisSatis.Entities;
using System;
using System.Linq;
using System.Windows.Forms;

namespace OtoServisSatis.WindowsApp
{
    public partial class AracYonetimi : Form
    {
        public AracYonetimi()
        {
            InitializeComponent();
        }

        private AracManager manager = new AracManager();
        private MarkaManager markaManager = new MarkaManager();

        // Verileri yükleme metodu
        void Yukle()
        {
            try
            {
                var araclar = manager.GetAll();
                if (araclar == null || !araclar.Any())
                {
                    MessageBox.Show("Veritabanında araç kaydı bulunamadı.");
                    dgvAraclar.DataSource = null;
                }
                else
                {
                    dgvAraclar.DataSource = araclar;
                }

                var markalar = markaManager.GetAll();
                if (markalar == null || !markalar.Any())
                {
                    MessageBox.Show("Veritabanında marka kaydı bulunamadı.");
                    cbMarka.DataSource = null;
                }
                else
                {
                    cbMarka.DataSource = markalar;
                    cbMarka.DisplayMember = "Adi";
                    cbMarka.ValueMember = "Id";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Yükleme sırasında bir hata oluştu: {ex.Message}");
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
                LblId.Text = "0";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Temizleme sırasında bir hata oluştu: {ex.Message}");
            }
        }

        // Form yüklendiğinde verileri yükleme
        private void AracYonetimi_Load(object sender, EventArgs e)
        {
            Yukle();
        }

        // Araç kaydetme işlemi
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtFiyat.Text) || string.IsNullOrWhiteSpace(txtModel.Text))
                {
                    MessageBox.Show("Lütfen gerekli tüm alanları doldurun.");
                    return;
                }

                var sonuc = manager.Add(new Arac
                {
                    Fiyati = Convert.ToDecimal(txtFiyat.Text),
                    KasaTipi = txtKasaTipi.Text,
                    MarkaId = Convert.ToInt32(cbMarka.SelectedValue),
                    Modeli = txtModel.Text,
                    ModelYili = int.Parse(TxtModelYili.Text),
                    Notlar = TxtNotlar.Text,
                    Renk = txtRenk.Text,
                    SatistaMi = cbSatistaMi.Checked
                });

                if (sonuc > 0)
                {
                    Temizle();
                    Yukle();
                    MessageBox.Show("Kayıt başarıyla eklendi!");
                }
                else
                {
                    MessageBox.Show("Kayıt eklenemedi.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kayıt eklenirken bir hata oluştu: {ex.Message}");
            }
        }

        // DataGridView'de bir satır seçildiğinde verileri doldurma
        private void dgvAraclar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvAraclar.CurrentRow == null || dgvAraclar.CurrentRow.Cells[0].Value == null)
                {
                    MessageBox.Show("Geçerli bir satır seçilmedi!");
                    return;
                }

                LblId.Text = dgvAraclar.CurrentRow.Cells[0].Value.ToString();
                int aracId = Convert.ToInt32(LblId.Text);
                var arac = manager.Find(aracId);

                if (arac != null)
                {
                    txtFiyat.Text = arac.Fiyati.ToString();
                    txtKasaTipi.Text = arac.KasaTipi;
                    txtModel.Text = arac.Modeli;
                    TxtModelYili.Text = arac.ModelYili.ToString();
                    TxtNotlar.Text = arac.Notlar;
                    txtRenk.Text = arac.Renk;
                    cbSatistaMi.Checked = arac.SatistaMi;
                    cbMarka.SelectedValue = arac.MarkaId;
                }
                else
                {
                    MessageBox.Show("Seçilen araç bulunamadı.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Seçim sırasında bir hata oluştu: {ex.Message}");
            }
        }

        // Araç güncelleme işlemi
        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            try
            {
                if (LblId.Text == "0")
                {
                    MessageBox.Show("Listeden güncellenecek kaydı seçiniz!");
                    return;
                }

                var sonuc = manager.Update(new Arac
                {
                    Id = Convert.ToInt32(LblId.Text),
                    Fiyati = Convert.ToDecimal(txtFiyat.Text),
                    KasaTipi = txtKasaTipi.Text,
                    MarkaId = Convert.ToInt32(cbMarka.SelectedValue),
                    Modeli = txtModel.Text,
                    ModelYili = int.Parse(TxtModelYili.Text),
                    Notlar = TxtNotlar.Text,
                    Renk = txtRenk.Text,
                    SatistaMi = cbSatistaMi.Checked
                });

                if (sonuc > 0)
                {
                    Temizle();
                    Yukle();
                    MessageBox.Show("Kayıt başarıyla güncellendi!");
                }
                else
                {
                    MessageBox.Show("Kayıt güncellenemedi.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kayıt güncellenirken bir hata oluştu: {ex.Message}");
            }
        }

        // Araç silme işlemi
        private void bntSil_Click(object sender, EventArgs e)
        {
            try
            {
                if (LblId.Text == "0")
                {
                    MessageBox.Show("Listeden silinecek kaydı seçiniz!");
                    return;
                }

                var confirmResult = MessageBox.Show("Bu kaydı silmek istediğinizden emin misiniz?",
                                                    "Silme Onayı",
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Warning);

                if (confirmResult == DialogResult.Yes)
                {
                    var sonuc = manager.Delete(Convert.ToInt32(LblId.Text));
                    if (sonuc > 0)
                    {
                        Temizle();
                        Yukle();
                        MessageBox.Show("Kayıt başarıyla silindi!");
                    }
                    else
                    {
                        MessageBox.Show("Kayıt silinemedi.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kayıt silinirken bir hata oluştu: {ex.Message}");
            }
        }
    }
}
