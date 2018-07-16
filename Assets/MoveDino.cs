using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDino : MonoBehaviour
{
    public float MoveSpeed = 0.1f;

    private Vector2 mousePosition, oldPosition;
    private Rect cameraRect;

    void Start()
    {
        var bottomLeft = Camera.main.ScreenToWorldPoint(Vector3.zero);
        var topRight = Camera.main.ScreenToWorldPoint(new Vector3(
            Camera.main.pixelWidth, Camera.main.pixelHeight));

        cameraRect = new Rect(
            bottomLeft.x,
            bottomLeft.y,
            topRight.x - bottomLeft.x,
            topRight.y - bottomLeft.y);
    }

    void FixedUpdate()
    {
        mousePosition = new Vector2(Mathf.Clamp(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
            cameraRect.xMin, cameraRect.xMax), this.transform.position.y);
        this.transform.position = Vector2.MoveTowards(this.transform.position, mousePosition, MoveSpeed * Time.deltaTime);

        if (oldPosition.x < this.transform.position.x)
        {
            this.GetComponent<SpriteRenderer>().flipX = true;
        } else if (oldPosition.x != this.transform.position.x)
        {
            this.GetComponent<SpriteRenderer>().flipX = false;
        }
        oldPosition = this.transform.position;
    }

}
