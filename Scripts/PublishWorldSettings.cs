using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRC.SDKBase;

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
        int _version = 0;
        public int version => _version;

        [SerializeField]
        string[] _tags = null;
        public string[] tags => _tags;

        [SerializeField]
        Texture2D _thumbnail = null;
        public Texture2D thumbnail => _thumbnail;
    }
}
