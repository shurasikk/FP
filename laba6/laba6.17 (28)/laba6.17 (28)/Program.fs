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

let Maximumfirst list=
    let rec m list max index maxindex=
        match list with
        |[]->maxindex
        |h::t->
            let newmax=if h>max then h else max
            let newmaxindex=if h>max then index else maxindex
            m t newmax (index+1) newmaxindex
    m list list.Head 1 1

let Maximumlast list =
    let rec m list max index maxindex=
        match list with
        |[]->maxindex
        |h::t->
            let newmax=if h>=max then h else max
            let newmaxindex=if h>=max then index else maxindex
            m t newmax (index+1) newmaxindex
    m list list.Head 1 1

let Between_el list  = 
    let rec Createlistt list newlist ind1 ind2 i =
        match list with
        |h::t->
            if i = ind2 then newlist
            else 
            let newnewlist=
                if i > ind1 then newlist @ [h]
                else newlist
            Createlistt t newnewlist ind1 ind2 (i+1)
    Createlistt list [] (Maximumfirst list) (Maximumlast list) 1


[<EntryPoint>]
let main argv =
    let list=readData
    Console.WriteLine(Maximumfirst list)
    Console.WriteLine(Maximumlast list)
    writeList(Between_el list)
    0 // return an integer exit code
