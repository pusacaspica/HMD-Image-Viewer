using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.SpriteAssetUtilities;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using Random = UnityEngine.Random;

public class TestRoutineController : MonoBehaviour
{
    public float ElapsedTime, ElapsedRoundTime;
    public int images, repeats, pastImages;
    public float exposureTime, restingTime;
    public bool testInSession, resting, voting;
    public List<int> RoundIndexes;
    public List<string> EffectIndexes;
    public TMP_Text textBox;

    public List<GameObject> crosshair;

    public SlideController _slideController;

    public int _indexOnScreen, _prevIndexOnScreen;

    public void ResetTestRoutine()
    {
        pastImages = 0;
        _slideController = this.GetComponent<SlideController>();
        RoundIndexes = new List<int>();
        
        testInSession = false;
        resting = false;
        voting = false;
        ElapsedTime = 0.0f;
        ElapsedRoundTime = 0.0f;
        
        images = _slideController.imageCount;
        for (int i = 0; i < images; i++)
        {
            for (int j = 0; j < repeats; j++)
            {
                RoundIndexes.Add(i);
                switch(i){
                    case 0:
                        EffectIndexes.Add("Subsurface Scattering");
                        break;
                    case 1:
                        EffectIndexes.Add("Emission");
                        break;
                    case 2:
                        EffectIndexes.Add("Colored Shadows");
                        break;
                    case 3:
                        EffectIndexes.Add("Refraction");
                        break;
                    default:
                        EffectIndexes.Add("Reflections");
                        break;
                }
            }
        }

        _indexOnScreen = -1;
    }
    // Start is called before the first frame update
    void Awake()
    {
        ResetTestRoutine();
        _prevIndexOnScreen = -1;
        Debug.Log(RoundIndexes.Count.ToString());


        //textBox.SetText("N. of Images: ", images);
        //textBox.SetText("Current Image: ");
    }

    // Update is called once per frame
    void Update()
    {
        // S for SKIP
        // or START
        // starts next round; elect new image and start the routine again
        if (Input.GetKeyDown(KeyCode.S))
        {
            if(_prevIndexOnScreen == _indexOnScreen) {
                if(RoundIndexes.Count == 0){
                    ResetTestRoutine();
                    _prevIndexOnScreen = -1;
                    return;
                }
                else if(RoundIndexes.Count == 1) 
                    _indexOnScreen = 0;
                else
                    _indexOnScreen = (int) Random.Range((int)0, (int)RoundIndexes.Count);
            }
            _slideController.frame = RoundIndexes[_indexOnScreen];
            Debug.Log(_indexOnScreen.ToString());
            ElapsedRoundTime = 0f;
            testInSession = true;
            resting = false;
            voting = false;
        }

        if (Input.GetKeyDown(KeyCode.H)){
            for(int i=0; i<crosshair.Count;i++){
                crosshair[i].SetActive(!crosshair[i].activeSelf);
            }
        }

        if (testInSession)
        {
            textBox.SetText("Elapsed time: " + ElapsedTime.ToString()+"\n"+"Images: " + pastImages.ToString()+ "/" + (images * repeats).ToString() +"\nEffect on display: " + EffectIndexes[_indexOnScreen] + "\nFoveated? " + _slideController.foveated.ToString());
            if (!resting && !voting)
            {
                _slideController.frame = RoundIndexes[_indexOnScreen];
                textBox.SetText("Elapsed time: " + ElapsedTime.ToString()+"\n"+"Images: " + pastImages.ToString()+ "/" + (images * repeats).ToString() +"\nEffect on display: " + EffectIndexes[_indexOnScreen] + "\nFoveated? " + _slideController.foveated.ToString());
                if (ElapsedRoundTime >= exposureTime)
                {
                    if (!_slideController.foveated)
                    {
                        ElapsedRoundTime = 0f;
                        resting = true;
                    }
                    else
                    {
                        _slideController.foveated = false;
                        ElapsedRoundTime = 0f;
                        _prevIndexOnScreen = _indexOnScreen;
                        RoundIndexes.RemoveAt(_prevIndexOnScreen);
                        EffectIndexes.RemoveAt(_prevIndexOnScreen);
                        _slideController.frame = -1;
                        pastImages++;
                        voting = true;
                    }
                }
            }
            else if(resting && !voting)
            {
                //textBox.SetText("Images: " + pastImages.ToString()+ "/" + (images * repeats).ToString() +"\nEffect on display: " + EffectIndexes[_indexOnScreen] + "\nFoveated? " + _slideController.foveated.ToString());
                _slideController.frame = -1;
                if (ElapsedRoundTime >= restingTime)
                {
                    ElapsedRoundTime = 0f;
                    resting = false;
                    _slideController.foveated = !_slideController.foveated;
                }
            }
            else if(!resting && voting){
                //textBox.SetText("Images: " + pastImages.ToString()+ "/" + (images * repeats).ToString() +"\nEffect on display: " + EffectIndexes[_indexOnScreen] + "\nFoveated? " + _slideController.foveated.ToString());
            }

            ElapsedTime += Time.deltaTime;
                ElapsedRoundTime += Time.deltaTime;
        }
    }
}
