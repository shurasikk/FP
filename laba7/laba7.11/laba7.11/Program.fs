// Learn more about F# at http://fsharp.org

open System

let rec readList n = 
    if n=0 then []
    else
    let Head = System.Convert.ToInt32(System.Console.ReadLine())
    let Tail = readList (n-1)
    Head::Tail

let readData = 
    let n=System.Convert.ToInt32(System.Console.ReadLine())
    readList n

let rec writeList = function
    [] ->   let z = System.Console.ReadKey()
            0
    | (head : int)::tail -> 
                       System.Console.WriteLine(head)
                       writeList tail

let index list=
    let ilist=List.indexed list
    let sort = List.sortByDescending snd ilist
    List.map fst sort


[<EntryPoint>]
let main argv =
    let list=readData
    writeList (index list)
    0 // return an integer exit code
