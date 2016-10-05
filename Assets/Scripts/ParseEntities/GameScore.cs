using Parse;

[ParseClassName("gameScoreSpaceInvaders")]
public class GameScore : ParseObject
{
    [ParseFieldName("name")]
    public string Name
    {
        get
        {
            return GetProperty<string>("Name");
        }
        set
        {
            SetProperty(value, "Name");
        }
    }

    [ParseFieldName("score")]
    public int Score
    {
        get
        {
            return this.GetProperty<int>("Score");
        }
        set
        {
            SetProperty(value, "Score");
        }
    }
}
