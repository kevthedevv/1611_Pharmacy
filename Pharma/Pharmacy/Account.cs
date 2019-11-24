using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy
{
    public class Account
    {
        int accountID;
        string userType;
        string username;
        string password;
        string firstName;
        string lastName;
        string address;
        string contact;
        string emailAddress;

        public Account() 
        {
            //Empty account
            userType = "";
            username = "";
            password = "";
            firstName = "";
            lastName = "";
            address = "";
            contact = "";
            emailAddress = "";
        }
        public int AccountID { get => accountID; set => accountID = value; }
        public string UserType { get => userType; set => userType = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Address { get => address; set => address = value; }
        public string Contact { get => contact; set => contact = value; }
        public string EmailAddress { get => emailAddress; set => emailAddress = value; }
    }
}
