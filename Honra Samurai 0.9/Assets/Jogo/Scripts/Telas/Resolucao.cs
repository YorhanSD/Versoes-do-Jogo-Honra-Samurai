using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resolucao : MonoBehaviour
{
    public void Resolucao_ULTRA_HD()
    {
        Screen.SetResolution(2160,1440, true);
    }
    public void Resolucao_FULL_HD()
    {
        Screen.SetResolution(1920,1080, true);
    }
    public void Resolucao_HD()
    {
        Screen.SetResolution(1280,720, true);
    }
    public void Resolucao_XGA()
    {
        Screen.SetResolution(1024,768, true);
    }
    public void Resolucao_qHD()
    {
        Screen.SetResolution(960,540, true);
    }
}
