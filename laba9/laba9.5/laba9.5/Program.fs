// Learn more about F# at http://fsharp.org

open System
open System.Windows.Forms
open System.Drawing
open System.IO

let form = new Form(Width=800, Height = 600, Text = "F# lab9.5")
let picture1 = new PictureBox(SizeMode = PictureBoxSizeMode.AutoSize, Top = 0,Width=100,Height=100)
let button1 = new Button(Text="Mood while doing F#",Top=300,Width=200,Height=30,Left = 500)

let list = ["C:\Users\Asus\Documents\GitHub\FP\laba9\laba9.5\cry.png";"C:\Users\Asus\Documents\GitHub\FP\laba9\laba9.5\happy.png"]
let mutable n = 0
picture1.ImageLocation<-"C:\Users\Asus\Documents\GitHub\FP\laba9\laba9.5\cry.png"
form.Controls.Add(picture1)
form.Controls.Add(button1)

let ClickButton _ = 
    if n > 1 then n <- -1
    n<-n+1
    picture1.ImageLocation<-List.item n list

let _ = button1.Click.Add(ClickButton)


Application.Run(form)