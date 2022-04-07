open System

let rec nod a b =
    match a with
    |_ when a<>0 && b <>0 ->
                        if a>b then nod (a%b) b 
                        else nod a (b%a)
    |_->
        a+b
//обход делителей с условием
let obhod_casual x predicate f init =
    let rec func x init number =
        match number with
        |1->init
        |_->
            let newinit = if predicate number=true && x%number=0 then (f init number) else init
            let newnumber = number - 1
            func x newinit newnumber
    func x init (x-1)

//обход взаимнопростых делителей с условием

let obhod_prost x predicate f init =
    let rec func x init number =
        match number with
        |1->init
        |_->
            let newinit = if predicate number=true && nod x number=1 then (f init number) else init
            let newnumber = number - 1
            func x newinit newnumber
    func x init (x-1)

[<EntryPoint>]
let main argv =
    Console.WriteLine("Введите число: ")
    let n = System.Convert.ToInt32(System.Console.ReadLine())
    Console.WriteLine("Произведение нечётных взаимнопростых: {0} ", obhod_prost n (fun x -> x%2=1) (fun x y -> x*y) 1)
    Console.WriteLine("Сумма чётных делителей числа:{0}", obhod_casual n (fun x -> x%2=0) (fun x y -> x + y) 0)
    0 // return an integer exit code