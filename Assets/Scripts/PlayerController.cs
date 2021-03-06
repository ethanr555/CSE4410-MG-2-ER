using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D playerRigidBody;

    float input;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        input = Input.GetAxis("Horizontal");
        playerRigidBody.AddForce(Vector2.right * input * speed * Time.deltaTime);
    }
}
