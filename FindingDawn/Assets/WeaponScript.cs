using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public GameObject EnemyPoof;
    private GameObject des;
    private GameObject rotate;
    private GameObject hit;
    [Header("Sounds")]
    public GameObject HitSound;
    public GameObject ThrowSound;
    public Vector3 direction { get; set; }
    // Use this for initialization
    void Start()
    {
       rotate = Instantiate(ThrowSound, this.transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
            this.transform.Translate(direction * 10f * Time.deltaTime);
            //transform.Rotate(0, 0, 10);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //print(collision.gameObject.tag);

        if (collision.gameObject.tag == "Enemy")
        {
            //print("Asd" + collision.gameObject.tag);
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
            Destroy(rotate);
            hit = Instantiate(HitSound, this.transform.position, Quaternion.identity);
            Destroy(hit, 0.51f);
            des = Instantiate(EnemyPoof, this.transform.position, Quaternion.identity);
            Destroy(des, 1f);
            
        }
        else if (collision.gameObject.tag == "Player")
        {

        }
        else
        { 
            Destroy(this.gameObject);
            Destroy(hit, 1f);
            Destroy(rotate);
        }
    }

}
