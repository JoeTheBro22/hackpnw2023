using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatingObstacle : MonoBehaviour
{
    public int startAngle;
    public int rotateSpeed = 10;
    Vector3 point;
    Vector3 axis = new Vector3(0,0,1);

    private GameObject GameManager;
    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.Find("GameManager");
        transform.rotation = new Quaternion(0, transform.rotation.x, startAngle, startAngle);
        point = new Vector3(transform.position.x, transform.position.y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        float shrinkAmount = GameManager.GetComponent<GameManager>().shrinkAmount;
        transform.localScale = new Vector3(1,1,0) * shrinkAmount;
        transform.RotateAround(point, axis, Time.deltaTime * rotateSpeed * shrinkAmount);
    }
}