using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class TalkManager : MonoBehaviour
{
    /// <summary>
    /// 대사 패널
    /// </summary>
    public GameObject talkPanel;

    TextMeshProUGUI talkText;

    GameObject intObj;
    InteractObj doorObj;

    bool isActive= false;

    int defaultTalkIndex = 0;
    int afterTalkIndex = 0;

    private void Awake()
    {
        talkText = talkPanel.GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Start()
    {
        talkPanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);

            if (!talkPanel.activeSelf)
            {
                if (hit.collider != null)
                {
                    intObj = hit.transform.gameObject;
                    if (intObj.CompareTag("Door"))
                    {
                        doorObj = intObj.GetComponent<InteractObj>();
                        if (!doorObj.key)
                        {
                            talkPanel.SetActive(true);
                            talkText.text = doorObj.defaultText[defaultTalkIndex];
                        }
                        else
                        {
                            if (!isActive)
                            {
                                talkPanel.SetActive(true);
                                doorObj.Open();
                                talkText.text = doorObj.afterText[afterTalkIndex];
                                isActive = true;
                            }
                            else
                            {
                                Debug.Log("다른방으로 진입");
                            }
                        }
                    }
                    else if (intObj.CompareTag("Item"))
                    {
                        Debug.Log(intObj.name);
                    }
                }
                
            }
            else
            {         
                // 패널이 열려 있을 때
                if (defaultTalkIndex == doorObj.defaultText.Length -1)
                {
                    defaultTalkIndex = 0;
                    talkPanel.SetActive(false);
                }                
                else if(!doorObj.key)
                {
                    defaultTalkIndex++;
                    talkText.text = doorObj.defaultText[defaultTalkIndex];
                }

                if (afterTalkIndex == doorObj.afterText.Length -1)
                {
                    afterTalkIndex = 0;
                    talkPanel.SetActive(false);
                }
                else if(doorObj.key)
                {
                    afterTalkIndex++;
                    talkText.text = doorObj.afterText[afterTalkIndex];                    
                }
            }
        }
    }
}
