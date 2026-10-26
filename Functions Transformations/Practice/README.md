# Function Transformations Practice

In Doc2Doc, users are asking for a filtering feature. They want a command that has dynamic options so that they can work as quickly as possible.

## Assignment

Complete the `getFilterCmd` function. It takes two functions as input, `filterOne` and `filterTwo`, and returns a function, `filterCmd`.

`filterCmd` should take as input a string `content` and an optional string `option: string option`.

1. [ ] When `option` is `None`, behave as if it were `Some "--one"` (F# functions have no default argument values, so `option` stands in for one).
2. [ ] Complete `filterCmd` so that it filters and returns the `content` according to the input `option`.
    1. [ ] If `--one`, use `filterOne`
    2. [ ] If `--two`, use `filterTwo`
    3. [ ] If `--three`, use `filterOne` first, then use `filterTwo`
    4. [ ] If another option is passed, fail with `failwith "invalid option"`
