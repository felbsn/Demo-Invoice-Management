using System;
using System.Collections.Generic;
using System.Text;
using Demo.Entities;

namespace Demo.DataAccess.Abstract
{
    public interface IClientRepository : IEntityRepository<Client>
    {
    }
}
