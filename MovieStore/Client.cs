using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStore
{
    class Client
    {
        private String name;
        private String surname;
        private DateTime registrationDate;
        private int totalNoOfOrders; // number of orders since registration date
        private DateTime dateOfBirth;

        public Client(String name, String surname, DateTime registrationDate, int totalNoOfOrders, DateTime dateOfBirth)
        {
            this.name = name;
            this.surname = surname;
            this.registrationDate = registrationDate;
            this.totalNoOfOrders = totalNoOfOrders;
            this.dateOfBirth = dateOfBirth;
        }

        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public DateTime RegistrationDate { get => registrationDate; set => registrationDate = value; }
        public int TotalNoOfOrders { get => totalNoOfOrders; set => totalNoOfOrders = value; }
        public DateTime DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }

        public int CalculateAge()
        {
            int age = DateTime.Today.Year - this.DateOfBirth.Year;

            if (DateTime.Today.Month < this.DateOfBirth.Month || (DateTime.Today.Month == this.DateOfBirth.Month && DateTime.Today.Day < this.DateOfBirth.Day))
                age--;

            return age;
        }
    }
}
