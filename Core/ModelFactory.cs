using Core.Models;
using Core.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class ModelFactory
    {
        public CustomerVM GetCustomerVM(Customer customer)
        {
            CustomerVM vm = new CustomerVM();
            vm.ID = customer.Id;
            vm.Name = customer.Name;
            return vm;
        }
    }
}
