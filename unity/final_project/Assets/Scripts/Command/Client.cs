public class Client
{
    Civilization civ;
    GameBoard gameBoard;

    public Client(GameBoard gameBoard_)
    {
        gameBoard = gameBoard_;
        civ = gameBoard_.getCiv(0);
    }

    public void spawnUnit(string type)
    {
        gameBoard.spawnUnit(civ, type);
    }

    public void moveUnit(GameBoard gameBoard, Unit fighter)
    {
        // TODO make do command pattern for unit movement
        // get a list of possible tiles to move to
        // list them somehow
        // move to the tile the player selected
        // if there are no possible moves, skip
        // fighter.move();
    }
}