var submitSignIn = function () {
    var _messageSignIn = clearErrorMessageDiv(document.querySelector("#messageSignIn"));
    validateSignIn(_messageSignIn);
    if (!isErrorMessageDivEmpty(_messageSignIn)) {
        return;
    }
    toggleButtonProgressBar(document.querySelector("#navSignIn"), document.querySelector("#progressBarSignIn"));
    fetch("/ApplicationUser/SignIn", postOptions(serialize(document.querySelector("#formSignIn")))).
        then(handleError).
        then(jsonDataType).
        then(function (data) {
        console.log(data.redirectToUrl);
        window.location.replace(data.redirectToUrl);
    }).
        catch(function (error) {
        toggleButtonProgressBar(document.querySelector("#navSignIn"), document.querySelector("#progressBarSignIn"));
        showErrorPopupForm(error);
    });
};
var signUp = function () {
    showPopupFormProgressBar();
    fetch("/ApplicationUser/SignUp").
        then(handleError).
        then(htmlDataType).
        then(function (signUpResp) {
        showPopupFormHtml(signUpResp);
    }).
        catch(function (error) {
        showErrorPopupForm(error);
    });
};
var submitSignUp = function () {
    var _messageSignUp = clearErrorMessageDiv(document.querySelector("#messageSignUp"));
    validateSignUp(_messageSignUp);
    if (!isErrorMessageDivEmpty(_messageSignUp)) {
        return;
    }
    toggleButtonProgressBar(document.querySelector("#navSignUp"), document.querySelector("#progressBarSignUp"));
    fetch("/ApplicationUser/SignUp", postOptions(serialize(document.querySelector("#formSignUp")))).
        then(handleError).
        then(htmlDataType).
        then(function (data) {
        showPopupFormHtml(data);
    }).
        catch(function (error) {
        showErrorPopupForm(error);
    });
};
function validateSignIn(messageDiv) {
    if (!(!!document.querySelector("#EmailAddress").value.trim())) {
        appendErrorMessage(messageDiv, "Email Address required");
    }
    if (!(!!document.querySelector("#UserPassword").value.trim())) {
        appendErrorMessage(messageDiv, "Password required");
    }
}
function validateSignUp(messageDiv) {
    var _emailAddress = document.querySelector("#SignUpEmailAddress");
    if (!(!!_emailAddress.value.trim())) {
        appendErrorMessage(messageDiv, "Email Address required");
    }
    else {
        if (!isValidEmailAddress(_emailAddress.value.trim())) {
            appendErrorMessage(messageDiv, "Invalid Email Address");
        }
    }
    if (!(!!document.querySelector("#SignUpUserPassword").value.trim())) {
        appendErrorMessage(messageDiv, "Password required");
    }
}
//# sourceMappingURL=application-user.js.map