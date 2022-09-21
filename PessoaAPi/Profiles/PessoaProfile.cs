using AutoMapper;
using PessoaAPi.Data.Dtos;
using PessoaAPi.Models;

namespace PessoaAPi.Profiles
{
    public class PessoaProfile : Profile
    {
        public PessoaProfile()
        {
            CreateMap<CreatePessoaDto, Pessoa>();
            CreateMap<Pessoa, ReadPesssoaDto>();
            CreateMap<UpdatePessoaDto, Pessoa>();
        }
    }
}
