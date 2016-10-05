using System;
using System.Linq;

using UnityEngine;

public class Hiscore : MonoBehaviour
{
    public GUISkin guiskin;
    public GUISkin guiskinScoresLabelLeftAlign;
    public GUISkin guiskinScoresLabelRightAlign;
    public GUISkin guiskinPlayerScoresLabelLeftAlign;
    public GUISkin guiskinPlayerScoresLabelRightAlign;
    Vector2 scrollViewVector = Vector2.zero;
    bool player;
    float updateInterval = 5.0f;
    float lastUpdated = 0;
    bool firstView = true;
    float scrollstart = 0;

    private GameScore[] scores = new GameScore[0];

    void OnGUI()
    {
        if (Time.time > lastUpdated)
        {
            Db.GethighScoreList(this.OnGameScoresLoaded);
            lastUpdated = Time.time + updateInterval;
        }

        GUI.skin = guiskin;
        if (scores.Any())
        {
            scrollViewVector = GUI.BeginScrollView(new Rect(Screen.width / 2 - 200, Screen.height / 2 - 100, 500, 250), scrollViewVector, new Rect(0, 0, 400, scores.Length * 25));

            for (int i = 0; i < this.scores.Length; i++)
            {
                player = false;
                var gameScore = this.scores[i];

//                if (gameScore.Name == PlayerScore.playerName && gameScore.Score == PlayerScore.score)
//                {
//                    scrollstart = i * 25;
//                    if (firstView)
//                    {
//                        scrollViewVector.y = scrollstart - 125;
//                        firstView = false;
//                    }
//                    player = true;
//                }


                if (player)
                {
                    GUI.skin = guiskinPlayerScoresLabelLeftAlign;
                }
                else
                {
                    GUI.skin = guiskinScoresLabelLeftAlign;
                }

                GUI.Label(new Rect(0, 0 + i * 25, 400, 25), (i + 1) + ". ");
                if (player)
                {
                    GUI.skin = guiskinPlayerScoresLabelLeftAlign;
                }
                else
                {
                    GUI.skin = guiskinScoresLabelLeftAlign;
                }

                GUI.Label(new Rect(45, 0 + i * 25, 400, 25), gameScore.Name);
                if (player)
                {
                    GUI.skin = guiskinPlayerScoresLabelRightAlign;
                }
                else
                {
                    GUI.skin = guiskinScoresLabelRightAlign;
                }

                GUI.Label(new Rect(45, 0 + i * 25, 400, 25), gameScore.Score + "");
            }
            GUI.EndScrollView();
        }
        else
        {
            GUI.skin = guiskin;
            GUI.Label(new Rect(Screen.width / 2 - 250, Screen.height / 2 - 20, 500, 25), "Loading");
        }

        GUI.skin = guiskin;
        if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 + 160, 180, 25), "Main Menu"))
        {
            Application.LoadLevel(0);
        }
    }

    private void OnGameScoresLoaded(GameScore[] scores)
    {
        this.scores = scores;
    }

    void Update()
    {

    }
}
