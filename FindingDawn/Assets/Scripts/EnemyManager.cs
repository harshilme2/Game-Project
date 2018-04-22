using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public float moveDistance = 2f;
    public bool vertical = true;
    public float speed = 2f;

    private float targetDistance;
    private Vector3 currentPos, endPos, startPos;

    void Start()
    {
        currentPos = transform.position;
        startPos = transform.position;
        endPos = transform.position;
    }

    void Update()
    {
        if (vertical)
        {
            if(transform.position.y > startPos.y + targetDistance){
                transform.rotation = Quaternion.AngleAxis(180, Vector3.forward);
                targetDistance = -moveDistance;
            }
            else {
                transform.rotation = Quaternion.AngleAxis(0, Vector3.forward);
                targetDistance = moveDistance;
            }

            transform.Translate(Vector3.up * speed * Time.deltaTime);

        }
        else
        {
            if (transform.position.x > startPos.x + targetDistance)
            {
                transform.rotation = Quaternion.AngleAxis(90, Vector3.forward);
                targetDistance = -moveDistance;
            }
            else
            {
                transform.rotation = Quaternion.AngleAxis(-90, Vector3.forward);
                targetDistance = moveDistance;
            }

            transform.Translate(Vector3.up * speed * Time.deltaTime);        }
        currentPos = transform.position;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.gameObject.name);

        if (collision.gameObject.tag == "Enemy")
        {
            //print(collision.gameObject.name);
            //Hurt(1);
        }

    }
}
