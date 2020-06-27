namespace Metronome
{
    partial class HB_Metronome
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
            this.txt_BPM = new System.Windows.Forms.TextBox();
            this.btn_start = new System.Windows.Forms.Button();
            this.btn_end = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_BPM
            // 
            this.txt_BPM.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txt_BPM.Location = new System.Drawing.Point(76, 60);
            this.txt_BPM.Name = "txt_BPM";
            this.txt_BPM.Size = new System.Drawing.Size(144, 21);
            this.txt_BPM.TabIndex = 0;
            this.txt_BPM.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_BPM_KeyPress);
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(226, 58);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(75, 23);
            this.btn_start.TabIndex = 1;
            this.btn_start.Text = "start";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_end
            // 
            this.btn_end.Location = new System.Drawing.Point(226, 58);
            this.btn_end.Name = "btn_end";
            this.btn_end.Size = new System.Drawing.Size(75, 23);
            this.btn_end.TabIndex = 2;
            this.btn_end.Text = "end";
            this.btn_end.UseVisualStyleBackColor = true;
            this.btn_end.Visible = false;
            this.btn_end.Click += new System.EventHandler(this.btn_end_Click);
            // 
            // HB_Metronome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 143);
            this.Controls.Add(this.btn_end);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.txt_BPM);
            this.Name = "HB_Metronome";
            this.Text = "HB_Metronome";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_BPM;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Button btn_end;
    }
}

