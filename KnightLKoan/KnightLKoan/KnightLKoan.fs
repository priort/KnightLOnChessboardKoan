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
