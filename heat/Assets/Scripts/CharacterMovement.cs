using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Animator animator;
    private AudioSource audioSource;
    public GameObject sandEffect;

    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        bool isMoving = animator.GetBool("IsMoving");

        if (sandEffect != null)
        {
            sandEffect.SetActive(isMoving);
        }


        if (isMoving && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
        else if (!isMoving && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}
