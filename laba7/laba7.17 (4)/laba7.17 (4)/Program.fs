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

let writethreeList list =
    let print x =
        match x with
        (s1, s2, s3) -> printf "(%d, %d, %d)\n" s1 s2 s3
    List.iter print list

let sortThree (x, y, z) =
    let list = [x; y; z]
    let sorted_list = List.sort list
    match sorted_list with
    |h1::h2::h3::t -> 
        (h1, h2, h3)
    |[]->exit(0) 
    

let Pifagor (x, y, z) =
    x*x + y*y = z*z 

let buildthree list=
    let l=List.allPairs list list
    let all=List.allPairs list l
    let makethree x  =
        let (a, b, c) = fst x, (fst (snd x)), (snd (snd x))
        (a, b, c)
    let sort = List.map sortThree (List.map makethree all)
    List.filter Pifagor (List.distinct sort)


[<EntryPoint>]
let main argv =
    //let list=[3!; 4!; 5!; 21!; 20!; 29!; 36; 11; 22]
    let list=readData
    let sortlist= buildthree list
    writethreeList (sortlist)
    0 // return an integer exit code
