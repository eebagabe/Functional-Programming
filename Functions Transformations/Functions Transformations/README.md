# Function Transformations

"Function transformation" is just a more concise way to describe a specific type of [higher order function](https://en.wikipedia.org/wiki/Higher-order_function). It's when a function takes a function (or functions) as input and returns a _new_ function. Let's look at an example:

![](https://storage.googleapis.com/qvault-webapp-dynamic-assets/course_assets/qnibqWE-1280x448.png)

```fsharp
let multiply x y = x * y

let add x y = x + y

// selfMath is a higher order function
// input: a function that takes two arguments and returns a value
// output: a new function that takes one argument and returns a value
let selfMath mathFunc =
    fun x -> mathFunc x x

let squareFunc = selfMath multiply
let doubleFunc = selfMath add

printfn "%d" (squareFunc 5)
// prints 25

printfn "%d" (doubleFunc 5)
// prints 10
```

The `selfMath` function takes a function that operates on two _different_ parameters (e.g. `multiply` or `add`) and returns a new function that operates on _one_ parameter _twice_ (e.g. `square` or `double`).

## Assignment

Doc2Doc needs a good logging system so that users and developers alike can see what's going on under the hood. **Complete the `getLogger` function.**

It takes a `formatter` function as a parameter and returns _a new function_. Steps:

1. [ ] Return a new function, the `logger`, from `getLogger` (see `selfMath` above as an example). It accepts two strings. You can just name them `first` and `second` if you like.
2. [ ] The `logger` function should _not_ return a value (it returns `unit`). It should simply `printfn` the result of calling the given `formatter` function with the `first` and `second` strings as arguments.

## Tip

The `colonDelimit` and `dashDelimit` functions are "formatters" that will be passed into our `getLogger` function by the tests. You don't need to touch them, but it's important to understand that when you call `formatter` in the `getLogger` function, you're calling one of these functions.

Run it with `dotnet fsi main.fsx`.
