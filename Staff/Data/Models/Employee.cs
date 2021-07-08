using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staff.Data.Models
{
    class Employee
    {
        [DisplayName("Id")]
        [Browsable(false)]
        public int Id { get; set; }
        [DisplayName("Имя")]
        public string FirstName { get; set; }
        [DisplayName("Отчество")]
        public string MidleName { get; set; }
        [DisplayName("Фамилия")]
        public string LastName { get; set; }
        [DisplayName("Должность")]
        public string Position { get; set; }
        [DisplayName("Дата рождения")]
        public DateTime DateOfBirth { get; set; }
        [DisplayName("Зарплата")]
        public decimal Salary { get; set; }
    }
}
