# Recursion Practice

In Doc2Doc, we have a search function to find the longest word in a document.

## Assignment

Complete the `findLongestWord` function without a loop. It accepts a string input, `document`, and returns the longest word in it.

1. [ ] Split the document into a list of words, then recur over that list with an inner `let rec` function that carries the current `longestWord` (starting as an empty string).
2. [ ] Check if the first word is longer than the current `longestWord`, then recur for the rest of the list.
   - Words with equal length to `longestWord` should be skipped.
3. [ ] When the list is empty (`[]`), return `longestWord`.

Assume that a "word" means a series of any consecutive non-whitespace characters. For example, `findLongestWord "How are you?"` should return the string `"you?"`.

Review the provided tests in `main_test.fsx` to see the expected behavior, including edge cases.

You can use [`.Split`](https://learn.microsoft.com/dotnet/api/system.string.split) with `StringSplitOptions.RemoveEmptyEntries` and `List.ofArray`.
Then match the list as `word :: rest` to get the first word and the rest of the list.
