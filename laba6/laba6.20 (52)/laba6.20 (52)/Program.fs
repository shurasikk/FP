// Learn more about F# at http://fsharp.org

open System

let rec readList n = 
    if n=0 then []
    else
    let Head = System.Convert.ToInt32(System.Console.ReadLine())
    let Tail = readList (n-1)
    Head::Tail

let rec writeList = function
    [] ->   let z = System.Console.ReadKey()
            0
    | (head : int)::tail -> 
                       System.Console.WriteLine(head)
                       writeList tail

let prost x=
    let rec prost x i=
        match i with
        |_ when x=i->true
        |_ when x>i->
            if x%i=0 then false
            else prost x (i+1)
    prost x 2

let rec pow x y=
    match y with
    |0->1
    |_->x * (pow x (y-1))

let ProstDelList x=
    let rec makelist x del p newlist=
        match x with
        |_ when x>del->
            if prost del && x%del=0 then
                let newdel=pow del p
                if x>newdel && x%newdel=0 then
                    makelist x del (p+1) (newlist@[del])
                else makelist x (del+1) 1 newlist
            else makelist x (del+1) 1 newlist
        |_ when x=del->
            newlist
    makelist x 2 1 []


[<EntryPoint>]
let main argv =
    writeList (ProstDelList 18)
    writeList (ProstDelList 8)
    0 // return an integer exit code
