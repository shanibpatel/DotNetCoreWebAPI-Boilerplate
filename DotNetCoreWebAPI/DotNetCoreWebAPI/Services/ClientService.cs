using DotNetCoreWebAPI.Data;
using DotNetCoreWebAPI.ViewModels;

namespace DotNetCoreWebAPI.Services
{
    public class ClientService : IClientService
    {
        private readonly WebAPIDBContext _context;

        public ClientService(WebAPIDBContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get list of all clients
        /// </summary>
        /// <returns>List of clients</returns>
        public List<Clients> GetClientsList()
        {
            List<Clients> clients;
            try
            {
                clients = _context.Set<Clients>()
                            .Where(c => c.IsActive == true)
                            .ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return clients;
        }

        /// <summary>
        /// Get client details by client id
        /// </summary>
        /// <param name="clientId">The id of the client</param>
        /// <returns>The client details</returns>
        public Clients GetClientDetailsById(int clientId)
        {
            Clients client;
            try
            {
                client = _context.Find<Clients>(clientId);
            }
            catch (Exception)
            {
                throw;
            }
            return client;
        }

        /// <summary>
        /// Add or update a client
        /// </summary>
        /// <param name="clientModel">The client model to be saved</param>
        /// <returns>A response indicating the result of the operation</returns>
        public ResponseModel SaveClient(Clients clientModel)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                Clients existingClient = GetClientDetailsById(clientModel.ClientId);
                if (existingClient != null)
                {
                    // Update existing client
                    existingClient.ClientCode = clientModel.ClientCode;
                    existingClient.ClientName = clientModel.ClientName;
                    existingClient.ContactPerson = clientModel.ContactPerson;
                    existingClient.Email = clientModel.Email;
                    existingClient.MobileNo = clientModel.MobileNo;
                    existingClient.Address = clientModel.Address;
                    existingClient.Notes = clientModel.Notes;
                    existingClient.IsActive = clientModel.IsActive;
                    existingClient.CreatedBy = clientModel.CreatedBy;
                    existingClient.CreatedWhen = clientModel.CreatedWhen;
                    existingClient.TouchedBy = clientModel.TouchedBy;
                    existingClient.TouchedWhen = clientModel.TouchedWhen;

                    _context.Update(existingClient);
                    model.Message = "Client updated successfully.";
                }
                else
                {
                    // Add new client
                    _context.Update<Clients>(clientModel);
                    model.Message = "Client added successfully.";
                }

                _context.SaveChanges();
                model.IsSuccess = true;
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Message = "Error: " + ex.Message;
            }
            return model;
        }

        /// <summary>
        /// Delete a client
        /// </summary>
        /// <param name="clientId">The id of the client to be deleted</param>
        /// <returns>A response indicating the result of the operation</returns>

        ///Method to Delete the Client
        //public ResponseModel DeleteClient(int clientId)
        //{
        //    ResponseModel model = new ResponseModel();
        //    try
        //    {
        //        Clients clientToDelete = GetClientDetailsById(clientId);
        //        if (clientToDelete != null)
        //        {
        //            _context.Remove(clientToDelete);
        //            _context.SaveChanges();
        //            model.IsSuccess = true;
        //            model.Message = "Client deleted successfully.";
        //        }
        //        else
        //        {
        //            model.IsSuccess = false;
        //            model.Message = "Client not found.";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        model.IsSuccess = false;
        //        model.Message = "Error: " + ex.Message;
        //    }
        //    return model;
        //}

        public ResponseModel DeleteClient(int clientId)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                Clients clientToUpdate = GetClientDetailsById(clientId);
                if (clientToUpdate != null)
                {
                    // Instead of removing the client, update IsActive flag to false
                    clientToUpdate.IsActive = false;
                    _context.SaveChanges();
                    model.IsSuccess = true;
                    model.Message = "Client deactivated successfully.";
                }
                else
                {
                    model.IsSuccess = false;
                    model.Message = "Client not found.";
                }
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Message = "Error: " + ex.Message;
            }
            return model;
        }

    }
}
