namespace OtoServisSatis.WindowsApp
{
    partial class RolYonetimi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RolYonetimi));
            this.dgvRoller = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.btnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.btnGüncelle = new DevExpress.XtraEditors.SimpleButton();
            this.bntSil = new DevExpress.XtraEditors.SimpleButton();
            this.txtRolAdi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoller)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRoller
            // 
            this.dgvRoller.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRoller.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRoller.Location = new System.Drawing.Point(12, 10);
            this.dgvRoller.Name = "dgvRoller";
            this.dgvRoller.Size = new System.Drawing.Size(291, 211);
            this.dgvRoller.TabIndex = 0;
            this.dgvRoller.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRoller_CellClick);
            this.dgvRoller.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRoller_CellContentClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureEdit1);
            this.groupBox1.Controls.Add(this.btnKaydet);
            this.groupBox1.Controls.Add(this.btnGüncelle);
            this.groupBox1.Controls.Add(this.bntSil);
            this.groupBox1.Controls.Add(this.txtRolAdi);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblId);
            this.groupBox1.Location = new System.Drawing.Point(12, 227);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(291, 113);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Rol Bilgileri";
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.EditValue = ((object)(resources.GetObject("pictureEdit1.EditValue")));
            this.pictureEdit1.Location = new System.Drawing.Point(2, 22);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.pictureEdit1.Size = new System.Drawing.Size(44, 38);
            this.pictureEdit1.TabIndex = 9;
            // 
            // btnKaydet
            // 
            this.btnKaydet.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnKaydet.ImageOptions.Image")));
            this.btnKaydet.Location = new System.Drawing.Point(2, 66);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnKaydet.Size = new System.Drawing.Size(92, 31);
            this.btnKaydet.TabIndex = 2;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // btnGüncelle
            // 
            this.btnGüncelle.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnGüncelle.ImageOptions.Image")));
            this.btnGüncelle.Location = new System.Drawing.Point(100, 66);
            this.btnGüncelle.Name = "btnGüncelle";
            this.btnGüncelle.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnGüncelle.Size = new System.Drawing.Size(89, 31);
            this.btnGüncelle.TabIndex = 3;
            this.btnGüncelle.Text = "Güncelle";
            this.btnGüncelle.Click += new System.EventHandler(this.btnGüncelle_Click);
            // 
            // bntSil
            // 
            this.bntSil.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bntSil.ImageOptions.Image")));
            this.bntSil.Location = new System.Drawing.Point(195, 66);
            this.bntSil.Name = "bntSil";
            this.bntSil.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.bntSil.Size = new System.Drawing.Size(89, 31);
            this.bntSil.TabIndex = 4;
            this.bntSil.Text = "Sil";
            this.bntSil.Click += new System.EventHandler(this.bntSil_Click);
            // 
            // txtRolAdi
            // 
            this.txtRolAdi.Location = new System.Drawing.Point(116, 36);
            this.txtRolAdi.Name = "txtRolAdi";
            this.txtRolAdi.Size = new System.Drawing.Size(100, 20);
            this.txtRolAdi.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Rol Adı";
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(242, 40);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(13, 13);
            this.lblId.TabIndex = 0;
            this.lblId.Text = "0";
            // 
            // RolYonetimi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 345);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvRoller);
            this.Name = "RolYonetimi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rol Yönetimi";
            this.Load += new System.EventHandler(this.RolYonetimi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoller)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRoller;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraEditors.SimpleButton btnKaydet;
        private DevExpress.XtraEditors.SimpleButton btnGüncelle;
        private DevExpress.XtraEditors.SimpleButton bntSil;
        private System.Windows.Forms.TextBox txtRolAdi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblId;
    }
}