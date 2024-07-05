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
        // Hareketi durdurma veya baþka kontrolleri iptal etme kodlarý eklenebilir
        // Örneðin: karakterin kontrollerini devre dýþý býrakmak
        // Bu kýsýmda gerekirse eklemeler yapabilirsiniz
        yield return new WaitForSeconds(sure);
        hareketEngellendi = false;
        // Hareketi yeniden etkinleþtirme veya kontrolleri geri getirme kodlarý eklenebilir
        // Örneðin: karakterin kontrollerini yeniden etkinleþtirmek
    }
}
