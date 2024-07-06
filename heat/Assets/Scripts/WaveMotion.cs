using UnityEngine;

public class WaveMotion : MonoBehaviour
{
    public float amplitudeY = 0.3f; // Y ekseninde hareket mesafesi
    public float frequencyY = 0.5f; // Y ekseninde hareket hýzý
    public float amplitudeX = 0.2f; // X ekseninde hareket mesafesi
    public float frequencyX = 0.3f; // X ekseninde hareket hýzý
    public float amplitudeZ = 0.2f; // Z ekseninde hareket mesafesi
    public float frequencyZ = 0.3f; // Z ekseninde hareket hýzý
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float newY = startPos.y + Mathf.Sin(Time.time * frequencyY) * amplitudeY;
        float newX = startPos.x + Mathf.Sin(Time.time * frequencyX) * amplitudeX;
        float newZ = startPos.z + Mathf.Sin(Time.time * frequencyZ) * amplitudeZ;
        transform.position = new Vector3(newX, newY, newZ);
    }
}
