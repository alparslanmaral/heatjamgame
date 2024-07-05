using UnityEngine;

public class KarakterKontrol : MonoBehaviour
{
    private Animator animator;
    public float hareketHizi = 5f;
    public float rotationSpeed = 360f;
    public GameObject d�nmeObjesi; // Y�r�me y�n�ne do�ru d�nmesini istedi�iniz obje

    private void Start()
    {
        animator = GetComponent<Animator>();

        // E�er d�nmeObjesi atanmam��sa, karakterin kendisi d�necek
        if (d�nmeObjesi == null)
        {
            d�nmeObjesi = gameObject;
        }
    }

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
            animator.SetBool("IsMoving", true);

            // Hareket y�n�ne do�ru d�nme i�lemi
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            d�nmeObjesi.transform.rotation = Quaternion.RotateTowards(d�nmeObjesi.transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }

        Vector3 hareket = movementDirection * hareketHizi * Time.deltaTime;
        transform.Translate(hareket, Space.World);
    }

    // Karakterin GameObject'ini ayarlamak i�in public void
    public void SetKarakterObject(GameObject yeniKarakterObject)
    {
        if (yeniKarakterObject != null)
        {
            d�nmeObjesi = yeniKarakterObject;
        }
        else
        {
            Debug.LogWarning("Ge�ersiz karakter objesi!");
        }
    }
}
