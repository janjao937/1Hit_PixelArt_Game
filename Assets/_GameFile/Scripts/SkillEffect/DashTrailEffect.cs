using UnityEngine;
using System.Collections;

public class DashTrailEffect : MonoBehaviour
{
    [SerializeField] private Transform posToSpawnEffect;
    [SerializeField] private Material effMat;
    [SerializeField] private float timeDelayDestory = 3;

    [SerializeField] private float activeTime = 2;
    [SerializeField] private float meshRefreshRate = 0.1f;
    private SkinnedMeshRenderer[] skinnedMeshRenderers;
    private bool isActiveEffect = false;

    private void Update() 
    {
        if(!UnityEngine.Input.GetKeyDown(KeyCode.E))return; //Test Old Input //if new input use like Block
        UseEffect();
    }
    private void UseEffect()
    {
        if(isActiveEffect)return;
        //GetComponent<PlayerMovement>().MoveSpeed = 5;
        isActiveEffect = true;
        StartCoroutine(ActiveTrailEffect(activeTime));
    }

    IEnumerator ActiveTrailEffect(float timeActive)
    {
        while(timeActive > 0)
        {
            timeActive-= meshRefreshRate;
            if(skinnedMeshRenderers == null)
            {
                skinnedMeshRenderers = GetComponentsInChildren<SkinnedMeshRenderer>();
            }

            foreach(var i in skinnedMeshRenderers)
            {
                GameObject gO = new GameObject();
                gO.transform.SetPositionAndRotation(posToSpawnEffect.position,posToSpawnEffect.rotation);
                MeshRenderer mRD = gO.AddComponent<MeshRenderer>();
                MeshFilter mFT = gO.AddComponent<MeshFilter>();
                Mesh mesh = new Mesh();
                i.BakeMesh(mesh);
                mFT.mesh = mesh;
                mRD.material = effMat;

                Destroy(gO,timeDelayDestory);

            }
            yield return new WaitForSeconds(meshRefreshRate);
        }
        isActiveEffect = false;
        //GetComponent<PlayerMovement>().MoveSpeed = 2.5f;

    }
}
