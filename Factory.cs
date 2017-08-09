using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// 资源加载（工厂）                
/// </summary>
public class Factory
{
    private string characterPath = "Prefabs/mon_";
    private string weaponPath = "Weapons/wp_";
    private string clotherPath = "Clother/";
    private Dictionary<string, Object> GoCache = new Dictionary<string, Object>();
    //加载 进场景（Instantiate）
    public GameObject LoadWeapon(string goName)
    {
        return LoadObj(weaponPath + goName);
    }
    public GameObject LoadCharacter(string goName)
    {
        return LoadObj(characterPath + goName);
    }
    private GameObject LoadObj(string resourcePath)
    {
        if(!GoCache.ContainsKey(resourcePath))
        {
            GameObject go = (GameObject)Resources.Load(resourcePath);
            go = GameObject.Instantiate(go);
            go.name = go.name.Replace("(Clone)", "");
            GoCache.Add(resourcePath, go);
        }
        return (GameObject)GoCache[resourcePath];
    }
    public Texture LoadCloth(string goName)
    {
        if (!GoCache.ContainsKey(goName))
        {
            Texture go = (Texture)Resources.Load(clotherPath + goName);
            GoCache.Add(goName, go);
        }
        return (Texture)GoCache[goName];
    }
}
