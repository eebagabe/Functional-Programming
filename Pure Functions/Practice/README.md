# Pure Functions Practice

Doc2Doc is customizable. New commands can be configured to use whichever function suits the user. However, the new commands are causing bugs in other parts of the application by mutating global values and other unintended side effects.

## Assignment

Make the following functions pure. With F#'s immutable `list` and `Map`, each one returns a new value instead of changing its input:

1. [ ] `addCustomCommand` returns a new commands map with the command added
2. [ ] `addFormat` returns a new formats list with the format appended
3. [ ] `saveDocument` returns a new documents map with the document saved
4. [ ] `addLineBreak` returns the line with `"\n\n"` appended, with no side effect (no printing)
