using FluentValidation;
using HanaHRM.DTO;


namespace HanaHRM.Validation
{
    public class EmployeeDTOValidator : AbstractValidator<EmployeeDTO>
    {

        public EmployeeDTOValidator() {

           
            RuleFor(x => x.EmployeeName)
                .NotEmpty().WithMessage("Name is required.")
                .Matches("^[a-zA-Z .]*$")
                .WithMessage("Employee name must not contain special characters and Numbers.");

            RuleFor(x => x.IdDepartment)
                .NotEmpty().WithMessage("Department ID is required.");
                

        }
    }
}
