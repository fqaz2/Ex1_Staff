using Microsoft.Reporting.WinForms;
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
            ReportDataSource rs = new ReportDataSource();
            List<Employee> staff = new List<Employee>();
            staff.AddRange(_staff);
            rs.Name = "DataSet1";
            rs.Value = staff;
            Report report = new Report();
            report.reportViewer1.LocalReport.DataSources.Clear();
            report.reportViewer1.LocalReport.DataSources.Add(rs);
            report.reportViewer1.LocalReport.ReportEmbeddedResource = "Staff.Report.rdlc";

            report.ShowDialog();
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

        private void sortByPosition_Click(object sender, EventArgs e)
        {
            BSStaff.DataSource = _staff.OrderBy(a => a.Position);
        }
    }
}
