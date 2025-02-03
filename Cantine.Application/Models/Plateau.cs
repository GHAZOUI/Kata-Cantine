namespace Cantine.Application.Models;

using Cantine.Domain.Entities;

public class Plateau
{
    private readonly Dictionary<TypeProduit, decimal> Supplements = new()
    {
        { TypeProduit.Entree, 3m },
        { TypeProduit.Plat, 6m },
        { TypeProduit.Dessert, 3m },
        { TypeProduit.Boisson, 1m },
        { TypeProduit.Fromage, 1m },
        { TypeProduit.Pain, 0.40m },
        { TypeProduit.PetitSaladeBar, 4m },
        { TypeProduit.GrandSaladeBar, 6m },
        { TypeProduit.PortionFruit, 1m }
    };

    public List<Produit> Produits { get; set; } = new();
    public decimal CalculerTotal()
    {
        bool isFormule =
                Produits.Any(p => p.Type == TypeProduit.Entree) &&
                Produits.Any(p => p.Type == TypeProduit.Plat) &&
                Produits.Any(p => p.Type == TypeProduit.Dessert) &&
                Produits.Any(p => p.Type == TypeProduit.Pain);

        decimal total = Produits.Where(p => Supplements.ContainsKey(p.Type)).Sum(p => Supplements[p.Type]);

        // si on a une formule, on ajout 10€ puis on retirer le prix des produits de la formule.
        if (isFormule)
        {
            total += 10m - Supplements[TypeProduit.Entree] 
                - Supplements[TypeProduit.Pain] 
                - Supplements[TypeProduit.Plat] 
                - Supplements[TypeProduit.Dessert];
        }

        return total;
    }
}