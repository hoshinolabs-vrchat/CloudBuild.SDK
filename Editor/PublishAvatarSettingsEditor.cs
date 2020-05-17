using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace CloudBuild.SDK
{
    [CustomEditor(typeof(PublishAvatarSettings))]
    public class PublishAvatarSettingsEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (GUILayout.Button("TakeImage"))
            {
                var imageCapture = GameObject.FindObjectOfType<CameraImageCapture>();
                var go = imageCapture ? Instantiate(imageCapture.gameObject) : GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("VRCCam"));
                imageCapture = go.GetComponent<CameraImageCapture>();
                string path = imageCapture.TakePicture(savePath: Application.dataPath);
                DestroyImmediate(go);

                AssetDatabase.Refresh();
                var settings = this.target as PublishAvatarSettings;
                var dir = new Uri(Path.Combine(Application.dataPath, ".."));
                path = dir.MakeRelativeUri(new Uri(path)).ToString();
                settings.thumbnail = AssetDatabase.LoadAssetAtPath<Texture2D>(path);
            }
        }
    }
}
