using DataAccessLayer.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories;

public interface ITicketsRepo
{
    IEnumerable<Ticket> GetAll();
    IEnumerable<Ticket>  GetTicketsDeptDev();
    Ticket GetTicketDeptDevById(Guid id);
    void Delete(Guid id);
    Ticket? GetTicketForEdit(Guid id);
    void UpdateTicket(Ticket ticket);
    void AddNewTicket(Ticket ticket);
    Ticket? GetById(Guid id);
    int SaveChanges();
}
