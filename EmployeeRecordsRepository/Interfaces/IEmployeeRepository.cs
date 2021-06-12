using EmployeeRecordsDomain.Entities;
using System.Collections.Generic;

namespace EmployeeRecordsRepository.Interfaces
{
    public interface IEmployeeRepository
    {
        long Create(Employee employee);
        Employee Retrieve(long id);
        IEnumerable<Employee> Retrieve();
        void Update(Employee employee);
        void Delete(Employee employee);
    }
}
