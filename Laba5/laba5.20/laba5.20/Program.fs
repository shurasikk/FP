// Learn more about F# at http://fsharp.org

open System

let rec nod a b =
    match a with
    |_ when a<>0 && b <>0 ->
                        if a>b then nod (a%b) b 
                        else nod a (b%a)
    |_->
        a+b

let obhod_prost x predicate f init =
    let rec func x init number =
        match number with
        |1->init
        |_->
            let newinit = if predicate number=true && nod x number <> 1 then (f init) else init
            let newnumber = number - 1
            func x newinit newnumber
    func x init (x-1)

let max_max n predicate=
   let rec maximum n max=
       match n with
       |_ when n<=0->max
       |_ ->
           let newn=n/10
           let newmax=
               if n%10>max && predicate (n%10) then n%10
               else max
           maximum newn newmax
   maximum n 0

let rec sumcifr n predicate=
    match n with
    |0->0 
    |_->
        if (predicate (n%10)) = false then sumcifr (n/10) predicate
        else n%10+sumcifr (n/10) predicate

let obhod x f init =
    let rec func x f init number =
        if number = 1 then init
        else 
            let newinit = if nod x number = 1 then (f init number) else init
            let newnumber = number - 1
            func x f newinit newnumber
    func x f init (x-1)

let f3 n=
    let rec f33 n number=
        match number with 
        |1->number 
        |_->
            if (nod n number) <> 1 && number% (obhod n (fun x y-> min x y) 9) <> 0 then number
            else
            let newnum = number-1
            f33 n newnum
    f33 n (n-1)

let choose n y=
    match n with
    |1->obhod_prost y (fun x->x%2=0) (fun x->x+1) 0
    |2-> max_max y (fun x->x%3<>0)
    |3-> (fun x y->x*y) (f3 y) (sumcifr y (fun x->x<5))
    |_->0

[<EntryPoint>]
let main argv =
    let n=Convert.ToInt32(Console.ReadLine())
    let x=Convert.ToInt32(Console.ReadLine())
    //карирование 
    let answer choose n x write=write(choose n x)
    answer choose n x Console.WriteLine
    //суперпозиция
    choose n x|>Console.WriteLine
    0
