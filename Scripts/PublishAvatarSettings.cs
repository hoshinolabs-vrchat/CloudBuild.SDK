using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using VRCSDK2;

namespace CloudBuild.SDK
{
    [RequireComponent(typeof(VRC_AvatarDescriptor))]
    public class PublishAvatarSettings : MonoBehaviour
    {
        [SerializeField]
        string _name = string.Empty;
        public new string name => _name;
        [SerializeField]
        [Multiline(4)]
        string _description = string.Empty;
        public string description => _description;

        [SerializeField]
        int _version = 0;
        public int version => _version;

        [SerializeField]
        Texture2D _thumbnail = null;
        public Texture2D thumbnail
        {
            set => _thumbnail = value;
            get => _thumbnail;
        }

#if UNITY_EDITOR
        public void TakeThumbnail()
        {
            var imageCapture = GameObject.FindObjectOfType<CameraImageCapture>();
            var go = imageCapture ? Instantiate(imageCapture.gameObject) : GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("VRCCam"));
            imageCapture = go.GetComponent<CameraImageCapture>();
            string path = imageCapture.TakePicture(savePath: Application.dataPath);
            DestroyImmediate(go);

            AssetDatabase.Refresh();
            var dir = new Uri(Path.Combine(Application.dataPath, ".."));
            path = dir.MakeRelativeUri(new Uri(path)).ToString();
            thumbnail = AssetDatabase.LoadAssetAtPath<Texture2D>(path);
        }
#endif
    }
}
