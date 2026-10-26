let defaultCommands<'T> : Map<string, 'T> = Map.empty
let defaultFormats = [ "txt"; "md"; "html" ]
let savedDocuments: Map<string, string> = Map.empty

let addCustomCommand commands newCommand func = Map.add newCommand func commands


let addFormat formats format = formats @ [ format ]


let saveDocument docs fileName doc = Map.add fileName doc docs


let addLineBreak line = line + "\n\n"
