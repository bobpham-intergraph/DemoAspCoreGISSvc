using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongodbConnect;

namespace DemoGisApiSvc.Controllers
{
    public class GisController : Controller
    {
        protected UnitOfWork _unitOfWork = new UnitOfWork();

               
    }
}