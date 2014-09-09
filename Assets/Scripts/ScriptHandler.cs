using UnityEngine;
using System.Collections;

public class ScriptHandler : MonoBehaviour {

    GameObject Ball;
    GameObject Kick;

    Vector3 ballPosition;
    void Start()
    {
        Ball = GameObject.Find("Ball");
        ballPosition = Ball.transform.position;
    }
    IEnumerator NextKick()
    {
        //Ball = GameObject.Find("Ball");
        Kick = GameObject.Find("Kick");

        
        
        //Destroy(Kick);
        yield return new WaitForSeconds(4.0f);
        Ball.transform.position = ballPosition;
        Ball.rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        yield return new WaitForSeconds(1.0f);
        Ball.rigidbody.constraints = RigidbodyConstraints.None;

       // GameObject newBall = (GameObject)Instantiate(Resources.Load("Prefabs/Ball"));
       //// GameObject newKick = (GameObject)Instantiate(Resources.Load("Prefabs/Kick"));
       // newBall.name = "Ball";
       // //newKick.name = "Kick";
    }
}
