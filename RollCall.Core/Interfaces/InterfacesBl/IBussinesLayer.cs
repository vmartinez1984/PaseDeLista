using RollCall.Core.Dtos.Inputs;
using RollCall.Core.Dtos.Outputs;

namespace RollCall.Core.Interfaces.InterfacesBl
{
    public interface IUnitOfWorkBl
    {
        public IAreaBl Area { get; }
        public ILoginBl Login { get; }
        public IScheduleBl Schedule { get; }

        public IUserBl User { get; }

        public IRoleBl Role { get; }
    }

    /// <summary>
    /// Donde T es la entrada y U la salida
    /// </summary>
    /// <typeparam name="T">Entrada</typeparam>
    /// <typeparam name="U">Salida</typeparam>
    public interface IBaseBl<T, U> where T : class
    {
        Task<int> AddAsync(T itemIn);
        Task DeleteAsync(int id);
        Task<U> GetAsync(int id);
        Task<List<U>> GetAsync();
        Task UpdateAsync(T itemIn, int id);
    }

    public interface IBase01Bl<T, U> where T : class
    {
        Task<int> AddAsync(T itemIn);
        Task DeleteAsync(int id);
        Task<List<U>> GetAsync();
        Task UpdateAsync(T itemIn, int id);
    }

    public interface IAreaBl : IBaseBl<AreaDtoIn, AreaDtoOut>
    {

    }

    public interface IEmployeeBl : IBaseBl<EmployeeDtoIn, EmployeeDto>
    {
        Task<EmployeeDto> GetAsync(string employeeNumber);
    }

    public interface ILoginBl
    {
        Task<UserDto> LoginAsync(UserLoginDto login);
    }

    public interface IScheduleBl : IBaseBl<ScheduleDtoIn, ScheduleDto> { }

    public interface IUserBl : IBaseBl<UserDtoIn, UserDto>
    {
        Task<bool> IsMaximum();
    }

    public interface IRoleBl
    {
        Task<List<RolDto>> GetAsync();
    }
}