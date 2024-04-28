using Application.Features.Auths.Utilities;
using Application.Features.Users.Commands.Create;
using Application.Features.Users.DTOs;
using Domain.Entities.Identity;
using Mapster;

namespace Application.Features.Users.Mappings
{
    public class UserMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<User, UserDTO>()
                .Map(dest => dest.FullName, src => $"{src.FirstName} {src.LastName}")
                ;
            config.NewConfig<CreateUserCommandRequest, User>()
               .Map(dest => dest.Password, src => PasswordEncrypter.Encrypt(src.Password));
        }
    }
}



