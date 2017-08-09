using UnityEngine;
using System.Collections;

/// <summary>
/// 业务处理（使用资源）                
/// </summary>
public class SkinController : MonoBehaviour
{
    private Factory factory = new Factory();
    private GameObject currentCharacter;
    private GameObject currentWeapon;
    /// <summary>
    /// 更换武器
    /// </summary>
    public void ChangeWeapon(string goName)
    {
        if(currentCharacter!=null)
        {
            var weapon = factory.LoadWeapon(goName);
            if (currentWeapon != null && currentWeapon.name != weapon.name)
                currentWeapon.SetActive(false);//原来的武器
            Transform wpHand = GameObject.FindGameObjectWithTag("WeaponPoint").transform;
            currentWeapon = weapon;
            currentWeapon.transform.parent = wpHand;
            currentWeapon.transform.localPosition = Vector3.zero;
            currentWeapon.transform.localEulerAngles = new Vector3(0,0,180);
            currentWeapon.SetActive(true);//现在的
        }
    }
    /// <summary>
    /// 更换动画
    /// </summary>
    public void ChangeAnimation(string goName)
    {
        if (currentCharacter != null)
        {
            currentCharacter.GetComponent<Animation>().Play(goName);
        }
    }
    /// <summary>
    /// 更换角色
    /// </summary>
    public void ChangeCharacter(string goName)
    {
        var character = factory.LoadCharacter(goName);
        if (currentCharacter != null && currentCharacter.name != character.name)
            currentCharacter.SetActive(false);//原来的角色
        character.transform.position = transform.position;
        character.transform.rotation = transform.rotation;
        currentCharacter = character;
        currentCharacter.SetActive(true);//现在的角色
    }
    /// <summary>
    /// 更换服装
    /// </summary>
    public void ChangeClother(string goName)
    {
        if (currentCharacter!=null)
        {
            var clother = factory.LoadCloth(currentCharacter.name + "_" + goName);
            currentCharacter.GetComponentInChildren<SkinnedMeshRenderer>().material.
                mainTexture = clother;
        }
      
    }
}
