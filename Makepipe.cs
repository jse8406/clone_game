using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Makepipe : MonoBehaviour
{
    public float timediff;
    public GameObject pipe;
    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > timediff){
            GameObject newpipe = Instantiate(pipe);
            newpipe.transform.position = new Vector3(8.2f,Random.Range(-1.7f, 5.7f),0);
            timer = 0;
            Destroy(newpipe, 5.0f);
        }
    }
}
