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
        public int AccountToId { get; set; }

        public int? AccountFromId { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [ForeignKey("AccountToId")]
        [InverseProperty("TransactionsTo")]
        public virtual Account AccountTo { get; set; }

        [ForeignKey("AccountFromId")]
        [InverseProperty("TransactionsFrom")]
        public virtual Account AccountFrom { get; set; }
    }
}