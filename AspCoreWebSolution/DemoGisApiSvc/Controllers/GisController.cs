using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MongodbConnect;

namespace DemoGisApiSvc.Controllers
{
    public class GisController : Controller
    {
        protected UnitOfWork _unitOfWork;

        protected IConfiguration _configuration;

        public GisController(IConfiguration iConfig)
        {
            _configuration = iConfig;

            _unitOfWork = new UnitOfWork(_configuration);
        }

    }
}