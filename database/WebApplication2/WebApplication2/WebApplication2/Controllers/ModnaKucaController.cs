using Microsoft.AspNetCore.Mvc;
using FashionWeek.DTOs;
using FashionWeek;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ModnaKucaController : ControllerBase
    {//radi
        [HttpGet]
        [Route("PreuzmiModneKuce")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult GetModneKuce()
        {
            try
            {
                return new JsonResult(DataProvider.VratiSveModneKuceAsync());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajModnuKucu")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> KreirajModnuKucu([FromBody] ModnaKucaView modnaKuca)
        {
            var (isError, id, error) = await DataProvider.SacuvajModnuKucuAsync(modnaKuca);

            if (isError)
            {
                return BadRequest(error);
            }

            return StatusCode(201, $"Kreirana modna kuca, sa ID: {id}");
        }

        [HttpPut]
        [Route("PromeniModnuKucu")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> PromeniModnuKucu([FromBody] ModnaKucaView modnaKuca)
        {
            var (isError, id, error) = await DataProvider.IzmeniModnuKucuAsync(modnaKuca);

            if (isError)
            {
                return BadRequest(error);
            }

            return StatusCode(201, $"Izmenjena modna kuca, sa ID: {id}");
        }

        //NESTO NECE
        [HttpDelete("IzbrisiModnuKucu/{idModneKuce}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> IzbrisiModnuKucu([FromRoute] int idModneKuce)
        {
            var data = await DataProvider.ObrisiModnuKucuAsync(idModneKuce);

            if (data.IsError)
            {
                return BadRequest(data.Error);
            }

            return Ok($"Izbrisana modna kuca, sa ID: {idModneKuce}");
        }

        [HttpPost]
        [Route("ModnaKucaModniKreator/{idModnaKuca}/{kreatorId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddModnaKucaModniKreatorDodavanje(int idModnaKuca, int kreatorId)
        {
            var data = await DataProvider.DodajUModnuKucuKreatoraAsync(idModnaKuca, kreatorId);

            if (data.IsError)
            {
                return BadRequest(data.Error);
            }

            return Ok($"Uspešno dodeljen modni kreator modnoj kuci: {idModnaKuca}");
        }

        [HttpPost]
        [Route("SpojiVlasnikaSaModnomKucom/{modnaKucaId}/{idVlasnik}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SpojiVlasnikaSaModnomKucom(int modnaKucaId, int idVlasnik)
        {
            var data = await DataProvider.DodajUModnuKucuVlasnikaAsync(modnaKucaId, idVlasnik);

            if (data.IsError)
            {
                return BadRequest(data.Error);
            }

            return Ok($"Uspešno dodeljen vlasnik modnoj kuci: {idVlasnik}");
        }
    }
}