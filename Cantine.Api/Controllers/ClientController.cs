namespace Cantine.Api.Controllers;

using Cantine.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ClientController : ControllerBase
{
    private readonly static List<Client> _clients = new();
    private readonly ILogger<ClientController> _logger;

    public ClientController(ILogger<ClientController> logger)
    {
        _logger = logger;
    }

    [HttpPost]
    public ActionResult<Client> CreateClient(Client client)
    {
        _clients.Add(client);
        return Created();
    }

    [HttpPost("{nom}/crediter")]
    public ActionResult CrediterClient(string nom, decimal montant)
    {
        var client = _clients.FirstOrDefault(c => c.Nom == nom);
        if (client == null)
        {
            return NotFound();
        }

        client.Crediter(montant);
        return Ok();
    }
}
