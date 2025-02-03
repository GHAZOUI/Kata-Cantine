namespace Cantine.Application.Models;

using Cantine.Domain.Entities;

public class Ticket
{
    public Client Client { get; set; }
    public List<Produit> Produits { get; set; }
    public decimal Total { get; set; }
}
