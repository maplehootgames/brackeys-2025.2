using UnityEngine;

public class CustomerController : MonoBehaviour
{

    public GameObject targetSpace;
    float moveSpeed = 0.03F;
    bool hasOrderd = false;
    public int targetNumber;
    public int reviewNumber;
    string[] orderedCookie;
    string[] bases = new string[] { "Chip", "Chocolate", "Vanilla" };
    string[] toppings = new string[] { "Blue Frosting", "Chocolate Frosting", "Fruit", "Jam", "Pink Frosting", "Whipped Cream" };

    void MoveToTarget() {
        Vector3 targetDirection = targetSpace.transform.position - transform.position;
        transform.Translate(targetDirection.normalized * moveSpeed);
    }

    void CompleteOrder()
    {
        
        Debug.Log("Order Completed");
        gameObject.transform.parent.gameObject.GetComponent<CustomerSpawnerController>().arrayOfAvailability[targetNumber] = false;
        Destroy(gameObject);
    }

// Stuff that I don't need to care about
    void FixedUpdate()
    {
        if (hasOrderd == false)
        {
            if (Vector3.Distance(targetSpace.transform.position, transform.position) < 0.2)
            {
                Order(RandomCookie());
            }
            else
            {
                MoveToTarget();
            }
        }
    }
    string[] RandomCookie()
    {
        string[] chosenCookie = new string[] { bases[Random.Range(0, bases.Length)], toppings[Random.Range(0, toppings.Length)] };

        return chosenCookie;
    }

    void Order(string[] cookie)
    {
        orderedCookie = cookie;
        Debug.Log(cookie[0] + " " + cookie[1]);
        hasOrderd = true;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == 6) {
            StatusController statusController = collider.GetComponent<StatusController>();
            string[] cookieProfile = statusController.getCookie();
            Debug.Log(cookieProfile[0] + " " + cookieProfile[1]);
            if (statusController != null && cookieProfile[0] + cookieProfile[1] == orderedCookie[0] + orderedCookie[1])
            {
                Debug.Log("Order Correct");
                Destroy(collider.gameObject);
                CompleteOrder();
            }
            else if (statusController != null && cookieProfile != orderedCookie)
            {
                Debug.Log("Order Incorrect");
                CompleteOrder();
            }
        }
    }
}
