using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableBlock : MonoBehaviour {


    private static int STABLE = 2;
    private static int UNSTABLE = 1;
    private static int BROKEN = 0;

    private int health;

	// Use this for initialization
	void Start () {
        health = STABLE;
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        health--;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(health == UNSTABLE)
        {
            Sprite damagedBlock = Resources.Load<Sprite>("Sprites\\Damaged Block");
            gameObject.GetComponent<SpriteRenderer>().sprite = damagedBlock;
        }
        if(health == BROKEN)
        {
            Destroy(this.gameObject);
        }
    }
}
