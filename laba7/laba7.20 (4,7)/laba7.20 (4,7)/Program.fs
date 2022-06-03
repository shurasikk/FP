// Learn more about F# at http://fsharp.org

open System

let getASCIICode x = 
    int x - int '0'

let rec readString n strings=
    match n with 
    |0 -> strings
    |_ -> 
        let s = Console.ReadLine()
        let newStrings = strings @ [s]
        let n1 = n - 1
        readString n1 newStrings

let rec writeList list= 
    List.iter (printfn "%s" ) list

let AverageWeight string = 
    let AverageAscii = List.average (List.map (fun x-> (double)(getASCIICode x)) (Seq.toList string))
    AverageAscii

let sortfirst (strings:'string list) =
    let firstStringWeight = AverageWeight strings.Head
    Console.WriteLine strings.Head
    let sorted = List.sortBy (fun x-> pown ((AverageWeight x) - firstStringWeight) 2) strings.Tail
    writeList (sorted)

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


[<EntryPoint>]
let main argv =
    let stringList = readString 3 []
    0 // return an integer exit code
