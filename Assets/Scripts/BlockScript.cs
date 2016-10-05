using UnityEngine;

public class BlockScript : MonoBehaviour
{
    public Material[] Materials;
    private bool damaged;
    private Renderer renderer;

    void Start()
    {
        renderer = GetComponent<Renderer>();
        renderer.sharedMaterial = Materials[0];
    }

    public void Collision()
    {
        if (damaged)
        {
            Destroy(gameObject);
        }
        else
        {
            renderer.sharedMaterial = this.Materials[1];
            damaged = true;
        }
    }
}
