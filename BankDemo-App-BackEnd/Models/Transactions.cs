using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankDemo_App_BackEnd.Models
{
    public class Transactions
    {
        [Key]
        public int Id { get; set; }
        public string Recepient { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}
