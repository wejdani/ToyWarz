using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class halo : MonoBehaviour
{

    float i;
    public Light light; 
    // public float multiplier; 


    // Use this for initialization
    void Start()
    {
        light = GetComponent<Light>();
        //StartCoroutine("WaitThreeSeconds");

    }

    // Update is called once per frame
    void Update()
    {
        dim();

    }

    void dim(){
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //light.range -= 1;
            for (i = 10; i <= 1; i--)
            {

                light.range = i;
                //RenderSettings.haloStrength -= (float)0.1;
                StartCoroutine("WaitThreeSeconds");
                Debug.Log(i + "light range" + light.range);
            }
            // RenderSettings.haloStrength -= 1;
        }
    }
    IEnumerator WaitThreeSeconds()
    {

   

        Debug.Log("wait..");
        yield return new WaitForSeconds(3);
    }
}