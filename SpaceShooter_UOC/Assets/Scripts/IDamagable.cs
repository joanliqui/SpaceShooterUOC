using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagable 
{
    public void Damaged(int damage);

    public void Destroyed();
}
