namespace Cantine.Application.Services;

using Cantine.Application.Interfaces;
using Cantine.Domain.Entities;

public class PrixService : IPrixService
{
    public decimal CalculerPriseEnCharge(TypeClient type, decimal montant)
    {
        return type switch
        {
            TypeClient.Interne => 7.5m,
            TypeClient.Prestataire => 6m,
            TypeClient.VIP => montant,
            TypeClient.Stagiaire => 10m,
            _ => 0m
        };
    }
}
