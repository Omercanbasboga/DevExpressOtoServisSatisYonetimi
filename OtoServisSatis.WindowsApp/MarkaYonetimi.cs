using OtoServisSatis.BL;
using OtoServisSatis.Entities;
using System;
using System.Linq;
using System.Windows.Forms;

namespace OtoServisSatis.WindowsApp
{
    public partial class MarkaYonetimi : Form
    {
        public MarkaYonetimi()
        {
            InitializeComponent();
        }

        private MarkaManager manager = new MarkaManager();

        // Verileri yükleme metodu
        void Yukle()
        {
            try
            {
                var markalar = manager.GetAll();
                if (markalar == null || !markalar.Any())
                {
                    MessageBox.Show("Veritabanında kayıtlı marka bulunamadı.");
                    dgvMarkalar.DataSource = null;
                }
                else
                {
                    dgvMarkalar.DataSource = markalar;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Markalar yüklenirken bir hata oluştu: {ex.Message}");
            }
        }

        // Form alanlarını temizleme metodu
        void Temizle()
        {
            lblId.Text = "0";
            txtMarkaAdi.Text = string.Empty;
        }

        // DataGridView'deki hücreye tıklama olayı
        private void dgvMarkalar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0) // Tıklanan hücrenin geçerli bir satıra ait olduğunu kontrol edin
                {
                    lblId.Text = dgvMarkalar.Rows[e.RowIndex].Cells["Id"].Value.ToString();
                    txtMarkaAdi.Text = dgvMarkalar.Rows[e.RowIndex].Cells["Adi"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hücre seçilirken bir hata oluştu: {ex.Message}");
            }
        }

        // Form yüklendiğinde çağrılan olay
        private void MarkaYonetimi_Load(object sender, EventArgs e)
        {
            Yukle();
        }

        // Marka ekleme butonuna tıklama olayı
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMarkaAdi.Text))
                {
                    MessageBox.Show("Marka adı boş olamaz! Lütfen bir marka adı giriniz.");
                    return;
                }

                int islemSonucu = manager.Add(new Marka { Adi = txtMarkaAdi.Text });

                if (islemSonucu > 0)
                {
                    Yukle();
                    Temizle();
                    MessageBox.Show("Marka başarıyla eklendi!");
                }
                else
                {
                    MessageBox.Show("Marka eklenemedi!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata oluştu! Kayıt eklenemedi: {ex.Message}");
            }
        }

        // Marka güncelleme butonuna tıklama olayı
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblId.Text == "0")
                {
                    MessageBox.Show("Lütfen güncellemek istediğiniz bir marka seçin.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtMarkaAdi.Text))
                {
                    MessageBox.Show("Marka adı boş olamaz! Lütfen bir marka adı giriniz.");
                    return;
                }

                int islemSonucu = manager.Update(new Marka
                {
                    Id = int.Parse(lblId.Text),
                    Adi = txtMarkaAdi.Text
                });

                if (islemSonucu > 0)
                {
                    Yukle();
                    Temizle();
                    MessageBox.Show("Marka başarıyla güncellendi!");
                }
                else
                {
                    MessageBox.Show("Marka güncellenemedi! Lütfen değişiklik yaptığınızdan emin olun.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata oluştu! Kayıt güncellenemedi: {ex.Message}");
            }
        }

        // Marka silme butonuna tıklama olayı
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblId.Text == "0")
                {
                    MessageBox.Show("Lütfen silmek istediğiniz bir marka seçin.");
                    return;
                }

                var confirmResult = MessageBox.Show("Bu markayı silmek istediğinizden emin misiniz?",
                                                    "Marka Silme Onayı",
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    var marka = manager.Get(int.Parse(lblId.Text));
                    int islemSonucu = manager.Delete(marka);

                    if (islemSonucu > 0)
                    {
                        Yukle();
                        Temizle();
                        MessageBox.Show("Marka başarıyla silindi!");
                    }
                    else
                    {
                        MessageBox.Show("Marka silinemedi!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata oluştu! Kayıt silinemedi: {ex.Message}");
            }
        }
    }
}
