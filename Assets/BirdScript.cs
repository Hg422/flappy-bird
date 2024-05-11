using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    // reference to the rigidbody2d so we can modify it
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logic;
    public bool birdAlive = true;

    // Start is called before the first frame update
    // run as soon as the script is enabled
    void Start()
    {
        // gameObject.name = "Birdy";
        myRigidbody.gravityScale = (float) 2.40;
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && birdAlive)
        {
            // velocity is given by vectors
            myRigidbody.velocity = Vector2.up * flapStrength; // build in shortcut
        }

        if(transform.position.y > 20 || transform.position.y < -20)
        {
            logic.gameOver();
            birdAlive = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        birdAlive = false;
    }
}
