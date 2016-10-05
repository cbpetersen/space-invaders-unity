using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour {
    public static int score = 0;
    public static int scoreMultiplyer = 1;

    private Text scoreLabel;

    public void Start()
    {
        this.scoreLabel = GetComponent<Text>();
    }

    public void UpdateScore(string enemyTag)
    {
        switch (enemyTag)
        {
            case "EnemyTree":
                score += 20 * scoreMultiplyer;
                break;
            case "EnemyTwo":
                score += 30 * scoreMultiplyer;
                break;
            case "EnemyOne":
                score += 40 * scoreMultiplyer;
                break;
            case "EnemySpaceship":
                score += Random.Range(5, 20) * 10 * scoreMultiplyer;
                break;
            default:
                score += 10;
                break;
        }

        scoreLabel.text = string.Format("Score: {0}", score);
    }

    public void ResetScore()
    {
        score = 0;
        scoreMultiplyer = 1;

        scoreLabel.text = string.Format("Score: {0}", score);
    }

    public void ResetMultiplyer()
    {
        Debug.Log("resetMultipler");
        scoreMultiplyer = 1;
    }

    public void AddToMultipler()
    {
        scoreMultiplyer++;
    }
}
