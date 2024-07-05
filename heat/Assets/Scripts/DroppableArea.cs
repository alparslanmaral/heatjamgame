using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;

public class DroppableArea : MonoBehaviour, IDropHandler
{
    public int score = 0;
    public Text scoreText;
    public float cooldownTime = 10f; // Cooldown süresi

    private bool canDrop = true; // Cooldown kontrolü için flag
    private Vector3 initialPosition; // Tabaðýn baþlangýç pozisyonu

    private void Start()
    {
        initialPosition = transform.position;
    }

    public void OnDrop(PointerEventData eventData)
    {
        DraggableItem draggable = eventData.pointerDrag.GetComponent<DraggableItem>();
        if (draggable != null && canDrop)
        {
            draggable.transform.SetParent(transform); // Dondurmayý alandan çýkartma iþlemi
            score += 1; // Puaný artýrma iþlemi
            scoreText.text = score.ToString(); // Sadece sayýyý gösterme
            draggable.ResetPosition(); // Dondurmanýn baþlangýç pozisyonuna dönmesi için
            canDrop = false; // Cooldown baþladý, tekrar býrakmayý engellemek için flag'i false yap
            StartCoroutine(CooldownCoroutine()); // Cooldown baþlatma
        }
    }


    private IEnumerator CooldownCoroutine()
    {
        yield return new WaitForSeconds(cooldownTime); // Belirtilen süre kadar bekle
        canDrop = true; // Cooldown bitti, tekrar býrakmaya izin vermek için flag'i true yap
        ResetDropArea(); // Býrakma alanýný sýfýrla
    }

    private void ResetDropArea()
    {
        transform.position = initialPosition; // Tabaðýn baþlangýç pozisyonuna geri dön
        scoreText.text = "Score: " + score; // Puaný güncelleme iþlemi
    }
}
