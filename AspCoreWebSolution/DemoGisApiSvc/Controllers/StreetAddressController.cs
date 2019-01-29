using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MongodbConnect.FeatureRepository;
using MongodbConnect.Models.StreetAddress;
using MongodbConnect.Repository;

namespace DemoGisApiSvc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StreetAddressController : GisController
    {
        public StreetAddressController(IConfiguration iConfig) : base(iConfig)
        {
        }

        [HttpGet]
        [Route("info")]
        public string Info()
        {
            return "StreetAddressController";
        }

        public StreetAddressRepository SARepository
        {
            get
            {
                return _unitOfWork.StreetAddressRepository;
            }
        }


        //update comment
        [Route("byname/{name}")]
        [HttpGet]
        public IEnumerable<StreetAddressDocument> GetAddressByName(string name)
        {
            return SARepository.FindStreetAddressByName(name);
        }


        [Route("byname/{name}/count")]
        [HttpGet]
        public int GetAddressByNameCount(string name)
        {
            return SARepository.FindStreetAddressByName(name).Count();
        }


        [Route("byname/{name}/{numberofrecords}")]
        [HttpGet]
        public IEnumerable<StreetAddressDocument> GetAddressByName(string name, int numberofrecords)
        {
            return SARepository.FindStreetAddressByName(name).Take(numberofrecords);
        }


        [Route("byname/{name}/{numberofrecords}/{page}")]
        [HttpGet]
        public IEnumerable<StreetAddressDocument> GetAddressByName(string name, int numberofrecords, int page)
        {
            if (page <= 0)
                page = 1;

            int count = SARepository.FindStreetAddressByName(name).Count();

            if (numberofrecords <= 0)
                numberofrecords = 10;

            int allpage = ((count - (count / page) * page) > 0) ? count / page + 1 : count / page;

            return SARepository.FindStreetAddressByName(name).Skip(page - 1).Take(numberofrecords);
        }


        [Route("bynamepaging/{name}/{numberofrecords}/{index}")]
        [HttpGet]
        public PagingResult<StreetAddressDocument> GetAddressByNamePaging(string name, int numberofrecords, int index)
        {
            if (index <= 0)
                index = 1;


            if (numberofrecords <= 0)
                numberofrecords = 10;



            return SARepository.FindStreetAddressByNamePaging(name, numberofrecords, index);
        }
    }
}