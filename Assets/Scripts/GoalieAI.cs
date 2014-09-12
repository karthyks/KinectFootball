using UnityEngine;
using System.Collections;

public class GoalieAI : MonoBehaviour {

    BallScript bs;
    public static int force
    {
        get;
        set;
    }

    public static Vector3 angle
    {
        get;
        set;
    }
    GameObject goalie;
    Vector3 goaliePos;
	void Start () {
        goalie = GameObject.Find("Goalie");
        goaliePos = goalie.transform.position;
        bs = GameObject.Find("Ball").GetComponent<BallScript>();
        force = 0;
	}
	
	// Update is called once per frame
	void Update () {
        switch (force)
        {
            case 0:
                
                break;
            case 18:
                if (angle.x < -0.1)
                {
                    transform.animation.Play("leftMin");
                }
                else if (angle.x > 0.1)
                {
                    transform.animation.Play("rightMin");
                }
                else
                {
                    transform.animation.Play("centreMin");
                }
                force = 0;
                break;
            case 30:
                if (angle.x < -0.1)
                {
                    transform.animation.Play("leftMax");
                }
                else if (angle.x > 0.1)
                {
                    transform.animation.Play("rightMax");
                }
                else
                {
                    transform.animation.Play("centreMax");
                }
                force = 0;
                break;
        }
	}

    void reset()
    {
        goalie.transform.position = goaliePos;
    }
    
}
