using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPatten : MonoBehaviour
{
    public StartUIManager manager;

    void Update()
    {
        Vector3 nextPos = transform.localPosition;

        if (nextPos.y <= -5.5f)
        {
            nextPos.x = 0;
            nextPos.y += 12f;
            transform.localPosition = nextPos;
        }

        nextPos.x -= manager.patternSpeed/2 * Time.deltaTime;
        nextPos.y -= manager.patternSpeed * Time.deltaTime;


        transform.localPosition = nextPos;
    }
}
