using UnityEngine;

public class GarbageController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == 6)
        {
            Destroy(collider.gameObject);
        }
    }
}
