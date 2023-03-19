using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DomainModels
{
    public class Department
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<Ticket> Tickets { get; set; } = new HashSet<Ticket>();
        public string DeptInfo() => $"{Name} ({Id})";
        public Department()
        {

        }
        public Department(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
    }
}
