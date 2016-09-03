using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Account
    {
        public virtual int accountId { get; set; }
        public virtual string number { get; set; }
        public virtual string username { get; set; }
        public virtual string password { get; set; }
        public virtual Customer customer { get; set; }

        public Account()
        {
        }

        //copy constructor
        public Account(Account account)
        {
            this.accountId = account.accountId;
            this.number = account.number;
            this.username = account.username;
            this.password = account.password;
            this.customer = account.customer;
        }
    }
}
