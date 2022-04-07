// Learn more about F# at http://fsharp.org

open System

let rec nod a b =
    if a<>0 && b <>0 then 
                    if a>b then nod (a%b) b 
                    else nod a (b%a)
    else 
        a+b

let f1 n init=
    let rec f11 n init number=
        match number with 
        |1->init
        |_->
            let newinit = if (nod n number) <> 1 && n%2=0 then init+1 else init
            let newnum = number-1
            f11 n newinit newnum
    f11 n init (n-1)

[<EntryPoint>]
let main argv =
    let n=Convert.ToInt32(Console.ReadLine())
    Console.WriteLine("Количество четных чисел, не взаимно простых с данным: {0}", f1 n 0)
    0 // return an integer exit code
