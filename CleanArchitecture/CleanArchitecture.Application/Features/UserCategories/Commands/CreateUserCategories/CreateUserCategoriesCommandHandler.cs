using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Features.UserCategory.Commands.DeleteUserCategories;

using CleanArchitecture.Core.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Features.UserCategory.Commands.CreateUserCategories
{
    public class CreateUserCategoriesCommandHandler : IRequestHandler<CreateUserCategoriesCommandRequest, CreateUserCategoriesCommandResponse>
    {
        IUserReadCategoryRepository _userReadCategoryRepository;
        IUserWriteCategoryRepository _userWriteCategoryRepository;
        readonly ICategoryReadRepository _jobTypeReadRepository;

        public CreateUserCategoriesCommandHandler(IUserReadCategoryRepository userReadCategoryRepository, IUserWriteCategoryRepository userWriteCategoryRepository, ICategoryReadRepository jobTypeReadRepository)
        {
            _userReadCategoryRepository = userReadCategoryRepository;
            _userWriteCategoryRepository = userWriteCategoryRepository;
            _jobTypeReadRepository = jobTypeReadRepository;
        }

        public async Task<CreateUserCategoriesCommandResponse> Handle(CreateUserCategoriesCommandRequest request, CancellationToken cancellationToken)
        {
            int count = 0;
           
            var jobTypes = _jobTypeReadRepository.GetAll(false).ToList();

            foreach (var category in request.UserSkills)
            {
                for (int i = 0; i < jobTypes.Count; i++)
                {
                    if (jobTypes[i].CategoryName.ToLower().Equals(category.ToLower()))
                    {
                        await _userWriteCategoryRepository.AddAsync(new()
                        {
                            UserId = request.UserId,
                            UserCategoryName = category
                           
                        }); 

                        count++;
                    }
                }

               
            }
            await _userWriteCategoryRepository.SaveAsync();
            if(count > 0)
            {
                count = 0;
                return new CreateUserCategoriesCommandResponse();

            }
            else
            {
            
                return null;
            }

           

        }
    }
}
