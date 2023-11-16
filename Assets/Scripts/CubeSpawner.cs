using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using Random = UnityEngine.Random;

public class CubeSpawner : MonoBehaviour
{
    public BallController BallController;
    public GameObject PanelDelJuego;
    public GameObject PanelWin;
    public int NumeroDeEnemigosMaximo;
    public int NumeroDeEnemigosMinimo;
    public int limiteDexMaximo;
    public int limiteDezMaximo;
    public GameObject[] Enemigos;
    public int TiempoMaximo;
    public int TiempoMinimo;
    private int MaximosEnemigosgeneral;
    
    public int RondasMaximas;
    private int ContadorDeRondas=0;
    private int NumeroIntentos=0;
    private void Start()
    {
        Invoke("GenerarEnemigos", Random.Range(TiempoMaximo, TiempoMinimo));
        PanelDelJuego.SetActive(true);
        PanelWin.SetActive(false);
    }
    void GenerarEnemigos()
    {
        if(BallController.count<MaximosEnemigosgeneral)
        {
            int EnemigoAleatorio = Random.Range(0, Enemigos.Length - 1);
            Vector3 posicionAleatoria = PosicionAleatoria();
            Collider[] hitColliders = Physics.OverlapSphere(Enemigos[EnemigoAleatorio].transform.position,0f);
            if (hitColliders.Length > 0)
            {
                NumeroIntentos += 1;
                Invoke("GenerarEnemigos", 0);
                if(NumeroIntentos >MaximosEnemigosgeneral*100)
                {
                    BallController.count = MaximosEnemigosgeneral; 
                }
            }
            else
            {
                Instantiate(Enemigos[EnemigoAleatorio], posicionAleatoria, Enemigos[EnemigoAleatorio].transform.rotation);
                Invoke("GenerarEnemigos",Random.Range(TiempoMinimo, TiempoMaximo));
            }
        }
        else
        {
            if (ContadorDeRondas == RondasMaximas)
            {
                PanelWin.SetActive(true);
                PanelDelJuego.SetActive(false);
                Time.timeScale = 0;
            }
            else
            {
                ContadorDeRondas += 1;
                MaximosEnemigosgeneral += 5;
                foreach (GameObject Objetos in Coleccionables)
                {
                    Objetos.transform.position = PosicionAleatoria();
                    Objetos.SetActive(true);
                }
            }
        }
    }
    private Vector3 PosicionAleatoria()
    {
        return new Vector3(Random.Range(limiteDexMaximo, -limiteDexMaximo), Random.Range(0f,1.25f), Random.Range(limiteDezMaximo, -limiteDexMaximo));
    }


}
