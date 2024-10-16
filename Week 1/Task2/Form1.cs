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
using System.Data.SqlClient;
using System.Runtime.Remoting.Contexts;
using System.Data.SqlTypes;
using System.Xml.Linq;

namespace Task2
{
    public partial class Form1 : Form
    {

        List<ProductionWorker> workerList = new List<ProductionWorker>();

        private SqlConnection myConnection = new SqlConnection();

        public Form1()
        {
            InitializeComponent();
            myConnection.ConnectionString = "Data Source = DESKTOP-S18FFQK\\SQLEXPRESS; Integrated Security = True; Connect Timeout = 10; Encrypt = False; Initial Catalog = Task2";
            dumpDB();
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            ProductionWorker worker = new ProductionWorker();

            if ((nameTextBox.Text == "") || (nameTextBox.Text.Substring(0, nameTextBox.Text.Length) == " ")) {
                Error.Text = "Add a name.";
                return;
            }

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.Text;

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

                int shiftNumber = 1;

                if (worker.GetShiftNumber() == "Night Shift")
                {
                    shiftNumber = 2;
                }

                if (!addToDB(worker.GetNumber(), worker.GetName(), shiftNumber, worker.GetHourlyPayRate()))
                {
                    return;
                }

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

        private void displayWorker() {
            dataGridView1.Rows.Clear();
            foreach (ProductionWorker worker in workerList) {
                dataGridView1.Rows.Add(worker.GetName(), worker.GetNumber(), worker.GetShiftNumber(), worker.GetHourlyPayRate());
            }
        }

        private void dumpDB() {
            try
            {
                myConnection.Open();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Employee", myConnection);
                DataTable dataTable = new DataTable();

                sda.Fill(dataTable);

                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    int empNum = (int)dataTable.Rows[i]["EmployeeNumber"];
                    string empName = (string)dataTable.Rows[i]["EmployeeName"];
                    int empShiftType = (int)dataTable.Rows[i]["EmployeeShiftType"];
                    double empHRP = double.Parse(dataTable.Rows[i]["EmployeeHrp"].ToString());

                    ProductionWorker worker = new ProductionWorker();

                    worker.SetName(empName);
                    worker.SetNumber(empNum);
                    worker.SetShiftType(empShiftType);
                    worker.SetPayRate(empHRP);

                    workerList.Add(worker);
                }

                displayWorker();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }finally {
                myConnection.Close();
            }
            
        }

        private bool addToDB(int num, string name, int shiftNum, double hourlyPayRate) {
            
            try { myConnection.Open(); } catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.CommandText = "INSERT INTO Employee VALUES (" + num + ",'" + name + "', " + shiftNum + "," + hourlyPayRate + ")";
            sqlcmd.Connection = myConnection;
            try {
                sqlcmd.ExecuteNonQuery();
            } catch (Exception ex) {
                Error.Text = "An error occurred when entering data in database.";
                myConnection.Close();
                return false;
            }
                
            myConnection.Close();
            return true;
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
