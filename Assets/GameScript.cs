using UnityEngine;

public class GameScript : MonoBehaviour
{
    public GameObject Enemyprefab;
    public GameObject Remaininglivesprefab;
    public GameObject Player;
    public GameObject EnemyLaser;
    public GameObject EnemySpaceship;
    public GameObject Block;
    public GameObject Level;
    public GameObject Rank;
    public GameObject Gameover;

    GameObject[,] enemys;

    public GUISkin GuiskinLabelCenterAlign;
    public GUISkin GuiskinLabelLeftAlign;
    public GUISkin GuiskinLabelRightAlign;

    float xStartOffset = -10;
    float yStartOffset = 2f;
    static GameObject[] lives;
    public int Score = 0;
    public int ScoreMultiplyer = 1;
    private Scoreboard scoreboard;
    private LevelGUITextScript level;
    float enemykillCount = 0;
    float timesinceLastTurn = 0;
    float levelnr = 1;
    float laserchance = 0.7f;
    int enemyLaseractivity = 0;
    float rankUpdateInterval = 5.0f;
    float rankLastUpdated = 0;

    private Rank rank;

    private GameoverScript gameoverScript;

    void Start()
    {
        level = GameObject.Find("Level").GetComponent<LevelGUITextScript>();
        scoreboard = GameObject.Find("Score").GetComponent<Scoreboard>();
        rank = GameObject.Find("Rank").GetComponent<Rank>();
        gameoverScript = GameObject.Find("GameOverModal").GetComponent<GameoverScript>();

        this.NewGame();
    }

    void OnGui()
    {
        GUI.skin = this.GuiskinLabelLeftAlign;
        GUI.Label(new Rect(25, 15, 400, 25), "score: " + global::Scoreboard.score);
        GUI.skin = this.GuiskinLabelCenterAlign;
        GUI.Label(new Rect(Screen.width / 2 - 200, 15, 400, 25), "Level: " + levelnr);
        GUI.skin = this.GuiskinLabelRightAlign;
        GUI.Label(new Rect(Screen.width - 475, 15, 400, 25), "Rank: " + this.rank);
    }

    public void ResetMultiplier()
    {
        this.scoreboard.ResetMultiplyer();
    }

    public void AddToScore(string enemyTag)
    {
        enemykillCount++;
        if (enemykillCount % 20 == 19)
        {
            Instantiate(this.EnemySpaceship, new Vector3(-20, 8, 0), Quaternion.AngleAxis(90, Vector3.up));
        }

        this.scoreboard.UpdateScore(enemyTag);
    }

    void NewLevel()
    {
        laserchance += 0.1f;
        Enemy.enemyMoveSpeed += 0.5f;
        enemys = new GameObject[10, 5];
        Enemy.moveDownwards = true;
        enemykillCount = 0;
        for (int y = 0; y < 5; y++)
        {
            for (int x = 0; x < 10; x++)
            {
                enemys[x, y] = (GameObject)Instantiate(this.Enemyprefab, new Vector3(x * 1.3f + xStartOffset, y * 1.1f + yStartOffset, 0), Quaternion.AngleAxis(90, Vector3.up));
                enemys[x, y].GetComponent<Enemy>().SetEnemyType(y);
            }
        }
    }

    void NewGame()
    {
        laserchance = 0.7f;
        Enemy.enemyMoveSpeed = 2;
        global::Scoreboard.score = 0;
        global::Scoreboard.scoreMultiplyer = 1;
        scoreboard.ResetMultiplyer();
        level.SetLevel((int)levelnr);
        NewLevel();
        gameoverScript.Display(false);
        lives = new GameObject[3];
        lives[0] = (GameObject)Instantiate(this.Remaininglivesprefab, new Vector3(12, 9, -3), Quaternion.AngleAxis(90, Vector3.up));
        lives[1] = (GameObject)Instantiate(this.Remaininglivesprefab, new Vector3(12, 7.5f, -3), Quaternion.AngleAxis(90, Vector3.up));
        lives[2] = (GameObject)Instantiate(this.Remaininglivesprefab, new Vector3(12, 6, -3), Quaternion.AngleAxis(90, Vector3.up));
        Instantiate(this.Player, new Vector3(0, -9, 0), Quaternion.AngleAxis(180, Vector3.up));

        this.GenerateBlocks(-10f, -7.5f);
        this.GenerateBlocks(8f, -7.5f);
        this.GenerateBlocks(-5f, -7.5f);
        this.GenerateBlocks(3f, -7.5f);
    }

    void GenerateBlocks(float blockOffsetX, float blockOffsetY)
    {
        float size = 0.2f;

        Instantiate(this.Block, new Vector3(0 * size + blockOffsetX, 0 * size + blockOffsetY, 0), Quaternion.identity);
        Instantiate(this.Block, new Vector3(0 * size + blockOffsetX, 1 * size + blockOffsetY, 0), Quaternion.identity);

        Instantiate(this.Block, new Vector3(1 * size + blockOffsetX, 0 * size + blockOffsetY, 0), Quaternion.identity);
        Instantiate(this.Block, new Vector3(1 * size + blockOffsetX, 2 * size + blockOffsetY, 0), Quaternion.identity);

        Instantiate(this.Block, new Vector3(2 * size + blockOffsetX, 1 * size + blockOffsetY, 0), Quaternion.identity);
        Instantiate(this.Block, new Vector3(2 * size + blockOffsetX, 3 * size + blockOffsetY, 0), Quaternion.identity);

        Instantiate(this.Block, new Vector3(3 * size + blockOffsetX, 2 * size + blockOffsetY, 0), Quaternion.identity);
        Instantiate(this.Block, new Vector3(3 * size + blockOffsetX, 4 * size + blockOffsetY, 0), Quaternion.identity);

        Instantiate(this.Block, new Vector3(4 * size + blockOffsetX, 2 * size + blockOffsetY, 0), Quaternion.identity);
        Instantiate(this.Block, new Vector3(4 * size + blockOffsetX, 4 * size + blockOffsetY, 0), Quaternion.identity);

        Instantiate(this.Block, new Vector3(5 * size + blockOffsetX, 2 * size + blockOffsetY, 0), Quaternion.identity);
        Instantiate(this.Block, new Vector3(5 * size + blockOffsetX, 4 * size + blockOffsetY, 0), Quaternion.identity);

        Instantiate(this.Block, new Vector3(6 * size + blockOffsetX, 2 * size + blockOffsetY, 0), Quaternion.identity);
        Instantiate(this.Block, new Vector3(6 * size + blockOffsetX, 4 * size + blockOffsetY, 0), Quaternion.identity);

        Instantiate(this.Block, new Vector3(7 * size + blockOffsetX, 2 * size + blockOffsetY, 0), Quaternion.identity);
        Instantiate(this.Block, new Vector3(7 * size + blockOffsetX, 4 * size + blockOffsetY, 0), Quaternion.identity);

        Instantiate(this.Block, new Vector3(8 * size + blockOffsetX, 1 * size + blockOffsetY, 0), Quaternion.identity);
        Instantiate(this.Block, new Vector3(8 * size + blockOffsetX, 3 * size + blockOffsetY, 0), Quaternion.identity);
        Instantiate(this.Block, new Vector3(9 * size + blockOffsetX, 0 * size + blockOffsetY, 0), Quaternion.identity);
        Instantiate(this.Block, new Vector3(9 * size + blockOffsetX, 2 * size + blockOffsetY, 0), Quaternion.identity);
        Instantiate(this.Block, new Vector3(10 * size + blockOffsetX, 0 * size + blockOffsetY, 0), Quaternion.identity);
        Instantiate(this.Block, new Vector3(10 * size + blockOffsetX, 1 * size + blockOffsetY, 0), Quaternion.identity);
    }


    public void PlayerDied()
    {
        int livesLeft = 0;
        foreach (GameObject live in lives)
        {
            if (live != null)
            {
                livesLeft++;
            }
        }

        if (livesLeft == 0)
        {
            gameoverScript.Display(true);
        }
        else
        {
            Destroy(lives[livesLeft - 1]);
            Instantiate(this.Player, new Vector3(0, -9, 0), Quaternion.AngleAxis(180, Vector3.up));
        }
    }

    void Update()
    {
        int count = 0;
        foreach (GameObject go in enemys)
        {
            if (go != null && (go.transform.position.x > 11 || go.transform.position.x < -11) && Time.time > this.timesinceLastTurn)
            {
                this.timesinceLastTurn = Time.time + 1;
                {
                    Enemy.enemyMoveDir = Enemy.enemyMoveDir * -1;
                }
            }
            if (go != null && go.transform.position.y < -5.0f)
            {
                Enemy.moveDownwards = false;
            }


            if (Random.Range(0, enemyLaseractivity) == 1 && go != null)
            {
                Instantiate(this.EnemyLaser, go.transform.position, Quaternion.identity);
            }

            if (go != null && go.active)
            {
                count++;
            }
        }
        if (count == 0)
        {
            global::Scoreboard.scoreMultiplyer++;
            levelnr++;
            this.NewLevel();
        }

        enemyLaseractivity = (int)((count % 50) * 20 / laserchance);
        if (Time.time > rankLastUpdated)
        {
            rankLastUpdated = Time.time + rankUpdateInterval;
            StartCoroutine(
                Db.GetRank(
                    Scoreboard.score,
                    rank =>
                        {
                            this.rank.UpdateRank(rank);
                        }));
        }
    }
}
