// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System
open System.Windows
open System.Windows.Markup
open System.Windows.Controls
open System.Windows.Media
open System.Windows.Media.Imaging

let mwXaml = " 
<Window 
 xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation'
 xmlns:x='http://schemas.microsoft.com/winfx/2006/xaml'
 Title='F# lab9.6' Height='1920' Width='1080'>
 <Grid>
        <Button x:Name='button1' Content='Mood while doing F#' HorizontalAlignment='Left' Margin='1200,600,0,0' VerticalAlignment='Top'/>
        <Image x:Name='Image1' HorizontalAlignment='Left' Height='1000' Margin='138,113,0,0' VerticalAlignment='Top' Width='1000'/>
 </Grid>
</Window>
" 

let getWindow(mwXaml) =
    let xamlObj=XamlReader.Parse(mwXaml)
    xamlObj :?> Window

let win = getWindow(mwXaml)

let button1 = win.FindName("button1") :?> Button
let image1 = win.FindName("Image1") :?> Image

let image1Path = new BitmapImage()
let image2Path = new BitmapImage()

image1Path.BeginInit()
image2Path.BeginInit()
image1Path.UriSource <- new Uri(@"C:\Users\Asus\Documents\GitHub\FP\laba9\laba9.6\laba9.6\cry.png")
image2Path.UriSource <- new Uri(@"C:\Users\Asus\Documents\GitHub\FP\laba9\laba9.6\laba9.6\happy.png")
image1Path.EndInit()
image2Path.EndInit()

image1.Source<-image1Path

let list = [image1Path;image2Path]
let mutable n = 0

button1.Click.Add(fun e ->
                      if n>1 then n<-1
                      n<-n+1
                      image1.Source<-List.item n list
                      )

[<STAThread>] ignore <| (new Application()).Run win 
