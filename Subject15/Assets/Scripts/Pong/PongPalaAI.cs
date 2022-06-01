using UnityEngine;

public class PongPalaAI : PongPalaBase
{

    [Header("PalaAI")]
    [SerializeField] private Transform ball = null;
    [SerializeField] private float padding = 0.5f;

    private Rigidbody ballRb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        ballRb = ball.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (!ball)
            return;

        if (ballRb.velocity.x <= 0f)
            return;

        var velocity = rb.velocity;
        if (ball.position.y > transform.position.y + padding)
            velocity = new Vector3(0, speed, 0);
        if (ball.position.y < transform.position.y - padding)
            velocity = new Vector3(0, -speed, 0);
        rb.velocity = velocity;
    }

}
