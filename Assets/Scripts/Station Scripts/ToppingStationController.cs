using UnityEngine;

public class ToppingStation : MonoBehaviour
{
    StatusController dishbase;
    public GameObject topping;

    void OnTriggerEnter2D(Collider2D collider) {

        if (collider.gameObject.layer == 6)
        {
            dishbase = collider.gameObject.GetComponent<StatusController>();

            if (dishbase.cookingStage > 0 && dishbase.toppingState == false)
            {
                GameObject toppingGO = Instantiate(topping, dishbase.gameObject.transform.position, Quaternion.Euler(0, 0, 0), dishbase.gameObject.transform);
                dishbase.addTopping(toppingGO);
            }
        }
    }
}
