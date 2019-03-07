using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionManager : MonoBehaviour
{
    private bool isBody;
    private Vector3 current_location;
    private Vector3 last_location;

    // Start is called before the first frame update
    void Start()
    {
        isBody = false;
        current_location = new Vector3();
        last_location = new Vector3();
    }

    public bool GetIsBody()
    {
        return isBody;
    }

    public void SetIsBody(bool init_is_body)
    {
        isBody = init_is_body;
    }

    public Vector3 GetCurrentLocation ()
    {
        return current_location;
    }

    public Vector3 GetLastLocation ()
    {
        return last_location;
    }

    public void SetCurrentLocation (Vector3 init_current_location)
    {
        last_location = current_location;
        current_location = init_current_location;
        if (isBody)
        {
            transform.position = current_location;
        }
    }
}
