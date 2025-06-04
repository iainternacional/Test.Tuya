using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test_Tuya.Domain.Entities;
using Test_Tuya.Domain.Repositories;

namespace Aplicacion.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository _repo;
        public CustomersController(ICustomerRepository repo) => _repo = repo;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetAll(CancellationToken ct)
            => Ok(await _repo.GetAllAsync(ct));

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Customer>> Get(Guid id, CancellationToken ct)
        {
            var c = await _repo.GetByIdAsync(id, ct);
            return c is null ? NotFound() : Ok(c);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create(
            [FromBody] string name, [FromBody] string email,
            CancellationToken ct)
        {
            var customer = new Customer(name, email);
            await _repo.AddAsync(customer, ct);
            await _repo.SaveChangesAsync(ct);
            return CreatedAtAction(nameof(Get), new { id = customer.Id }, customer.Id);
        }
    }
}
