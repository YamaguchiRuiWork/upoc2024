using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRandomRotation : MonoBehaviour
{
    // Start is called before the first frame update
    private float yRotation;
    private float RandomScale;
    private float PosX;

    void Start()
    {
        PosX = transform.position.x;
        if (PosX < -2)
        {
            yRotation = Random.Range(180, 270);
        }
        else if (PosX >= -2 && PosX < 3.5)
        {
            yRotation = Random.Range(135, 225);
        }
        else
        {
            yRotation = Random.Range(90, 180);
        }
        //yRotation = Random.Range(0, 180);
        RandomScale = Random.Range(0.7f, 1.2f);
        transform.rotation = Quaternion.Euler(0f, yRotation, 0f); // yŽ²‚ð10‹‚ÉÝ’è
        transform.localScale = Vector3.one * RandomScale;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
