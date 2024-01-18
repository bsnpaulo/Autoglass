using Autoglass.Domain.Models;
using Autoglass.Service.Dtos;
using AutoMapper;

namespace Autoglass.Service.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Produto, ProdutoDto>()
                .ForMember(dest => dest.CodigoProduto, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Descricao, opt => opt.MapFrom(src => src.Descricao))
                .ForMember(dest => dest.Situacao, opt => opt.MapFrom(src => MapSituacaoParaDto(src.Situacao)))
                .ForMember(dest => dest.DataFabricacao, opt => opt.MapFrom(src => src.DataFabricacao))
                .ForMember(dest => dest.DataValidade, opt => opt.MapFrom(src => src.DataValidade))
                .ForMember(dest => dest.CodigoFornecedor, opt => opt.MapFrom(src => src.FornecedorId))
                .ForMember(dest => dest.Fornecedor, opt => opt.MapFrom(src => src.Fornecedor));

            CreateMap<ProdutoDto, Produto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.CodigoProduto))
                .ForMember(dest => dest.Descricao, opt => opt.MapFrom(src => src.Descricao))
                .ForMember(dest => dest.Situacao, opt => opt.MapFrom(src => MapSituacaoParaModelo(src.Situacao)))
                .ForMember(dest => dest.DataFabricacao, opt => opt.MapFrom(src => src.DataFabricacao))
                .ForMember(dest => dest.DataValidade, opt => opt.MapFrom(src => src.DataValidade))
                .ForMember(dest => dest.FornecedorId, opt => opt.MapFrom(src => src.CodigoFornecedor));

            CreateMap<Fornecedor, FornecedorDto>()
                .ForMember(dest => dest.CodigoFornecedor, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.DescricaoFornecedor, opt => opt.MapFrom(src => src.DescricaoFornecedor))
                .ForMember(dest => dest.Cnpj, opt => opt.MapFrom(src => src.Cnpj))
                .ReverseMap();
        }

        private static string MapSituacaoParaDto(string situacao)
        {
            return situacao?.ToLower() switch
            {
                "a" => "Ativo",
                "i" => "Inativo",
                _ => situacao
            };
        }

        private static string MapSituacaoParaModelo(string situacao)
        {
            return situacao?.ToLower() switch
            {
                "ativo" => "A",
                "inativo" => "I",
                _ => situacao
            };
        }
    }
}