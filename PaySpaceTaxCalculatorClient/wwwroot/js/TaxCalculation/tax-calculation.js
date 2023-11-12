var createAnnualIncomeTax = function () {
    showPopupFormProgressBar();
    fetch("/TaxCalculation/CreateAnnualIncomeTax").
        then(handleError).
        then(htmlDataType).
        then(function (data) {
        showPopupFormHtml(data);
    }).
        catch(function (error) {
        showErrorPopupForm(error);
    });
};
var submitCreateAnnualIncomeTax = function () {
    var _messageCreateAnnualIncomeTax = clearErrorMessageDiv(document.querySelector("#messageCreateAnnualIncomeTax"));
    validateCreateAnnualIncomeTax(_messageCreateAnnualIncomeTax);
    if (!isErrorMessageDivEmpty(_messageCreateAnnualIncomeTax)) {
        return;
    }
    toggleButtonProgressBar(document.querySelector("#navCreateAnnualIncomeTax"), document.querySelector("#progressBarCreateAnnualIncomeTax"));
    fetch("/TaxCalculation/CreateAnnualIncomeTax", postOptions(serialize(document.querySelector("#formCreateAnnualIncomeTaxForm")))).
        then(handleError).
        then(htmlDataType).
        then(function (data) {
        var _gvRowMessage = document.querySelector("#divAnnualIncomeTaxGrid .grid-view .gv-row-message");
        if (!!_gvRowMessage) {
            _gvRowMessage.remove();
            document.querySelector("#divAnnualIncomeTaxGrid .grid-view").innerHTML = data;
        }
        else {
            document.querySelector("#divAnnualIncomeTaxGrid .grid-view").insertAdjacentHTML("afterbegin", data);
        }
        hidePopupForm();
    }).
        catch(function (error) {
        showErrorPopupForm(error);
    });
};
function validateCreateAnnualIncomeTax(messageDiv) {
    if (!(!!document.querySelector("#PostalCode").value.trim())) {
        appendErrorMessage(messageDiv, "Postal Code required");
    }
    var _annualIncome = document.querySelector("#AnnualIncome").value.trim();
    if (!(!!_annualIncome)) {
        appendErrorMessage(messageDiv, "Annual Income required");
    }
    else {
        if (isNaN(parseFloat(_annualIncome))) {
            appendErrorMessage(messageDiv, "Numeric Annual Income required");
        }
        else {
            if (parseFloat(_annualIncome) < 0) {
                appendErrorMessage(messageDiv, "Annual Income cannot be less than zero");
            }
        }
    }
}
//# sourceMappingURL=tax-calculation.js.map