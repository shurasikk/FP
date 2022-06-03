// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System.Drawing
open System.Windows.Forms
open System

let form = new Form(Width = 800, Height = 600,Visible=true,Text="F# Лаб 9.8")

let textbox1 = new TextBox(Left=0, Top=100, Width=200,Height=50)
let textbox2 = new TextBox(Left=0, Top=200, Width=200,Height=50)

let button1 = new Button(Text="Ввести список(через пробел)", Left=250, Top=100, Width=200,Height=50)
let button2 = new Button(Text="Сумма элементов в списке", Left=250, Top=200, Width=200,Height=50)

form.Controls.Add(textbox1)
form.Controls.Add(textbox2)
form.Controls.Add(button1)
form.Controls.Add(button2)

let mutable list = []

let click1 _ =
    let list1 = 
        textbox1.Text.Split(" ")
    let listANS: string list =
        Array.toList list1
    let listANSInt =
        List.map (fun x -> Convert.ToInt32((string)x)) listANS
    list<-listANSInt
    MessageBox.Show("СПИСОК СЧИТАН")|>ignore

let _ = button1.Click.Add(click1)


let getSum list = 
    let rec getSumRec list sum =
        match list with 
        |[] -> sum
        |H::T->
            let newSum = 
                sum + H
            getSumRec T newSum
    getSumRec list 0

let click2 _ =
    let sum = 
        getSum list
    textbox2.Text<-Convert.ToString(sum)

let _ = button2.Click.Add(click2)

do Application.Run(form)