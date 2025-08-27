using UnityEngine;

public class CustomerSpawnerController : MonoBehaviour
{

    public GameObject customer;
    int curentCustomerID = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            SpawnCustomer();
        }
    }

    void SpawnCustomer()
    {
        GameObject spawnedCustomer = Instantiate(customer, transform.position, transform.rotation);

        spawnedCustomer.GetComponent<CustomerController>().ID = curentCustomerID;

        if (curentCustomerID < 30)
        {
            curentCustomerID++;
        }
        else
        {
            curentCustomerID = 0;
        }
    }
}
