using UnityEngine;

public class ToppingStation : MonoBehaviour
{
    public string topping;

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.layer == 6) {
            StatusController dishbase = collider.gameObject.GetComponent<StatusController>();
            dishbase.toppingName = topping;
        }
    }
}
