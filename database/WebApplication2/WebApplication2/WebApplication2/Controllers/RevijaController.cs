using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FashionWeek.DTOs;
using FashionWeek;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RevijaController : ControllerBase
    {//radi
        [HttpGet]
        [Route("PreuzmiSveRevije")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetRevija()
        {
            var radnici = await DataProvider.VratiSveRevijeAsync();

            if (radnici.IsError)
            {
                return BadRequest(radnici.Error);
            }

            return Ok(radnici.Data); 
        }

        [HttpPost]
        [Route("DodajReviju")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddReviju([FromBody] RevijaView r)
        {
            var data = await DataProvider.SacuvajRevijuAsync(r);

            if (data.IsError)
            {
                return BadRequest(data.Error);
            }

            return Ok($"Uspešno dodata revija: {r.Naziv}, u {r.Mesto}");
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("IzmeniReviju")]
        public async Task<ActionResult> IzmeniReviju([FromBody] RevijaView r)
        {
            var data = await DataProvider.IzmeniRevijuAsync(r);

            if (data.IsError)
            {
                return BadRequest(data.Error);
            }

            return Ok($"Upisano izmenjena revije: {r.Naziv}");
        }

        //NECE
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("IzbrisiReviju/{idRevije}")]
        public async Task<ActionResult> IzbrisReviju(int idRevije)
        {
            var data = await DataProvider.ObrisiRevijuAsync(idRevije);

            if (data.IsError)
            {
                return BadRequest(data.Error);
            }

            return Ok($"Izbrisana revija, sa ID: {idRevije}");
        }

        [HttpPost]
        [Route("SpojiRevijuSaOrganizatorom/{revijaId}/{kreatorId}/{prvaRevija}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SpojiRevijuSaOrganizatorom(int revijaId, int kreatorId, string prvaRevija)
        {
            var data = await DataProvider.DodajRevijiOrganizatoraAsync(revijaId, kreatorId, prvaRevija);

            if (data.IsError)
            {
                return BadRequest(data.Error);
            }

            return Ok($"Uspešno dodeljena revija organizatoru: {kreatorId}");
        }


        [HttpPost]
        [Route("SpojiRevijuSaKolekcijom/{revijaId}/{kolekcijaId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SpojiRevijuSaKolekcijom(int revijaId, int kolekcijaId)
        {
            var data = await DataProvider.DodajRevijiKolekcijuAsync(revijaId, kolekcijaId);

            if (data.IsError)
            {
                return BadRequest(data.Error);
            }

            return Ok($"Uspešno dodeljena revija kolekciji: {kolekcijaId}");
        }

        [HttpPost]
        [Route("SpojiRevijuSaKreatoromUcesnikom/{revijaId}/{kreatorId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SpojiRevijuSaKreatoromUcesnikom(int revijaId, int kreatorId)
        {
            var data = await DataProvider.DodajRevijiKreatoraUcesnikaAsync(revijaId, kreatorId);

            if (data.IsError)
            {
                return BadRequest(data.Error);
            }

            return Ok($"Uspešno dodeljen kreator ucesnik reviji: {revijaId}");
        }

        [HttpPost]
        [Route("SpojiRevijuSaManekenom/{revijaId}/{manekenId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SpojiRevijuSaManekenom(int revijaId, int manekenId)
        {
            var data = await DataProvider.DodajRevijiManekenaAsync(revijaId, manekenId);

            if (data.IsError)
            {
                return BadRequest(data.Error);
            }

            return Ok($"Uspešno dodeljen maneken reviji: {revijaId}");
        }
    }
}
