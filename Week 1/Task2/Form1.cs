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
        public class Employee
        {
            private string EmployeeName;
            private int EmployeeNumber;


            public void SetName(string Name) {
                this.EmployeeName = Name;
            }

            public void SetNumber(int Number)
            {
                this.EmployeeNumber = Number;
            }

            public string GetName() {
                return EmployeeName;
            }

            public int GetNumber()
            {
                return EmployeeNumber;
            }

        }

        public class ProductionWorker : Employee
        {
            private int ShiftNumber;
            private double HourlyPayRate;
            public void SetShiftType(int ShiftType)
            {
                this.ShiftNumber = ShiftType;
            }

            public void SetPayRate(double PayRate)
            {
                this.HourlyPayRate = PayRate;
            }
            public string GetShiftNumber()
            {
                if (ShiftNumber == 1) {
                    return "Day Shift";
                }
                return "Night Shift";
            }

            public double GetHourlyPayRate()
            {
                return HourlyPayRate;
            }
        }

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


            NameDisplay.Text = worker.GetName();
            NumberDisplay.Text = worker.GetNumber().ToString();
            ShiftTypeDisplay.Text = worker.GetShiftNumber();
            HPRDisplay.Text = worker.GetHourlyPayRate().ToString();
        }
    }
}
