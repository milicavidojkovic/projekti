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
    public class ModniKreatorController : ControllerBase
    {//radi
        [HttpGet]
        [Route("PreuzmiModneKreatore")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult GetModneKreatore()
        {
            try
            {
                return new JsonResult(DataProvider.VratiSveModneKreatoreAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        //IZMENI ZA MODNOG KREATORA
        [HttpPost]
        [Route("DodajModnogKreatora")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> KreirajModnuKucu([FromBody] ModniKreatorView modniKreator)
        {
            var (isError, id, error) = await DataProvider.SacuvajModnogKreatoraAsync(modniKreator);

            if (isError)
            {
                return BadRequest(error);
            }

            return StatusCode(201, $"Kreiran modni kreator, sa ID: {id}");
        }

        [HttpPost]
        [Route("DodajModnomKreatoruUcestvovanuReviju/{idModnogKreatora}/{idRevije}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddMKreatoruURevije([FromRoute] int idModnogKreatora,int idRevije)
        {
            var data = await DataProvider.DodajModnomKreatoruUcestvovaneRevijeAsync(idModnogKreatora,idRevije);

            if (data.IsError)
            {
                return BadRequest(data.Error);
            }

            return Ok($"Uspešno dodata ucestvovana revija {idRevije} modnom kreatoru {idModnogKreatora} ");
        }

        [HttpPost]
        [Route("DodajModnomKreatoruOrganizovanuReviju/{idModnogKreatora}/{idRevije}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddMKreatoruORevije([FromRoute] int idModnogKreatora, int idRevije)
        {
            var data = await DataProvider.DodajModnomKreatoruOrganizovaneRevijeAsync(idModnogKreatora, idRevije);

            if (data.IsError)
            {
                return BadRequest(data.Error);
            }

            return Ok($"Uspešno dodata organizovana revija {idRevije} modnom kreatoru {idModnogKreatora} ");
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("ObrisiModnogKreatora/{idKreatora}")]
        public async Task<ActionResult> IzbrisiModnogKreatora(int idKreatora)
        {
            var data = await DataProvider.ObrisiModnogKreatoraAsync(idKreatora);

            if (data.IsError)
            {
                return BadRequest(data.Error);
            }

            return Ok($"Izbrisan modni kreator, sa ID: {idKreatora}");
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("IzmeniModnogKreatora")]
        public async Task<ActionResult> IzmeniModnogKreatoraAsync([FromBody] ModniKreatorView modniKreator)
        {
            var data = await DataProvider.IzmeniModnogKreatoraAsync(modniKreator);

            if (data.IsError)
            {
                return BadRequest(data.Error);
            }

            return Ok($"Upisan izmenjeni modni kreator: {modniKreator.Ime} {modniKreator.Prezime}");
        }


        [HttpPost]
        [Route("SpojiModnogKreatoraSaModnomKucom/{modnaKucaId}/{kreatorId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SpojiMKreatoraSaModnomKucom(int modnaKucaId, int kreatorId)
        {
            var data = await DataProvider.DodajModnomKreatoruModnuKucuAsync(modnaKucaId, kreatorId);

            if (data.IsError)
            {
                return BadRequest(data.Error);
            }

            return Ok($"Uspešno dodeljen modni kreator modnoj kuci: {kreatorId}");
        }


        [HttpPost]
        [Route("SpojiModnogKreatoraSaModnimKreatorom/{idKreatora}/{kreatorId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SpojiMKreatoraSaModnomKreatorom(int idKreatora, int kreatorId)
        {
            var data = await DataProvider.DodajModnomKreatoruModneKreatoreAsync(idKreatora, kreatorId);

            if (data.IsError)
            {
                return BadRequest(data.Error);
            }

            return Ok($"Uspešno dodeljen modni kreator modnom kreatoru: {kreatorId}");
        }
    }
}
