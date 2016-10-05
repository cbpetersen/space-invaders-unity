using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    public GUISkin guiskin;
    float halfScreenWidth;
    float halfScreenheight;
    float labelwidth;
    float labelOffsetX;
    float buttonOffsetX;

    void OnGUI()
    {
        halfScreenWidth = Screen.width / 2;
        halfScreenheight = Screen.height / 2;
        buttonOffsetX = halfScreenWidth - 90;
        labelOffsetX = halfScreenWidth - 200;

        GUI.skin = guiskin;

        if (GUI.Button(new Rect(buttonOffsetX, halfScreenheight - 20, 180, 25), "Start game"))
        {
            Application.LoadLevel(2);
        }


        if (GUI.Button(new Rect(buttonOffsetX, halfScreenheight + 20, 180, 25), "High score"))
        {
            Application.LoadLevel(1);
        }

        GUI.Label(new Rect(labelOffsetX, halfScreenheight + 125, 400, 25), "Remake by");
        GUI.Label(new Rect(labelOffsetX, halfScreenheight + 150, 400, 25), "Christoffer Bo Petersen");
        if (GUI.Button(new Rect(halfScreenWidth - 140, halfScreenheight + 175, 280, 25), "Go to www.cb-p.dk"))
        {
            Application.ExternalEval("window.open('http://www.cb-p.dk','_blank')");
        }

    }
}
