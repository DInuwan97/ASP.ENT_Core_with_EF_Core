using MYTestingASPNETCore.Dtos;
using MYTestingASPNETCore.Models;
using AutoMapper;
namespace MYTestingASPNETCore.Profiles
{
    public class CommandsProfiles : Profile
    {
        public CommandsProfiles()
        {
            //Source -> Target
            CreateMap<Command, CommandReadDto>();
            CreateMap<CommandCreateDto, Command>();
            CreateMap<CommandUpdateDto, Command>();
            CreateMap<Command, CommandUpdateDto>();
        }
    }
}
