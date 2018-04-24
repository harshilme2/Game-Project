using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{

    public Vector3 direction { get; set; }
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
            this.transform.Translate(direction * 10f * Time.deltaTime);
            //transform.Rotate(0, 0, 10);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.gameObject.tag);

        if (collision.gameObject.tag == "Enemy")
        {
            //print("Asd" + collision.gameObject.tag);
            Destroy(collision.gameObject);
            Destroy(this.gameObject);

        }else if (collision.gameObject.tag == "Player")
        {

        }
        else
        Destroy(this.gameObject);

        

    }
}
