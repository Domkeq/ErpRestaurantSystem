using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpRestaurantSystem
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string Role { get; set; }
        public int PinCode { get; set; }

        public Employee() { }

        public Employee(int id, string name, string surname, string patronymic, string role, int pinCode)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            Role = role;
            PinCode = pinCode;
        }
    }
}
