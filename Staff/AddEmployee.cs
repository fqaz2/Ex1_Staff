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
    public partial class AddEmployee : Form
    {
        private Main _main;
        public AddEmployee(Main main)
        {
            InitializeComponent();
            _main = main;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee()
            {
                FirstName = firstName.Text,
                MidleName = midleName.Text,
                LastName = lastName.Text,
                Position = position.Text,
                DateOfBirth = Convert.ToDateTime(dateOfBirth.Text),
                Salary = Convert.ToDecimal(salary.Text)
            };
            SqlHelper.AddEmployee(employee);
            _main.refreshRecords();
            this.Close();

        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
