using System;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	private Rigidbody2D rigidBody;
	private BoxCollider2D playerCollider;
	public float speed = 1f;
    private int lives;
    [SerializeField]
    private GameObject ball;

    // Use this for initialization
    void Start () {
		this.rigidBody = GetComponent<Rigidbody2D>();
        lives = 3;
        ball.GetComponent<Bounce>().DeathEvent += HandleDeath;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 movement = new Vector3(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0f, 0f);
        transform.Translate(movement);
	}

    private void HandleDeath()
    {
        lives--;
        gameObject.transform.position = new Vector3(0f, -8.7f, 0f);
        if (lives == 0)
        {
            Debug.Log("GAME OVER");
        }
    }

}
