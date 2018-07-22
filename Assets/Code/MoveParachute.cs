using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveParachute : MonoBehaviour
{
    public Vector3 TargetAngle = new Vector3(0f, 0f, -20f);

    private Vector3 CurrentAngle;
    private int Speed;
    void Start()
    {
        Speed = Random.Range(300, 800);
    }

    void FixedUpdate()
    {
        if (this.transform.parent.tag != "Egg")
        {
            this.GetComponent<Rigidbody2D>().AddForce(new Vector3(0.8f, 0.8f, 0) * Speed * Time.deltaTime);

            CurrentAngle = new Vector3(
             Mathf.LerpAngle(CurrentAngle.x, TargetAngle.x, Time.deltaTime),
             Mathf.LerpAngle(CurrentAngle.y, TargetAngle.y, Time.deltaTime),
             Mathf.LerpAngle(CurrentAngle.z, TargetAngle.z, Time.deltaTime));

            transform.eulerAngles = CurrentAngle;
        }
        else
        {
            CurrentAngle = transform.eulerAngles;
        }
    }

    void OnBecameInvisible()
    {
        if (this.transform.parent.tag != "Egg")
        {
            Destroy(this.gameObject);
        }
    }
}
