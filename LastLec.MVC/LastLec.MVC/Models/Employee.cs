using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace LastLec.MVC.Models;

public class Employee: IdentityUser
{
    [Column(TypeName ="date")]
    public DateTime DateBirth { get; set; }
}
