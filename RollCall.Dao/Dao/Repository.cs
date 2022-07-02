using System;
using RollCall.Core.Interfaces.IRepositories;

namespace RollCall.Dao.Dao
{
    public class Repository : IRepository
    {
        public Repository(
            IAreaRepository areaRepository
            //, IEmployeeRepository employeeRepository
            //, ISecurityQuestionRepository securityQuestionRepository
            , IUserRepository userRepository
            , IScheduleRepository scheduleRepository
            //, IAssistanceLog assistanceLog
            ,IConfigurationRepository configurationRepository
        )
        {
            this.Area = areaRepository;
            this.User = userRepository;
            //this.Employee = employeeRepository;
            //this.SecurityQuestion = securityQuestionRepository;
            this.Schedule = scheduleRepository;
            //this.AssistanceLog = AssistanceLog;
            this.Configuration = configurationRepository;
        }

        public IAreaRepository Area { get; }

        public IEmployeeRepository Employee => throw new NotImplementedException();//{ get; }

        public ISecurityQuestionRepository SecurityQuestion => throw new NotImplementedException();// { get; }

        public IUserRepository User { get; }

        public IScheduleRepository Schedule { get; }

        public IAssistanceLog AssistanceLog => throw new NotImplementedException();

        public IConfigurationRepository Configuration { get; }        
    }
}