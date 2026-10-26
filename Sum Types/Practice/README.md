# Sum Types Practice

Doc2Doc should be able to prepare and export a CSV file of whatever data you input. CSV (Comma-Separated Values) is a ubiquitous text format that allows for information to be structured in a table. There is usually a header row, followed by data rows. Within rows, items are separated by commas.

## Assignment

Each status of the export is a case of the `CSVExportStatus` union, and each case carries the data for that step:

```fsharp
type CSVExportStatus =
    | Pending of RawCSVData // obj list list
    | Processing of PreparedCSVData // string list list
    | Success of string
    | Failure of RawCSVData
```

Complete the `getCsvStatus` function. It should use a `match` expression to select the correct response depending on the status of the export operation. It returns a `CSVStatusResult`: a tuple with a message and a `CSVData` (`Prepared` rows or a `Processed` CSV string). Create functions to handle each operation as follows:

1. [ ] `Pending`: return `"Pending..."` and the raw table data converted from a list of lists of anything to a prepared list of lists of strings (`Prepared`).
   1. [ ] Try to use nested `List.map` functions with `string` to convert the data items into strings.
2. [ ] `Processing`: return `"Processing..."` and the prepared list of lists of strings converted to one CSV-formatted string (`Processed`).
   1. [ ] For each list of strings, combine the strings with [`String.concat`](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-core-stringmodule.html#concat) with commas in between to form a row.
   2. [ ] Combine the rows with `String.concat` with newlines (`"\n"`) in between to form a table.
3. [ ] `Success`: return `"Success!"` and the data as-is.
4. [ ] `Failure`: return `"Unknown error, retrying..."` and the data after it's been prepared and processed into a CSV string, by combining the steps for `Pending` and `Processing`.

There is no "unknown status" case: the union only has these four cases, and the compiler checks that the `match` handles all of them.

> Tip: Try this challenge without loops. Pipelines (`|>`) and `List.map` are enough.
