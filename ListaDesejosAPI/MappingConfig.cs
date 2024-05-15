using AutoMapper;
using ListaDesejosAPI.Models;
using ListaDesejosAPI.Models.Dto;

namespace ListaDesejosAPI
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
            CreateMap<Categoria, CategoriaDTO>().ReverseMap();
            CreateMap<Produto, ProdutoDTO>().ReverseMap();
        }
    }
}
