using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBullet : BaseBullet
{
    
    
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

}
