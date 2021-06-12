using CSharpFunctionalExtensions;
using EmployeeRecordsDomain.Dto;
using System.Collections.Generic;

namespace EmployeeRecordsService.Interfaces
{
    public interface IEmployeeService
    {
        Result<long> Create(EmployeeCreateDto employeeCreateDto);
        IEnumerable<EmployeeDto> Retrieve();
        Result Update(long id, EmployeeUpdateDto employeeUpdateDto);
        Result Delete(long id);
    }
}
