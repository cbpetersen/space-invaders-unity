using UnityEngine;
using UnityEngine.UI;

public class Rank : MonoBehaviour
{
    private Text rankLabel;

    public void Start()
    {
        this.rankLabel = GetComponent<Text>();
    }

    public void UpdateRank(int rank)
    {
        this.rankLabel.text = string.Format("Rank: {0}", rank);
    }
}
