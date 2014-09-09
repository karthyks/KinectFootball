using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {

    float time;
    float distance;
    float angle;
    float initialVelocity;
    float finalVelocity;
    float force;
    float mass = 15f;
    float acceleration;

    ScriptHandler handler;
    void Start()
    {
        handler = GameObject.Find("ScriptHandler").GetComponent<ScriptHandler>();
    }
    void KickForce(float[] param)
    {
        time = param[0];
        distance = param[1];
        angle = param[2];
        initialVelocity = param[3];
        finalVelocity = param[4];


        acceleration = (finalVelocity - initialVelocity) / time;
        force = mass * finalVelocity;
        if (force < 5)
        {
            force = 10;
        }
        transform.rigidbody.AddForce(force * new Vector3(angle, 0.2f, 1) * 75);
        Debug.Log(force);

        handler.SendMessage("NextKick", SendMessageOptions.DontRequireReceiver);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            handler.SendMessage("NextKick", SendMessageOptions.DontRequireReceiver);
        }
    }
}
