using DataAccessLayer.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ViewModels;

public record ReadTicketsVM(Guid Id, string Title, string Description, string Severity, string? Department, int Developers);