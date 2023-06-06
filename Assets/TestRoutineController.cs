using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.SpriteAssetUtilities;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class TestRoutineController : MonoBehaviour
{
    public float ElapsedTime, ElapsedRoundTime;
    public int images, repeats;
    public float exposureTime, restingTime;
    public bool testInSession, resting, voting;
    public List<int> RoundIndexes;

    private SlideController _slideController;

    private int _indexOnScreen, _prevIndexOnScreen;
    // Start is called before the first frame update
    void Awake()
    {
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
            }
        }

        _indexOnScreen = -1;
        _prevIndexOnScreen = -1;
        Debug.Log(RoundIndexes.Count.ToString());
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // S for SKIP
        // or START
        // starts next round; elect new image and start the routine again
        if (Input.GetKeyDown(KeyCode.S))
        {
            while(_prevIndexOnScreen == _indexOnScreen) _indexOnScreen = (int) Random.Range(0, RoundIndexes.Count);
            _slideController.frame = RoundIndexes[_indexOnScreen];
            Debug.Log(_indexOnScreen.ToString());
            ElapsedRoundTime = 0f;
            testInSession = true;
            resting = false;
            voting = false;
        }

        if (testInSession)
        {
            // RESTING ROUTINE
            // when resting time is over, change from raytraced to foveated;
            /*if (resting)
            {
                _slideController.frame = -1;
                if (ElapsedRoundTime >= restingTime)
                {
                    resting = false;
                    ElapsedRoundTime = 0.0f;
                    _slideController.foveated = true;
                }
            }
            // EXPOSURE ROUTINE
            // when exposure time is over, if the image was raytraced, start resting routine
            // when exposure time is over, if the image was foveated, pick a new image to show and wait for input
            else
            {
                if (ElapsedRoundTime >= exposureTime || !_slideController.foveated)
                {
                    resting = true;
                    ElapsedRoundTime = 0.0f;
                }

                if (ElapsedRoundTime >= exposureTime || _slideController.foveated)
                {
                    ElapsedRoundTime = 0.0f; //reset elapsed time
                    
                    _slideController.foveated = false; //confirm that next round will start by raytraced image
                    
                    // end round
                    _prevIndexOnScreen = _indexOnScreen;
                    int item = RoundIndexes[_prevIndexOnScreen];
                    RoundIndexes.Remove(item);
                    _slideController.frame = -1;
                }
                
                _slideController.frame = RoundIndexes[_indexOnScreen];*/
        //}

        if (!resting && !voting)
        {
            Debug.Log("index on screen: " + _indexOnScreen.ToString());
            _slideController.frame = RoundIndexes[_indexOnScreen];
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
                    _slideController.frame = -1;
                    voting = true;
                }
            }
        }
        else if(resting && !voting)
        {
            _slideController.frame = -1;
            if (ElapsedRoundTime >= restingTime)
            {
                ElapsedRoundTime = 0f;
                resting = false;
                _slideController.foveated = !_slideController.foveated;
            }
        }

        ElapsedTime += Time.deltaTime;
            ElapsedRoundTime += Time.deltaTime;
        }
    }
}
