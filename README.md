# GamePlatform
1. Content
    * Moo Game
    * Mastermind Game
    * MSTest project

# Moo Game
Moo is a Mastermind-style game where the player must guess a randomly generated four-digit string with as few attempts as possible. The randomly generated string will always have four unique digits.
# How to Play
1. The player guesses a four-digit number.
2. The game responds with an answer in the form of B's and C's.
     * "B" means that a digit in the guess is correct and in the correct position.
     * "C" means that a digit in the guess is correct, but in the wrong position.
     * For example, "B" indicates that one digit in the guess is correct and in the correct position, but the player does not know which digit it is. ",CCC" indicates that three digits in the guess are correct but are in the wrong position. "BBBB" is the goal and ends the game.
3. The player continues to guess until they correctly guess the four-digit string.
  
The player can make guesses with non-unique digits if they choose, but the goal always has four unique digits.

# Mastermind Game
Unlike Moo Game, Mastermind has just seven possible digit values instead of ten. Additionally, the same digit can appear more than once in the randomly generated number.

# Leaderboard
After each game, the average number of guesses for all players is displayed in a leaderboard, sorted by the best average guess.
The game keeps track of the statistics of all games played in a file from which the leaderboard is calculated and displayed after each game.

# Gameplay
Comment out or remove this line from the controller to play real games:
_ui.PrintString($"For practice, number is: {_currentGame.DigitsToGuess}\n");
