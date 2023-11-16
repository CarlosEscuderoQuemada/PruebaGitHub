using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonesDeEscenas : MonoBehaviour
{
    public void SalirAlEscritorio()
    {
        Application.Quit();
    }
    public void IrAlJuego()
    {
        SceneManager.LoadScene(0);
    }
}
