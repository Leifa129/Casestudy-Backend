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
    public class CommandsController : ControllerBase
    {
        private readonly CommandContext ctx;

        public CommandsController(CommandContext context)
        {
            ctx = context;
        }

        //GET        api/commands
        [HttpGet]
        public ActionResult<IEnumerable<Command>> GetCommand()
        {
            return ctx.CommandItems;
        }

        //GET        api/commands/persons
        [HttpGet("persons")]
        public ActionResult<IEnumerable<Person>> GetPerson()
        {
            return ctx.PersonItems;
        }


        //GET        api/commands/(value)
        [HttpGet("{id}")]
        public ActionResult<Command> GetCommandItem(int id)
        {
            var commandItem = ctx.CommandItems.Find(id);

            if(commandItem == null)
            {
                return NotFound();
            }

            return commandItem;
        }



        //POST            api/commands
        [HttpPost]
        public ActionResult<Command> PostCommandItem(Command command)
        {
            ctx.CommandItems.Add(command);
            ctx.SaveChanges();

            return CreatedAtAction("GetCommandItem", new Command { Id = command.Id }, command);
        }

        //PUT      api/commands/{id}
        [HttpPut("{id}")]
        public ActionResult PutCommandItem(int id, Command command)
        {
            if(id != command.Id)
            {
                return BadRequest();
            }

            ctx.Entry(command).State = EntityState.Modified;
            ctx.SaveChanges();

            return NoContent();
        }

        //DELETE    api/commands/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCommandItem(int id)
        {
            var commandItem = ctx.CommandItems.Find(id);

            if(id != commandItem.Id)
            {
                return NotFound();
            }

            ctx.Remove(commandItem);
            ctx.SaveChanges();

            return NoContent();
        }

    }
}
