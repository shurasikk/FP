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

let Maximum list=
    let rec m list max=
        match list with
        |[]->max
        |h::t->
            let newmax=if h>max then h else max
            let newlist=t
            m newlist newmax
    m list list.Head

let Maximum2 list max2=
    let rec m2 list max2 current_max =
        match list with
        | [] -> current_max
        | h::t ->
            let newmax = if (h > current_max && h<>max2) then h else current_max
            m2 t max2 newmax 
    m2 list max2 list.Head

let rec between_el list a b=
    match list with
        |h::t->
            match h with
            |_ when h=a->
                    let rec betin t newlist= 
                        match t with 
                        |h1::t1->
                            if h1=b then newlist
                            else 
                            let newnewlist=newlist @ [h1]
                            betin t1 newnewlist
                        |_->newlist
                    betin t []
            |_ when h=b -> 
                let rec betin t newlist= 
                    match t with 
                    |h1::t1->
                        if h1=a then newlist
                        else 
                        let newnewlist=newlist @ [h1]
                        betin t1 newnewlist
                    |_->newlist
                betin t []
        |_->[]


[<EntryPoint>]
let main argv =
    let list=readData
    writeList(between_el list (Maximum list) (Maximum2 list (Maximum list) ) )
    0 // return an integer exit code
