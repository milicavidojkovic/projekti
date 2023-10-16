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
    public class KolekcijaController : ControllerBase
    {
        [HttpGet]
        [Route("PreuzmiSveKolekcije")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult GetKolekcije()
        {
            try
            {
                return new JsonResult(DataProvider.VratiSvKolekcijeAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        //NE RADI
        [HttpPost]
        [Route("DodajKolekciju")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> KreirajKolekciju([FromBody] KolekcijaView kolekcija)
        {
            var (isError, id, error) = await DataProvider.SacuvajKolekcijuAsync(kolekcija);

            if (isError)
            {
                return BadRequest(error);
            }

            return StatusCode(201, $"Kreirana modna kuca, sa ID: {id}");
        }


        //
        [HttpPost]
        [Route("DodajKolekcijiRevijuIModnuKucu/{idKolekcije}/{idRevije}/{idModneKuce}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DodajKolekcijiRevijuIModnuKucu([FromRoute] int idKolekcije, int idRevije, int idModneKuce)
        {
            var data = await DataProvider.PoveziKolekcijuRevijuIModnuKucuAsync(idKolekcije, idRevije,idModneKuce);

            if (data.IsError)
            {
                return BadRequest(data.Error);
            }

            return Ok($"Uspešno dodata revija {idRevije} i modna kuca {idModneKuce} kolekciji {idKolekcije} ");
        }

        //NE RADI
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("ObrisiKolekciju/{idKolekcije}")]
        public async Task<ActionResult> IzbrisiKolekciju(int idKolekcije)
        {
            var data = await DataProvider.ObrisiKolekcijuAsync(idKolekcije);

            if (data.IsError)
            {
                return BadRequest(data.Error);
            }

            return Ok($"Izbrisana kolekcija, sa ID: {idKolekcije}");
        }

        //RADI
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("IzmeniKolekciju")]
        public async Task<ActionResult> IzmeniKolekcijuAsync([FromBody] KolekcijaView kolekcija)
        {
            var data = await DataProvider.IzmeniKolekcijuAsync(kolekcija);

            if (data.IsError)
            {
                return BadRequest(data.Error);
            }

            return Ok($"Upisana izmenjena kolekcija: {kolekcija.Naziv}");
        }
    }
}
