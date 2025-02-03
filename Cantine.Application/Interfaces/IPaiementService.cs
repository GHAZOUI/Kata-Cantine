namespace Cantine.Application.Interfaces;

using Cantine.Domain.Entities;

public interface IPaiementService
{
    bool Payer(Client client, decimal montant);
}
