using EmployeeRecordsDomain.Entities;
using EmployeeRecordsRepository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeRecordsRepository.Repositories
{
    public sealed class EmployeeRepository: IEmployeeRepository
    {
        private readonly EmployeeRecordsContext _employeeRecordsContext;

        public EmployeeRepository(EmployeeRecordsContext employeeRecordsContext)
        {
            if (employeeRecordsContext == null)
                throw new ArgumentNullException("EmployeeRecordsContext Required");

            _employeeRecordsContext = employeeRecordsContext;
        }

        public long Create(Employee employee)
        {
            _employeeRecordsContext
                .Add(employee);

            _employeeRecordsContext
                .SaveChanges();

            _employeeRecordsContext
                .Entry(employee)
                .State = EntityState.Detached;

            return employee.Id;
        }

        public Employee Retrieve(long id)
        {
            return _employeeRecordsContext
                .Employees
                .Find(id);
        }

        public IEnumerable<Employee> Retrieve()
        {
            return _employeeRecordsContext
                .Employees
                .AsEnumerable();
        }

        public void Delete(Employee employee)
        {
            _employeeRecordsContext
                .Employees
                .Remove(employee);

            _employeeRecordsContext
                .SaveChanges();
        }
    }
}
