using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureRotator : MonoBehaviour {

	
	void Update () {
		
        transform.Rotate(new Vector3(0, 0, 45) * Time.deltaTime);// rotate the object only on z axis.
	
	}
}
