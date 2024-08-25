namespace Tickets.Domains;
public class Employee : BaseEntity
{        
    public DateTime DateOfBirth { get; set; }                       
    public User User { get; set; }       
}
