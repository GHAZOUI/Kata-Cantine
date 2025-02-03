namespace Cantine.Application.Interfaces;

using Cantine.Application.Models;
using Cantine.Domain.Entities;

public interface IFacturationService
{
    Ticket GenererTicket(Client client, Plateau plateau);
}
