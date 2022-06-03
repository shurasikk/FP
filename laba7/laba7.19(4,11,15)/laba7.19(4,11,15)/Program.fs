// Learn more about F# at http://fsharp.org

open System

let checkPalindrome (str:string) =
    let charArray = str.ToCharArray()
    let revCharArray = Array.Reverse charArray
    let revString = (string)revCharArray
    match str with
    |_ when str=revString->true
    |_->false

let CountWords (str:string)=
    let strnew=str.Split(" ")
    let k=Array.length strnew
    k

let Differentcounts (str:string)=
    let arr_cifr=str.ToCharArray()
    let diff_arr=Array.distinct arr_cifr
    let k=Array.length diff_arr
    k

let choosing k (str:string)=
    match k with
    |1->Console.WriteLine(checkPalindrome(str))
    |2->Console.WriteLine(CountWords(str))
    |3->Console.WriteLine(Differentcounts(str))
    |_->Console.WriteLine("Команды под данным номером не существует, нажмите 1,2 или 3")


[<EntryPoint>]
let main argv =
    let str=Console.ReadLine()
    Console.WriteLine("Нажмите цифру 1, 2 или 3 (1-является ли слово палиндромом, 2-количество слов, разделённых пробелом, 3-количество различных цифр числа")
    let k=Convert.ToInt32(Console.ReadLine())
    choosing k str
    0 // return an integer exit code
