using UnityEngine;

public class AutoDestroy : MonoBehaviour
{

    float spawnTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        spawnTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > spawnTime + 5)
        {
            Destroy(gameObject);
        }
    }
}
