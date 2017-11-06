using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour {
    [SerializeField] private GameObject breakableBlock;
    private int numberOfBlocks;
	// Use this for initialization
	void Start () {
        numberOfBlocks = 0;

		Camera cam = Camera.main;
		float height = 18f;
		float camWidth = (height * cam.aspect);

		float gapSpace = camWidth - 30;
		float padding = gapSpace/9;
		
		for(float y = 8.5f; y > 0f; y -= 1f)
		{
			for(float i = (-camWidth/2) + 1.5f; i < camWidth/2; i += (3 + padding))
			{
                Quaternion defRotation = new Quaternion(0f, 0f, 0f, 0f);
				Instantiate(breakableBlock, new Vector3(i,y,0), defRotation);
                numberOfBlocks++; 
			}
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
