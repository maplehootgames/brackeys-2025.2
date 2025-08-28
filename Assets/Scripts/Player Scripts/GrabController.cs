using UnityEngine;
public class GrabController : MonoBehaviour
{
    public GameObject grabbedGO;
    private Collider2D[] results = new Collider2D[5];
    public int grabbableLayer = 6;
    private Vector2 par_pos;
    private Vector2 mos_pos;
    private Vector2 mouse_wp;
    float lastGrab = 0F;
    float grabCD = 0.1F;
    
    void Update() {
        pointtomouse();
        if (grabbedGO != null) {
            grabbedGO.transform.position = transform.position;
        }

        if (Input.GetMouseButtonDown(0)) {      
            if (lastGrab + grabCD < Time.time) {
                lastGrab = Time.time;
                if (grabbedGO == null) {
                    Grab();
                } else {
                    grabbedGO = null;
                }
            }
        }
    }
    public void Grab(GameObject target = null) {
        lastGrab = Time.time;

        if (target != null && grabbedGO == null) {
            Debug.Log("Grab called by external script");
            grabbedGO = target;
            return;
        } else {
            int numOverlaps = GetComponent<Collider2D>().Overlap(new ContactFilter2D().NoFilter(), results);
            foreach (Collider2D collider in results)
            {
                if (collider != null && collider.gameObject.layer == grabbableLayer)
                {
                    grabbedGO = collider.gameObject;
                    break;
                }
                results = new Collider2D[] {null, null, null, null, null};
            }
        }
    }
    void pointtomouse() {
        par_pos = transform.parent.gameObject.transform.position;
		mos_pos = Input.mousePosition;
		mouse_wp = (new Vector2 (Camera.main.ScreenToWorldPoint(mos_pos).x,Camera.main.ScreenToWorldPoint(mos_pos).y)  - par_pos);
		Vector2 position = new Ray2D(par_pos, mouse_wp).GetPoint(0.8f);
        transform.position = position;
    }
}
