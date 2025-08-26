using UnityEngine;

public class CustomerController : MonoBehaviour
{

    public GameObject target;
    public float moveSpeed;
    public bool hasOrderd = false;

    string[] bases = new string[] {"Chip", "Chocolate", "Vanilla"};
    string[] toppings = new string[] {"Blue Frosting", "Chocolate Frosting", "Fruit", "Jam", "Pink Frosting", "Whipped Cream"};

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    void FixedUpdate()
    {
        if (hasOrderd == false)
        {
            if (Vector3.Distance(target.transform.position, transform.position) < 0.2)
            {
                Order(RandomCookie());
            }
            else
            {
                MoveToTarget();
            }
        }
    }

    void MoveToTarget()
    {

        Vector3 targetDirection =  target.transform.position - transform.position;

        transform.Translate(targetDirection.normalized * moveSpeed);

    }

    string[] RandomCookie()
    {
        string[] chosenCookie = new string[] {bases[Random.Range(0, bases.Length)], toppings[Random.Range(0, toppings.Length)]};

        return chosenCookie;
    }  

    void Order(string[] cookie)
    {
        Debug.Log(cookie[0] + " " + cookie[1]);
        hasOrderd = true;
    }
}
