using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarbleFollower : MonoBehaviour
{
    private Transform marble;

    void Awake()
    {
        marble = GameObject.Find("Marble").transform; //assume there's only one marble in scene
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = marble.position;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(this.transform.position, 0.3f);
    }
}
