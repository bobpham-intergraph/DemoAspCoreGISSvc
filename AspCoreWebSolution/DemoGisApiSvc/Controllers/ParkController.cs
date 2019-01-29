using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MongodbConnect.FeatureRepository;
using MongodbConnect.Models.Park;
using MongodbConnect.Repository;

namespace DemoGisApiSvc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class ParkController : GisController
    {
        public ParkController(IConfiguration iConfig): base(iConfig)
        {
        }

        [HttpGet]
        [Route("info")]
        public string Info()
        {
            return "ParkController";
        }

        public ParkRepository SARepository
        {
            get
            {
                return _unitOfWork.ParkRepository;
            }
        }


        [Route("byname/{name}")]
        [HttpGet]
        [ProducesResponseType(200)]
        public IActionResult GetParkByName(string name)
        {
            return Ok(SARepository.FindParkByName(name));
        }

        [Route("byId/{id}")]
        [HttpGet]
        public IEnumerable<ParkDocument> GetParkById(int id)
        {
            return SARepository.FindParkById(id);
        }


        [Route("byname/{name}/count")]
        [HttpGet]
        public int GetParkByNameCount(string name)
        {
            return SARepository.FindParkByName(name).Count();
        }


        [Route("byname/{name}/{numberofrecords}")]
        [HttpGet]
        public IEnumerable<ParkDocument> GetParkByName(string name, int numberofrecords)
        {
            return SARepository.FindParkByName(name).Take(numberofrecords);
        }


        [Route("byname/{name}/{numberofrecords}/{page}")]
        [HttpGet]
        public IEnumerable<ParkDocument> GetParkByName(string name, int numberofrecords, int page)
        {
            if (page <= 0)
                page = 1;

            int count = SARepository.FindParkByName(name).Count();

            if (numberofrecords <= 0)
                numberofrecords = 10;

            int allpage = ((count - (count / page) * page) > 0) ? count / page + 1 : count / page;

            return SARepository.FindParkByName(name).Skip(page - 1).Take(numberofrecords);
        }


        [Route("bynamepaging/{name}/{numberofrecords}/{index}")]
        [HttpGet]
        public PagingResult<ParkDocument> GetParkByNamePaging(string name, int numberofrecords, int index)
        {
            if (index <= 0)
                index = 1;

            if (numberofrecords <= 0)
                numberofrecords = 10;

            return SARepository.FindParkByNamePaging(name, numberofrecords, index);
        }


    }
}