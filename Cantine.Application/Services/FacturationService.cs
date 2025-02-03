namespace Cantine.Application.Services;

using Cantine.Application.Interfaces;
using Cantine.Application.Models;
using Cantine.Domain.Entities;

public class FacturationService : IFacturationService
{
    private readonly IPrixService _prixStrategy;
    public FacturationService(IPrixService prixStrategy) => _prixStrategy = prixStrategy;

    public Ticket GenererTicket(Client client, Plateau plateau)
    {
        decimal total = plateau.CalculerTotal();
        decimal priseEnCharge = _prixStrategy.CalculerPriseEnCharge(client.Type, total);
        decimal montantFinal = total - priseEnCharge;

        return new Ticket { Client = client, Produits = plateau.Produits, Total = montantFinal };
    }
}
