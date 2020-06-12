using UnityEngine;

public class CameraController : MonoBehaviour
{
    //private bool restrictedMovement = true;

    public float panSpeed = 30f;
    public float panBorderThickness = 10f;

    public float scrollSpeed = 5f;
    public float minY = 10f;
    public float maxY = 60f;

    public float minX = 7f;
    public float maxX = 85f;
    public float minZ = -24f;
    public float maxZ = 57f;

    private void Start()
    {
        
    }

    void Update()
    {

        //if (Input.GetKeyDown(KeyCode.Escape)) restrictedMovement = !restrictedMovement;
        //if (!restrictedMovement) return;

        //HandleKeyboard();
        //HandleMouse();
    }

    private void HandleMouse()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 position = transform.position;
        position.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        position.y = Mathf.Clamp(position.y, minY, maxY);
        transform.position = position;

    }

    private void HandleKeyboard()
    {
        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness || Input.GetKey(KeyCode.UpArrow))
        {
            var newPos = Vector3.left * panSpeed * Time.deltaTime;
            transform.Translate(newPos, Space.World);
            transform.position = Clamp();
        }
        else if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness || Input.GetKey(KeyCode.DownArrow))
        {
            var newPos = Vector3.right * panSpeed * Time.deltaTime;
            transform.Translate(newPos, Space.World);
            transform.position = Clamp();
        }
        else if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness || Input.GetKey(KeyCode.RightArrow))
        {
            var newPos = Vector3.forward * panSpeed * Time.deltaTime;
            transform.Translate(newPos, Space.World);
            transform.position = Clamp();
        }
        else if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness || Input.GetKey(KeyCode.LeftArrow))
        {
            var newPos = Vector3.back * panSpeed * Time.deltaTime;
            transform.Translate(newPos, Space.World);
            transform.position = Clamp();
        }
    }

    private Vector3 Clamp()
    {
        Vector3 position = transform.position;
        position.x = Mathf.Clamp(position.x, minX, maxX);
        position.z = Mathf.Clamp(position.z, minZ, maxZ);
        return position;
    }

}
