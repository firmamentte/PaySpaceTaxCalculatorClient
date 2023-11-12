const showErrorPopupForm = (error: string) => {

    fetch(`/Shared/Ok?okMessage=${error}&messageSymbol=x`).
        then(handleError).
        then(htmlDataType).
        then((data) => {
            showPopupFormHtml(data)
        }).
        catch((error) => {
            console.log(error)
        })
}

const userAccountMenu = () => {

    showPopupFormProgressBar()

    fetch("/Shared/UserAccount").
        then(handleError).
        then(htmlDataType).
        then((data) => {
            showPopupFormHtml(data)
        }).
        catch((error) => {
            showErrorPopupForm(error)
        })
}

const signOut = () => {
    window.location.assign("/ApplicationUser/UserSignOut")
}

const gridViewMessage = (message) => {
    return `<div class="gv-row-message">
            <span class="gv-message-value">${message}</span>
            </div>`
}
