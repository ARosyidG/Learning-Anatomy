using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine.UI;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.UI;
using Unity.XR.CoreUtils;

public class Bone : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject TheBone;
    
    Transform partContainer;
    [SerializeField]
    GameObject NamePlate;
    
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void setBoneNamePlate(){
        GameObject NamePlateTemp = Instantiate(this.NamePlate);
        Debug.Log(TheBone);
        NamePlateTemp.transform.localScale = new Vector3(1.5f/TheBone.transform.localScale.x,1.5f/TheBone.transform.localScale.y,1.5f/TheBone.transform.localScale.z);
        partContainer = TheBone.transform.Find("Part");
        foreach(Transform child in partContainer.transform){
            Vector3 namePosition = child.position + (child.forward*2);
            GameObject name = Instantiate(NamePlateTemp,child);
            name.SetActive(true);
            name.name = "NamePlatePointer";
            name.gameObject.transform.position = namePosition;
            name.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().SetText("");
            LineRenderer nameLine = name.GetComponent<LineRenderer>();
            nameLine.SetPosition(1,name.transform.position);
            nameLine.SetPosition(0,child.position);
        }
        Destroy(NamePlateTemp);
    }
    
    public void NamePlateSwitch(){
        partContainer = TheBone.transform.Find("Part");
        Debug.Log("Jlmn");
        foreach(Transform part in partContainer){
            TrackedDeviceGraphicRaycaster trackingComponent = part.Find("NamePlatePointer").GetComponent<TrackedDeviceGraphicRaycaster>();
            
            if(!trackingComponent.isActiveAndEnabled){
                trackingComponent.enabled = true;
            }else{
                trackingComponent.enabled = false;
            }
        }
    }
}
