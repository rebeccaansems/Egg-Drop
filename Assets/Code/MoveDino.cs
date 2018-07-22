using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDino : MonoBehaviour
{
    public float MoveSpeed = 0.1f;

    private Vector3 mousePosition, oldPosition;
    private Vector2[] colliderOffsetLeft, colliderOffsetRight;
    private Rect cameraRect;

    private bool isLeft = true;

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

        colliderOffsetLeft = new Vector2[2];
        colliderOffsetRight = new Vector2[2];

        colliderOffsetLeft[0] = new Vector2(
            -this.GetComponents<CapsuleCollider2D>()[0].offset.x,
            this.GetComponents<CapsuleCollider2D>()[0].offset.y);
        colliderOffsetRight[0] = new Vector2(
            this.GetComponents<CapsuleCollider2D>()[0].offset.x,
            this.GetComponents<CapsuleCollider2D>()[0].offset.y);
        colliderOffsetLeft[1] = new Vector2(
            -this.GetComponents<CapsuleCollider2D>()[1].offset.x,
            this.GetComponents<CapsuleCollider2D>()[1].offset.y);
        colliderOffsetRight[1] = new Vector2(
            this.GetComponents<CapsuleCollider2D>()[1].offset.x,
            this.GetComponents<CapsuleCollider2D>()[1].offset.y);

        mousePosition = this.transform.position;
    }

    void FixedUpdate()
    {
        if (this.GetComponent<Animator>().GetBool("IsDead") == false)
        {
            Move();
        }
    }

    void Move()
    {
        mousePosition = new Vector3(Mathf.Clamp(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
           cameraRect.xMin, cameraRect.xMax), this.transform.position.y, 0);
        
        if (Camera.main.ScreenToWorldPoint(Input.mousePosition).y < 0) //don't move dino if player is touching the top 1/2 of screen
        {
            this.transform.position = Vector2.MoveTowards(this.transform.position, mousePosition, MoveSpeed * Time.deltaTime);
        }

        float speed = (this.transform.position - oldPosition).magnitude / Time.deltaTime;
        this.GetComponent<Animator>().SetFloat("Speed", speed);

        if ((oldPosition.x - this.transform.position.x) < -0.03f && isLeft == false)
        {
            this.GetComponent<SpriteRenderer>().flipX = true;
            this.GetComponents<CapsuleCollider2D>()[0].offset = colliderOffsetLeft[0];
            this.GetComponents<CapsuleCollider2D>()[1].offset = colliderOffsetLeft[1];

            isLeft = true;
        }
        else if ((oldPosition.x - this.transform.position.x) > 0.03f && isLeft == true)
        {
            this.GetComponent<SpriteRenderer>().flipX = false;
            this.GetComponents<CapsuleCollider2D>()[0].offset = colliderOffsetRight[0];
            this.GetComponents<CapsuleCollider2D>()[1].offset = colliderOffsetRight[1];

            isLeft = false;
        }
        oldPosition = this.transform.position;
    }

}
