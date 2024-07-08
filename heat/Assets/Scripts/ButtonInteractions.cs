using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInteractions : MonoBehaviour
{
    public float scanRadius = 4f; // Tarama yarýçapý
    public LayerMask playerLayer; // Oyuncu layer'ý

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Örnek olarak Space tuþuna basýldýðýnda
        {
            ScanForCustomers();
        }
    }

    void ScanForCustomers()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, scanRadius, playerLayer);
        foreach (Collider collider in hitColliders)
        {
            GameObject player = collider.gameObject;
            if (player.CompareTag("Player"))
            {
                PlayerInventory playerInventory = player.GetComponent<PlayerInventory>();
                if (playerInventory != null)
                {
                    GameObject[] customers = GameObject.FindGameObjectsWithTag("Customer");
                    foreach (GameObject customer in customers)
                    {
                        CustomerRequest customerRequest = customer.GetComponent<CustomerRequest>();
                        if (customerRequest != null)
                        {
                            if (customerRequest.isReqwater && playerInventory.waterStock > 0)
                            {
                                customerRequest.isReqwater = false;
                                playerInventory.waterStock--;
                                Debug.Log("Player gave water to customer. Water stock now: " + playerInventory.waterStock);
                            }
                            else if (customerRequest.isReqicecream && playerInventory.icecreamStock > 0)
                            {
                                customerRequest.isReqicecream = false;
                                playerInventory.icecreamStock--;
                                Debug.Log("Player gave ice cream to customer. Ice cream stock now: " + playerInventory.icecreamStock);
                            }
                        }
                    }
                }
            }
        }
    }
}
