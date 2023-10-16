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
    public class ZemljaController:ControllerBase
    {

        //HOCE
        [HttpGet]
        [Route("PreuzmiZemlje")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult GetZemlje()
        {
            try
            {
                return new JsonResult(DataProvider.VratiSveZemljeAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        //NECE
        [HttpPost]
        [Route("DodajZemlju")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddZemlju([FromBody] ZemljaView zemlja)
        {
            var data = await DataProvider.SacuvajZemljuAsync(zemlja);

            if (data.IsError)
            {
                return BadRequest(data.Error);
            }

            return Ok($"Uspešno dodata zemlju: {zemlja.Naziv}");
        }

        //HOCE
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("ObrisiZemlju/{id}")]
        public async Task<ActionResult> IzbrisiZemlju(int id)
        {
            var data = await DataProvider.ObrisiZemljuAsync(id);

            if (data.IsError)
            {
                return BadRequest(data.Error);
            }

            return Ok($"Izbrisana zemlja, sa ID: {id}");
        }

        //HOCE
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("IzmeniZemlju")]
        public async Task<ActionResult> IzmeniZemlju([FromBody] ZemljaView zemlja)
        {
            var data = await DataProvider.IzmeniZemljuAsync(zemlja);

            if (data.IsError)
            {
                return BadRequest(data.Error);
            }

            return Ok($"Upisano izmenjena zemlja: {zemlja.Naziv}");
        }

        [HttpPost]
        [Route("ZemljaAgencija/{idZemlja}/{agencijaId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddZemljaAgencijaDodavanje(int idZemlja, int agencijaId)
        {
            var data = await DataProvider.SpojiZemljuSaAgencijomAsync(idZemlja, agencijaId);

            if (data.IsError)
            {
                return BadRequest(data.Error);
            }

            return Ok($"Uspešno dodeljena zemlja agenciji: {idZemlja}");
        }

    }
}
