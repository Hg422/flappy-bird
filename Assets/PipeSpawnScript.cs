using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{

    public GameObject Pipe;
    public float spawnRate = 3;
    private float timer = 0;
    public float heightOffset = 7;
    private float levelSteps = 15;
    private float level = 0;
    private float i = 0;

    // Start is called before the first frame update
    void Start()
    {
        spawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer < spawnRate)
        {
            timer += Time.deltaTime;
            timer += (level * (float) 0.001);
            i++;
            if(i == levelSteps)
            {
                if(level < 5 && heightOffset > 2)
                {
                    level++;
                    heightOffset--;
                }
            }
        } else
        {
            spawnPipe();
            timer = 0;
        }
    }

    void spawnPipe()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;
        Instantiate(Pipe, new Vector3(transform.position.x, Random.Range(lowestPoint,highestPoint), 0), transform.rotation);
    }
}
