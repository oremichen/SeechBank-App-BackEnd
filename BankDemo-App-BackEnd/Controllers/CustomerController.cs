using BankDemo_App_BackEnd.Models;
using BankDemo_App_BackEnd.Service;
using BankDemo_App_BackEnd.Service.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BankDemo_App_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerManagementService _managementService;

        public CustomerController(ICustomerManagementService managementService)
        {
            _managementService = managementService;
        }

        [HttpPost("CreateTransaction")]
        public async Task<IActionResult> InsertCustomers(TransactionDto model)
        {
            var customer = new Customer(); 
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }



            //insert tranction
            var res = await _managementService.InsertTransaction(model);

             var getCustomer = await _managementService.GetCustomerDetails();
            if (getCustomer == null)
            {
                customer.Balance = model.Amount;
                customer.Name = "John Doe";
                await _managementService.UpdateCustomerBalance(customer);
            }
            else
            {
                var balance = getCustomer.Balance + model.Amount;
                getCustomer.Balance = balance;
                await _managementService.UpdateCustomerBalance(getCustomer);
            }
         

            //update customer balance
            await _managementService.UpdateCustomerBalance(customer);

            return Ok(res);

        }

        [HttpGet("GetTransactions")]
        [ProducesResponseType(typeof(IEnumerable<Transactions>), 200)]
        public async Task<IActionResult> GetTransactions()
        {
            var res = await _managementService.GetAllTransactions();
            return Ok(res);
        }


        [HttpGet("GetCustomer")]
        [ProducesResponseType(typeof(Customer), 200)]
        public async Task<IActionResult> GetCustomer()
        {
            var res = await _managementService.GetCustomerDetails();
            return Ok(res);
        }


    }
}
