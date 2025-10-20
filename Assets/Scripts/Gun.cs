using UnityEngine;
using Unity.Mathematics;

public class Gun : MonoBehaviour
{
	Transform t_cache;
	Transform bullet_spawn;
	void Awake()
	{
		t_cache = transform;
		bullet_spawn = transform.GetChild(0);
	}

	public float3 GetPosition => t_cache.position;
	public float3 GetBulletSpawn => bullet_spawn.position;
}
