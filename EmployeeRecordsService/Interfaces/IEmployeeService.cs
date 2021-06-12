using CSharpFunctionalExtensions;
using EmployeeRecordsDomain.Dto;
using EmployeeRecordsDomain.Entities;
using EmployeeRecordsRepository.Interfaces;
using System;

namespace EmployeeRecordsService.Interfaces
{
    public interface IEmployeeService
    {
        Result<long> Create(EmployeeCreateDto employeeCreateDto);
    }
}
