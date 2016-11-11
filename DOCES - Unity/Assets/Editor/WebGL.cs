using UnityEditor;

class WebGLBuilder {
    static void build() {
        string[] scenes = {"Assets/Scenes/GameScenes.unity"};
        BuildPipeline.BuildPlayer(scenes, "WEBGLRODA", BuildTarget.WebGL, BuildOptions.None);
    }
}
