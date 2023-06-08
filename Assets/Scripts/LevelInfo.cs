using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelInfo", menuName = "ScObj/New LevelInfo")]
public class LevelInfo : ScriptableObject
{
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _holeHeight;
    [SerializeField]
    private float _timeSpawn;

    public float speed => _speed;
    public float holeHeight => _holeHeight;
    public float timeSpawn => _timeSpawn;

}
