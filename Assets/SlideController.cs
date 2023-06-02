using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SlideController : MonoBehaviour
{
    // How many different angles are you testing against
    public int imageCount = 12;
    
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

    public List<List<Texture2D>> Images;

    private int _frame = 0;

    private bool foveated = false;

    void Awake()
    {
        Images = new List<List<Texture2D>>();
        for(int i = 0; i < imageCount; i++)
        {
            List<Texture2D> pair = new List<Texture2D>();
            Debug.Log((Texture2D)AssetDatabase.LoadAssetAtPath(
                "Assets/Images/raytraced_frame" + (i + 1).ToString() + ".png", typeof(Texture2D)));
            pair.Add((Texture2D)AssetDatabase.LoadAssetAtPath(path + "/" + prefix1 + (i + 1).ToString() + "." + format, typeof(Texture2D)));
            pair.Add((Texture2D)AssetDatabase.LoadAssetAtPath(path + "/" + prefix2 + (i + 1).ToString() + "." + format, typeof(Texture2D)));
            Images.Add(pair);
            
            Debug.Log("added: Images/raytraced_frame" + (i + 1).ToString() + ".png");
            Debug.Log("added: Images/foveated_frame" + (i + 1).ToString() + ".png");
        }

        Debug.Log(Images.Count.ToString() + " images loaded");
    }

    // Update is called once per frame
    void Update()
    {
        imageOnDisplay.mainTexture = Images[_frame][foveated ? 1 : 0];

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _frame = (_frame == 0) ? Images.Count - 1 : _frame-1;
            Debug.Log("_frame is "+_frame.ToString());
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            _frame = (_frame == (Images.Count - 1)) ? 0 : _frame+1;
            Debug.Log("_frame is "+_frame.ToString());
        }
        
        if(Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.Backspace))
        {
            foveated = !foveated;
            Debug.Log("foveated is "+foveated.ToString());
        }

        if (Input.GetKeyDown(KeyCode.Alpha0) ||
            Input.GetKeyDown(KeyCode.Keypad0)) {_frame = 0;
            Debug.Log("_frame is "+_frame.ToString());}
        if (Input.GetKeyDown(KeyCode.Alpha1) ||
            Input.GetKeyDown(KeyCode.Keypad1)) {_frame = 1;
            Debug.Log("_frame is "+_frame.ToString());}
        if (Input.GetKeyDown(KeyCode.Alpha2) ||
            Input.GetKeyDown(KeyCode.Keypad2)) {_frame = 2;
            Debug.Log("_frame is "+_frame.ToString());}
        if (Input.GetKeyDown(KeyCode.Alpha3) ||
            Input.GetKeyDown(KeyCode.Keypad3)) {_frame = 3;
            Debug.Log("_frame is "+_frame.ToString());}
        if (Input.GetKeyDown(KeyCode.Alpha4) ||
            Input.GetKeyDown(KeyCode.Keypad4)) {_frame = 4;
            Debug.Log("_frame is "+_frame.ToString());}
        if (Input.GetKeyDown(KeyCode.Alpha5) ||
            Input.GetKeyDown(KeyCode.Keypad5)) {_frame = 5;
            Debug.Log("_frame is "+_frame.ToString());}
        if (Input.GetKeyDown(KeyCode.Alpha6) ||
            Input.GetKeyDown(KeyCode.Keypad6)) {_frame = 6;
            Debug.Log("_frame is "+_frame.ToString());}
        if (Input.GetKeyDown(KeyCode.Alpha7) ||
            Input.GetKeyDown(KeyCode.Keypad7)) {_frame = 7;
            Debug.Log("_frame is "+_frame.ToString());}
        if (Input.GetKeyDown(KeyCode.Alpha8) ||
            Input.GetKeyDown(KeyCode.Keypad8)) {_frame = 8;
            Debug.Log("_frame is "+_frame.ToString());}
        if (Input.GetKeyDown(KeyCode.Alpha9) ||
            Input.GetKeyDown(KeyCode.Keypad9)) {_frame = 9;
            Debug.Log("_frame is "+_frame.ToString());}
    }
}
