// Learn more about F# at http://fsharp.org

open System

let rec writeList list= 
    List.iter (printfn "%d" ) list

let isInteger (x : float32) =
    if x - (floor x) = 0.f then
        1
    else
        0

let checkList (list:float32 list) =
    let intfloatlist = List.map isInteger list
    let pairList = List.pairwise intfloatlist
    let rec checking list=
        match list with
        |h::t->
            if ((fst (h)=1 && snd(h)=0) || (fst(h)=0 && snd(h)=1)) then checking t
            else false
        |[]->true
    let p=checking pairList
    p

[<EntryPoint>]
let main argv =
    let list = 
        [1.f; 1.1f]
    if checkList list then Console.WriteLine("чередуются")
        else Console.WriteLine("не чередуются")
    0 // return an integer exit code
