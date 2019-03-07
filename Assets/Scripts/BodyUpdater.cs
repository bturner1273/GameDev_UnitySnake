using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyUpdater : MonoBehaviour
{
    // Update is called once per frame
    public static void UpdateBody(Transform transform)
    {
        for (int i = 1; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<PositionManager>().SetCurrentLocation(
                transform.GetChild(i - 1).GetComponent<PositionManager>().GetLastLocation());
        }
    }
}
