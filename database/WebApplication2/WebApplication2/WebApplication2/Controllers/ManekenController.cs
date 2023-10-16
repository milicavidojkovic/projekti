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
    public class ManekenController : ControllerBase
    {//radi
        [HttpGet]
        [Route("PreuzmiManekene")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult GetManekene()
        {
            try
            {
                return new JsonResult(DataProvider.VratiSveManekeneAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajManekena")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddManekena([FromBody] ManekenView maneken)
        {
            var data = await DataProvider.SacuvajManekenaAsync(maneken);

            if (data.IsError)
            {
                return BadRequest(data.Error);
            }

            return Ok($"Uspešno dodat maneken: {maneken.Ime} {maneken.Prezime}");
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("ObrisiManekena/{idManekenena}")]
        public async Task<ActionResult> IzbrisiModnogKreatora(string idManekena)
        {
            var data = await DataProvider.ObrisiManekenaAsync(idManekena);

            if (data.IsError)
            {
                return BadRequest(data.Error);
            }

            return Ok($"Izbrisan maneken, ID: {idManekena}");
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("IzmeniManekena")]
        public async Task<ActionResult> IzmeniManekenaAsync([FromBody] ManekenView maneken)
        {
            var data = await DataProvider.IzmeniManekenaAsync(maneken);

            if (data.IsError)
            {
                return BadRequest(data.Error);
            }

            return Ok($"Upisan izmenjen maneken: {maneken.Ime} {maneken.Prezime}");
        }

        [HttpPost]
        [Route("ManekenRevija/{idRevija}/{manekenId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddRevijaManekenDodavanje(int idRevija, string manekenId)
        {
            var data = await DataProvider.PoveziManekenaIRevijuAsync(idRevija, manekenId);

            if (data.IsError)
            {
                return BadRequest(data.Error);
            }

            return Ok($"Uspešno dodeljena revija manekenu: {idRevija}");
        }

        [HttpPost]
        [Route("ManekenAgencija/{idAgencija}/{manekenId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddRevijaManekenDodavanje(int idAgencija, string manekenId)
        {
            var data = await DataProvider.PoveziManekenaIAgencijuAsync(idAgencija, manekenId);

            if (data.IsError)
            {
                return BadRequest(data.Error);
            }

            return Ok($"Uspešno dodeljena agencija manekenu: {idAgencija}");
        }

    }
}
