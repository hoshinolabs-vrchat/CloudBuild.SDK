using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRCSDK2;

namespace CloudBuild.SDK
{
    [RequireComponent(typeof(VRC_SceneDescriptor))]
    public class PublishWorldSettings : MonoBehaviour
    {
        [SerializeField]
        string _name = string.Empty;
        public new string name => _name;
        [SerializeField]
        [Multiline(4)]
        string _description = string.Empty;
        public string description => _description;
        [SerializeField]
        [Range(1, 64)]
        short _capacity = 8;
        public short capacity => _capacity;

        [SerializeField]
        string[] _tags;
        public string[] tags => _tags;

        [SerializeField]
        Texture2D _thumbnail;
        public Texture2D thumbnail => _thumbnail;
    }
}
