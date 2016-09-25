using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public interface IUnitOfWork 
    {
        IRepository<Customer> Customers{get;}
        IRepository<Diary> Diaries { get; }
        IRepository<Notes> Notes { get; }
        IRepository<Notification> Notifications { get; }

        void Save();
    }
}
