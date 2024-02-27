using System.ComponentModel.DataAnnotations;
namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Domain
{
    public class DocumentType
    {
        public int DocumentTypeId { get; private set; }
        public string DocumentTypeDescription { get; private set; }

        public DocumentType(string documentTypeDescription, int documentTypeId)
        {
            DocumentTypeDescription = documentTypeDescription;
            DocumentTypeId = documentTypeId;

        }
    }
}