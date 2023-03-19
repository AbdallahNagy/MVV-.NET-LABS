using BusinessLayer.ViewModels;
using DataAccessLayer.DomainModels;
using System.Net.Sockets;

namespace BusinessLayer;

public interface ITicketsManager
{
    IEnumerable<ReadTicketsVM> GetTicketsDeptDev();
    ReadTicketsVM GetTicketDeptDevById(Guid id);
    void Delete(Guid id);
    EditTicketsVM? GetTicketForEdit(Guid id);
    void UpdateTicket(EditTicketsVM ticket);
    void AddNewTicket(AddTicketsVM ticket);
}