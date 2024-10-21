using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    public Animator switch_;
    public bool inReach;
    // Start is called before the first frame update
    void Start()
    {
        inReach = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            Debug.Log("In Reach");
            inReach = true;
        }
    }
    void OnTriggerExit(Collider other)
    {

        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (inReach && Input.GetButtonDown("Click"))
        {
            SwitchOn();
        }
        else
        {
            SwitchOff();
        }
    }
    void SwitchOn()
    {
        switch_.SetBool("on", true);
        switch_.SetBool("off", false);
    }

    void SwitchOff()
    {
        switch_.SetBool("off", true);
        switch_.SetBool("on", false);
    }
}
