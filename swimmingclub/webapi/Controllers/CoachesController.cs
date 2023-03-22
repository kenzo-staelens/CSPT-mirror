﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Coaches;
using webapi.Entities;
using webapi.Repositories;

namespace webapi.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class CoachesController : ControllerBase {
        private readonly ICoachRepository _repo;

        public CoachesController(ICoachRepository repo) {
            _repo = repo;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<GetCoachModel>>> GetCoaches() {
            return await _repo.GetCoaches();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetCoachModel>> GetCoach(Guid id) {
            GetCoachModel coach = await _repo.GetCoach(id);
            return coach == null ? new StatusCodeResult(StatusCodes.Status404NotFound) : coach;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GetCoachModel>> PostCoach(PostCoachModel coach) {
            try {
                var getModel = await _repo.PostCoach(coach);
                return CreatedAtAction(nameof(PostCoach), new { id = getModel.Id }, getModel);
            }
            catch (Exception) {
                return new BadRequestResult();
            }
        }
    }
}
