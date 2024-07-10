namespace AuditionCopilot
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.picBall2 = new System.Windows.Forms.PictureBox();
            this.picKey2 = new System.Windows.Forms.PictureBox();
            this.picKey1 = new System.Windows.Forms.PictureBox();
            this.linePanel = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.picBall1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picBall2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picKey2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picKey1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBall1)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(484, 219);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(72, 16);
            this.checkBox1.TabIndex = 14;
            this.checkBox1.Text = "自动按键";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(380, 212);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "加载驱动";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 211);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(362, 21);
            this.textBox1.TabIndex = 16;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(213, 189);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(71, 16);
            this.radioButton1.TabIndex = 19;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "自动空格";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Checked = true;
            this.radioButton2.Location = new System.Drawing.Point(329, 190);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(83, 16);
            this.radioButton2.TabIndex = 20;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "自动空格关";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // picBall2
            // 
            this.picBall2.Location = new System.Drawing.Point(213, 124);
            this.picBall2.Name = "picBall2";
            this.picBall2.Size = new System.Drawing.Size(170, 18);
            this.picBall2.TabIndex = 5;
            this.picBall2.TabStop = false;
            // 
            // picKey2
            // 
            this.picKey2.Location = new System.Drawing.Point(12, 68);
            this.picKey2.Name = "picKey2";
            this.picKey2.Size = new System.Drawing.Size(510, 50);
            this.picKey2.TabIndex = 2;
            this.picKey2.TabStop = false;
            // 
            // picKey1
            // 
            this.picKey1.Location = new System.Drawing.Point(12, 12);
            this.picKey1.Name = "picKey1";
            this.picKey1.Size = new System.Drawing.Size(510, 50);
            this.picKey1.TabIndex = 0;
            this.picKey1.TabStop = false;
            // 
            // linePanel
            // 
            this.linePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.linePanel.Location = new System.Drawing.Point(213, 153);
            this.linePanel.Name = "linePanel";
            this.linePanel.Size = new System.Drawing.Size(170, 23);
            this.linePanel.TabIndex = 24;
            this.linePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.linePanel_Paint);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(183, 152);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(24, 24);
            this.button3.TabIndex = 25;
            this.button3.Text = "←";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(406, 153);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(24, 24);
            this.button4.TabIndex = 26;
            this.button4.Text = "→";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(438, 162);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 17;
            this.label1.Text = "偏移：";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(491, 159);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(31, 21);
            this.textBox2.TabIndex = 18;
            this.textBox2.Text = "0.35";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(136, 159);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 27;
            this.label2.Text = "label2";
            // 
            // picBall1
            // 
            this.picBall1.Location = new System.Drawing.Point(12, 124);
            this.picBall1.Name = "picBall1";
            this.picBall1.Size = new System.Drawing.Size(170, 18);
            this.picBall1.TabIndex = 4;
            this.picBall1.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 243);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.linePanel);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.picBall2);
            this.Controls.Add(this.picBall1);
            this.Controls.Add(this.picKey2);
            this.Controls.Add(this.picKey1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBall2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picKey2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picKey1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBall1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox picKey1;
        private System.Windows.Forms.PictureBox picKey2;
        private System.Windows.Forms.PictureBox picBall2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Panel linePanel;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox picBall1;
    }
}

