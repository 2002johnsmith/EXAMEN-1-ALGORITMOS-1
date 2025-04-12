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
    [Title("Estad�sticas para John")]
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
    [Button("A�ade un turno")]
    public void A�ade()
    {
        if (johnPlayer.Vida > 0)
        {
            if (listadoble.Peak != listadoble.lastNode)
            {
                listadoble.EliminarNodosDespuesDePeak();
            }

            listadoble.A�ade(turno);
            print("Turno a�adido: " + turno);

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
                    AplicarDa�oRandom();
                    break;
                case OpcionMovimiento.Atras:
                    MoverAtras();
                    turnosMovidos++;
                    AplicarDa�oRandom();
                    break;
            }
        }
        else
        {
            Debug.Log("No cuentas con vida se acabo el juego y no puede agregar mas turnos");
        }
    }
    [Button("Aumentar Vida y Energ�a")]
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
                Debug.Log("No te has movido lo suficiente para recuperar energ�a y vida.");
            }
        }
        else
        {
            Debug.Log("No cuentas con vida se acabo el juego y no puede agregar mas turnos");
        }
    }

    [Button("Actualizar Estad�sticas de John")]
    public void ActualizarEstadisticas()
    {
        if (johnPlayer != null)
        {
            johnPlayer.CambiarVida(nuevaVida);
            johnPlayer.CambiarEnergia(nuevaEnergia);
            Debug.Log("Se actualizaron las estad�sticas de John");
        }
        else
        {
            Debug.LogWarning("No se encontr� a John en la escena.");
        }
    }
    [Button("Mostrar Estad�sticas")]
    public void MostrarEstad�sticas()
    {
        if (johnPlayer != null)
        {
            Debug.Log("Posici�n de John: "+listadoble.Peak.value );
            Debug.Log("Vida de John: "+johnPlayer.Vida);
            Debug.Log("Energ�a de John: "+johnPlayer.Energia);
        }
        else
        {
            Debug.LogWarning("John Player no est� asignado.");
        }
    }
    [Button("Resetear Juego")]
    public void ResetearJuego()
    {
        johnPlayer.ResetearEstadisticas();

        listadoble.ResetearLista();

        turno = 1;

        Debug.Log("�Juego reseteado correctamente!");
    }

    public void MoverAdelante()
    {
        listadoble.MoverAdelante();  
    }
    public void MoverAtras()
    {
        listadoble.MoverAtras();  
    }
    private void AplicarDa�oRandom()
    {
        if (johnPlayer != null)
        {
            int da�oVida = UnityEngine.Random.Range(1, 11);    
            int da�oEnergia = UnityEngine.Random.Range(1, 11); 

            johnPlayer.CambiarVida(johnPlayer.Vida - da�oVida);
            johnPlayer.CambiarEnergia(johnPlayer.Energia - da�oEnergia);

            Debug.Log("Recibiste " +da�oVida+" de da�o a la vida y "+ da�oEnergia +" de da�o a la energ�a.");
            if (johnPlayer.Vida <= 0)
            {
                Debug.Log("�Game Over! Has perdido toda tu vida.");
            }
        }
    }
}
