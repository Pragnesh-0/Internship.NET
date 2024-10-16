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
using System.Drawing.Text;

namespace Task2
{
    public partial class Form1 : Form
    {

        List<ProductionWorker> workerList = new List<ProductionWorker>();

        public Form1()
        {
            InitializeComponent();
        }

        private void displayWorker() {
            dataGridView1.Rows.Clear();
            foreach (ProductionWorker worker in workerList) {
                dataGridView1.Rows.Add(worker.GetName(), worker.GetNumber(), worker.GetShiftNumber(), worker.GetHourlyPayRate());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProductionWorker worker = new ProductionWorker();

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

                workerList.Add(worker);
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

            displayWorker();
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
