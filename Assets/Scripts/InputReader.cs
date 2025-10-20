using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour
{
	public event Action OnShoot;
	public event Action OnDash;

	private Inputs inputs;
	private float2 _move_dir;
	private float2 _mouse_pos;


	void Awake()
	{
		inputs = new Inputs();
		inputs.PlayerInputs.Enable();
	}

	void Start()
	{
		inputs.PlayerInputs.Move.performed += (e) => _move_dir = e.ReadValue<Vector2>();
		inputs.PlayerInputs.Move.canceled += (e) => _move_dir = float2.zero;

		inputs.PlayerInputs.MousePosition.performed += (e) => _mouse_pos = e.ReadValue<Vector2>();

		inputs.PlayerInputs.LMB.performed += _ => OnShoot?.Invoke();
		inputs.PlayerInputs.SPACE.performed += _ => OnDash?.Invoke();

	}




	public float2 GetMoveDirection => _move_dir;
	public float2 GetMousePositionSS => _mouse_pos;

	public float3 GetMousePositionWS => Camera.main.ScreenToWorldPoint(new float3(_mouse_pos.xy, 0.0f));

}
