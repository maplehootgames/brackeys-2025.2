using UnityEngine;

public class CustomerSpawnerController : MonoBehaviour
{

    public GameObject[] customerSprite = new GameObject[4];
    int reviewNumber = 0;
    public bool[] arrayOfAvailability = new bool[6];
    GameObject[] arrayOfGameObjects = new GameObject[6];
    int spawnTime = 10;
    int spawnTimer = 0;
    public float reviewModifier = 1;
    public int que;
    ReviewSystem reviewer;

    public void addToQue(int queadd) {
        que += queadd;
    }
    void Start() {
        arrayOfGameObjects[0] = GameObject.Find("Target1");
        arrayOfGameObjects[1] = GameObject.Find("Target2");
        arrayOfGameObjects[2] = GameObject.Find("Target3");
        arrayOfGameObjects[3] = GameObject.Find("Target4");
        arrayOfGameObjects[4] = GameObject.Find("Target5");
        arrayOfGameObjects[5] = GameObject.Find("Target6");
        reviewer = GameObject.Find("CustomerSpawner").GetComponent<ReviewSystem>();
        }
    void Update() {
        int averageReview = reviewer.averageReview();
        if (averageReview == 5) {
            reviewModifier = 0.2f;
        } else if (averageReview == 4) {
            reviewModifier = 0.4f;
        } else if (averageReview == 3) {
            reviewModifier = 0.6f;
        } else if (averageReview == 2) {
            reviewModifier = 0.8f;
        } else if (averageReview == 1) {
            reviewModifier = 1f;
        }
        if (que != 0) {
            que--;
            spawnCustomer();
        }
    }
    GameObject whereShouldIGo(int num) {
        return arrayOfGameObjects[num];
    }
    int whereShouldIGoNum() {
        int whereAmI = 0;
        foreach (bool trfls in arrayOfAvailability) {
            if (trfls == false) {
                return whereAmI;
            }
            whereAmI += 1;
            if (whereAmI == 6) {
                return -1;
            }
        }
        return -1;
    }
    int whereShouldIGoNumActual() {
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
        if (whereShouldIGoNum() != -1) {
            if (reviewNumber == 30) { reviewNumber = 0; }
            GameObject customer = Instantiate(customerSprite[Random.Range(0, 4)], gameObject.transform);
            CustomerController customerController = customer.gameObject.GetComponent<CustomerController>();
            int targetNumber = whereShouldIGoNumActual();
            customerController.targetNumber = targetNumber;
            customerController.targetSpace = whereShouldIGo(targetNumber);
            customerController.reviewNumber = reviewNumber;
            reviewNumber += 1;
            targetNumber = 0;
        } else {
            que++;
        }
    }

    void FixedUpdate() {
        spawnTimer += 1;
        if (spawnTimer == spawnTime*reviewModifier*50) {
            spawnCustomer();
            spawnTimer = 0;
        }
    }    
}
