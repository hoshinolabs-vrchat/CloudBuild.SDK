using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using VRC.Core;
using VRCSDK2;

namespace CloudBuild.SDK
{
    public static class BuildHelper
    {
        const string assignIdMenuItem = "CloudBuild/AssignID";
        [MenuItem(assignIdMenuItem, false, 1000)]
        public static void AssignId()
        {
            var pipelineManager = GameObject.FindObjectOfType<PipelineManager>();
            if (string.IsNullOrEmpty(pipelineManager.blueprintId))
            {
                pipelineManager.AssignId();
                EditorUtility.SetDirty(pipelineManager);
                EditorSceneManager.MarkSceneDirty(pipelineManager.gameObject.scene);
                EditorSceneManager.SaveScene(pipelineManager.gameObject.scene);
            }
        }
        [MenuItem(assignIdMenuItem, true)]
        static bool CanAssignId()
        {
            if (GameObject.FindObjectOfType<VRC_SceneDescriptor>() == null)
            {
                return false;
            }

            var pipelineManager = GameObject.FindObjectOfType<PipelineManager>();
            if (!string.IsNullOrEmpty(pipelineManager.blueprintId))
            {
                return false;
            }

            return true;
        }
    }
}
