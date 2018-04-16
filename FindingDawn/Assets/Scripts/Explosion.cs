using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (!collider2D.gameObject.isStatic)
        {
            Destroy(collider2D.gameObject);
        }
    }
}
