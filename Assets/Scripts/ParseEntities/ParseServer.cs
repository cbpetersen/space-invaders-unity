using Parse;

public class ParseServer : Parse.ParseInitializeBehaviour
{
    public override void Awake()
    {
        ParseObject.RegisterSubclass<GameScore>();
        base.Awake();
    }
}
