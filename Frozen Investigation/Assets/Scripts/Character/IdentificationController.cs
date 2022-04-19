using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdentificationController : PlayerController
{
    [SerializeField] GameObject interaction;
    //private string[] shop = {"Weapon","Food"};

    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnTriggerStay(Collider other)
    {

        if (other.gameObject.tag != "Player")
        {
            interaction.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {

                Debug.Log("are interactiong " );
                GetInteraction(other.gameObject,true);
            }

        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag != "Player")
        {
            Debug.Log("bye");
            interaction.SetActive(false);

        }
    }

    private void GetInteraction(GameObject object_name, bool isInteracting)
    {
  
    }


}
