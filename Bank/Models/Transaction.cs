using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Bank.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }

		[Required]
        public int AccountId { get; set; }

		[Required]
        public decimal Amount { get; set; }

		[Required]
        public DateTime Date { get; set; }

		[Required]
		public string Message { get; set; }

        [ForeignKey("AccountId")]
        public virtual Account Account { get; set; }
    }
}