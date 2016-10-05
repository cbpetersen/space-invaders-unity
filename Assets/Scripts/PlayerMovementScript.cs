using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{

    public float playerSpeed = 1;
    public GameObject laserPrefab;
    public float invincibleBlinkInterval = 0.33F;
    public Material[] materials;
    private bool alive = true;
    private float explodeTime = 0;
    private float revivalTime = 0;
    private GameScript gameScript;
    private bool invincible = true;
    private float invincibleTimer;
    private Renderer renderer;

    private void Start()
    {
        alive = true;
        invincibleTimer = Time.time + 2.0f;
        gameScript = FindObjectOfType<GameScript>();
        renderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        if (alive)
        {
            Vector3 v = Vector3.left * Input.GetAxisRaw("Horizontal") * Time.deltaTime * playerSpeed;

            if (v.x > 0)
            {
                if (transform.position.x > -12)
                    transform.Translate(v);
            }
            else if (v.x < 0)
            {
                if (transform.position.x < 12)
                    transform.Translate(v);
            }

            if (Input.GetKeyDown("space"))
            {
                Instantiate(laserPrefab, transform.position, Quaternion.identity);
            }

            if (invincible)
            {
                if (Time.time > invincibleTimer)
                {
                    gameObject.GetComponent<Collider>().isTrigger = true;
                    invincible = false;
                    renderer.sharedMaterial = materials[0];
                }
                else
                {
                    int index = (int)(Time.time / invincibleBlinkInterval);
                    index = index % 2;
                    if (index == 0)
                    {
                        renderer.sharedMaterial = materials[0];
                    }
                    else
                    {
                        renderer.sharedMaterial = materials[2];
                    }
                }
            }
        }
        else
        {
            if (Time.time > explodeTime)
            {
                renderer.sharedMaterial = materials[2];
            }
            if (Time.time > revivalTime)
            {
                gameScript.PlayerDied();
                Destroy(gameObject);
            }
        }
    }

    public void Killed()
    {
        GetComponent<AudioSource>().Play();
        alive = false;
        gameObject.GetComponent<Collider>().isTrigger = false;
        renderer.sharedMaterial = materials[1];
        explodeTime = Time.time + 0.5f;
        revivalTime = Time.time + 1.5f;
    }
}
