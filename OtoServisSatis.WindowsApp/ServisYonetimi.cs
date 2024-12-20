using DevExpress.XtraEditors; // DevExpress mesaj kutuları için
using OtoServisSatis.BL;
using OtoServisSatis.Entities;
using System;
using System.Linq;
using System.Windows.Forms;
using System.Net.Mail; // E-posta gönderimi için
using System.IO; // Dosya işlemleri için
using PdfSharp.Pdf; // PdfSharp PDF oluşturma
using PdfSharp.Drawing; // PdfSharp çizim için

namespace OtoServisSatis.WindowsApp
{
    public partial class ServisYonetimi : Form
    {
        public ServisYonetimi()
        {
            InitializeComponent();
        }

        private ServisManager manager = new ServisManager();

        // Verileri yükleme metodu
        void Yukle()
        {
            try
            {
                var servisler = manager.GetAll();
                if (servisler == null || !servisler.Any())
                {
                    XtraMessageBox.Show("Veritabanında servis kaydı bulunamadı.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvServisler.DataSource = null;
                }
                else
                {
                    dgvServisler.DataSource = servisler;
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

        // PdfSharp kullanarak PDF oluşturma metodu
        private string CreatePDF(Servis servis)
        {
            // Masaüstü dizin yolunu alın
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePath = Path.Combine(desktopPath, $"Servis_{servis.Id}.pdf");

            try
            {
                // Yeni PDF belgesi oluştur
                PdfDocument document = new PdfDocument();
                document.Info.Title = "Servis Bilgileri";

                // PDF sayfası ekle
                PdfPage page = document.AddPage();
                XGraphics gfx = XGraphics.FromPdfPage(page);

                // Yazı fontlarını ayarla
                XFont titleFont = new XFont("Verdana", 16); 
                XFont regularFont = new XFont("Verdana", 12); 

                // Başlık ekle
                gfx.DrawString("Servis Bilgileri", titleFont, XBrushes.Black, new XRect(0, 20, page.Width, page.Height), XStringFormats.TopCenter);

                // Servis bilgilerini ekle
                int yPoint = 80;
                gfx.DrawString($"Araç Plaka: {servis.AracPlaka ?? "Bilinmiyor"}", regularFont, XBrushes.Black, new XPoint(40, yPoint)); yPoint += 20;
                gfx.DrawString($"Araç Sorunu: {servis.AracSorunu ?? "Bilinmiyor"}", regularFont, XBrushes.Black, new XPoint(40, yPoint)); yPoint += 20;
                gfx.DrawString($"Marka: {servis.Marka ?? "Bilinmiyor"}", regularFont, XBrushes.Black, new XPoint(40, yPoint)); yPoint += 20;
                gfx.DrawString($"Model: {servis.Model ?? "Bilinmiyor"}", regularFont, XBrushes.Black, new XPoint(40, yPoint)); yPoint += 20;
                gfx.DrawString($"Kasa Tipi: {servis.KasaTipi ?? "Bilinmiyor"}", regularFont, XBrushes.Black, new XPoint(40, yPoint)); yPoint += 20;
                gfx.DrawString($"Servis Ücreti: {servis.ServisUcreti:C}", regularFont, XBrushes.Black, new XPoint(40, yPoint)); yPoint += 20;
                gfx.DrawString($"Yapılan İşlemler: {servis.YapilanIslemler ?? "Bilinmiyor"}", regularFont, XBrushes.Black, new XPoint(40, yPoint)); yPoint += 20;
                gfx.DrawString($"Garanti Kapsamında Mı: {(servis.GarantiKapsamindaMi ? "Evet" : "Hayır")}", regularFont, XBrushes.Black, new XPoint(40, yPoint));

                // PDF dosyasını kaydet
                document.Save(filePath);

                return filePath;
            }
            catch (Exception ex)
            {
                // Hata mesajını göster ve null döndür
                XtraMessageBox.Show($"PDF oluşturulurken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


        // `SendEmailWithAttachment` metodu
        private void SendEmailWithAttachment(string emailAddress, string filePath)
        {
            try
            {
                using (var smtpClient = new SmtpClient("smtp.gmail.com", 587)) // Gmail SMTP sunucusu
                {
                    smtpClient.Credentials = new System.Net.NetworkCredential("gorselprogramlama48@gmail.com", "vexq nasi dwto acen"); // Gmail kullanıcı adı ve uygulama parolası
                    smtpClient.EnableSsl = true; // Güvenli bağlantı için SSL etkinleştirildi

                    var mailMessage = new MailMessage
                    {
                        From = new MailAddress("gorselprogramlama48@gmail.com"), // Gönderen adresi
                        Subject = "Yeni Servis Bilgileri", // E-posta konusu
                        Body = "Ekteki dosyada servis bilgileri bulunmaktadır.", // E-posta içeriği
                        IsBodyHtml = true // HTML içeriği destekleniyor
                    };

                    // Alıcı adresini ekle
                    mailMessage.To.Add(emailAddress);

                    // Ek dosya (PDF) ekle
                    if (!string.IsNullOrEmpty(filePath) && File.Exists(filePath)) // Ek dosya kontrolü
                    {
                        mailMessage.Attachments.Add(new Attachment(filePath));
                    }
                    else
                    {
                        throw new FileNotFoundException("Eklenecek dosya bulunamadı.");
                    }

                    // E-postayı gönder
                    smtpClient.Send(mailMessage);

                    // Başarılı gönderim bildirimi
                    XtraMessageBox.Show("E-posta başarıyla gönderildi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (FileNotFoundException fnfEx)
            {
                // Dosya bulunamadığında hata mesajı göster
                XtraMessageBox.Show($"E-posta gönderiminde hata oluştu: {fnfEx.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (SmtpException smtpEx)
            {
                // SMTP hatalarında hata mesajı göster
                XtraMessageBox.Show($"SMTP sunucusu ile ilgili bir hata oluştu: {smtpEx.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Diğer genel hatalarda hata mesajı göster
                XtraMessageBox.Show($"E-posta gönderiminde hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void dgvServisler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvServisler.CurrentRow == null || dgvServisler.CurrentRow.Cells[0].Value == null)
                {
                    XtraMessageBox.Show("Geçerli bir satır seçilmedi!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var servis = manager.Find(Convert.ToInt32(dgvServisler.CurrentRow.Cells[0].Value));
                if (servis != null)
                {
                    txtAracPlaka.Text = servis.AracPlaka;
                    txtAracSorunu.Text = servis.AracSorunu;
                    txtKasaTipi.Text = servis.KasaTipi;
                    txtMarka.Text = servis.Marka;
                    txtModel.Text = servis.Model;
                    txtNotlar.Text = servis.Notlar;
                    txtSaseNo.Text = servis.SaseNo;
                    txtServisUcreti.Text = servis.ServisUcreti.ToString();
                    txtYapilanIslemler.Text = servis.YapilanIslemler;
                    dtpServiseGelisTarihi.Value = servis.ServiseGelisTarihi;
                    dtpServistenCikisTarihi.Value = servis.ServistenCikisTarihi;
                    cbGaranti.Checked = servis.GarantiKapsamindaMi;
                    lblId.Text = servis.Id.ToString();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Hata oluştu! Kayıt yüklenemedi: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ServisYonetimi_Load(object sender, EventArgs e)
        {
            try
            {
                Yukle();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Form yüklenirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtAracPlaka.Text) || string.IsNullOrWhiteSpace(txtServisUcreti.Text))
                {
                    XtraMessageBox.Show("Lütfen gerekli tüm alanları doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var servis = new Servis
                {
                    AracPlaka = txtAracPlaka.Text,
                    AracSorunu = txtAracSorunu.Text,
                    GarantiKapsamindaMi = cbGaranti.Checked,
                    KasaTipi = txtKasaTipi.Text,
                    Marka = txtMarka.Text,
                    Model = txtModel.Text,
                    Notlar = txtNotlar.Text,
                    SaseNo = txtSaseNo.Text,
                    ServiseGelisTarihi = dtpServiseGelisTarihi.Value,
                    ServistenCikisTarihi = dtpServistenCikisTarihi.Value,
                    ServisUcreti = Convert.ToDecimal(txtServisUcreti.Text),
                    YapilanIslemler = txtYapilanIslemler.Text
                };

                var sonuc = manager.Add(servis);

                if (sonuc > 0)
                {
                    string pdfPath = CreatePDF(servis);
                    SendEmailWithAttachment("gorselprogramlama48@gmail.com", pdfPath);

                    Temizle();
                    Yukle();
                    XtraMessageBox.Show("Servis başarıyla kaydedildi ve e-posta gönderildi!", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    XtraMessageBox.Show("Servis kaydedilemedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Servis kaydedilirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblId.Text == "0" || string.IsNullOrWhiteSpace(lblId.Text))
                {
                    XtraMessageBox.Show("Lütfen güncellenecek bir kayıt seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtAracPlaka.Text) || string.IsNullOrWhiteSpace(txtServisUcreti.Text))
                {
                    XtraMessageBox.Show("Lütfen gerekli tüm alanları doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Güncellenecek Servis nesnesini oluştur
                var servis = new Servis
                {
                    Id = Convert.ToInt32(lblId.Text), // Güncellenecek kaydın Id'si
                    AracPlaka = txtAracPlaka.Text,
                    AracSorunu = txtAracSorunu.Text,
                    GarantiKapsamindaMi = cbGaranti.Checked,
                    KasaTipi = txtKasaTipi.Text,
                    Marka = txtMarka.Text,
                    Model = txtModel.Text,
                    Notlar = txtNotlar.Text,
                    SaseNo = txtSaseNo.Text,
                    ServiseGelisTarihi = dtpServiseGelisTarihi.Value,
                    ServistenCikisTarihi = dtpServistenCikisTarihi.Value,
                    ServisUcreti = decimal.TryParse(txtServisUcreti.Text, out var ucret) ? ucret : 0, // Ücret dönüşümü
                    YapilanIslemler = txtYapilanIslemler.Text
                };

                // Veritabanından mevcut kayıtları getir
                var mevcutServis = manager.Find(servis.Id);
                if (mevcutServis != null)
                {
                    // Yeni bilgiler mevcut bilgilerle aynı mı kontrol et
                    if (mevcutServis.AracPlaka == servis.AracPlaka &&
                        mevcutServis.AracSorunu == servis.AracSorunu &&
                        mevcutServis.GarantiKapsamindaMi == servis.GarantiKapsamindaMi &&
                        mevcutServis.KasaTipi == servis.KasaTipi &&
                        mevcutServis.Marka == servis.Marka &&
                        mevcutServis.Model == servis.Model &&
                        mevcutServis.Notlar == servis.Notlar &&
                        mevcutServis.SaseNo == servis.SaseNo &&
                        mevcutServis.ServiseGelisTarihi == servis.ServiseGelisTarihi &&
                        mevcutServis.ServistenCikisTarihi == servis.ServistenCikisTarihi &&
                        mevcutServis.ServisUcreti == servis.ServisUcreti &&
                        mevcutServis.YapilanIslemler == servis.YapilanIslemler)
                    {
                        // Eğer bilgiler aynıysa uyarı göster ve işlemi durdur
                        XtraMessageBox.Show("Girilen bilgiler önceki bilgilerle aynı. Lütfen farklı bilgiler girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // Veritabanında güncelleme işlemini yap
                var sonuc = manager.Update(servis);

                if (sonuc > 0) // Güncelleme başarılıysa
                {
                    // PDF oluştur
                    string pdfPath = CreatePDF(servis);

                    if (!string.IsNullOrEmpty(pdfPath)) // PDF başarıyla oluşturulmuşsa
                    {
                        // E-posta gönder
                        SendEmailWithAttachment("gorselprogramlama48@gmail.com", pdfPath);
                    }

                    Temizle(); // Formu temizle
                    Yukle();   // Veritabanındaki verileri yenile
                    XtraMessageBox.Show("Servis başarıyla güncellendi ve e-posta gönderildi!", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    XtraMessageBox.Show("Servis güncellenemedi. Lütfen veritabanı bağlantınızı ve servis Id'sini kontrol edin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (FormatException)
            {
                XtraMessageBox.Show("Servis ücreti geçerli bir sayı olmalıdır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Servis güncellenirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





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
                        XtraMessageBox.Show("Servis başarıyla silindi!", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        XtraMessageBox.Show("Servis silinemedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Servis silinirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
