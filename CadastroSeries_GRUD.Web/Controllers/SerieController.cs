using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CadastroSeries_GRUD.Src;
using CadastroSeries_GRUD.Models;

namespace CadastroSeries_GRUD.Web.Controllers
{
    [Route("[controller]")]
    public class SerieController : Controller
    {
        private readonly IRepository<Serie> _repository;

        public SerieController(IRepository<Serie> serieRepository) { 
            _repository = serieRepository;  
        }



        [HttpGet("")]
        public IActionResult Lista() { 
            return Ok(_repository.Lista().Select(s => new SerieModel(s)));
        }

        [HttpPut("{id}")]
        public IActionResult Atualiza(int id, [FromBody]SerieModel model){ 
            _repository.Atualiza(id, model.ToSerie());
            return NoContent();
        }

        [HttpPost("")]
        public IActionResult Insere([FromBody] SerieModel model)
        {
            model.Id = _repository.ProximoId();
            var serie = model.ToSerie();
            _repository.Insere(serie);
            return Created("", serie);
        }

        [HttpDelete("{id}")]
        public IActionResult Exclui(int id)
        {
            return Ok(id);
        }

        [HttpGet("{id}")]
        public IActionResult Consulta(int id)
        {
            return Ok(new SerieModel(_repository.RetornaPorId(id)));
        }
    }
}
