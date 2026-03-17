using UnityEngine;

public class VisualGato : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject Circulo;
    public GameObject Cruz;
    public LogicGato logicg;

    Vector3[] centros = new Vector3[9];
    void Start()
    {
        visualGato();
        guardarCentros();
    }
    void visualGato()
    {
        for (int i = 0; i < 8; i++)
        {
            int cuadrito = logicg.secuencia[i];

            Vector3 pos = centros[cuadrito];

            GameObject ficha;

            if (i % 2 == 0)
            {
                ficha = Cruz;
            } else
            {
                ficha = Circulo;
            }

            Instantiate(ficha, pos, Quaternion.identity);
        }
    }
    void guardarCentros()
    {
        float comp = 2.5f;
        float paso = 2.5f;

        int index = 0;

        for (int fila = 0; fila < 3; fila++)
        {
            for (int col = 0; col < 3; col++)
            {
                float x = -comp + col*paso;
                float z = -comp + fila*paso;

                centros[index] = new Vector3 (x,3,z);
                index++;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
