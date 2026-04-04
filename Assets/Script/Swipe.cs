using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Swipe : MonoBehaviour, IEndDragHandler
{
    [SerializeField] int MaxPage;
    [SerializeField] Vector3 PageStep;
    [SerializeField] RectTransform LevelPagesRect;
    Vector3 targetPos;
    int currentPage;
    float drag;
    [SerializeField] float tweenTime;
    [SerializeField] LeanTweenType tweenType;
    [SerializeField] Image[] img;
    [SerializeField] Sprite Closed,Open;
    
    private void Awake()
    {
        currentPage = 1;
        targetPos = LevelPagesRect.localPosition;
        drag = Screen.width / 15;
        UpdateBar();
    }

    public void Next(){
        if (currentPage < MaxPage){
            currentPage++;
            targetPos += PageStep;
            MovePage();
        }
    }
    public void Previous(){
        if (currentPage > 1){
            currentPage--;
            targetPos -= PageStep;
            MovePage();
        }
    }

    void MovePage(){
        LevelPagesRect.LeanMoveLocal(targetPos, tweenTime).setEase(tweenType);
        UpdateBar();
    }

    public void OnEndDrag(PointerEventData eventData){
        if (Mathf.Abs(eventData.position.x - eventData.pressPosition.x) > drag){
            if (eventData.position.x > eventData.pressPosition.x){
                Previous();
            } else {
                Next();
            }
        } else {
            MovePage();
        }
    }

    void UpdateBar(){
        foreach (var item in img){
            item.sprite = Closed;
        }
        img[currentPage-1].sprite = Open;
    }
}
