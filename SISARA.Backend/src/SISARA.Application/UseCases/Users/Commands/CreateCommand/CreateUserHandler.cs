using AutoMapper;
using MediatR;
using SISARA.Application.Common.Base;
using SISARA.Application.Interfaces;
using SISARA.Domain.Entities;
using SISARA.Domain.ValueObjects;

namespace SISARA.Application.UseCases.Users.Commands.CreateCommand
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, BaseResponse<bool>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IMapper _mapper;
        public CreateUserHandler(IUserRepository userRepository, IPasswordHasher passwordHasher, IMapper mapper)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _mapper = mapper;
        }

        public async Task<BaseResponse<bool>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();
            try
            {
                var passwordHashed = _passwordHasher.HashPassword(request.Password!);
                var user = _mapper.Map<User>(request);
                user.Password = passwordHashed;
                var data = await _userRepository.UserRegister(user);
                if (data > 0)
                {
                    response.Data = true;
                    response.IsSuccess = true;
                    response.Message = "Registrado Correctamente!";
                }

            }catch(Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
