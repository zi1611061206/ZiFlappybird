using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnMoving : MonoBehaviour
{
    private GameObject obj; //Là đối tượng được gắn source này
    public float moveSpeed; //Biến lưu thông số về tốc độ di chuyển
    public float oldPosition; //Biến lưu thông số về vị trí ban đầu
    public float minY;
    public float maxY;

    // Use this for initialization
    void Start()
    {
        obj = gameObject;
        moveSpeed = 2;
        oldPosition = 10;
        minY = -1;
        maxY = 1;
    }

    // Update is called once per frame
    void Update()
    {
        obj.transform.Translate(new Vector3(-1 * Time.deltaTime * moveSpeed, 0, 0));
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("ResetColumn"))
        {
            obj.transform.position = new Vector3(oldPosition, Random.Range(minY - 1, maxY), 0);
        }
    }
}
