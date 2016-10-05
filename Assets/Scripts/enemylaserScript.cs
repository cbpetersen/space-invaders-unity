using UnityEngine;

public class enemylaserScript : MonoBehaviour {

    public float laserSpeed = 2;
    public Light lightsource;

    private Transform mTransform;
    private Light lightsourceObject;

    void Start()
    {
        mTransform = transform;
        Instantiate(lightsource, mTransform.position, Quaternion.identity);
    }

    void Update()
    {
        mTransform.Translate(Vector3.down * laserSpeed * Time.deltaTime);
        if (mTransform.position.y < -10f)
            Destroy(gameObject);
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag.Equals("Player"))
        {
            Debug.Log("player hit");
            collider.GetComponent<PlayerMovementScript>().Killed();
            Destroy(gameObject);
        }
        else if (collider.tag.Equals("Block"))
        {
            Destroy(gameObject);
            collider.GetComponent<BlockScript>().Collision();
        }
    }
}
