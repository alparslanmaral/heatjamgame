using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Transform originalParent; // originalParent deðiþkeni
    private Vector3 startPosition; // Baþlangýç pozisyonu
    private Image image; // Image bileþeni

    private void Awake()
    {
        image = GetComponent<Image>(); // Image bileþenini al
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalParent = transform.parent; // sürükleme baþlamadan önce originalParent deðiþkenini ata
        startPosition = transform.position; // baþlangýç pozisyonunu kaydet
        transform.SetParent(transform.root); // sürüklenen nesneyi root'a taþý
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.pointerCurrentRaycast.worldPosition; // fare imlecinin dünyadaki konumunu sürükleme sýrasýnda nesnenin pozisyonu olarak ayarla
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(originalParent); // sürükleme bittiðinde nesneyi originalParent'e geri taþý

        // Image'i görünür yap (eðer basýlý deðilse)
        if (!eventData.dragging)
        {
            image.enabled = true;
        }
    }

    public void ResetPosition()
    {
        transform.position = startPosition; // sürüklenen nesneyi baþlangýç pozisyonuna geri döndür
    }

    public void SetStartPosition(Vector3 position)
    {
        startPosition = position; // baþlangýç pozisyonunu belirtilen konuma ayarla
    }
}
