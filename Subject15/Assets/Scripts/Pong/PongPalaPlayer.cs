using UnityEngine;

public class PongPalaPlayer : PongPalaBase
{


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Control
        var velocity = rb.velocity;
        if (Input.GetKey(KeyCode.W))
            velocity = new Vector3(0, speed, 0);
        if (Input.GetKey(KeyCode.S))
            velocity = new Vector3(0, -speed, 0);
        rb.velocity = velocity;
    }

}
