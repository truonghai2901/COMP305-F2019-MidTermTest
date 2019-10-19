using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

public class Player2 : MonoBehaviour
{
    public GameController gameController;

    // private instance variables
    private AudioSource _thunderSound;
    private AudioSource _yaySound;

    public Speed speed;
    public Boundary boundary;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckBounds();
    }
    public void Move()
    {
        Vector2 newPosition = transform.position;

        if (Input.GetAxis("Vertical") > 0.0f)
        {
            newPosition += new Vector2(0.0f, speed.max);
        }

        if (Input.GetAxis("Vertical") < 0.0f)
        {
            newPosition += new Vector2(0.0f, speed.min);
        }

        transform.position = newPosition;
    }
    public void CheckBounds()
    {
        // check Top boundary
        if (transform.position.y > boundary.Top)
        {
            transform.position = new Vector2(transform.position.x, boundary.Top);
        }

        // check  boundary
        if (transform.position.y < boundary.Bottom)
        {
            transform.position = new Vector2(transform.position.x, boundary.Bottom);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Cloud2":
                _thunderSound.Play();
                gameController.Lives -= 1;
                break;
            case "Island2":
                _yaySound.Play();
                gameController.Score += 100;
                break;
        }
    }
}
