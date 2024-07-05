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
        heatBarInstance.transform.SetParent(transform, false);

        heatBarScript = heatBarInstance.GetComponent<HeatBar>();
    }

    void Update()
    {
        if (heatBarScript != null)
        {
            heatBarScript.IncreaseHeat(1 * Time.deltaTime); // Adjust increase rate as needed

            // Update the position of the heat bar to stay above the customer
            Vector3 barPosition = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z); // Adjust the y offset as needed
            heatBarInstance.transform.position = barPosition;
        }
    }
}
