using UnityEngine;

public class OnClickReview : MonoBehaviour
{
    public GameObject objecta;
    void OnMouseOver() {
        Debug.Log("this is happen1");
        if (Input.GetMouseButtonDown(0)) {
            Debug.Log("this is happen2");
            objecta.SetActive(true);
        }
    }
}
