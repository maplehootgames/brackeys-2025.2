using UnityEngine;

public class BaseStationController : MonoBehaviour
{
    public GameObject Prefab;
    GameObject player;
    GrabController GrabController;

    void Start () {
        player = GameObject.Find("Player");
        GrabController = GameObject.Find("Grab Point").GetComponent<GrabController>();
    }
    void OnMouseOver () {
        if (Input.GetMouseButtonDown(0) && Vector2.Distance(player.transform.position, transform.position) < 2 && GrabController.grabbedGO == null) {
            GameObject spawnedBase = Instantiate(Prefab);
            GrabController.Grab(spawnedBase);
        }
    }
}
