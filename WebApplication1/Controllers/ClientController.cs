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
    public class ClientController : ControllerBase
    {
        private readonly banqueService _banqueService;
        public ClientController(banqueService banqueService)
        {
            _banqueService = banqueService;
        }
        [HttpGet]
        public IActionResult GetClients() => Ok(_banqueService.SeachByName(""));

        [HttpPost]
        public IActionResult AddClient([FromBody] Client client)
        {
            if (client == null)
                return BadRequest("Client cannot be null");
            _banqueService.AjouterClient(client);
            return Ok();
        }

    }

}