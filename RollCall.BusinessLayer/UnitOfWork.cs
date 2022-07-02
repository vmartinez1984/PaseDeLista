using RollCall.Core.Interfaces.InterfacesBl;

namespace RollCall.BusinessLayer
{
    public class UnitOfWork : IUnitOfWorkBl
    {
        public UnitOfWork(
            ILoginBl login, IAreaBl areaBl, IScheduleBl scheduleBl
            , IUserBl userBl
            , IRoleBl roleBl
        )
        {
            this.Login = login;
            this.Area = areaBl;
            this.Schedule = scheduleBl;
            this.User = userBl;
            this.Role = roleBl;
        }

        public IAreaBl Area { get; }

        public ILoginBl Login { get; }

        public IScheduleBl Schedule { get; }
        
        public IUserBl User { get; }

        public IRoleBl Role { get; }
        
    }//end class
}