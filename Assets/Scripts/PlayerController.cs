using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float moveSpeedModifier;
    private Vector2 moveDirection;

    void Update()
    {
        moveSpeedModifier = 3;
        moveDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        transform.Translate(moveDirection * Time.deltaTime * moveSpeedModifier);
    }
}
