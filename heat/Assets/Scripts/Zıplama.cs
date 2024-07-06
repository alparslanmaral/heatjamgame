using UnityEngine;

public class KarakterZiplama : MonoBehaviour
{
    public float ziplamaGucu = 10f; 

    private Rigidbody rb;
    private bool zeminUzerinde;

    void Start()
    {
       
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
     
        if (Input.GetKeyDown(KeyCode.Space) && ZeminKontrol())
        {
            Ziplama();
        }
    }

    void Ziplama()
    {
      
        rb.AddForce(Vector3.up * ziplamaGucu, ForceMode.Impulse);
    }

    bool ZeminKontrol()
    {
      
        float yaricap = 0.1f; 
        zeminUzerinde = Physics.CheckSphere(transform.position, yaricap, LayerMask.GetMask("Default"));
        return zeminUzerinde;
    }
}
