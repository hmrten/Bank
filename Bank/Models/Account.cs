using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Bank.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public bool IsLocked { get; set; }

        [Required]
        public decimal Balance { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public virtual ICollection<Transaction> TransactionsTo { get; set; }
        public virtual ICollection<Transaction> TransactionsFrom { get; set; }

        public Account()
        {
            TransactionsTo = new List<Transaction>();
            TransactionsFrom = new List<Transaction>();
        }
    }
}