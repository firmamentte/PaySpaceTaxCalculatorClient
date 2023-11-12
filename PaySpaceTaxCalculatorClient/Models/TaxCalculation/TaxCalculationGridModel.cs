namespace PaySpaceTaxCalculatorClient.Models.TaxCalculation
{
    public class AnnualIncomeTaxGridModel
    {
        public decimal AnnualIncome { get; set; } = decimal.Zero;
        public decimal AnnualIncomeTax { get; set; } = decimal.Zero;
        public string PostalCodeValue { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; }
    }
}
