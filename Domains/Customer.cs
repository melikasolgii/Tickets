namespace Tickets.Domains
{
    public class Customer:BaseEntity
    {        
        public string Address { get; set; }                              
        public User User { get; set; }
    }
}
