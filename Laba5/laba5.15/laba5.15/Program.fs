// Learn more about F# at http://fsharp.org

open System

let rec nod a b =
    if a<>0 && b <>0 then 
                    if a>b then nod (a%b) b 
                    else nod a (b%a)
    else 
        a+b

let obhod x f init =
    let rec func x f init number =
        if number = 1 then init
        else 
            let newinit = if nod x number = 1 then (f init number) else init
            let newnumber = number - 1
            func x f newinit newnumber
    func x f init (x-1)

[<EntryPoint>]
let main argv =
    Console.WriteLine("Введите число: ")
    let n = System.Convert.ToInt32(System.Console.ReadLine())
    let res = obhod n (fun x y -> x*y) 1
    Console.WriteLine("Произведение взаимнопростых: {0} ", res)
    0 // return an integer exit code
