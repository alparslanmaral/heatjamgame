using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int waterStock = 10;
    public int icecreamStock = 10;

    public GameObject hImage; // UI'da bulunan Image GameObject'i
    public float activationDistance = 1f; // Aktivasyon mesafesi

    private GameObject[] customers; // Customer tagine sahip objeleri tutacak dizi

    void Start()
    {
        // Customer tagine sahip tüm objeleri bul

        // Baþlangýçta tüm objeleri iþlevsiz hale getir
        GorusmezYap();
    }

    void Update()
    {
        customers = GameObject.FindGameObjectsWithTag("Customer");

        if (customers.Length > 0)
        {
            // En yakýn müþteri objesinin mesafesini kontrol et
            float nearestDistance = float.MaxValue;
            foreach (GameObject customer in customers)
            {
                float distance = Vector3.Distance(transform.position, customer.transform.position);
                if (distance < nearestDistance)
                {
                    nearestDistance = distance;
                }
            }

            // Aktivasyon mesafesine göre kontrol et
            if (nearestDistance < activationDistance)
            {
                GorusurYap();
            }
            else
            {
                GorusmezYap();
            }
        }
        else
        {
            Debug.LogError("No Customer objects found with the tag 'Customer'.");
        }
    }

    // Image GameObject'i etkin yap
    private void GorusurYap()
    {
        if (hImage != null)
        {
            hImage.SetActive(true);
        }
    }

    // Image GameObject'i iþlevsiz yap
    private void GorusmezYap()
    {
        if (hImage != null)
        {
            hImage.SetActive(false);
        }
    }
}
