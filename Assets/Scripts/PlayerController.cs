using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private moveSpeedModifier;
    private Vector2 moveDirection;

    void Update()
    {
        moveSpeedModifier = 3;
        moveDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        transform.Translate(wishDir * Time.deltaTime * moveSpeedModifier);
    }
}
