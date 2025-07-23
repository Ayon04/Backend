using FluentValidation;
using HanaHRM.DTO;

namespace HanaHRM.Validation
{
    public class EmployeeDocumentDTOValidator : AbstractValidator<EmployeeDocumentDTO>
    {

        public EmployeeDocumentDTOValidator() {


            RuleFor(e => e.IdClient)
              .NotEmpty().WithMessage("Client Id is required.");
              
            RuleFor(e => e.IdEmployee)
              .NotEmpty().WithMessage("Employee Id is required.");
              
            RuleFor(e => e.DocumentName)
              .NotEmpty().WithMessage("Document Name is required.");
              
            RuleFor(e => e.FileName)
              .NotEmpty().WithMessage("File Name is required.");
              
            RuleFor(e => e.UploadDate)
              .NotEmpty().WithMessage("Uploaded Date is required.");

        }   
    }
}
