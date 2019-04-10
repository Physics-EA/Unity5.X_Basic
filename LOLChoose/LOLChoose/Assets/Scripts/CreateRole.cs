using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
using System;
using UnityEngine.UI;

public class CreateRole : MonoBehaviour
{

    public static CreateRole instance;

    public GameObject rolePrefab;
    public GameObject Item;

    private GameObject RoleBox;
    private Sprite[] touxiangSprites;
    private AudioClip[] audioClips;
    public Dictionary<string, AudioClip> audioDic;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(instance);

        LoadTA();
    }
    // Use this for initialization
    void Start()
    {
        pattern = @"[A-Z][a-z]+";
        RoleBox = GameObject.FindWithTag("Rolebox");

        InstantiateRole(touxiangSprites);   //生成所有英雄
    }


    private string nameStr; //得到精灵的名字；
    private void LoadTA()
    {
        touxiangSprites = Resources.LoadAll<Sprite>("touxiang");
        audioClips = Resources.LoadAll<AudioClip>("champions");

        audioDic = new Dictionary<string, AudioClip>();
        foreach (AudioClip a in audioClips)
        {
            audioDic.Add(a.name, a);
        }
    }


    private string pattern; //正则表达式
    string MatchName(string name)
    {
        Match ma = Regex.Match(name, pattern);
        return ma.ToString();
    }   //匹配和英雄名字相同的音效名字


    private GameObject tempObj;
    void InstantiateRole(Sprite[] s)
    {
        foreach (Sprite sp in s)
        {
            ChageRolePrefab(sp);
            tempObj = Instantiate(Item);
            tempObj.name = tempObj.GetComponentInChildren<Image>().sprite.name.Split('_')[0];
            tempObj.transform.localScale = new Vector3(1, 1);
            tempObj.transform.SetParent(RoleBox.transform, false);
        }

    }


    void ChageRolePrefab(Sprite s)
    {
        rolePrefab.GetComponent<Image>().sprite = s;
    }
}
