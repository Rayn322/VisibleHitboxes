using HarmonyLib;
using UnityEngine;

namespace VisibleHitboxes.Patches {

    [HarmonyPatch(typeof(BoxCuttableBySaber), "Awake", MethodType.Normal)]
    public class BoxCuttableBySaberPatch {

        private static void Postfix(BoxCuttableBySaber __instance, ref BoxCollider ____collider) {
            if (!Config.Instance.IsEnabled) {
                return;
            }

            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.name = "VisibleCubeCollider";
            cube.transform.SetParent(__instance.transform, false);
            cube.transform.localScale = __instance.colliderSize;
            cube.transform.position = new Vector3(0, 1, 0);
            cube.GetComponent<MeshRenderer>().material = Plugin.hitboxMaterial;

            // Silhouette-Outlined Diffuse
        }
    }
}