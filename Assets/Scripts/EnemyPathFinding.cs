using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathfinding : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;

    private Rigidbody2D rb;
    private Vector2 moveDir;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>(); // Ensure a SpriteRenderer is attached
    }

    private void FixedUpdate()
    {
        Vector2 newPosition = rb.position + moveDir * (moveSpeed * Time.fixedDeltaTime);
        rb.MovePosition(new Vector2(newPosition.x, rb.position.y)); // Restrict Y movement
    }

    public void MoveTo(Vector2 targetPosition)
    {
        moveDir = new Vector2(targetPosition.x, 0).normalized; // X-axis only

        // Flip sprite based on direction
        if (moveDir.x > 0)
            spriteRenderer.flipX = false; // Facing right
        else if (moveDir.x < 0)
            spriteRenderer.flipX = true; // Facing left
    }
}

// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class EnemyPathfinding : MonoBehaviour
// {
//     [SerializeField] private float moveSpeed = 2f;

//     private Rigidbody2D rb;
//     private Vector2 moveDir;

//     private void Awake()
//     {
//         rb = GetComponent<Rigidbody2D>();
//     }

//     private void FixedUpdate()
//     {
//         rb.MovePosition(rb.position + moveDir * (moveSpeed * Time.fixedDeltaTime));
//     }

//     public void MoveTo(Vector2 targetPosition)
//     {
//         moveDir = targetPosition;
//     }
// }