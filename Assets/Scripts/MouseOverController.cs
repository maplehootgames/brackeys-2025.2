using UnityEngine;

public class MouseOverController : MonoBehaviour
{
    void OnMouseOver () {
        if (Input.GetMouseButtonDown(0)) {
            // Do left-click stuff here
        } else if (Input.GetMouseButtonDown(1)) {
            // Do right-click stuff here
        }
    }
}
