using TMPro;
using UnityEngine;

public class Resources : MonoBehaviour
{
    [SerializeField]
    private CursorBehaviour cursor_ref;

    public static Resources Instance;
    private InputReader _input_reader;
    private CursorBehaviour cursor;


    void Awake()
    {
        Resources.Instance = this;
        _input_reader = GetComponent<InputReader>();


        cursor = Instantiate(cursor_ref);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }


    public static InputReader GetInputReader => Instance._input_reader;
}
