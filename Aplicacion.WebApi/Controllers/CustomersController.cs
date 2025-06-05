using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test_Tuya.Application.DTOs;
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
        public async Task<ActionResult<Guid>> Create(CreateCustomerRequest createCustomerRequest,
            CancellationToken ct)
        {
            var customer = new Customer(createCustomerRequest.Name, createCustomerRequest.Email);
            await _repo.AddAsync(customer, ct);
            await _repo.SaveChangesAsync(ct);
            return CreatedAtAction(nameof(Get), new { id = customer.Id }, customer.Id);
        }
    }
}
