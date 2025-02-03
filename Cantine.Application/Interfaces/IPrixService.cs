namespace Cantine.Application.Interfaces;

using Cantine.Domain.Entities;

public interface IPrixService
{
    decimal CalculerPriseEnCharge(TypeClient type, decimal montant);
}
