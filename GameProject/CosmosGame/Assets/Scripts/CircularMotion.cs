using UnityEngine;
using System.Collections;

public class CircularMotion : MonoBehaviour {

    Rigidbody2D rb;
    float speed;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();

        speed = 0;
    }
	
	// Update is called once per frame
	void Update () {
        speed += 0.01f;
        rb.position += new Vector2(Mathf.Sin(speed) / 5, Mathf.Cos(speed) / 5);

    }
}
