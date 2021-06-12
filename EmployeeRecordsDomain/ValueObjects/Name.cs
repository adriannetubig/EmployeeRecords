using CSharpFunctionalExtensions;
using EmployeeRecordsDomain.Dto;

namespace EmployeeRecordsDomain.ValueObjects
{
    public class Name
    {
        public string First { get; private set; }
        public string Middle { get; private set; }
        public string Last { get; private set; }

        protected Name()
        {
        }

        private Name(string first, string middle, string last)
        {
            First = first;
            Last = last;

            if (!string.IsNullOrEmpty(middle))
                Middle = middle;
        }

        public static Result<Name> Create(EmployeeCreateDto employeeCreateDto)
        {
            if (employeeCreateDto == null)
                return Result.Failure<Name>("EmployeeCreateDto Required");
            if (string.IsNullOrEmpty(employeeCreateDto.FirstName))
                return Result.Failure<Name>("FirstName Required");
            if (string.IsNullOrEmpty(employeeCreateDto.FirstName))
                return Result.Failure<Name>("LastName Required");

            return new Name(employeeCreateDto.FirstName, employeeCreateDto.MiddleName, employeeCreateDto.LastName);
        }
    }
}
