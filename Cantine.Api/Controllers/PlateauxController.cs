namespace Cantine.Api.Controllers;

using Cantine.Application.Interfaces;
using Cantine.Application.Models;
using Cantine.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class PlateauxController : ControllerBase
{
    private readonly IFacturationService _facturationService;
    private readonly ILogger<PlateauxController> _logger;

    public PlateauxController(IFacturationService facturationService, ILogger<PlateauxController> logger)
    {
        _facturationService = facturationService;
        _logger = logger;
    }

    [HttpPost("generer-ticket")]
    public ActionResult<Ticket> GenererTicket(Client client)
    {
        Plateau plateau = new();
        var ticket = _facturationService.GenererTicket(client, plateau);
        return Ok(ticket);
    }
}
