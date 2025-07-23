using FluentValidation;
using HanaHRM.DTO;

namespace HanaHRM.Validation
{
    public class EmployeeEducationInfoDTOValidator : AbstractValidator<EmployeeEducationInfoDTO>
    {

        public EmployeeEducationInfoDTOValidator() {

            RuleFor(e => e.IdClient)
              .NotEmpty().WithMessage("Client Id is required.");

            RuleFor(e => e.IdEmployee)
              .NotEmpty().WithMessage("Employee Id is required.");

            RuleFor(e => e.IdEducationLevel)
              .NotEmpty().WithMessage("Education Level is required.");

            RuleFor(e => e.IdEducationExamination)
              .NotEmpty().WithMessage("Education Examination is required.");

            RuleFor(e => e.IdEducationResult)
              .NotEmpty().WithMessage("Education Result is required.");

            RuleFor(e => e.Major)
              .NotEmpty().WithMessage("Major is required.");

            RuleFor(e => e.PassingYear)
              .NotEmpty().WithMessage("Passing Year is required.");

            RuleFor(e => e.InstituteName)
              .NotEmpty().WithMessage("Institute Name is required.");

            RuleFor(e => e.IsForeignInstitute)
              .NotEmpty().WithMessage("Foreign Institute is required.");

        } 
        
    }
}
