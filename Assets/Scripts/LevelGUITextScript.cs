using UnityEngine;
using UnityEngine.UI;

public class LevelGUITextScript : MonoBehaviour
{
    public int level = 1;
    private Text levelText;

    void Start()
    {
        levelText = this.GetComponent<Text>();
    }

    void Update()
    {
        levelText.text = "Level: " + level;
    }

    public void SetLevel(int level)
    {
        this.level = level;
    }
}
