using LearningCoreAPI.Model;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace LearningCoreAPI.CQRSMethods.Commands.CreateEmployees
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, string>
    {
        private readonly UserManager<Bulk_EmployeesDetails> _userManager;

        public CreateEmployeeCommandHandler(UserManager<Bulk_EmployeesDetails> userManager)
        {
            _userManager = userManager;
        }

        public async Task<string> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = new Bulk_EmployeesDetails
            {
                Employeerollno = request.Employeerollno,
                EmployeeName = request.EmployeeName,
                EmployeeDepartment = request.EmployeeDepartment,
                UserName = request.Email,
                Email = request.Email
            };

            try
            {
                IdentityResult result = await _userManager.CreateAsync(employee, request.Password);

                if (result.Succeeded)
                {
                    return "Employee created successfully.";
                }
                else
                {
                    return "Failed to create employee: " + string.Join(", ", result.Errors.Select(e => e.Description));
                }
            }
            catch (Exception ex)
            {
                // Log the exception if needed
                return "An error occurred while creating the employee: " + ex.Message;
            }
        }

    }
}
