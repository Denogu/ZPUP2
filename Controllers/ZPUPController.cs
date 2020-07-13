using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ZPUPController : ControllerBase
    {
       
        private readonly ILogger<ZPUPController> _logger;

        public ZPUPController(ILogger<ZPUPController> logger)
        {
            _logger = logger;
        }
    }
}