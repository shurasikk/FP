// Learn more about F# at http://fsharp.org

open System

let getASCIICode x = 
    int x - int '0'

let readString n =
    let rec readStringRec n strings=
        match n with 
        |0 -> strings
        |_ -> 
            let s = Console.ReadLine()
            let newStrings = strings @ [s]
            readStringRec (n-1) newStrings
    readStringRec n []

let rec writeList list= 
    List.iter (printfn "%s" ) list

let AverageWeight string = 
    let AverageAscii = List.average (List.map (fun x-> (double)(getASCIICode x)) (Seq.toList string))
    AverageAscii

let sortfirst (strings:'string list) =
    let firstStringWeight = AverageWeight strings.Head
    let sorted = List.sortBy (fun x-> pown ((AverageWeight x) - firstStringWeight) 2) strings.Tail
    sorted

let isVowel (x : char) =
    (x = 'а') || (x = 'и') || (x = 'е') || (x = 'ё') || (x = 'о') || (x = 'у') || (x = 'ы') || (x = 'э') || (x = 'ю') || (x = 'я') || (x = 'u') || (x = 'i') || (x = 'o')

let counts x y =
    if (isVowel (snd y)) && (not (isVowel (fst y))) then x + 1
        else if (isVowel (fst y)) && (not(isVowel(snd y))) then x - 1
                else x

let countSoch str =
    let pairList = Seq.pairwise str
    Seq.fold counts 0 pairList

let sortsecond (strings:'string list)=
    Seq.toList (Seq.sortBy countSoch strings)

let choose k stringList =
    match k with 
    |1 -> sortfirst stringList
    |2 -> sortsecond stringList
    |_ -> exit(0)

[<EntryPoint>]
let main argv =
    Console.WriteLine("Выберите задачу для решения и введите строку: \n Отсортировать строки в указанном порядке")
    Console.WriteLine("1 В порядке увеличения квадратичного отклонения среднего веса ASCII-кода символа строки от среднего веса ASCII-кода символа первой строки")
    Console.WriteLine("2 В порядке увеличения разницы между количеством сочетаний «гласная-согласная» и «согласная-гласная» в строке")
    let k =
        Convert.ToInt32(Console.ReadLine())
    let n = 
        Convert.ToInt32(Console.ReadLine())
    let stringList = 
        readString n
    let newList =
        choose k stringList
    writeList newList
    0 // return an integer exit code
