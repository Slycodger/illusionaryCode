using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolSwitch : MonoBehaviour
{   
    [Header("Outside variables")]
    [Tooltip("Objects to switch between")]
    public List<GameObject> Objects;
    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject ob in Objects)
        {
            ob.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            Objects[0].SetActive(true);
            Objects[1].SetActive(false);
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            Objects[0].SetActive(false);
            Objects[1].SetActive(true);
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            Objects[0].SetActive(false);
            Objects[1].SetActive(false);
        }
    }
}
