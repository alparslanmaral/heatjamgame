using UnityEngine;

public class SeaController : MonoBehaviour
{
    private Animator animator;
    public GameObject sandEffect; // SandEffect objesi burada tanýmlanacak
    private bool isTouchingSea = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        bool isMoving = animator.GetBool("IsMoving");

        if (sandEffect != null)
        {
            sandEffect.SetActive(isMoving && isTouchingSea);
        }

        // Hata ayýklama için log ekleyin
        Debug.Log($"isMoving: {isMoving}, isTouchingSea: {isTouchingSea}");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sea"))
        {
            isTouchingSea = true;
            Debug.Log("Sea object entered.");
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Sea"))
        {
            isTouchingSea = true;
            Debug.Log("Sea object staying.");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Sea"))
        {
            isTouchingSea = false;
            Debug.Log("Sea object exited.");
        }
    }
}
