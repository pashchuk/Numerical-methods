open System
open System.IO
open System.Windows.Forms


type row = float list * float

[<STAThread>]
[<EntryPoint>]
let main argv =
    
    let dialog = new OpenFileDialog()
    dialog.ShowDialog() |> ignore
    let data = 
        try 
            dialog.FileName 
            |> File.ReadAllLines 
            |> Array.map (fun x -> x.Split ' ') 
            |> Array.map (fun x -> x |> Array.map Double.Parse)
        with _ as err -> failwith err.Message
    for row in 0..text.Length-1 do
        let index = 
    printfn "%A" argv
    Console.ReadLine()
    0 // return an integer exit code
