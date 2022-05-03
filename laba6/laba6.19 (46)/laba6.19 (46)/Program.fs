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

let PlusMinusList list predicate=
    let rec createlist list newlist=
        match list with
        |h::t->
            let newnewlist=
                if predicate h then newlist@[h]
                else newlist
            createlist t newnewlist
        |[]->newlist
    createlist list []
                    
[<EntryPoint>]
let main argv =
    let list=readData
    writeList(PlusMinusList list (fun x->x>0)@PlusMinusList list (fun x->x<0))
    0 // return an integer exit code
