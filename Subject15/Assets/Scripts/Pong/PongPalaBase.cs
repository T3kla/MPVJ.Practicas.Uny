using UnityEngine;

public class PongPalaBase : MonoBehaviour
{

    [Header("PalaBase")]
    [SerializeField] public float spread = 3f;
    [SerializeField] protected float speed = 5f;

    protected Rigidbody rb;

}
