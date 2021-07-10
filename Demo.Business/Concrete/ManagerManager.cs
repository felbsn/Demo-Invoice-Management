using Demo.Business.Abstract;
using Demo.DataAccess.Abstract;
using Demo.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Business.Concrete
{
    public class ManagerManager : IManagerService
    {

        IManagerRepository _managers;

        public ManagerManager(IManagerRepository clients)
        {
            _managers = clients;
        }

        public Manager Create(Manager manager)
        {
            return _managers.Add(manager);
        }

        public void Delete(Manager manager)
        {
            _managers.Delete(manager);
        }

        public Manager Find(string username, string password)
        {
            return _managers.Get(mgr => mgr.Username == username && mgr.Password == password);
        }

        public Manager Update(Manager manager)
        {
            return _managers.Update(manager);
        }
    }
}
