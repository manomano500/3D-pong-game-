using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalContorller : MonoBehaviour
{
        private int player1 = 0; // Counter to keep track of goals scored
        private int player2 = 0; // Counter to keep track of goals scored

    public float speed;
    private Rigidbody rb;
    private Vector3 direction;
    public float minDirection = 0.5f;

    void Start()
    {
        this.rb = GetComponent<Rigidbody>();
        this.ChooseDirection();
    }

    void Update()
    {
        // transform.position += direction * speed * Time.deltaTime;
    }

    void FixedUpdate()
    {
        this.rb.MovePosition(this.rb.position + direction * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall"))
        {
            direction.z = -direction.z;
            // direction.x = -direction.x;
            
        }
         if (other.CompareTag("Goal"))
        {
            direction.x = -direction.x;

            // player1+1;
        Debug.Log("Goal Scored! PLAYER 2" );
        }

        if( other.CompareTag("Goal2")){
            direction.x = -direction.x;
            // player2+1;
        Debug.Log("Goal Scored! PLAYER 1" );

        }
        if (other.CompareTag("Racket"))
        {
            Vector3 newDirection = (transform.position - other.transform.position).normalized;
            newDirection.y = 0;  // Ensure the y-component is zero

            newDirection.x = Mathf.Sign(newDirection.x) * Mathf.Max(Mathf.Abs(newDirection.x), this.minDirection);
            newDirection.z = Mathf.Sign(newDirection.z) * Mathf.Max(Mathf.Abs(newDirection.z), this.minDirection);

            direction = newDirection;
        }
    }

    private void ChooseDirection()
    {
        float signX = Mathf.Sign(Random.Range(-1f, 1f));
        float signZ = Mathf.Sign(Random.Range(-1f, 1f));
        this.direction = new Vector3(0.5f * signX, 0, 0.5f * signZ);
    }


}
