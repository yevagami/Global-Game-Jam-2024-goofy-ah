using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class OverworldCharacter : MonoBehaviour
{
    Vector2 direction;
    Vector2 movementDirection;
    Rigidbody2D rb2d;
    float speed = 5.0f;

    // Start is called before the first frame update
    void Start() {
        direction = new Vector2(1, 0);
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movementDirection.x = Input.GetAxisRaw("Horizontal");
        movementDirection.y = Input.GetAxisRaw("Vertical");
        UpdateDirection();
        rb2d.velocity = movementDirection * speed;
    }

    void UpdateDirection() {
        if(movementDirection.magnitude > 0) {
            direction = movementDirection;
        }
    }
}
