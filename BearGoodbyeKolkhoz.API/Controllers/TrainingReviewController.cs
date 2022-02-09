﻿using AutoMapper;
using BearGoodbyeKolkhozProject.API.Models;
using BearGoodbyeKolkhozProject.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace BearGoodbyeKolkhozProject.API.Controllers
{
    [ApiController]
    [Route("api/training-review")]
    public class TrainingReviewController : Controller
    {

        private readonly ITrainingReviewService _service;
        private readonly IMapper _mapper;


        public TrainingReviewController(ITrainingReviewService trainingReviewService, IMapper mapper)
        {
            _service = trainingReviewService;
            _mapper = mapper;
        }


    }
}
