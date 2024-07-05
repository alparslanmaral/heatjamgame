using UnityEngine;

public class KarakterKontrol : MonoBehaviour
{
    public float hareketHizi = 5f;
    public float rotationSpeed = 360f;


    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // E�er hem yatay hem de dikey tu�lar bas�lm��sa, vekt�r� normalize et
        if (horizontal != 0 && vertical != 0)
        {
            // Normalize edilmi� vekt�r� olu�tur
            Vector2 normalizedInput = new Vector2(horizontal, vertical).normalized;
            horizontal = normalizedInput.x;
            vertical = normalizedInput.y;
        }

        Vector3 movementDirection = new Vector3(horizontal, 0f, vertical);

        if (movementDirection != Vector3.zero)
        {

            // Hareket y�n�ne do�ru d�nme i�lemi
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
        }

        Vector3 hareket = movementDirection * hareketHizi * Time.deltaTime;
        transform.Translate(hareket, Space.World);
    }

    // Karakterin GameObject'ini ayarlamak i�in public void
    public void SetKarakterObject(GameObject yeniKarakterObject)
    {
        if (yeniKarakterObject != null)
        {
        }
        else
        {
            Debug.LogWarning("Ge�ersiz karakter objesi!");
        }
    }
}
