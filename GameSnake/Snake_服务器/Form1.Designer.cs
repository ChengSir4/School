
namespace Snake_服务器
{
    partial class Form1
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.txtchat = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbName = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbSoket = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtchat
            // 
            this.txtchat.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtchat.Location = new System.Drawing.Point(0, 47);
            this.txtchat.Multiline = true;
            this.txtchat.Name = "txtchat";
            this.txtchat.ReadOnly = true;
            this.txtchat.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtchat.Size = new System.Drawing.Size(925, 521);
            this.txtchat.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(278, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 15);
            this.label3.TabIndex = 13;
            this.label3.Text = "用户昵称:";
            // 
            // cmbName
            // 
            this.cmbName.FormattingEnabled = true;
            this.cmbName.Location = new System.Drawing.Point(359, 9);
            this.cmbName.Name = "cmbName";
            this.cmbName.Size = new System.Drawing.Size(121, 23);
            this.cmbName.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(529, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 15);
            this.label2.TabIndex = 10;
            this.label2.Text = "用户ip及端口:";
            // 
            // cmbSoket
            // 
            this.cmbSoket.FormattingEnabled = true;
            this.cmbSoket.Location = new System.Drawing.Point(641, 9);
            this.cmbSoket.Name = "cmbSoket";
            this.cmbSoket.Size = new System.Drawing.Size(272, 23);
            this.cmbSoket.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "本地ip:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(73, 9);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(157, 25);
            this.textBox1.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 568);
            this.Controls.Add(this.txtchat);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbSoket);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtchat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbSoket;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
    }
}

