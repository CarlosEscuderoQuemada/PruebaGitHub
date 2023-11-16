using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class RotadorDelSeguidorDeCamaraYCamara : MonoBehaviour
{
    private float Yrotation;
    private float Xrotation;
    public float SensX;
    public float SensY;
    public GameObject orientation;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X")*Time.deltaTime*SensX;
        float mouseY = Input.GetAxisRaw("Mouse Y")*Time.deltaTime *SensY;

        Yrotation += mouseX;
        Xrotation -= mouseY;
        Xrotation = Mathf.Clamp(Xrotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(Xrotation,Yrotation,0);
        orientation.transform.rotation=Quaternion.Euler(0,Yrotation,0);
    }
}
