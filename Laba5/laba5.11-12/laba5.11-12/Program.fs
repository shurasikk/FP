// Learn more about F# at http://fsharp.org

open System

let Check s =
    if (s="F#"||s="Prolog") then "Вы подлиза!"
    else "Спасибо за ответ!"

[<EntryPoint>]
let main argv =
    Console.WriteLine("Пожалуйста, введите ваш любимый язык программирования:")
    let s=Console.ReadLine()
    Console.WriteLine(Check s)
    0
