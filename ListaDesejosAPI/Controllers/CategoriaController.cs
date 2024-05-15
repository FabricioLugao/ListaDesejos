using AutoMapper;
using ListaDesejosAPI.Models;
using ListaDesejosAPI.Models.Dto;
using ListaDesejosAPI.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ListaDesejosAPI.Controllers
{
    [Route("api/categorias")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepository _dbCategoria;
        private readonly IMapper _mapper;

        public CategoriaController(ICategoriaRepository dbCategoria, IMapper mapper)
        {
            _dbCategoria = dbCategoria;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetCategorias()
        {
            var categorias = await _dbCategoria.GetAllAsync();
            return Ok(_mapper.Map<List<CategoriaDTO>>(categorias));
        }
    }
}
