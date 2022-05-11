# TicTacToeKata
Like many game kata, it’s a good introduction to [double loop TDD](https://jmauerhan.wordpress.com/talks/double-loop-tdd-bdd-done-right/) or BDD.

## Rules
In random order

+ there are two players in the game (X and O)
+ x always plays first
+ players take turns taking fields until the game is over
+ Can,t play twice in the same position
+ a game has nine fields in a 3x3 grid
+ + a game is over when all fields in a row are taken by a player
+ a game is over when all fields in a diagonal are taken by a player
+ a game is over when all fields are taken
+ a game is over when all fields in a column are taken by a player
+ a player can take a field if not already taken

## Suggested Test Cases

Given this game board

```
+---+---+---+
| 1 | 2 | 3 |
+---+---+---+
| 4 | 5 | 6 |
+---+---+---+
| 7 | 8 | 9 |
+---+---+---+



And it's the turn of player X
When it play on cell 5
Then the board is now 

+---+---+---+
| 1 | 2 | 3 |
+---+---+---+
| 4 | X | 6 |
+---+---+---+
| 7 | 8 | 9 |
+---+---+---+

And it's not the end of game.
```
