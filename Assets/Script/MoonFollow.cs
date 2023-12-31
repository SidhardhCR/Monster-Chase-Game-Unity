using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonFollow : MonoBehaviour
{
    [SerializeField]
    private float pos;
    [SerializeField]
    private float minX, maxX;

    private Transform player;
    private Vector3 tempPos;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {   
        if(!player) return;

        tempPos = transform.position;
        tempPos.x = player.position.x + pos;
        if (tempPos.x < minX)
            tempPos.x = minX;
        if (tempPos.x > maxX)
            tempPos.x = maxX;
        transform.position = tempPos;
    }
}
