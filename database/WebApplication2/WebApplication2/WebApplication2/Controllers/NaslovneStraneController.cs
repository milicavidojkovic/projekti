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
    public class NaslovneStraneController:ControllerBase
    {//radi
        [HttpGet]
        [Route("PreuzmiNaslovneStane")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult GetNaslovneStrane()
        {
            try
            {
                return new JsonResult(DataProvider.VratiSveNaslovneStraneAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajNaslovneStrane")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SacuvajNaslovuStranuAsync([FromBody] NaslovneStraneView r)
        {
            var data = await DataProvider.SacuvajNaslovuStranuAsync(r);

            if (data.IsError)
            {
                return BadRequest(data.Error);
            }

            return Ok($"Uspešno dodata naslovna strana: {r.NaslovneStrana}");
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("ObrisiNaslovneStrane/{id}")]
        public async Task<ActionResult> ObrisiNaslovnuStranu(int id)
        {
            var data = await DataProvider.ObrisiNaslovnuStranuAsync(id);

            if (data.IsError)
            {
                return BadRequest(data.Error);
            }

            return Ok($"Izbrisan naslovne, sa ID: {id}");
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("IzmeniNaslovneStrane")]
        public async Task<ActionResult> IzmeniNaslovnuStranuAsync([FromBody] NaslovneStraneView naslovna)
        {
            var data = await DataProvider.IzmeniNaslovnuStranuAsync(naslovna);

            if (data.IsError)
            {
                return BadRequest(data.Error);
            }

            return Ok($"Upisano izmenjena revije: {naslovna.NaslovneStrana}");
        }

        [HttpPost]
        [Route("ManekenNaslovna/{idNaslovna}/{manekenId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddNaslovnaManekenDodavanje(int idNaslovna, string manekenId)
        {
            var data = await DataProvider.SpojiNaslovnuSaManekenomAsync(idNaslovna, manekenId);

            if (data.IsError)
            {
                return BadRequest(data.Error);
            }

            return Ok($"Uspešno dodeljena naslovna stana manekenu: {idNaslovna}");
        }
    }
    
}
