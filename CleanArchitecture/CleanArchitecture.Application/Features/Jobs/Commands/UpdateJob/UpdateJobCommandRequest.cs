using CleanArchitecture.Core.Entities;
//using CleanArchitecture.Core.Entities.Identity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Features.Jobs.Commands.UpdateJob
{
    public class UpdateJobCommandRequest :  IRequest<UpdateJobCommandResponse>
    {
        public string Id { get; set; }
        public string Title { get; set; }//
        public string JobType { get; set; }//
    

        public string Status { get; set; }
        public string Description { get; set; }//job doer get put delete puanlandirma iki taneside koyulacak
        public float Price { get; set; }
       // public string Skill { get; set; }
      

        public int JobPosterRating { get; set; }
       // public int JobDoerRating { get; set; }
        public string JobDoerId { get; set; }

        public string JobPosterRequestId { get; set; }
    }
}
