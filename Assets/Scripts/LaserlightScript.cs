using UnityEngine;

public class LaserlightScript : MonoBehaviour
{
    public float laserSpeed = 15;

    private void Start()
    {
        transform.Translate(Vector3.forward * -2f);
    }

    private void Update()
    {
        transform.Translate(Vector3.up * laserSpeed * Time.deltaTime);
        if (transform.position.y > 30f)
        {
            Destroy(gameObject);
        }
    }
}
