module MainApp

open System
open System.Windows
open System.Windows.Controls
open FsXaml

type MainWindow = XAML<"MainWindow.xaml">

let loadWindow() =
   let window = MainWindow().CreateRoot()
   let accessor = MainWindow.Accessor(window)
   
   // Your awesome code goes here and you have strongly typed access to the XAML via "window"
   
   // ボタンクリック時のイベント
   accessor.button1.Click.Add( fun _ -> 
    let x = Convert.ToInt32( accessor.text1.Text )
    let y = Convert.ToInt32( accessor.text2.Text )
    let ans = x + y
    accessor.text3.Text <- ans.ToString()
   )

   window

[<STAThread>]
(new Application()).Run(loadWindow()) |> ignore