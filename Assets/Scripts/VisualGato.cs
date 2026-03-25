//Camila Quintanilla 
//Valeria Porcayo 
using UnityEngine;

public class VisualGato : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] Material baseMat;
    [SerializeField] Material cuadMat;
    [SerializeField] PhysicsMaterial basePhysic;
    [SerializeField] PhysicsMaterial cuadPhysic;
    public GameObject Circulo;
    public GameObject Cruz;
    public LogicGato logicg;

    Vector3[] centros = new Vector3[9];
    void Start()
    {
        MakePiso();
        MakeCuadricula();
        guardarCentros();
        logicg.logicGato();
        visualGato();
    }

    void MakePiso()
    {
        GameObject piso = GameObject.CreatePrimitive(PrimitiveType.Cube);
        piso.transform.position = new Vector3(0, 0.125f, 0);
        piso.transform.localScale = new Vector3(8,0.25f,8);

        Rigidbody rb = piso.AddComponent<Rigidbody>();
        rb.isKinematic = true;

        MeshRenderer mr = piso.GetComponent<MeshRenderer>();
        mr.material = baseMat;

        Collider colp = piso.GetComponent<Collider>();
        colp.material = basePhysic;
    }
    void MakeLineas(Vector3 pos, Vector3 lscale)
    {
        GameObject linea = GameObject.CreatePrimitive(PrimitiveType.Cube);
        linea.transform.position = pos;
        linea.transform.localScale = lscale;

        Rigidbody rb = linea.AddComponent<Rigidbody>();
        rb.isKinematic = true;

        MeshRenderer mrl = linea.GetComponent<MeshRenderer>();
        mrl.material = cuadMat;

        Collider col = linea.GetComponent<Collider>();
        col.material = cuadPhysic;

    }
    void MakeCuadricula()
    {
        MakeLineas(new Vector3(-1.5f, 0.25f, 0), new Vector3(0.2f, 0.25f, 8));
        MakeLineas(new Vector3(1.5f, 0.25f, 0), new Vector3(0.2f, 0.25f, 8));
        MakeLineas(new Vector3(0, 0.25f, -1.5f), new Vector3(8, 0.25f, 0.2f));
        MakeLineas(new Vector3(0, 0.25f, 1.5f), new Vector3(8, 0.25f, 0.2f));
   }
    void visualGato()
    {
        Debug.Log("VisualGato funcionando");
        for (int i = 0; i < logicg.totalTurnos; i++)
        {
            Debug.Log("jugada: " + logicg.secuencia[i]);
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
