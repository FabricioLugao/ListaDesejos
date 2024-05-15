using AutoMapper;
using ListaDesejosAPI.Models.Dto;
using ListaDesejosAPI.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ListaDesejosAPI.Controllers
{
    [Route("api/produtos")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepository _dbProduto;
        private readonly IMapper _mapper;

        public ProdutoController(IProdutoRepository dbProduto, IMapper mapper)
        {
            _dbProduto = dbProduto;
            _mapper = mapper;
        }

        [HttpGet("{categoriaId:int}/{email}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetUsuario(int categoriaId, string email)
        {
            if (string.IsNullOrEmpty(email) || categoriaId == 0)
            {
                ModelState.AddModelError("ErrorMessages", "Email e categoriaId obrigatórios");
                return BadRequest(ModelState);
            }

            var produtos = await _dbProduto.GetAllAsync(u => u.CategoriaId == categoriaId, includeProperties: "Categoria");

            if (produtos.Count == 0)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<List<ProdutoDTO>>(produtos));
        }
    }
}
