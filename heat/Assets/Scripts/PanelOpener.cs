using UnityEngine;

public class PanelOpener : MonoBehaviour
{
    public GameObject panel;

    private void Start()
    {
        // Oyun baþladýðýnda paneli pasif yap
        panel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Player etiketiyle kontrol yapabilirsiniz.
        {
            panel.SetActive(true); // UI panelini aç.
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            panel.SetActive(false); // UI panelini kapat.
        }
    }
}
