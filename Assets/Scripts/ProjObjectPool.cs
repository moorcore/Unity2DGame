using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjObjectPool : MonoBehaviour
{
    public static ProjObjectPool instance;
    public Transform LaunchOffset;

    private List<GameObject> pooledObjects = new List<GameObject>();
    private int amountToPool = 20;
    
    [SerializeField]
    private GameObject projPrefab;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(projPrefab, LaunchOffset.position, transform.rotation);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    void Update()
    {
        GameObject proj = instance.GetPooledObject();
        proj.transform.rotation = LaunchOffset.rotation;
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }

        return null;
    }
}
