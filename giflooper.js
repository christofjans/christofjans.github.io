function initClock() {
    const timeEl = document.getElementById("clock-time");
    const ampmEl = document.getElementById("clock-ampm");
    const dateEl = document.getElementById("clock-date");
    if (!timeEl || !ampmEl || !dateEl)
        return;
    const update = () => {
        const now = new Date();
        const timeStr = now.toLocaleTimeString("en-US", {
            hour: "2-digit",
            minute: "2-digit",
            hour12: true,
        });
        const match = timeStr.match(/(\d{2}:\d{2})\s*([AP]M)/);
        timeEl.textContent = match?.[1] ?? timeStr;
        ampmEl.textContent = match?.[2] ?? "";
        dateEl.textContent = new Intl.DateTimeFormat("en-US", {
            weekday: "long",
            month: "long",
            day: "numeric",
        }).format(now);
    };
    update();
    const now = new Date();
    const msToNextMinute = (60 - now.getSeconds()) * 1000 - now.getMilliseconds() + 25;
    setTimeout(() => {
        update();
        setInterval(update, 60_000);
    }, msToNextMinute);
}
function run() {
    initClock();
    const images = [
        "./octocat.gif",
        "./matrix-code.gif",
        //"./droid.gif",
        "./starwars.gif",
        "./gandalf.gif",
        "./controller.gif",
        "./pacman.gif",
        "./mancubus.gif",
        "./space-invaders.gif",
        "./spacemarine.gif",
        "./cat.gif",
        "./tintin.gif"
        //"./yin-and-yang.gif",
    ];
    const delayBetweenImages = 5000;
    let imgIndex = 0;
    setInterval(() => {
        imgIndex = (imgIndex + 1) % images.length;
        const img1 = document.getElementById("img1");
        const imgSrc = images[imgIndex];
        if (imgSrc) {
            img1.src = imgSrc;
        }
    }, delayBetweenImages);
}
export { run };
//# sourceMappingURL=giflooper.js.map