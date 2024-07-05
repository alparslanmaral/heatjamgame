using UnityEngine;

public class Customer : MonoBehaviour
{
    public GameObject heatBarPrefab; // Assign this in the Inspector
    private GameObject heatBarInstance;
    private HeatBar heatBarScript;

    void Start()
    {
        Vector3 barPosition = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z); // Adjust the y offset as needed
        heatBarInstance = Instantiate(heatBarPrefab, barPosition, Quaternion.identity);
        heatBarInstance.transform.SetParent(transform);

        heatBarScript = heatBarInstance.GetComponent<HeatBar>();
    }

    void Update()
    {
        if (heatBarScript != null)
        {
            heatBarScript.DecreaseHeat(1 * Time.deltaTime); // Adjust decrease rate as needed
        }
    }
}
