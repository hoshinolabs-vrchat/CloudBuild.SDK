using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditorInternal;
#endif
using UnityEngine;

#if UNITY_EDITOR
namespace HoshinoLabs.CloudBuild.SDK
{
    [RequireComponent(typeof(Camera))]
    public class VRCCamHelper : MonoBehaviour
    {
        private void Start()
        {
            StartCoroutine(ApplyVRCCam());
        }

        IEnumerator ApplyVRCCam()
        {
            yield return null;

            var vrccam = GameObject.Find("VRCCam");
            if (!vrccam)
                yield break;

            ComponentUtility.CopyComponent(transform);
            ComponentUtility.PasteComponentValues(vrccam.transform);
            ComponentUtility.CopyComponent(GetComponent<Camera>());
            ComponentUtility.PasteComponentValues(vrccam.GetComponent<Camera>());
        }
    }
}
#endif
