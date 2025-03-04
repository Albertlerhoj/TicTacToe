namespace TicTacToeTest;

using NUnit.Framework;
using TicTacToe;

public class BoardCheckerTest {

    public Board board;
    public BoardChecker boardChecker;

    [SetUp]
    public void Setup() {
        board = new Board(3);
        boardChecker = new BoardChecker();
    }

    [Test]
    public void VerticalWinTest() {
        board.TryInsert(0, 2, PlayerIdentifier.Cross);
        board.TryInsert(1, 2, PlayerIdentifier.Cross);
        board.TryInsert(2, 2, PlayerIdentifier.Cross);

        Assert.AreEqual(BoardState.Winner, boardChecker.CheckBoardState(board));
    }

    [Test]
    public void HorizontalWinTest() {
        board.TryInsert(1, 0, PlayerIdentifier.Naught);
        board.TryInsert(1, 1, PlayerIdentifier.Naught);
        board.TryInsert(1, 2, PlayerIdentifier.Naught);

        Assert.AreEqual(BoardState.Winner, boardChecker.CheckBoardState(board));
    }
    
    [Test]
    public void DiagonalWinTest() {
        board.TryInsert(0, 0, PlayerIdentifier.Cross);
        board.TryInsert(1, 1, PlayerIdentifier.Cross);
        board.TryInsert(2, 2, PlayerIdentifier.Cross);

        Assert.AreEqual(BoardState.Winner, boardChecker.CheckBoardState(board));
    }

    [Test]
    public void DiagonalWinTest2() {
        board.TryInsert(2, 0, PlayerIdentifier.Cross);
        board.TryInsert(1, 1, PlayerIdentifier.Cross);
        board.TryInsert(0, 2, PlayerIdentifier.Cross);

        Assert.AreEqual(BoardState.Winner, boardChecker.CheckBoardState(board));
    }
    

    [Test]
    public void InconclusiveTest() {
        board.TryInsert(0, 0, PlayerIdentifier.Cross);

        Assert.AreEqual(BoardState.Inconclusive, boardChecker.CheckBoardState(board));
    }

    [Test]
    public void TiedTest() {
        board.TryInsert(1, 1, PlayerIdentifier.Cross); 
        board.TryInsert(0, 0, PlayerIdentifier.Naught); 
        board.TryInsert(0, 2, PlayerIdentifier.Cross); 
        board.TryInsert(2, 0, PlayerIdentifier.Naught); 
        board.TryInsert(1, 0, PlayerIdentifier.Cross);
        board.TryInsert(1, 2, PlayerIdentifier.Naught); 
        board.TryInsert(2, 1, PlayerIdentifier.Cross); 
        board.TryInsert(0, 1, PlayerIdentifier.Naught);
        board.TryInsert(2, 2, PlayerIdentifier.Cross);

        Assert.AreEqual(BoardState.Tied, boardChecker.CheckBoardState(board));
    }
}
