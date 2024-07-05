using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Transform originalParent; // originalParent de�i�keni
    private Vector3 startPosition; // Ba�lang�� pozisyonu
    private Image image; // Image bile�eni

    private void Awake()
    {
        image = GetComponent<Image>(); // Image bile�enini al
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalParent = transform.parent; // s�r�kleme ba�lamadan �nce originalParent de�i�kenini ata
        startPosition = transform.position; // ba�lang�� pozisyonunu kaydet
        transform.SetParent(transform.root); // s�r�klenen nesneyi root'a ta��
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.pointerCurrentRaycast.worldPosition; // fare imlecinin d�nyadaki konumunu s�r�kleme s�ras�nda nesnenin pozisyonu olarak ayarla
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(originalParent); // s�r�kleme bitti�inde nesneyi originalParent'e geri ta��

        // Image'i g�r�n�r yap (e�er bas�l� de�ilse)
        if (!eventData.dragging)
        {
            image.enabled = true;
        }
    }

    public void ResetPosition()
    {
        transform.position = startPosition; // s�r�klenen nesneyi ba�lang�� pozisyonuna geri d�nd�r
    }

    public void SetStartPosition(Vector3 position)
    {
        startPosition = position; // ba�lang�� pozisyonunu belirtilen konuma ayarla
    }
}
