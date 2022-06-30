using System;
using RollCall.Core.Interfaces.IRepositories;

namespace RollCall.Dao.Dao
{
    public class Repository : IRepository
    {
        public Repository(IAreaRepository areaRepository, IUserRepository userRepository)
        {
            this.Area = areaRepository;
            this.User = userRepository;
        }

        public IAreaRepository Area { get; }

        public IEmployeeRepository Employee => throw new NotImplementedException();

        public ISecurityQuestionRepository SecurityQuestion => throw new NotImplementedException();

        public IUserRepository User { get; }

        public IScheduleRepository Schedule => throw new NotImplementedException();

        public IAssistanceLog AssistanceLog => throw new NotImplementedException();
    }
}