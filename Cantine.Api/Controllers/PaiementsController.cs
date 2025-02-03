namespace Cantine.Api.Controllers;

using Cantine.Application.Interfaces;
using Cantine.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class PaiementsController : ControllerBase
{
    private readonly IPaiementService _paiementService;
    private readonly ILogger<PaiementsController> _logger;

    public PaiementsController(IPaiementService paiementService, ILogger<PaiementsController> logger)
    {
        _paiementService = paiementService;
        _logger = logger;
    }

    [HttpPost("payer")]
    public ActionResult Payer(Client client, decimal montant)
    {
        if (_paiementService.Payer(client, montant))
            return Ok();
        return BadRequest("Fonds insuffisants");
    }
}
