using UnityEngine;

public class BaseStationController : MonoBehaviour
{
    public GameObject Prefab;
    GrabController GrabController;

    void Start () {
        GrabController = GameObject.Find("Grab Point").GetComponent<GrabController>();
    }
    void OnMouseOver () {
        if (Input.GetMouseButtonDown(0) && Vector3.Distance(GrabController.gameObject.transform.position, transform.position) < 1.1 && GrabController.grabbedGO == null) {
            GameObject spawnedBase = Instantiate(Prefab);
            GrabController.Grab(spawnedBase);
        }
    }
}
