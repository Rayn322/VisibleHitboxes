using HarmonyLib;
using UnityEngine;

namespace VisibleHitboxes.Patches {

    [HarmonyPatch(typeof(SaberManager), "RefreshSabers", MethodType.Normal)]
    public class SaberPatch {

        private static void Postfix(SaberManager __instance, ref Saber ____leftSaber, ref Saber ____rightSaber) {
            if (!Config.Instance.IsEnabled) {
                return;
            }

            // BoxCollider[] saberColliders = { ____leftSaber.GetComponent<BoxCollider>(), ____rightSaber.GetComponent<BoxCollider>() };

            Saber[] sabers = { ____leftSaber, ____rightSaber };

            foreach (Saber saber in sabers) {
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.name = "VisibleSaberCollider";
                cube.transform.SetParent(saber.transform, false);
                cube.transform.localPosition = new Vector3(0, 0, 0.5f);
                cube.transform.localScale = new Vector3(0.06f, 0.06f, 1);
                cube.GetComponent<MeshRenderer>().material = Plugin.hitboxMaterial;
            }

            //BoxCollider leftCollider = ____leftSaber.GetComponent<BoxCollider>();

            //GameObject leftCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            //leftCube.name = "VisibleSaberCollider";
            //leftCube.transform.SetParent(leftCollider.transform, false);
            //leftCube.transform.localPosition = new Vector3(0, 0, 0.5f);
            //leftCube.transform.localScale = new Vector3(0.06f, 0.06f, 1);
            //leftCube.GetComponent<MeshRenderer>().material = Plugin.hitboxMaterial;

            //BoxCollider rightCollider = ____rightSaber.GetComponent<BoxCollider>();

            //GameObject rightCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            //rightCube.name = "VisibleSaberCollider";
            //rightCube.transform.SetParent(rightCollider.transform, false);
            //rightCube.transform.localPosition = new Vector3(0, 0, 0.5f);
            //rightCube.transform.localScale = new Vector3(0.06f, 0.06f, 1);
            //rightCube.GetComponent<MeshRenderer>().material = Plugin.hitboxMaterial;
        }
    }
}