using System.Collections;
using System.Collections.Generic;
using UniRx.Async;
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
        private async void Start()
        {
            await UniTask.DelayFrame(1);

            var go = GameObject.Find("VRCCam");
            if (go != null)
            {
                ComponentUtility.CopyComponent(transform);
                ComponentUtility.PasteComponentValues(go.transform);

                ComponentUtility.CopyComponent(GetComponent<Camera>());
                ComponentUtility.PasteComponentValues(go.GetComponent<Camera>());
            }
        }
    }
}
#endif
