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

            if (nameTextBox.Text == null) {
                Console.WriteLine("ASD");
                return;
            }

            

            worker.SetName(nameTextBox.Text);
            try{
                worker.SetNumber(int.Parse(numberTextBox.Text));
                if (int.Parse(shiftTypeBox.Text) > 2) {
                    Error.Text = "Incorrect Shift Type!: 1. Day Shift 2. Night Shift";
                    return;
                }
                worker.SetShiftType(int.Parse(shiftTypeBox.Text));
                worker.SetPayRate(double.Parse(hourlyPayrateBox.Text));
            }catch {
                Error.Text = "An Error occurred. Please try again.";
                return;
            }
            

            nameTextBox.Clear();
            numberTextBox.Clear();
            shiftTypeBox.Clear();
            hourlyPayrateBox.Clear();

            Error.Text = "";

            NameDisplay.Text = worker.GetName();
            NumberDisplay.Text = worker.GetNumber().ToString();
            ShiftTypeDisplay.Text = worker.GetShiftNumber();
            HPRDisplay.Text = worker.GetHourlyPayRate().ToString();
        }
    }
}
