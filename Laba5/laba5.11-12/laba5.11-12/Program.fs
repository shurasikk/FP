// Learn more about F# at http://fsharp.org

open System

let Check s =
    if (s="F#"||s="Prolog") then "Вы подлиза!"
    else "Спасибо за ответ!"

[<EntryPoint>]
let main argv =
    let Checking s =
        if (s="F#"||s="Prolog") then "Вы подлиза!"
        else "Спасибо за ответ!"
    Console.WriteLine("Пожалуйста, введите ваш любимый язык программирования:")
    (*суперпозиция*)
    let answer read check_func write=write(check_func(read()))
    answer  Console.ReadLine Checking Console.WriteLine
    (*каррирование*)
    //(Console.ReadLine>>Checking>>Console.WriteLine)()
    0
