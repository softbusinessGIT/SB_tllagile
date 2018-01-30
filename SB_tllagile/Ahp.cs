using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Net.Kniaz.AHP;
using DotNetMatrix;
using System.Windows.Forms;

namespace SB_tllagile
{
    class Ahp
    {
        static List<Equipa> ListaColabEquipa = new List<Equipa>(); //lista de Utilizador (tipo Utilizador)
        static List<Colaborador> ListaColab = new List<Colaborador>();
        static DataAccess db = new DataAccess();
        

        public static Colaborador[] calcularAhpProductOwner(double kbnCm, double kifCm, double eaCm, double fkCm, double kifKbm, double eaKbm, double fkKbm, double eaKif, double fkKif, double fkea)
        {
            //Pesquisa na Base de dados o utilizador
            ListaColab = db.pontuacaoColab(); 
            
            if ((ListaColab.Count)>4)
            {
                var size = ListaColab.Count;
                //double[] communicationSkillArray = { 12, 15, 12, 20, 1 };
                double[] communicationSkillArray = new double[size];
                double[] knowledgeBusinessArray = new double[size];
                double[] knowledgeIndstryArray = new double[size];
                double[] entrepeneurArray = new double[size];
                double[] financialKnowlegdeArray = new double[size];


                for (var i=0; i< ListaColab.Count;i++)
                {
                    communicationSkillArray[i] = ListaColab[i].communication;
                    knowledgeBusinessArray[i] = ListaColab[i].know_business_model;
                    knowledgeIndstryArray[i] = ListaColab[i].know_industry_field;
                    entrepeneurArray[i] = ListaColab[i].enterpreneur_ability;
                    financialKnowlegdeArray[i] = ListaColab[i].financial_know;
                }

                
                //var size = ListaColab.Count;

                // cada elemento da matrix corresponde a cada criterio de comparação
                /* array == criterios
                   cada elemento do array == nota de cada pessoa */
                double[][] criteria = new double[][]
                    {
                    new double[]{1, kbnCm, kifCm,  eaCm,  fkCm },
                    new double[]{0, 1,     kifKbm, eaKbm, fkKbm},
                    new double[]{0, 0,     1,      eaKif, fkKif},
                    new double[]{0, 0,     0,      1,     fkea },
                    new double[]{0, 0,     0,      0 ,    1    }
                    };

                // array 
                double[][] communicationSkillMatrix = new double[size][];

                for (int i = 0; i < size; i++)
                {
                    communicationSkillMatrix[i] = new double[size];
                }
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        communicationSkillMatrix[i][j] = 0;
                    }
                }
                for (int k = 0; k < size; k++)
                {
                    for (int w = k; w < size; w++)
                    {
                        if (w.Equals(k))
                        {

                            communicationSkillMatrix[k][w] = 1;
                        }
                        else
                        {
                            communicationSkillMatrix[k][w] = communicationSkillArray[k] / communicationSkillArray[w];
                        }
                    }

                }

                double[][] knowledgeBusinessMatrix = new double[size][];
                for (int i = 0; i < size; i++)
                {
                    knowledgeBusinessMatrix[i] = new double[size];
                }
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        knowledgeBusinessMatrix[i][j] = 0;
                    }
                }
                for (int k = 0; k < size; k++)
                {
                    for (int w = k; w < size; w++)
                    {
                        if (w.Equals(k))
                        {

                            knowledgeBusinessMatrix[k][w] = 1;
                        }
                        else
                        {
                            knowledgeBusinessMatrix[k][w] = knowledgeBusinessArray[k] / knowledgeBusinessArray[w];
                        }
                    }

                }

                double[][] knowledgeIndstryMatrix = new double[size][];
                for (int i = 0; i < size; i++)
                {
                    knowledgeIndstryMatrix[i] = new double[size];
                }
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        knowledgeIndstryMatrix[i][j] = 0;
                    }
                }
                for (int k = 0; k < size; k++)
                {
                    for (int w = k; w < size; w++)
                    {
                        if (w.Equals(k))
                        {

                            knowledgeIndstryMatrix[k][w] = 1;
                        }
                        else
                        {
                            knowledgeIndstryMatrix[k][w] = knowledgeIndstryArray[k] / knowledgeIndstryArray[w];
                        }
                    }

                }

                double[][] entrepeneurMatrix = new double[size][];
                for (int i = 0; i < size; i++)
                {
                    entrepeneurMatrix[i] = new double[size];
                }
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        entrepeneurMatrix[i][j] = 0;
                    }
                }
                for (int k = 0; k < size; k++)
                {
                    for (int w = k; w < size; w++)
                    {
                        if (w.Equals(k))
                        {

                            entrepeneurMatrix[k][w] = 1;
                        }
                        else
                        {
                            entrepeneurMatrix[k][w] = entrepeneurArray[k] / entrepeneurArray[w];
                        }
                    }
                }

                double[][] financialKnowlegdeMatrix = new double[size][];
                for (int i = 0; i < size; i++)
                {
                    financialKnowlegdeMatrix[i] = new double[size];
                }
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        financialKnowlegdeMatrix[i][j] = 0;
                    }
                }
                for (int k = 0; k < size; k++)
                {
                    for (int w = k; w < size; w++)
                    {
                        if (w.Equals(k))
                        {

                            financialKnowlegdeMatrix[k][w] = 1;
                        }
                        else
                        {
                            financialKnowlegdeMatrix[k][w] = financialKnowlegdeArray[k] / financialKnowlegdeArray[w];
                        }
                    }
                }


                AHPModel model = new AHPModel(5, size);

                // options  == matrix alternativa

                model.AddCriteria(criteria);
                model.AddCriterionRatedChoices(0, communicationSkillMatrix);
                model.AddCriterionRatedChoices(1, knowledgeBusinessMatrix);
                model.AddCriterionRatedChoices(2, knowledgeIndstryMatrix);
                model.AddCriterionRatedChoices(3, entrepeneurMatrix);
                model.AddCriterionRatedChoices(4, financialKnowlegdeMatrix);
                model.CalculateModel();

                GeneralMatrix CalcCriteria = model.CalculatedCriteria;
                GeneralMatrix results = model.ModelResult;
                GeneralMatrix calcOptions = model.CalculatedChoices;

                //var posMaior = 0;

                //for (var i = 1; i < ListaColab.Count; i++)
                //{


                //    if (calcOptions.GetElement(i, 0)> calcOptions.GetElement(i-1, 0))
                //    {
                //         posMaior = i;
                //    }
                //}
                //DialogResult dialogCamposIns = MessageBox.Show(ListaColab[posMaior].colab_nome.ToString(),
                //                    "Erro - seleção", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //return ListaColab[posMaior];

                //Coloca o resutado ahp no objeto colaborador
                for (var i = 1; i < ListaColab.Count; i++)
                {
                    ListaColab[i].resultadoAhp = calcOptions.GetElement(i, 0);
                }

                Colaborador temp;

                Colaborador[] listaColabToArray = ListaColab.ToArray();
                //ordenar o array perante o resultado do ahp
                for (int write = 0; write < listaColabToArray.Length; write++)
                {
                    for (int sort = 0; sort < listaColabToArray.Length - 1; sort++)
                    {
                        if (listaColabToArray[sort].resultadoAhp < listaColabToArray[sort + 1].resultadoAhp)
                        {
                            temp = listaColabToArray[sort + 1];
                            listaColabToArray[sort + 1] = listaColabToArray[sort];
                            listaColabToArray[sort] = temp;
                        }
                    }
                }

                return listaColabToArray;


                //Console.WriteLine(calcOptions.GetElement(0, 0) * 100.00);
                //Console.WriteLine(calcOptions.GetElement(1, 0) * 100.00);
                //Console.WriteLine(calcOptions.GetElement(2, 0) * 100.00);
                //Console.WriteLine(calcOptions.GetElement(3, 0) * 100.00);
                //Console.WriteLine(calcOptions.GetElement(4, 0) * 100.00);


            }
            return null;
        }
        public static Colaborador[] calcularAhpTeamMaster(double pmtCs, double citCs, double desCs, double maCs, double csCs,      double citPmt, double desPmt, double maPmt, double csPmt,      double desCit, double maCit, double csCit,     double maDes, double csDes,      double csMa)
        {
            //Pesquisa na Base de dados o utilizador
            ListaColab = db.pontuacaoColab(); 

            if ((ListaColab.Count)> 3)
            {
                var size = ListaColab.Count;
                //double[] communicationSkillArray = { 12, 15, 12, 20, 1 };
                double[] communicationSkillArray = new double[size];
                double[] projectManagmentArray = new double[size];
                double[] continuosIntegrationArray = new double[size];
                double[] developmentEnviromentArray = new double[size];
                double[] motivationArray = new double[size];
                double[] CoordenationArray = new double[size];
                

                for (var i = 0; i < ListaColab.Count; i++)
                {
                    communicationSkillArray[i] = ListaColab[i].communication;
                    projectManagmentArray[i] = ListaColab[i].proj_management_tool;
                    continuosIntegrationArray[i] = ListaColab[i].integration_tool;
                    developmentEnviromentArray[i] = ListaColab[i].dev_environment_setup;
                    motivationArray[i] = ListaColab[i].motivation_ability;
                    CoordenationArray[i] = ListaColab[i].coordination_skill;
                }


                //var size = ListaColab.Count;

                // cada elemento da matrix corresponde a cada criterio de comparação
                /* array == criterios
                   cada elemento do array == nota de cada pessoa */
                double[][] criteria = new double[][]
                    {
                    new double[]{1, pmtCs, citCs, desCs,  maCs , csCs },
                    new double[]{0, 1,     citPmt, desPmt, maPmt, csPmt},
                    new double[]{0, 0,     1,      desCit, maCit, csCit},
                    new double[]{0, 0,     0,      1,      maDes, csDes },
                    new double[]{0, 0,     0,      0 ,     1,      csMa },
                    new double[]{0, 0,     0,      0 ,     0,      1   }
                    };

                // array 
                double[][] communicationSkillMatrix = new double[size][];

                for (int i = 0; i < size; i++)
                {
                    communicationSkillMatrix[i] = new double[size];
                }
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        communicationSkillMatrix[i][j] = 0;
                    }
                }
                for (int k = 0; k < size; k++)
                {
                    for (int w = k; w < size; w++)
                    {
                        if (w.Equals(k))
                        {

                            communicationSkillMatrix[k][w] = 1;
                        }
                        else
                        {
                            communicationSkillMatrix[k][w] = communicationSkillArray[k] / communicationSkillArray[w];
                        }
                    }

                }

                double[][] projectManagmentMatrix = new double[size][];
                for (int i = 0; i < size; i++)
                {
                    projectManagmentMatrix[i] = new double[size];
                }
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        projectManagmentMatrix[i][j] = 0;
                    }
                }
                for (int k = 0; k < size; k++)
                {
                    for (int w = k; w < size; w++)
                    {
                        if (w.Equals(k))
                        {

                            projectManagmentMatrix[k][w] = 1;
                        }
                        else
                        {
                            projectManagmentMatrix[k][w] = projectManagmentArray[k] / projectManagmentArray[w];
                        }
                    }

                }

                double[][] continuosIntegrationMatrix = new double[size][];
                for (int i = 0; i < size; i++)
                {
                    continuosIntegrationMatrix[i] = new double[size];
                }
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        continuosIntegrationMatrix[i][j] = 0;
                    }
                }
                for (int k = 0; k < size; k++)
                {
                    for (int w = k; w < size; w++)
                    {
                        if (w.Equals(k))
                        {

                            continuosIntegrationMatrix[k][w] = 1;
                        }
                        else
                        {
                            continuosIntegrationMatrix[k][w] = continuosIntegrationArray[k] / continuosIntegrationArray[w];
                        }
                    }

                }

                double[][] developmentEnviromentMatrix = new double[size][];
                for (int i = 0; i < size; i++)
                {
                    developmentEnviromentMatrix[i] = new double[size];
                }
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        developmentEnviromentMatrix[i][j] = 0;
                    }
                }
                for (int k = 0; k < size; k++)
                {
                    for (int w = k; w < size; w++)
                    {
                        if (w.Equals(k))
                        {

                            developmentEnviromentMatrix[k][w] = 1;
                        }
                        else
                        {
                            developmentEnviromentMatrix[k][w] = developmentEnviromentArray[k] / developmentEnviromentArray[w];
                        }
                    }
                }

                double[][] motivationMatrix = new double[size][];
                for (int i = 0; i < size; i++)
                {
                    motivationMatrix[i] = new double[size];
                }
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        motivationMatrix[i][j] = 0;
                    }
                }
                for (int k = 0; k < size; k++)
                {
                    for (int w = k; w < size; w++)
                    {
                        if (w.Equals(k))
                        {

                            motivationMatrix[k][w] = 1;
                        }
                        else
                        {
                            motivationMatrix[k][w] = motivationArray[k] / motivationArray[w];
                        }
                    }
                }

                double[][] CoordenationMatrix = new double[size][];
                for (int i = 0; i < size; i++)
                {
                    CoordenationMatrix[i] = new double[size];
                }
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        CoordenationMatrix[i][j] = 0;
                    }
                }
                for (int k = 0; k < size; k++)
                {
                    for (int w = k; w < size; w++)
                    {
                        if (w.Equals(k))
                        {

                            CoordenationMatrix[k][w] = 1;
                        }
                        else
                        {
                            CoordenationMatrix[k][w] = CoordenationArray[k] / CoordenationArray[w];
                        }
                    }
                }


                AHPModel model = new AHPModel(6, size);

                // options  == matrix alternativa

                model.AddCriteria(criteria);
                model.AddCriterionRatedChoices(0, communicationSkillMatrix);
                model.AddCriterionRatedChoices(1, projectManagmentMatrix);
                model.AddCriterionRatedChoices(2, continuosIntegrationMatrix);
                model.AddCriterionRatedChoices(3, developmentEnviromentMatrix);
                model.AddCriterionRatedChoices(4, motivationMatrix);
                model.AddCriterionRatedChoices(5, CoordenationMatrix);
                model.CalculateModel();

                GeneralMatrix CalcCriteria = model.CalculatedCriteria;
                GeneralMatrix results = model.ModelResult;
                GeneralMatrix calcOptions = model.CalculatedChoices;

                //var posMaior = 0;

                //for (var i = 1; i < ListaColab.Count; i++)
                //{


                //    if (calcOptions.GetElement(i, 0) > calcOptions.GetElement(i - 1, 0))
                //    {
                //        posMaior = i;
                //    }
                //}
                //DialogResult dialogCamposIns = MessageBox.Show(ListaColab[posMaior].colab_nome.ToString(),
                //                    "Erro - seleção", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //return ListaColab[posMaior];


                //Coloca o resutado ahp no objeto colaborador
                for (var i = 1; i < ListaColab.Count; i++)
                {
                    ListaColab[i].resultadoAhp = calcOptions.GetElement(i, 0);
                }

                Colaborador temp;

                Colaborador[] listaColabToArray = ListaColab.ToArray();
                //ordenar o array perante o resultado do ahp
                for (int write = 0; write < listaColabToArray.Length; write++)
                {
                    for (int sort = 0; sort < listaColabToArray.Length - 1; sort++)
                    {
                        if (listaColabToArray[sort].resultadoAhp < listaColabToArray[sort + 1].resultadoAhp)
                        {
                            temp = listaColabToArray[sort + 1];
                            listaColabToArray[sort + 1] = listaColabToArray[sort];
                            listaColabToArray[sort] = temp;
                        }
                    }
                }

                return listaColabToArray;

                
                //    Console.WriteLine("Option 1");

                //Console.WriteLine(calcOptions.GetElement(0, 0) * 100.00);
                //Console.WriteLine(calcOptions.GetElement(1, 0) * 100.00);
                //Console.WriteLine(calcOptions.GetElement(2, 0) * 100.00);
                //Console.WriteLine(calcOptions.GetElement(3, 0) * 100.00);
                //Console.WriteLine(calcOptions.GetElement(4, 0) * 100.00);

                //Console.ReadLine();
            }
            return null;
        }
        public static Colaborador[] calcularAhpTeam(double psaPls, double tsPls, double citPls, double rcPls, double dkPls, double bdkPls,       double tsPsa, double citPsa, double rcPsa, double dkPsa, double bdkPsa,       double citTs, double rcTs, double dkTs, double bdkTs,     double rcCit, double dkCit, double bdkCit, double dkRc, double bdkRc,    double bdkDk)
        {
            //Pesquisa na Base de dados o utilizador
            ListaColab = db.pontuacaoColab();

            if ((ListaColab.Count) > 3)
            {
                var size = ListaColab.Count;
                //double[] communicationSkillArray = { 12, 15, 12, 20, 1 };
                double[] programmingArray = new double[size];
                double[] problemSolvingArray = new double[size];
                double[] testingSkillsArray = new double[size];
                double[] continuosIntegrationArray = new double[size];
                double[] refactoringArray = new double[size];
                double[] databaseKnowledgeArray = new double[size];
                double[] bigDataArray = new double[size];
                


                for (var i = 0; i < ListaColab.Count; i++)
                {
                    programmingArray[i] = ListaColab[i].prog_lang_skill;
                    problemSolvingArray[i] = ListaColab[i].problem_solving;
                    testingSkillsArray[i] = ListaColab[i].integration_tool;
                    continuosIntegrationArray[i] = ListaColab[i].integration_tool;
                    refactoringArray[i] = ListaColab[i].refact_concept;
                    databaseKnowledgeArray[i] = ListaColab[i].db_knowledge;
                    bigDataArray[i] = ListaColab[i].big_data_knowledge;
                }


                //var size = ListaColab.Count;

                // cada elemento da matrix corresponde a cada criterio de comparação
                /* array == criterios
                   cada elemento do array == nota de cada pessoa */
                double[][] criteria = new double[][]
                    {
                    new double[]{1, psaPls, tsPls, citPls, rcPls, dkPls, bdkPls },
                    new double[]{0, 1,     tsPsa, citPsa, rcPsa, dkPsa, bdkPsa},
                    new double[]{0, 0,     1,     citTs,  rcTs,   dkTs, bdkTs},
                    new double[]{0, 0,     0,      1,      rcCit, dkCit, bdkCit},
                    new double[]{0, 0,     0,      0 ,     1,      dkRc, bdkRc },
                    new double[]{0, 0,     0,      0 ,     0,      1,    bdkDk },
                    new double[]{0, 0,     0,      0 ,     0,      0,    1 }
                    };

                // array 
                double[][] programmingMatrix = new double[size][];

                for (int i = 0; i < size; i++)
                {
                    programmingMatrix[i] = new double[size];
                }
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        programmingMatrix[i][j] = 0;
                    }
                }
                for (int k = 0; k < size; k++)
                {
                    for (int w = k; w < size; w++)
                    {
                        if (w.Equals(k))
                        {

                            programmingMatrix[k][w] = 1;
                        }
                        else
                        {
                            programmingMatrix[k][w] = programmingArray[k] / programmingArray[w];
                        }
                    }

                }

                double[][] problemSolvingMatrix = new double[size][];
                for (int i = 0; i < size; i++)
                {
                    problemSolvingMatrix[i] = new double[size];
                }
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        problemSolvingMatrix[i][j] = 0;
                    }
                }
                for (int k = 0; k < size; k++)
                {
                    for (int w = k; w < size; w++)
                    {
                        if (w.Equals(k))
                        {

                            problemSolvingMatrix[k][w] = 1;
                        }
                        else
                        {
                            problemSolvingMatrix[k][w] = problemSolvingArray[k] / problemSolvingArray[w];
                        }
                    }

                }
                double[][] testingSkillsMatrix = new double[size][];
                for (int i = 0; i < size; i++)
                {
                    testingSkillsMatrix[i] = new double[size];
                }
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        testingSkillsMatrix[i][j] = 0;
                    }
                }
                for (int k = 0; k < size; k++)
                {
                    for (int w = k; w < size; w++)
                    {
                        if (w.Equals(k))
                        {

                            testingSkillsMatrix[k][w] = 1;
                        }
                        else
                        {
                            testingSkillsMatrix[k][w] = testingSkillsArray[k] / testingSkillsArray[w];
                        }
                    }

                }

                double[][] continuosIntegrationMatrix = new double[size][];
                for (int i = 0; i < size; i++)
                {
                    continuosIntegrationMatrix[i] = new double[size];
                }
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        continuosIntegrationMatrix[i][j] = 0;
                    }
                }
                for (int k = 0; k < size; k++)
                {
                    for (int w = k; w < size; w++)
                    {
                        if (w.Equals(k))
                        {

                            continuosIntegrationMatrix[k][w] = 1;
                        }
                        else
                        {
                            continuosIntegrationMatrix[k][w] = continuosIntegrationArray[k] / continuosIntegrationArray[w];
                        }
                    }

                }

                double[][] refactoringMatrix = new double[size][];
                for (int i = 0; i < size; i++)
                {
                    refactoringMatrix[i] = new double[size];
                }
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        refactoringMatrix[i][j] = 0;
                    }
                }
                for (int k = 0; k < size; k++)
                {
                    for (int w = k; w < size; w++)
                    {
                        if (w.Equals(k))
                        {

                            refactoringMatrix[k][w] = 1;
                        }
                        else
                        {
                            refactoringMatrix[k][w] = refactoringArray[k] / refactoringArray[w];
                        }
                    }
                }

                double[][] databaseKnowledgeMatrix = new double[size][];
                for (int i = 0; i < size; i++)
                {
                    databaseKnowledgeMatrix[i] = new double[size];
                }
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        databaseKnowledgeMatrix[i][j] = 0;
                    }
                }
                for (int k = 0; k < size; k++)
                {
                    for (int w = k; w < size; w++)
                    {
                        if (w.Equals(k))
                        {

                            databaseKnowledgeMatrix[k][w] = 1;
                        }
                        else
                        {
                            databaseKnowledgeMatrix[k][w] = databaseKnowledgeArray[k] / databaseKnowledgeArray[w];
                        }
                    }
                }

                double[][] bigDataMatrix = new double[size][];
                for (int i = 0; i < size; i++)
                {
                    bigDataMatrix[i] = new double[size];
                }
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        bigDataMatrix[i][j] = 0;
                    }
                }
                for (int k = 0; k < size; k++)
                {
                    for (int w = k; w < size; w++)
                    {
                        if (w.Equals(k))
                        {

                            bigDataMatrix[k][w] = 1;
                        }
                        else
                        {
                            bigDataMatrix[k][w] = bigDataArray[k] / bigDataArray[w];
                        }
                    }
                }


                AHPModel model = new AHPModel(7, size);

                // options  == matrix alternativa

                model.AddCriteria(criteria);
                model.AddCriterionRatedChoices(0, programmingMatrix);
                model.AddCriterionRatedChoices(1, problemSolvingMatrix);
                model.AddCriterionRatedChoices(2, testingSkillsMatrix);
                model.AddCriterionRatedChoices(3, continuosIntegrationMatrix);
                model.AddCriterionRatedChoices(4, refactoringMatrix);
                model.AddCriterionRatedChoices(5, databaseKnowledgeMatrix);
                model.AddCriterionRatedChoices(6, bigDataMatrix);
                model.CalculateModel();

                GeneralMatrix CalcCriteria = model.CalculatedCriteria;
                GeneralMatrix results = model.ModelResult;
                GeneralMatrix calcOptions = model.CalculatedChoices;

                
                //Coloca o resutado ahp no objeto colaborador
                for (var i = 1; i < ListaColab.Count; i++)
                {
                    ListaColab[i].resultadoAhp = calcOptions.GetElement(i, 0);
                }

                Colaborador temp;

                Colaborador[] listaColabToArray = ListaColab.ToArray();
                //ordenar o array perante o resultado do ahp
                for (int write = 0; write < listaColabToArray.Length; write++)
                {
                    for (int sort = 0; sort < listaColabToArray.Length - 1; sort++)
                    {
                        if (listaColabToArray[sort].resultadoAhp < listaColabToArray[sort + 1].resultadoAhp)
                        {
                            temp = listaColabToArray[sort + 1];
                            listaColabToArray[sort + 1] = listaColabToArray[sort];
                            listaColabToArray[sort] = temp;
                        }
                    }
                }

                return listaColabToArray;
            }
            return null;
        }
    }
}
