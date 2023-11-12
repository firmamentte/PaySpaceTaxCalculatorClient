
const createAnnualIncomeTax = () => {

    showPopupFormProgressBar()

    fetch("/TaxCalculation/CreateAnnualIncomeTax").
        then(handleError).
        then(htmlDataType).
        then((data) => {

            showPopupFormHtml(data)
        }).
        catch((error) => {
            showErrorPopupForm(error)
        })
}

const submitCreateAnnualIncomeTax = () => {

    const _messageCreateAnnualIncomeTax = clearErrorMessageDiv((<HTMLDivElement>document.querySelector("#messageCreateAnnualIncomeTax")))

    validateCreateAnnualIncomeTax(_messageCreateAnnualIncomeTax)

    if (!isErrorMessageDivEmpty(_messageCreateAnnualIncomeTax)) {
        return
    }

    toggleButtonProgressBar(document.querySelector("#navCreateAnnualIncomeTax"), document.querySelector("#progressBarCreateAnnualIncomeTax"))

    fetch("/TaxCalculation/CreateAnnualIncomeTax", postOptions(serialize(document.querySelector("#formCreateAnnualIncomeTaxForm")))).
        then(handleError).
        then(htmlDataType).
        then((data) => {

            const _gvRowMessage = document.querySelector("#divAnnualIncomeTaxGrid .grid-view .gv-row-message")
            if (!!_gvRowMessage) {

                _gvRowMessage.remove()

                 document.querySelector("#divAnnualIncomeTaxGrid .grid-view").innerHTML = data
            }
            else {
                    document.querySelector("#divAnnualIncomeTaxGrid .grid-view").insertAdjacentHTML("afterbegin", data)
            }

            hidePopupForm()
        }).
        catch((error) => {
            showErrorPopupForm(error)
        })
}

function validateCreateAnnualIncomeTax(messageDiv: HTMLDivElement) {

    if (!(!!(<HTMLInputElement>document.querySelector("#PostalCode")).value.trim())) {
        appendErrorMessage(messageDiv, "Postal Code required")
    }

    const _annualIncome = (<HTMLInputElement>document.querySelector("#AnnualIncome")).value.trim()

    if (!(!!_annualIncome)) {
        appendErrorMessage(messageDiv, "Annual Income required")
    } else {

        if (isNaN(parseFloat(_annualIncome))) {
            appendErrorMessage(messageDiv, "Numeric Annual Income required")
        } else {
            if (parseFloat(_annualIncome) < 0) {
                appendErrorMessage(messageDiv, "Annual Income cannot be less than zero")
            }
        }
    }
}
