using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public float scrollSpeed = 0.5f;

    void Start()
    {
        // Create a new material instance to avoid changing the shared material of the sprite renderer
        spriteRenderer.material = new Material(spriteRenderer.material);
    }

    void Update()
    {
        float offset = Time.time * scrollSpeed;
        float x = offset % 1; // Calculate the fractional part of the offset
        Vector2 offsetVector = new Vector2(x, 0);
        spriteRenderer.material.mainTextureOffset = offsetVector;
    }
}


