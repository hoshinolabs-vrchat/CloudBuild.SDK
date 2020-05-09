using System.Collections;
using System.Collections.Generic;
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
        public Texture2D thumbnail => _thumbnail;
    }
}
