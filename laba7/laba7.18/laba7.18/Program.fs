// Learn more about F# at http://fsharp.org

open System

let writeArray arr =
    Array.iter (printf "%d ") arr

let filter arr=
    Array.filter (fun x->x%3=0) arr

[<EntryPoint>]
let main argv =
    let arr=[|1; 2; 3; 4; 5; 6; 7; 8; 9; 10; 11; 12|]
    writeArray (filter arr)
    0 // return an integer exit code
