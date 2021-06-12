using EmployeeRecordsDomain.Entities;
using System.Collections.Generic;

namespace EmployeeRecordsRepository.Interfaces
{
    public interface IEmployeeRepository
    {
        long Create(Employee employee);
        IEnumerable<Employee> Retrieve();
    }
}
