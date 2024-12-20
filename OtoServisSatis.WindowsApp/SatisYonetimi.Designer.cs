namespace OtoServisSatis.WindowsApp
{
    partial class SatisYonetimi
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SatisYonetimi));
            this.dgvSatislar = new System.Windows.Forms.DataGridView();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.dtpSatisTarihi = new System.Windows.Forms.DateTimePicker();
            this.cbMusteri = new System.Windows.Forms.ComboBox();
            this.cbArac = new System.Windows.Forms.ComboBox();
            this.pictureEdit9 = new DevExpress.XtraEditors.PictureEdit();
            this.pictureEdit2 = new DevExpress.XtraEditors.PictureEdit();
            this.pictureEdit4 = new DevExpress.XtraEditors.PictureEdit();
            this.btnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.btnGüncelle = new DevExpress.XtraEditors.SimpleButton();
            this.bntSil = new DevExpress.XtraEditors.SimpleButton();
            this.txtSatisFiyati = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSatislar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit9.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSatislar
            // 
            this.dgvSatislar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSatislar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSatislar.Location = new System.Drawing.Point(12, 12);
            this.dgvSatislar.Name = "dgvSatislar";
            this.dgvSatislar.Size = new System.Drawing.Size(566, 255);
            this.dgvSatislar.TabIndex = 1;
            this.dgvSatislar.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSatislar_CellClick);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.dtpSatisTarihi);
            this.groupControl1.Controls.Add(this.cbMusteri);
            this.groupControl1.Controls.Add(this.cbArac);
            this.groupControl1.Controls.Add(this.pictureEdit9);
            this.groupControl1.Controls.Add(this.pictureEdit2);
            this.groupControl1.Controls.Add(this.pictureEdit4);
            this.groupControl1.Controls.Add(this.btnKaydet);
            this.groupControl1.Controls.Add(this.pictureEdit1);
            this.groupControl1.Controls.Add(this.btnGüncelle);
            this.groupControl1.Controls.Add(this.bntSil);
            this.groupControl1.Controls.Add(this.txtSatisFiyati);
            this.groupControl1.Controls.Add(this.label8);
            this.groupControl1.Controls.Add(this.label3);
            this.groupControl1.Controls.Add(this.label2);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Controls.Add(this.lblId);
            this.groupControl1.Location = new System.Drawing.Point(12, 274);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(566, 131);
            this.groupControl1.TabIndex = 2;
            this.groupControl1.Text = "Satış Bilgileri";
            // 
            // dtpSatisTarihi
            // 
            this.dtpSatisTarihi.Location = new System.Drawing.Point(322, 32);
            this.dtpSatisTarihi.Name = "dtpSatisTarihi";
            this.dtpSatisTarihi.Size = new System.Drawing.Size(175, 21);
            this.dtpSatisTarihi.TabIndex = 4;
            // 
            // cbMusteri
            // 
            this.cbMusteri.DisplayMember = "Adi";
            this.cbMusteri.FormattingEnabled = true;
            this.cbMusteri.Location = new System.Drawing.Point(125, 58);
            this.cbMusteri.Name = "cbMusteri";
            this.cbMusteri.Size = new System.Drawing.Size(100, 21);
            this.cbMusteri.TabIndex = 2;
            this.cbMusteri.ValueMember = "Id";
            // 
            // cbArac
            // 
            this.cbArac.DisplayMember = "Adi";
            this.cbArac.FormattingEnabled = true;
            this.cbArac.Location = new System.Drawing.Point(125, 29);
            this.cbArac.Name = "cbArac";
            this.cbArac.Size = new System.Drawing.Size(100, 21);
            this.cbArac.TabIndex = 1;
            this.cbArac.ValueMember = "Id";
            // 
            // pictureEdit9
            // 
            this.pictureEdit9.EditValue = ((object)(resources.GetObject("pictureEdit9.EditValue")));
            this.pictureEdit9.Location = new System.Drawing.Point(231, 29);
            this.pictureEdit9.Name = "pictureEdit9";
            this.pictureEdit9.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit9.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit9.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit9.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.pictureEdit9.Size = new System.Drawing.Size(20, 20);
            this.pictureEdit9.TabIndex = 61;
            // 
            // pictureEdit2
            // 
            this.pictureEdit2.EditValue = ((object)(resources.GetObject("pictureEdit2.EditValue")));
            this.pictureEdit2.Location = new System.Drawing.Point(27, 96);
            this.pictureEdit2.Name = "pictureEdit2";
            this.pictureEdit2.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit2.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit2.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit2.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.pictureEdit2.Size = new System.Drawing.Size(20, 20);
            this.pictureEdit2.TabIndex = 55;
            // 
            // pictureEdit4
            // 
            this.pictureEdit4.EditValue = ((object)(resources.GetObject("pictureEdit4.EditValue")));
            this.pictureEdit4.Location = new System.Drawing.Point(27, 58);
            this.pictureEdit4.Name = "pictureEdit4";
            this.pictureEdit4.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit4.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit4.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit4.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.pictureEdit4.Size = new System.Drawing.Size(20, 20);
            this.pictureEdit4.TabIndex = 54;
            // 
            // btnKaydet
            // 
            this.btnKaydet.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnKaydet.ImageOptions.Image")));
            this.btnKaydet.Location = new System.Drawing.Point(258, 85);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnKaydet.Size = new System.Drawing.Size(92, 31);
            this.btnKaydet.TabIndex = 5;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.EditValue = ((object)(resources.GetObject("pictureEdit1.EditValue")));
            this.pictureEdit1.Location = new System.Drawing.Point(27, 26);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.pictureEdit1.Size = new System.Drawing.Size(20, 20);
            this.pictureEdit1.TabIndex = 53;
            // 
            // btnGüncelle
            // 
            this.btnGüncelle.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnGüncelle.ImageOptions.Image")));
            this.btnGüncelle.Location = new System.Drawing.Point(356, 85);
            this.btnGüncelle.Name = "btnGüncelle";
            this.btnGüncelle.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnGüncelle.Size = new System.Drawing.Size(89, 31);
            this.btnGüncelle.TabIndex = 6;
            this.btnGüncelle.Text = "Güncelle";
            this.btnGüncelle.Click += new System.EventHandler(this.btnGüncelle_Click);
            // 
            // bntSil
            // 
            this.bntSil.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bntSil.ImageOptions.Image")));
            this.bntSil.Location = new System.Drawing.Point(451, 85);
            this.bntSil.Name = "bntSil";
            this.bntSil.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.bntSil.Size = new System.Drawing.Size(89, 31);
            this.bntSil.TabIndex = 7;
            this.bntSil.Text = "Sil";
            this.bntSil.Click += new System.EventHandler(this.bntSil_Click);
            // 
            // txtSatisFiyati
            // 
            this.txtSatisFiyati.Location = new System.Drawing.Point(125, 96);
            this.txtSatisFiyati.Name = "txtSatisFiyati";
            this.txtSatisFiyati.Size = new System.Drawing.Size(100, 21);
            this.txtSatisFiyati.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(55, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 13);
            this.label8.TabIndex = 42;
            this.label8.Text = "Araç";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 36;
            this.label3.Text = "Satış Fiyatı";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 35;
            this.label2.Text = "Müşteri";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(257, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "Satış Tarihi";
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(527, 29);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(13, 13);
            this.lblId.TabIndex = 32;
            this.lblId.Text = "0";
            // 
            // SatisYonetimi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 414);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.dgvSatislar);
            this.Name = "SatisYonetimi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Satış Yönetimi";
            this.Load += new System.EventHandler(this.SatisYonetimi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSatislar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit9.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSatislar;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.ComboBox cbMusteri;
        private System.Windows.Forms.ComboBox cbArac;
        private DevExpress.XtraEditors.PictureEdit pictureEdit9;
        private DevExpress.XtraEditors.PictureEdit pictureEdit2;
        private DevExpress.XtraEditors.PictureEdit pictureEdit4;
        private DevExpress.XtraEditors.SimpleButton btnKaydet;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraEditors.SimpleButton btnGüncelle;
        private DevExpress.XtraEditors.SimpleButton bntSil;
        private System.Windows.Forms.TextBox txtSatisFiyati;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.DateTimePicker dtpSatisTarihi;
    }
}