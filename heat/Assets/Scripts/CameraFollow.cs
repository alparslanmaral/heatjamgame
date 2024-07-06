using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Takip edilecek oyuncu
    public Vector3 offset;   // Oyuncuya olan mesafe

    void LateUpdate()
    {
        transform.position = player.position + offset;
    }
}
