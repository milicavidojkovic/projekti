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
    public class VlasniciMKController:ControllerBase
    {
        //HOCE
        [HttpGet]
        [Route("PreuzmiVlasnikeMK")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult GetVlasnike()
        {
            try
            {
                return new JsonResult(DataProvider.VratiSveVlasnikeAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        //HOCE
        [HttpPost]
        [Route("DodajVlasnikeMK")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddVlasnikeMK([FromBody] VlasniciMKView r)
        {
            var data = await DataProvider.SacuvajVlasnikaAsync(r);

            if (data.IsError)
            {
                return BadRequest(data.Error);
            }

            return Ok($"Uspešno dodavanje vlasnika modne kuće: {r.ImeVlasanika}");
        }

        //HOCE
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("ObrisiVlasnikaMK/{id}")]
        public async Task<ActionResult> IzbrisiVlasnikaMK(int id)
        {
            var data = await DataProvider.ObrisiVlasnikaAsync(id);

            if (data.IsError)
            {
                return BadRequest(data.Error);
            }

            return Ok($"Izbrisan vlasnik modne kuće, sa ID: {id}");
        }

        //HOCE
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("IzmeniVlasnikaMK")]
        public async Task<ActionResult> IzmeniVlasnikaAsync([FromBody] VlasniciMKView vlasnik)
        {
            var data = await DataProvider.IzmeniVlasnikaAsync(vlasnik);

            if (data.IsError)
            {
                return BadRequest(data.Error);
            }

            return Ok($"Upisano izmenjena revije: {vlasnik.ImeVlasanika}");
        }

        [HttpPost]
        [Route("SpojiVlasnikaSaModnomKucom/{idVlasnik}/{modnaKucaId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SpojiVlasnikaSaModnomKucom(int idVlasnik, int modnaKucaId)
        {
            var data = await DataProvider.SpojiVlasnikaSaModnomKucomAsync(idVlasnik, modnaKucaId);

            if (data.IsError)
            {
                return BadRequest(data.Error);
            }

            return Ok($"Uspešno dodeljen vlasnik modnoj kuci: {idVlasnik}");
        }
    }
}
