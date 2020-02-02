using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    // 總時間設定
    public int time_int;

    public bool pass;

    public Text time_UI;
    public GameObject gameover;

    //初始值
    void Awake(){
        //呼叫計時器,每秒數一次
        InvokeRepeating("timer", 1 , 1 );
        //初始字體顏色及大小設定
        time_UI.GetComponent<Text>().color = Color.white;
        time_UI.GetComponent<Text>().fontSize = 72;
        time_UI.text = time_int + "";
    }

    //計時器
    void timer(){
        //數值減1
        time_int -= 1;
        //印出數值
        time_UI.text = time_int + "";

        //倒數至小於10後開始變化
        if( time_int < 10 ) {
        //字體顏色變紅及大小改變
        time_UI.GetComponent<Text>().color = Color.red;
        time_UI.GetComponent<Text>().fontSize = 86;
        //呼叫心跳的感覺
        Invoke("HeartBeat", 0.5f );
            //判斷時間到
            if (time_int == 0) {
                time_UI.GetComponent<Text>().fontSize = 50;
                time_UI.text = "TIME's UP";
                CancelInvoke("timer");
                CancelInvoke("HeartBeat");
                gameover.SetActive(true);
            }
        }
    }
    
    //心跳的感覺
    void HeartBeat(){
        time_UI.GetComponent<Text>().fontSize = 72;
    }
}
