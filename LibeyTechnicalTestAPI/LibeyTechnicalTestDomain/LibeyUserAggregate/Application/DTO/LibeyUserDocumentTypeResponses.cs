namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO
{
    public record LibeyUserDocumentTypeResponse
    {
        public string DocumentTypeDescription { get; init; }
        public int DocumentTypeId { get; init; }

    }
}