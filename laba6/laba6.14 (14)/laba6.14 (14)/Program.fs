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

let CountInInterval list a b=
    let rec count list k=
        match list with
        |[]->k
        |h::t->
            if h<b && h>a then 
                let newk=k+1
                let newlist=t
                count newlist newk
            else 
                let newlist=t
                count newlist k
    count list 0

[<EntryPoint>]
let main argv =
    let list=readData
    let a=Convert.ToInt32(Console.ReadLine())
    let b=Convert.ToInt32(Console.ReadLine())
    Console.WriteLine(CountInInterval list a b)
    0 // return an integer exit code
