using UnityEngine;

public class BaseStationController : MonoBehaviour
{
    public GameObject Prefab;
    GrabController GrabController;
    

    void Start () {
        GrabController = GameObject.Find("Grab Point").GetComponent<GrabController>();
    }
    void OnMouseOver () {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject spawnedBase = Instantiate(Prefab);
            GrabController.Grab(spawnedBase);
    
        }
        else if (Input.GetMouseButtonDown(1))
        {
            // Do right-click stuff here
        }
    }
}
