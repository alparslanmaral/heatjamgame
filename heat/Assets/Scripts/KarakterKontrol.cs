using UnityEngine;

public class KarakterKontrol : MonoBehaviour
{
    private Animator animator;
    public float hareketHizi = 5f;
    public float rotationSpeed = 360f;
    public GameObject dönmeObjesi; // Yürüme yönüne doðru dönmesini istediðiniz obje

    private void Start()
    {
        animator = GetComponent<Animator>();

        // Eðer dönmeObjesi atanmamýþsa, karakterin kendisi dönecek
        if (dönmeObjesi == null)
        {
            dönmeObjesi = gameObject;
        }
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Eðer hem yatay hem de dikey tuþlar basýlmýþsa, vektörü normalize et
        if (horizontal != 0 && vertical != 0)
        {
            // Normalize edilmiþ vektörü oluþtur
            Vector2 normalizedInput = new Vector2(horizontal, vertical).normalized;
            horizontal = normalizedInput.x;
            vertical = normalizedInput.y;
        }

        Vector3 movementDirection = new Vector3(horizontal, 0f, vertical);

        if (movementDirection != Vector3.zero)
        {
            animator.SetBool("IsMoving", true);

            // Hareket yönüne doðru dönme iþlemi
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            dönmeObjesi.transform.rotation = Quaternion.RotateTowards(dönmeObjesi.transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }

        Vector3 hareket = movementDirection * hareketHizi * Time.deltaTime;
        transform.Translate(hareket, Space.World);
    }

    // Karakterin GameObject'ini ayarlamak için public void
    public void SetKarakterObject(GameObject yeniKarakterObject)
    {
        if (yeniKarakterObject != null)
        {
            dönmeObjesi = yeniKarakterObject;
        }
        else
        {
            Debug.LogWarning("Geçersiz karakter objesi!");
        }
    }
}
