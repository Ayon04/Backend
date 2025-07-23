using FluentValidation;
using HanaHRM.DTO;

namespace HanaHRM.Validation
{
    public class EmployeeProfessionalCertificationDTOValidator : AbstractValidator<EmployeeProfessionalCertificationDTO>
    {

        public EmployeeProfessionalCertificationDTOValidator() {

            RuleFor(e => e.IdClient)
              .NotEmpty().WithMessage("Client Id is required.");

            RuleFor(e => e.IdEmployee)
              .NotEmpty().WithMessage("Employee Id is required.");

            RuleFor(e => e.CertificationTitle)
             .NotEmpty().WithMessage("Certification  Title is required.");
           
            RuleFor(e => e.CertificationInstitute)
             .NotEmpty().WithMessage("Certification Institute is required.");

            RuleFor(e => e.InstituteLocation)
             .NotEmpty().WithMessage("Institute Locatione is required.");

            RuleFor(e => e.FromDate)
             .NotEmpty().WithMessage("From Date is required.");
        }

    }
}
