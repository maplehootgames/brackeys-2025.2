using UnityEngine;

public class StatusController : MonoBehaviour
{
    public int cookingStage = 0;
    public bool toppingState = false;
    
    public void cookIncrement () {
        cookingStage += 1;
    }
    public void addTopping () {
        toppingState = true;
    }
    public void burnOut() {
        Destroy(transform.gameObject);
    }
}
