using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

namespace UnityEditor.Rendering.HighDefinition
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(LightCluster))]
    class LightClusterEditor : VolumeComponentEditor
    {
        public override void OnInspectorGUI()
        {
            HDRenderPipelineAsset currentAsset = HDRenderPipeline.currentAsset;
            bool notSupported = currentAsset != null && !currentAsset.currentPlatformRenderPipelineSettings.supportRayTracing;
            if (notSupported)
            {
                EditorGUILayout.Space();
                HDEditorUtils.QualitySettingsHelpBox(HDRenderPipelineUI.Styles.rayTracingUnsupportedMessage,
                    MessageType.Warning, HDRenderPipelineUI.Expandable.Rendering,
                    "m_RenderPipelineSettings.supportRayTracing");
            }
            using var disableScope = new EditorGUI.DisabledScope(notSupported);

            base.OnInspectorGUI();
        }
    }
}
