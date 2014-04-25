﻿module MainApp

open System
open System.Windows
open System.Windows.Controls
open FSharpx

type MainWindow = XAML<"MainWindow.xaml">

let loadWindow() =
   let window = MainWindow()
   
   // Your awesome code goes here and you have strongly typed access to the XAML via "window"
   
   // ボタンクリック時のイベント
   window.button1.Click.Add( fun _ -> 
    let x = Convert.ToInt32( window.text1.Text )
    let y = Convert.ToInt32( window.text2.Text )
    let ans = x + y
    window.text3.Text <- ans.ToString()
   )

   window.Root

[<STAThread>]
(new Application()).Run(loadWindow()) |> ignore