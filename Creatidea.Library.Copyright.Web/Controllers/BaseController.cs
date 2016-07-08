using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Creatidea.Library.Copyright.Web.Controllers
{
    using Creatidea.Library.Copyright.Web.Models;

    public class BaseController : Controller
    {
        protected readonly CopyrightsContext _context;

        public BaseController(CopyrightsContext context)
        {
            _context = context;
        }
    }
}