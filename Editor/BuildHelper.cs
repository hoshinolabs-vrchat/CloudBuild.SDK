using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using VRC.Core;
using VRC.SDKBase;

namespace CloudBuild.SDK
{
    public static class BuildHelper
    {
        const string assignIdMenuItem = "CloudBuild/Assign ID";
        [MenuItem(assignIdMenuItem, false, 1000)]
        public static void AssignId()
        {
            var gameObject = TargetGameObject();
            var pipelineManager = gameObject.GetComponent<PipelineManager>();
            pipelineManager.contentType = ContentType(pipelineManager.gameObject);
            pipelineManager.AssignId();
            EditorUtility.SetDirty(pipelineManager);
            EditorSceneManager.MarkSceneDirty(pipelineManager.gameObject.scene);
            EditorSceneManager.SaveScene(pipelineManager.gameObject.scene);
        }

        [MenuItem(assignIdMenuItem, true)]
        static bool CanAssignId()
        {
            var gameObject = TargetGameObject();

            if (gameObject == null)
            {
                return false;
            }

            var pipelineManager = gameObject.GetComponent<PipelineManager>();
            if (!string.IsNullOrEmpty(pipelineManager.blueprintId))
            {
                return false;
            }

            return true;
        }

        static GameObject TargetGameObject()
        {
            var gameObjects = Selection.gameObjects;
            var gameObject = gameObjects.FirstOrDefault();

            if(1 < gameObjects.Length)
            {
                return null;
            }

            if (gameObjects.Length == 1)
            {
                var descriptor = gameObject.GetComponent<VRC_AvatarDescriptor>();
                if(descriptor == null)
                {
                    return null;
                }
            }

            if (gameObjects.Length == 0)
            {
                var descriptor = GameObject.FindObjectOfType<VRC_SceneDescriptor>();
                if(descriptor == null)
                {
                    return null;
                }
                gameObject = descriptor.gameObject;
            }

            return gameObject;
        }

        static PipelineManager.ContentType ContentType(GameObject gameObject)
        {
            if (gameObject.GetComponent<VRC_SceneDescriptor>())
            {
                return PipelineManager.ContentType.world;
            }
            return PipelineManager.ContentType.avatar;
        }
    }
}
