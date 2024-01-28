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
    [SerializeField] Camera MainCamera;
    [SerializeField] Animator animationController;
    SpriteRenderer SpriteRenderer;

    // Start is called before the first frame update
    void Start() {
        direction = new Vector2(1, 0);
        rb2d = GetComponent<Rigidbody2D>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Update movement and or direction
        movementDirection.x = Input.GetAxisRaw("Horizontal");
        movementDirection.y = Input.GetAxisRaw("Vertical");
        UpdateDirection();
        rb2d.velocity = movementDirection * speed;
        MainCamera.transform.position = new Vector3(transform.position.x, transform.position.y, -10);

        //player is moving
        if (rb2d.velocity.magnitude > 0) {
            //up && down
            if (direction.y == 1) {
                animationController.Play("walk_up");
            }

            if (direction.y == -1) {
                animationController.Play("walk_down");
            }

            //Left && right
            if (direction.x == 1) {
                animationController.Play("walk_left");
                SpriteRenderer.flipX = true;
            }

            if (direction.y == -1) {
                animationController.Play("walk_left");
                SpriteRenderer.flipX = false;
            }

        } else {
            //up && down
            if (direction.y == 1) {
                animationController.Play("idle_up");
            }

            if (direction.y == -1) {
                animationController.Play("idle_down");
            }

            //Left && right
            if (direction.x == 1) {
                animationController.Play("idle_left");
                SpriteRenderer.flipX = true;
            }

            if (direction.y == -1) {
                animationController.Play("idle_left");
                SpriteRenderer.flipX = false;
            }
        }
    }

    void UpdateDirection() {
        if(movementDirection.magnitude > 0) {
            direction = movementDirection;
        }
    }
}
