export function isUserLogged(value) {
    const userID = value

    if (userID == 0) {

        window.location.href = window.location.href.replace('/Perfil/Perfil', '/Sign/Sign')
    }
}