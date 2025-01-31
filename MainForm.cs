using System;
using System.Data;
using System.Windows.Forms;

namespace EmployeeManagementSystem
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            DatabaseHelper.InitializeDatabase();
            LoadEmployees();
        }

        private void LoadEmployees()
        {
            DataTable dt = DatabaseHelper.GetEmployees();
            dataGridViewEmployees.DataSource = dt;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DatabaseHelper.AddEmployee(txtName.Text, int.Parse(txtAge.Text), txtEmail.Text, txtDepartment.Text, double.Parse(txtSalary.Text));
            LoadEmployees();
            MessageBox.Show("Employee added successfully!");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewEmployees.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridViewEmployees.SelectedRows[0].Cells[0].Value);
                DatabaseHelper.DeleteEmployee(id);
                LoadEmployees();
                MessageBox.Show("Employee deleted successfully!");
            }
        }
    }
}
