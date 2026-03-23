using ItoApp.Application.Interfaces;
using ItoApp.Domain.Entities.ItoCare;
using Microsoft.AspNetCore.Mvc;

namespace ItoApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChiNhanhController : ControllerBase
    {
        private readonly IItoCareRepository _repository;

        public ChiNhanhController(IItoCareRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChiNhanh>>> GetAll()
        {
            var result = await _repository.LayTatCaChiNhanh();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ChiNhanh>> GetById(int id)
        {
            var result = await _repository.LayChiNhanhTheoId(id);
            if (result == null) return NotFound();
            return Ok(result);
        }
    }
}

