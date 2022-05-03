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

let FindMin list (predicate:int->bool)=
    let rec find list min=
        match list with
        |h::t->
            let newmin=
                if h<min && predicate h then h
                else min
            find t newmin
        |[]->min
    find list list.Head

[<EntryPoint>]
let main argv =
    let list=readData
    let vyvod=
        if ( FindMin list (fun a->a%2=0) ) % 2=0 then Console.WriteLine( FindMin list (fun a->a%2=0) )
        else Console.WriteLine("Чётных элементов в списке нет.")
    0 // return an integer exit code
