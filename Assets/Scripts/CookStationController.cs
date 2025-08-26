using UnityEngine;

public class CookStationController : MonoBehaviour
{
    bool cookTimerActive;
    int cookTimerValue;
    StatusController dishbase;

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.layer == 6) {
            dishbase = collider.gameObject.GetComponent<StatusController>();
            dishbase.cookTimerActive = true;
        }
    }
}
