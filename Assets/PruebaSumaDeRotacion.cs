using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PruebaSumaDeRotacion : MonoBehaviour
{
    [SerializeField] Transform Padre; 
    [SerializeField] Transform HijoI; 
    [SerializeField] Transform HijoD;
    [SerializeField] Transform Hijo3;
    Quaternion quaternionHijoI;
    Quaternion quaternionHijoD;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        quaternionHijoI = HijoI.rotation;
        quaternionHijoD = HijoD.rotation;
        Padre.rotation = quaternionHijoD * quaternionHijoI;

        Vector3 x = Padre.rotation.eulerAngles;
        .x = x.x >= 180 && x.x <= 50 ?  50 : x.x <= 180 && x.x >= 310 ? 310 : x.x ;
        x.z = x.z >= 180 && x.z <= 50 ?  50 : x.z <= 180 && x.z >= 310 ? 310 : x.z ;
        x.z = x.z <= 50 ?  x.z : 50;
        Vector3 x = Padre.rotation.eulerAngles;

        Padre.rotation = Padre.rotation.eulerAngles != x ? Quaternion.Euler(x) : Padre.rotation;

        HijoI.rotation = Quaternion.Euler(new Vector3(0, 0, x.x));
        HijoD.rotation = Quaternion.Euler(new Vector3(0, 0, x.x));
        Hijo3.rotation = Quaternion.Euler(new Vector3(-x.z, 0, 0));
    }
}
