using System;
using System.Collections;
using System.Linq;
using System.Threading;

using Parse;

using UnityEngine;

public class Db
{
    public delegate void HighScoreCallback(GameScore[] scores);
    public delegate void RankCallback(int rank);
    public delegate void SaveScoreCallback(string id);

    public static IEnumerator SaveScore(string name, int score, GameObject go, SaveScoreCallback callback)
    {
        var gameScore = ParseObject.Create<GameScore>();
        gameScore.Score = score;
        gameScore.Name = name;
        string id = null;
        var asyncTask = gameScore.SaveAsync()
            .ContinueWith(
            b =>
                {
                    id = gameScore.ObjectId;
                });
        yield return new WaitUntil(() => asyncTask.IsCompleted);

        callback(id);

    }

    public static IEnumerator GetRank(int score, RankCallback callback)
    {
        var task = new ParseQuery<GameScore>()
            .WhereGreaterThan("score", score)
            .CountAsync();

        yield return new WaitUntil(() => task.IsCompleted);

        callback(task.Result);
    }

    public static void GethighScoreList(HighScoreCallback callback)
    {
        new ParseQuery<GameScore>()
            .OrderByDescending("score")
            .Limit(25)
            .FindAsync()
            .ContinueWith(
                t =>
                    {
                        try
                        {
                            callback(t.Result.ToArray());
                        }
                        catch (Exception e)
                        {
                            Debug.LogException(e);
                        }
                    });
    }
}
