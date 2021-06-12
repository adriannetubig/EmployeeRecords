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

        public Result Update(EmployeeUpdateDto employeeUpdateDto)
        {
            if (employeeUpdateDto == null)
                return Result.Failure("EmployeeUpdateDto Required");

            var nameUpdateResult = Name.Update(employeeUpdateDto);
            if (nameUpdateResult.IsFailure)
                return Result.Failure(nameUpdateResult.Error);

            return Result.Success();
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
