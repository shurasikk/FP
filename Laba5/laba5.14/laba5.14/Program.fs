// Learn more about F# at http://fsharp.org

open System

let del n f init=
    let rec deletel n f init d=
        match d with
        |_ when n=d -> init
        |_->
            let newinit=
                if n%d=0 then f init d
                else init
            let newd=d+1
            deletel n f newinit newd
    deletel n f init 2
[<EntryPoint>]
let main argv=
    Console.WriteLine("Введите число: ")
    let n=Convert.ToInt32(Console.ReadLine())
    let sumd= del n (fun x y -> x + y) 0
    let mind = del n (fun x y->min x y) n
    Console.WriteLine(sumd)
    Console.WriteLine(mind)
    0
