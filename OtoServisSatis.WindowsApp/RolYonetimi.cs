using OtoServisSatis.BL;
using OtoServisSatis.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtoServisSatis.WindowsApp
{
    public partial class RolYonetimi : Form
    {
        public RolYonetimi()
        {
            InitializeComponent();
        }

        private RoleManager roleManager = new RoleManager();
          void Yukle()
        {
            dgvRoller.DataSource = roleManager.GetAll();
        }
        void Temizle()
        {
            txtRolAdi.Text = string.Empty;
            lblId.Text = "0";
        }

        private void dgvRoller_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                var sonuc = roleManager.Add(
                    new Rol
                    {
                        Adi = txtRolAdi.Text
                    }
                    );
                if (sonuc > 0)
                {
                    Temizle();
                    Yukle();
                    MessageBox.Show("Kayıt Eklendi!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Hata Oluştu! Kayıt Eklenemedi!");
            }
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblId.Text == "0")
                {
                    MessageBox.Show("Listeden güncellenecek kaydı seçiniz!");
                }
                else
                {
                    int rolId = Convert.ToInt32(dgvRoller.CurrentRow.Cells[0].Value);
                    var sonuc = roleManager.Update(
                        new Rol
                        {
                            Id = rolId,
                            Adi = txtRolAdi.Text
                        }
                        );
                    if (sonuc > 0)
                    {
                        Temizle();
                        Yukle();
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
                if (lblId.Text == "0")
                {
                    MessageBox.Show("Listeden silinecek kaydı seçiniz!");
                }
                else
                {
                    var sonuc = roleManager.Delete(Convert.ToInt32(lblId.Text));
                    if (sonuc > 0)
                    {
                        Temizle();
                        Yukle();
                        MessageBox.Show("Kayıt Silindi!");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Hata Oluştu! Kayıt Silinemedi!");
            }
        }

        private void RolYonetimi_Load(object sender, EventArgs e)
        {
            Yukle();    
        }

        private void dgvRoller_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //int rolId = Convert.ToInt32(dgvRoller.CurrentRow.Cells[0].Value);
                lblId.Text = dgvRoller.CurrentRow.Cells[0].Value.ToString();
                txtRolAdi.Text = dgvRoller.CurrentRow.Cells[1].Value.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Hata Oluştu! Kayıt Atanamadı!");
            }
        }
    }
}
