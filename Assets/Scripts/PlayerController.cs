using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        for (int i = 0; i < Input.touchCount; i++)
        {

            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.touches[i].position);

            if (i == 0)
            {
                transform.LookAt(touchPosition, Vector3.forward);
            }
        }
    }
}
