using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankDemo_App_BackEnd.Service.Dto
{
    public class TransactionDto
    {
        public string Recepient { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;

        
    }
}
