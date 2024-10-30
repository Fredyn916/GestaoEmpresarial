using AutoMapper;
using GestaoEmpresarial.Entidades.DTO.AcaoDTO;
using GestaoEmpresarial.Entidades.DTO.BalancoDTO;
using GestaoEmpresarial.Entidades.DTO.CargoDTO;
using GestaoEmpresarial.Entidades.DTO.DataBalancoDTO;
using GestaoEmpresarial.Entidades.DTO.EconomiaDTO;
using GestaoEmpresarial.Entidades.DTO.FuncionarioDTO;

namespace GestaoEmpresarial.Entidades.DTO
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateFuncionarioDTO, Funcionario>().ReverseMap();
            CreateMap<CreateEconomiaDTO, Economia>().ReverseMap();
            CreateMap<CreateDataDTO, DataBalanco>().ReverseMap();
            CreateMap<ReadFuncionarioDTO, Funcionario>().ReverseMap();
            CreateMap<CreateAcaoDTO, Acao>().ReverseMap();
            CreateMap<CreateCargoDTO, Cargo>().ReverseMap();
            CreateMap<CreateBalancoDTO, Balanco>().ReverseMap();
        }
    }
}
