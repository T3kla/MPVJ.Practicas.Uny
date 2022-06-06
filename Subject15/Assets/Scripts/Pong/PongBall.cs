using UnityEngine;

public class PongBall : MonoBehaviour
{

    [SerializeField] private Vector3 initialDirection = Vector3.zero;
    [SerializeField] private float speed = 5f;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        rb.velocity = initialDirection.normalized * speed;
    }

    private void OnCollisionEnter(Collision col)
    {
        Debug.Log($"Bola collides with + {col.gameObject.name}"); ; ;

        var pala = col.gameObject.GetComponent<PongPalaBase>();

        if (pala)
        {
            var A = new Vector3(col.transform.position.x + pala.spread, col.transform.position.y, 0f);
            var B = transform.position;
            var dir = (B - A);
            rb.velocity = CorrectVelocity(dir) * speed;
            return;
        }

        var normal = col.GetContact(0).normal;
        var reflect = Vector3.Reflect(rb.velocity, normal);
        rb.velocity = CorrectVelocity(reflect) * speed;
    }

    private void Update()
    {
        rb.velocity = CorrectVelocity(rb.velocity) * speed;
    }

    Vector3 CorrectVelocity(Vector3 direction)
    {
        float x = 0f, y = 0f, z = 0f;

        if (direction.x < 0f && direction.x > -0.5f)
            x = -0.5f;
        else if (direction.x > 0f && direction.x < 0.5f)
            x = 0.5f;
        else
            x = direction.x;

        if (direction.x > 0f && direction.y > direction.x)
            y = x;
        else if (direction.x < 0f && direction.y < direction.x)
            y = x;
        else
            y = direction.y;

        return new Vector3(x, y, z).normalized;
    }

}
