using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;
using UnityEngine.Pool;

public class PoolManager : Singleton<PoolManager>
{
    [SerializeField] private PoolObject[] poolObjects;

    private Dictionary<string, Stack<PoolObject>> _stackDictionary = new Dictionary<string, Stack<PoolObject>>();

    private void Start()
    {
        PoolManager.Instance.Load();
        
    }
    private void Load()
    {
        //change
      
        foreach (var poolObject in poolObjects)
        {

            Stack<PoolObject> objStack = new Stack<PoolObject>();
            var newPoolObject = Instantiate(poolObject);
            newPoolObject.gameObject.SetActive(false);
            newPoolObject.gameObject.name = poolObject.name;//make sure the name is same with Spawn()
            objStack.Push(newPoolObject);

            _stackDictionary.Add(poolObject.name, objStack);
        }
        
    }

    public PoolObject Spawn(string objName)

    {
        Stack<PoolObject> objStack = _stackDictionary[objName];


        if (objStack.Count == 1) 
        {
            PoolObject whatIsInTheStack = objStack.Peek();
            PoolObject newPoolObject = Instantiate(whatIsInTheStack);
            newPoolObject.name = whatIsInTheStack.name;
            newPoolObject.gameObject.SetActive(true);
            return newPoolObject;
        }

        PoolObject lastObjectInTheStack = objStack.Pop();
        lastObjectInTheStack.gameObject.SetActive(true);
        return lastObjectInTheStack;
    }

    public void DeSpawn(PoolObject poolObject)
    {
        Debug.Log("destroy bullet");
        if (!_stackDictionary.ContainsKey(poolObject.name))
        {
            Debug.LogError($"Pool with name {poolObject.name}does not exist." );
            return;
        }
        
        Stack<PoolObject> objStack = _stackDictionary[poolObject.name];
        poolObject.gameObject.SetActive(false);
        objStack.Push(poolObject);
    }
}

