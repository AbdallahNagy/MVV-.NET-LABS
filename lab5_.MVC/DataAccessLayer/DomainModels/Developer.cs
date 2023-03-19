using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DomainModels
{
    public class Developer
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public ICollection<Ticket> Tickets { get; set; } = new HashSet<Ticket>();
        public string FullName() => $"{FirstName} {LastName}";
        public Developer()
        {

        }
        public Developer(string fname, string lname)
        {
            Id = Guid.NewGuid();
            FirstName = fname;
            LastName = lname;
        }
    }
}
