namespace HanaHRM.DTO
{
    public class EmployeeDocumentDTO
    {
        public int IdClient { get; set; }
        public int Id { get; set; }
        public int IdEmployee { get; set; }

        public string DocumentName { get; set; }
        public string FileName { get; set; } 
        public string? UploadedFileExtention { get; set; }

        public DateTime UploadDate { get; set; }
        public DateTime? SetDate { get; set; }

        public string? CreatedBy { get; set; }
        public IFormFile? DocumentFile { get; set; }

    }
}
