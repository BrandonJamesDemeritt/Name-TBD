using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotAirBalloon : MonoBehaviour
{

    private float axisY;
    private float axisX;
    private float axisZ;

    private bool isInAir;

    // Start is called before the first frame update
    void Start()
    {
        isInAir = false;
        axisY = this.transform.position.y;
        axisX = this.transform.position.x;
        axisZ = this.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Rise()
    {
        this.transform.position = new Vector3(axisX, axisY + 2, axisZ);
        isInAir = true;
    }//end Rise
}
