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
    public class AgencijaController:ControllerBase
    {//radi
        [HttpGet]
        [Route("PreuzmiAgencije")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult GetAgencije()
        {
            try
            {
                return new JsonResult(DataProvider.VratiSveAgencijeAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        //

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("IzmeniAgenciju")]
        public async Task<ActionResult> IzmeniAgenciju([FromBody] AgencijaView agencija)
        {
            var data = await DataProvider.IzmeniAgencijuAsync(agencija);

            if (data.IsError)
            {
                return BadRequest(data.Error);
            }

            return Ok($"Izmenjena agencija: {agencija.Naziv}");
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("ObrisiAgenciju/{id}")]
        public async Task<ActionResult> ObrisiAgencijuAsync(int id)
        {
            var data = await DataProvider.ObrisiAgencijuAsync(id);

            if (data.IsError)
            {
                return BadRequest(data.Error);
            }

            return Ok($"Izbrisana agencija, sa ID: {id}");
        }

        [HttpPost]
        [Route("DodajAgenciju")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddAgenciju([FromBody] AgencijaView agencija)
        {
            var data = await DataProvider.SacuvajAgencijuAsync(agencija);

            if (data.IsError)
            {
                return BadRequest(data.Error);
            }

            return Ok($"Uspešno dodata agencija: {agencija.Naziv}");
        }

    }
}
