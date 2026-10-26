# Sum Types

Remember when I said, "Pure function are my favorite part of functional programming"? Well, sum types are a close second.

A "sum" type is the opposite of a "product" type. This F# record is an example of a product type:

```fsharp
type Man = { StudiesFinance: bool; HasTrustFund: bool }
```

The total number of combinations a `Man` can have is `4`, the product of `2 * 2`:

| StudiesFinance | HasTrustFund |
| -------------- | ------------ |
| `true`         | `true`       |
| `true`         | `false`      |
| `false`        | `true`       |
| `false`        | `false`      |

If we add a third field, perhaps a `HasBlueEyes` boolean, the total number of possibilites multiplies again, to `8`!

| StudiesFinance | HasTrustFund | HasBlueEyes |
| -------------- | ------------ | ----------- |
| `true`         | `true`       | `true`      |
| `true`         | `true`       | `false`     |
| `true`         | `false`      | `true`      |
| `true`         | `false`      | `false`     |
| `false`        | `true`       | `true`      |
| `false`        | `true`       | `false`     |
| `false`        | `false`      | `true`      |
| `false`        | `false`      | `false`     |

But let's pretend that we live in a world where there are really only three types of people that our program cares about:

1. Dateable
2. Undateable
3. Maybe dateable

We can reduce the number of cases our code needs to handle by using a sum type with only 3 possible cases. In F# that's a [discriminated union](https://learn.microsoft.com/dotnet/fsharp/language-reference/discriminated-unions):

```fsharp
type Person =
    | Dateable of name: string
    | MaybeDateable of name: string
    | Undateable of name: string
```

Then we can use pattern matching to check which case a `Person` is:

```fsharp
let respondToText guyAtBar =
    match guyAtBar with
    | Dateable name -> $"Hey {name}, I'd love to go out with you!"
    | MaybeDateable name -> $"Hey {name}, I'm busy but let's hang out sometime later."
    | Undateable _ -> "Have you tried being rich?"
```

There is no "invalid person type" branch: a `Person` can only be one of these three cases, and the compiler warns if the `match` misses one.

## Sum Types vs. Product Types

A product type combines fields, while a sum type represents one of several alternatives. Each alternative can carry data, like the person's name. Unlike Python, **F# supports sum types natively**, and the compiler enforces them for us.

### Assignment

Whenever a document is parsed by Doc2Doc, it can either succeed or fail. In functional programming, we often represent errors as data (e.g., the `ParseError` case) rather than by raising exceptions, because exceptions are side effects.

**Complete the `MaybeParsed` union.**

- `Parsed` represents success. It should carry a `docName` string and a `text` string.
- `ParseError` represents failure. It should carry a `docName` string and an `err` string.

The test suite uses pattern matching to see if an error occurred based on the case.
