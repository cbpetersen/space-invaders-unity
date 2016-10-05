using UnityEngine;

public class EnemySpaceshipScript : MonoBehaviour
{
    public static float enemyMoveSpeed = 4;
    public GameObject enemyLaser;
    public GameObject enemySpaceshipLight;
    public AudioClip[] audioclips;
    public Material[] materials;

    private bool dead = false;
    private float explodeTime = 0;
    private Transform mTransform;
    private Renderer renderer;

    void Start()
    {
        renderer = this.GetComponent<Renderer>();
        this.mTransform = transform;
        this.renderer.sharedMaterial = materials[0];
        this.enemySpaceshipLight = (GameObject)Instantiate(this.enemySpaceshipLight, new Vector3(-20, 8, -1.3f), Quaternion.AngleAxis(90, Vector3.up));
    }

    void Update()
    {
        if (this.dead)
        {
            if (Time.time > this.explodeTime)
            {
                Destroy(this.enemySpaceshipLight);
                Destroy(this.gameObject);
            }

            this.enemySpaceshipLight.GetComponent<Light>().intensity += 1;
            return;
        }

        mTransform.Translate(Vector3.forward * enemyMoveSpeed * Time.deltaTime);
        if (this.mTransform.position.x > 20)
        {
            Destroy(this.gameObject);
        }

        if (Random.Range(0, 200) == 1)
        {
            Instantiate(this.enemyLaser, this.mTransform.position, Quaternion.identity);
        }
    }

    public void Kill()
    {
        var audioSource = this.GetComponent<AudioSource>();
        audioSource.clip = audioclips[1];
        audioSource.Play();
        this.renderer.sharedMaterial = materials[1];
        this.dead = true;
        explodeTime = Time.time + 0.1f;
    }
}
