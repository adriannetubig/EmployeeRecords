using EmployeeRecordsDomain.Entities;

namespace EmployeeRecordsRepository.Interfaces
{
    public interface IEmployeeRepository
    {
        long Create(Employee employee);
    }
}
