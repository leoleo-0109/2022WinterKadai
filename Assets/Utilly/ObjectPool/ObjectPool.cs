using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject poolPrefab;

    protected List<GameObject> poolObjs = new List<GameObject>();

    protected virtual void GenerateObj(int num)
    {
        for(int i = 0; i < num; i++)
        {
            GameObject obj = Instantiate(poolPrefab,transform);
            poolObjs.Add(obj);
            obj.SetActive(false);
        }
    }

    public void InitPool(int num)
    {
        //écÇ¡ÇƒÇΩÇÁè¡Ç∑
        int poolObjCount = poolObjs.Count;
        for (int i = 0; i < poolObjCount; i++)
        {
            GameObject obj =poolObjs[0];
            poolObjs.RemoveAt(0);
            Destroy(obj);
        }
        //èâä˙âª
        poolObjs.Clear();
        poolObjs = new List<GameObject>(num);
        //ê∂ê¨
        GenerateObj(num);
    }

    public void DisableObj(GameObject obj)
    {
        obj.transform.parent = transform;
        poolObjs.Add(obj);
        obj.SetActive(false);
    }

    public GameObject GetObj(Transform parent)
    {
        if(poolObjs.Count == 0)
        {
            GenerateObj(1);
        }

        GameObject obj = poolObjs[0];
        poolObjs.Remove(obj);
        obj.SetActive(true);
        obj.transform.parent = parent;
        return obj;
    }
}
