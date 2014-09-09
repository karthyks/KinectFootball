using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KickScript : MonoBehaviour {

    GameObject rightFoot;
    GameObject leftFoot;
    GameObject spine;
    GameObject ball;

    float posOfFoot;
    Vector3 differenceOfFoot;
    Vector3 angleOfKick;

    float time;
    float timeTaken;
    float maxDistanceofKick;

    List<float> timeList;
    List<float> footPos;

    bool kickStarted = false;

    BallScript bs;
    void Start()
    {
        leftFoot = GameObject.Find("15_Foot_Left");
        rightFoot = GameObject.Find("19_Foot_Right");
        ball = GameObject.Find("Ball");
        spine = GameObject.Find("01_Spine");
        time = 0;
        timeTaken = 0;
        maxDistanceofKick = 0;
        bs = GameObject.Find("Ball").GetComponent<BallScript>();
        footPos = new List<float>();
        timeList = new List<float>();
    }

    void Update()
    {
        posOfFoot = Mathf.Floor((leftFoot.transform.position.z - spine.transform.position.z) * 100) / 100;

        if (posOfFoot > 0.1 && !kickStarted)
        {
            kickStarted = true;
            time = 0;
        }
        if (kickStarted)
        {
            DetectKick();
        }  
    }

    void DetectKick()
    {
        time = time + Time.deltaTime;
        footPos.Add(posOfFoot);
        timeList.Add(time);

        if (posOfFoot < -0.35)
        {
            angleOfKick = (leftFoot.transform.position - ball.transform.position);
            //angleOfKick.Normalize();
            kickStarted = false;
            KickParameters();
        }
    }

    void KickParameters()
    {
        float maxTime = 0;
        float minTime = 0;
        float maxDistance = 0;
        float minDistance = 0;

        float initialVelocity = 0;
        float finalVelocity = 0;

        foreach (float t in timeList)
        {
            maxTime = Mathf.Max(maxTime, t);
            minTime = Mathf.Min(minTime, t);
        }
        foreach (float d in footPos)
        {
            maxDistance = Mathf.Max(maxDistance, d);
            minDistance = Mathf.Min(minDistance, d);
        }

        timeTaken = maxTime - minTime;
        maxDistanceofKick = maxDistance - minDistance;

        initialVelocity = (maxDistance / 2) / (maxTime / 2);
        finalVelocity = maxDistanceofKick / timeTaken;

        float[] kickParams = new float[5];
        kickParams[0] = timeTaken;
        kickParams[1] = maxDistanceofKick;
        kickParams[2] = angleOfKick.x;
        kickParams[3] = initialVelocity;
        kickParams[4] = finalVelocity;

        GameObject.Find("Ball").SendMessage("KickForce", kickParams, SendMessageOptions.DontRequireReceiver);
    }
}
