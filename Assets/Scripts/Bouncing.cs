using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncing : MonoBehaviour
{
    // Start is called before the first frame update
    // public float Yincrement;
    public float speed;
    private Vector2 targetPos;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        other.transform.position = Vector2.MoveTowards(other.transform.position,targetPos, speed * Time.deltaTime);
        if (other.tag == "Player") 
        {
            // other.transform.position.y + 200
            // print(other.transform.position);
            targetPos = new Vector2(other.transform.position.x,  other.transform.position.y + 2000f);
            // print(targetPos);
            Destroy(gameObject);
        }
    }
}
