using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Task2
{
    public partial class Form1 : Form
    {

        ProductionWorker worker = new ProductionWorker();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if ((nameTextBox.Text == "") || (nameTextBox.Text.Substring(0, nameTextBox.Text.Length) == " ")) {
                Error.Text = "Add a name.";
                return;
            }

            

            worker.SetName(nameTextBox.Text);
            try{

                if (!(radioButton1.Checked || radioButton2.Checked)) {
                    Error.Text = "Select a Shift!";
                    return;
                }

                if (radioButton1.Checked)
                {
                    worker.SetShiftType(2);
                }
                else {
                    worker.SetShiftType(1);
                }



                worker.SetNumber(int.Parse(numberTextBox.Text));
                worker.SetPayRate(double.Parse(hourlyPayrateBox.Text));
            }catch {
                Error.Text = "An Error occurred. Please try again.";
                return;
            }
            

            nameTextBox.Clear();
            numberTextBox.Clear();
            hourlyPayrateBox.Clear();
            radioButton2.Checked = false;
            radioButton1.Checked = false;

            Error.Text = "";

            NameDisplay.Text = worker.GetName();
            NumberDisplay.Text = worker.GetNumber().ToString();
            ShiftTypeDisplay.Text = worker.GetShiftNumber();
            HPRDisplay.Text = worker.GetHourlyPayRate().ToString();
        }

        private void hourlyPayrateBox_TextChanged(object sender, EventArgs e)
        {
            bool catchVal = false;
            try{ 
                double.Parse(hourlyPayrateBox.Text);
            }catch { 
                catchVal = true;
            }
            if (catchVal) {
                hourlyPayrateBox.Clear();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            radioButton2.Checked = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
        }
    }
}
