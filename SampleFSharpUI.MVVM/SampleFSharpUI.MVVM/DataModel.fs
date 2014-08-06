namespace SampleFSharpUI.MVVM.Model

open FSharp.ViewModule

type DataModel() as self =
    inherit ViewModelBase()

    // Backing fields
    let _x = self.Factory.Backing(<@ self.X @>, 10)
    let _y = self.Factory.Backing(<@ self.Y @>, 20)
    let _ans = self.Factory.Backing(<@ self.Answer @>, 30)

    // Command for logic
    let computeNewValue () =
        self.Answer <- self.X + self.Y
    let computeCommand = self.Factory.CommandSync(computeNewValue)

    // Bindable properties
    member __.X with get() = _x.Value and set(v) = _x.Value <- v
    member __.Y with get() = _y.Value and set(v) = _y.Value <- v
    member __.Answer with get() = _ans.Value and set(v) = _ans.Value <- v
    member __.Compute = computeCommand



// Alternative "model" which automatically computes itself - no need for pushing the button        
type AutomaticDataMode() as self =
    inherit ViewModelBase()

    let _x = self.Factory.Backing(<@ self.X @>, 10)
    let _y = self.Factory.Backing(<@ self.Y @>, 20)

    // This is only used to disable the button
    let computeCommand = self.Factory.CommandSyncChecked((fun _ -> ()), (fun _ -> false))

    do
        self.DependencyTracker.AddPropertyDependencies(<@@ self.Answer @@>, [ <@@ self.X @@> ; <@@ self.Y @@> ])

    member __.X with get() = _x.Value and set(v) = _x.Value <- v
    member __.Y with get() = _y.Value and set(v) = _y.Value <- v
    member this.Answer = this.X + this.Y
    member __.Compute = computeCommand
