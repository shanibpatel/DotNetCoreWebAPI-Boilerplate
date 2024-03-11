using DotNetCoreWebAPI.Data;
using DotNetCoreWebAPI.ViewModels;

namespace DotNetCoreWebAPI.Services
{
    public interface IClientService
    {
        /// <summary>
        /// Get list of all clients
        /// </summary>
        /// <returns>List of clients</returns>
        List<Clients> GetClientsList();

        /// <summary>
        /// Get client details by client id
        /// </summary>
        /// <param name="clientId">The id of the client</param>
        /// <returns>The client details</returns>
        Clients GetClientDetailsById(int clientId);

        /// <summary>
        /// Add or edit a client
        /// </summary>
        /// <param name="client">The client model to be saved</param>
        /// <returns>A response indicating the result of the operation</returns>
        ResponseModel SaveClient(Clients clients);

        /// <summary>
        /// Delete a client
        /// </summary>
        /// <param name="clientId">The id of the client to be deleted</param>
        /// <returns>A response indicating the result of the operation</returns>
        ResponseModel DeleteClient(int clientId);
    }
}
