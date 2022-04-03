// Learn more about F# at http://fsharp.org

open System

let Check s =
    if (s="F#"||s="Prolog") then "Вы подлиза!"
    else "Спасибо за ответ!"

[<EntryPoint>]
let main argv =
    let Checking s =
        match s with
        | "F#" | "Prolog"-> "Вы подлиза!"
        |_->"Спасибо за ответ!"
    Console.WriteLine("Пожалуйста, введите ваш любимый язык программирования:")
    (*каррирование*)
    let answer read check_func write=write(check_func(read()))
    answer  Console.ReadLine Checking Console.WriteLine
    (*суперпозиция*)
    (Console.ReadLine>>Checking>>Console.WriteLine)()
    0
