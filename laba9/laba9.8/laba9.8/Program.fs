// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System.Drawing
open System.Windows.Forms
open System

let form = new Form(Width = 800, Height = 600,Visible=true,Text="F# Лаб 9.8")

let textbox1 = new TextBox(Left=0, Top=100, Width=200,Height=50)
let textbox2 = new TextBox(Left=0, Top=200, Width=200,Height=50)

let button1 = new Button(Text="Ввести массив", Left=250, Top=100, Width=200,Height=50)
let button2 = new Button(Text="Элементы, которые делятся на 3 без остатка", Left=250, Top=200, Width=200,Height=50)

form.Controls.Add(textbox1)
form.Controls.Add(textbox2)
form.Controls.Add(button1)
form.Controls.Add(button2)

let array = [|1;2;3;4;5;6;7;8;9;10;11;12|]
let list = Array.toList array

let mass (list: int list) =
    let rec massRec (list: int list) (newList: string list) i= 
        match i with
        |0 -> newList
        |_ -> 
            let newI = i - 1
            let newNewList =
                newList@[Convert.ToString(list.Head)]
            let newNewNewList =
                newNewList@["  "]

            massRec list.Tail newNewNewList newI
    massRec list [] list.Length

let filt array =
    let newArray = Array.filter (fun x -> if x%3 = 0 then true else false) array
    newArray

let click1 _ =
    let nList = 
        mass list
    let arr =  List.toArray nList
    let str = System.String.Concat(arr)
    textbox1.Text<-str

let _ = button1.Click.Add(click1)

let click2 _ =
    let newArr = 
        filt array
    let newArrList =
        Array.toList newArr
    let nList = 
        mass newArrList
    let arr =  List.toArray nList
    let str = System.String.Concat(arr)
    textbox2.Text<-str

let _ = button2.Click.Add(click2)


do Application.Run(form)