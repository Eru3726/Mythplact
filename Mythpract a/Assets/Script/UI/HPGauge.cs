using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPGauge : MonoBehaviour
{

    ParticleSystem gauge1;
    ParticleSystem gauge2;
    ParticleSystem gauge3;
    ParticleSystem gauge4;
    ParticleSystem gauge5;
    ParticleSystem gauge6;
    ParticleSystem gauge7;
    ParticleSystem gauge8;
    ParticleSystem gauge9;
    ParticleSystem gauge10;
    ParticleSystem gauge11;
    ParticleSystem gauge12;
    ParticleSystem gauge13;
    ParticleSystem gauge14;
    ParticleSystem gauge15;
    ParticleSystem gauge16;
    ParticleSystem gauge17;
    ParticleSystem gauge18;
    ParticleSystem gauge19;
    ParticleSystem gauge20;


    ParticleSystem gauge1_break;
    ParticleSystem gauge2_break;
    ParticleSystem gauge3_break;
    ParticleSystem gauge4_break;
    ParticleSystem gauge5_break;
    ParticleSystem gauge6_break;
    ParticleSystem gauge7_break;
    ParticleSystem gauge8_break;
    ParticleSystem gauge9_break;
    ParticleSystem gauge10_break;


    ParticleSystem gauge1_sub;
    ParticleSystem gauge2_sub;
    ParticleSystem gauge3_sub;
    ParticleSystem gauge4_sub;
    ParticleSystem gauge5_sub;
    ParticleSystem gauge6_sub;
    ParticleSystem gauge7_sub;
    ParticleSystem gauge8_sub;
    ParticleSystem gauge9_sub;
    ParticleSystem gauge10_sub;


    ParticleSystem gauge1_fres;
    ParticleSystem gauge2_fres;
    ParticleSystem gauge3_fres;
    ParticleSystem gauge4_fres;
    ParticleSystem gauge5_fres;
    ParticleSystem gauge6_fres;
    ParticleSystem gauge7_fres;
    ParticleSystem gauge8_fres;
    ParticleSystem gauge9_fres;
    ParticleSystem gauge10_fres;


    //ParticleSystem gaugeaura;

    [SerializeField]Color firstcolor;
    [SerializeField]Color secondcolor;
    Image img;
    SY.HitMng hitMng;

    void Start()
    {
        img = gameObject.GetComponent<Image>();
        hitMng = GameObject.Find("Player").GetComponent<SY.HitMng>();
        gauge1 = GameObject.Find("UI/HPGauge/Gauge/1/HPaura").GetComponent<ParticleSystem>();
        gauge2 = GameObject.Find("UI/HPGauge/Gauge/2/HPaura").GetComponent<ParticleSystem>();
        gauge3 = GameObject.Find("UI/HPGauge/Gauge/3/HPaura").GetComponent<ParticleSystem>();
        gauge4 = GameObject.Find("UI/HPGauge/Gauge/4/HPaura").GetComponent<ParticleSystem>();
        gauge5 = GameObject.Find("UI/HPGauge/Gauge/5/HPaura").GetComponent<ParticleSystem>();
        gauge6 = GameObject.Find("UI/HPGauge/Gauge/6/HPaura").GetComponent<ParticleSystem>();
        gauge7 = GameObject.Find("UI/HPGauge/Gauge/7/HPaura").GetComponent<ParticleSystem>();
        gauge8 = GameObject.Find("UI/HPGauge/Gauge/8/HPaura").GetComponent<ParticleSystem>();
        gauge9 = GameObject.Find("UI/HPGauge/Gauge/9/HPaura").GetComponent<ParticleSystem>();
        gauge10 = GameObject.Find("UI/HPGauge/Gauge/10/HPaura").GetComponent<ParticleSystem>();
        gauge11 = GameObject.Find("UI/HPGauge/Gauge/11/HPaura").GetComponent<ParticleSystem>();
        gauge12 = GameObject.Find("UI/HPGauge/Gauge/12/HPaura").GetComponent<ParticleSystem>();
        gauge13 = GameObject.Find("UI/HPGauge/Gauge/13/HPaura").GetComponent<ParticleSystem>();
        gauge14 = GameObject.Find("UI/HPGauge/Gauge/14/HPaura").GetComponent<ParticleSystem>();
        gauge15 = GameObject.Find("UI/HPGauge/Gauge/15/HPaura").GetComponent<ParticleSystem>();
        gauge16 = GameObject.Find("UI/HPGauge/Gauge/16/HPaura").GetComponent<ParticleSystem>();
        gauge17 = GameObject.Find("UI/HPGauge/Gauge/17/HPaura").GetComponent<ParticleSystem>();
        gauge18 = GameObject.Find("UI/HPGauge/Gauge/18/HPaura").GetComponent<ParticleSystem>();
        gauge19 = GameObject.Find("UI/HPGauge/Gauge/19/HPaura").GetComponent<ParticleSystem>();
        gauge20 = GameObject.Find("UI/HPGauge/Gauge/20/HPaura").GetComponent<ParticleSystem>();





        gauge1_break = GameObject.Find("UI/HPGauge/Gauge/1/HPburstaura").GetComponent<ParticleSystem>();
        gauge2_break = GameObject.Find("UI/HPGauge/Gauge/2/HPburstaura").GetComponent<ParticleSystem>();
        gauge3_break = GameObject.Find("UI/HPGauge/Gauge/3/HPburstaura").GetComponent<ParticleSystem>();
        gauge4_break = GameObject.Find("UI/HPGauge/Gauge/4/HPburstaura").GetComponent<ParticleSystem>();
        gauge5_break = GameObject.Find("UI/HPGauge/Gauge/5/HPburstaura").GetComponent<ParticleSystem>();
        gauge6_break = GameObject.Find("UI/HPGauge/Gauge/6/HPburstaura").GetComponent<ParticleSystem>();
        gauge7_break = GameObject.Find("UI/HPGauge/Gauge/7/HPburstaura").GetComponent<ParticleSystem>();
        gauge8_break = GameObject.Find("UI/HPGauge/Gauge/8/HPburstaura").GetComponent<ParticleSystem>();
        gauge9_break = GameObject.Find("UI/HPGauge/Gauge/9/HPburstaura").GetComponent<ParticleSystem>();
        gauge10_break = GameObject.Find("UI/HPGauge/Gauge/10/HPburstaura").GetComponent<ParticleSystem>();


        gauge1_sub = gauge1.transform.GetChild(0).GetComponent<ParticleSystem>();
        gauge2_sub = gauge2.transform.GetChild(0).GetComponent<ParticleSystem>();
        gauge3_sub = gauge3.transform.GetChild(0).GetComponent<ParticleSystem>();
        gauge4_sub = gauge4.transform.GetChild(0).GetComponent<ParticleSystem>();
        gauge5_sub = gauge5.transform.GetChild(0).GetComponent<ParticleSystem>();
        gauge6_sub = gauge6.transform.GetChild(0).GetComponent<ParticleSystem>();
        gauge7_sub = gauge7.transform.GetChild(0).GetComponent<ParticleSystem>();
        gauge8_sub = gauge8.transform.GetChild(0).GetComponent<ParticleSystem>();
        gauge9_sub = gauge9.transform.GetChild(0).GetComponent<ParticleSystem>();
        gauge10_sub = gauge10.transform.GetChild(0).GetComponent<ParticleSystem>();

        gauge1_fres = gauge1.transform.GetChild(1).GetComponent<ParticleSystem>();
        gauge2_fres = gauge2.transform.GetChild(1).GetComponent<ParticleSystem>();
        gauge3_fres = gauge3.transform.GetChild(1).GetComponent<ParticleSystem>();
        gauge4_fres = gauge4.transform.GetChild(1).GetComponent<ParticleSystem>();
        gauge5_fres = gauge5.transform.GetChild(1).GetComponent<ParticleSystem>();
        gauge6_fres = gauge6.transform.GetChild(1).GetComponent<ParticleSystem>();
        gauge7_fres = gauge7.transform.GetChild(1).GetComponent<ParticleSystem>();
        gauge8_fres = gauge8.transform.GetChild(1).GetComponent<ParticleSystem>();
        gauge9_fres = gauge9.transform.GetChild(1).GetComponent<ParticleSystem>();
        gauge10_fres = gauge10.transform.GetChild(1).GetComponent<ParticleSystem>();



    }

    void Update()
    {
        switch (hitMng.HP)
        {
            case 0:
                gauge1.Stop();
                if (gauge1.isPlaying) gauge1_break.Play();
                else gauge1_break.Stop();

                gauge2.Clear();
                gauge3.Clear();
                gauge4.Clear();
                gauge5.Clear();
                gauge6.Clear();
                gauge7.Clear();
                gauge8.Clear();
                gauge9.Clear();
                gauge10.Clear();

                gauge11.Clear();
                gauge12.Clear();
                gauge13.Clear();
                gauge14.Clear();
                gauge15.Clear();
                gauge16.Clear();
                gauge17.Clear();
                gauge18.Clear();
                gauge19.Clear();
                gauge20.Clear();


                break;
            case 1:
                gauge1.Play();
                gauge2.Stop();
                if (gauge2.isPlaying) gauge2_break.Play();
                else gauge2_break.Stop();

                gauge3.Clear();
                gauge4.Clear();
                gauge5.Clear();
                gauge6.Clear();
                gauge7.Clear();
                gauge8.Clear();
                gauge9.Clear();
                gauge10.Clear();

                gauge11.Clear();
                gauge12.Clear();
                gauge13.Clear();
                gauge14.Clear();
                gauge15.Clear();
                gauge16.Clear();
                gauge17.Clear();
                gauge18.Clear();
                gauge19.Clear();
                gauge20.Clear();

                break;
            case 2:
                gauge1.Play();
                gauge2.Play();
                gauge3.Stop();
                if (gauge3.isPlaying) gauge3_break.Play();
                else gauge3_break.Stop();

                gauge4.Clear();
                gauge5.Clear();
                gauge6.Clear();
                gauge7.Clear();
                gauge8.Clear();
                gauge9.Clear();
                gauge10.Clear();

                gauge11.Clear();
                gauge12.Clear();
                gauge13.Clear();
                gauge14.Clear();
                gauge15.Clear();
                gauge16.Clear();
                gauge17.Clear();
                gauge18.Clear();
                gauge19.Clear();
                gauge20.Clear();

                break;
            case 3:
                gauge1.Play();
                gauge2.Play();
                gauge3.Play();
                gauge4.Stop();
                if (gauge4.isPlaying) gauge4_break.Play();
                else gauge4_break.Stop();

                gauge5.Clear();
                gauge6.Clear();
                gauge7.Clear();
                gauge8.Clear();
                gauge9.Clear();
                gauge10.Clear();

                gauge11.Clear();
                gauge12.Clear();
                gauge13.Clear();
                gauge14.Clear();
                gauge15.Clear();
                gauge16.Clear();
                gauge17.Clear();
                gauge18.Clear();
                gauge19.Clear();
                gauge20.Clear();

                break;
            case 4:
                gauge1.Play();
                gauge2.Play();
                gauge3.Play();
                gauge4.Play();
                gauge5.Stop();
                if (gauge5.isPlaying) gauge5_break.Play();
                else gauge5_break.Stop();

                gauge6.Clear();
                gauge7.Clear();
                gauge8.Clear();
                gauge9.Clear();
                gauge10.Clear();

                gauge11.Clear();
                gauge12.Clear();
                gauge13.Clear();
                gauge14.Clear();
                gauge15.Clear();
                gauge16.Clear();
                gauge17.Clear();
                gauge18.Clear();
                gauge19.Clear();
                gauge20.Clear();

                break;
            case 5:
                gauge1.Play();
                gauge2.Play();
                gauge3.Play();
                gauge4.Play();
                gauge5.Play();
                gauge6.Stop();
                if (gauge6.isPlaying) gauge6_break.Play();
                else gauge6_break.Stop();

                gauge7.Clear();
                gauge8.Clear();
                gauge9.Clear();
                gauge10.Clear();

                gauge11.Clear();
                gauge12.Clear();
                gauge13.Clear();
                gauge14.Clear();
                gauge15.Clear();
                gauge16.Clear();
                gauge17.Clear();
                gauge18.Clear();
                gauge19.Clear();
                gauge20.Clear();

                break;
            case 6:
                gauge1.Play();
                gauge2.Play();
                gauge3.Play();
                gauge4.Play();
                gauge5.Play();
                gauge6.Play();
                gauge7.Stop();
                if (gauge7.isPlaying) gauge7_break.Play();
                else gauge7_break.Stop();

                gauge8.Clear();
                gauge9.Clear();
                gauge10.Clear();

                gauge11.Clear();
                gauge12.Clear();
                gauge13.Clear();
                gauge14.Clear();
                gauge15.Clear();
                gauge16.Clear();
                gauge17.Clear();
                gauge18.Clear();
                gauge19.Clear();
                gauge20.Clear();

                break;
            case 7:
                gauge1.Play();
                gauge2.Play();
                gauge3.Play();
                gauge4.Play();
                gauge5.Play();
                gauge6.Play();
                gauge7.Play();
                gauge8.Stop();
                if (gauge8.isPlaying) gauge8_break.Play();
                else gauge8_break.Stop();

                gauge9.Clear();
                gauge10.Clear();

                gauge11.Clear();
                gauge12.Clear();
                gauge13.Clear();
                gauge14.Clear();
                gauge15.Clear();
                gauge16.Clear();
                gauge17.Clear();
                gauge18.Clear();
                gauge19.Clear();
                gauge20.Clear();

                break;
            case 8:
                gauge1.Play();
                gauge2.Play();
                gauge3.Play();
                gauge4.Play();
                gauge5.Play();
                gauge6.Play();
                gauge7.Play();
                gauge8.Play();
                gauge9.Stop();
                if (gauge9.isPlaying) gauge9_break.Play();
                else gauge9_break.Stop();

                gauge10.Clear();

                gauge11.Clear();
                gauge12.Clear();
                gauge13.Clear();
                gauge14.Clear();
                gauge15.Clear();
                gauge16.Clear();
                gauge17.Clear();
                gauge18.Clear();
                gauge19.Clear();
                gauge20.Clear();

                break;
            case 9:
                gauge1.Play();
                gauge2.Play();
                gauge3.Play();
                gauge4.Play();
                gauge5.Play();
                gauge6.Play();
                gauge7.Play();
                gauge8.Play();
                gauge9.Play();
                gauge10.Stop();
                if (gauge10.isPlaying) gauge10_break.Play();
                else gauge10_break.Stop();

                gauge11.Clear();
                gauge12.Clear();
                gauge13.Clear();
                gauge14.Clear();
                gauge15.Clear();
                gauge16.Clear();
                gauge17.Clear();
                gauge18.Clear();
                gauge19.Clear();
                gauge20.Clear();

                break;
            case 10:
                gauge1.Play();
                gauge2.Play();
                gauge3.Play();
                gauge4.Play();
                gauge5.Play();
                gauge6.Play();
                gauge7.Play();
                gauge8.Play();
                gauge9.Play();
                gauge10.Play();

                gauge11.Stop();
                gauge12.Clear();
                gauge13.Clear();
                gauge14.Clear();
                gauge15.Clear();
                gauge16.Clear();
                gauge17.Clear();
                gauge18.Clear();
                gauge19.Clear();
                gauge20.Clear();

                break;
            case 11:
                gauge1.Stop();
                gauge2.Play();
                gauge3.Play();
                gauge4.Play();
                gauge5.Play();
                gauge6.Play();
                gauge7.Play();
                gauge8.Play();
                gauge9.Play();
                gauge10.Play();

                gauge11.Play();
                gauge12.Stop();
                gauge13.Stop();
                gauge14.Stop();
                gauge15.Stop();
                gauge16.Stop();
                gauge17.Stop();
                gauge18.Stop();
                gauge19.Stop();
                gauge20.Stop();

                break;

            case 12:
                gauge1.Stop();
                gauge2.Stop();
                gauge3.Play();
                gauge4.Play();
                gauge5.Play();
                gauge6.Play();
                gauge7.Play();
                gauge8.Play();
                gauge9.Play();
                gauge10.Play();

                gauge11.Play();
                gauge12.Play();
                gauge13.Stop();
                gauge14.Stop();
                gauge15.Stop();
                gauge16.Stop();
                gauge17.Stop();
                gauge18.Stop();
                gauge19.Stop();
                gauge20.Stop();

                break;

            case 13:
                gauge1.Stop();
                gauge2.Stop();
                gauge3.Stop();
                gauge4.Play();
                gauge5.Play();
                gauge6.Play();
                gauge7.Play();
                gauge8.Play();
                gauge9.Play();
                gauge10.Play();

                gauge11.Play();
                gauge12.Play();
                gauge13.Play();
                gauge14.Stop();
                gauge15.Stop();
                gauge16.Stop();
                gauge17.Stop();
                gauge18.Stop();
                gauge19.Stop();
                gauge20.Stop();

                break;

            case 14:
                gauge1.Stop();
                gauge2.Stop();
                gauge3.Stop();
                gauge4.Stop();
                gauge5.Play();
                gauge6.Play();
                gauge7.Play();
                gauge8.Play();
                gauge9.Play();
                gauge10.Play();

                gauge11.Play();
                gauge12.Play();
                gauge13.Play();
                gauge14.Play();
                gauge15.Stop();
                gauge16.Stop();
                gauge17.Stop();
                gauge18.Stop();
                gauge19.Stop();
                gauge20.Stop();

                break;

            case 15:
                gauge1.Stop();
                gauge2.Stop();
                gauge3.Stop();
                gauge4.Stop();
                gauge5.Stop();
                gauge6.Play();
                gauge7.Play();
                gauge8.Play();
                gauge9.Play();
                gauge10.Play();

                gauge11.Play();
                gauge12.Play();
                gauge13.Play();
                gauge14.Play();
                gauge15.Play();
                gauge16.Stop();
                gauge17.Stop();
                gauge18.Stop();
                gauge19.Stop();
                gauge20.Stop();

                break;

            case 16:
                gauge1.Stop();
                gauge2.Stop();
                gauge3.Stop();
                gauge4.Stop();
                gauge5.Stop();
                gauge6.Stop();
                gauge7.Play();
                gauge8.Play();
                gauge9.Play();
                gauge10.Play();

                gauge11.Play();
                gauge12.Play();
                gauge13.Play();
                gauge14.Play();
                gauge15.Play();
                gauge16.Play();
                gauge17.Stop();
                gauge18.Stop();
                gauge19.Stop();
                gauge20.Stop();

                break;
            case 17:
                gauge1.Stop();
                gauge2.Stop();
                gauge3.Stop();
                gauge4.Stop();
                gauge5.Stop();
                gauge6.Stop();
                gauge7.Stop();
                gauge8.Play();
                gauge9.Play();
                gauge10.Play();

                gauge11.Play();
                gauge12.Play();
                gauge13.Play();
                gauge14.Play();
                gauge15.Play();
                gauge16.Play();
                gauge17.Play();
                gauge18.Stop();
                gauge19.Stop();
                gauge20.Stop();

                break;

            case 18:
                gauge1.Stop();
                gauge2.Stop();
                gauge3.Stop();
                gauge4.Stop();
                gauge5.Stop();
                gauge6.Stop();
                gauge7.Stop();
                gauge8.Stop();
                gauge9.Play();
                gauge10.Play();

                gauge11.Play();
                gauge12.Play();
                gauge13.Play();
                gauge14.Play();
                gauge15.Play();
                gauge16.Play();
                gauge17.Play();
                gauge18.Play();
                gauge19.Stop();
                gauge20.Stop();

                break;


            case 19:
                gauge1.Stop();
                gauge2.Stop();
                gauge3.Stop();
                gauge4.Stop();
                gauge5.Stop();
                gauge6.Stop();
                gauge7.Stop();
                gauge8.Stop();
                gauge9.Stop();
                gauge10.Play();

                gauge11.Play();
                gauge12.Play();
                gauge13.Play();
                gauge14.Play();
                gauge15.Play();
                gauge16.Play();
                gauge17.Play();
                gauge18.Play();
                gauge19.Play();
                gauge20.Stop();

                break;

            case 20:
                gauge1.Stop();
                gauge2.Stop();
                gauge3.Stop();
                gauge4.Stop();
                gauge5.Stop();
                gauge6.Stop();
                gauge7.Stop();
                gauge8.Stop();
                gauge9.Stop();
                gauge10.Stop();

                gauge11.Play();
                gauge12.Play();
                gauge13.Play();
                gauge14.Play();
                gauge15.Play();
                gauge16.Play();
                gauge17.Play();
                gauge18.Play();
                gauge19.Play();
                gauge20.Play();

                break;
            default:
                break;
        }

        //if(hitMng.HP <= 10)
        //{
        //    var submain1 = gauge1_sub.main;
        //    var submain2 = gauge2_sub.main;
        //    var submain3 = gauge3_sub.main;
        //    var submain4 = gauge4_sub.main;
        //    var submain5 = gauge5_sub.main;
        //    var submain6 = gauge6_sub.main;
        //    var submain7 = gauge7_sub.main;
        //    var submain8 = gauge8_sub.main;
        //    var submain9 = gauge9_sub.main;
        //    var submain10 = gauge10_sub.main;

        //    var fresmain1 = gauge1_fres.main;
        //    var fresmain2 = gauge2_fres.main;
        //    var fresmain3 = gauge3_fres.main;
        //    var fresmain4 = gauge4_fres.main;
        //    var fresmain5 = gauge5_fres.main;
        //    var fresmain6 = gauge6_fres.main;
        //    var fresmain7 = gauge7_fres.main;
        //    var fresmain8 = gauge8_fres.main;
        //    var fresmain9 = gauge9_fres.main;
        //    var fresmain10 = gauge10_fres.main;

        //    submain1.startColor = new ParticleSystem.MinMaxGradient(firstcolor);
        //    submain2.startColor = new ParticleSystem.MinMaxGradient(firstcolor);
        //    submain3.startColor = new ParticleSystem.MinMaxGradient(firstcolor);
        //    submain4.startColor = new ParticleSystem.MinMaxGradient(firstcolor);
        //    submain5.startColor = new ParticleSystem.MinMaxGradient(firstcolor);
        //    submain6.startColor = new ParticleSystem.MinMaxGradient(firstcolor);
        //    submain7.startColor = new ParticleSystem.MinMaxGradient(firstcolor);
        //    submain8.startColor = new ParticleSystem.MinMaxGradient(firstcolor);
        //    submain9.startColor = new ParticleSystem.MinMaxGradient(firstcolor);
        //    submain10.startColor = new ParticleSystem.MinMaxGradient(firstcolor);
        //    fresmain1.startColor = new ParticleSystem.MinMaxGradient(firstcolor);
        //    fresmain2.startColor = new ParticleSystem.MinMaxGradient(firstcolor);
        //    fresmain3.startColor = new ParticleSystem.MinMaxGradient(firstcolor);
        //    fresmain4.startColor = new ParticleSystem.MinMaxGradient(firstcolor);
        //    fresmain5.startColor = new ParticleSystem.MinMaxGradient(firstcolor);
        //    fresmain6.startColor = new ParticleSystem.MinMaxGradient(firstcolor);
        //    fresmain7.startColor = new ParticleSystem.MinMaxGradient(firstcolor);
        //    fresmain8.startColor = new ParticleSystem.MinMaxGradient(firstcolor);
        //    fresmain9.startColor = new ParticleSystem.MinMaxGradient(firstcolor);
        //    fresmain10.startColor = new ParticleSystem.MinMaxGradient(firstcolor);
            


        //}
        //else if(hitMng.HP <= 20)
        //{
        //    var submain1 = gauge1_sub.main;
        //    var submain2 = gauge2_sub.main;
        //    var submain3 = gauge3_sub.main;
        //    var submain4 = gauge4_sub.main;
        //    var submain5 = gauge5_sub.main;
        //    var submain6 = gauge6_sub.main;
        //    var submain7 = gauge7_sub.main;
        //    var submain8 = gauge8_sub.main;
        //    var submain9 = gauge9_sub.main;
        //    var submain10 = gauge10_sub.main;

        //    var fresmain1 = gauge1_fres.main;
        //    var fresmain2 = gauge2_fres.main;
        //    var fresmain3 = gauge3_fres.main;
        //    var fresmain4 = gauge4_fres.main;
        //    var fresmain5 = gauge5_fres.main;
        //    var fresmain6 = gauge6_fres.main;
        //    var fresmain7 = gauge7_fres.main;
        //    var fresmain8 = gauge8_fres.main;
        //    var fresmain9 = gauge9_fres.main;
        //    var fresmain10 = gauge10_fres.main;

        //    submain1.startColor = new ParticleSystem.MinMaxGradient(secondcolor);
        //    submain2.startColor = new ParticleSystem.MinMaxGradient(secondcolor);
        //    submain3.startColor = new ParticleSystem.MinMaxGradient(secondcolor);
        //    submain4.startColor = new ParticleSystem.MinMaxGradient(secondcolor);
        //    submain5.startColor = new ParticleSystem.MinMaxGradient(secondcolor);
        //    submain6.startColor = new ParticleSystem.MinMaxGradient(secondcolor);
        //    submain7.startColor = new ParticleSystem.MinMaxGradient(secondcolor);
        //    submain8.startColor = new ParticleSystem.MinMaxGradient(secondcolor);
        //    submain9.startColor = new ParticleSystem.MinMaxGradient(secondcolor);
        //    submain10.startColor = new ParticleSystem.MinMaxGradient(secondcolor);
        //    fresmain1.startColor = new ParticleSystem.MinMaxGradient(secondcolor);
        //    fresmain2.startColor = new ParticleSystem.MinMaxGradient(secondcolor);
        //    fresmain3.startColor = new ParticleSystem.MinMaxGradient(secondcolor);
        //    fresmain4.startColor = new ParticleSystem.MinMaxGradient(secondcolor);
        //    fresmain5.startColor = new ParticleSystem.MinMaxGradient(secondcolor);
        //    fresmain6.startColor = new ParticleSystem.MinMaxGradient(secondcolor);
        //    fresmain7.startColor = new ParticleSystem.MinMaxGradient(secondcolor);
        //    fresmain8.startColor = new ParticleSystem.MinMaxGradient(secondcolor);
        //    fresmain9.startColor = new ParticleSystem.MinMaxGradient(secondcolor);
        //    fresmain10.startColor = new ParticleSystem.MinMaxGradient(secondcolor);

        //}
    }
}
