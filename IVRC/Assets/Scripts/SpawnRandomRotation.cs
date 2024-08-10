using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRandomRotation : MonoBehaviour
{
    // Start is called before the first frame update
    private float yRotation;

    void Start()
    {
        yRotation = Random.Range(0, 360);
        transform.rotation = Quaternion.Euler(0f, yRotation, 0f); // yé≤Ç10ÅãÇ…ê›íË
    }

    // Update is called once per frame
    void Update()
    {

    }
}
