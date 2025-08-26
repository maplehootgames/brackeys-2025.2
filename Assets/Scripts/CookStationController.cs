using UnityEngine;

public class CookStationController : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.layer == 6) {
            StatusController dishbase = collider.gameObject.GetComponent<StatusController>();
            dishbase.cookTimerActive = true;
        }
    }
}
