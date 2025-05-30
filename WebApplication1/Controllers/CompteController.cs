using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using minibanque.Models;
using minibanque.Service;

namespace minibanque.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompteController : ControllerBase
    {
        private readonly banqueService _banqueService;
        public CompteController(banqueService banqueService)
        {
            _banqueService = banqueService;
        }

        [HttpGet]
        public IActionResult GetComptes() => Ok(_banqueService.SeachByName(""));

        [HttpPost]
        public IActionResult AddCompte([FromBody] Compte compte)
        {
            if (compte == null)
                return BadRequest("Client cannot be null");
            _banqueService.AddCompte(compte);
            return Ok();
        }


        [HttpGet("client/{clientId}")]
        public ActionResult<IEnumerable<Compte>> ObtenirCompte(int clientId)
        {
            Console.WriteLine("debut de traitement");
            var comptes = _banqueService.RechercherComptesParClient(clientId);
            Console.WriteLine("fin d'affichage");
            if (comptes == null || !comptes.Any())
            {
                return NotFound($"Aucun compte trouvé pour ce client : {clientId}");
            }
            return Ok(comptes);
        }

        

        [HttpGet("{Id}")]
        public ActionResult RetournerUnCompte(int Id)
        {
            var compte = _banqueService.RechercherCompte(Id);
            if (compte == null)
            {
                return NotFound($"Aucun compte trouvé pour ce client : {Id}");
            }
            return Ok(compte);
        }
        [HttpPost("virement")]
        public IActionResult Virement([FromQuery] int SourceId, [FromQuery] int DestinationId, [FromQuery] decimal montant)
        {
            if (_banqueService.Virement(SourceId, DestinationId, montant))
            {
                return Ok("Virement effectué avec succès");
            }
            else
            {
                return BadRequest("Erreur lors du virement");
            }
        }
        [HttpDelete("{Id}")]
        public IActionResult SupprimerCompte(int Id)
        {
            var compte = _banqueService.RechercherCompte(Id);
            if (compte == null)
            {
                return NotFound($"Aucun compte trouvé pour ce client : {Id}");
            }
            _banqueService.DeleteCompte(Id);
            return NoContent();
        }
    }

}