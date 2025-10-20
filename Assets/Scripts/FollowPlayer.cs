using Unity.Mathematics;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] Player p;
    Transform t_cache;
    float3 camera_offset;

    void Awake()
    {
        camera_offset = new float3(0f, 0f, -10f);
        t_cache = transform;
    }

    void Update()
    {
        if (!p) return;
        t_cache.position = p.GetPosition + camera_offset;
    }
}
