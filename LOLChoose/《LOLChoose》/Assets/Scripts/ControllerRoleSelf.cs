using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ControllerRoleSelf : MonoBehaviour
{

    private AudioSource canvasAudio;   //用来播放声音UI声音
    private ControllerRoleMove conll;
    private AudioSource ASource;
    private Toggle toggle;


    void Start()
    {
        ASource = GetComponent<AudioSource>();
        toggle = GetComponent<Toggle>();
        canvasAudio = GameObject.FindWithTag("Canvas").GetComponent<AudioSource>();

        conll = GameObject.FindWithTag("Kaiguan").GetComponent<ControllerRoleMove>();

        toggle.group = gameObject.GetComponentInParent<ToggleGroup>();

        toggle.onValueChanged.AddListener(delegate { OnClick(); });


    }


    void OnClick()
    {
        try
        {
            canvasAudio.clip = CreateRole.instance.audioDic[gameObject.name];
        }
        catch
        {
            print(gameObject.name + ":没有找到相关声音！");

        }
        if (canvasAudio != null && !canvasAudio.isPlaying)
            canvasAudio.Play();

        if (conll.number < 5)
        {
            GameObject.FindWithTag("Kaiguan").GetComponent<Button>().interactable = true;
            GameObject.FindWithTag("Kaiguan").GetComponentInChildren<Image>().enabled = true;
            GameObject.FindWithTag("Kaiguan").GetComponentInChildren<Text>().enabled = true;
            GameObject.FindWithTag("Kaiguan").GetComponent<ControllerRoleMove>().GetPlayer(gameObject);
        }
        else
        {
            GameObject.FindWithTag("Kaiguan").GetComponent<Button>().interactable = false;
            GameObject.FindWithTag("Kaiguan").GetComponentInChildren<Image>().enabled = false;
            GameObject.FindWithTag("Kaiguan").GetComponentInChildren<Text>().enabled = false;
            //GameObject.Find("SureButton").SetActive(false);
        }




    }



}
