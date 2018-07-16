using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDino : MonoBehaviour
{
    public float MoveSpeed = 0.1f;

    private Vector3 mousePosition, oldPosition;
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
        mousePosition = new Vector3(Mathf.Clamp(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
            cameraRect.xMin, cameraRect.xMax), this.transform.position.y, 0);
        this.transform.position = Vector2.MoveTowards(this.transform.position, mousePosition, MoveSpeed * Time.deltaTime);

        float speed = (this.transform.position - oldPosition).magnitude / Time.deltaTime;
        this.GetComponent<Animator>().SetFloat("Speed", speed);

        if ((oldPosition.x - this.transform.position.x) < -0.03f)
        {
            this.GetComponent<SpriteRenderer>().flipX = true;
        } else if ((oldPosition.x - this.transform.position.x) > 0.03f)
        {
            this.GetComponent<SpriteRenderer>().flipX = false;
        }
        oldPosition = this.transform.position;
    }

}
