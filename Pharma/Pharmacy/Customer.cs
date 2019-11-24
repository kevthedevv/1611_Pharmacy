using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy
{
    class Customer
    {
        int customerID;
        string firstName;
        string lastName;
        string company;
        string contact;
        string customerAddress;
        string emailAddress;

        public Customer(int customerID, string firstName, string lastName, string company, string contact, string customerAddress, string emailAddress)
        {
            this.CustomerID = customerID;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Company = company;
            this.Contact = contact;
            this.CustomerAddress = customerAddress;
            this.EmailAddress = emailAddress;
        }

        public int CustomerID { get => customerID; set => customerID = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Company { get => company; set => company = value; }
        public string Contact { get => contact; set => contact = value; }
        public string CustomerAddress { get => customerAddress; set => customerAddress = value; }
        public string EmailAddress { get => emailAddress; set => emailAddress = value; }
    }
}
