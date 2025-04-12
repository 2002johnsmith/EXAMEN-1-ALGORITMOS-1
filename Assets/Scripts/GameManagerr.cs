using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using ListaDoble;
using static GameManagerr;

public class GameManagerr : MonoBehaviour
{
    ListaDoblemeneteEnlazada<int> listadoble = new ListaDoblemeneteEnlazada<int>();

    private int turno = 1;
    [Title("Estadísticas para John")]
    public float nuevaVida = 0f;
    public float nuevaEnergia = 0f;
    public John johnPlayer;
    private int turnosMovidos = 0;

    void Start()
    {
    }
    void Update()
    {
    }
    [Button("Añade un turno")]
    public void Añade()
    {
        if (johnPlayer.Vida > 0)
        {
            if (listadoble.Peak != listadoble.lastNode)
            {
                listadoble.EliminarNodosDespuesDePeak();
            }

            listadoble.Añade(turno);
            print("Turno añadido: " + turno);

            turno++;
        }
        else
        {
            Debug.Log("No cuentas con vida se acabo el juego y no puede agregar mas turnos");
        }
    }

    public enum OpcionMovimiento
    {
        Adelante,
        Atras
    }
    public OpcionMovimiento opcionMovimiento;
    [Button("Mover jugador")]
    public void MoverJugador()
    {
        if (johnPlayer.Vida > 0)
        {
            switch (opcionMovimiento)
            {
                case OpcionMovimiento.Adelante:
                    MoverAdelante();
                    turnosMovidos++;
                    AplicarDañoRandom();
                    break;
                case OpcionMovimiento.Atras:
                    MoverAtras();
                    turnosMovidos++;
                    AplicarDañoRandom();
                    break;
            }
        }
        else
        {
            Debug.Log("No cuentas con vida se acabo el juego y no puede agregar mas turnos");
        }
    }
    [Button("Aumentar Vida y Energía")]
    public void AumentarVidaEnergia()
    {
        if (johnPlayer.Vida > 0)
        {
            if (turnosMovidos >= 2)
            {
                johnPlayer.AumentarVidaEnergiaRandom();
                turnosMovidos = 0;
            }
            else
            {
                Debug.Log("No te has movido lo suficiente para recuperar energía y vida.");
            }
        }
        else
        {
            Debug.Log("No cuentas con vida se acabo el juego y no puede agregar mas turnos");
        }
    }

    [Button("Actualizar Estadísticas de John")]
    public void ActualizarEstadisticas()
    {
        if (johnPlayer != null)
        {
            johnPlayer.CambiarVida(nuevaVida);
            johnPlayer.CambiarEnergia(nuevaEnergia);
            Debug.Log("Se actualizaron las estadísticas de John");
        }
        else
        {
            Debug.LogWarning("No se encontró a John en la escena.");
        }
    }
    [Button("Mostrar Estadísticas")]
    public void MostrarEstadísticas()
    {
        if (johnPlayer != null)
        {
            Debug.Log("Posición de John: "+listadoble.Peak.value );
            Debug.Log("Vida de John: "+johnPlayer.Vida);
            Debug.Log("Energía de John: "+johnPlayer.Energia);
        }
        else
        {
            Debug.LogWarning("John Player no está asignado.");
        }
    }
    [Button("Resetear Juego")]
    public void ResetearJuego()
    {
        johnPlayer.ResetearEstadisticas();

        listadoble.ResetearLista();

        turno = 1;

        Debug.Log("¡Juego reseteado correctamente!");
    }

    public void MoverAdelante()
    {
        listadoble.MoverAdelante();  
    }
    public void MoverAtras()
    {
        listadoble.MoverAtras();  
    }
    private void AplicarDañoRandom()
    {
        if (johnPlayer != null)
        {
            int dañoVida = UnityEngine.Random.Range(1, 11);    
            int dañoEnergia = UnityEngine.Random.Range(1, 11); 

            johnPlayer.CambiarVida(johnPlayer.Vida - dañoVida);
            johnPlayer.CambiarEnergia(johnPlayer.Energia - dañoEnergia);

            Debug.Log("Recibiste " +dañoVida+" de daño a la vida y "+ dañoEnergia +" de daño a la energía.");
            if (johnPlayer.Vida <= 0)
            {
                Debug.Log("¡Game Over! Has perdido toda tu vida.");
            }
        }
    }
}
