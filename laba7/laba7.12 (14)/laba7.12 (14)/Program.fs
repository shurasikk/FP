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

let Count list a b=
    List.fold(fun k x->if x>=a && x<=b then k+1 else k) 0 list

[<EntryPoint>]
let main argv =
    let list=readData
    let a=Convert.ToInt32(Console.ReadLine())
    let b=Convert.ToInt32(Console.ReadLine())
    Console.WriteLine(Count list a b)
    0 // return an integer exit code
