using UnityEngine;

public class StatusController : MonoBehaviour
{
    int cookTimerValue;
    int cookingStage = 0;
    bool toppingState = false;
    SpriteRenderer spriteRenderer;

    public bool cookTimerActive;
    public string toppingName = "";
    public Sprite rawSprite;
    public Sprite cookedSprite;

    void Start() {
         spriteRenderer = transform.gameObject.GetComponent<SpriteRenderer>();
    }

    void Update() {
        if (toppingName != "" && cookingStage > 0 && toppingState == false) {
            GameObject toppingGameObject = Instantiate((GameObject)Resources.Load(toppingName), gameObject.transform.position, Quaternion.Euler(0, 0, 0), gameObject.transform);
            toppingState = true;
        }
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
}
