namespace Cantine.Domain.Entities;

public class Client
{
    public string Nom { get; set; }
    public TypeClient Type { get; set; }
    public decimal Credit { get; private set; }

    public void Crediter(decimal montant) => Credit += montant;
    public bool Debiter(decimal montant) => (Credit -= montant) >= 0 || Type == TypeClient.Interne || Type == TypeClient.VIP;
}
