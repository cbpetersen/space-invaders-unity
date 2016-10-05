using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static float enemyMoveDir = 1;
    public static float enemyMoveSpeed = 2;

    public float changeInterval = 0.33F;
    public Material[] materials;
    public int enemyType;
    public static bool moveDownwards = true;

    private float killtime = -1;
    private bool dead = false;
    private Transform mTransform;
    private Vector3 calc;

    public void SetEnemyType(int type)
    {
        switch (type)
        {
            case 4:
                enemyType = 0;
                tag = "EnemyOne";
                break;
            case 3:
                enemyType = 2;
                tag = "EnemyTwo";
                break;
            case 2:
                enemyType = 2;
                tag = "EnemyTwo";
                break;
            case 1:
                enemyType = 4;
                tag = "EnemyTree";
                break;
            case 0:
                enemyType = 4;
                tag = "EnemyTree";
                break;
        }
    }

    void Start()
    {
        mTransform = transform;
    }

    void Update()
    {
        calc = Vector3.back * enemyMoveSpeed * enemyMoveDir * Time.deltaTime;
        mTransform.Translate(calc);

        if (moveDownwards)
        {
            mTransform.Translate(Vector3.down * enemyMoveSpeed * 0.025f * Time.deltaTime);
        }

        this.SetMaterial();
    }

    void SetMaterial()
    {
        int index = (int)(Time.time / changeInterval);
        index = index % 2;
        if (dead)
        {
            if (Time.time > this.killtime)
            {
                Destroy(this.gameObject);
            }
        }
        else
        {
            GetComponent<Renderer>().sharedMaterial = materials[index + enemyType];
        }
    }

    public void Killed()
    {
        GetComponent<AudioSource>().Play();
        GetComponent<Collider>().isTrigger = false;
        dead = true;
        killtime = Time.time + 0.25f;
        GetComponent<Renderer>().sharedMaterial = materials[6];
    }
}
