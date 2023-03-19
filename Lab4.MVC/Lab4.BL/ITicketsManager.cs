using Lab4.BL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.BL;

public interface ITicketsManager
{
    List<ReadTicketVM> GetAll();
    ReadTicketVM? Get(int id);
    void Add(AddTicketVM ticket);
    void Edit(EditTicketVM ticket);
    EditTicketVM? GetToEdit(int id);
}
