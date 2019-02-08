
using UnityEngine;

public class HoloTexture : MonoBehaviour
{
//this was created to work in conjunction with hologram shader.
//this is github repo of person who shared the shader.
//https://github.com/andydbc/HologramShader
//Add this to object above material.
     
        public float Speed;
        //matId is the id of the material in the inspector, in the case where object has multiple materials
        public int MatId;
        //to easily add frames create a folder with textures numbered 0 upwards.
        //lock inspector on script, drag allframes into frame array in script and auto creates populated list of frames.
        public Texture[] Frames;
        int i;
        Material _Material;
    
        void Awake()
        {
            Random.InitState((int)System.DateTime.Now.Ticks * 1000);
        }
    
    	// Use this for initialization
    	void Start () 
        {
            _Material = GetComponent<Renderer>().materials[MatId];
           
    	}
    	
    	// Update is called once per frame
    	void Update () 
        {
            i = (int)(Time.time * Speed);
            i = i % Frames.Length;
            _Material.mainTexture = Frames[i];
    	}
}
