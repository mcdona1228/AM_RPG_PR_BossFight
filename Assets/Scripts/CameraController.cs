using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        // does the player exist?
        if (PlayerController.me != null && !PlayerController.me.dead)
        {
            Vector3 targetPos = PlayerController.me.transform.position;
            targetPos.z = -10;
            transform.position = targetPos;
        }
    }
}
