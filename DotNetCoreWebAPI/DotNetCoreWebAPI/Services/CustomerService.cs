using AutoMapper;
using DotNetCoreWebAPI.Data;
using DotNetCoreWebAPI.Models;
using DotNetCoreWebAPI.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreWebAPI.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly WebAPIDBContext _context;
        private readonly IMapper _mapper;

        public CustomerService(WebAPIDBContext context, IMapper mapper)
        {
            _context = context;
            this._mapper = mapper;
        }

        /// <summary>
        /// Get list of all Customers
        /// </summary>
        /// <returns>List of Customers</returns>
        public List<Customer> GetCustomersList()
        {
            List<Customer> Customers;
            try
            {
                Customers = _context.Set<Customer>()
                    .Include(u => u.Clients)
                    .Where(c => c.IsActive == true)
                    .ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return Customers;
        }

        /// <summary>
        /// Get Customer details by Customer id
        /// </summary>
        /// <param name="CustomerId">The id of the Customer</param>
        /// <returns>The Customer details</returns>
        public Customer GetCustomerDetailsById(int CustomerId)
        {
            Customer Customer;
            try
            {
                Customer = _context.Find<Customer>(CustomerId);
            }
            catch (Exception)
            {
                throw;
            }
            return Customer;
        }

        /// <summary>
        /// Add or update a Customer
        /// </summary>
        /// <param name="CustomerModel">The Customer model to be saved</param>
        /// <returns>A response indicating the result of the operation</returns>
        public ResponseModel SaveCustomer(CustomerSaveDto CustomerSaveDto)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                Customer existingCustomer = GetCustomerDetailsById(CustomerSaveDto.CustomerId);
                if (existingCustomer != null)
                {

                    // Update existing Customer
                    _mapper.Map(CustomerSaveDto, existingCustomer);

                    _context.Update(existingCustomer);
                    model.Message = "Customer updated successfully.";
                }
                else
                {
                    // Add new Customer
                    var Customer = _mapper.Map<Customer>(CustomerSaveDto);
                    _context.Update<Customer>(Customer);
                    model.Message = "Customer added successfully.";
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
        /// Delete a Customer
        /// </summary>
        /// <param name="CustomerId">The id of the Customer to be deleted</param>
        /// <returns>A response indicating the result of the operation</returns>

        ///Method to Delete the Customer
        //public ResponseModel DeleteCustomer(int CustomerId)
        //{
        //    ResponseModel model = new ResponseModel();
        //    try
        //    {
        //        Customers CustomerToDelete = GetCustomerDetailsById(CustomerId);
        //        if (CustomerToDelete != null)
        //        {
        //            _context.Remove(CustomerToDelete);
        //            _context.SaveChanges();
        //            model.IsSuccess = true;
        //            model.Message = "Customer deleted successfully.";
        //        }
        //        else
        //        {
        //            model.IsSuccess = false;
        //            model.Message = "Customer not found.";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        model.IsSuccess = false;
        //        model.Message = "Error: " + ex.Message;
        //    }
        //    return model;
        //}

        public ResponseModel DeleteCustomer(int CustomerId)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                Customer CustomerToUpdate = GetCustomerDetailsById(CustomerId);
                if (CustomerToUpdate != null)
                {
                    // Instead of removing the Customer, update IsActive flag to false
                    CustomerToUpdate.IsActive = false;
                    _context.SaveChanges();
                    model.IsSuccess = true;
                    model.Message = "Customer deactivated successfully.";
                }
                else
                {
                    model.IsSuccess = false;
                    model.Message = "Customer not found.";
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
