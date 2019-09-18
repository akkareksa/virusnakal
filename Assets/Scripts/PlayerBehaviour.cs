using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public float score;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Target") 
        {
            score += 1;
            print(score);
            // print(other.transform.gameObject);
            Destroy(other.gameObject);
            
        }
    }
}
