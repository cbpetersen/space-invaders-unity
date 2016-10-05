using UnityEngine;

public class enemylaserlightScript : MonoBehaviour
{
    public float laserSpeed = 2;

    void Start()
    {
        transform.Translate(Vector3.forward * -2f);
    }

    void Update()
    {
        transform.Translate(Vector3.down * laserSpeed * Time.deltaTime);
        if (transform.position.y < -10f)
        {
            Destroy(gameObject);
        }
    }
}
