using UnityEngine;

public class ToppingStation : MonoBehaviour
{
    public GameObject topping;

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.layer == 6) {
            StatusController dishbase = collider.gameObject.GetComponent<StatusController>();
            dishbase.addTopping(topping);
        }
    }
}
