using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KontrolaIgre : MonoBehaviour
{
    public GameObject loptaPrefab;
    public float brzinaLopte;
    GameObject loptaInstance;
    Vector3 mousePocetak;
    Vector3 mouseKraj;

    float minPomak = 15f;
    float zDubina = 25f;

    void Start()
    {
        CreateLopta();    
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mousePocetak = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0))
        {
            mouseKraj = Input.mousePosition;
            if (Vector3.Distance(mouseKraj, mousePocetak) > minPomak)
            {
                Vector3 hitPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, zDubina);
                hitPos = Camera.main.ScreenToWorldPoint(hitPos);
                loptaInstance.transform.LookAt(hitPos);
                loptaInstance.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * brzinaLopte, ForceMode.Impulse);
                Invoke("CreateLopta", 2f);
            }
        }
    }
    void CreateLopta()
    {
        loptaInstance = Instantiate(loptaPrefab, loptaPrefab.transform.position, Quaternion.identity) as GameObject;
    }
}
