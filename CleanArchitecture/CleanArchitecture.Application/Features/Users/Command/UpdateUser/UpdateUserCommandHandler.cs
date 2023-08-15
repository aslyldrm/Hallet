using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Features.Users.Command.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommandRequest, UpdateUserCommandResponse>
    {
        IUserReadRepository _userReadRepository;
        IUserWriteRepository _userWriteRepository;

        public UpdateUserCommandHandler(IUserReadRepository userReadRepository, IUserWriteRepository userWriteRepository)
        {
            _userReadRepository = userReadRepository;
            _userWriteRepository = userWriteRepository;
        }

        public async Task<UpdateUserCommandResponse> Handle(UpdateUserCommandRequest request, CancellationToken cancellationToken)
        {
            User user = await _userReadRepository.GetByIdAsync(request.Id);
            CreatePasswordHash(request.Password, out byte[] passwordHash,
         out byte[] passwordSalt);

            user.Name = request.Name;
            user.Surname = request.Surname;
            user.Email = request.Email;
            user.Image = request.Image;
           user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _userWriteRepository.SaveAsync();
            return new();

        }

        private void CreatePasswordHash(string password,
    out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash
                    (System.Text.Encoding.UTF8.GetBytes(password));

            }
        }
    }
}
