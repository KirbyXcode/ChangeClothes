using UnityEngine;
using System.Collections;

/// <summary>
/// 按钮分配任务                
/// </summary>
public class ButtonClickHandler : MonoBehaviour
{
    private SkinController skinController;
    private void Start(){
        skinController = FindObjectOfType<SkinController>();
        for (int i = 0; i < transform.childCount; i++){
            transform.GetChild(i).GetComponent<UIButton>().onClick.Add(
                new EventDelegate(OnButtonClick));}
    }
    public void OnButtonClick(){
        print("点击的按钮名： " + UIButton.current.name);
        var arr = UIButton.current.name.Split(' ');
        var function = arr[0];//功能描述
        var goName = arr[1];//需要的资源描述
        switch (function){
            case "Weapons":
                skinController.ChangeWeapon(goName);
                break;
            case "Animation":
                skinController.ChangeAnimation(goName);
                break;
            case "Character":
                skinController.ChangeCharacter(goName);
                break;
            case "Clother":
                skinController.ChangeClother(goName);
                break;
        }


    }
}
