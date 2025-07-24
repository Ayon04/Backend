using FluentValidation;
using HanaHRM.DTO;
namespace HanaHRM.Validation
{
    public class EmployeeDTOValidator : AbstractValidator<EmployeeDTO>
    {

        public EmployeeDTOValidator() {

            RuleFor(e => e.EmployeeName)
                .NotEmpty().WithMessage("Name is required.")
                .Matches("^[a-zA-Z .]*$")
                .WithMessage("Employee name must not contain special characters and Numbers.");

            RuleFor(e=> e.IdDepartment)
                .NotEmpty().WithMessage("Department ID is required.");

            RuleFor(e => e.IdSection)
                .NotEmpty().WithMessage("Section ID is required.");

            RuleFor(e => e.EmpImg)
             
             .Must(file => file.Length > 10 * 1024 * 1024)
             .WithMessage("File Size Maximum 10 MB");


        }
    }
}
