module KnightLKoanTest

open Expecto
open KnightLKoan

[<Tests>]
let tests =

  testList "" [
    test "shortest path for (1,1) knight to move is 4 moves" {
      Expect.equal <| KnightLKoan.shortestPath (1,1) 5 <| 4 <| ""
    }
    test "shortest path for (1,2) knight to move is 2 moves" {
      Expect.equal <| KnightLKoan.shortestPath (1,2) 5 <| 4 <| ""
    }
    test "shortest path for (1,3) knight to move is 2 moves" {
      Expect.equal <| KnightLKoan.shortestPath (1,3) 5 <| 2 <| ""
    }
    test "shortest path for (1,4) knight to move is 8 moves" {
      Expect.equal <| KnightLKoan.shortestPath (1,4) 5 <| 8 <| ""
    }
    
    test "shortest path for (2,1) knight to move is 4 moves" {
      Expect.equal <| KnightLKoan.shortestPath (2,1) 5 <| 4 <| ""
    }
    test "shortest path for (2,2) knight to move is 2 moves" {
      Expect.equal <| KnightLKoan.shortestPath (2,2) 5 <| 2 <| ""
    }
    test "shortest path for (2,3) knight to move is 4 moves" {
      Expect.equal <| KnightLKoan.shortestPath (2,3) 5 <| 4 <| ""
    }
    test "shortest path for (2,4) knight to move is 4 moves" {
      Expect.equal <| KnightLKoan.shortestPath (2,4) 5 <| 4 <| ""
    }
    
    test "shortest path for (3,1) knight to move is 4 moves" {
      Expect.equal <| KnightLKoan.shortestPath (3,1) 5 <| 2 <| ""
    }
    test "shortest path for (3,2) knight to move is 2 moves" {
      Expect.equal <| KnightLKoan.shortestPath (3,2) 5 <| 4 <| ""
    }
    test "shortest path for (3,3) knight to move is 4 moves" {
      Expect.equal <| KnightLKoan.shortestPath (3,3) 5 <| -1 <| ""
    }
    test "shortest path for (3,4) knight to move is 4 moves" {
      Expect.equal <| KnightLKoan.shortestPath (3,4) 5 <| -1 <| ""
    }

    test "shortest path for (4,1) knight to move is 4 moves" {
      Expect.equal <| KnightLKoan.shortestPath (4,1) 5 <| 8 <| ""
    }
    test "shortest path for (4,2) knight to move is 2 moves" {
      Expect.equal <| KnightLKoan.shortestPath (4,2) 5 <| 4 <| ""
    }
    test "shortest path for (4,3) knight to move is 4 moves" {
      Expect.equal <| KnightLKoan.shortestPath (4,3) 5 <| -1 <| ""
    }
    test "shortest path for (4,4) knight to move is 4 moves" {
      Expect.equal <| KnightLKoan.shortestPath (4,4) 5 <| 1 <| ""
    }
  ]

[<EntryPoint>]
let main args =
  runTestsInAssembly defaultConfig args

//expected output for 7
// 6 4 4 8 2 12
// 4 3 4 2 16 3
// 4 4 2 4 4 4
// 8 2 4 -1 -1 -1
// 2 16 4 -1 -1 -1
// 12 3 4 -1 -1 1

//expected output for board size 24
// 23 16 13 10 9 10 9 6 9 18 13 22 13 18 15 14 17 10 19 6 21 2 23
// 16 -1 10 -1 10 -1 6 -1 14 -1 14 -1 10 -1 26 -1 6 -1 38 -1 2 -1 -1
// 13 10 -1 10 7 -1 9 10 -1 20 11 -1 13 6 -1 26 19 -1 19 2 -1 -1 -1
// 10 -1 10 -1 10 -1 10 -1 6 -1 6 -1 18 -1 30 -1 18 -1 2 -1 -1 -1 -1
// 9 10 7 10 -1 6 7 6 13 -1 11 14 17 26 -1 14 21 2 -1 -1 -1 -1 -1
// 10 -1 -1 -1 6 -1 10 -1 -1 -1 22 -1 18 -1 -1 -1 2 -1 -1 -1 -1 -1 -1
// 9 6 9 10 7 10 -1 16 15 6 11 10 15 -1 19 2 55 -1 -1 -1 -1 -1 -1
// 6 -1 10 -1 6 -1 16 -1 14 -1 14 -1 22 -1 2 -1 -1 -1 -1 -1 -1 -1 -1
// 9 14 -1 6 13 -1 15 14 -1 10 17 -1 17 2 -1 -1 -1 -1 -1 -1 -1 -1 -1
// 18 -1 20 -1 -1 -1 6 -1 10 -1 6 -1 2 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1
// 13 14 11 6 11 22 11 14 17 6 -1 2 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1
// 22 -1 -1 -1 14 -1 10 -1 -1 -1 2 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1
// 13 10 13 18 17 18 15 22 17 2 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1
// 18 -1 6 -1 26 -1 -1 -1 2 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1
// 15 26 -1 30 -1 -1 19 2 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1
// 14 -1 26 -1 14 -1 2 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1
// 17 6 19 18 21 2 55 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1
// 10 -1 -1 -1 2 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1
// 19 38 19 2 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1
// 6 -1 2 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1
// 21 2 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1
// 2 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1
// 23 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 1


//expected for board size 17
// 16 12 8 8 6 8 4 4 8 12 10 20 6 28 2 32
// 12 8 8 6 8 4 14 4 16 6 16 12 16 2 16 16
// 8 8 -1 8 4 -1 6 4 -1 20 8 -1 2 28 -1 -1
// 8 6 8 4 8 6 8 4 8 8 8 2 8 8 8 8
// 6 8 4 8 -1 12 6 4 10 -1 2 68 16 -1 -1 -1
// 8 4 -1 6 12 -1 8 4 -1 2 -1 -1 -1 -1 -1 -1
// 4 14 6 8 6 8 -1 4 2 -1 -1 -1 -1 -1 -1 -1
// 4 4 4 4 4 4 4 2 4 4 4 4 4 4 4 4
// 8 16 -1 8 10 -1 2 4 -1 -1 -1 -1 -1 -1 -1 -1
// 12 6 20 8 -1 2 -1 4 -1 -1 -1 -1 -1 -1 -1 -1
// 10 16 8 8 2 -1 -1 4 -1 -1 -1 -1 -1 -1 -1 -1
// 20 12 -1 2 68 -1 -1 4 -1 -1 -1 -1 -1 -1 -1 -1
// 6 16 2 8 16 -1 -1 4 -1 -1 -1 -1 -1 -1 -1 -1
// 28 2 28 8 -1 -1 -1 4 -1 -1 -1 -1 -1 -1 -1 -1
// 2 16 -1 8 -1 -1 -1 4 -1 -1 -1 -1 -1 -1 -1 -1
// 32 16 -1 8 -1 -1 -1 4 -1 -1 -1 -1 -1 -1 -1 1
