using EmployeeRecordsDomain.Dto;
using EmployeeRecordsService.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

namespace EmployeeRecordsApi.Controllers.V1
{
    public sealed class EmployeesController : BaseV1Controller
    {
        private readonly IEmployeeService _iEmployeeService;

        public EmployeesController(IEmployeeService iEmployeeService)
        {
            if (iEmployeeService == null)
                throw new ArgumentNullException("IEmployeeService Required");

            _iEmployeeService = iEmployeeService;
        }

        [HttpPost]
        public IActionResult Create(EmployeeCreateDto employeeCreateDto)
        {
            var createResult = _iEmployeeService.Create(employeeCreateDto);

            if (createResult.IsFailure)
                return BadRequest(createResult.Error);
            else
                return new ObjectResult(createResult.Value)
                {
                    StatusCode = (int)HttpStatusCode.Created
                };
        }
    }
}
