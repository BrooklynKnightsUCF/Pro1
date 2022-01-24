using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroScript : MonoBehaviour {
    float currentTime = 0f;
    float startingTime = 2f;

	// Use this for initialization
	void Awake() {
                currentTime = startingTime;

        }
	
	// Update is called once per frame
	void Update () {
		if(currentTime < 0)
        {
            Destroy(gameObject);
        }
	}
}