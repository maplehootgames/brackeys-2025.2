using UnityEngine;

public class PlayerController : MonoBehaviour
{
    void Update() {
        Vector2 moveDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        transform.Translate(moveDirection * Time.deltaTime * 3);
    }
}
