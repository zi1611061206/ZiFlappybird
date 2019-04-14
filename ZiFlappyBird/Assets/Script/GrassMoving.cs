using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassMoving : MonoBehaviour
{

    private GameObject obj; //Là đối tượng được gắn source này
    public float moveSpeed; //Biến lưu thông số về tốc độ di chuyển
    public float moveDistance; //Biến lưu thông số về khoảng cách đã di chuyển so với vi trí ban đầu
    public Vector3 oldPosition; //Biến lưu thông số về vị trí ban đầu

    // Use this for initialization
    void Start()
    {
        obj = gameObject;
        moveSpeed = 2;
        moveDistance = 20.43F;
        oldPosition = obj.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        obj.transform.Translate(new Vector3(-1 * Time.deltaTime * moveSpeed, transform.position.y, 0));
        if (Vector3.Distance(oldPosition, obj.transform.position) > moveDistance)
        {
            obj.transform.position = oldPosition;
        }
    }
}
