using GoogleARCore;
using System.Collections;
using UnityEngine;

public class ARImageVisualizer : MonoBehaviour
{
    public GameObject bonusUI;
    private Animator anim;
    private bool flag = false;
    public AugmentedImage Image;
    public GameObject chestModel;
    public void Update()
    {
        if (Image == null || Image.TrackingState != TrackingState.Tracking)
        {
            chestModel.SetActive(false);
            return;
        }

        float halfWidth = Image.ExtentX / 2;
        float halfHeight = Image.ExtentZ / 2;
        chestModel.transform.localPosition = (halfWidth * Vector3.zero) + (halfHeight * Vector3.zero);
        chestModel.SetActive(true);



        anim = chestModel.GetComponent<Animator>();
        anim.SetTrigger("open");

        if (flag != true)
        {
            StartCoroutine(wait3seconds());
            flag = true;
        }

    }

    IEnumerator wait3seconds()
    {
        yield return new WaitForSeconds(5f);
        bonusUI.SetActive(true);
    }
}
