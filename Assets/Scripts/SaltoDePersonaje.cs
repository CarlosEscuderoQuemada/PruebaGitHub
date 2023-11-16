using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaltoDePersonaje : MonoBehaviour
{
    public BallController ballController;
    private void FixedUpdate()
    {
        if (Input.GetButtonDown("Space") && ballController.enSuelo == true)
        {
            ballController.enSuelo = false;
            ballController.rb.AddForce(ballController.ForceReference.up * ballController.FuerzaDeSalto);
        }
    }
}
