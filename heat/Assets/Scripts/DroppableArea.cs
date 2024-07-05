using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;

public class DroppableArea : MonoBehaviour, IDropHandler
{
    public int score = 0;
    public Text scoreText;
    public float cooldownTime = 10f; // Cooldown s�resi

    private bool canDrop = true; // Cooldown kontrol� i�in flag
    private Vector3 initialPosition; // Taba��n ba�lang�� pozisyonu

    private void Start()
    {
        initialPosition = transform.position;
    }

    public void OnDrop(PointerEventData eventData)
    {
        DraggableItem draggable = eventData.pointerDrag.GetComponent<DraggableItem>();
        if (draggable != null && canDrop)
        {
            draggable.transform.SetParent(transform); // Dondurmay� alandan ��kartma i�lemi
            score += 1; // Puan� art�rma i�lemi
            scoreText.text = score.ToString(); // Sadece say�y� g�sterme
            draggable.ResetPosition(); // Dondurman�n ba�lang�� pozisyonuna d�nmesi i�in
            canDrop = false; // Cooldown ba�lad�, tekrar b�rakmay� engellemek i�in flag'i false yap
            StartCoroutine(CooldownCoroutine()); // Cooldown ba�latma
        }
    }


    private IEnumerator CooldownCoroutine()
    {
        yield return new WaitForSeconds(cooldownTime); // Belirtilen s�re kadar bekle
        canDrop = true; // Cooldown bitti, tekrar b�rakmaya izin vermek i�in flag'i true yap
        ResetDropArea(); // B�rakma alan�n� s�f�rla
    }

    private void ResetDropArea()
    {
        transform.position = initialPosition; // Taba��n ba�lang�� pozisyonuna geri d�n
        scoreText.text = "Score: " + score; // Puan� g�ncelleme i�lemi
    }
}
