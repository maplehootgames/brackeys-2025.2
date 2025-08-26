using UnityEngine;

public class StatusController : MonoBehaviour
{
    int cookTimerValue;
    int cookingStage = 0;
    bool toppingState = false;
    string toppingName = "";
    SpriteRenderer spriteRenderer;

    public bool cookTimerActive;
    public Sprite rawSprite;
    public Sprite cookedSprite;

    void Start() {
         spriteRenderer = transform.gameObject.GetComponent<SpriteRenderer>();
    }

    void Update() {
        if (cookingStage == 0) {
            spriteRenderer.sprite = rawSprite;
        } else if (cookingStage == 1) {
            spriteRenderer.sprite = cookedSprite;
        }
    }
    
    void cookIncrement() {
        cookingStage += 1;
    }

    void burnOut() {
        Destroy(transform.gameObject);
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

    public void addTopping(GameObject topping) {
        if (cookingStage > 0 && toppingState == false) {
            GameObject toppingGameObject = Instantiate(topping, gameObject.transform.position, Quaternion.Euler(0, 0, 0), gameObject.transform);
            toppingState = true;
            toppingName = toppingGameObject.name;
        }
    }    
}
