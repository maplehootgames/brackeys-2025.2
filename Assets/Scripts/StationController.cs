using UnityEngine;

public class StationController : MonoBehaviour
{

    public bool cookes = false;
    public bool addsTopping = false;
    public string topping = "";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collider)
    {

        Debug.Log("Collision Detected");

        CookableController target = collider.gameObject.GetComponent<CookableController>();

        if (target != null)
        {
            if (cookes == true)
            {
                Debug.Log("Station Sending Cook");
                target.CookIncrement();
            }
            if (addsTopping == true)
            {
                target.AddTopping(topping);
            }
        }
    }
}
