using DotNetCoreWebAPI.Data;
using DotNetCoreWebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        /// <summary>
        /// Get all clients
        /// </summary>
        /// <returns>A list of clients</returns>
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetClients()
        {
            try
            {
                var clients = _clientService.GetClientsList();
                if (clients == null)
                    return NotFound();
                return Ok(clients);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Get client details by id
        /// </summary>
        /// <param name="id">The id of the client</param>
        /// <returns>The client details</returns>
        [HttpGet]
        [Route("[action]/{id}")]
        public IActionResult GetClientById(int id)
        {
            try
            {
                var client = _clientService.GetClientDetailsById(id);
                if (client == null)
                    return NotFound();
                return Ok(client);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Save client
        /// </summary>
        /// <param name="clientModel">The client model to save</param>
        /// <returns>A response indicating the result of the operation</returns>
        [HttpPost]
        [Route("[action]")]
        public IActionResult SaveClient(Clients clientModel)
        {
            try
            {
                var model = _clientService.SaveClient(clientModel);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Delete client
        /// </summary>
        /// <param name="id">The id of the client to delete</param>
        /// <returns>A response indicating the result of the operation</returns>
        [HttpDelete]
        [Route("[action]")]
        public IActionResult DeleteClient(int id)
        {
            try
            {
                var model = _clientService.DeleteClient(id);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
