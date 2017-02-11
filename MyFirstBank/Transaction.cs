using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstBank
{
    //bool value
    public enum TransactionType 
    {
        Credit,
        Debit 
    }
    public class Transaction
    {
        [Key]
        public int TransactionNumber { get; set; }

        public DateTime TransactionDate { get; set; }

        public string Description { get; set; }

        public TransactionType TypeOfTransaction { get; set; }  

        public decimal Amount { get; set; }

        [ForeignKey("Account")]
        public int AccountNumber { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }

        public virtual Account Account { get; set; } // Account number is the primary key

    }
}
