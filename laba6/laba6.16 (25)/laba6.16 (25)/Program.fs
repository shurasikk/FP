// Learn more about F# at http://fsharp.org

open System

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

let MaxInterval list a b= 
    let rec maxinterval list max = 
        match list with
        |[]->max
        |h::t-> 
            let newmax = 
                if h>max && h>a && h<b then h
                else max
            maxinterval t newmax
    maxinterval list a

[<EntryPoint>]
let main argv =
    let list=readData
    let a=Convert.ToInt32(Console.ReadLine())
    let b=Convert.ToInt32(Console.ReadLine())
    if a>b then Console.WriteLine("Ошибка")
    else Console.WriteLine(MaxInterval list a b)
    0 // return an integer exit code
