using CleanArchitecture.Core.Features.Image.Command.DeleteImage;
using CleanArchitecture.Core.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Features.UserCategory.Commands.DeleteUserCategories
{
    public class DeleteUserCategoriesCommandHandler : IRequestHandler<DeleteUserCategoriesCommandRequest, DeleteUserCategoriesCommandResponse>
    {
        IUserReadCategoryRepository _userReadCategoryRepository;
        IUserWriteCategoryRepository _userWriteCategoryRepository;

        public DeleteUserCategoriesCommandHandler(IUserReadCategoryRepository userReadCategoryRepository, IUserWriteCategoryRepository userWriteCategoryRepository)
        {
            _userReadCategoryRepository = userReadCategoryRepository;
            _userWriteCategoryRepository = userWriteCategoryRepository;
        }

        public async Task<DeleteUserCategoriesCommandResponse> Handle(DeleteUserCategoriesCommandRequest request, CancellationToken cancellationToken)
        {
            int deletedRowCount = await _userWriteCategoryRepository.DeleteByCustomCriteriaAsync(request.UserId, request.CategoryName,"UserId","UserCategoryName");

            if (deletedRowCount > 0)
            {
                // İşlem başarılı oldu, isteğe bağlı olarak bir yanıt döndürebilirsiniz.
                DeleteUserCategoriesCommandResponse response = new DeleteUserCategoriesCommandResponse
                {
                    Success = true,
                    Message = $"Successfully deleted {deletedRowCount} user category(s)."
                };


                return response;

            }
            else
            {

                throw new Exception("Failed to delete user category(s).");
            }

        }
    }
}
