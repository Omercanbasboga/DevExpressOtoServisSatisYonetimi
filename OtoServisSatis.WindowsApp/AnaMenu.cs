using OtoServisSatis.BL;
using System;
using System.Linq;
using System.Windows.Forms;

namespace OtoServisSatis.WindowsApp
{
    public partial class AnaMenu : Form
    {
        public AnaMenu()
        {
            InitializeComponent();
        }

        private void AnaMenu_Load(object sender, EventArgs e)
        {
            LoadChart(); // Form yüklenirken marka chart'ını yükle
            LoadModelYearChart(); // Model yılı chart'ını yükle
        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AracYonetimi aracYonetimi = new AracYonetimi();
            aracYonetimi.FormClosed += (s, args) =>
            {
                LoadChart(); // Marka chart'ını güncelle
                LoadModelYearChart(); // Model yılı chart'ını güncelle
            };
            aracYonetimi.ShowDialog();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            KullaniciYonetimi kullaniciYonetimi = new KullaniciYonetimi();
            kullaniciYonetimi.ShowDialog();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MarkaYonetimi markaYonetimi = new MarkaYonetimi();
            markaYonetimi.ShowDialog();
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MusteriYonetimi musteriYonetimi = new MusteriYonetimi();
            musteriYonetimi.ShowDialog();
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            RolYonetimi rolYonetimi = new RolYonetimi();
            rolYonetimi.ShowDialog();
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SatisYonetimi satisYonetimi = new SatisYonetimi();
            satisYonetimi.ShowDialog();
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ServisYonetimi servisYonetimi = new ServisYonetimi();
            servisYonetimi.ShowDialog();
        }

        private void AnaMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void LoadChart()
        {
            using (var context = new DatabaseContext())
            {
                var manager = new AracManager();
                var markaVerileri = manager.GetAracMarkaGruplama();

                chartAracMarka.Series.Clear();

                var series = new System.Windows.Forms.DataVisualization.Charting.Series
                {
                    Name = "Marka - Araç Sayısı",
                    ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column
                };

                chartAracMarka.Series.Add(series);

                foreach (var veri in markaVerileri)
                {
                    series.Points.AddXY(veri.MarkaAdi, veri.AracSayisi);
                }

                chartAracMarka.ChartAreas[0].AxisX.Title = "Marka Adı";
                chartAracMarka.ChartAreas[0].AxisY.Title = "Araç Sayısı";
            }
        }

        private void LoadModelYearChart()
        {
            using (var context = new DatabaseContext())
            {
                var manager = new AracManager();
                var modelYearData = manager.GetAll()
                    .GroupBy(a => a.ModelYili)
                    .Select(group => new
                    {
                        ModelYili = group.Key,
                        AracSayisi = group.Count()
                    })
                    .ToList();

                chartAracModelYili.Series.Clear();

                var series = new System.Windows.Forms.DataVisualization.Charting.Series
                {
                    Name = "Model Yılı - Araç Sayısı",
                    ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut // Doughnut Chart
                };

                chartAracModelYili.Series.Add(series);

                foreach (var data in modelYearData)
                {
                    series.Points.AddXY(data.ModelYili, data.AracSayisi);
                }

                chartAracModelYili.Series[0]["PieLabelStyle"] = "Outside"; // Etiketlerin dışarıda görünmesi
                chartAracModelYili.Legends[0].Enabled = true; // Legend (Açıklama) etkinleştirildi
            }
        }
    }
}
