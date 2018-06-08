using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour {

    public float speed = 10;
    public float rotationSpeed = 10;
    public float angle;
    public float fuel = 100;
    public float rateOfConsumptionIDDLE = 1;
    public float rateOfConsuptionMOVING = 2.5f;


	void Update () {
        Movement();
        FuelConsumption();
    }

    private float GetRealAngle(Vector3 from, Vector3 to) //Angulo real entre dos vectores
    {
        Vector3 right = Vector3.right;

        Vector3 dir = to - from;

        float angleBtw = Vector3.Angle(right, dir);
        Vector3 cross = Vector3.Cross(right, dir);
        if (cross.y < 0)
        {
            angleBtw = 360 - angleBtw;
        }

        return angleBtw;
    }
    private void Movement() //Movimiento de la nave
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(h * speed, 0, v * speed);

        Vector3 lastPosition = transform.position;

        Vector3 newPosition = transform.position + movement * Time.deltaTime;

        float newAngleY = GetRealAngle(lastPosition, newPosition);

        Quaternion currentRotation = transform.rotation;
        Quaternion newRotation = Quaternion.Slerp(currentRotation, Quaternion.AngleAxis(newAngleY, Vector3.up),
            rotationSpeed * Time.deltaTime);

        transform.position = newPosition;
        if (h != 0 || v != 0)
        {
            angle = newAngleY;
            transform.rotation = newRotation;
        }
    }
    private void FuelConsumption() //Consume mas combustible cuando la nave se mueve
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            fuel -= rateOfConsuptionMOVING * Time.deltaTime;
        else
            fuel -= rateOfConsumptionIDDLE * Time.deltaTime;
    }
}
