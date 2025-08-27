using UnityEngine;

public class ToppingStation : MonoBehaviour
{
    public string topping;

    void OnTriggerEnter2D(Collider2D collider) {
        
        StatusController dishbase = collider.gameObject.GetComponent<StatusController>();

        if (dishbase.cookingStage > 0 && dishbase.toppingState == false)
        {
            if (collider.gameObject.layer == 6)
            {
                dishbase.toppingName = topping;
            }
        }
    }
}
