// Learn more about F# at http://fsharp.org

open System

let checkPalindrome (str:string) =
    let charArray = str.ToCharArray()
    let revCharArray = Array.Reverse charArray
    let revString = (string)revCharArray
    match str with
    |_ when str=revString->true
    |_->false

let CountWords (str:string)=
    let strnew=str.Split(" ")
    let k=Array.length strnew
    k

let Differentcounts (str:string)=
    let arr_cifr=str.ToCharArray()
    let diff_arr=Array.distinct arr_cifr
    let k=Array.length diff_arr
    k

[<EntryPoint>]
let main argv =
    printfn "Hello World from F#!"
    0 // return an integer exit code
