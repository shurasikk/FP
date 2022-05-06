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
let elem list i =
    let rec el list i count =
        match list with
        |[]->0
        |h::t->
            if i=count then h
            else
                el t i (count+1)
    el list i 1

let DelElem list n =
    let rec DelElem (list:'a list) n (curlist:'a list) curIdx  =
        if n = curIdx then curlist @ list.Tail
        else
            let newCurlist = curlist @ [list.Head]
            DelElem list.Tail n newCurlist (curIdx+1)
    DelElem list n [] 1

let findIndex list x =
    let rec FindIndex list x i =
        match list with
        |[]-> -1
        |h::t->
            if h=x then i 
            else
                FindIndex t x (i+1)
    FindIndex list x 1


let findMax list =
    let rec Max list max =
        match list with
        |[]->max
        |h::t->
            let newCur = if (h>max) then h else max
            let newList = if t<>[] then t else []
            Max newList newCur
    Max list list.Head

let findMin list =
    let rec rec_findMax list cur =
        match list with
        |[]->cur
        |h::t->
            let newCur = if (h<cur) then h else cur
            let newList = if t<>[] then t else []
            rec_findMax newList newCur
    rec_findMax list list.Head


let Have list x =
    let rec have list x =
        match list with
        |[]-> false
        |h::t->
            if (h=x) then true else have t x
    have list x


let revSort list =
    let rec recRevSort list curlist =
        match list with
        |[]->curlist
        |_->
            let max = findMax list
            let idxMax = findIndex list max
            let newList = DelElem list idxMax
            let newCurlist = curlist @ [max]
            recRevSort newList newCurlist
    recRevSort list []


let rec MakeList list min max curEl curList =
    if curEl = (max+1) then curList
    else 
        if (Have list curEl && Have curList (findIndex list curEl) = false) then 
            let idxEl = findIndex list curEl
            let newCurlist = [idxEl] @ curList
            
            MakeList list min max curEl newCurlist
        else
            MakeList list min max (curEl+1) curList
    

[<EntryPoint>]
let main argv =
    let list = readData
    let ans = MakeList list (findMin list) (findMax list) (findMin list) []
    Console.WriteLine("\n")
    writeList ans
    0 // return an integer exit code
