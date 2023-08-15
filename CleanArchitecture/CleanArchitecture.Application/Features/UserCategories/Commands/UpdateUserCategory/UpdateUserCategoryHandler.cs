using CleanArchitecture.Core.Entities;

using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Features.UserCategory.Commands.UpdateUserCategory
{
    public class UpdateUserCategoryHandler : IRequestHandler<UpdateUserCategoryRequest, UpdateUserCategoryResponse>
    {
        readonly IUserReadCategoryRepository _userReadCategoryRepository;
        readonly IUserWriteCategoryRepository _userWriteCategoryRepository;

        public UpdateUserCategoryHandler(IUserReadCategoryRepository userReadCategoryRepository, IUserWriteCategoryRepository userWriteCategoryRepository)
        {
            _userReadCategoryRepository = userReadCategoryRepository;
            _userWriteCategoryRepository = userWriteCategoryRepository;
        }

        public async Task<UpdateUserCategoryResponse> Handle(UpdateUserCategoryRequest request, CancellationToken cancellationToken)
        {
            var filteredJobs = _userReadCategoryRepository.GetAll(false)
         .Where(p => p.UserId == request.UserId);

            foreach (var job in filteredJobs)
            {
                job.UserCategoryName = request.UserCategoryName; // Yeni değeri burada atayın
                                                            // Diğer güncelleme işlemlerini burada yapabilirsiniz
            }

            // Güncelleme işlemleri tamamlandıktan sonra veritabanını kaydedin
            await _userWriteCategoryRepository.SaveAsync();

            var response = new UpdateUserCategoryResponse()
            {
                UserCategories = filteredJobs.Select(p => p.UserCategoryName).ToList(),
                // Diğer özellikleri veya verileri doldurabilirsiniz
            };

            return response;
        }
    }
}
