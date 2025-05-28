namespace ZX_s_PC_Checker
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            label1 = new Label();
            label2 = new Label();
            checkBox1 = new CheckBox();
            label3 = new Label();
            label4 = new Label();
            button1 = new Button();
            button2 = new Button();
            textBox1 = new TextBox();
            button3 = new Button();
            label5 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(308, 9);
            label1.Name = "label1";
            label1.Size = new Size(232, 38);
            label1.TabIndex = 0;
            label1.Text = "ZX's PC CHECKER";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(308, 47);
            label2.Name = "label2";
            label2.Size = new Size(236, 28);
            label2.TabIndex = 1;
            label2.Text = "Made by xi3_x on Discord";
            label2.Click += label2_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Checked = true;
            checkBox1.CheckState = CheckState.Checked;
            checkBox1.Location = new Point(12, 424);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(836, 24);
            checkBox1.TabIndex = 3;
            checkBox1.Text = "I allow access to 3rd party applications on my pc and I allow a PC Checker to access, edit, modify, and view files on my PC.";
            checkBox1.TextAlign = ContentAlignment.MiddleCenter;
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(535, 23);
            label3.Name = "label3";
            label3.Size = new Size(26, 20);
            label3.TabIndex = 4;
            label3.Text = "V1";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(821, 9);
            label4.Name = "label4";
            label4.Size = new Size(24, 28);
            label4.TabIndex = 5;
            label4.Text = "X";
            label4.Click += label4_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.Black;
            button1.ForeColor = Color.Transparent;
            button1.Location = new Point(282, 294);
            button1.Name = "button1";
            button1.Size = new Size(151, 48);
            button1.TabIndex = 6;
            button1.Text = "Manual PC Check";
            button1.UseVisualStyleBackColor = false;
            button1.Visible = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.Black;
            button2.ForeColor = Color.Transparent;
            button2.Location = new Point(439, 294);
            button2.Name = "button2";
            button2.Size = new Size(151, 48);
            button2.TabIndex = 7;
            button2.Text = "Automatic PC Check";
            button2.UseVisualStyleBackColor = false;
            button2.Visible = false;
            button2.Click += button2_Click;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.Black;
            textBox1.ForeColor = SystemColors.Info;
            textBox1.Location = new Point(363, 153);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(135, 27);
            textBox1.TabIndex = 8;
            // 
            // button3
            // 
            button3.BackColor = Color.Black;
            button3.ForeColor = Color.Transparent;
            button3.Location = new Point(363, 186);
            button3.Name = "button3";
            button3.Size = new Size(135, 35);
            button3.TabIndex = 9;
            button3.Text = "Verify";
            button3.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label5.Location = new Point(363, 122);
            label5.Name = "label5";
            label5.Size = new Size(126, 28);
            label5.TabIndex = 10;
            label5.Text = "Access code:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(851, 460);
            Controls.Add(label5);
            Controls.Add(button3);
            Controls.Add(textBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(checkBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            ForeColor = SystemColors.ButtonHighlight;
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "ZX's PC CHECKER";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private CheckBox checkBox1;
        private Label label3;
        private Label label4;
        private Button button1;
        private Button button2;
        private TextBox textBox1;
        private Button button3;
        private Label label5;
    }
}
