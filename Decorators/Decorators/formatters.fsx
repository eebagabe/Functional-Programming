#load "decorators.fsx"

open Decorators

let concat =
    markdownToTextDecorator (function
        | [ firstDoc; secondDoc ] -> $"  First: {firstDoc}\n  Second: {secondDoc}"
        | _ -> failwith "concat expects 2 documents")


let formatAsEssay =
    markdownToTextDecorator (function
        | [ title; body; conclusion ] -> $"  Title: {title}\n  Body: {body}\n  Conclusion: {conclusion}"
        | _ -> failwith "formatAsEssay expects 3 documents")
