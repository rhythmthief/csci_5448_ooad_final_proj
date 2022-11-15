public class GameSettings
{
    static GameSettings singleton = new GameSettings();
    string playerCivSelection;

    // hide default constructor
    private GameSettings() { }

    // get singleton instance
    public static GameSettings getGameSettings() => singleton;

    public void setPlayerCivSelection(string selection_) => playerCivSelection = selection_;

    public string getPlayerCivSelection() => playerCivSelection;
}