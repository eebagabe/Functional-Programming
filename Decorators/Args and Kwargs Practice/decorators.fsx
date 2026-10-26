let configurePluginDecorator (func: Map<string, string> -> 'a) =
    fun (args: (string * string) list) -> func (Map args)
