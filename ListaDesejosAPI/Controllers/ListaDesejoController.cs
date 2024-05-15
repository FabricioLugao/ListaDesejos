using AutoMapper;
using ListaDesejosAPI.Models;
using ListaDesejosAPI.Models.Dto;
using ListaDesejosAPI.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ListaDesejosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListaDesejoController : ControllerBase
    {
        private readonly IUsuarioRepository _dbUsuario;
        private readonly IProdutoRepository _dbProduto;
        private readonly IListaDesejoRepository _dbListaDesejo;
        private readonly IMapper _mapper;

        public ListaDesejoController(IUsuarioRepository dbUsuario,
            IListaDesejoRepository dbListaDesejo, IProdutoRepository dbProduto,
            IMapper mapper)
        {
            _dbUsuario = dbUsuario;
            _dbProduto = dbProduto;
            _dbListaDesejo = dbListaDesejo;
            _mapper = mapper;
        }

        [HttpGet("{email}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetProdutosListaDesejo(string email)
        {
            var usuario = await _dbUsuario.GetAsync(u => u.Email == email);

            if (usuario == null)
            {
                return NotFound("Usuário não encontrado");
            }

            var listaDesejoItens = await _dbListaDesejo
                .GetAllAsync(ld => ld.UsuarioId == usuario.UsuarioId, includeProperties: "Produto,Produto.Categoria");
            var produtos = listaDesejoItens.Select(ld => ld.Produto).ToList();

            return Ok(_mapper.Map<List<ProdutoDTO>>(produtos));
        }

        [HttpGet("{email}/produtoIds")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetProdutosIdsListaDesejo(string email)
        {
            var usuario = await _dbUsuario.GetAsync(u => u.Email == email);

            if (usuario == null)
            {
                return NotFound("Usuário não encontrado");
            }

            var listaDesejoItens = await _dbListaDesejo
                .GetAllAsync(ld => ld.UsuarioId == usuario.UsuarioId);
            var produtoIds = listaDesejoItens.Select(ld => ld.ProdutoId).ToList();

            return Ok(produtoIds);
        }


        [HttpPost("{produtoId:int}/{email}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> AddListaDesejo(int produtoId, string email)
        {
            if (string.IsNullOrEmpty(email) || produtoId == 0)
            {
                ModelState.AddModelError("ErrorMessages", "Email e produtoId obrigatórios");
                return BadRequest(ModelState);
            }

            var usuario = await _dbUsuario.GetAsync(u => u.Email == email);

            if (usuario == null)
            {
                return NotFound("Usuário não encontrado");
            }

            var produto = await _dbProduto.GetAsync(u => u.ProdutoId == produtoId);

            if (produto == null)
            {
                return NotFound("Produto não encontrado");
            }

            var listaDesejoDb = await _dbListaDesejo
                .GetAsync(ld => ld.ProdutoId == produtoId && ld.UsuarioId == usuario.UsuarioId);

            if (listaDesejoDb != null)
            {
                return BadRequest("Produto já consta na lista deste usuário");
            }

            var listaDesejo = new ListaDesejo
            {
                ProdutoId = produtoId,
                UsuarioId = usuario.UsuarioId,
            };

            await _dbListaDesejo.CreateAsync(listaDesejo);

            return Ok();
        }

        [HttpDelete("{produtoId:int}/{email}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> RemoveListaDesejo(int produtoId, string email)
        {
            var usuario = await _dbUsuario.GetAsync(u => u.Email == email);

            if (usuario == null)
            {
                return NotFound("Usuário não encontrado");
            }

            var listaDesejoDb = await _dbListaDesejo
                .GetAsync(ld => ld.ProdutoId == produtoId && ld.UsuarioId == usuario.UsuarioId);

            if (listaDesejoDb == null)
            {
                return BadRequest("Produto não consta na lista deste usuário");
            }

            await _dbListaDesejo.RemoveAsync(listaDesejoDb);

            return Ok();
        }

    }
}
