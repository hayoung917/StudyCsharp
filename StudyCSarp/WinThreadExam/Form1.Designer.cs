namespace WinThreadExam
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.prgSample = new System.Windows.Forms.ProgressBar();
            this.BtnStart1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // prgSample
            // 
            this.prgSample.Location = new System.Drawing.Point(12, 12);
            this.prgSample.Name = "prgSample";
            this.prgSample.Size = new System.Drawing.Size(776, 87);
            this.prgSample.TabIndex = 0;
            // 
            // BtnStart1
            // 
            this.BtnStart1.Location = new System.Drawing.Point(614, 116);
            this.BtnStart1.Name = "BtnStart1";
            this.BtnStart1.Size = new System.Drawing.Size(174, 62);
            this.BtnStart1.TabIndex = 1;
            this.BtnStart1.Text = "Start";
            this.BtnStart1.UseVisualStyleBackColor = true;
            this.BtnStart1.Click += new System.EventHandler(this.BtnStart1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 204);
            this.Controls.Add(this.BtnStart1);
            this.Controls.Add(this.prgSample);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar prgSample;
        private System.Windows.Forms.Button BtnStart1;
    }
}

