namespace Cantine.Tests.Application;

using Cantine.Application.Models;
using Cantine.Application.Services;
using Cantine.Domain.Entities;

public class PaiementServiceTests
{
    [Fact]
    public void Payer_ShouldReduceCredit()
    {
        decimal expectedCredit = 10m;
        var service = new PaiementService();
        var client = new Client { Nom = "Test", Type = TypeClient.Prestataire };
        client.Crediter(20);

        bool result = service.Payer(client, 10);

        Assert.True(result);
        Assert.Equal(expectedCredit, client.Credit);
    }
}