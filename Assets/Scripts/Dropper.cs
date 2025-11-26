using UnityEngine;

public class dropper : MonoBehaviour
{
    public int timer = 3;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (Time.time > timer)
        {
            rb.useGravity = true;
        }
    }
}
