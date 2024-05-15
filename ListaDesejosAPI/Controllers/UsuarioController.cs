using AutoMapper;
using ListaDesejosAPI.Models;
using ListaDesejosAPI.Models.Dto;
using ListaDesejosAPI.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ListaDesejosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _dbUsuario;
        private readonly IMapper _mapper;

        public UsuarioController(IUsuarioRepository dbUsuario, IMapper mapper)
        {
            _dbUsuario = dbUsuario;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateUsuario([FromBody] UsuarioDTO createDTO)
        {
            if (await _dbUsuario.GetAsync(u => u.Email.ToLower() == createDTO.Email.ToLower()) != null)
            {
                return BadRequest("Email já existe");
            }

            if (createDTO == null)
            {
                return BadRequest(createDTO);
            }

            Usuario usuario = _mapper.Map<Usuario>(createDTO);

            await _dbUsuario.CreateAsync(usuario);

            return Ok(usuario);
        }

        [HttpGet("{email}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetUsuario(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return BadRequest("Email obrigatório");
            }

            var usuario = await _dbUsuario.GetAsync(u => u.Email == email);

            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<UsuarioDTO>(usuario));
        }
    }
}
