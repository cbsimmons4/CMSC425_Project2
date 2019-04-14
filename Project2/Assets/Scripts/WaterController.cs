using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterController : MonoBehaviour
{
    //Ideas come from water turtorial linked in project description

    public float waterLevel;
    private bool isUnderWater;
    // Start is called before the first frame update
    void Start()
    {
        RenderSettings.fog = true;
        RenderSettings.fogDensity = 0;
        RenderSettings.fogColor = new Color(0.22f, 0.65f, 0.77f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < waterLevel)
        {
            if (!isUnderWater)
            {
                RenderSettings.fogDensity = 0.1f;
                isUnderWater = !isUnderWater;
            }

        }
        else
        {
            if (isUnderWater) {
                RenderSettings.fogDensity = 0.0f;
                isUnderWater = !isUnderWater;
            }

        }
    }


}
