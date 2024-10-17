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

        private int editID = 0;

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

                if (radioButton1.Checked){
                    worker.SetShiftType(2);
                }
                else {
                    worker.SetShiftType(1);
                }
                


                worker.SetNumber(int.Parse(numberTextBox.Text));
                worker.SetPayRate(double.Parse(hourlyPayrateBox.Text));

                int shiftNumber = 1;

                if (worker.GetShiftNumber() == "Night Shift"){
                    shiftNumber = 2;
                }

                if (!addToDB(worker.GetNumber(), worker.GetName(), shiftNumber, worker.GetHourlyPayRate())){
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
            workerList.Clear();
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
            catch {
            } finally {
                myConnection.Close();
            }
            
        }

        private bool addToDB(int num, string name, int shiftNum, double hourlyPayRate) {

            try {
                myConnection.Open();
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.CommandType = CommandType.Text;
                sqlcmd.CommandText = "INSERT INTO Employee VALUES (@num,@name,@shiftNum,@hourlyPayrate)";
                sqlcmd.Parameters.Add(new SqlParameter("@num", num));
                sqlcmd.Parameters.Add(new SqlParameter("@name", name));
                sqlcmd.Parameters.Add(new SqlParameter("@shiftNum", shiftNum));
                sqlcmd.Parameters.Add(new SqlParameter("@hourlyPayrate", hourlyPayRate));
                sqlcmd.Connection = myConnection;
                sqlcmd.ExecuteNonQuery();
            } catch {
                Error.Text = "An error occurred when entering data in database.";
                myConnection.Close();
                return false;
            } finally {
                myConnection.Close();
            }
            return true;
        }

        private bool editDB(int num, string name, int shiftNum, double hourlyPayRate) {

            try {
                myConnection.Open();
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.CommandText = "UPDATE Employee SET EmployeeName = @name, EmployeeShiftType = @shiftType, EmployeeHrp = @empHrp WHERE EmployeeNumber = @num";
                sqlcmd.Parameters.Add(new SqlParameter("@name", name));
                sqlcmd.Parameters.Add(new SqlParameter("@shiftType", shiftNum));
                sqlcmd.Parameters.Add(new SqlParameter("@empHrp", hourlyPayRate));
                sqlcmd.Parameters.Add(new SqlParameter("@num", num));
                sqlcmd.Connection = myConnection;
                sqlcmd.ExecuteNonQuery();
            } catch {
                myConnection.Close();
                return false;
            }
            finally {
                myConnection.Close(); 
            }

            return true;
        }


        private void hourlyPayrateBox_TextChanged(object sender, EventArgs e)
        {
            bool catchVal = false;
            try { 
                double.Parse(hourlyPayrateBox.Text);
            } catch { 
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

        private void button_Clicked(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4) {
                try {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                    var id = row.Cells[1].Value;
                    myConnection.Open();
                    SqlCommand newCmd = new SqlCommand();
                    newCmd.CommandText = "DELETE FROM Employee WHERE EmployeeNumber = @ID";
                    newCmd.Connection = myConnection;
                    SqlParameter pram = new SqlParameter("@ID", id);
                    newCmd.Parameters.Add(pram);
                    newCmd.ExecuteNonQuery();
                } catch {
                    Error.Text = "An Error Occurred.";
                } finally {
                    myConnection.Close();
                }
                dumpDB();
                displayWorker();
            }else if(e.ColumnIndex == 5){
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                idVal.Enabled = true;
                idVal.Text = row.Cells[1].Value.ToString();
                idVal.Visible = true;
                

                label7.Enabled = true;
                nameEdit.Text = row.Cells[0].Value.ToString();
                label7.Visible = true;
                nameEdit.Enabled = true;
                nameEdit.Visible = true;
                

                label8.Enabled = true;
                label8.Visible = true;
                hrpEdit.Text = row.Cells[3].Value.ToString();
                hrpEdit.Enabled = true;
                hrpEdit.Visible = true;
                

                label5.Enabled = true;
                label5.Visible = true;
                radioButton4.Visible = true;
                radioButton4.Enabled = true;
                radioButton3.Visible = true;
                radioButton3.Enabled = true;
                if (row.Cells[2].Value.ToString() == "Night Shift"){
                    radioButton4.Checked = true;
                }
                else {
                    radioButton3.Checked = true;
                }

                button2.Enabled = true;
                button2.Visible = true;

            }
        }

        private void textBox3_TextChanged_1(object sender, EventArgs e){
            bool catchVal = false;
            try
            {
                double.Parse(hrpEdit.Text);
            }
            catch
            {
                catchVal = true;
            }
            if (catchVal)
            {
                hrpEdit.Clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ProductionWorker worker = new ProductionWorker();

            if ((nameEdit.Text == "") || (nameEdit.Text.Substring(0, nameEdit.Text.Length) == " "))
            {
                Error.Text = "Add a name.";
                return;
            }

            worker.SetName(nameEdit.Text);
            try
            {

                if (!(radioButton3.Checked || radioButton4.Checked))
                {
                    return;
                }

                if (radioButton4.Checked)
                {
                    worker.SetShiftType(2);
                }
                else
                {
                    worker.SetShiftType(1);
                }

                var num = int.Parse(idVal.Text);

                worker.SetPayRate(double.Parse(hrpEdit.Text));

                int shiftNumber = 1;

                if (worker.GetShiftNumber() == "Night Shift")
                {
                    shiftNumber = 2;
                }

                if (!editDB(num, worker.GetName(), shiftNumber, worker.GetHourlyPayRate()))
                {
                    return;
                }
            }
            catch
            {
                Error.Text = "An Error occurred. Please try again.";
                return;
            }


            idVal.Enabled = false;
            idVal.Text = "";
            idVal.Visible = false;


            label7.Enabled = false;
            nameEdit.Text = "";
            label7.Visible = false;
            nameEdit.Enabled = false;
            nameEdit.Visible = false;


            label8.Enabled = false;
            label8.Visible = false;
            hrpEdit.Text = "";
            hrpEdit.Enabled = false;
            hrpEdit.Visible = false;


            label5.Enabled = false;
            label5.Visible = false;
            radioButton4.Visible = false;
            radioButton4.Enabled = false;
            radioButton3.Visible = false;
            radioButton3.Enabled = false;
            radioButton4.Checked = false;
            radioButton4.Checked = false;

            button2.Enabled = false;
            button2.Visible = false;


            dumpDB();
        }
    }
}