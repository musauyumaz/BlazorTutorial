using Application.Features.Commands.Users;
using Domain.Entities;
using Mapster;

namespace Application.Features.Mappings
{
    public class UserMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<User, UserDTO>()
                .Map(dest => dest.FullName, src => $"{src.FirstName} {src.LastName}");
        }
    }
}



