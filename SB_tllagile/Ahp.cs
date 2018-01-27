using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Net.Kniaz.AHP;
using DotNetMatrix;

namespace SB_tllagile
{
    class Ahp
    {
        static void calcularAhp()
        {


            double[] Array = { 12, 15, 12, 20, 1 };
            double[] Array2 = { 12, 15, 12, 20, 1 };
            double[] Array3 = { 12, 15, 12, 20, 1 };
            double[] Array4 = { 12, 15, 12, 20, 1 };
            var size = Array.Length;

            // cada elemento da matrix corresponde a cada criterio de comparação
            /* array == criterios
               cada elemento do array == nota de cada pessoa */
            double[][] criteria = new double[][]
                {
                    new double[]{1,3,7,3},
                    new double[]{0,1,9,1},
                    new double[]{0,0,1,1},
                    new double[]{0,0,0,1}
                };

            // array 
            double[][] Options = new double[size][];

            for (int i = 0; i < size; i++)
            {
                Options[i] = new double[size];
            }
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Options[i][j] = 0;
                }
            }
            for (int k = 0; k < size; k++)
            {
                for (int w = k; w < size; w++)
                {
                    if (w.Equals(k))
                    {

                        Options[k][w] = 1;
                    }
                    else
                    {
                        Options[k][w] = Array[k] / Array[w];
                    }
                }

            }

            double[][] Options2 = new double[size][];
            for (int i = 0; i < size; i++)
            {
                Options2[i] = new double[size];
            }
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Options2[i][j] = 0;
                }
            }
            for (int k = 0; k < size; k++)
            {
                for (int w = k; w < size; w++)
                {
                    if (w.Equals(k))
                    {

                        Options2[k][w] = 1;
                    }
                    else
                    {
                        Options2[k][w] = Array2[k] / Array2[w];
                    }
                }

            }

            double[][] Options3 = new double[size][];
            for (int i = 0; i < size; i++)
            {
                Options3[i] = new double[size];
            }
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Options3[i][j] = 0;
                }
            }
            for (int k = 0; k < size; k++)
            {
                for (int w = k; w < size; w++)
                {
                    if (w.Equals(k))
                    {

                        Options3[k][w] = 1;
                    }
                    else
                    {
                        Options3[k][w] = Array3[k] / Array3[w];
                    }
                }

            }

            double[][] Options4 = new double[size][];
            for (int i = 0; i < size; i++)
            {
                Options4[i] = new double[size];
            }
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Options4[i][j] = 0;
                }
            }
            for (int k = 0; k < size; k++)
            {
                for (int w = k; w < size; w++)
                {
                    if (w.Equals(k))
                    {

                        Options4[k][w] = 1;
                    }
                    else
                    {
                        Options4[k][w] = Array4[k] / Array4[w];
                    }
                }

            }




            AHPModel model = new AHPModel(4, size);

            // options  == matrix alternativa

            model.AddCriteria(criteria);
            model.AddCriterionRatedChoices(0, Options);
            model.AddCriterionRatedChoices(1, Options2);
            model.AddCriterionRatedChoices(2, Options3);
            model.AddCriterionRatedChoices(3, Options4);
            model.CalculateModel();

            GeneralMatrix CalcCriteria = model.CalculatedCriteria;
            GeneralMatrix results = model.ModelResult;
            GeneralMatrix calcOptions = model.CalculatedChoices;

            Console.WriteLine("Option 1");
            Console.WriteLine(calcOptions.GetElement(0, 0) * 100.00);
            Console.WriteLine(calcOptions.GetElement(1, 0) * 100.00);
            Console.WriteLine(calcOptions.GetElement(2, 0) * 100.00);
            Console.WriteLine(calcOptions.GetElement(3, 0) * 100.00);
            Console.WriteLine(calcOptions.GetElement(4, 0) * 100.00);

            Console.ReadLine();

        }
    }
}
