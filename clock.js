export function runclock(canvasId) {
    var canvas = document.getElementById(canvasId);
    var ctx = canvas.getContext('2d');
    if (ctx === null) {
        console.error('unable to retrieve context');
    }
    else {
        setInterval(function () {
            drawClock(ctx);
        }, 200);
    }
}
function drawClock(ctx) {
    var now = new Date();
    var seconds = now.getSeconds();
    var minutes = now.getMinutes();
    var hours = now.getHours();
    minutes += seconds / 60;
    if (hours >= 12)
        hours -= 12;
    hours += minutes / 60;
    hours *= 5;
    ctx.resetTransform();
    ctx.clearRect(0, 0, 256, 256);
    drawNotches(ctx);
    drawArm(ctx, minutes, 5, 100, '#000000');
    drawArm(ctx, hours, 5, 70, '#000000');
    drawArm(ctx, seconds, 2, 120, '#ff0000');
}
function drawArm(ctx, seconds, width, height, fill) {
    ctx.fillStyle = fill;
    ctx.resetTransform();
    ctx.translate(128, 128);
    ctx.rotate(seconds * 2 * Math.PI / 60);
    ctx.fillRect(-width / 2, -height, width, height);
}
function drawNotches(ctx) {
    ctx.fillStyle = '#000000';
    for (var i = 0; i < 12; i++) {
        var angle = i * Math.PI / 6;
        ctx.resetTransform();
        ctx.translate(128, 128);
        ctx.rotate(angle);
        ctx.fillRect(-1, -128, 2, 5);
    }
}
