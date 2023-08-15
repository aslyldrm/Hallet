using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Features.Users.Command.RegisterUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        readonly IUserReadRepository _userReadrepository;
        readonly IUserWriteRepository _userWriterepository;
        public CreateUserCommandHandler(IUserReadRepository repository, IUserWriteRepository userWriterepository)
        {
            _userReadrepository = repository;
            _userWriterepository = userWriterepository;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            CreatePasswordHash(request.Password, out byte[] passwordHash,
                out byte[] passwordSalt);

            var query = _userReadrepository.GetWhere(data => data.Email == request.Email, tracking: false);
            var result = await query.AnyAsync();
            if (result )
            {
                throw new Exception("This email is already in database ");

            }
          
            await _userWriterepository.AddAsync(new()
            {
                Name = request.Name,
                Email = request.Email,
                 Surname = request.Surname,
                PasswordHash = passwordHash,
              PasswordSalt = passwordSalt,
              Rating = 0.0
            });
            await _userWriterepository.SaveAsync();




            return new();

        }

        private void CreatePasswordHash(string password,
            out byte[] passwordHash,out byte[] passwordSalt)
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
