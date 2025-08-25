using UnityEngine;

public class ToppingStation : MonoBehaviour
{
    StatusController dishbase;

    void OnTriggerEnter2D(Collider2D collider) {
        dishbase = collider.gameObject.GetComponent<StatusController>();
        dishbase.addTopping();
    }
}
