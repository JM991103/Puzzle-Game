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

    InteractObj intObj;

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
                    intObj = hit.transform.gameObject.GetComponent<InteractObj>();
                    if (intObj.CompareTag("Door"))
                    {
                        if (!intObj.key)
                        {
                            talkPanel.SetActive(true);
                            talkText.text = intObj.defaultText[defaultTalkIndex];
                        }
                        else
                        {
                            if (!isActive)
                            {
                                talkPanel.SetActive(true);
                                intObj.Open();
                                talkText.text = intObj.afterText[afterTalkIndex];
                                isActive = true;
                            }
                            else
                            {
                                Debug.Log("다른방으로 진입");
                            }
                        }
                    }
                }
            }
            else
            {         
                // 패널이 열려 있을 때
                if (defaultTalkIndex == intObj.defaultText.Length -1)
                {
                    defaultTalkIndex = 0;
                    talkPanel.SetActive(false);
                }                
                else if(!intObj.key)
                {
                    defaultTalkIndex++;
                    talkText.text = intObj.defaultText[defaultTalkIndex];
                }

                if (afterTalkIndex == intObj.afterText.Length -1)
                {
                    afterTalkIndex = 0;
                    talkPanel.SetActive(false);
                }
                else if(intObj.key)
                {
                    afterTalkIndex++;
                    talkText.text = intObj.afterText[afterTalkIndex];                    
                }
            }
        }
    }
}
