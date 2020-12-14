export function run(id) {
    var canvas = document.getElementById(id);
    if (canvas === null) {
        console.error('unable to retrieve canvas');
        return;
    }
    var ctx = canvas.getContext('2d');
    if (ctx === null) {
        console.error('unable to retrieve 2d canvas');
        return;
    }
    var centerX = 256;
    var centerY = 64;
    canvas.addEventListener('mousemove', function (e) {
        centerX = e.offsetX;
        centerY = e.offsetY;
    });
    var r = 0;
    setInterval(function () {
        draw(ctx, r, centerX, centerY);
        r += 0.005;
    }, 1);
}
function draw(ctx, r, centerX, centerY) {
    var squareSize = 32;
    var fourSize = 4 * squareSize;
    ctx.resetTransform();
    ctx.clearRect(0, 0, 1000, 1000);
    ctx.translate(centerX, centerY);
    ctx.rotate(r);
    ctx.fillStyle = '#000000';
    //ctx.fillRect(10, 10, 50, 50);
    for (var y = 0; y < 8; y++) {
        for (var x = 0; x < 8; x++) {
            var yIsOdd = y % 2;
            var xIsOdd = x % 2;
            if (yIsOdd === xIsOdd) {
                ctx.fillRect(x * squareSize - fourSize, y * squareSize - fourSize, squareSize, squareSize);
            }
        }
    }
}
