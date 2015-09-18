using UnityEngine;
using System.Collections;

public class Shuriken : MonoBehaviour
{
    public bool destroyed;
    bool holding, start;
    Vector3 velocity, position, lastPos;
    Rigidbody2D rb;
    SpawnEnemies enemies;

	// Use this for initialization
	void Start ()
    {
        destroyed = false;
        holding = false;
        start = true;
        position = transform.position;
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
        enemies = GameObject.FindGameObjectWithTag("Castle").GetComponent<SpawnEnemies>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (destroyed)
            DestroyShuriken();
	}

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        if (holding)
        {
            start = false;
        }

        else if(!holding && !start)
        {
            rb.isKinematic = false;
            Vector3 direction = lastPos - position;
            Debug.Log(direction + " direction");
            transform.Translate(direction * 3.5f * Time.deltaTime);
        }
    }


    void DestroyShuriken()
    {
        if(transform.position.y > 6 || transform.position.x < 3.8f ||
            transform.position.x > 3.8f)
        {
            Destroy(this.gameObject);
        }
    }

    void OnMouseDown()
    {
        holding = true;
        position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
        CalculateEndPoint();

    }

    void CalculateEndPoint()
    {
        Debug.Log((position - Input.mousePosition).magnitude);

        if((position - Input.mousePosition).magnitude > 180)
        {
            lastPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
            holding = false;
        }
    }

    void OnMouseUp()
    {
        //holding = false;
        //lastPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Enemy")
        {
            enemies.destroyed = true;
            destroyed = true;
        }
    }
} // jos hiiri on kulkenut tietyn matkan