using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DomainModels;
public enum Severity
{
    Low,
    Medium,
    High
}

public class Ticket
{
    public Guid Id { get; set; }
    [Required]
    public string Title { get; set; } = string.Empty;
    [Required]
    public string Description { get; set; } = string.Empty;
    public Severity Severity { get; set; }
    [ForeignKey("Department")]
    public Guid? DeptId { get; set; }
    public Department? Department { get; set; }
    public ICollection<Developer> Developers { get; set; } = new HashSet<Developer>();
    public Ticket()
    {

    }
    public Ticket(string title, string description, Severity severity, Guid? deptid, ICollection<Developer> developers)
    {
        Id = Guid.NewGuid();
        Title = title;
        Description = description;
        Severity = severity;
        DeptId = deptid;
        Developers = developers;
    }
}