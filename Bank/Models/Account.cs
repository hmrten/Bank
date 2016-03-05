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

        public int UserId { get; set; }

        public bool IsLocked { get; set; }

        public decimal Balance { get; set; }

        [ForeignKey("UserId")]
        public virtual Customer User { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }

        public Account()
        {
            Transactions = new List<Transaction>();
        }
    }
}