using UnityEngine;

public class CookableController : MonoBehaviour
{

    public int cookingStage = 0;
    public int burnInt = 3;
    public string topping = "";

    public void CookIncrement()
    {
        if (cookingStage < burnInt)
        {
            Debug.Log("Cook Receved!!!");
            cookingStage++;
        }
    }

    public void AddTopping(string addedTopping)
    {
        topping = addedTopping;
    }
    
}
