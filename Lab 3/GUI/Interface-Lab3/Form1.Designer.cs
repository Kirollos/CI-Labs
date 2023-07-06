
namespace Interface_Lab3
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
            comboBox1 = new ComboBox();
            label1 = new Label();
            button8 = new Button();
            button9 = new Button();
            button10 = new Button();
            label2 = new Label();
            comboBox2 = new ComboBox();
            label3 = new Label();
            textBox1 = new TextBox();
            label4 = new Label();
            button1 = new Button();
            textBox2 = new TextBox();
            label5 = new Label();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(76, 12);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(7, 15);
            label1.Name = "label1";
            label1.Size = new Size(63, 15);
            label1.TabIndex = 10;
            label1.Text = "COM Port:";
            // 
            // button8
            // 
            button8.Location = new Point(203, 11);
            button8.Name = "button8";
            button8.Size = new Size(54, 23);
            button8.TabIndex = 11;
            button8.Text = "Refresh";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // button9
            // 
            button9.Location = new Point(76, 41);
            button9.Name = "button9";
            button9.Size = new Size(60, 23);
            button9.TabIndex = 12;
            button9.Text = "Connect";
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click;
            // 
            // button10
            // 
            button10.Location = new Point(142, 41);
            button10.Name = "button10";
            button10.Size = new Size(74, 23);
            button10.TabIndex = 13;
            button10.Text = "Disconnect";
            button10.UseVisualStyleBackColor = true;
            button10.Click += button10_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(98, 72);
            label2.Name = "label2";
            label2.Size = new Size(79, 15);
            label2.TabIndex = 14;
            label2.Text = "Disconnected";
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "Read", "Write" });
            comboBox2.Location = new Point(109, 159);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(121, 23);
            comboBox2.TabIndex = 15;
            comboBox2.Text = "Write";
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(9, 162);
            label3.Name = "label3";
            label3.Size = new Size(94, 15);
            label3.TabIndex = 16;
            label3.Text = "Select Operaton:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(109, 112);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(121, 23);
            textBox1.TabIndex = 17;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 115);
            label4.Name = "label4";
            label4.Size = new Size(52, 15);
            label4.TabIndex = 18;
            label4.Text = "Address:";
            // 
            // button1
            // 
            button1.Location = new Point(184, 210);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 19;
            button1.Text = "Write";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(65, 210);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 20;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(11, 214);
            label5.Name = "label5";
            label5.Size = new Size(34, 15);
            label5.TabIndex = 21;
            label5.Text = "Data:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(276, 338);
            Controls.Add(label5);
            Controls.Add(textBox2);
            Controls.Add(button1);
            Controls.Add(label4);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(comboBox2);
            Controls.Add(label2);
            Controls.Add(button10);
            Controls.Add(button9);
            Controls.Add(button8);
            Controls.Add(label1);
            Controls.Add(comboBox1);
            Name = "Form1";
            Text = "Form1";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Label label2;
        private ComboBox comboBox2;
        private Label label3;
        private TextBox textBox1;
        private Label label4;
        private Button button1;
        private TextBox textBox2;
        private Label label5;
    }
}

