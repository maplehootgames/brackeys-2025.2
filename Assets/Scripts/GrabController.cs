using UnityEngine;

public class GrabController : MonoBehaviour
{

    public GameObject grabbedGO;
    private Collider2D[] results = new Collider2D[1];

    public int grabbableLayer = 6;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (grabbedGO == null)
            {
                Grab();
            }
            else
            {
                grabbedGO = null;
            }
        }

        if (grabbedGO != null)
        {
            grabbedGO.transform.position = transform.position;
        }
    }

    void Grab()
    {
        int numOverlaps = GetComponent<Collider2D>().Overlap(new ContactFilter2D().NoFilter(), results);

        if (results[0] != null && results[0].gameObject.layer == grabbableLayer)
        {
            grabbedGO = results[0].gameObject;
            results[0] = null;
        }
    }
}
