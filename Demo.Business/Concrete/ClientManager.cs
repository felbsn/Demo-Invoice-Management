using Demo.Business.Abstract;
using Demo.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using Demo.Entities;

namespace Demo.Business.Concrete
{
    public class ClientManager : IClientService
    {

        IClientRepository _clients;

        public ClientManager(IClientRepository clients)
        {
            _clients = clients;
        }

        public Client Create(Client client)
        {
            return _clients.Add(client);
        }

        public void Delete(Client client)
        {
            _clients.Delete(client);
        }

        public Client Find(string clientNumber, string password)
        {
           return  _clients.Get(client => client.ClientNumber == clientNumber && client.Password == password);
        }

        public Client Find(int id)
        {
            return _clients.Get(c => c.Id == id); 
        }

        public Client FindByIdentityNo(string identity)
        {
            return _clients.Get(client => client is IndividualClient && (client as IndividualClient).IdentityNo == identity);
        }

        public Client FindByTaxNo(string taxNo)
        {
            return _clients.Get(client => client is CorporateClient && (client as CorporateClient).TaxNo == taxNo);
        }

        public IList<Client> GetList()
        {
            return _clients.GetList();
        }

        public Client Update(Client client)
        {
            return _clients.Update(client);
        }
    }
}
