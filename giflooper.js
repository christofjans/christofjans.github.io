export function run() {
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
        "./tintin.gif",
        //"./yin-and-yang.gif",
    ];
    const delayBetweenImages = 5000;
    let imgIndex = 0;
    setInterval(() => {
        imgIndex = (imgIndex + 1) % images.length;
        const img1 = document.getElementById("img1");
        img1.src = images[imgIndex];
    }, delayBetweenImages);
}
