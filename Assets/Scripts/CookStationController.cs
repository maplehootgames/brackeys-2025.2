using UnityEngine;

public class CookStationController : MonoBehaviour
{
    bool cookTimerActive;
    public int cookTimerValue;
    StatusController dishbase;

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.layer == 6)
        {
            Debug.Log("trigger enter called");

            if (cookTimerActive == true) {
                cookTimerValue += 1;
            }
            dishbase = collider.gameObject.GetComponent<StatusController>();
            cookTimerActive = true;
        }
    }
    void OnTriggerExit2D(Collider2D collider) {
        if (collider.gameObject.layer == 6)
        {
            Debug.Log("Collision Exit Called");
            cookTimerValue = 0;
            cookTimerActive = false;
        }
    }
	void FixedUpdate() {
		if (cookTimerValue == 350) {
            dishbase.cookIncrement();
            cookTimerValue += 1;
		} else if (cookTimerValue == 700) {
			dishbase.cookIncrement();
            cookTimerValue += 1;
		} else if (cookTimerValue == 1050) {
            dishbase.burnOut();
            cookTimerActive = false;
        } else if (cookTimerActive == true) {
            cookTimerValue += 1;
        }
	}
}
