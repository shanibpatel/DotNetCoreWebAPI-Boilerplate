using DotNetCoreWebAPI.Models;
using DotNetCoreWebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _CustomerService;

        public CustomerController(ICustomerService CustomerService)
        {
            _CustomerService = CustomerService;
        }

        /// <summary>
        /// Get all Customers
        /// </summary>
        /// <returns>A list of Customers</returns>
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetCustomers()
        {
            try
            {
                var Customers = _CustomerService.GetCustomersList();
                if (Customers == null)
                    return NotFound();
                return Ok(Customers);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Get Customer details by id
        /// </summary>
        /// <param name="id">The id of the Customer</param>
        /// <returns>The Customer details</returns>
        [HttpGet]
        [Route("[action]/{id}")]
        public IActionResult GetCustomerById(int id)
        {
            try
            {
                var Customer = _CustomerService.GetCustomerDetailsById(id);
                if (Customer == null)
                    return NotFound();
                return Ok(Customer);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Save Customer
        /// </summary>
        /// <param name="CustomerModel">The Customer model to save</param>
        /// <returns>A response indicating the result of the operation</returns>
        [HttpPost]
        [Route("[action]")]
        public IActionResult SaveCustomer(CustomerSaveDto CustomerModel)
        {
            try
            {
                var model = _CustomerService.SaveCustomer(CustomerModel);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Delete Customer
        /// </summary>
        /// <param name="id">The id of the Customer to delete</param>
        /// <returns>A response indicating the result of the operation</returns>
        [HttpDelete]
        [Route("[action]")]
        public IActionResult DeleteCustomer(int id)
        {
            try
            {
                var model = _CustomerService.DeleteCustomer(id);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
