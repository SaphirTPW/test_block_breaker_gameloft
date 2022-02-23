using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{

    private Vector3 targetPos;
    public float speed = 2.0f;

    void Start()
    {
        targetPos = transform.position;
    }

    void Update()
    {
        float distance = transform.position.z - Camera.main.transform.position.z;
        targetPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        targetPos = Camera.main.ScreenToWorldPoint(targetPos);
        targetPos = new Vector3(Mathf.Clamp(targetPos.x, -2f, 2f), 0, 0);

        Vector3 followXonly = new Vector3(targetPos.x, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, followXonly, speed * Time.deltaTime);

    }
}
