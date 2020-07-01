using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MYTestingASPNETCore.Data;
using MYTestingASPNETCore.Dtos;
using MYTestingASPNETCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MYTestingASPNETCore.Controllers
{
    //api/commands
    [Route("api/commands")]
    [ApiController]
    public class CommandsConroller : ControllerBase
    {

        private readonly ICommanderRepo _repository;
        private readonly IMapper _mapper;
        //private readonly MockCommanderRepo _repository = new MockCommanderRepo();

        public CommandsConroller(ICommanderRepo repository, IMapper mapper)
        {
            _repository = repository; //Dependecy Injection
            _mapper = mapper;
        }



        //GET api/commands  
        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDto>> GetAllCommands()
        {
            var commandItems = _repository.GetAllCommands();
            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandItems));
        }




        //GET api/commands/1 
        [HttpGet("{id}", Name = "GetCommandById")]
        public ActionResult<CommandReadDto> GetCommandById(int id)
        {
            var commandItem = _repository.GetCommandById(id);

            if (commandItem != null)
                return Ok(_mapper.Map<CommandReadDto>(commandItem));
            return NotFound();

        }




        //POST api/commands
        [HttpPost]
        public ActionResult<CommandReadDto> CreateCoomand(CommandCreateDto commandCreateDto)
        {
            var commandModel = _mapper.Map<Command>(commandCreateDto);
            _repository.CreateCommand(commandModel);
            _repository.SaveChanges();


            var commandReadDto = _mapper.Map<CommandReadDto>(commandModel);

            return CreatedAtRoute(nameof(GetCommandById), new { Id = commandReadDto.Id }, commandReadDto);
        }




        //PUT api/commands
        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id, CommandUpdateDto commandUpdateDto)
        {
            var commandModelFromRepo = _repository.GetCommandById(id);

            if (commandModelFromRepo == null)
            {
                return NotFound();
            }
            else
            {
                _mapper.Map(commandUpdateDto, commandModelFromRepo);
                _repository.UpdateCommand(commandModelFromRepo);

                _repository.SaveChanges();

                return Ok();
            }

        }





        // PATCH api/commands/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<CommandUpdateDto> patchDoc)
        {
            var commandModelFrom = _repository.GetCommandById(id);
            if (commandModelFrom == null)
            {
                return NotFound();
            }

            var commandToPatch = _mapper.Map<CommandUpdateDto>(commandModelFrom);
            patchDoc.ApplyTo(commandToPatch, ModelState);

            if (!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(commandToPatch, commandModelFrom);

            _repository.UpdateCommand(commandModelFrom);
            _repository.SaveChanges();
            return Ok();
        }

    }

      
}
