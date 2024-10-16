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

                if (Check.GetItemChecked(0) == false && Check.GetItemChecked(1) == false){
                    return;
                }

                if (Check.GetItemChecked(1)){
                    worker.SetShiftType(1);
                }
                else { 
                    worker.SetShiftType(0);
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
            Check.SetItemChecked(0, false);
            Check.SetItemChecked(1, false);

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

        int shiftVal = -1;

        private void Check_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Check.GetSelected(0) && shiftVal != 0) {
                shiftVal = 0;
                Check.SetItemChecked(1,false);
            }
            if (Check.GetSelected(1) && shiftVal != 1)
            {
                shiftVal = 1;
                Check.SetItemChecked(0, false);
            }
        }
    }
}
