using UnityEngine;
using System.Collections;

public class ScriptHandler : MonoBehaviour {

    GameObject Ball;
    GameObject Kick;

    Vector3 ballPosition;

    string kick;

    GUIStyle fontSize;
    void Start()
    {
        fontSize = new GUIStyle();
        Ball = GameObject.Find("Ball");
        ballPosition = Ball.transform.position;
        kick = "Kick";
        fontSize.fontSize = 50;
    }
    IEnumerator NextKick()
    {
        //Ball = GameObject.Find("Ball");
        Kick = GameObject.Find("Kick");
        //Destroy(Kick);
        kick = null;
        yield return new WaitForSeconds(4.0f);
        Ball.transform.position = ballPosition;
        Ball.rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        yield return new WaitForSeconds(1.0f);
        kick = "Kick";
        Ball.rigidbody.constraints = RigidbodyConstraints.None;
        BallScript.goal = null;
        GameObject.Find("Goalie").SendMessage("reset", SendMessageOptions.DontRequireReceiver);

       // GameObject newBall = (GameObject)Instantiate(Resources.Load("Prefabs/Ball"));
       //// GameObject newKick = (GameObject)Instantiate(Resources.Load("Prefabs/Kick"));
       // newBall.name = "Ball";
       // //newKick.name = "Kick";
    }

    void OnGUI()
    {
        GUI.Label(new Rect(Screen.width/2 - 50, 150, 100, 200), kick, fontSize);
    }
}
