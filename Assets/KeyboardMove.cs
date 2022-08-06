using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardMove : MonoBehaviour
{
    public float speed = 3;
    public Vector2 moveDirection;
    void Update()
    {
        moveDirection = Vector2.zero;
        if (Input.GetKey(KeyCode.W)) moveDirection.y = 1;
        if (Input.GetKey(KeyCode.S)) moveDirection.y = -1;
        if (Input.GetKey(KeyCode.D)) moveDirection.x = 1;
        if (Input.GetKey(KeyCode.A)) moveDirection.x = -1;

        if (moveDirection.sqrMagnitude > 0)
        {
            moveDirection.Normalize();
            transform.Translate(
                moveDirection * Time.deltaTime * speed);
        }
    }
}
