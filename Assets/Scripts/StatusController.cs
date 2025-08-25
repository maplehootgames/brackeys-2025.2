using UnityEngine;

public class StatusController : MonoBehaviour
{

    public Sprite rawSprite;
    public Sprite cookedSprite;
    public int cookingStage = 0;
    public bool toppingState = false;
    SpriteRenderer spriteRenderer;

    

    void Start()
    {
         spriteRenderer = transform.gameObject.GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (cookingStage == 0)
        {
            spriteRenderer.sprite = rawSprite;
        }
        else if (cookingStage == 1)
        {
            spriteRenderer.sprite = cookedSprite;
        }
        else if (cookingStage >= 2)
        {
            burnOut();   
        }
    }
    
    public void cookIncrement()
    {
        cookingStage += 1;
    }
    public void addTopping () {
        toppingState = true;
    }
    public void burnOut() {
        Destroy(transform.gameObject);
    }
}
