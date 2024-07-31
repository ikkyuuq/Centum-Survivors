// 8 lines
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    public float playerHealth = 100f;
    public float playerMoveSpeed = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.velocity = (
            new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0) * playerMoveSpeed
        );
    }
}
