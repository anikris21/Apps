using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MetricsAppAPI.Services;

using MetricsAppAPI.Model;
namespace MetricsAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        CustomerService _customersvc; 
        
        public CustomerController(CustomerService svc) 
        { 
            _customersvc = svc; 
        }

        [HttpPost("customers")]

        // Todo : DTo instead of obj 
        public async Task<ActionResult> CreateCustomer(Customer c1) 
        {
            var createdCust = await _customersvc.CreateAsync(c1);
            return CreatedAtAction("GetCustomer", new { customerId = 0 }, c1); 
        }

        [HttpGet("customers/{customerId}")]
        public async Task<ActionResult> GetCustomer(int customerId)
        {
            var cust = await _customersvc.GetById(customerId);
            return cust == null ? Ok(cust) : NotFound();
        }

        [HttpGet("customers")]
        public async Task<ActionResult> GetCustomers(int customerId)
        {
            var cust = await _customersvc.GetAllAsync();
            return cust == null ? Ok(cust) : NotFound();
        }




    }
}
