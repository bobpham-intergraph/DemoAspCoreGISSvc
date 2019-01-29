using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MongodbConnect.FeatureRepository;
using MongodbConnect.Models.RatingUnit;
using MongodbConnect.Repository;

namespace DemoGisApiSvc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingUnitController : GisController
    {
        public RatingUnitController(IConfiguration iConfig) : base(iConfig)
        {
        }

        [HttpGet]
        [Route("info")]
        public string Info()
        {
            return "RatingUnitController";
        }

        public RatingUnitRepository SARepository
        {
            get
            {
                return _unitOfWork.RatingUnitRepository;
            }
        }

        [Route("byname/{name}")]
        [HttpGet]
        public IEnumerable<RatingUnitDocument> GetRatingUnitByName(string name)
        {
            return SARepository.FindRatingUnitByName(name);
        }


        [Route("byId/{id}")]
        [HttpGet]
        public IEnumerable<RatingUnitDocument> GetRatingUnitById(int id)
        {
            return SARepository.FindRatingUnitById(id);
        }


        [Route("byname/{name}/count")]
        [HttpGet]
        public int GetRatingUnitByNameCount(string name)
        {
            return SARepository.FindRatingUnitByName(name).Count();
        }


        [Route("byname/{name}/{numberofrecords}")]
        [HttpGet]
        public IEnumerable<RatingUnitDocument> GetRatingUnitByName(string name, int numberofrecords)
        {
            return SARepository.FindRatingUnitByName(name).Take(numberofrecords);
        }


        [Route("byname/{name}/{numberofrecords}/{page}")]
        [HttpGet]
        public IEnumerable<RatingUnitDocument> GetRatingUnitByName(string name, int numberofrecords, int page)
        {
            if (page <= 0)
                page = 1;

            int count = SARepository.FindRatingUnitByName(name).Count();

            if (numberofrecords <= 0)
                numberofrecords = 10;

            int allpage = ((count - (count / page) * page) > 0) ? count / page + 1 : count / page;

            return SARepository.FindRatingUnitByName(name).Skip(page - 1).Take(numberofrecords);
        }


        [Route("bynamepaging/{name}/{numberofrecords}/{index}")]
        [HttpGet]
        public PagingResult<RatingUnitDocument> GetRatingUnitByNamePaging(string name, int numberofrecords, int index)
        {
            if (index <= 0)
                index = 1;


            if (numberofrecords <= 0)
                numberofrecords = 10;

            return SARepository.FindRatingUnitByNamePaging(name, numberofrecords, index);
        }

    }
}