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
    let dayOfWeekIdx = date.getDay();
    let dayOfMonth = date.getDate();
    let monthIdx = date.getMonth();
    let today = `${days[dayOfWeekIdx]}, ${months[monthIdx]} ${dayOfMonth}`;
    maindateWidget.innerHTML = today;
}
export function initUtcTimeWidget(utctimeid) {
    let utctimeWidget = document.getElementById(utctimeid);
    setInterval(function () {
        if (utctimeWidget === null)
            return;
        let date = new Date();
        let msg = `UTC ${padLeft(date.getUTCHours())}:${padLeft(date.getUTCMinutes())}`;
        utctimeWidget.innerHTML = msg;
    }, 400);
}
function padLeft(i) {
    return i < 10 ? `0${i}` : `${i}`;
}
const days = [
    "Sunday",
    "Monday",
    "Tuesday",
    "Wednesday",
    "Thursday",
    "Friday",
    "Saturday"
];
const months = [
    "January",
    "February",
    "March",
    "April",
    "May",
    "June",
    "July",
    "August",
    "September",
    "October",
    "November",
    "December"
];
