using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dart_hit : MonoBehaviour
{
    [SerializeField] private Collider objct_col;
    [SerializeField] private GameObject objct;
    [SerializeField] private GameObject prop;
    [SerializeField] private Transform backrooms;

    double x_val;
    double y_val;
    double distance;
    int points;

    private void OnTriggerEnter(Collider other)
    {
        if (other == objct_col)
        {
            prop.transform.position = objct.transform.position;
            objct.transform.position = backrooms.transform.position;
            objct.transform.rotation = backrooms.transform.rotation;

            x_val = prop.transform.position.x;
            y_val = prop.transform.position.y;
            distance = (x_val + 2.5)*(x_val + 2.5)+(y_val - 2.2) *(y_val - 2.2);
            points = 0;

            

            //1. 3 obrêcze punktowe

            if(distance < 0.05)
            {
                points = 50;
            }
            else if(distance < 0.1)
            {
                points = 25;
            }
            else if (distance > 1)
            {
                points = 0;
            }
            else //2. sprawdzanie pola punktowego
            {
                if((x_val + 4.7) < y_val)
                {
                    if ((-0.3-x_val) < y_val) //górna æwiartka
                    {
                        if (((x_val*(-6.31375)) - 13.584375 ) < y_val)
                        {
                            if (((x_val * (6.31375)) + 17.984375) < y_val)
                            {
                                points = 20;
                            }
                            else
                            {
                                if (((x_val * (1.96261)) + 7.106525) < y_val)
                                {
                                    points = 1;
                                }
                                else
                                {
                                    points = 18;
                                }
                            }
                        }
                        else 
                        {
                            if (((x_val * (-1.96261)) - 2.706525) < y_val)
                            {
                                points = 5;
                            }
                            else
                            {
                                points = 12;
                            }
                        }
                    }
                    else //lewa æwiartka
                    {
                        if (((x_val * (0.15838)) + 2.59595) > y_val)
                        {
                            if (((x_val * (0.50952)) + 3.4738) < y_val)
                            {
                                points = 8;
                            }
                            else
                            {
                                points = 16;
                            }
                        }
                        else
                        {
                            if (((x_val * (-0.15838)) + 1.80405) < y_val)
                            {
                                if (((x_val * (-0.50952)) + 0.9262) < y_val)
                                {
                                    points = 9;
                                }
                                else
                                {
                                    points = 14;
                                }
                            }
                            else
                            {
                                points = 11;
                            }
                        }
                    }
                }
                else
                {
                    if ((-0.3 - x_val) < y_val) //prawa æwiartka
                    {
                        if (((x_val * (0.15838)) + 2.59595) < y_val)
                        {
                            if (((x_val * (0.50952)) + 3.4738) < y_val)
                            {
                                points = 4;
                            }
                            else
                            {
                                points = 13;
                            }
                        }
                        else
                        {
                            if (((x_val * (-0.15838)) + 1.80405) > y_val)
                            {
                                if (((x_val * (-0.50952)) + 0.9262) < y_val)
                                {
                                    points = 10;
                                }
                                else
                                {
                                    points = 15;
                                }
                            }
                            else
                            {
                                points = 6;
                            }
                        }
                    }
                    else //dolna æwiartka
                    {
                        if (((x_val * (-6.31375)) - 13.584375) > y_val)
                        {
                            if (((x_val * (6.31375)) + 17.984375) > y_val)
                            {
                                points = 3;
                            }
                            else
                            {
                                if (((x_val * (1.96261)) + 7.106525) < y_val)
                                {
                                    points = 7;
                                }
                                else
                                {
                                    points = 19;
                                }
                            }
                        }
                        else
                        {
                            if (((x_val * (-1.96261)) - 2.706525) < y_val)
                            {
                                points = 2;
                            }
                            else
                            {
                                points = 17;
                            }
                        }
                    }
                }
            }

            //3. naliczanie mno¿ników

            if (distance > 0.95)
            {
                points = points * 2;
            }
            else if ((distance > 0.575)&&(distance < 0.65))
            {
                points = points * 3;
            }

            Point_Management.instance.AddPoint(points);

        }
    }
}
