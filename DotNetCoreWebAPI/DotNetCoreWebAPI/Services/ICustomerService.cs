using DotNetCoreWebAPI.Data;
using DotNetCoreWebAPI.Models;
using DotNetCoreWebAPI.ViewModels;

namespace DotNetCoreWebAPI.Services
{
    public interface ICustomerService
    {
        /// <summary>
        /// Get list of all customers
        /// </summary>
        /// <returns>List of customers</returns>
        List<Customer> GetCustomersList();

        /// <summary>
        /// Get customer details by customer id
        /// </summary>
        /// <param name="customerId">The id of the customer</param>
        /// <returns>The customer details</returns>
        Customer GetCustomerDetailsById(int customerId);

        /// <summary>
        /// Add or edit a customer
        /// </summary>
        /// <param name="customer">The customer model to be saved</param>
        /// <returns>A response indicating the result of the operation</returns>
        ResponseModel SaveCustomer(CustomerSaveDto customer);

        /// <summary>
        /// Delete a customer
        /// </summary>
        /// <param name="customerId">The id of the customer to be deleted</param>
        /// <returns>A response indicating the result of the operation</returns>
        ResponseModel DeleteCustomer(int customerId);
    }
}

