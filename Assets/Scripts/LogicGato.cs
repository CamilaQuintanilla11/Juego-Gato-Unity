//Camila Quintanilla 
//Valeria Porcayo 
using UnityEngine;
using System.Collections.Generic;

public class LogicGato : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int[] secuencia = new int[9];
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
        }
        int turno = 0;

        while (disponibles.Count > 0)
        {
            int mirandom = Random.Range(0, disponibles.Count);
            int jugada = disponibles[mirandom];

            secuencia[turno] = jugada;

            disponibles.RemoveAt(mirandom);
            turno++;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
