using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfter : MonoBehaviour {
    public float time = 3;
    void Start()
    {
        Destroy(gameObject, time);
    }

}
