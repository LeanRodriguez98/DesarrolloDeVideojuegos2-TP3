using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{

    public static Ship instance;

    public float speed = 10;
    public float rotationSpeed = 10;
    public float angle;
    public float fuel = 100;
    public float consumptionIDDLE = 1;
    public float consuptionMOVING = 2.5f;
    public Camera mainCamera;
    public float distanceTarget = 5;
    public float offset_X = 2;

    [HideInInspector] public bool stopPlanets = false;
    private Vector3 cameraPos;
    private Quaternion cameraRot;

    private void Awake()
    {
        instance = this;
        cameraPos = mainCamera.transform.position;
        cameraRot = mainCamera.transform.rotation;
    }

    void Update()
    {
        if (!instance.stopPlanets)
        {
            Movement();
            FuelConsumption();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            instance.stopPlanets = false;
            mainCamera.transform.position = cameraPos;
            mainCamera.transform.rotation = cameraRot;
        }

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
            fuel -= consuptionMOVING * Time.deltaTime;
        else
            fuel -= consumptionIDDLE * Time.deltaTime;
    }

    private void OnTriggerStay(Collider other)
    {
       

        if (other.gameObject.CompareTag("m_Planet"))
        {
            Renderer otherRend = other.gameObject.GetComponent<Renderer>();
            otherRend.material.shader = Shader.Find("ShaderPiola"); //Hacer un buen shader en algun momento
           
            if (Input.GetKeyDown(KeyCode.Q))
            {
                
                 
                 
                instance.stopPlanets = true;
                mainCamera.transform.rotation = other.transform.rotation;

                float otherX = other.transform.position.x - offset_X;
                float otherY = other.transform.position.y;
                float otherZ = other.transform.position.z - distanceTarget;

                Vector3 otherPos = new Vector3(otherX, otherY, otherZ);
                mainCamera.transform.position = otherPos;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("m_Planet"))
        {
            Renderer otherRend = other.gameObject.GetComponent<Renderer>();
            otherRend.material.shader = Shader.Find("Standard");
        }
    }
}

