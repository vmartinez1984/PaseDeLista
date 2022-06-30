using RollCall.Core.Entities;

namespace RollCall.Core.Interfaces.IRepositories
{
    public interface IRepository
    {
        public IAreaRepository Area { get; }

        public IEmployeeRepository Employee { get; }

        public ISecurityQuestionRepository SecurityQuestion { get; }

        public IUserRepository User { get; }

        public IScheduleRepository Schedule { get; }
        
        public IAssistanceLog AssistanceLog { get; }
    }

    public interface IBase01Repository<T> where T : class
    {
        Task<T> GetAsync(int id);
        Task<List<T>> GetAsync();
        Task<int> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }

    public interface IBase02Repository<T> where T : class
    {
        Task<T> GetAsync(int id);
        Task<int> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }

    public interface IBase03Repository<T> where T : class
    {

        Task<int> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }

    public interface IAreaRepository : IBase01Repository<AreaEntity> { }

    public interface IEmployeeRepository : IBase01Repository<EmployeeEntity>
    {
        Task<EmployeeEntity> GetAsync(string employeeNumber);

        Task<List<EmployeeEntity>> GetAsync(bool isActive = true);

        Task<int> CountAsync();
    }

    public interface IUserRepository : IBase01Repository<UserEntity>
    {
        Task<UserEntity> GetAsync(string email);
        Task<int> CountAsync();
    }

    public interface ISecurityQuestionRepository : IBase02Repository<SecurityQuestionEntity>
    {
        Task<List<SecurityQuestionEntity>> GetAllAsync(int employeeId);
    }

    public interface IScheduleRepository : IBase01Repository<ScheduleEntity> { }

    public interface IAssistanceLog
    {
        public Task AddAsync(AssistanceLogEntity entity);
    }
}