using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float SpeedGain = 2.5f;
    public float PowerTime = 10f;
    private MeshRenderer meshRenderer;
    private CapsuleCollider collider;

    private void Start()
    {
        collider = GetComponent<CapsuleCollider>();
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Player")
        {
            collider.enabled = false;
            meshRenderer.enabled = false;
            StartCoroutine(AddSpeed(collision.gameObject));
        }
    }

    public IEnumerator AddSpeed(GameObject player)
    {
        PlayerMovement playerScript = player.GetComponent<PlayerMovement>();
        playerScript.Speed += SpeedGain;
        yield return new WaitForSeconds(PowerTime);
        playerScript.Speed -= SpeedGain;
        gameObject.SetActive(false);
        collider.enabled = true;
        meshRenderer.enabled = true;
    }
}
