using System.Threading.Tasks;
using AutoMapper;
using RollCall.Core.Dtos.Inputs;
using RollCall.Core.Dtos.Outputs;
using RollCall.Core.Entities;
using RollCall.Core.Interfaces.InterfacesBl;
using RollCall.Core.Interfaces.IRepositories;

namespace RollCall.BusinessLayer
{
    public class LoginBl : ILoginBl
    {
        private IRepository _repository;
        private IMapper _mapper;

        public LoginBl(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<UserDto> LoginAsync(UserLoginDto login)
        {
            UserEntity entity;
            UserDto user;

            user = null;
            entity = await _repository.User.GetAsync(login.Email);
            if (entity is null)
                return null;

            if(entity.Password == login.Password)
                user = _mapper.Map<UserDto>(entity);

            return user;
        }
    }
}