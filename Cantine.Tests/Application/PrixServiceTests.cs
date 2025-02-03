using Cantine.Application.Services;
using Cantine.Domain.Entities;

namespace Cantine.Tests.Application;

public class PrixServiceTests
{
    private readonly PrixService _prixStrategy = new();

    [Fact]
    public void CalculerPriseEnCharge_VIP_ShouldReturnFullAmount()
    {
        decimal expectedPriseEnCharge = 20m;
        decimal priseEnCharge = _prixStrategy.CalculerPriseEnCharge(TypeClient.VIP, 20);
        Assert.Equal(expectedPriseEnCharge, priseEnCharge);
    }

    [Fact]
    public void CalculerPriseEnCharge_Visiteur_ShouldReturnZero()
    {
        decimal expectedPriseEnCharge = 0m;
        decimal priseEnCharge = _prixStrategy.CalculerPriseEnCharge(TypeClient.Visiteur, 20);
        Assert.Equal(expectedPriseEnCharge, priseEnCharge);
    }
}
