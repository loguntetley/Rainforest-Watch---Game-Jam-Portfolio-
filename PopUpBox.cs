using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpBox : MonoBehaviour
{
    public enum PopVals
    {
        AniPicOne,
        AniPicTwo,
        AniPIcThree,
    }

    public GameObject PopUpBoxes;
    public CanvasGroup PopUpBoxes1;
    public Image ImagetoSet;
    public Sprite Armadillo;
    public Sprite Cat;
    public Sprite Anteater;
    public Sprite Macaw;

    void Update()
    {
        PicPicker(3);

        PopUpActivation();
    }

    void PopUpActivation()
    {
        FadeIn(PopUpBoxes1);
        StartCoroutine(DelayAnimation(PopUpBoxes1));
    }

    void PicPicker(int AnimalIndex)
    {

        switch (AnimalIndex)
        {
            case 0:
                ImagetoSet.sprite = Armadillo;
                break;
            case 1:
                ImagetoSet.sprite = Cat;
                break;
            case 2:
                ImagetoSet.sprite = Anteater;
                break;
            case 3:
                ImagetoSet.sprite = Macaw;
                break;
            default:
                ImagetoSet.sprite = Armadillo;
                break;
        }
    }

    public void FadeOut(CanvasGroup PopUp)
    {
        StartCoroutine(FadePopUp(PopUp, PopUp.alpha, 0));
    }
    public void FadeIn(CanvasGroup PopUp)
    {
        StartCoroutine(FadePopUp(PopUp, PopUp.alpha, 1));
    }
    public IEnumerator FadePopUp(CanvasGroup cg, float start, float end, float lerpTime = 1f)
    {
        float _timeStartedLerping = Time.time;
        float timeSinceStarted = Time.time - _timeStartedLerping;
        float PercentageComplete = timeSinceStarted / lerpTime;
        while (true)
        {
            timeSinceStarted = Time.time - _timeStartedLerping;
            PercentageComplete = timeSinceStarted / lerpTime;

            float currentValue = Mathf.Lerp(start, end, PercentageComplete);
            cg.alpha = currentValue;

            if (PercentageComplete >= 1) break;

            yield return new WaitForEndOfFrame();
        }

    }


    public void PopUpAnimation(CanvasGroup PopUp)
    {

        FadeIn(PopUp);
        StartCoroutine(DelayAnimation(PopUp));

    }

    public IEnumerator DelayAnimation(CanvasGroup PopUp)
    {
        yield return new WaitForSeconds(3);
        FadeOut(PopUp);
    }

}