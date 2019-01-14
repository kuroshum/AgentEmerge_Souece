using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Text;

public class StageScore : MonoBehaviour {
    void Start()
    {
        Sort();
        k = 0;
        ReadFile();
    }

    void Update()
    {

    }
    /*スコア始まり*/
    public static void Sort()
    {
        int cnt = 0;
        StreamReader fp = new StreamReader("ScoreData" + Player_controller2.cene + ".txt", Encoding.UTF8);
        string text;
        /*
        ArrayList al = new ArrayList();
        while((text = fp.ReadLine()) != null)
        {
            al.Add(text);
            cnt++;
        }
        */
        int subcnt = 0;
        while ((text = fp.ReadLine()) != null)
        {
            subcnt++;
        }
        string[] name = new string[subcnt];
        int[] score = new int[subcnt];
        string buffn;
        int buffs;
        char sp = ' ';
        while((text = fp.ReadLine()) != null)
        {
            //            string[] values = text.Split(new char[] { ' ' });
            string[] values = new string[2];
            values = text.Split(sp);
            name[cnt] = values[0];
            score[cnt] = int.Parse(values[1]);
            cnt++;
        }
        fp.Close();
        StreamWriter fb = new StreamWriter("ScoreDataSort" + Player_controller2.cene + ".txt", false);
        for (int m = 0; m < cnt; m++)
        {
            for (int n = 0; n < cnt; n++)
            {
                if (score[m]<score[n])
                {
                    buffs = score[m];
                    score[m] = score[n];
                    score[n] = buffs;

                    buffn = name[m];
                    name[m] = name[n];
                    name[n] = buffn;
                    
                }
            }
            fb.WriteLine(name[m] + " " + score[m]);
        }
        fb.Flush();
        fb.Close();
    }
    /*ソート終わり*/

    public Text[] scoreText = new Text[4];
    private string[] guitxt = new string[4];
    public static int k = 0;
    private void ReadFile()
    {
        for (int i = 0; i < 3; i++)
        {
            k = i + 1;
            StreamReader Fp = new StreamReader("C:/Users/kurosyun/Desktop/AgentEmerge5/ScoreData" + k + ".txt", Encoding.UTF8);
            guitxt[i] = Fp.ReadToEnd();
            Fp.Close();
            scoreText[i].text = string.Format("名前\t\tTotal\n" + guitxt[i]);
        }
    }

}
