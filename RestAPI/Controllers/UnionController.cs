using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestAPI.Models;
using Microsoft.EntityFrameworkCore;


namespace RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnionController : ControllerBase
    {
        private readonly CommandContext ctx;

        public UnionController(CommandContext context)
        {
            ctx = context;
        }

     
        [HttpGet("counties")]
        public ActionResult<IEnumerable<UnionCounty>> GetCounties()
        {
            var result = ctx.UnionCounties.Select(uc => new UnionCounty { ID = uc.ID, County = uc.County, 
                                                       Name = uc.Name,
                                                        LocalUnions = ctx.LocalUnions.Where(lu => lu.UnionCountyID == uc.ID).ToList()});
            return result.ToList();
        }

        [HttpGet("counties/{county}")]
        public ActionResult<UnionCounty> GetCounty(string county)
        {
            if (county.Equals("UKJENT"))
            {
                return null;
            }
        
            var result = ctx.UnionCounties.Where(c => c.County.Equals(county)).Select(uc => new UnionCounty
            {
                ID = uc.ID,
                County = uc.County,
                Name = uc.Name,
                LocalUnions = ctx.LocalUnions.Where(lu => lu.UnionCountyID == uc.ID).ToList()
            });
            return  result.FirstOrDefault();
        }


    }
}
