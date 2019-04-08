using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoreCubes : MonoBehaviour {


    public GameObject prefabCubes;

    public void Cube()
    {
        Instantiate(prefabCubes);
    }

}
