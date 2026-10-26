# Currying Practice

Doc2Doc should include a feature for image resizing, allowing users to adjust image dimensions to specified ranges. This ensures that images in documents fit and aren't freakishly large or hilariously small.

## Assignment

Complete the `newResizer` function using currying. It should make sure the image dimensions are never smaller than the minimum width and height, or larger than the maximum width and height specified.

Each step receives a tuple: `(maxWidth, maxHeight)`, then `(minWidth, minHeight)`, then `(width, height)`. Check the example at the bottom to see how it is intended to be called.

1. [ ] After receiving the maximum and minimum sizes:
   1. [ ] If `minWidth` is more than `maxWidth` or `minHeight` is more than `maxHeight`, fail with `failwith "minimum size cannot exceed maximum size"`.
   2. [ ] Return a function that takes `(width, height)`, and in its body:
      1. [ ] Use the built-in [`min`](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-core-operators.html#min) and [`max`](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-core-operators.html#max) functions to reduce `width` if it's above `maxWidth` or increase it if it's below `minWidth`.
      2. [ ] Do the same for `height`.
      3. [ ] Return the new `(width, height)` tuple.

The check must happen when the minimum size is applied, before any image is resized. That's why the function body runs the check and then returns a lambda.

## Example

If `newResizer` returns a `setMinSize` function, and `setMinSize` returns a `resizeImage` function, we would use it like this:

```fsharp
// Step 1: Create the resizer with maximum dimensions
let setMinSize = newResizer (800, 600)

// Step 2: Set the minimum dimensions
let resizeImage = setMinSize (200, 100)

// Step 3: Resize the image
let newWidth, newHeight = resizeImage (1000, 500)

// Step 4: Output the result
printfn "%d, %d" newWidth newHeight // Output: 800, 500

// All at once
printfn "%A" (newResizer (800, 600) (200, 100) (1000, 500)) // Output: (800, 500)
```

If there is no minimum, pass `(0, 0)`.
