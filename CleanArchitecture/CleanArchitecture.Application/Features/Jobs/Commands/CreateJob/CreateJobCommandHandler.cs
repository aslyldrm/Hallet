using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Features.UserCategory.Commands.DeleteUserCategories;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.Interfaces.Repositories;
using CleanArchitecture.Core.Interfaces.Repositories.Image;
using MediatR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Features.Jobs.Commands.CreateJob
{
    public class CreateJobCommandHandler : IRequestHandler<CreateJobCommandRequest, CreateJobCommandResponse >{

        readonly IJobWriteRepository _jobWriteRepository;
        readonly IWriteImageRepository _writeImageRepository;
        readonly IJobReadRepository _jobReadRepository;
        readonly ICategoryReadRepository _jobTypeReadRepository;

        public CreateJobCommandHandler(IJobWriteRepository jobWriteRepository, IWriteImageRepository writeImageRepository, IJobReadRepository jobReadRepository, ICategoryReadRepository jobTypeReadRepository)
        {
            _jobWriteRepository = jobWriteRepository;
            _writeImageRepository = writeImageRepository;
            _jobReadRepository = jobReadRepository;
            _jobTypeReadRepository = jobTypeReadRepository;
        }

        public async Task<CreateJobCommandResponse> Handle(CreateJobCommandRequest request, CancellationToken cancellationToken)
        {
            var jobTypes = _jobTypeReadRepository.GetAll(false).ToList();
            int count = 0;
            for (int i = 0 ; i < jobTypes.Count; i++)
            {
                if (jobTypes[i].CategoryName.ToLower().Equals(request.JobType.ToLower()))
                {
                    count++;

               
                }
            }
            
             if (count == 0)
               {
                    CreateJobCommandResponse response = new CreateJobCommandResponse
                    {
                        Success = false,
                        Message = $"Your category wrong"
                    };
                    return response;
                }
            if ( request.OwnerId == "string")
            {
                CreateJobCommandResponse response = new CreateJobCommandResponse
                {
                    Success = false,
                    Message = $"You didn't enter owner id"
                };
                return response;
            }
            if (request.Location == "string")
            {
                CreateJobCommandResponse response = new CreateJobCommandResponse
                {
                    Success = false,
                    Message = $"You didn't enter location, please enter"
                };
                return response;
            }
            if (request.City == "string")
            {
                CreateJobCommandResponse response = new CreateJobCommandResponse
                {
                    Success = false,
                    Message = $"You didn't enter City, please enter"
                };
                return response;
            }


            count = 0;

            var newJob = new Job
            {
                Title = request.Title,
                Price = request.Price,
                JobType = request.JobType,
                CreatedDate = DateTime.Now,
                Description = request.Description,
                OwnerId = request.OwnerId,
                Location = request.Location,
                City = request.City,
                Status = "available"
            };

            bool isAdded = await _jobWriteRepository.AddAsync(newJob);

            if (isAdded)
            {
                await _jobWriteRepository.SaveAsync();

                CreateJobCommandResponse response = new CreateJobCommandResponse
                {
                    JobId = newJob.Id.ToString(),
                     Success = true
        
                    // Yaratılan işin ID'sini response'a ekleyin
                };

                return response; // Güncellenmiş yanıtı döndürün
            }
            else
            {
                return null;
            }

  
        }

         
        
    }
}
