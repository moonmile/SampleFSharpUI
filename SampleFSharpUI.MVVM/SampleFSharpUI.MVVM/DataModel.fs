namespace SampleFSharpUI.MVVM.Model

type DataModel() =
    inherit ViewModelBase()
    let mutable _X : int = 10
    let mutable _Y : int = 20
    let mutable _ANS : int = 30

    member this.X 
        with get() = _X
        and set(value) = 
            _X <- value
            base.OnPropertyChanged "X" 

    member this.Y
        with get() = _Y
        and set(value) = 
            _Y <- value
            base.OnPropertyChanged "Y" 

    member this.ANS
        with get() = _ANS
        and set(value) = 
            _ANS <- value
            base.OnPropertyChanged "ANS" 
        
