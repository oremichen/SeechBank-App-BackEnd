using BankDemo_App_BackEnd.Models;
using BankDemo_App_BackEnd.Service.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankDemo_App_BackEnd.Service
{
    public interface ICustomerManagementService
    {
        Task<IEnumerable<Transactions>> GetAllTransactions();
        Task<Transactions> InsertTransaction(TransactionDto customer);
        Task<Customer> GetCustomerDetails();
        Task<Customer> UpdateCustomerBalance(Customer customer);
    }

    public class CustomerManagementService : ICustomerManagementService
    {
        private readonly DataBaseContext _context;

        public CustomerManagementService(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<Transactions> InsertTransaction(TransactionDto model)
        {
            var customer = new Transactions
            {
                Amount = model.Amount,
                DateCreated = model.DateCreated,
                Description = model.Description,
                Recepient = model.Recepient
            };
            var result = await _context.AddAsync(customer);

            await _context.SaveChangesAsync();

            return result.Entity;


        }

        public async Task<IEnumerable<Transactions>> GetAllTransactions()
        {
            var result = _context.Transactions.AsQueryable().OrderBy(x => x.DateCreated);


            return result.ToList();


        }

        public async Task<Customer> GetCustomerDetails()
        {
            var result = _context.Customers.FirstOrDefault();

            return result;


        }

        public async Task<Customer> UpdateCustomerBalance(Customer customer)
        {
            var update = _context.Customers.Update(customer);

            await _context.SaveChangesAsync();


            return update.Entity;


        }

        public async Task<Customer> InsertCustomerBalance(Customer customer)
        {
            var update = await _context.Customers.AddAsync(customer);

            await _context.SaveChangesAsync();

            return update.Entity;


        }
    }
}
