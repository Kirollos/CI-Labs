
namespace Interface_Lab2
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
            button1 = new System.Windows.Forms.Button();
            button2 = new System.Windows.Forms.Button();
            button3 = new System.Windows.Forms.Button();
            button4 = new System.Windows.Forms.Button();
            button5 = new System.Windows.Forms.Button();
            button6 = new System.Windows.Forms.Button();
            button7 = new System.Windows.Forms.Button();
            groupBox1 = new System.Windows.Forms.GroupBox();
            groupBox2 = new System.Windows.Forms.GroupBox();
            comboBox1 = new System.Windows.Forms.ComboBox();
            label1 = new System.Windows.Forms.Label();
            button8 = new System.Windows.Forms.Button();
            button9 = new System.Windows.Forms.Button();
            button10 = new System.Windows.Forms.Button();
            label2 = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(19, 128);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(70, 25);
            button1.TabIndex = 0;
            button1.Text = "Increase";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new System.Drawing.Point(19, 166);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(70, 25);
            button2.TabIndex = 1;
            button2.Text = "Decrease";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new System.Drawing.Point(183, 128);
            button3.Name = "button3";
            button3.Size = new System.Drawing.Size(70, 25);
            button3.TabIndex = 2;
            button3.Text = "Forward";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new System.Drawing.Point(183, 165);
            button4.Name = "button4";
            button4.Size = new System.Drawing.Size(70, 25);
            button4.TabIndex = 3;
            button4.Text = "Reverse";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new System.Drawing.Point(183, 215);
            button5.Name = "button5";
            button5.Size = new System.Drawing.Size(70, 25);
            button5.TabIndex = 4;
            button5.Text = "Stop";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Location = new System.Drawing.Point(19, 301);
            button6.Name = "button6";
            button6.Size = new System.Drawing.Size(70, 25);
            button6.TabIndex = 5;
            button6.Text = "LED ON";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.Location = new System.Drawing.Point(183, 301);
            button7.Name = "button7";
            button7.Size = new System.Drawing.Size(70, 25);
            button7.TabIndex = 6;
            button7.Text = "LED OFF";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // groupBox1
            // 
            groupBox1.Location = new System.Drawing.Point(12, 90);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(245, 164);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "Motor Control";
            // 
            // groupBox2
            // 
            groupBox2.Location = new System.Drawing.Point(19, 271);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new System.Drawing.Size(245, 64);
            groupBox2.TabIndex = 8;
            groupBox2.TabStop = false;
            groupBox2.Text = "LED Control";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new System.Drawing.Point(76, 12);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new System.Drawing.Size(121, 23);
            comboBox1.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(7, 15);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(63, 15);
            label1.TabIndex = 10;
            label1.Text = "COM Port:";
            // 
            // button8
            // 
            button8.Location = new System.Drawing.Point(203, 11);
            button8.Name = "button8";
            button8.Size = new System.Drawing.Size(54, 23);
            button8.TabIndex = 11;
            button8.Text = "Refresh";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // button9
            // 
            button9.Location = new System.Drawing.Point(76, 41);
            button9.Name = "button9";
            button9.Size = new System.Drawing.Size(60, 23);
            button9.TabIndex = 12;
            button9.Text = "Connect";
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click;
            // 
            // button10
            // 
            button10.Location = new System.Drawing.Point(142, 41);
            button10.Name = "button10";
            button10.Size = new System.Drawing.Size(74, 23);
            button10.TabIndex = 13;
            button10.Text = "Disconnect";
            button10.UseVisualStyleBackColor = true;
            button10.Click += button10_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(98, 72);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(79, 15);
            label2.TabIndex = 14;
            label2.Text = "Disconnected";
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(276, 338);
            Controls.Add(label2);
            Controls.Add(button10);
            Controls.Add(button9);
            Controls.Add(button8);
            Controls.Add(label1);
            Controls.Add(comboBox1);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(groupBox1);
            Controls.Add(groupBox2);
            Name = "Form1";
            Text = "Form1";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Label label2;
    }
}

