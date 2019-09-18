using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HingeMovement : MonoBehaviour
{
	private bool _grabbing; 
    public bool alive;
    public float maxHeight;
    public float minHeight;
	LineRenderer lr;   

    void Start()
    {
        alive = true;
        lr = gameObject.GetComponentInChildren<LineRenderer>(); 
        // print(transform.position);
    }

	// Update is called once per frame
	void Update ()
	{   
        if (transform.position.y<minHeight) {
            alive = false;
            // print("GAMEOVER");
        }
        if(alive) 
        {
            // LineRenderer lr = gameObject.GetComponentInChildren<LineRenderer>();        
            // print(lr);
            // Color color1 = Color.green;
            // Color color2 = Color.red;
            // lr.startColor = Color.green;    
            // lr.SetColors(color1,color2);
            // lr.material = new Material(Shader.Find("Particles/Alpha Blended Premultiply"));
            lr.SetWidth(0.08f,0.08f);
            // lr.startWidth = 0.08f;
            // lr.endWidth = 0.08f;
            if (Input.GetMouseButtonDown(0))
            {
                _grabbing = true;
                // print("Mouse button down"); 
            }

            if (Input.GetMouseButton(0))
            {
                lr.positionCount = 2;
                GameObject closest = FindNearest();
                // print("Mouse button ");
                if (_grabbing)
                {
                    // print("Mouse button grab");
                    lr.SetPosition(1, closest.transform.position);
                    closest.GetComponentInChildren<HingeJoint2D>().connectedBody =
                        gameObject.GetComponentInChildren<Rigidbody2D>();
                    _grabbing = false; 
                }
                lr.SetPosition(0, transform.position);
            }

            if (Input.GetMouseButtonUp(0))
            {
                // print("Mouse button up");
                GameObject[] hinges;
                hinges = GameObject.FindGameObjectsWithTag("hinge");
                lr.positionCount = 0; 

                foreach (GameObject go in hinges)
                {
                    go.GetComponentInChildren<HingeJoint2D>().connectedBody = null;
                }
            }
        }
	}

	GameObject FindNearest()
	{
		GameObject[] hinges;
		hinges = GameObject.FindGameObjectsWithTag("hinge");
		GameObject closest = null;
		float distance = Mathf.Infinity;
		Vector3 position = transform.position;

		foreach (GameObject go in hinges)
		{
			Vector3 diff = go.transform.position - position;
			float curDistance = diff.sqrMagnitude;
			if (curDistance < distance)
			{
				closest = go;
				distance = curDistance; 
			}
		}
		return closest; 
	}
}       