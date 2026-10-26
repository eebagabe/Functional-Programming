# Currying Practice

Markdown makes [displaying images](https://www.markdownguide.org/basic-syntax/#images-1) as simple as possible. To add an image to a markdown document, just use this syntax:

```
![alt text](url "title")
```

- `alt text` a brief description for screen readers and web scrapers. Required for accessibility.
- `url` url or relative path to image.
- `title` shown on mouse hover. Optional.

## Assignment

Doc2Doc makes using markdown a breeze. This includes adding images to markdown documents.

Complete the `createMarkdownImage` function using currying. In F# every function with several parameters is already curried, so it takes `altText`, then `url`, then `title` one at a time.

1. [ ] Enclose the `altText` in square brackets prefixed with an exclamation point `![altText]`.
2. [ ] [Escape](https://en.wikipedia.org/wiki/Escape_sequence) any parentheses in the `url` by replacing them with [encoded sequences](https://www.url-encode-decode.com/).
   1. [ ] Use the `.Replace()` string method to change any opening parenthesis `(` into `%28`.
   2. [ ] Do the same to change any closing parenthesis `)` into `%29`.
3. [ ] Enclose the `url` with parentheses `(url)` and add it to the end of the enclosed `altText`: `![altText](url)`
4. [ ] The last parameter is an optional title, `title: string option`.
   1. [ ] If it is `Some title`, add the quoted `title` before the closing parenthesis: `![altText](url "title")`
   2. [ ] If it is `None`, return the image syntax without a title.

## Example

```fsharp
let sealImage = createMarkdownImage "seal" "https://imgur.com/oglPAXK"

sealImage (Some "this is a seal")
// ![seal](https://imgur.com/oglPAXK "this is a seal")

sealImage None
// ![seal](https://imgur.com/oglPAXK)
```
