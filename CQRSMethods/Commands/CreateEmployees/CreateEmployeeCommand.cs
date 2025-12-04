using MediatR;

namespace LearningCoreAPI.CQRSMethods.Commands.CreateEmployees
{
    public class CreateEmployeeCommand : IRequest<string>
    {
        public long Employeerollno { get; set; } = 123456;
        public string EmployeeName { get; set; } = "Test Name";
        public string EmployeeDepartment { get; set; } = "TestNameDpt";
        public string Email { get; set; } = "Testname@gmail.com";
        public string Password { get; set; } = "Test@123";
    }
}
