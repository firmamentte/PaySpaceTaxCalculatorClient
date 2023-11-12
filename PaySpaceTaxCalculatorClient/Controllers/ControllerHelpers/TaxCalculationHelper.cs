using PaySpaceTaxCalculatorClient.BLL.DataContract;
using PaySpaceTaxCalculatorClient.Models.TaxCalculation;

namespace PaySpaceTaxCalculatorClient.Controllers.ControllerHelpers
{
    public class TaxCalculationHelper
    {
        public List<AnnualIncomeTaxGridModel> FillAnnualIncomeTaxGridModel(List<AnnualIncomeTaxResp> annualIncomeTaxResps)
        {
            List<AnnualIncomeTaxGridModel> _model = new();

            annualIncomeTaxResps ??= new();

            foreach (var annualIncomeTaxResp in annualIncomeTaxResps)
            {
                _model.Add(new AnnualIncomeTaxGridModel()
                {
                    AnnualIncome = annualIncomeTaxResp.AnnualIncome,
                    AnnualIncomeTax = annualIncomeTaxResp.AnnualIncomeTax,
                    PostalCodeValue = annualIncomeTaxResp.PostalCodeValue,
                    CreationDate = annualIncomeTaxResp.CreationDate
                });
            }

            return _model;
        }

        public List<AnnualIncomeTaxGridModel> FillAnnualIncomeTaxGridModel(AnnualIncomeTaxResp annualIncomeTaxResp)
        {
            if (annualIncomeTaxResp is null)
                return new List<AnnualIncomeTaxGridModel>();

            return new List<AnnualIncomeTaxGridModel>()
            {
                new AnnualIncomeTaxGridModel()
                {
                    AnnualIncome = annualIncomeTaxResp.AnnualIncome,
                    AnnualIncomeTax = annualIncomeTaxResp.AnnualIncomeTax,
                    PostalCodeValue = annualIncomeTaxResp.PostalCodeValue,
                    CreationDate = annualIncomeTaxResp.CreationDate
                }
            };
        }
    }
}
