using UnityEngine;

public class LaserScript : MonoBehaviour
{
    public float laserSpeed = 15;
    public Light lightsource;
    public GameScript gamescript;
    private Light lightsourceObject;
    private Transform mTransform;

    private void Start()
    {
        mTransform = transform;
        lightsourceObject = Instantiate(lightsource, mTransform.position, Quaternion.identity) as Light;
        gamescript = FindObjectOfType<GameScript>();
    }

    private void Update()
    {
        mTransform.Translate(Vector3.up * laserSpeed * Time.deltaTime);
        if (mTransform.position.y > 30f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag.Equals("EnemySpaceship"))
        {
            Destroy(lightsourceObject);
            Destroy(gameObject);
            collider.GetComponent<EnemySpaceshipScript>().Kill();
            gamescript.AddToScore(collider.tag);
        }
        else if (collider.tag.Contains("Enemy"))
        {
            Enemy enemy = (Enemy)collider.gameObject.GetComponent("Enemy");
            enemy.Killed();
            gamescript.AddToScore(collider.tag);
            Destroy(lightsourceObject);
            Destroy(gameObject);
        }
        else if (collider.tag.Equals("Block"))
        {
            Destroy(lightsourceObject);
            Destroy(gameObject);
            collider.GetComponent<BlockScript>().Collision();
        }
    }
}
