#define SEQUENTIAL 
using UnityEngine;
using System.Collections;


public class CameraFollow : MonoBehaviour
{

    public Transform target;

    public float approachPosRate = 0.1f;
    public float approachRotRate = 0.03f;

    private float height = 15.0f;   // カメラの高さ
    private float distance = 10.0f; // どれくらい後ろを追随するか
    private int followMode = 2; 


    // Update is called once per frame
    void FixedUpdate()
    {
        if (target != null)
        {
            Vector3 endPos;
            Quaternion endRot;
            switch (followMode)
            {
                case 0:
                    transform.position = Vector3.Lerp(transform.position, target.position, approachPosRate);
                    transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, approachRotRate);
                    break;
                case 1:
                    endPos = target.transform.position + distance * target.forward.normalized;
                    endPos = new Vector3(endPos.x, height, endPos.z);
                    transform.position = Vector3.Lerp(transform.position, endPos, approachPosRate);
                    endRot = Quaternion.Euler(90, target.rotation.eulerAngles.y, target.rotation.eulerAngles.z);
                    transform.rotation = Quaternion.Lerp(transform.rotation, endRot, approachRotRate);
                    break;
                case 2:
                    endPos = target.transform.position + distance * target.forward.normalized;
                    transform.position = new Vector3(endPos.x, height, endPos.z);
                    transform.rotation = Quaternion.Euler(90, target.rotation.eulerAngles.y, target.rotation.eulerAngles.z);
                    break;
            }
        }
    }
}
