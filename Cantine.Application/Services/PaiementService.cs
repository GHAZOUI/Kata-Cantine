namespace Cantine.Application.Services;

using Cantine.Application.Interfaces;
using Cantine.Domain.Entities;

public class PaiementService : IPaiementService
{
    public bool Payer(Client client, decimal montant)
    {
        return client.Debiter(montant);
    }
}
