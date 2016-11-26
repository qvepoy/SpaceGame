using UnityEngine;
using System.Collections;

public class PlayerShip : MonoBehaviour {

    Rigidbody2D rb;
    // Rotate variables 
    float rotateAccelerationLeft, rotateAccelerationRight, rotateAngleLeft, rotateAngleRight, rotationMaxSpeed;
    float rotate, physRotate;
    float speed, maxSpeed;
    
    void Start() {
        rb = GetComponent<Rigidbody2D>();

        rotateAccelerationLeft = 0;
        rotateAccelerationRight = 0;
        
        rotateAngleLeft = 0;
        rotateAngleRight = 0;

        rotationMaxSpeed = 2f;

        speed = 0;
        maxSpeed = 1;
        

        //rb.position = new Vector3(500, 500);
    }

    void Update() {

        Shooting();
        Moving();
    }

    void Shooting() {
        if (Input.GetMouseButtonDown(0)) {
            Sprite.Create(Gettext)
        }
    }

    void Moving() {
        rotate = rb.rotation;
        
        if (speed > maxSpeed)
            speed = maxSpeed;

        if (speed < -maxSpeed)
            speed = -maxSpeed;

        if (Input.GetKey(KeyCode.W)) {
            speed += 0.1f;
            physRotate = rotate;
        }

        if (Input.GetKey(KeyCode.S)) {
            speed -= 0.1f;
            physRotate = rotate;
        }

        if (Input.GetKey(KeyCode.A)) {
            rotateAngleLeft = rotationMaxSpeed * rotateAccelerationLeft;
            if (rotateAccelerationLeft < 1)
                rotateAccelerationLeft += 0.01f;
        } else {
            rotateAngleLeft *= rotateAccelerationLeft;
            if (rotateAccelerationLeft > 0)
                rotateAccelerationLeft -= 0.01f;
        }

        if (Input.GetKey(KeyCode.D)) {
            rotateAccelerationLeft = 0;
            rotateAngleRight = -rotationMaxSpeed * rotateAccelerationRight;
            if (rotateAccelerationRight < 1)
                rotateAccelerationRight += 0.01f;
        } else {
            rotateAngleRight *= rotateAccelerationRight;

            if (rotateAccelerationRight > 0)
                rotateAccelerationRight -= 0.01f;
        }


        //  Move object to mouse position
        //Vector2 targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //transform.position = targetPosition;

        //  Move object in direction 
        //transform.position += new Vector3(Mathf.Sin(Mathf.Deg2Rad * physRotate - Mathf.PI) * speed, Mathf.Cos(Mathf.Deg2Rad * physRotate) * speed);

        transform.position += new Vector3(Mathf.Sin(Mathf.Deg2Rad * physRotate - Mathf.PI) * speed, Mathf.Cos(Mathf.Deg2Rad * physRotate) * speed);
        transform.Rotate(0, 0, rotateAngleLeft + rotateAngleRight);
        Debug.Log(Mathf.Sin(Mathf.Deg2Rad * rotate) + " " + Mathf.Cos(Mathf.Deg2Rad * rotate));
        //Debug.Log("Speed : " + speed + " LAAngle : " + rotateAccelerationLeft + " RAAngle : " + rotateAccelerationRight + " LAngle : " + rotateAngleLeft + " RAngle : " + rotateAngleRight);// + " Mouse X : " + targetPosition.x + " Mouse Y : " + targetPosition.y);

    }
}
