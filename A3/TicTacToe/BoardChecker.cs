namespace TicTacToe;

using System;
using TicTacToe.Interfaces;


/// <summary>
/// A basic board checker that will determine if for a given row, diagonal or column, if all of
/// the elements is equal to eachother and not equal to null. It will also determine if the board
/// is in a tied position.
/// </summary>
public class BoardChecker : IBoardChecker {

    /// <summary>
    /// Method that is used to check if all elements in a row is equal to eachother and is not
    /// equal to null.
    /// </summary>
    /// <param name="board">A given board.</param>
    /// <returns>
    /// True if there is a win where all identifiers in the row is equal else false.
    /// </returns>
    private bool IsRowWin(Board board) {
        for (int row = 0; row < board.Size; row = row + 1) {
            var first = board.Get(row, 0);
            if (first.HasValue) {
                bool isWinningRow = true;
                for (int col = 1; col < board.Size; col = col + 1) {
                    if (board.Get(row, col) != first) {
                        isWinningRow = false;
                        break;
                    }
                }
                if (isWinningRow) return true;
            }
        }
        return false;
    }

    /// <summary>
    /// Method that is used to check if all elements in a column is equal to eachother and is not
    /// equal to null.
    /// </summary>
    /// <param name="board">A given board.</param>
    /// <returns>
    /// True if there is a win where all identifiers in the column is equal else false.
    /// </returns>
    private bool IsColWin(Board board) {
        for (int col = 0; col < board.Size; col = col + 1) {
            var first = board.Get(0, col);
            if (first.HasValue) { 
                bool isWinningCol = true;
                for (int row = 1; row < board.Size; row = row + 1) {
                    if (board.Get(row, col) != first) {
                        isWinningCol = false;
                        break;
                    }
                }
                if (isWinningCol) return true;
            }
        }
        return false;
    }

    /// <summary>
    /// Method that is used to check if all elements in a diagonal is equal to eachother and is not
    /// equal to null. This diagonal will always be the two longest in a square.
    /// </summary>
    /// <param name="board">A given board.</param>
    /// <returns>
    /// True if there is a win where all identifiers in the diagonal is equal else false.
    /// </returns>
    private bool IsDiagWin(Board board) {
        // Checking diagonal (top-left to bottom-right)
        var firstMainDiag = board.Get(0, 0);
        bool mainDiagWin = firstMainDiag.HasValue;
        for (int i = 1; i < board.Size; i = i + 1) {
            if (board.Get(i, i) != firstMainDiag) {
                mainDiagWin = false;
                break;
            }
        }

        // Checking invert-diagonal (top-right to bottom-left)
        var firstAntiDiag = board.Get(0, board.Size - 1);
        bool antiDiagWin = firstAntiDiag.HasValue;
        for (int i = 1; i < board.Size; i = i + 1) {
            if (board.Get(i, board.Size - 1 - i) != firstAntiDiag) {
                antiDiagWin = false;
                break;
            }
        }

        return mainDiagWin || antiDiagWin;
    }

    /// <summary>
    /// Method that will determine what the state of the board is. If there is a winner, a tied or
    /// the game is still inconclusive.
    /// </summary>
    /// <param name="board">A given board.</param>
    /// <returns> The state of the board.</returns>
    public BoardState CheckBoardState(Board board) {
        if (IsRowWin(board) || IsColWin(board) || IsDiagWin(board)) {
            return BoardState.Winner;
        }

        if (board.IsFull()) {
            return BoardState.Tied;
        }

        return BoardState.Inconclusive;
    } 
}