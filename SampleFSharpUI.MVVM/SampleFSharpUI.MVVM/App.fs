module MainApp

open System
open System.Windows
open System.Windows.Controls
open FsXaml
open SampleFSharpUI.MVVM.Model

type MainWindow = XAML<"MainWindow.xaml">

let _model = new DataModel()
let _automodel = new AutomaticDataMode()

let loadWindow() =
    let window = MainWindow().CreateRoot()
    
    window.DataContext <- _model
    
    // Uncomment to make window work without clicking the button
    // window.DataContext <- _automodel
    window
   
[<STAThread>]
(new Application()).Run(loadWindow()) |> ignore