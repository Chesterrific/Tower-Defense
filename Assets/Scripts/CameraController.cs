using UnityEngine;

public class CameraController : MonoBehaviour {

    private bool doMovement = true;

    public float panSpeed = 30f;
    public float panBorderThickness = 10;
    public float scrollSpeed = 5f;
    public float minY = 10f;
    public float maxY = 80f;

    // Update is called once per frame
    void Update() {

        if (GameManager.GameIsOver)
        {
            this.enabled = false;
            return;
        }

        //enables or disables movement.
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            doMovement = !doMovement;
        }
        //checks if movement has been set to disabled.
        if (!doMovement)
        {
            return;
        }
        //up (mouse movement with commented code)
        if (Input.GetKey("w") /*|| Input.mousePosition.y >= Screen.height - panBorderThickness*/)
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World); //Vector3.forward = new Vector3(0f, 0f, 1f)
            //space.world ignores object rotation and uses global directions.
        }
        //down
        if (Input.GetKey("s") /*|| Input.mousePosition.y <= panBorderThickness*/)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World); //Vector3.back = new Vector3(0f, 0f, -1f)
        }
        //left
        if (Input.GetKey("a") /*|| Input.mousePosition.x <= panBorderThickness*/)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World); //Vector3.left = new Vector3(-1f, 0f, 0f)
        }
        //right
        if (Input.GetKey("d") /*|| Input.mousePosition.x >= Screen.width - panBorderThickness*/)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World); //Vector3.right = new Vector3(1f, 0f, 0f)
        }
        //mouse scrolling
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 pos = transform.position;

        pos.y -= scroll * 700 * scrollSpeed * Time.deltaTime;
        //scroll input is small, 1000 for scroll speed increase.
        //scrolling up is positive, y is subtracted and we zoom in.
        //scrolling down is negative, y = y - (-pos) adds pos and we zoom out.

        pos.y = Mathf.Clamp(pos.y, minY, maxY); //clamps pos.y between minY and maxY.
        transform.position = pos;
    }
}

