using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameoverScript : MonoBehaviour
{
    public void Display(bool show)
    {
        this.gameObject.SetActive(show);
    }

    public void SubmitScore()
    {
        var playerName = GameObject.Find("Name").GetComponent<InputField>().text;
        StartCoroutine(Db.SaveScore(playerName, Scoreboard.score, this.gameObject, loadHighScoreScene));
    }

    private void loadHighScoreScene(string id)
    {
        SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
    }
}
