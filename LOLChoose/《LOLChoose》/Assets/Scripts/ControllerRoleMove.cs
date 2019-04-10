using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class ControllerRoleMove : MonoBehaviour
{

    private GameObject temprole;
    public List<GameObject> playerLists;
    public  int number = 0;

    void Awake()
    {
        Transform SedTran = GameObject.FindWithTag("Canvas").transform.Find("BackGrond/SelectedPanel");

        foreach (Transform T in SedTran)
        {
            playerLists.Add(T.gameObject);
        }
    }

    void Start()
    {

        GetComponent<Button>().onClick.AddListener(MovetoPlayer);
    }


    public void GetPlayer(GameObject player)
    {
        temprole = player;

        playerLists[number].transform.FindChild("profile").GetComponent<Image>().sprite = temprole.GetComponentInChildren<Image>().sprite;
        playerLists[number].transform.FindChild("profile").GetComponent<Image>().enabled = true;
    }


    public void MovetoPlayer()
    {
        if (temprole != null)
        {
            GetComponentInChildren<Image>().enabled = false;
            GetComponentInChildren<Text>().enabled = false;
            temprole.GetComponent<Toggle>().interactable = false;
            temprole.transform.Find("Role/Image").GetComponent<Image>().enabled = false;
            playerLists[number].transform.FindChild("Light").GetComponent<Image>().enabled = false;
            number++;
            if (number < 5)
            {

                playerLists[number].transform.FindChild("Light").GetComponent<Image>().enabled = true;
                GetComponent<Button>().interactable = false;
            }
            GetComponent<Button>().interactable = false;
        }
    }


}
