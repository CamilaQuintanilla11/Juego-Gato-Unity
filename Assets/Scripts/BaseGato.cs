//Camila Quintanilla 
//Valeria Porcayo 
using UnityEngine;

public class BaseGato : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] Material baseMat;
    [SerializeField] Material cuadMat;
    [SerializeField] PhysicsMaterial basePhysic;
    [SerializeField] PhysicsMaterial cuadPhysic;
    void Start()
    {
        MakePiso();
        MakeCuadricula();
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
;   }

    // Update is called once per frame
    void Update()
    {
        
    }
}
