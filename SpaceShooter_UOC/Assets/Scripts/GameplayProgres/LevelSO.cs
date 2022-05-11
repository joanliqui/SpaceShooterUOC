using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="LevelX", menuName = "Levels")]
public class LevelSO : ScriptableObject
{
    public List<Round> rounds;
}
