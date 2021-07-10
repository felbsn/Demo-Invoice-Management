using Demo.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using Demo.Entities;


namespace Demo.DataAccess.Concrete.Ef
{
    public class ClientRepository : EfEntityRepositoryBase<Client,DemoContext> , IClientRepository
    {

    }
}
