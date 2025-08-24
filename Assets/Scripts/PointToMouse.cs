using UnityEngine;

public class PointToMouse : MonoBehaviour
{
    private Vector2 par_pos;
    private Vector2 mos_pos;
    private Vector2 mouse_wp;

    void Update()
    {   
        par_pos = transform.parent.gameObject.transform.position;
		mos_pos = Input.mousePosition;
		mouse_wp = (new Vector2 (Camera.main.ScreenToWorldPoint(mos_pos).x,Camera.main.ScreenToWorldPoint(mos_pos).y)  - par_pos);
		Vector2 position = new Ray2D(par_pos, mouse_wp).GetPoint(0.7f);
        transform.position = position;
    }
}
