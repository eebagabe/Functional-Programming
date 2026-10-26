type RawCSVData = obj list list
type PreparedCSVData = string list list

type CSVExportStatus =
    | Pending of RawCSVData
    | Processing of PreparedCSVData
    | Success of string
    | Failure of RawCSVData

type CSVData =
    | Prepared of PreparedCSVData
    | Processed of string

type CSVStatusResult = string * CSVData

// Don't touch above this line


let prepare (data: RawCSVData) : PreparedCSVData = data |> List.map (List.map string)


let processData (preparedData: PreparedCSVData) =
    preparedData |> List.map (String.concat ",") |> String.concat "\n"


let getCsvStatus status : CSVStatusResult =
    match status with
    | Pending data -> "Pending...", Prepared(prepare data)
    | Processing data -> "Processing...", Processed(processData data)
    | Success data -> "Success!", Processed data
    | Failure data -> "Unknown error, retrying...", Processed(data |> prepare |> processData)
