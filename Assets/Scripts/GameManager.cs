using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    // Sets the screen resolution.
    void Awake () {
        Screen.SetResolution(1920, 1080, true);
    }
	
	// Update is called once per frame
	void Update () {
        Screen.SetResolution(1920, 1080, true);
    }
}
