/**
* Copyright (c) 2015-2016 VisionStar Information Technology (Shanghai) Co., Ltd. All Rights Reserved.
* EasyAR is the registered trademark or trademark of VisionStar Information Technology (Shanghai) Co., Ltd in China
* and other countries for the augmented reality technology developed by VisionStar Information Technology (Shanghai) Co., Ltd.
*/

using UnityEngine;

namespace EasyAR
{
    public class ARIsEasyBehaviour : MonoBehaviour
    {
        private const string title = "Please enter KEY first!";
        private const string boxtitle = "===PLEASE ENTER YOUR KEY HERE===";
        private const string keyMessage = "yFeZ9hJWQvA59T8QNNa8ydbNMbWTHa6l9Tm681V5RR0HwpY1LRP9NFOkXRZj3PA8JL57xETAhKD61MZCIPBklT29Dzsj5TB2yIQwab43c1f8ece39d1c0e6a34e843156453DnstGEt2G0laJaQlbiBTLUWy5kxGviN2pznNg13ezgNKiwaqxtr9wJylLKum5IsfpLeG";

        private void Awake()
        {
            var EasyARBehaviour = FindObjectOfType<EasyARBehaviour>();
            if (EasyARBehaviour.Key.Contains(boxtitle))
            {
#if UNITY_EDITOR
                //UnityEditor.EditorUtility.DisplayDialog(title, keyMessage, "OK");
#endif
                Debug.LogError(title + " " + keyMessage);
            }
            EasyARBehaviour.Initialize();
            foreach (var behaviour in ARBuilder.Instance.AugmenterBehaviours)
            {
                behaviour.TargetFound += OnTargetFound;
                behaviour.TargetLost += OnTargetLost;
                behaviour.TextMessage += OnTextMessage;
            }
            foreach (var behaviour in ARBuilder.Instance.TrackerBehaviours)
            {
                behaviour.TargetLoad += OnTargetLoad;
                behaviour.TargetUnload += OnTargetUnload;
            }
        }

        void OnTargetFound(AugmenterBaseBehaviour augmenterBehaviour, ImageTargetBaseBehaviour targetBehaviour, Target target)
        {
            Debug.Log("<Global Handler> Found: " + target.Id);
        }

        void OnTargetLost(AugmenterBaseBehaviour augmenterBehaviour, ImageTargetBaseBehaviour targetBehaviour, Target target)
        {
            Debug.Log("<Global Handler> Lost: " + target.Id);
        }

        void OnTargetLoad(ImageTrackerBaseBehaviour trackerBehaviour, ImageTargetBaseBehaviour targetBehaviour, Target target, bool status)
        {
            Debug.Log("<Global Handler> Load target (" + status + "): " + target.Id + " (" + target.Name + ") " + " -> " + trackerBehaviour);
        }

        void OnTargetUnload(ImageTrackerBaseBehaviour trackerBehaviour, ImageTargetBaseBehaviour targetBehaviour, Target target, bool status)
        {
            Debug.Log("<Global Handler> Unload target (" + status + "): " + target.Id + " (" + target.Name + ") " + " -> " + trackerBehaviour);
        }

        private void OnTextMessage(AugmenterBaseBehaviour augmenterBehaviour, string text)
        {
            Debug.Log("got text: " + text);
        }
    }
}
