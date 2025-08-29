using UnityEngine;

public class CustomerController : MonoBehaviour
{

    public GameObject targetSpace;
    public GameObject moneyParticle;
    public GameObject badParticle;
    public Animator animator;
    float moveSpeed = 0.03F;
    bool hasOrderd = false;
    public int targetNumber;
    public int reviewNumber;
    int timerValue = 0;
    int reviewRating = 5;
    string[] orderedCookie;
    string[] bases = new string[] { "Chip", "Chocolate", "Vanilla" };
    string[] toppings = new string[] { "Blue Frosting", "Chocolate Frosting", "Fruit", "Jam", "Pink Frosting", "Whipped Cream" };

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    void MoveToTarget() {

        if (animator.GetBool("isMoving") == false)
        {
            animator.SetBool("isMoving", true);
        }

        Vector3 targetDirection = targetSpace.transform.position - transform.position;
        transform.Translate(targetDirection.normalized * moveSpeed);
    }

    void CompleteOrder(bool isCorrect)
    {
        if (isCorrect == false) { reviewRating = 0;}
        Debug.Log("Order Completed");
        gameObject.transform.parent.gameObject.GetComponent<ReviewSystem>().reviewList[reviewNumber] = reviewRating;
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

                animator.SetBool("isMoving", false);
            }
            else
            {
                MoveToTarget();
            }
        } else {
            timerValue += 1;
            if (timerValue == 750) {
                reviewRating -= 1;
                timerValue = 0;
            }
        }
    }
    string[] RandomCookie()
    {
        string[] chosenCookie = new string[] { bases[UnityEngine.Random.Range(0, bases.Length)], toppings[UnityEngine.Random.Range(0, toppings.Length)] };

        return chosenCookie;
    }

    void Order(string[] cookie)
    {
        orderedCookie = cookie;
        Debug.Log(cookie[0] + " " + cookie[1]);
        hasOrderd = true;
        Instantiate((GameObject)Resources.Load(cookie[0] + " " + cookie[1]), gameObject.transform.position + new Vector3 (0,1,0), Quaternion.Euler(0, 0, 0), gameObject.transform);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == 6) {
            StatusController statusController = collider.GetComponent<StatusController>();
            string[] cookieProfile = statusController.getCookie();
            Debug.Log(cookieProfile[0] + " " + cookieProfile[1]);
            if (statusController != null && cookieProfile[0] + cookieProfile[1] == orderedCookie[0] + orderedCookie[1])
            {
                Instantiate(moneyParticle, transform.position, transform.rotation);
                Debug.Log("Order Correct");
                Destroy(collider.gameObject);
                CompleteOrder(true);
            }
            else if (statusController != null && cookieProfile != orderedCookie)
            {
                Instantiate(badParticle, transform.position, transform.rotation);
                Debug.Log("Order Incorrect");
                CompleteOrder(false);
            }
        }
    }
}
