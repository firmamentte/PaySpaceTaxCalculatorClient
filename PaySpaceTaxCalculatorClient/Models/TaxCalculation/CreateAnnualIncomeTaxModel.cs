namespace PaySpaceTaxCalculatorClient.Models.TaxCalculation
{
    public class CreateAnnualIncomeTaxModel
    {
        public string? PostalCode { get; set; }
        public decimal AnnualIncome { get; set; }
    }
}
