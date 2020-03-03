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
    public class CaseController : ControllerBase
    {
        private readonly CommandContext ctx;

        public CaseController(CommandContext context)
        {
            ctx = context;
        }

            //      api/case/cases
        [HttpGet("cases")]
        public ActionResult<IEnumerable<Case>> GetCases()
        {
            return ctx.CaseItems;
        }

        [HttpGet("{id}")]
        public ActionResult<Case> GetCaseItem(int id)
        {
            var caseItem =  ctx.CaseItems.Find(id);

            if(caseItem == null)
            {
                return NotFound();
            }


            return caseItem;
        }

        //PUT      api/case
        [HttpPut]
        public ActionResult PutCaseItem( Case caseItem)
        {
            var myCase = ctx.CaseItems.FirstOrDefault(c => c.Email.Equals(caseItem.Email));

            if (myCase != null)
            {      
                myCase.FirstName = caseItem.FirstName;
                myCase.LastName = caseItem.LastName;
                myCase.Phone = caseItem.Phone;
                myCase.Email = caseItem.Email;
                myCase.UnionID = caseItem.UnionID;
                ctx.Entry(myCase).State = EntityState.Modified;
                ctx.SaveChanges();

               
            }

            else
            {
                ctx.CaseItems.Add(caseItem);
                ctx.SaveChanges();
            }



            return NoContent();
        }

        [HttpPost]
        public ActionResult<Case> PostCaseItem(Case c)
        {
            ctx.CaseItems.Add(c);
            ctx.SaveChanges();

            return CreatedAtAction("GetCaseItem", new Case { Id = c.Id }, c);
        }

        

    }
}
