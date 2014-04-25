module MainApp

open System
open System.Windows
open System.Windows.Controls
open FSharpx
open SampleFSharpUI.MVVM.Model

type MainWindow = XAML<"MainWindow.xaml">

let _model = new DataModel()

let loadWindow() =
    let window = MainWindow()
   
    // Your awesome code goes here and you have strongly typed access to the XAML via "window"

    // 初期値
    _model.X <- 0
    _model.Y <- 0   
    _model.ANS <- 0
    window.button1.Click.Add( fun _ -> 
        // データバインドで設定
        _model.ANS <- _model.X + _model.Y 
    )
    window.Root.DataContext <- _model
    window.Root

[<STAThread>]
(new Application()).Run(loadWindow()) |> ignore