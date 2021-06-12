using CSharpFunctionalExtensions;
using EmployeeRecordsDomain.Dto;
using EmployeeRecordsDomain.Entities;
using EmployeeRecordsRepository.Interfaces;
using EmployeeRecordsService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public IEnumerable<EmployeeDto> Retrieve()
        {

            var employees = _iEmployeeRepository.Retrieve();

            return employees
                .ToList()
                .Select(a =>
                new EmployeeDto
                {
                    Id = a.Id,
                    FirstName = a.Name.First,
                    MiddleName = a.Name.Middle,
                    LastName = a.Name.Last
                });
        }

        public Result Delete(long id)
        {
            var employee = _iEmployeeRepository.Retrieve(id);

            if (employee == null)
                return Result.Failure("Employee does not exists");

            _iEmployeeRepository.Delete(employee);

            return Result.Success();
        }
    }
}
