using Unity.Mathematics;
using UnityEngine;

public class Player : MonoBehaviour
{
	Transform t_cache;
	Transform p_hand;
	Rigidbody2D rb;
	TrailRenderer tr;

	[SerializeField] float speed;
	[SerializeField] float h_offset;

	[SerializeField] float dash_speed;
	[SerializeField] float dash_duration;
	[SerializeField] float dash_cooldown;
	public bool dashing;

	float timer;

	float2 dir;
	float2 velocity;
	float2 player_pos;

	float3 FLIP;


	void Awake()
	{
		t_cache = transform;
		rb = GetComponent<Rigidbody2D>();
		tr = GetComponent<TrailRenderer>();
		p_hand = transform.GetChild(0);
		FLIP = new float3(1f, -1f, 1f);
		dashing = false;
	}

	void Start()
	{
		Resources.GetInputReader.OnDash += DashAbility;
		timer = 0;
	}

	public void SetVelocity(float2 v) => rb.linearVelocity = v;

	void Update()
	{
		dir = Resources.GetInputReader.GetMoveDirection;
		velocity = speed * math.normalizesafe(dir);

		dashing = timer > 0f;

		if (dashing)
		{
			timer -= Time.deltaTime;
		}
		else
		{
			tr.emitting = false;
			SetVelocity(velocity);
		}





		// DIRECTION
		player_pos.x = t_cache.position.x;
		player_pos.y = t_cache.position.y;


		float2 look_dir = math.normalizesafe(Resources.GetInputReader.GetMousePositionWS.xy - player_pos);
		float rad_angle = math.atan2(look_dir.y, look_dir.x);
		float2 hand_direction = new float2(math.cos(rad_angle), math.sin(rad_angle));
		p_hand.position = new float3(player_pos + hand_direction * h_offset, 0f);
		p_hand.localRotation = quaternion.EulerXYZ(0f, 0f, rad_angle);
		float angle = math.degrees(rad_angle);

		if (angle > 90f && angle < 180f || angle > -179f && angle < -90f)
		{
			p_hand.GetComponent<SpriteRenderer>().flipY = true;
		}
		else
		{
			p_hand.GetComponent<SpriteRenderer>().flipY = false;
		}

	}

	void DebugInput()
	{
		Debug.Log("PRESSED");
	}
	void DashAbility()
	{

		tr.emitting = true;
		timer = dash_duration;
		float2 velocity = dir * dash_speed;
		SetVelocity(velocity);
	}

	public float3 GetPosition => t_cache.position;
}
