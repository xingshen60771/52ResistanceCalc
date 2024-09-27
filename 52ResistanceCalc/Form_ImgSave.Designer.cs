namespace _52ResistanceCalc
{
    partial class Form_ImgSave
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
            this.img_ShareView = new System.Windows.Forms.PictureBox();
            this.btn_saveas = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.label_preview = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.img_ShareView)).BeginInit();
            this.SuspendLayout();
            // 
            // img_ShareView
            // 
            this.img_ShareView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.img_ShareView.Location = new System.Drawing.Point(15, 45);
            this.img_ShareView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.img_ShareView.Name = "img_ShareView";
            this.img_ShareView.Size = new System.Drawing.Size(799, 600);
            this.img_ShareView.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.img_ShareView.TabIndex = 0;
            this.img_ShareView.TabStop = false;
            // 
            // btn_saveas
            // 
            this.btn_saveas.Location = new System.Drawing.Point(715, 658);
            this.btn_saveas.Margin = new System.Windows.Forms.Padding(4);
            this.btn_saveas.Name = "btn_saveas";
            this.btn_saveas.Size = new System.Drawing.Size(100, 29);
            this.btn_saveas.TabIndex = 1;
            this.btn_saveas.Text = "保存图片";
            this.btn_saveas.UseVisualStyleBackColor = true;
            this.btn_saveas.Click += new System.EventHandler(this.Btn_SaveAs_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(607, 658);
            this.btn_Cancel.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(100, 29);
            this.btn_Cancel.TabIndex = 2;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.Btn_Cancel_Click);
            // 
            // label_preview
            // 
            this.label_preview.AutoSize = true;
            this.label_preview.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_preview.Location = new System.Drawing.Point(16, 11);
            this.label_preview.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_preview.Name = "label_preview";
            this.label_preview.Size = new System.Drawing.Size(89, 20);
            this.label_preview.TabIndex = 3;
            this.label_preview.Text = "图片预览";
            // 
            // Form_ImgSave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 701);
            this.Controls.Add(this.label_preview);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_saveas);
            this.Controls.Add(this.img_ShareView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_ImgSave";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "保存与分享";
            this.Load += new System.EventHandler(this.Form_imgsave_Load);
            ((System.ComponentModel.ISupportInitialize)(this.img_ShareView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox img_ShareView;
        private System.Windows.Forms.Button btn_saveas;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Label label_preview;
    }
}