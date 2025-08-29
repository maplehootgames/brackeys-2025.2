using UnityEngine;

public class CustomerSpawnerController : MonoBehaviour
{

    public GameObject[] customerSprite = new GameObject[4];
    int reviewNumber = 0;
    public bool[] arrayOfAvailability = new bool[6];
    GameObject[] arrayOfGameObjects = new GameObject[6];
    int spawnTime = 10;
    int spawnTimer = 0;

    void Start() {
        arrayOfGameObjects[0] = GameObject.Find("Target1");
        arrayOfGameObjects[1] = GameObject.Find("Target2");
        arrayOfGameObjects[2] = GameObject.Find("Target3");
        arrayOfGameObjects[3] = GameObject.Find("Target4");
        arrayOfGameObjects[4] = GameObject.Find("Target5");
        arrayOfGameObjects[5] = GameObject.Find("Target6");
    }
    GameObject whereShouldIGo(int num) {
        return arrayOfGameObjects[num];
    }
    int whereShouldIGoNum() {
        int whereAmI = 0;
        foreach (bool trfls in arrayOfAvailability) {
            if (trfls == false) {
                arrayOfAvailability[whereAmI] = true;
                return whereAmI;
            }
            whereAmI += 1;
            if (whereAmI == 6) {
                return -1;
            }
        }
        return -1;
    }
    
    void spawnCustomer() {
        GameObject customer = Instantiate(customerSprite[Random.Range(0, 3)], gameObject.transform);
        CustomerController customerController = customer.gameObject.GetComponent<CustomerController>();
        int targetNumber = whereShouldIGoNum();
        customerController.targetNumber = targetNumber;
        customerController.targetSpace = whereShouldIGo(targetNumber);
        customerController.reviewNumber = reviewNumber;
        reviewNumber += 1;
        targetNumber = 0;
    }

    void FixedUpdate() {
        spawnTimer += 1;
        if (spawnTimer == spawnTime*50) {
            spawnCustomer();
            spawnTimer = 0;
        }        
    }    
}
