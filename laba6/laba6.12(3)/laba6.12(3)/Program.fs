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

let Maximum list=
    let rec m list max=
        match list with
        |[]->max
        |h::t->
            let newmax=if h>max then h else max
            let newlist=t
            m newlist newmax
    m list list.Head
 
let SearchInd list i max=
    let rec searching list i check=
        match list with
        |[]->check
        |h::t->
            if i<>1 then
                let newi=i-1
                let newlist=t
                searching newlist newi check
                else 
                    if h=max then check=true
                    else check=false
    searching list i true
[<EntryPoint>]
let main argv =
    let list=readData
    let max=Maximum list
    let n=Convert.ToInt32(Console.ReadLine())
    Console.WriteLine(SearchInd list n max)
    0
