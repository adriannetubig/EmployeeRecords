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

        [HttpGet]
        public IActionResult Retrieve()//Todo: Add paging
        {
            return Ok(_iEmployeeService.Retrieve());
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, EmployeeUpdateDto employeeUpdateDto)//Todo: Add different return code if employee does not exist
        {
            var deleteResult = _iEmployeeService.Update(id, employeeUpdateDto);

            if (deleteResult.IsFailure)
                return BadRequest(deleteResult.Error);
            else
                return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var deleteResult = _iEmployeeService.Delete(id);

            if (deleteResult.IsFailure)
                return NotFound(deleteResult.Error);
            else
                return NoContent();
        }
    }
}
