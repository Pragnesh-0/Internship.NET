using System.Windows.Forms;

namespace Task2
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.numberTextBox = new System.Windows.Forms.TextBox();
            this.hourlyPayrateBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Error = new System.Windows.Forms.Label();
            this.NameDisplay = new System.Windows.Forms.Label();
            this.NumberDisplay = new System.Windows.Forms.Label();
            this.ShiftTypeDisplay = new System.Windows.Forms.Label();
            this.HPRDisplay = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(41, 300);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Create";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(41, 63);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(158, 20);
            this.nameTextBox.TabIndex = 1;
            // 
            // numberTextBox
            // 
            this.numberTextBox.Location = new System.Drawing.Point(41, 115);
            this.numberTextBox.Name = "numberTextBox";
            this.numberTextBox.Size = new System.Drawing.Size(158, 20);
            this.numberTextBox.TabIndex = 2;
            // 
            // hourlyPayrateBox
            // 
            this.hourlyPayrateBox.Location = new System.Drawing.Point(41, 224);
            this.hourlyPayrateBox.Name = "hourlyPayrateBox";
            this.hourlyPayrateBox.Size = new System.Drawing.Size(158, 20);
            this.hourlyPayrateBox.TabIndex = 4;
            this.hourlyPayrateBox.TextChanged += new System.EventHandler(this.hourlyPayrateBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "EmployeeNumber";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Shift Type";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 208);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Hourly Pay Rate";
            // 
            // Error
            // 
            this.Error.AutoSize = true;
            this.Error.BackColor = System.Drawing.SystemColors.HotTrack;
            this.Error.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Error.Location = new System.Drawing.Point(38, 273);
            this.Error.Name = "Error";
            this.Error.Size = new System.Drawing.Size(0, 13);
            this.Error.TabIndex = 9;
            // 
            // NameDisplay
            // 
            this.NameDisplay.AutoSize = true;
            this.NameDisplay.Location = new System.Drawing.Point(493, 47);
            this.NameDisplay.Name = "NameDisplay";
            this.NameDisplay.Size = new System.Drawing.Size(0, 13);
            this.NameDisplay.TabIndex = 10;
            // 
            // NumberDisplay
            // 
            this.NumberDisplay.AutoSize = true;
            this.NumberDisplay.Location = new System.Drawing.Point(493, 99);
            this.NumberDisplay.Name = "NumberDisplay";
            this.NumberDisplay.Size = new System.Drawing.Size(0, 13);
            this.NumberDisplay.TabIndex = 11;
            // 
            // ShiftTypeDisplay
            // 
            this.ShiftTypeDisplay.AutoSize = true;
            this.ShiftTypeDisplay.Location = new System.Drawing.Point(493, 150);
            this.ShiftTypeDisplay.Name = "ShiftTypeDisplay";
            this.ShiftTypeDisplay.Size = new System.Drawing.Size(0, 13);
            this.ShiftTypeDisplay.TabIndex = 12;
            // 
            // HPRDisplay
            // 
            this.HPRDisplay.AutoSize = true;
            this.HPRDisplay.Location = new System.Drawing.Point(493, 208);
            this.HPRDisplay.Name = "HPRDisplay";
            this.HPRDisplay.Size = new System.Drawing.Size(0, 13);
            this.HPRDisplay.TabIndex = 13;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(36, 166);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(45, 17);
            this.checkBox1.TabIndex = 14;
            this.checkBox1.Text = "Day";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.Click += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(97, 166);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(51, 17);
            this.checkBox2.TabIndex = 15;
            this.checkBox2.Text = "Night";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.Click += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 450);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.HPRDisplay);
            this.Controls.Add(this.ShiftTypeDisplay);
            this.Controls.Add(this.NumberDisplay);
            this.Controls.Add(this.NameDisplay);
            this.Controls.Add(this.Error);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.hourlyPayrateBox);
            this.Controls.Add(this.numberTextBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button button1;
        private TextBox nameTextBox;
        private TextBox numberTextBox;
        private TextBox hourlyPayrateBox;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label Error;
        private Label NameDisplay;
        private Label NumberDisplay;
        private Label ShiftTypeDisplay;
        private Label HPRDisplay;
        private CheckBox checkBox1;
        private CheckBox checkBox2;

        
    }
}

