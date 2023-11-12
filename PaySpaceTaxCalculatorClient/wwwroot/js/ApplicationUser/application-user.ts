
const submitSignIn = () => {

    const _messageSignIn = clearErrorMessageDiv(document.querySelector("#messageSignIn"))

    validateSignIn(_messageSignIn)

    if (!isErrorMessageDivEmpty(_messageSignIn)) {
        return
    }

    toggleButtonProgressBar(document.querySelector("#navSignIn"), document.querySelector("#progressBarSignIn"))

    fetch("/ApplicationUser/SignIn", postOptions(serialize(document.querySelector("#formSignIn")))).
        then(handleError).
        then(jsonDataType).
        then((data) => {
            console.log(data.redirectToUrl)
            window.location.replace(data.redirectToUrl)
        }).
        catch((error) => {
            toggleButtonProgressBar(document.querySelector("#navSignIn"), document.querySelector("#progressBarSignIn"))
            showErrorPopupForm(error)
        })
}

const signUp = () => {

    showPopupFormProgressBar()

    fetch("/ApplicationUser/SignUp").
        then(handleError).
        then(htmlDataType).
        then((signUpResp) => {
            showPopupFormHtml(signUpResp)
        }).
        catch((error) => {
            showErrorPopupForm(error)
        })
}

const submitSignUp = () => {

    const _messageSignUp = clearErrorMessageDiv(document.querySelector("#messageSignUp"))

    validateSignUp(_messageSignUp);

    if (!isErrorMessageDivEmpty(_messageSignUp)) {
        return
    }

    toggleButtonProgressBar(document.querySelector("#navSignUp"), document.querySelector("#progressBarSignUp"))

    fetch("/ApplicationUser/SignUp", postOptions(serialize(document.querySelector("#formSignUp")))).
        then(handleError).
        then(htmlDataType).
        then((data) => {
            showPopupFormHtml(data)
        }).
        catch((error) => {
            showErrorPopupForm(error)
        })
}

function validateSignIn(messageDiv: HTMLDivElement) {

    if (!(!!(<HTMLInputElement>document.querySelector("#EmailAddress")).value.trim())) {
        appendErrorMessage(messageDiv, "Email Address required")
    }

    if (!(!!(<HTMLInputElement>document.querySelector("#UserPassword")).value.trim())) {
        appendErrorMessage(messageDiv, "Password required")
    }
}

function validateSignUp(messageDiv: HTMLDivElement) {

    const _emailAddress: HTMLInputElement = document.querySelector("#SignUpEmailAddress")

    if (!(!!_emailAddress.value.trim())) {
        appendErrorMessage(messageDiv, "Email Address required")
    }
    else {
        if (!isValidEmailAddress(_emailAddress.value.trim())) {
            appendErrorMessage(messageDiv, "Invalid Email Address")
        }
    }

    if (!(!!(<HTMLInputElement>document.querySelector("#SignUpUserPassword")).value.trim())) {
        appendErrorMessage(messageDiv, "Password required")
    }
}