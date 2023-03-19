using Lab4.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.BL.ViewModels;
public record ReadTicketVM (int Id, string Title, string Description, Severity Severity);