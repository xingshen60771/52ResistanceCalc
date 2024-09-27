namespace _52ResistanceCalc
{
    partial class Form_ClacResult
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
            this.label_Result = new System.Windows.Forms.Label();
            this.btn_ClacResult_OK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_Result
            // 
            this.label_Result.BackColor = System.Drawing.Color.Transparent;
            this.label_Result.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Result.ForeColor = System.Drawing.Color.Blue;
            this.label_Result.Location = new System.Drawing.Point(75, 9);
            this.label_Result.Name = "label_Result";
            this.label_Result.Size = new System.Drawing.Size(450, 300);
            this.label_Result.TabIndex = 0;
            this.label_Result.Text = "label1";
            this.label_Result.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_ClacResult_OK
            // 
            this.btn_ClacResult_OK.Font = new System.Drawing.Font("宋体", 18F);
            this.btn_ClacResult_OK.Location = new System.Drawing.Point(219, 335);
            this.btn_ClacResult_OK.Name = "btn_ClacResult_OK";
            this.btn_ClacResult_OK.Size = new System.Drawing.Size(163, 50);
            this.btn_ClacResult_OK.TabIndex = 1;
            this.btn_ClacResult_OK.Text = "知道了";
            this.btn_ClacResult_OK.UseVisualStyleBackColor = true;
            this.btn_ClacResult_OK.Click += new System.EventHandler(this.Btn_ClacResult_OK_Chick);
            // 
            // Form_ClacResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(582, 403);
            this.ControlBox = false;
            this.Controls.Add(this.btn_ClacResult_OK);
            this.Controls.Add(this.label_Result);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_ClacResult";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "计算完成";
            this.Load += new System.EventHandler(this.Form_ClacResult_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label_Result;
        private System.Windows.Forms.Button btn_ClacResult_OK;
    }
}