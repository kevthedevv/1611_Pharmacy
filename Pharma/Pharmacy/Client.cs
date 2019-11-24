namespace Pharmacy
{
    class Client
    {
        int clientID;
        string firstName;
        string lastName;
        string company;
        string contact;
        string customerAddress;
        string emailAddress;

        public Client(int clientID, string firstName, string lastName, string company, string contact, string customerAddress, string emailAddress)
        {
            this.ClientID = clientID;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Company = company;
            this.Contact = contact;
            this.CustomerAddress = customerAddress;
            this.EmailAddress = emailAddress;
        }

        public int ClientID { get => clientID; set => clientID = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Company { get => company; set => company = value; }
        public string Contact { get => contact; set => contact = value; }
        public string CustomerAddress { get => customerAddress; set => customerAddress = value; }
        public string EmailAddress { get => emailAddress; set => emailAddress = value; }
    }
}
