using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        foreach (var PoolObject in poolObjects)
        {
            // add the bullets (pool object>) to the dictionary
            Stack<PoolObject> objStack = new Stack<PoolObject>();

            var newPoolObject = Instantiate(PoolObject);
            newPoolObject.gameObject.SetActive(false);
            newPoolObject.gameObject.name = PoolObject.name;
            objStack.Push(newPoolObject);

            _stackDictionary.Add(PoolObject.name, objStack);
        }
    }

    public PoolObject Spawn(string objName) // "bullet"
    {
        // look inside the dictionary
        Stack<PoolObject> objStack = _stackDictionary[objName];

        if (objStack.Count == 1) // if the stack has only one object
        {
            PoolObject whatIsInTheStack = objStack.Peek();
            PoolObject newPoolObject = Instantiate(whatIsInTheStack);
            newPoolObject.name = whatIsInTheStack.name;
            newPoolObject.gameObject.SetActive(true);
            return newPoolObject;
        }

        //If there is more than one object, just remove and return the last object from the stack
        PoolObject lastObjectInTheStack = objStack.Pop();
        lastObjectInTheStack.gameObject.SetActive(true);
        return lastObjectInTheStack;

    }

    public void DeSpawn(PoolObject poolObject)
    {
        Stack<PoolObject> objStack = _stackDictionary[poolObject.name];

        // disable the object and push it into the stack
        poolObject.gameObject.SetActive(false);
        objStack.Push(poolObject);
    }

}