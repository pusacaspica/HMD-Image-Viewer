using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SlideController : MonoBehaviour
{
    // How many different angles are you testing against
    public int imageCount = 5;
    
    // The path for your images. The string that returns your images should be:
    // PATH + "/" + PREFIX + (i + 1) + "." + FORMAT
    //
    // For example, if I have JPG images (img1, img2, img3...) and (alt1, alt2, alt3...) at path "Assets/Images",
    // the strings should be named as following:
    // path = "Assets/Images"
    // prefix1 = "img"
    // prefix2 = "alt"
    // fomrat = "jpg"
    public string path, prefix1, prefix2, format;
    
    public Material imageOnDisplay;
    public Texture2D debugImage;
    public List<List<Texture2D>> Images;
    public TestRoutineController testRoutineController;

    [NonSerialized] public int frame = 0;

    public bool foveated = false;

    void Awake()
    {
        testRoutineController = this.GetComponent<TestRoutineController>();
        Images = new List<List<Texture2D>>();
        path = Application.dataPath; 
        for(int i = 0; i < imageCount; i++)
        {
            List<Texture2D> pair = new List<Texture2D>();
            //Debug.Log((Texture2D)AssetDatabase.LoadAssetAtPath(
            //    "Assets/Images/raytraced_frame" + (i + 1).ToString() + ".png", typeof(Texture2D)));
            pair.Add(Resources.Load<Texture2D>(prefix1 + (i + 1).ToString()));
            Debug.Log(pair[0]);
            //pair.Add((Texture2D)AssetDatabase.LoadAssetAtPath(path + "/" + prefix1 + (i + 1).ToString() + "." + format, typeof(Texture2D)));
            pair.Add(Resources.Load<Texture2D>(prefix2 + (i + 1).ToString()));
            Debug.Log(pair[1]);
            //pair.Add((Texture2D)AssetDatabase.LoadAssetAtPath(path + "/" + prefix2 + (i + 1).ToString() + "." + format, typeof(Texture2D)));
            Images.Add(pair);
            
            //Debug.Log("added: Images/raytraced_frame" + (i + 1).ToString() + ".png");
            //Debug.Log("added: Images/foveated_frame" + (i + 1).ToString() + ".png");
        }

        frame = -1;

        Debug.Log(Images.Count.ToString() + " images loaded");
    }

    // Update is called once per frame
    void Update()
    {
        if (frame == -1) imageOnDisplay.mainTexture = debugImage;
        else imageOnDisplay.mainTexture = Images[frame][foveated ? 1 : 0];

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            frame = (frame == 0) ? Images.Count - 1 : frame-1;
            //Debug.Log("_frame is "+frame.ToString());
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            frame = (frame == (Images.Count - 1)) ? 0 : frame+1;
            //Debug.Log("_frame is "+frame.ToString());
        }
        
        if(Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.Backspace))
        {
            foveated = !foveated;
            //Debug.Log("foveated is "+foveated.ToString());
        }

        if (Input.GetKeyDown(KeyCode.Alpha0) ||
            Input.GetKeyDown(KeyCode.Keypad0)) {frame = 0;
            Debug.Log("_frame is "+frame.ToString());}
        if (Input.GetKeyDown(KeyCode.Alpha1) ||
            Input.GetKeyDown(KeyCode.Keypad1)) {frame = 1;
            Debug.Log("_frame is "+frame.ToString());}
        if (Input.GetKeyDown(KeyCode.Alpha2) ||
            Input.GetKeyDown(KeyCode.Keypad2)) {frame = 2;
            Debug.Log("_frame is "+frame.ToString());}
        if (Input.GetKeyDown(KeyCode.Alpha3) ||
            Input.GetKeyDown(KeyCode.Keypad3)) {frame = 3;
            Debug.Log("_frame is "+frame.ToString());}
        if (Input.GetKeyDown(KeyCode.Alpha4) ||
            Input.GetKeyDown(KeyCode.Keypad4)) {frame = 4;
            Debug.Log("_frame is "+frame.ToString());}
        if (Input.GetKeyDown(KeyCode.Alpha5) ||
            Input.GetKeyDown(KeyCode.Keypad5)) {frame = 5;
            Debug.Log("_frame is "+frame.ToString());}
        if (Input.GetKeyDown(KeyCode.Alpha6) ||
            Input.GetKeyDown(KeyCode.Keypad6)) {frame = 6;
            Debug.Log("_frame is "+frame.ToString());}
        if (Input.GetKeyDown(KeyCode.Alpha7) ||
            Input.GetKeyDown(KeyCode.Keypad7)) {frame = 7;
            Debug.Log("_frame is "+frame.ToString());}
        if (Input.GetKeyDown(KeyCode.Alpha8) ||
            Input.GetKeyDown(KeyCode.Keypad8)) {frame = 8;
            Debug.Log("_frame is "+frame.ToString());}
        if (Input.GetKeyDown(KeyCode.Alpha9) ||
            Input.GetKeyDown(KeyCode.Keypad9)) {frame = 9;
            Debug.Log("_frame is "+frame.ToString());}
    }
}
