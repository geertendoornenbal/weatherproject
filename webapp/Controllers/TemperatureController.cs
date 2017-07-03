using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace weathergraph2.Controllers
{
  [Route("api/[controller]")]
  public class TemperatureController : Controller
  {
    // GET api/values
    [HttpGet]
    public double Get()
    {
      return 20;
    }
  }
}
