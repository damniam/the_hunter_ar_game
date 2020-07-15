using System.Collections;
using System.Collections.Generic;
using GoogleARCore;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ARImageController : MonoBehaviour
{
    public GameObject instructionUI;
    public GameObject FitToScanOverlay;
    public ARImageVisualizer imageVisualizerPrefab;
    
    private Dictionary<int, ARImageVisualizer> m_Visualizers = new Dictionary<int, ARImageVisualizer>();
    private List<AugmentedImage> m_TempAugmentedImages = new List<AugmentedImage>();

    private void Start()
    {
        instructionUI.SetActive(true);
        StartCoroutine(wait5seconds());
    }

    public void Update()
    {
        if (Session.Status != SessionStatus.Tracking)
        {
            return;
        }
        Session.GetTrackables<AugmentedImage>(m_TempAugmentedImages, TrackableQueryFilter.Updated);

        foreach (var image in m_TempAugmentedImages)
        {
            ARImageVisualizer visualizer = null;
            m_Visualizers.TryGetValue(image.DatabaseIndex, out visualizer);
            if (image.TrackingState == TrackingState.Tracking && visualizer == null)
            {
                Anchor anchor = image.CreateAnchor(image.CenterPose);
                visualizer = (ARImageVisualizer)Instantiate(imageVisualizerPrefab, anchor.transform);
                visualizer.Image = image;
                m_Visualizers.Add(image.DatabaseIndex, visualizer);
            }
            else if (image.TrackingState == TrackingState.Stopped && visualizer != null)
            {
                m_Visualizers.Remove(image.DatabaseIndex);
                GameObject.Destroy(visualizer.gameObject);
            }
        }
        foreach (var visualizer in m_Visualizers.Values)
        {
            if (visualizer.Image.TrackingState == TrackingState.Tracking)
            {
                FitToScanOverlay.SetActive(false);
                return;
            }
        }

        FitToScanOverlay.SetActive(true);
    }

    IEnumerator wait5seconds()
    {
        yield return new WaitForSeconds(5f);
        instructionUI.SetActive(false);
    }

    public void Exit()
    {
        SceneManager.LoadScene("World");
    }
}