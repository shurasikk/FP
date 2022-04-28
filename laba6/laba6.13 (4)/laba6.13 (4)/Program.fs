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
let findMax list=
    let rec findm list max index maxindex=
        match list with
        |h::t-> 
            let newindex=index+1
            let newmax=if h>max then h else max
            let newmaxindex=if h=newmax then newindex else maxindex
            let newlist=t
            findm newlist newmax newindex newmaxindex
        |[]->maxindex
    findm list list.Head 0 0
 
let DelElem list n =
    let rec recDelElem list n curlist curIdx  =
        match list with
        |h::t->
            if n = curIdx then curlist @ t
            else
                let newCurlist = curlist @ [list.Head]
                recDelElem t n newCurlist (curIdx+1)
        |[]->[]
    recDelElem list n [] 1

let ShowIndex list=
    let rec recshoww list i maxindex newlist=
        match list with
        |h::t->
            if i=maxindex then 
                        let newnewlist=newlist @ [i]
                        let novlist=DelElem list i
                        if novlist<>[] then recshoww novlist 1 (findMax novlist) newnewlist
                        else newnewlist
            else 
                recshoww list (i+1) maxindex newlist
        |_->newlist
    recshoww list 1 (findMax list) []

[<EntryPoint>]
let main argv =
    let list=readData
    Console.WriteLine(findMax list)
    Console.WriteLine(ShowIndex list)
    0 // return an integer exit code
