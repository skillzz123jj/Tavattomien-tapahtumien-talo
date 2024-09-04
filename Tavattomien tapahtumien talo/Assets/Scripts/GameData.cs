public class GameData
{
    private static GameData instance;

    public bool isAudioMuted { get; set; }
    public bool hintsEnabled { get; set; }

    private GameData() { }

    //Public method to access the instance
    public static GameData Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameData();
            }
            return instance;
        }
    }

}
