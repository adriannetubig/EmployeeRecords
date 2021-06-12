using CSharpFunctionalExtensions;
using EmployeeRecordsDomain.Dto;
using System.Collections.Generic;

namespace EmployeeRecordsService.Interfaces
{
    public interface IEmployeeService
    {
        Result<long> Create(EmployeeCreateDto employeeCreateDto);
        IEnumerable<EmployeeDto> Retrieve();
        Result Delete(long id);
    }
}
