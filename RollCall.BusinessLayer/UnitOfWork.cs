using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RollCall.Core.Interfaces.InterfacesBl;

namespace RollCall.BusinessLayer
{
    public class UnitOfWork : IUnitOfWorkBl
    {
        public UnitOfWork(ILoginBl login, IAreaBl areaBl)
        {
            this.Login = login;
            this.Area = areaBl;
        }
        
        public IAreaBl Area { get; }

        public ILoginBl Login { get; }
    }
}