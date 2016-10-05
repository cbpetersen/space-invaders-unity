using UnityEngine;

public class EnemySpaceshipLightScript : MonoBehaviour
{
    public static float moveSpeed = 4;
    private Transform mTransform;

    // Use this for initialization
    void Start()
    {
        mTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        mTransform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        if (mTransform.position.x > 20)
        {
            Destroy(gameObject);
        }
    }
}
