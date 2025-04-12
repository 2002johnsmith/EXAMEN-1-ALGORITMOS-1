using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
public interface IEntity
{
    float Vida { get; set; }
    float Energia { get; set; }

    void CambiarVida(float nuevaVida);
    void CambiarEnergia(float nuevaEnergia);
}
public class John : MonoBehaviour,IEntity
{
    public float Vida { get; set; }
    public float Energia { get; set; }

    public John()
    {
        Vida = 0f;  
        Energia = 0f;  
    }
    void Start()
    {
    }
    public void AumentarVidaEnergiaRandom()
    {
        int vidaRandom = UnityEngine.Random.Range(1, 6);
        int energiaRandom = UnityEngine.Random.Range(1, 6);

        CambiarVida(Vida + vidaRandom);
        CambiarEnergia(Energia + energiaRandom);

        Debug.Log("Vida aumentada en "+vidaRandom+" y energía aumentada en "+energiaRandom+".");
    }
    public void ResetearEstadisticas()
    {
        Vida = 100f;
        Energia = 100f;
    }
    public void CambiarVida(float nuevaVida)
    {
        Vida = Mathf.Clamp(nuevaVida, 0f, 100f);  
    }

    public void CambiarEnergia(float nuevaEnergia)
    {
        Energia = Mathf.Clamp(nuevaEnergia, 0f, 100f);  
    }
}
