using UnityEngine;

public class BaseStationController : MonoBehaviour
{
    GameObject Parent;
    public GameObject Prefab;

    void Start () {
        Parent = GameObject.Find("Player");
    }
    void OnMouseOver () {
        if (Input.GetMouseButtonDown(0)) {
            Instantiate(Prefab, Parent.transform);
        } else if (Input.GetMouseButtonDown(1)) {
            // Do right-click stuff here
        }
    }
}
