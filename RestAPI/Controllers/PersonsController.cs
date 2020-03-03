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
    public class PersonsController : ControllerBase
    {
        private readonly CommandContext ctx;

        public PersonsController(CommandContext context)
        {
            ctx = context;
        }

      

        //GET        api/persons
        [HttpGet]
        public ActionResult<IEnumerable<Person>> GetPerson()
        {
            return ctx.PersonItems;
        }


        //GET        api/persons/(value)
        [HttpGet("{id}")]
        public ActionResult<Person> GetCommandItem(int id)
        {
            var personItem = ctx.PersonItems.Find(id);

            if (personItem == null)
            {
                return NotFound();
            }

            return personItem;
        }



        //POST            api/commands
        [HttpPost]
        public ActionResult<Person> PostCommandItem(Person person)
        {
            ctx.PersonItems.Add(person);
            ctx.SaveChanges();

            return CreatedAtAction("GetPersonItem", new Person { Id = person.Id }, person);
        }

        //PUT      api/persons/{id}
        [HttpPut("{id}")]
        public ActionResult PutCommandItem(int id, Person person)
        {
            if (id != person.Id)
            {
                return BadRequest();
            }

            ctx.Entry(person).State = EntityState.Modified;
            ctx.SaveChanges();

            return NoContent();
        }

        //DELETE    api/persons/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCommandItem(int id)
        {
            var personItem = ctx.PersonItems.Find(id);

            if (id != personItem.Id)
            {
                return NotFound();
            }

            ctx.Remove(personItem);
            ctx.SaveChanges();

            return NoContent();
        }

    }
}
