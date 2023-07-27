using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingConsoleApp.BusinessObject
{
    
    public interface IClientRepository
    {
        Client GetClientFromId(int clientId);
        public bool PersistCart();
    }
}
