{"title":"Test","pubDate":"2013-07-14T20:17:14.908Z","author":"Christof Jans"}

# Test

This is a test post of my new "blog-engine". The world clearly does not have enough blog engines so I decided to write my own. It uses git, node.js and markdown on the client and is hosted on Amazon S3.

## Math

Math is awesome. I don't know if I'll be doing a lot of math blogging, but I would like to have the option. I'm using the awesome [MathJax](http://www.mathjax.org) library to render math.

This is inline math: $$\Delta =\sum_{i=1}^N w_i (x_i - \bar{x})^2$$ .  

This is a math paragraph:  

$$$\Delta =\sum_{i=1}^N w_i (x_i - \bar{x})^2$$$  

## Code 

For code styling I'm currently using [Highlight.js](http://softwaremaniacs.org/soft/highlight/en/) .

This is inline code: `console.log("Hello, world !");` .  

This is a code paragraph :

    
    // example of code paragraph
    
    var i;

    for (i=0;i<100;i++) {
        console.log(i);
    }
    

## Media

Image test:

<img src="beach.jpg" />

Youtube test:

<iframe width="560" height="315" src="http://www.youtube.com/embed/JrQ0qMRZ_1Q" frameborder="0" allowfullscreen></iframe>  

## misc

Quote test:

> Suppose you were an idiot and
> suppose you were a member of congress;
> but I repeat myself .
>
> Mark Twain

Javascript animation test:

<div data-ng-controller='controller' style="font-family:monospaced;background-color:lightgray">{{dateTime}}</div>

------

This is the end of this test post.  

<script type="text/javascript">
    var controller = function ($scope, $timeout) {
        var updateDate = function () {
            $scope.dateTime = (new Date()).toString();
            $timeout(updateDate, 300);
        };
        updateDate();
    };
</script>