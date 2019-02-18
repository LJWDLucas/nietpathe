using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace NietPathe.Models.Tickets
{
    public class TicketRepository : ITicketRepository
    {
        private readonly IDataContext _dataContext;

        public TicketRepository(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Ticket CreateTicket(Ticket ticket)
        {
            _dataContext.Tickets.InsertOneAsync(ticket);
            return ticket;
        }
    }
}
