using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Features.Jobs.Commands.CreateJob;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Features.Jobs.Commands.UpdateJob
{
    public class UpdateJobCommandHandler : IRequestHandler<UpdateJobCommandRequest, UpdateJobCommandResponse>
    {
        IJobReadRepository _jobReadRepository;
        IJobWriteRepository _jobWriteRepository;
        IUserWriteRepository _userWriteRepository;
        IUserReadRepository _userReadRepository;
        private IJobDoerRequestWriteRepository _jobDoerRequestWriteRepository;
        readonly ICategoryReadRepository _jobTypeReadRepository;

        public UpdateJobCommandHandler(IJobReadRepository jobReadRepository, IJobWriteRepository jobWriteRepository, IUserWriteRepository userWriteRepository, IUserReadRepository userReadRepository, ICategoryReadRepository jobTypeReadRepository, IJobDoerRequestWriteRepository jobDoerRequestWriteRepository)
        {
            _jobReadRepository = jobReadRepository;
            _jobWriteRepository = jobWriteRepository;
            _userWriteRepository = userWriteRepository;
            _userReadRepository = userReadRepository;
            _jobTypeReadRepository = jobTypeReadRepository;
            _jobDoerRequestWriteRepository = jobDoerRequestWriteRepository;
        }

        public async Task<UpdateJobCommandResponse> Handle(UpdateJobCommandRequest request, CancellationToken cancellationToken)
        {
            //category kısmı da eklenecek
            var jobTypes = _jobTypeReadRepository.GetAll(false).ToList();
            int count = 0;
            for (int i = 0; i < jobTypes.Count; i++)
            {
                if (jobTypes[i].CategoryName.ToLower().Equals(request.JobType.ToLower()))
                {
                    count++;


                }
            }

            Job job = await _jobReadRepository.GetByIdAsync(request.Id);
          
           if (count == 0 && request.JobType != "string")
            {
                UpdateJobCommandResponse response = new UpdateJobCommandResponse
                {
                    Success = false,
                    Message = $" Control the jobtype."
                };

                return response;
            }
 
            count = 0;
            if (!request.Status.Equals("string"))
            {
                job.Status = request.Status.ToLower();

            }

            else if (!request.Title.Equals("string"))
            {
                job.Title = request.Title;


            }
            else if (request.Price != 0)
            {
                job.Price = request.Price;

            }
            else if (!request.JobType.Equals("string"))
            {
                job.JobType = request.JobType;


            }
            else if (!request.JobDoerId.Equals("string"))
            {
                job.DoerId = request.JobDoerId;

            }
            else if (!request.JobPosterRequestId.Equals("string"))
            {
                job.JobPosterRequestId = request.JobPosterRequestId;


            }
            else if (!request.Description.Equals("string"))
            {
                job.Description = request.Description;


            }
            else if (request.JobPosterRating != 0)
            {
                job.JobPosterRating = request.JobPosterRating;

            }



            if (request.Status.ToLower().Equals("completed")){
                User user = await _userReadRepository.GetByIdAsync(job.DoerId);
                user.CompletedJobs++;
                user.Rating =( user.Rating + request.JobPosterRating) / user.CompletedJobs;
                await _userWriteRepository.SaveAsync();
            }
            //job doer da kabul edilmeyen userlar silinecek
            if (request.Status.ToLower().Equals("accepted"))
            {
                _jobDoerRequestWriteRepository.DeleteAndSaveData(job.DoerId);


            }

                await _jobWriteRepository.SaveAsync();
            return new()
            {
                Success = true
        
            };
        }
    }
}
