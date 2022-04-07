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

let f2 n=
    let rec f22 n max=
        match n with
        |_ when n<10->max
        |_ ->
            let newn=n/10
            let newmax=
                if n%10>max && n%3<>0 then n%10
                else max
            f22 newn newmax
    f22 n 0

let rec sumcifr n=
    match n with
    |0->0 
    |_->
        if n%10>=5 then sumcifr (n/10)
        else n%10+sumcifr (n/10)

let mind n=
    let rec minimumd n number=
        match number with
        |n->number
        |_->
            if n%number=0 then number
            else 
                let newnumber=number+1
                minimumd n newnumber
    minimumd n 2

let f3 n=
    let rec f33 n number=
        match number with 
        |1->number 
        |_->
            if (nod n number) <> 1 then number
            else
            let newnum = number-1
            f33 n newnum
    f33 n (n-1)

[<EntryPoint>]
let main argv =
    let n=Convert.ToInt32(Console.ReadLine())
    Console.WriteLine("Количество четных чисел, не взаимно простых с данным: {0}", f1 n 0)
    let x=Convert.ToInt32(Console.ReadLine())
    Console.WriteLine("Максимальная цифра числа, не делящаяся на 3: {0}", f2 x)
    let y=Convert.ToInt32(Console.ReadLine())
    Console.WriteLine("Произведение максимального числа, не взаимно простого
    с данным, не делящегося на наименьший делитель исходно числа, и
    суммы цифр числа, меньших 5: {0}", (f3 y)*(sumcifr y))
    0 // return an integer exit code
