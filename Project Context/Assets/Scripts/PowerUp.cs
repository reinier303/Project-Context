using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float SpeedGain = 2.5f;
    public float PowerTime = 10f;
    private MeshFilter meshFilter;
    private MeshRenderer meshRenderer;
    private CapsuleCollider collider;

    GameManager gameManager;

    public List<Mesh> MaleMeshes;
    public List<Mesh> FemaleMeshes;

    private Light light;

    private int male = 0;

    private bool lightHigh;

    public float GlowSpeed;

    private void Start()
    {
        gameManager = GameManager.Instance;

        collider = GetComponent<CapsuleCollider>();
        meshFilter = GetComponent<MeshFilter>();
        meshRenderer = GetComponent<MeshRenderer>();
        light = GetComponent<Light>();
        male = Random.Range(0,2);
        ChangeMesh();
        StartCoroutine(GlowEffect());
    }

    public void ChangeMesh()
    {
        if(male == 0)
        {
            light.color = Color.blue;
            print(Random.Range(0, MaleMeshes.Count));
            meshFilter.mesh = MaleMeshes[Random.Range(0, MaleMeshes.Count)];
            //REMOVE COLOR WHEN MODELS READY!!!
            meshRenderer.material.color = Color.blue;
        }
        else
        {
            light.color = Color.red;
            print(Random.Range(0, FemaleMeshes.Count));
            meshFilter.mesh = FemaleMeshes[Random.Range(0, FemaleMeshes.Count)];
            meshRenderer.material.color = Color.red;
        }

    }

    IEnumerator GlowEffect()
    {
        if(!lightHigh)
        {
            for (int i = 0; i < 35; i++)
            {
                yield return new WaitForSeconds(GlowSpeed);
                light.intensity += 0.1f;
            }
            lightHigh = true;
        }
        else
        {
            for (int i = 0; i < 35; i++)
            {
                yield return new WaitForSeconds(GlowSpeed);
                light.intensity -= 0.1f;
            }
            lightHigh = false;
        }
        StartCoroutine(GlowEffect());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Player")
        {
            collider.enabled = false;
            meshRenderer.enabled = false;
            StartCoroutine(AddSpeed(collision.gameObject));
            gameManager.PowerUpsCollected++;
            gameManager.CheckForBossSpawn();
            collision.gameObject.GetComponent<ModelChanger>().ChangeMesh();
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
