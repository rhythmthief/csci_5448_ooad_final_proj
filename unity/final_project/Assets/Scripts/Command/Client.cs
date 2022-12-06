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
}