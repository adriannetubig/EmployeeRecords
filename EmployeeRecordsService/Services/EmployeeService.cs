using CSharpFunctionalExtensions;
using EmployeeRecordsDomain.Dto;
using EmployeeRecordsDomain.Entities;
using EmployeeRecordsRepository.Interfaces;
using EmployeeRecordsService.Interfaces;
using System;

namespace EmployeeRecordsService.Services
{
    public sealed class EmployeeService: IEmployeeService
    {
        private readonly IEmployeeRepository _iEmployeeRepository;

        public EmployeeService(IEmployeeRepository iEmployeeRepository)
        {
            if (iEmployeeRepository == null)
                throw new ArgumentNullException("IEmployeeRepository Required");

            _iEmployeeRepository = iEmployeeRepository;
        }

        public Result<long> Create(EmployeeCreateDto employeeCreateDto)
        {
            var employeeResult = Employee.Create(employeeCreateDto);
            if (employeeResult.IsFailure)
                return Result.Failure<long>(employeeResult.Error);

            var employeeId = _iEmployeeRepository.Create(employeeResult.Value);

            return Result.Success(employeeId);
        }
    }
}
