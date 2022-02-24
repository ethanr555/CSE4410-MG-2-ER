using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    Rigidbody2D ballRigidBody;
    public float speed;
    public float randomUp;

    Vector3 startPosition;

    GameController cont;

    // Start is called before the first frame update
    void Start()
    {
        ballRigidBody = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
        cont = FindObjectOfType<GameController>();
    }

    private void OnEnable()
    {
        Invoke("PushBall", 1f);
    }

    private void PushBall()
    {
        int dir = Random.Range(0, 2);
        float x;
        if (dir == 0)
            x = speed;
        else
            x = -speed;

        ballRigidBody.AddForce(new Vector2(x, -randomUp));


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collision gameObject: " + collision.gameObject.tag);
        Debug.Log("collision gameObject: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Player"))
        {
            Vector2 vel;
            vel.y = ballRigidBody.velocity.y;
            vel.x = ballRigidBody.velocity.x / 2 + collision.collider.attachedRigidbody.velocity.x / 2;

            ballRigidBody.velocity = vel;
        }

        if (collision.gameObject.CompareTag("Brick"))
        {
            cont.HitBrick();
            Destroy(collision.gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        cont.LoseLife();
        ballRigidBody.velocity = Vector2.zero;
        transform.position = startPosition;
        Invoke("PushBall", 2f);
    }
}
