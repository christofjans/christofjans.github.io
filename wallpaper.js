export function initMainTimeWidget(maintimeid) {
    let maintimeWidget = document.getElementById(maintimeid);
    setInterval(function () {
        if (maintimeWidget === null)
            return;
        let date = new Date();
        let msg = `${padLeft(date.getHours())}:${padLeft(date.getMinutes())}`;
        maintimeWidget.innerHTML = msg;
    }, 400);
}
export function initMainDateWidget(maindateid) {
    let maindateWidget = document.getElementById(maindateid);
    if (maindateWidget === null)
        return;
    let date = new Date();
    var dd = padLeft(date.getDate());
    var mm = padLeft(date.getMonth() + 1); //January is 0!
    var yyyy = date.getFullYear();
    let today = `${yyyy}-${mm}-${dd}`;
    maindateWidget.innerHTML = today;
}
function padLeft(i) {
    return i < 10 ? `0${i}` : `${i}`;
}
