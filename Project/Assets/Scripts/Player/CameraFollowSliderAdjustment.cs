using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CameraFollowSliderAdjustment : MonoBehaviour
{

    public UnityStandardAssets.Utility.FollowTarget followTargetScript = null;
    public float DistanceAmount = 10.0f;
    public Text distanceText = null;
    private Vector3 startingOffset;

    void InitializeComponents()
    {
        Debug.Assert(followTargetScript != null, "Follow target script not set.");
        Debug.Assert(distanceText != null, "Distance text object not set.");
    }

    void Start()
    {
        InitializeComponents();

        startingOffset = followTargetScript.offset;
        UpdateText();
    }

    public void DidChangeSliderValue(float value)
    {
        Vector3 currentOffset = startingOffset - followTargetScript.transform.forward * DistanceAmount * value;
        followTargetScript.offset = currentOffset;
        UpdateText();
    }

    void UpdateText()
    {
        string newValue = "Y: " + followTargetScript.offset.y;
        distanceText.text = newValue;
    }
}
