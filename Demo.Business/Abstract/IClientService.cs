using System;
using System.Collections.Generic;
using System.Text;
using Demo.Entities;

namespace Demo.Business.Abstract
{
    public interface IClientService
    {
        public Client Find(string clientNumber, string password);
        public Client Find(int id);
        public Client FindByIdentityNo(string identity);
        public Client FindByTaxNo(string taxNo);
        public IList<Client> GetList();
        public Client Update(Client client);
        public Client Create(Client client);
        public void Delete(Client client);
    }
}
