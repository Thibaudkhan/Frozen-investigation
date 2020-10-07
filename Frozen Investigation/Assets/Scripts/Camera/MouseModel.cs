using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseModel : MonoBehaviour
{
    public float MouseSensivity
    {
        get
        {
            Debug.Log(this.mouseSensivity);
            return this.mouseSensivity;
        }
        set
        {
            this.mouseSensivity = 100f;
        }
    }

    private float mouseSensivity;

    private void Awake()
    {
        this.mouseSensivity = 300f;
    }
}
