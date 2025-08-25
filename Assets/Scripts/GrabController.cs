using UnityEngine;
public class GrabController : MonoBehaviour
{
    public GameObject grabbedGO;
    private Collider2D[] results = new Collider2D[1];
    public int grabbableLayer = 6;
    float lastGrab = 0F;
    float grabCD = 0.1F;
    
    void Update()
    {
        if (grabbedGO != null)
        {
            grabbedGO.transform.position = transform.position;
        }

        if (Input.GetMouseButtonDown(0))
        {
                
            if (lastGrab + grabCD < Time.time)
            {
                lastGrab = Time.time;
                if (grabbedGO == null)
                {
                    Grab();
                }
                else
                {
                    grabbedGO = null;
                }
            }
        }
    }
    public void Grab(GameObject target = null)
    {

            lastGrab = Time.time;

        if (target != null && grabbedGO == null)
        {
            Debug.Log("Grab called by external script");
            grabbedGO = target;
             return;
        }
        else
        {
            int numOverlaps = GetComponent<Collider2D>().Overlap(new ContactFilter2D().NoFilter(), results);
             if (results[0] != null && results[0].gameObject.layer == grabbableLayer)
            {
                grabbedGO = results[0].gameObject;
                results[0] = null;
            }
        }
    }
}