using Staff.Data.Models;
using Staff.Data.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Staff
{
    public partial class Main : Form
    {
        private List<Employee> _staff;
        public Main()
        {
            InitializeComponent();
            _staff = SqlHelper.GetStuff();
            BSStaff.DataSource = _staff;
            dataGridView1.AutoGenerateColumns = true;
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            refreshRecords();
        }

        private void add_Click(object sender, EventArgs e)
        {
            AddEmployee addEmployee = new AddEmployee(this);
            addEmployee.ShowDialog();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            SqlHelper.DeleteEmployee((Employee)BSStaff.Current);
            BSStaff.RemoveCurrent();
        }

        private void report_Click(object sender, EventArgs e)
        {
            
        }
        internal void refreshRecords()
        {
            List<Employee> staff = SqlHelper.GetStuff();
            if (staff != null && staff.Count >= 0)
            {
                _staff.Clear();
                _staff.AddRange(staff);
                BSStaff.ResetBindings(false);
            }
        }
    }
}
