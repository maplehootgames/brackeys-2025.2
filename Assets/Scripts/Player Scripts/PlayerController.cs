using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Animator animator;

    bool left;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }
    void Update()
    {
        Vector2 moveDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (left == false)
        {
            transform.Translate(moveDirection * Time.deltaTime * 3);
        }
        else
        {
            transform.Translate(new Vector2(moveDirection.x * -1, moveDirection.y) * Time.deltaTime * 3);
        }

        if (left)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (moveDirection != Vector2.zero)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            left = false;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            left = true;
        }
    }
}
