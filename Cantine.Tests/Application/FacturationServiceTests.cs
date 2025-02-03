namespace Cantine.Tests.Application;

using Cantine.Application.Models;
using Cantine.Application.Services;
using Cantine.Domain.Entities;

public class FacturationServiceTests
{
    [Fact]
    public void GenererTicket_Prestataire_ShouldCalculateTotalCorrectly_WithoutSupp()
    {
        decimal expectedTotal = 10m - 6m; // Forumle - PriseEnCharge
        var prixService = new PrixService();
        var service = new FacturationService(prixService);
        var client = new Client { Nom = "Test", Type = TypeClient.Prestataire };
        var plateau = new Plateau 
        { 
            Produits = new List<Produit> 
            { 
                new Produit { Type = TypeProduit.Entree }, 
                new Produit { Type = TypeProduit.Plat }, 
                new Produit { Type = TypeProduit.Dessert }, 
                new Produit { Type = TypeProduit.Pain } 
            } 
        };

        var ticket = service.GenererTicket(client, plateau);

        Assert.Equal(expectedTotal, ticket.Total);
    }

    [Fact]
    public void GenererTicket_Interne_ShouldCalculateTotalCorrectly_WithSupp()
    {
        decimal expectedTotal = 15m - 7.5m; // Total - PriseEnCharge
        var prixService = new PrixService();
        var service = new FacturationService(prixService);
        var client = new Client { Nom = "Test", Type = TypeClient.Interne };
        var plateau = new Plateau 
        { 
            Produits = new List<Produit> 
            { 
                new Produit { Type = TypeProduit.Entree }, // 3€
                new Produit { Type = TypeProduit.Plat }, // 6€
                new Produit { Type = TypeProduit.Boisson }, // 1€
                new Produit { Type = TypeProduit.PetitSaladeBar }, // 4€
                new Produit { Type = TypeProduit.Fromage }, // 1€
            } 
        };

        var ticket = service.GenererTicket(client, plateau);

        Assert.Equal(expectedTotal, ticket.Total);
    }
}
