namespace EmployeeRecordsDomain.Dto
{
    public class EmployeeDto
    {
        public long Id { get; set; }//ToDo: identifier should not be recognizeable.
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
    }
}
