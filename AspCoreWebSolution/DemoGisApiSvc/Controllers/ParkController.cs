using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongodbConnect.Models.Park;
using MongodbConnect.Repository;

namespace DemoGisApiSvc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkController : GisController
    {
        [HttpGet]
        [Route("info")]
        public string Info()
        {
            return "ParkController";
        }


        [Route("byname/{name}")]
        [HttpGet]
        public IEnumerable<ParkDocument> GetParkByName(string name)
        {
            return _unitOfWork.ParkRepository.FindParkByName(name);
        }

        [Route("byId/{id}")]
        [HttpGet]
        public IEnumerable<ParkDocument> GetParkById(int id)
        {
            return _unitOfWork.ParkRepository.FindParkById(id);
        }


        [Route("byname/{name}/count")]
        [HttpGet]
        public int GetParkByNameCount(string name)
        {
            return _unitOfWork.ParkRepository.FindParkByName(name).Count();
        }


        [Route("byname/{name}/{numberofrecords}")]
        [HttpGet]
        public IEnumerable<ParkDocument> GetParkByName(string name, int numberofrecords)
        {
            return _unitOfWork.ParkRepository.FindParkByName(name).Take(numberofrecords);
        }


        [Route("byname/{name}/{numberofrecords}/{page}")]
        [HttpGet]
        public IEnumerable<ParkDocument> GetParkByName(string name, int numberofrecords, int page)
        {
            if (page <= 0)
                page = 1;

            int count = _unitOfWork.ParkRepository.FindParkByName(name).Count();

            if (numberofrecords <= 0)
                numberofrecords = 10;

            int allpage = ((count - (count / page) * page) > 0) ? count / page + 1 : count / page;

            return _unitOfWork.ParkRepository.FindParkByName(name).Skip(page - 1).Take(numberofrecords);
        }


        [Route("bynamepaging/{name}/{numberofrecords}/{index}")]
        [HttpGet]
        public PagingResult<ParkDocument> GetParkByNamePaging(string name, int numberofrecords, int index)
        {
            if (index <= 0)
                index = 1;

            if (numberofrecords <= 0)
                numberofrecords = 10;

            return _unitOfWork.ParkRepository.FindParkByNamePaging(name, numberofrecords, index);
        }


    }
}