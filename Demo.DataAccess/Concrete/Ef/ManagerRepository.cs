using Demo.DataAccess.Abstract;
using Demo.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.DataAccess.Concrete.Ef
{
    public class ManagerRepository : EfEntityRepositoryBase<Manager, DemoContext>, IManagerRepository
    {

    }
}
