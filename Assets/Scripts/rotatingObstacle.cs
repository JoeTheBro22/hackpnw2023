using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatingObstacle : MonoBehaviour
{
    public int startAngle;
    public int rotateSpeed = 10;
    Vector3 point;
    Vector3 axis = new Vector3(0,0,1);
    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = new Quaternion(0, transform.rotation.x, transform.rotation.y, startAngle);
        point = new Vector3(transform.position.x, transform.position.y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(point, axis, Time.deltaTime * rotateSpeed);
    }
}
