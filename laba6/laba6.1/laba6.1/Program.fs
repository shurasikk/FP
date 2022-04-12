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


let rec change list f=
    match list with
    |a::b::c::t->(f a b c)::(change t f)
    |a::b::[]->(f a b 1)::(change [] f)
    |a::[]->(f a 1 1)::(change [] f)
    |[]->[]
 
[<EntryPoint>]
let main argv = 
    let list=readData
    Console.WriteLine(change list (fun x y z->x+y+z))
    0