using UnityEngine;

public class StationController : MonoBehaviour
{
    public bool cookes = false;
    public bool addsTopping = false;
    public string topping = "";

    void OnTriggerEnter2D(Collider2D collider)
    {
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
