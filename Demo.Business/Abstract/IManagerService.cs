using System;
using System.Collections.Generic;
using System.Text;
using Demo.Entities;

namespace Demo.Business.Abstract
{
    public interface IManagerService
    {
        public Manager Find(string username, string password);

        public Manager Update(Manager manager);
        public Manager Create(Manager manager);
        public void Delete(Manager manager);
    }
}
