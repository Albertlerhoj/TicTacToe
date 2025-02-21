namespace TicTacToeTest;

using NUnit.Framework;
using TicTacToe;
using TicTacToe.IO;


public class CursorTest {
    private Cursor cursor;

    [SetUp]
    public void Setup() {
        var keyToMoveMap = new KeyToMoveMap('i', 'k', 'j', 'l', 'q', ' ');
        cursor = new Cursor(3, keyToMoveMap);
        cursor.MoveDown();
        cursor.MoveRight();
    }

    [Test]
    public void CursorCenterTest() {
        Assert.True(cursor.position.X == 1 && cursor.position.Y == 1);
    }

    [Test]
    public void MoveUpTest() {
        //I assume X in the cursor.cs file is horizontal and Y is vertical. Moveup should be Y - 1
        int CurrentY = cursor.position.Y;
        cursor.MoveUp();
        if (cursor.position.Y != CurrentY - 1) {
            Assert.Fail("Cursor did not move up.");
        }
    }

    [Test]
    public void MoveDownTest() {
        int CurrentY = cursor.position.Y; 
        cursor.MoveDown();
        if (cursor.position.Y != CurrentY + 1) {
            Assert.Fail("Cursor did not move down.");
        }
    }
    
    [Test]
    public void MoveLeftTest() {
        int CurrentX = cursor.position.X;
        cursor.MoveLeft();
        if (cursor.position.X != CurrentX - 1) {
            Assert.Fail("Cursor did not move left.");
        }
    }

    [Test]
    public void MoveRightTest() {
        int CurrentX = cursor.position.X; 
        cursor.MoveRight();
        if (cursor.position.X != CurrentX + 1) {
            Assert.Fail("Cursor did not move right.");
        }
    }   
}
