using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeModel : MonoBehaviour
{
    public float speed = 5f;
    public float holeHeight = 4f;
    public float timeSpawn = 3f;

    public float maxHeightPipe = 3f;
    public float minHeightPipe = 1f;

    [Header("Смещение для координат, необходимых для расстановки труб ")]
    public float offset = 0.5f;
    [HideInInspector]
    public float posStartYUp = 5f;
    [HideInInspector]
    public float posStartYDown = -3.92f;


    public GameObject pipes;

}
