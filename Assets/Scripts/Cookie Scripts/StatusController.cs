using UnityEngine;

public class StatusController : MonoBehaviour
{
    public bool cookTimerActive;
    int cookTimerValue;
    public Sprite rawSprite;
    public Sprite cookedSprite;
    public int cookingStage = 0;
    public bool toppingState = false;
    public string toppingName = "";
    public GameObject toppingGO;
    public string baseType;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = transform.gameObject.GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (cookingStage == 0)
        {
            spriteRenderer.sprite = rawSprite;
        }
        else if (cookingStage == 1)
        {
            spriteRenderer.sprite = cookedSprite;
        }
        else if (cookingStage >= 2)
        {
            burnOut();
        }
    }

    public void cookIncrement()
    {
        cookingStage += 1;
    }
    public void addTopping(GameObject topping)
    {
        toppingState = true;
        toppingName = topping.name;
        toppingGO = topping;

    }
    public void burnOut()
    {
        Destroy(transform.gameObject);
    }
    public string[] getCookie()
    {
        return new string[] {baseType, toppingName};
    }
    void FixedUpdate() {
		if (cookTimerValue == 350) {
            cookIncrement();
            cookTimerValue += 1;
		} else if (cookTimerValue == 700) {
			cookIncrement();
            cookTimerValue += 1;
		} else if (cookTimerValue == 1050) {
            burnOut();
            cookTimerActive = false;
        } else if (cookTimerActive == true) {
            cookTimerValue += 1;
        }
	}
    void OnTriggerExit2D(Collider2D collider) {
        if (collider.gameObject.layer == 7) {
            cookTimerValue = 0;
            cookTimerActive = false;
        }
    }    
}
