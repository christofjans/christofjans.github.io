{"Author":"Christof Jans","PubDate":"2016-09-14T02:21:01.0706259Z","Title":"Loading TypeScript ES6 modules","CleanTitle":"loading_typescript_es6_modules"}

# Loading Typescript ES6 modules.

I like TypeScript and I like ES6 modules. Typescript has it's own module system but you are not obliged to use it. The future clearly belongs to ES6 modules. If you want to know more about ES6 modules [this](http://www.2ality.com/2014/09/es6-modules-final.html) is a good resource.

The problem is that many browser still don't support ES6 modules natively. In this blogpost I will simply document a simple solution that worked for me. I make no claim that it's the "best" solution.

The solution consists of 2 steps:

1. transpile TypeScript modules to amd
2. use RequireJS to load the compiled amd module.

#### 1. Transpile TypeScript modules to amd

While browsers may not yet support es6, TypeScript allows you to transpile the ES6 modules to another module system. Set your `module` to `amd` like so: 

```javascript
{
    "compilerOptions": {
        "target": "es6",
        "module": "amd"         // set module to amd
    }
}
```

#### 2. use RequireJS to load the compiled amd module.

Now we need a way to load the compiled `amd` modules in the browser. There are multiple solutions; the one I chose is [RequireJS](http://requirejs.org/). To load your module `main.js` from the browser, simply add this to your `.html` file:

```html
<script data-main="./main.js" src="./require.js"></script>
```

That's it. Hope this helps.