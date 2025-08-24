using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeedModifier;
    Vector2 wishDir;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        wishDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        transform.Translate(wishDir * Time.deltaTime * moveSpeedModifier);
    }
}
