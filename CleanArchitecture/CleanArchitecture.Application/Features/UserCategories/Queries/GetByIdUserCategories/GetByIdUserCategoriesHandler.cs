


using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Features.UserCategories.Queries.GetAllUserCategories
{
    public class GetByIdUserCategoriesHandler : IRequestHandler<GetByIdUserCategoriesRequest, GetByIdUserCategoriesResponse>
    {
        IUserReadCategoryRepository _userReadCategoryRepository;

        public GetByIdUserCategoriesHandler(IUserReadCategoryRepository userReadCategoryRepository)
        {
            _userReadCategoryRepository = userReadCategoryRepository;
        }

        public async Task<GetByIdUserCategoriesResponse> Handle(GetByIdUserCategoriesRequest request, CancellationToken cancellationToken)
        {

            

            var record = await _userReadCategoryRepository.GetByCustomCriteriaAsync("UserId", request.UserId);
            foreach (var category in record)
            {
                Console.WriteLine(category.UserCategoryName);
            }

            if (record != null)
            {
                // Veri bulundu, yapılacak işlemleri gerçekleştirin.
                var response = new GetByIdUserCategoriesResponse();

                foreach (var category in record)
                {
                    response.CategoryNames.Add(category.UserCategoryName);
                }


                return response;
            }
            else
            {
                return null;
            }

        }
    }
}
