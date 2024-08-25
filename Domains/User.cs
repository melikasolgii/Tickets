namespace Tickets.Domains
{
    public class User : BaseEntity
    {
        public string Name { get; set; }        
        public string Username { get; set; }
        public string Password { get; set; }
        public string NationalCode { get; set; }
        public bool IsActive { get; set; }        

        #region Relations

        public ICollection<Customer> Customers { get; set; }
        public ICollection<Employee> Employees { get; set; }

        #endregion
    }
}
