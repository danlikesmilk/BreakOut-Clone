using System;
using UnityEngine;

public class Bounce : MonoBehaviour {
	private Rigidbody2D rigidBody;
	private Vector2 direction;
    public float speed = 5f;

    public delegate void DeathHandler();
    public event DeathHandler DeathEvent;

    // Use this for initialization
    void Start () {
		direction = new Vector2(0f, -1f);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(direction.x * speed * Time.deltaTime, direction.y * speed * Time.deltaTime, 0);
        if(isOutOfLimits())
        {
            if(DeathEvent != null)
            {
                DeathEvent();
            }
            Instantiate<GameObject>(gameObject, new Vector3(0f, -5f, 0f), new Quaternion(0f, 0f, 0f, 0f));
            Destroy(gameObject);
        }
	}

	void OnCollisionEnter2D(Collision2D collision){
        string tag = collision.collider.gameObject.tag;
        if (collision.collider.gameObject.tag == "Player")
        {
            Vector2 pointOfContact = collision.contacts[0].point;
            GameObject collidedObject = collision.collider.gameObject;
            float playerHorSize = (collidedObject.GetComponent<Collider2D>().bounds.size.x) / 2f;
            float collidedObjectLoc = collidedObject.transform.position.x;
            float angle = ((pointOfContact.x - collidedObjectLoc) / playerHorSize) * 1.4f;
            Vector2 newDirection = new Vector2(Mathf.Tan(angle), 1);
            newDirection.Normalize();
            direction = newDirection;
        }
        else
        {
            Vector2 surfaceNorm = collision.contacts[0].normal;
            if(surfaceNorm.x != 0)
            {
                direction.x = Mathf.Sign(surfaceNorm.x) * Mathf.Abs(direction.x);
            }
            if (surfaceNorm.y != 0)
            {
                direction.y = Mathf.Sign(surfaceNorm.y) * Mathf.Abs(direction.y);
            }
        }
	}

    private bool isOutOfLimits()
    {
        Vector2 MAX_VALUES = new Vector2(18f * Camera.main.aspect, 8.5f);
        Vector2 MIN_VALUES = new Vector2(-18f * Camera.main.aspect, -10f);
        Vector3 position = transform.position;
        if(position.x < MIN_VALUES.x || position.y < MIN_VALUES.y)
        {
            return true;
        }
        if(position.x > MAX_VALUES.x || position.y > MAX_VALUES.y)
        {
            return true;
        }
        return false;
    }
}
