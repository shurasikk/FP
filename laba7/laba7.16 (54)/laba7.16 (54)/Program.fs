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

let more3 list=
    List.map fst (List.filter (fun x -> (snd x) > 3) (List.countBy id list) )

[<EntryPoint>]
let main argv =
    let list=readData
    writeList (more3 list)
    0 // return an integer exit code
