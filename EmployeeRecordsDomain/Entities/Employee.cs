using CSharpFunctionalExtensions;
using EmployeeRecordsDomain.Dto;
using EmployeeRecordsDomain.ValueObjects;

namespace EmployeeRecordsDomain.Entities
{
    public class Employee: Entity
    {
        public virtual Name Name { get; private set; }

        protected Employee()
        {
        }

        private Employee(Name name)
        {
            Name = name;
        }

        public static Result<Employee> Create(EmployeeCreateDto employeeCreateDto)
        {
            if (employeeCreateDto == null)
                return Result.Failure<Employee>("EmployeeCreateDto Required");

            var nameResult = Name.Create(employeeCreateDto);
            if(nameResult.IsFailure)
                return Result.Failure<Employee>(nameResult.Error);


            return Result.Success(new Employee(nameResult.Value));
        }
    }
}
