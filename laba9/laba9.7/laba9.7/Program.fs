// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System
open System
open System.Windows.Forms

let form = new Form(Width = 800, Height = 600,Visible=true,Text="F# Лаб 9.7")

let seasons = new ComboBox()
let button1 = new Button(Text="Время года", Left=0, Top=80, Width=150,Height=30)

let list = ["Январь"; "Февраль"; "Март"; "Апрель"; "Май"; "Июнь"; "Июль"; "Август"; "Сентябрь"; "Октябрь"; "Ноябрь"; "Декабрь"]
let array = List.toArray list

seasons.DataSource<-array

form.Controls.Add(seasons)
form.Controls.Add(button1)

let click _ =
    let x = seasons.Text
    match x with
    |"Январь"->MessageBox.Show("Зима")|>ignore
    |"Февраль"->MessageBox.Show("Зима")|>ignore
    |"Март"->MessageBox.Show("Весна")|>ignore
    |"Апрель"->MessageBox.Show("Весна")|>ignore
    |"Май"->MessageBox.Show("Весна")|>ignore
    |"Июнь"->MessageBox.Show("Лето")|>ignore
    |"Июль"->MessageBox.Show("Лето")|>ignore
    |"Август"->MessageBox.Show("Лето")|>ignore
    |"Сентябрь"->MessageBox.Show("Осень")|>ignore
    |"Октябрь"->MessageBox.Show("Осень")|>ignore
    |"Ноябрь"->MessageBox.Show("Осень")|>ignore
    |"Декабрь"->MessageBox.Show("Зима")|>ignore

let _ = button1.Click.Add(click)

do Application.Run(form)