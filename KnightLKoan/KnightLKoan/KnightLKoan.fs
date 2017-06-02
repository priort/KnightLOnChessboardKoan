module KnightLKoan

open System.Collections.Generic

type KnightLength = int * int
type KnightPosition = {
    Row: int
    Col: int
}
type Path = {
    Position : KnightPosition
    Moves : int
    PositionHistory : KnightPosition HashSet
}

let possibleMoves knightLength path boardSize = 

    let allMoves = seq {
        for a in [fst knightLength; -(fst knightLength)] do
        for b in [snd knightLength; -(snd knightLength)] do
            let newPosition = { Row = path.Position.Row + a; Col = path.Position.Col + b }
            yield { Position = newPosition
                    Moves = path.Moves + 1; PositionHistory = (path.PositionHistory.Add path.Position |> ignore; path.PositionHistory) }
            if (fst knightLength) <> (snd knightLength) then
                let newPositionOpp = { Col = path.Position.Col + a; Row = path.Position.Row + b }
                yield { Position = newPositionOpp 
                        Moves = path.Moves + 1; PositionHistory = (path.PositionHistory.Add path.Position |> ignore; path.PositionHistory) }
    }

    let withinBounds path = 
        path.Position.Row >= 0 && path.Position.Row < boardSize
        && path.Position.Col >= 0 && path.Position.Col < boardSize

    allMoves |> Seq.filter withinBounds

let shortestPath knightLength boardSize = 

    let eliminated = HashSet<KnightPosition>()

    let pathsToExplore = new LinkedList<Path>()
    pathsToExplore.AddLast( { Position = { Row = 0; Col = 0; }; Moves = 0; PositionHistory = HashSet() } ) |> ignore

    let rec explorePathsFurther() =
        if pathsToExplore.Count = 0 then -1
        else 
            let lastPath = pathsToExplore.First.Value
            if eliminated.Contains lastPath.Position |> not then
                eliminated.Add lastPath.Position |> ignore
                pathsToExplore.RemoveFirst()
                if lastPath.Position.Row = (boardSize - 1) && lastPath.Position.Col = (boardSize - 1) then
                    lastPath.Moves
                else
                    let nextPaths = possibleMoves knightLength lastPath boardSize |> Seq.filter (fun p -> lastPath.PositionHistory.Contains(p.Position) |> not)
                    for p in nextPaths do 
                        pathsToExplore.AddLast p |> ignore
                    explorePathsFurther()
            else 
                pathsToExplore.RemoveFirst()
                explorePathsFurther()
            
    explorePathsFurther()

[<EntryPoint>]
let main argv =
    let boardSize = System.Console.ReadLine() |> int
    let resultCache = Dictionary<int*int,int>()
    for a in 1 .. boardSize - 1 do
        for b in 1 .. boardSize - 1 do
            let present,res = resultCache.TryGetValue((b,a))
            if present then printf "%i " res
            else 
                let r = (shortestPath (a,b) boardSize)
                printf "%i " r
                resultCache.Add((a,b),r)
                 
        printfn "%s" ""
    0



// let rec shortestPathWithVisited knightLength boardSize currentPath (eliminated: HashSet<KnightPosition>) : int =
//     let furtherPaths = 
//         possibleMoves knightLength currentPath boardSize
//         |> Seq.filter (fun p -> currentPath.PositionHistory.Contains p.Position |> not)
//         // |> Seq.filter (fun p -> eliminated.Contains p.Position |> not)
//     if currentPath.Position.Row = (boardSize - 1) && currentPath.Position.Col = (boardSize - 1) then currentPath.Moves
//     else 
//         let candidates = 
//             seq {
//                 for p in furtherPaths -> shortestPathWithVisited knightLength boardSize p eliminated
//             }
//         // printfn "CANDIDATES %A" candidates
//         candidates
//         |> Seq.fold (fun shortestMoves moves -> 
//                 if moves <> -1 && (shortestMoves = -1 || moves < shortestMoves) then moves else shortestMoves) 
//            -1 
        

// let rec shortestPath knightLength boardSize =
//     let eliminated = new HashSet<KnightPosition>()
//     let shortest = 
//         shortestPathWithVisited knightLength boardSize { Position = { Row = 0; Col = 0; }; Moves = 0; PositionHistory = HashSet() } eliminated
//     // printfn "Shortest %A" shortest
//     shortest

// // let rec shortestPath knightLength boardSize = 
// //     let eliminated = new HashSet<KnightPosition>()

// //     let mutable shortest = -1

// //     let rec explorePathsFurther lastPath =
// //         // eliminated.Add(lastPath.Position) |> ignore 

// //         seq {
// //             if  lastPath.Position.Row = (boardSize - 1) 
// //                 && lastPath.Position.Col = (boardSize - 1)
// //                 && (shortest = -1 || lastPath.Moves < shortest) then
// //                 shortest <- lastPath.Moves
// //                 yield lastPath
// //             else 
// //                 let furtherPaths = 
// //                     possibleMoves knightLength lastPath boardSize
// //                     |> Seq.filter (fun p -> lastPath.PositionHistory |> Set.ofList |> Set.contains p.Position |> not)
            
// //                 for p in furtherPaths do 
// //                     if  eliminated.Contains p.Position |> not
// //                         && (shortest = -1 || p.Moves < shortest) then
// //                         yield! explorePathsFurther p 
// //         }

// //     explorePathsFurther { Position = { Row = 0; Col = 0; }; Moves = 0; PositionHistory = [] }
// //     |> Seq.sortBy (fun p -> p.Moves)
// //     |> Seq.tryHead |> Option.fold (fun _ p -> p.Moves) -1