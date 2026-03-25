//Camila Quintanilla 
//Valeria Porcayo 
using UnityEngine;
using System.Collections.Generic;

public class LogicGato : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int[] secuencia = new int[9];
    public char[] tablero = new char[9];
    public int totalTurnos;
    void Start()
    {
        logicGato();
    }
    public void logicGato()
    {
        List<int> disponibles = new List<int>();


        for (int i = 0; i < 9; i++)
        {
            disponibles.Add(i);
            tablero[i] = '-';
        }
        int turno = 0;
        char jugador = 'X';

        while (disponibles.Count > 0)
        {
            int mirandom = Random.Range(0, disponibles.Count);
            int jugada = disponibles[mirandom];

            secuencia[turno] = jugada;
            tablero[jugada] = jugador;

            disponibles.RemoveAt(mirandom);
             
            if (Gano(jugador))
            {
                totalTurnos = turno + 1;
                return;
            }
            jugador = (jugador == 'X') ? 'O' : 'X';
            turno ++;
        }
        totalTurnos = turno;
        
    }
    bool Linea(int a, int b, int c, char j)
    {
        return tablero[a] == j && tablero[b] == j && tablero[c] == j;
    }

    bool Gano(char j)
{
    return
        // filas
        Linea(0,1,2,j) ||
        Linea(3,4,5,j) ||
        Linea(6,7,8,j) ||

        // columnas
        Linea(0,3,6,j) ||
        Linea(1,4,7,j) ||
        Linea(2,5,8,j) ||

        // diagonales
        Linea(0,4,8,j) ||
        Linea(2,4,6,j);
}
    // Update is called once per frame
    void Update()
    {
        
    }
}
