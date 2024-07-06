using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerRequest : MonoBehaviour
{
    public GameObject IceCream;
    public GameObject Water;

    public bool isReqicecream = false;
    public bool isReqwater = false;
    public bool isWant = false;

    void Start()
    {
        IceCream.SetActive(false);
        Water.SetActive(false);
        StartCoroutine(RequestRoutine());
    }

    IEnumerator RequestRoutine()
    {
        while (true)
        {
            if (isWant)
            {
                yield return new WaitUntil(() => isWant == false);
            }

            yield return new WaitForSeconds(5f);

            if (!isWant)
            {
                int randomRequest = Random.Range(0, 2);
                if (randomRequest == 0)
                {
                    isReqicecream = true;
                    IceCream.SetActive(true);
                    isWant = true;
                }
                else
                {
                    isReqwater = true;
                    Water.SetActive(true);
                    isWant = true;
                }
            }
        }
    }
}
