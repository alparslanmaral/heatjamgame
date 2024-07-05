using UnityEngine;
using System.Collections;

public class KarakterCarpmaKontrol : MonoBehaviour
{
    public float geriTepmeGucu = 100f;
    public float stunSure = 2f;

    private bool hareketEngellendi = false;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Engel") && !hareketEngellendi)
        {
            Vector3 geriTepmeYonu = (transform.position - collision.transform.position).normalized;
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.AddForce(geriTepmeYonu * geriTepmeGucu, ForceMode.Impulse);

            StartCoroutine(StunZamani(stunSure));
        }
    }

    IEnumerator StunZamani(float sure)
    {
        hareketEngellendi = true;
        // Hareketi durdurma veya ba�ka kontrolleri iptal etme kodlar� eklenebilir
        // �rne�in: karakterin kontrollerini devre d��� b�rakmak
        // Bu k�s�mda gerekirse eklemeler yapabilirsiniz
        yield return new WaitForSeconds(sure);
        hareketEngellendi = false;
        // Hareketi yeniden etkinle�tirme veya kontrolleri geri getirme kodlar� eklenebilir
        // �rne�in: karakterin kontrollerini yeniden etkinle�tirmek
    }
}
