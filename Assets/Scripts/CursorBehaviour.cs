using Unity.Mathematics;
using UnityEngine;

public class CursorBehaviour : MonoBehaviour
{
    Transform t_cache;


    void Awake()
    {
        t_cache = transform;
    }
    void Update()
    {
        t_cache.position = new float3(Resources.GetInputReader.GetMousePositionWS.xy, 0f);
    }
}
