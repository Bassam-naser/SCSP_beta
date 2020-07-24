﻿using NLoptNet;
using sc.net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace RefPropWindowsForms
{
    public partial class RCMCI_with_Two_Intercooling_with_Three_Reheating_Analysis_Results : Form
    {
        RCMCI_with_Two_Intercooling_with_Three_Reheating puntero_aplicacion;

        public RCMCI_with_Two_Intercooling_with_Three_Reheating_Analysis_Results(RCMCI_with_Two_Intercooling_with_Three_Reheating puntero1)
        {
            puntero_aplicacion = puntero1;
            InitializeComponent();
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        //Mixtures calculations
        private void button3_Click(object sender, EventArgs e)
        {
            int counter_Excel = 4;

            Excel.Application xlApp1;
            Excel.Workbook xlWorkBook1;
            Excel.Worksheet xlWorkSheet1;
            Excel.Worksheet xlWorkSheet2;

            object misValue1 = System.Reflection.Missing.Value;

            xlApp1 = new Excel.Application();
            xlApp1.DisplayAlerts = false;
            xlWorkBook1 = xlApp1.Workbooks.Add(misValue1);

            xlWorkSheet1 = (Excel.Worksheet)xlWorkBook1.Worksheets.Add();

            double initial_CIP_value = 0;

            //Optimize UA false
            if (checkBox2.Checked == false)
            {
                //PureFluid
                if (puntero_aplicacion.comboBox1.Text == "PureFluid")
                {
                    puntero_aplicacion.category = RefrigerantCategory.PureFluid;
                    puntero_aplicacion.luis.core1(puntero_aplicacion.comboBox1.Text, puntero_aplicacion.category);
                }

                //NewMixture
                if (puntero_aplicacion.comboBox1.Text == "NewMixture")
                {
                    puntero_aplicacion.category = RefrigerantCategory.NewMixture;
                    puntero_aplicacion.luis.core1(puntero_aplicacion.comboBox2.Text + "=" + puntero_aplicacion.textBox35.Text + "," + puntero_aplicacion.comboBox16.Text + "=" + puntero_aplicacion.textBox36.Text, puntero_aplicacion.category);
                }

                if (puntero_aplicacion.comboBox1.Text == "PredefinedMixture")
                {
                    puntero_aplicacion.category = RefrigerantCategory.PredefinedMixture;
                }

                if (puntero_aplicacion.comboBox1.Text == "PseudoPureFluid")
                {
                    puntero_aplicacion.category = RefrigerantCategory.PseudoPureFluid;
                }

                if (puntero_aplicacion.comboBox3.Text == "DEF")
                {
                    puntero_aplicacion.referencestate = ReferenceState.DEF;
                }
                if (puntero_aplicacion.comboBox3.Text == "ASH")
                {
                    puntero_aplicacion.referencestate = ReferenceState.ASH;
                }
                if (puntero_aplicacion.comboBox3.Text == "IIR")
                {
                    puntero_aplicacion.referencestate = ReferenceState.IIR;
                }
                if (puntero_aplicacion.comboBox3.Text == "NBP")
                {
                    puntero_aplicacion.referencestate = ReferenceState.NBP;
                }

                puntero_aplicacion.luis.working_fluid.Category = puntero_aplicacion.category;
                puntero_aplicacion.luis.working_fluid.reference = puntero_aplicacion.referencestate;

                puntero_aplicacion.luis.wmm = puntero_aplicacion.luis.working_fluid.MolecularWeight;

                //Store Input Data from Graphical User Interface GUI into variables
                puntero_aplicacion.w_dot_net2 = Convert.ToDouble(puntero_aplicacion.textBox1.Text);
                puntero_aplicacion.t_mc1_in2 = Convert.ToDouble(puntero_aplicacion.textBox2.Text);
                puntero_aplicacion.t_mc2_in2 = Convert.ToDouble(puntero_aplicacion.textBox28.Text);
                puntero_aplicacion.t_mc3_in2 = Convert.ToDouble(puntero_aplicacion.textBox93.Text);
                puntero_aplicacion.t_t_in2 = Convert.ToDouble(puntero_aplicacion.textBox4.Text);
                puntero_aplicacion.p_mc1_in2 = Convert.ToDouble(puntero_aplicacion.textBox3.Text);
                puntero_aplicacion.p_mc1_out2 = Convert.ToDouble(puntero_aplicacion.textBox8.Text);
                puntero_aplicacion.p_mc2_in2 = Convert.ToDouble(puntero_aplicacion.textBox23.Text);
                puntero_aplicacion.p_mc2_out2 = Convert.ToDouble(puntero_aplicacion.textBox22.Text);
                puntero_aplicacion.p_mc3_in2 = Convert.ToDouble(puntero_aplicacion.textBox95.Text);
                puntero_aplicacion.p_mc3_out2 = Convert.ToDouble(puntero_aplicacion.textBox94.Text);
                puntero_aplicacion.p_rhx1_in2 = Convert.ToDouble(puntero_aplicacion.textBox7.Text);
                puntero_aplicacion.t_rht1_in2 = Convert.ToDouble(puntero_aplicacion.textBox6.Text);
                puntero_aplicacion.p_rhx2_in2 = Convert.ToDouble(puntero_aplicacion.textBox107.Text);
                puntero_aplicacion.t_rht2_in2 = Convert.ToDouble(puntero_aplicacion.textBox106.Text);
                puntero_aplicacion.p_rhx3_in2 = Convert.ToDouble(puntero_aplicacion.textBox115.Text);
                puntero_aplicacion.t_rht3_in2 = Convert.ToDouble(puntero_aplicacion.textBox114.Text);
                puntero_aplicacion.ua_lt2 = Convert.ToDouble(puntero_aplicacion.textBox17.Text);
                puntero_aplicacion.ua_ht2 = Convert.ToDouble(puntero_aplicacion.textBox16.Text);
                puntero_aplicacion.recomp_frac2 = Convert.ToDouble(puntero_aplicacion.textBox15.Text);
                puntero_aplicacion.eta1_mc2 = Convert.ToDouble(puntero_aplicacion.textBox14.Text);
                puntero_aplicacion.eta2_mc2 = Convert.ToDouble(puntero_aplicacion.textBox27.Text);
                puntero_aplicacion.eta3_mc2 = Convert.ToDouble(puntero_aplicacion.textBox92.Text);
                puntero_aplicacion.eta_rc2 = Convert.ToDouble(puntero_aplicacion.textBox13.Text);
                puntero_aplicacion.eta_t2 = Convert.ToDouble(puntero_aplicacion.textBox19.Text);
                puntero_aplicacion.eta_trh1 = Convert.ToDouble(puntero_aplicacion.textBox18.Text);
                puntero_aplicacion.eta_trh2 = Convert.ToDouble(puntero_aplicacion.textBox108.Text);
                puntero_aplicacion.eta_trh3 = Convert.ToDouble(puntero_aplicacion.textBox113.Text);
                puntero_aplicacion.n_sub_hxrs2 = Convert.ToInt64(puntero_aplicacion.textBox20.Text);
                puntero_aplicacion.tol2 = Convert.ToDouble(puntero_aplicacion.textBox21.Text);
                puntero_aplicacion.dp2_lt1 = Convert.ToDouble(puntero_aplicacion.textBox5.Text);
                puntero_aplicacion.dp2_ht1 = Convert.ToDouble(puntero_aplicacion.textBox12.Text);
                puntero_aplicacion.dp1_pc1 = Convert.ToDouble(puntero_aplicacion.textBox11.Text);
                puntero_aplicacion.dp2_pc1 = Convert.ToDouble(puntero_aplicacion.textBox24.Text);
                puntero_aplicacion.dp3_pc1 = Convert.ToDouble(puntero_aplicacion.textBox96.Text);
                puntero_aplicacion.dp2_phx1 = Convert.ToDouble(puntero_aplicacion.textBox10.Text);
                puntero_aplicacion.dp2_rhx12 = Convert.ToDouble(puntero_aplicacion.textBox9.Text);
                puntero_aplicacion.dp2_rhx22 = Convert.ToDouble(puntero_aplicacion.textBox105.Text);
                puntero_aplicacion.dp2_rhx32 = Convert.ToDouble(puntero_aplicacion.textBox116.Text);
                puntero_aplicacion.dp2_lt2 = Convert.ToDouble(puntero_aplicacion.textBox26.Text);
                puntero_aplicacion.dp2_ht2 = Convert.ToDouble(puntero_aplicacion.textBox25.Text);

                core.RCMCIwithTwoIntercoolingwithThreeReheating cicloRCMCI_withTwoIntercooling_withThreeRH = new core.RCMCIwithTwoIntercoolingwithThreeReheating();

                double UA_Total = puntero_aplicacion.ua_lt2 + puntero_aplicacion.ua_ht2;

                double LT_fraction = 0.1;

                int counter = 0;

                List<Double> recomp_frac2_list = new List<Double>();
                List<Double> p_mc1_in2_list = new List<Double>();
                List<Double> p_mc1_out2_list = new List<Double>();
                List<Double> p_mc2_out2_list = new List<Double>();
                List<Double> p_rhx1_list = new List<Double>();
                List<Double> p_rhx2_list = new List<Double>();
                List<Double> p_rhx3_list = new List<Double>();
                List<Double> eta_thermal2_list = new List<Double>();
                List<Double> ua_LT_list = new List<Double>();
                List<Double> ua_HT_list = new List<Double>();

                NLoptAlgorithm algorithm_type = NLoptAlgorithm.LN_BOBYQA;

                if (comboBox19.Text == "BOBYQA")
                    algorithm_type = NLoptAlgorithm.LN_BOBYQA;
                else if (comboBox19.Text == "COBYLA")
                    algorithm_type = NLoptAlgorithm.LN_COBYLA;
                else if (comboBox19.Text == "SUBPLEX")
                    algorithm_type = NLoptAlgorithm.LN_SBPLX;
                else if (comboBox19.Text == "NELDER-MEAD")
                    algorithm_type = NLoptAlgorithm.LN_NELDERMEAD;
                else if (comboBox19.Text == "NEWUOA")
                    algorithm_type = NLoptAlgorithm.LN_NEWUOA;
                else if (comboBox19.Text == "PRAXIS")
                    algorithm_type = NLoptAlgorithm.LN_PRAXIS;

                if (checkBox6.Checked == true)
                {
                    initial_CIP_value = Convert.ToDouble(textBox1.Text);
                }
                else
                {
                    initial_CIP_value = puntero_aplicacion.MixtureCriticalPressure;
                }

                xlWorkSheet1.Name = puntero_aplicacion.comboBox2.Text + " Mixture";

                //puntero_aplicacion.comboBox2.Text + "=" + puntero_aplicacion.textBox68.Text + "," + puntero_aplicacion.comboBox6.Text + "=" + puntero_aplicacion.textBox69.Text + "," + puntero_aplicacion.comboBox12.Text + "=" + puntero_aplicacion.textBox33.Text + "," + puntero_aplicacion.comboBox7.Text + "=" + puntero_aplicacion.textBox34.Text
                xlWorkSheet1.Cells[1, 1] = puntero_aplicacion.comboBox2.Text + ":" + puntero_aplicacion.textBox33.Text + "," + puntero_aplicacion.comboBox6.Text + ":" + puntero_aplicacion.textBox34.Text + "," + puntero_aplicacion.comboBox12.Text + ":" + puntero_aplicacion.textBox68.Text + "," + puntero_aplicacion.comboBox7.Text + ":" + puntero_aplicacion.textBox69.Text;
                xlWorkSheet1.Cells[1, 2] = "Pcrit(kPa)";
                xlWorkSheet1.Cells[1, 3] = "Tcrit(ºC)";

                xlWorkSheet1.Cells[2, 1] = "";
                xlWorkSheet1.Cells[2, 2] = Convert.ToString(puntero_aplicacion.MixtureCriticalPressure);
                xlWorkSheet1.Cells[2, 3] = Convert.ToString(puntero_aplicacion.MixtureCriticalTemperature - 273.15);

                xlWorkSheet1.Cells[3, 1] = "";
                xlWorkSheet1.Cells[3, 2] = "";
                xlWorkSheet1.Cells[4, 3] = "";

                xlWorkSheet1.Cells[4, 1] = "MC1_in(kPa)";
                xlWorkSheet1.Cells[4, 2] = "MC1_out(kPa)";
                xlWorkSheet1.Cells[4, 3] = "MC2_out(kPa)";
                xlWorkSheet1.Cells[4, 4] = "P_rhx1(kPa)";
                xlWorkSheet1.Cells[4, 5] = "P_rhx2(kPa)";
                xlWorkSheet1.Cells[4, 6] = "P_rhx3(kPa)";
                xlWorkSheet1.Cells[4, 7] = "CIT(K)";
                xlWorkSheet1.Cells[4, 8] = "LT UA(kW/K)";
                xlWorkSheet1.Cells[4, 9] = "HT UA(kW/K)";
                xlWorkSheet1.Cells[4, 10] = "Rec.Frac.";
                xlWorkSheet1.Cells[4, 11] = "Eff.(%)";
                xlWorkSheet1.Cells[4, 12] = "LTR Eff.(%)";
                xlWorkSheet1.Cells[4, 13] = "LTR Pinch(ºC)";
                xlWorkSheet1.Cells[4, 14] = "HTR Eff.(%)";
                xlWorkSheet1.Cells[4, 15] = "HTR Pinch(ºC)";

                using (var solver = new NLoptSolver(algorithm_type, 7, 0.000001, 10000))
                {
                    solver.SetLowerBounds(new[] { 0.0, initial_CIP_value, initial_CIP_value, 
                    initial_CIP_value, initial_CIP_value, initial_CIP_value , initial_CIP_value});
                    
                    solver.SetUpperBounds(new[] { 1.0, (puntero_aplicacion.p_mc3_out2 / 1.1), 
                    (puntero_aplicacion.p_mc3_out2 / 1.1), (puntero_aplicacion.p_mc3_out2 / 1.1), 
                    puntero_aplicacion.p_mc3_out2, puntero_aplicacion.p_mc3_out2 , 
                    puntero_aplicacion.p_mc3_out2});

                    solver.SetInitialStepSize(new[] { 0.05, 250.0, 250.0, 250.0, 1000.0, 1000.0, 1000.0 });

                    var initialValue = new[] { 0.2, initial_CIP_value + 1500.0, initial_CIP_value + 2000.0, 
                    initial_CIP_value + 3000.0, initial_CIP_value + 6000.0, initial_CIP_value + 5000.0,
                    initial_CIP_value + 4000.0 };

                    Func<double[], double> funcion = delegate (double[] variables)
                    {
                        puntero_aplicacion.luis.RecompCycle_RCMCI_with_Two_Intercooling_with_ThreeReheating(puntero_aplicacion.luis,
                        ref cicloRCMCI_withTwoIntercooling_withThreeRH, puntero_aplicacion.w_dot_net2,
                        puntero_aplicacion.t_mc2_in2, puntero_aplicacion.t_t_in2, puntero_aplicacion.t_rht1_in2,
                        variables[4], puntero_aplicacion.t_rht2_in2, variables[5],
                        puntero_aplicacion.t_rht3_in2, variables[6], variables[2],
                        variables[3], variables[1], puntero_aplicacion.t_mc1_in2,
                        variables[2], variables[3], puntero_aplicacion.t_mc3_in2,
                        puntero_aplicacion.p_mc3_out2, puntero_aplicacion.ua_lt2, puntero_aplicacion.ua_ht2,
                        puntero_aplicacion.eta2_mc2, puntero_aplicacion.eta_rc2, puntero_aplicacion.eta1_mc2,
                        puntero_aplicacion.eta3_mc2, puntero_aplicacion.eta_t2, puntero_aplicacion.eta_trh1,
                        puntero_aplicacion.eta_trh2, puntero_aplicacion.eta_trh3, puntero_aplicacion.n_sub_hxrs2,
                        variables[0], puntero_aplicacion.tol2, puntero_aplicacion.eta_thermal2,
                        -puntero_aplicacion.dp2_lt1, -puntero_aplicacion.dp2_lt2, -puntero_aplicacion.dp2_ht1,
                        -puntero_aplicacion.dp2_ht2, -puntero_aplicacion.dp1_pc1, -puntero_aplicacion.dp1_pc2,
                        -puntero_aplicacion.dp2_phx1, -puntero_aplicacion.dp2_phx2, -puntero_aplicacion.dp2_rhx11,
                        -puntero_aplicacion.dp2_rhx12, -puntero_aplicacion.dp2_rhx21, -puntero_aplicacion.dp2_rhx22,
                        -puntero_aplicacion.dp2_rhx31, -puntero_aplicacion.dp2_rhx32, -puntero_aplicacion.dp2_pc1,
                        -puntero_aplicacion.dp2_pc2, -puntero_aplicacion.dp3_pc1, -puntero_aplicacion.dp3_pc2);

                        counter++;

                        puntero_aplicacion.massflow2 = cicloRCMCI_withTwoIntercooling_withThreeRH.m_dot_turbine;
                        puntero_aplicacion.w_dot_net2 = cicloRCMCI_withTwoIntercooling_withThreeRH.W_dot_net;

                        puntero_aplicacion.eta_thermal2 = cicloRCMCI_withTwoIntercooling_withThreeRH.eta_thermal;
                        puntero_aplicacion.recomp_frac2 = variables[0];
                        puntero_aplicacion.p_mc1_in2 = variables[1];
                        puntero_aplicacion.p_mc1_out2 = variables[2];
                        puntero_aplicacion.p_mc2_in2 = variables[2];
                        puntero_aplicacion.p_mc2_out2 = variables[3];
                        puntero_aplicacion.p_mc3_in2 = variables[3];
                        puntero_aplicacion.p_rhx1_in2 = variables[4];
                        puntero_aplicacion.p_rhx2_in2 = variables[5];
                        puntero_aplicacion.p_rhx3_in2 = variables[6];

                        puntero_aplicacion.temp21 = cicloRCMCI_withTwoIntercooling_withThreeRH.temp[0];
                        puntero_aplicacion.temp22 = cicloRCMCI_withTwoIntercooling_withThreeRH.temp[1];
                        puntero_aplicacion.temp23 = cicloRCMCI_withTwoIntercooling_withThreeRH.temp[2];
                        puntero_aplicacion.temp24 = cicloRCMCI_withTwoIntercooling_withThreeRH.temp[3];
                        puntero_aplicacion.temp25 = cicloRCMCI_withTwoIntercooling_withThreeRH.temp[4];
                        puntero_aplicacion.temp26 = cicloRCMCI_withTwoIntercooling_withThreeRH.temp[5];
                        puntero_aplicacion.temp27 = cicloRCMCI_withTwoIntercooling_withThreeRH.temp[6];
                        puntero_aplicacion.temp28 = cicloRCMCI_withTwoIntercooling_withThreeRH.temp[7];
                        puntero_aplicacion.temp29 = cicloRCMCI_withTwoIntercooling_withThreeRH.temp[8];
                        puntero_aplicacion.temp210 = cicloRCMCI_withTwoIntercooling_withThreeRH.temp[9];
                        puntero_aplicacion.temp211 = cicloRCMCI_withTwoIntercooling_withThreeRH.temp[10];
                        puntero_aplicacion.temp212 = cicloRCMCI_withTwoIntercooling_withThreeRH.temp[11];
                        puntero_aplicacion.temp213 = cicloRCMCI_withTwoIntercooling_withThreeRH.temp[12];
                        puntero_aplicacion.temp214 = cicloRCMCI_withTwoIntercooling_withThreeRH.temp[13];
                        puntero_aplicacion.temp215 = cicloRCMCI_withTwoIntercooling_withThreeRH.temp[14];
                        puntero_aplicacion.temp216 = cicloRCMCI_withTwoIntercooling_withThreeRH.temp[15];
                        puntero_aplicacion.temp217 = cicloRCMCI_withTwoIntercooling_withThreeRH.temp[16];
                        puntero_aplicacion.temp218 = cicloRCMCI_withTwoIntercooling_withThreeRH.temp[17];
                        puntero_aplicacion.temp219 = cicloRCMCI_withTwoIntercooling_withThreeRH.temp[18];
                        puntero_aplicacion.temp220 = cicloRCMCI_withTwoIntercooling_withThreeRH.temp[19];

                        puntero_aplicacion.pres21 = cicloRCMCI_withTwoIntercooling_withThreeRH.pres[0];
                        puntero_aplicacion.pres22 = cicloRCMCI_withTwoIntercooling_withThreeRH.pres[1];
                        puntero_aplicacion.pres23 = cicloRCMCI_withTwoIntercooling_withThreeRH.pres[2];
                        puntero_aplicacion.pres24 = cicloRCMCI_withTwoIntercooling_withThreeRH.pres[3];
                        puntero_aplicacion.pres25 = cicloRCMCI_withTwoIntercooling_withThreeRH.pres[4];
                        puntero_aplicacion.pres26 = cicloRCMCI_withTwoIntercooling_withThreeRH.pres[5];
                        puntero_aplicacion.pres27 = cicloRCMCI_withTwoIntercooling_withThreeRH.pres[6];
                        puntero_aplicacion.pres28 = cicloRCMCI_withTwoIntercooling_withThreeRH.pres[7];
                        puntero_aplicacion.pres29 = cicloRCMCI_withTwoIntercooling_withThreeRH.pres[8];
                        puntero_aplicacion.pres210 = cicloRCMCI_withTwoIntercooling_withThreeRH.pres[9];
                        puntero_aplicacion.pres211 = cicloRCMCI_withTwoIntercooling_withThreeRH.pres[10];
                        puntero_aplicacion.pres212 = cicloRCMCI_withTwoIntercooling_withThreeRH.pres[11];
                        puntero_aplicacion.pres213 = cicloRCMCI_withTwoIntercooling_withThreeRH.pres[12];
                        puntero_aplicacion.pres214 = cicloRCMCI_withTwoIntercooling_withThreeRH.pres[13];
                        puntero_aplicacion.pres215 = cicloRCMCI_withTwoIntercooling_withThreeRH.pres[14];
                        puntero_aplicacion.pres216 = cicloRCMCI_withTwoIntercooling_withThreeRH.pres[15];
                        puntero_aplicacion.pres217 = cicloRCMCI_withTwoIntercooling_withThreeRH.pres[16];
                        puntero_aplicacion.pres218 = cicloRCMCI_withTwoIntercooling_withThreeRH.pres[17];
                        puntero_aplicacion.pres219 = cicloRCMCI_withTwoIntercooling_withThreeRH.pres[18];
                        puntero_aplicacion.pres220 = cicloRCMCI_withTwoIntercooling_withThreeRH.pres[19];

                        puntero_aplicacion.PHX1 = cicloRCMCI_withTwoIntercooling_withThreeRH.PHX.Q_dot;
                        puntero_aplicacion.RHX1 = cicloRCMCI_withTwoIntercooling_withThreeRH.RHX1.Q_dot;
                        puntero_aplicacion.RHX2 = cicloRCMCI_withTwoIntercooling_withThreeRH.RHX2.Q_dot;
                        puntero_aplicacion.RHX3 = cicloRCMCI_withTwoIntercooling_withThreeRH.RHX3.Q_dot;

                        puntero_aplicacion.LT_Q = cicloRCMCI_withTwoIntercooling_withThreeRH.LT.Q_dot;
                        puntero_aplicacion.LT_mdotc = cicloRCMCI_withTwoIntercooling_withThreeRH.LT.m_dot_design[0];
                        puntero_aplicacion.LT_mdoth = cicloRCMCI_withTwoIntercooling_withThreeRH.LT.m_dot_design[1];
                        puntero_aplicacion.LT_Tcin = cicloRCMCI_withTwoIntercooling_withThreeRH.LT.T_c_in;
                        puntero_aplicacion.LT_Thin = cicloRCMCI_withTwoIntercooling_withThreeRH.LT.T_h_in;
                        puntero_aplicacion.LT_Pcin = cicloRCMCI_withTwoIntercooling_withThreeRH.LT.P_c_in;
                        puntero_aplicacion.LT_Phin = cicloRCMCI_withTwoIntercooling_withThreeRH.LT.P_h_in;
                        puntero_aplicacion.LT_Pcout = cicloRCMCI_withTwoIntercooling_withThreeRH.LT.P_c_out;
                        puntero_aplicacion.LT_Phout = cicloRCMCI_withTwoIntercooling_withThreeRH.LT.P_h_out;
                        puntero_aplicacion.LT_Effc = cicloRCMCI_withTwoIntercooling_withThreeRH.LT.eff;

                        puntero_aplicacion.HT_Q = cicloRCMCI_withTwoIntercooling_withThreeRH.HT.Q_dot;
                        puntero_aplicacion.HT_mdotc = cicloRCMCI_withTwoIntercooling_withThreeRH.HT.m_dot_design[0];
                        puntero_aplicacion.HT_mdoth = cicloRCMCI_withTwoIntercooling_withThreeRH.HT.m_dot_design[1];
                        puntero_aplicacion.HT_Tcin = cicloRCMCI_withTwoIntercooling_withThreeRH.HT.T_c_in;
                        puntero_aplicacion.HT_Thin = cicloRCMCI_withTwoIntercooling_withThreeRH.HT.T_h_in;
                        puntero_aplicacion.HT_Pcin = cicloRCMCI_withTwoIntercooling_withThreeRH.HT.P_c_in;
                        puntero_aplicacion.HT_Phin = cicloRCMCI_withTwoIntercooling_withThreeRH.HT.P_h_in;
                        puntero_aplicacion.HT_Pcout = cicloRCMCI_withTwoIntercooling_withThreeRH.HT.P_c_out;
                        puntero_aplicacion.HT_Phout = cicloRCMCI_withTwoIntercooling_withThreeRH.HT.P_h_out;
                        puntero_aplicacion.HT_Effc = cicloRCMCI_withTwoIntercooling_withThreeRH.HT.eff;

                        puntero_aplicacion.PC1 = -cicloRCMCI_withTwoIntercooling_withThreeRH.PC1.Q_dot;
                        puntero_aplicacion.PC2 = -cicloRCMCI_withTwoIntercooling_withThreeRH.PC2.Q_dot;
                        puntero_aplicacion.PC3 = -cicloRCMCI_withTwoIntercooling_withThreeRH.COOLER.Q_dot;

                        eta_thermal2_list.Add(puntero_aplicacion.eta_thermal2);
                        recomp_frac2_list.Add(puntero_aplicacion.recomp_frac2);
                        p_mc1_in2_list.Add(puntero_aplicacion.p_mc1_in2);
                        p_mc1_out2_list.Add(puntero_aplicacion.p_mc1_out2);
                        p_mc2_out2_list.Add(puntero_aplicacion.p_mc2_out2);
                        p_rhx1_list.Add(puntero_aplicacion.p_rhx1_in2);
                        p_rhx2_list.Add(puntero_aplicacion.p_rhx2_in2);
                        p_rhx3_list.Add(puntero_aplicacion.p_rhx3_in2);
                        ua_LT_list.Add(puntero_aplicacion.ua_lt2);
                        ua_HT_list.Add(puntero_aplicacion.ua_ht2);

                        listBox1.Items.Add(counter.ToString());
                        listBox2.Items.Add(puntero_aplicacion.eta_thermal2.ToString());
                        listBox3.Items.Add(puntero_aplicacion.recomp_frac2.ToString());
                        listBox4.Items.Add(puntero_aplicacion.p_mc1_in2.ToString());
                        listBox7.Items.Add(puntero_aplicacion.p_mc1_out2.ToString());
                        listBox24.Items.Add(puntero_aplicacion.p_mc2_in2.ToString());
                        listBox23.Items.Add(puntero_aplicacion.p_mc2_out2.ToString());
                        listBox19.Items.Add(puntero_aplicacion.p_rhx1_in2.ToString());
                        listBox21.Items.Add(puntero_aplicacion.p_rhx2_in2.ToString());
                        listBox27.Items.Add(puntero_aplicacion.p_rhx3_in2.ToString());
                        listBox5.Items.Add(puntero_aplicacion.ua_lt2.ToString());
                        listBox6.Items.Add(puntero_aplicacion.ua_ht2.ToString());
                        listBox8.Items.Add(puntero_aplicacion.temp27.ToString());
                        listBox9.Items.Add(puntero_aplicacion.temp28.ToString());

                        double LTR_min_DT_1 = cicloRCMCI_withTwoIntercooling_withThreeRH.temp[7] - cicloRCMCI_withTwoIntercooling_withThreeRH.temp[2];
                        double LTR_min_DT_2 = cicloRCMCI_withTwoIntercooling_withThreeRH.temp[8] - cicloRCMCI_withTwoIntercooling_withThreeRH.temp[1];
                        double LTR_min_DT_paper = Math.Min(LTR_min_DT_1, LTR_min_DT_2);

                        double HTR_min_DT_1 = cicloRCMCI_withTwoIntercooling_withThreeRH.temp[7] - cicloRCMCI_withTwoIntercooling_withThreeRH.temp[3];
                        double HTR_min_DT_2 = cicloRCMCI_withTwoIntercooling_withThreeRH.temp[6] - cicloRCMCI_withTwoIntercooling_withThreeRH.temp[4];
                        double HTR_min_DT_paper = Math.Min(HTR_min_DT_1, HTR_min_DT_2);

                        //MC1_in(kPa)
                        xlWorkSheet1.Cells[counter_Excel + 1, 1] = Convert.ToString(puntero_aplicacion.p_mc1_in2);
                        //MC1_out(kPa)
                        xlWorkSheet1.Cells[counter_Excel + 1, 2] = Convert.ToString(puntero_aplicacion.p_mc1_out2);
                        //MC2_out(kPa)
                        xlWorkSheet1.Cells[counter_Excel + 1, 3] = Convert.ToString(puntero_aplicacion.p_mc2_out2);
                        //P_rhx1(kPa)
                        xlWorkSheet1.Cells[counter_Excel + 1, 4] = Convert.ToString(puntero_aplicacion.p_rhx1_in2);
                        //P_rhx2(kPa)
                        xlWorkSheet1.Cells[counter_Excel + 1, 5] = Convert.ToString(puntero_aplicacion.p_rhx2_in2);
                        //P_rhx3(kPa)
                        xlWorkSheet1.Cells[counter_Excel + 1, 6] = Convert.ToString(puntero_aplicacion.p_rhx3_in2);
                        //CIT (MC1)
                        xlWorkSheet1.Cells[counter_Excel + 1, 7] = Convert.ToString(puntero_aplicacion.t_mc1_in2 - 273.15);
                        //LT UA(kW/K)
                        xlWorkSheet1.Cells[counter_Excel + 1, 8] = Convert.ToString(puntero_aplicacion.ua_lt2);
                        //HT UA(kW/K)
                        xlWorkSheet1.Cells[counter_Excel + 1, 9] = Convert.ToString(puntero_aplicacion.ua_ht2);
                        //Rec.Frac.
                        xlWorkSheet1.Cells[counter_Excel + 1, 10] = puntero_aplicacion.recomp_frac2.ToString();
                        //Eff.(%)
                        xlWorkSheet1.Cells[counter_Excel + 1, 11] = (puntero_aplicacion.eta_thermal2 * 100).ToString();
                        //LTR Eff.(%)
                        xlWorkSheet1.Cells[counter_Excel + 1, 12] = cicloRCMCI_withTwoIntercooling_withThreeRH.LT.eff.ToString();
                        //LTR Pinch(ºC)
                        xlWorkSheet1.Cells[counter_Excel + 1, 13] = LTR_min_DT_paper.ToString();
                        //HTR Eff.(%)
                        xlWorkSheet1.Cells[counter_Excel + 1, 14] = cicloRCMCI_withTwoIntercooling_withThreeRH.HT.eff.ToString();
                        //HTR Pinch(ºC)
                        xlWorkSheet1.Cells[counter_Excel + 1, 15] = HTR_min_DT_paper.ToString();

                        counter_Excel++;

                        return puntero_aplicacion.eta_thermal2;
                    };

                    solver.SetMaxObjective(funcion);

                    double? finalScore;

                    var result = solver.Optimize(initialValue, out finalScore);

                    Double max_eta_thermal = 0.0;

                    max_eta_thermal = eta_thermal2_list.Max();

                    var maxIndex = eta_thermal2_list.IndexOf(eta_thermal2_list.Max());

                    textBox86.Text = eta_thermal2_list[maxIndex].ToString();
                    textBox90.Text = recomp_frac2_list[maxIndex].ToString();
                    textBox91.Text = p_mc1_in2_list[maxIndex].ToString();
                    textBox2.Text = p_mc1_out2_list[maxIndex].ToString();
                    textBox4.Text = p_mc2_out2_list[maxIndex].ToString();
                    textBox6.Text = p_rhx1_list[maxIndex].ToString();
                    textBox5.Text = p_rhx2_list[maxIndex].ToString();
                    textBox7.Text = p_rhx3_list[maxIndex].ToString();
                    textBox82.Text = ua_LT_list[maxIndex].ToString();
                    textBox83.Text = ua_HT_list[maxIndex].ToString();

                    //Copy results as design-point inputs
                    if (checkBox3.Checked == true)
                    {
                        puntero_aplicacion.textBox15.Text = recomp_frac2_list[maxIndex].ToString();
                        puntero_aplicacion.textBox3.Text = p_mc1_in2_list[maxIndex].ToString();
                        puntero_aplicacion.textBox8.Text = p_mc1_out2_list[maxIndex].ToString();
                        puntero_aplicacion.textBox23.Text = p_mc1_out2_list[maxIndex].ToString();
                        puntero_aplicacion.textBox22.Text = p_mc2_out2_list[maxIndex].ToString();
                        puntero_aplicacion.textBox95.Text = p_mc2_out2_list[maxIndex].ToString();
                        puntero_aplicacion.textBox7.Text = p_rhx1_list[maxIndex].ToString();
                        puntero_aplicacion.textBox107.Text = p_rhx2_list[maxIndex].ToString();
                        puntero_aplicacion.textBox115.Text = p_rhx3_list[maxIndex].ToString();
                    }

                    //Closing Excel Book
                    xlWorkBook1.SaveAs(textBox3.Text + "RCMCI_with_Two_Intercooling_with_Three_ReHeating" + ".xls", Excel.XlFileFormat.xlWorkbookNormal, misValue1, misValue1, misValue1, misValue1, Excel.XlSaveAsAccessMode.xlExclusive, misValue1, misValue1, misValue1, misValue1, misValue1);

                    xlWorkBook1.Close(true, misValue1, misValue1);
                    xlApp1.Quit();

                    releaseObject(xlWorkSheet1);
                    //releaseObject(xlWorkSheet2);
                    releaseObject(xlWorkBook1);
                    releaseObject(xlApp1);
                }
            } //end UA optimization false

            //Optimize UA true
            else if (checkBox2.Checked == true)
            {
                //PureFluid
                if (puntero_aplicacion.comboBox1.Text == "PureFluid")
                {
                    puntero_aplicacion.category = RefrigerantCategory.PureFluid;
                    puntero_aplicacion.luis.core1(puntero_aplicacion.comboBox1.Text, puntero_aplicacion.category);
                }

                //NewMixture
                if (puntero_aplicacion.comboBox1.Text == "NewMixture")
                {
                    puntero_aplicacion.category = RefrigerantCategory.NewMixture;
                    puntero_aplicacion.luis.core1(puntero_aplicacion.comboBox2.Text + "=" + puntero_aplicacion.textBox35.Text + "," + puntero_aplicacion.comboBox16.Text + "=" + puntero_aplicacion.textBox36.Text, puntero_aplicacion.category);
                }

                if (puntero_aplicacion.comboBox1.Text == "PredefinedMixture")
                {
                    puntero_aplicacion.category = RefrigerantCategory.PredefinedMixture;
                }

                if (puntero_aplicacion.comboBox1.Text == "PseudoPureFluid")
                {
                    puntero_aplicacion.category = RefrigerantCategory.PseudoPureFluid;
                }

                if (puntero_aplicacion.comboBox3.Text == "DEF")
                {
                    puntero_aplicacion.referencestate = ReferenceState.DEF;
                }
                if (puntero_aplicacion.comboBox3.Text == "ASH")
                {
                    puntero_aplicacion.referencestate = ReferenceState.ASH;
                }
                if (puntero_aplicacion.comboBox3.Text == "IIR")
                {
                    puntero_aplicacion.referencestate = ReferenceState.IIR;
                }
                if (puntero_aplicacion.comboBox3.Text == "NBP")
                {
                    puntero_aplicacion.referencestate = ReferenceState.NBP;
                }

                puntero_aplicacion.luis.working_fluid.Category = puntero_aplicacion.category;
                puntero_aplicacion.luis.working_fluid.reference = puntero_aplicacion.referencestate;

                puntero_aplicacion.luis.wmm = puntero_aplicacion.luis.working_fluid.MolecularWeight;

                //Store Input Data from Graphical User Interface GUI into variables
                puntero_aplicacion.w_dot_net2 = Convert.ToDouble(puntero_aplicacion.textBox1.Text);
                puntero_aplicacion.t_mc1_in2 = Convert.ToDouble(puntero_aplicacion.textBox2.Text);
                puntero_aplicacion.t_mc2_in2 = Convert.ToDouble(puntero_aplicacion.textBox28.Text);
                puntero_aplicacion.t_mc3_in2 = Convert.ToDouble(puntero_aplicacion.textBox93.Text);
                puntero_aplicacion.t_t_in2 = Convert.ToDouble(puntero_aplicacion.textBox4.Text);
                puntero_aplicacion.p_mc1_in2 = Convert.ToDouble(puntero_aplicacion.textBox3.Text);
                puntero_aplicacion.p_mc1_out2 = Convert.ToDouble(puntero_aplicacion.textBox8.Text);
                puntero_aplicacion.p_mc2_in2 = Convert.ToDouble(puntero_aplicacion.textBox23.Text);
                puntero_aplicacion.p_mc2_out2 = Convert.ToDouble(puntero_aplicacion.textBox22.Text);
                puntero_aplicacion.p_mc3_in2 = Convert.ToDouble(puntero_aplicacion.textBox95.Text);
                puntero_aplicacion.p_mc3_out2 = Convert.ToDouble(puntero_aplicacion.textBox94.Text);
                puntero_aplicacion.p_rhx1_in2 = Convert.ToDouble(puntero_aplicacion.textBox7.Text);
                puntero_aplicacion.t_rht1_in2 = Convert.ToDouble(puntero_aplicacion.textBox6.Text);
                puntero_aplicacion.p_rhx2_in2 = Convert.ToDouble(puntero_aplicacion.textBox107.Text);
                puntero_aplicacion.t_rht2_in2 = Convert.ToDouble(puntero_aplicacion.textBox106.Text);
                puntero_aplicacion.p_rhx3_in2 = Convert.ToDouble(puntero_aplicacion.textBox115.Text);
                puntero_aplicacion.t_rht3_in2 = Convert.ToDouble(puntero_aplicacion.textBox114.Text);
                puntero_aplicacion.ua_lt2 = Convert.ToDouble(puntero_aplicacion.textBox17.Text);
                puntero_aplicacion.ua_ht2 = Convert.ToDouble(puntero_aplicacion.textBox16.Text);
                puntero_aplicacion.recomp_frac2 = Convert.ToDouble(puntero_aplicacion.textBox15.Text);
                puntero_aplicacion.eta1_mc2 = Convert.ToDouble(puntero_aplicacion.textBox14.Text);
                puntero_aplicacion.eta2_mc2 = Convert.ToDouble(puntero_aplicacion.textBox27.Text);
                puntero_aplicacion.eta3_mc2 = Convert.ToDouble(puntero_aplicacion.textBox92.Text);
                puntero_aplicacion.eta_rc2 = Convert.ToDouble(puntero_aplicacion.textBox13.Text);
                puntero_aplicacion.eta_t2 = Convert.ToDouble(puntero_aplicacion.textBox19.Text);
                puntero_aplicacion.eta_trh1 = Convert.ToDouble(puntero_aplicacion.textBox18.Text);
                puntero_aplicacion.eta_trh2 = Convert.ToDouble(puntero_aplicacion.textBox108.Text);
                puntero_aplicacion.eta_trh3 = Convert.ToDouble(puntero_aplicacion.textBox113.Text);
                puntero_aplicacion.n_sub_hxrs2 = Convert.ToInt64(puntero_aplicacion.textBox20.Text);
                puntero_aplicacion.tol2 = Convert.ToDouble(puntero_aplicacion.textBox21.Text);
                puntero_aplicacion.dp2_lt1 = Convert.ToDouble(puntero_aplicacion.textBox5.Text);
                puntero_aplicacion.dp2_ht1 = Convert.ToDouble(puntero_aplicacion.textBox12.Text);
                puntero_aplicacion.dp1_pc1 = Convert.ToDouble(puntero_aplicacion.textBox11.Text);
                puntero_aplicacion.dp2_pc1 = Convert.ToDouble(puntero_aplicacion.textBox24.Text);
                puntero_aplicacion.dp3_pc1 = Convert.ToDouble(puntero_aplicacion.textBox96.Text);
                puntero_aplicacion.dp2_phx1 = Convert.ToDouble(puntero_aplicacion.textBox10.Text);
                puntero_aplicacion.dp2_rhx12 = Convert.ToDouble(puntero_aplicacion.textBox9.Text);
                puntero_aplicacion.dp2_rhx22 = Convert.ToDouble(puntero_aplicacion.textBox105.Text);
                puntero_aplicacion.dp2_rhx32 = Convert.ToDouble(puntero_aplicacion.textBox116.Text);
                puntero_aplicacion.dp2_lt2 = Convert.ToDouble(puntero_aplicacion.textBox26.Text);
                puntero_aplicacion.dp2_ht2 = Convert.ToDouble(puntero_aplicacion.textBox25.Text);

                core.RCMCIwithTwoIntercoolingwithThreeReheating cicloRCMCI_withTwoIntercooling_withThreeRH = new core.RCMCIwithTwoIntercoolingwithThreeReheating();

                double UA_Total = puntero_aplicacion.ua_lt2 + puntero_aplicacion.ua_ht2;

                double LT_fraction = 0.1;

                int counter = 0;

                List<Double> recomp_frac2_list = new List<Double>();
                List<Double> p_mc1_in2_list = new List<Double>();
                List<Double> p_mc1_out2_list = new List<Double>();
                List<Double> p_mc2_out2_list = new List<Double>();
                List<Double> p_rhx1_list = new List<Double>();
                List<Double> p_rhx2_list = new List<Double>();
                List<Double> p_rhx3_list = new List<Double>();
                List<Double> eta_thermal2_list = new List<Double>();
                List<Double> ua_LT_list = new List<Double>();
                List<Double> ua_HT_list = new List<Double>();

                NLoptAlgorithm algorithm_type = NLoptAlgorithm.LN_BOBYQA;

                if (comboBox19.Text == "BOBYQA")
                    algorithm_type = NLoptAlgorithm.LN_BOBYQA;
                else if (comboBox19.Text == "COBYLA")
                    algorithm_type = NLoptAlgorithm.LN_COBYLA;
                else if (comboBox19.Text == "SUBPLEX")
                    algorithm_type = NLoptAlgorithm.LN_SBPLX;
                else if (comboBox19.Text == "NELDER-MEAD")
                    algorithm_type = NLoptAlgorithm.LN_NELDERMEAD;
                else if (comboBox19.Text == "NEWUOA")
                    algorithm_type = NLoptAlgorithm.LN_NEWUOA;
                else if (comboBox19.Text == "PRAXIS")
                    algorithm_type = NLoptAlgorithm.LN_PRAXIS;

                if (checkBox6.Checked == true)
                {
                    initial_CIP_value = Convert.ToDouble(textBox1.Text);
                }
                else
                {
                    initial_CIP_value = puntero_aplicacion.MixtureCriticalPressure;
                }

                xlWorkSheet1.Name = puntero_aplicacion.comboBox2.Text + " Mixture";

                //puntero_aplicacion.comboBox2.Text + "=" + puntero_aplicacion.textBox68.Text + "," + puntero_aplicacion.comboBox6.Text + "=" + puntero_aplicacion.textBox69.Text + "," + puntero_aplicacion.comboBox12.Text + "=" + puntero_aplicacion.textBox33.Text + "," + puntero_aplicacion.comboBox7.Text + "=" + puntero_aplicacion.textBox34.Text
                xlWorkSheet1.Cells[1, 1] = puntero_aplicacion.comboBox2.Text + ":" + puntero_aplicacion.textBox33.Text + "," + puntero_aplicacion.comboBox6.Text + ":" + puntero_aplicacion.textBox34.Text + "," + puntero_aplicacion.comboBox12.Text + ":" + puntero_aplicacion.textBox68.Text + "," + puntero_aplicacion.comboBox7.Text + ":" + puntero_aplicacion.textBox69.Text;
                xlWorkSheet1.Cells[1, 2] = "Pcrit(kPa)";
                xlWorkSheet1.Cells[1, 3] = "Tcrit(ºC)";

                xlWorkSheet1.Cells[2, 1] = "";
                xlWorkSheet1.Cells[2, 2] = Convert.ToString(puntero_aplicacion.MixtureCriticalPressure);
                xlWorkSheet1.Cells[2, 3] = Convert.ToString(puntero_aplicacion.MixtureCriticalTemperature - 273.15);

                xlWorkSheet1.Cells[3, 1] = "";
                xlWorkSheet1.Cells[3, 2] = "";
                xlWorkSheet1.Cells[4, 3] = "";

                xlWorkSheet1.Cells[4, 1] = "MC1_in(kPa)";
                xlWorkSheet1.Cells[4, 2] = "MC1_out(kPa)";
                xlWorkSheet1.Cells[4, 3] = "MC2_out(kPa)";
                xlWorkSheet1.Cells[4, 4] = "P_rhx1(kPa)";
                xlWorkSheet1.Cells[4, 5] = "P_rhx2(kPa)";
                xlWorkSheet1.Cells[4, 6] = "P_rhx3(kPa)";
                xlWorkSheet1.Cells[4, 7] = "CIT(K)";
                xlWorkSheet1.Cells[4, 8] = "LT UA(kW/K)";
                xlWorkSheet1.Cells[4, 9] = "HT UA(kW/K)";
                xlWorkSheet1.Cells[4, 10] = "Rec.Frac.";
                xlWorkSheet1.Cells[4, 11] = "Eff.(%)";
                xlWorkSheet1.Cells[4, 12] = "LTR Eff.(%)";
                xlWorkSheet1.Cells[4, 13] = "LTR Pinch(ºC)";
                xlWorkSheet1.Cells[4, 14] = "HTR Eff.(%)";
                xlWorkSheet1.Cells[4, 15] = "HTR Pinch(ºC)";

                using (var solver = new NLoptSolver(algorithm_type, 8, 0.000001, 10000))
                {
                    solver.SetLowerBounds(new[] { 0.0, initial_CIP_value, initial_CIP_value,
                    initial_CIP_value, initial_CIP_value, initial_CIP_value , initial_CIP_value, 0.0});

                    solver.SetUpperBounds(new[] { 1.0, (puntero_aplicacion.p_mc3_out2 / 1.1),
                    (puntero_aplicacion.p_mc3_out2 / 1.1), (puntero_aplicacion.p_mc3_out2 / 1.1),
                    puntero_aplicacion.p_mc3_out2, puntero_aplicacion.p_mc3_out2 ,
                    puntero_aplicacion.p_mc3_out2, 1.0});

                    solver.SetInitialStepSize(new[] { 0.05, 250.0, 250.0, 250.0, 1000.0, 1000.0, 1000.0, 0.05 });

                    var initialValue = new[] { 0.2, initial_CIP_value + 1500.0, initial_CIP_value + 2000.0,
                    initial_CIP_value + 3000.0, initial_CIP_value + 6000.0, initial_CIP_value + 5000.0,
                    initial_CIP_value + 4000.0, 0.5 };

                    Func<double[], double> funcion = delegate (double[] variables)
                    {
                        puntero_aplicacion.luis.RecompCycle_RCMCI_with_Two_Intercooling_with_ThreeReheating_for_optimization(puntero_aplicacion.luis,
                        ref cicloRCMCI_withTwoIntercooling_withThreeRH, puntero_aplicacion.w_dot_net2,
                        puntero_aplicacion.t_mc2_in2, puntero_aplicacion.t_t_in2, puntero_aplicacion.t_rht1_in2,
                        variables[4], puntero_aplicacion.t_rht2_in2, variables[5],
                        puntero_aplicacion.t_rht3_in2, variables[6], variables[2],
                        variables[3], variables[1], puntero_aplicacion.t_mc1_in2,
                        variables[2], variables[3], puntero_aplicacion.t_mc3_in2,
                        puntero_aplicacion.p_mc3_out2, variables[7], UA_Total,
                        puntero_aplicacion.eta2_mc2, puntero_aplicacion.eta_rc2, puntero_aplicacion.eta1_mc2,
                        puntero_aplicacion.eta3_mc2, puntero_aplicacion.eta_t2, puntero_aplicacion.eta_trh1,
                        puntero_aplicacion.eta_trh2, puntero_aplicacion.eta_trh3, puntero_aplicacion.n_sub_hxrs2,
                        variables[0], puntero_aplicacion.tol2, puntero_aplicacion.eta_thermal2,
                        -puntero_aplicacion.dp2_lt1, -puntero_aplicacion.dp2_lt2, -puntero_aplicacion.dp2_ht1,
                        -puntero_aplicacion.dp2_ht2, -puntero_aplicacion.dp1_pc1, -puntero_aplicacion.dp1_pc2,
                        -puntero_aplicacion.dp2_phx1, -puntero_aplicacion.dp2_phx2, -puntero_aplicacion.dp2_rhx11,
                        -puntero_aplicacion.dp2_rhx12, -puntero_aplicacion.dp2_rhx21, -puntero_aplicacion.dp2_rhx22,
                        -puntero_aplicacion.dp2_rhx31, -puntero_aplicacion.dp2_rhx32, -puntero_aplicacion.dp2_pc1,
                        -puntero_aplicacion.dp2_pc2, -puntero_aplicacion.dp3_pc1, -puntero_aplicacion.dp3_pc2);

                        counter++;

                        puntero_aplicacion.massflow2 = cicloRCMCI_withTwoIntercooling_withThreeRH.m_dot_turbine;
                        puntero_aplicacion.w_dot_net2 = cicloRCMCI_withTwoIntercooling_withThreeRH.W_dot_net;

                        puntero_aplicacion.eta_thermal2 = cicloRCMCI_withTwoIntercooling_withThreeRH.eta_thermal;
                        puntero_aplicacion.recomp_frac2 = variables[0];
                        puntero_aplicacion.p_mc1_in2 = variables[1];
                        puntero_aplicacion.p_mc1_out2 = variables[2];
                        puntero_aplicacion.p_mc2_in2 = variables[2];
                        puntero_aplicacion.p_mc2_out2 = variables[3];
                        puntero_aplicacion.p_mc3_in2 = variables[3];
                        puntero_aplicacion.p_rhx1_in2 = variables[4];
                        puntero_aplicacion.p_rhx2_in2 = variables[5];
                        puntero_aplicacion.p_rhx3_in2 = variables[6];
                        LT_fraction = variables[7];
                        puntero_aplicacion.ua_lt2 = UA_Total * LT_fraction;
                        puntero_aplicacion.ua_ht2 = UA_Total * (1 - LT_fraction);

                        puntero_aplicacion.temp21 = cicloRCMCI_withTwoIntercooling_withThreeRH.temp[0];
                        puntero_aplicacion.temp22 = cicloRCMCI_withTwoIntercooling_withThreeRH.temp[1];
                        puntero_aplicacion.temp23 = cicloRCMCI_withTwoIntercooling_withThreeRH.temp[2];
                        puntero_aplicacion.temp24 = cicloRCMCI_withTwoIntercooling_withThreeRH.temp[3];
                        puntero_aplicacion.temp25 = cicloRCMCI_withTwoIntercooling_withThreeRH.temp[4];
                        puntero_aplicacion.temp26 = cicloRCMCI_withTwoIntercooling_withThreeRH.temp[5];
                        puntero_aplicacion.temp27 = cicloRCMCI_withTwoIntercooling_withThreeRH.temp[6];
                        puntero_aplicacion.temp28 = cicloRCMCI_withTwoIntercooling_withThreeRH.temp[7];
                        puntero_aplicacion.temp29 = cicloRCMCI_withTwoIntercooling_withThreeRH.temp[8];
                        puntero_aplicacion.temp210 = cicloRCMCI_withTwoIntercooling_withThreeRH.temp[9];
                        puntero_aplicacion.temp211 = cicloRCMCI_withTwoIntercooling_withThreeRH.temp[10];
                        puntero_aplicacion.temp212 = cicloRCMCI_withTwoIntercooling_withThreeRH.temp[11];
                        puntero_aplicacion.temp213 = cicloRCMCI_withTwoIntercooling_withThreeRH.temp[12];
                        puntero_aplicacion.temp214 = cicloRCMCI_withTwoIntercooling_withThreeRH.temp[13];
                        puntero_aplicacion.temp215 = cicloRCMCI_withTwoIntercooling_withThreeRH.temp[14];
                        puntero_aplicacion.temp216 = cicloRCMCI_withTwoIntercooling_withThreeRH.temp[15];
                        puntero_aplicacion.temp217 = cicloRCMCI_withTwoIntercooling_withThreeRH.temp[16];
                        puntero_aplicacion.temp218 = cicloRCMCI_withTwoIntercooling_withThreeRH.temp[17];
                        puntero_aplicacion.temp219 = cicloRCMCI_withTwoIntercooling_withThreeRH.temp[18];
                        puntero_aplicacion.temp220 = cicloRCMCI_withTwoIntercooling_withThreeRH.temp[19];

                        puntero_aplicacion.pres21 = cicloRCMCI_withTwoIntercooling_withThreeRH.pres[0];
                        puntero_aplicacion.pres22 = cicloRCMCI_withTwoIntercooling_withThreeRH.pres[1];
                        puntero_aplicacion.pres23 = cicloRCMCI_withTwoIntercooling_withThreeRH.pres[2];
                        puntero_aplicacion.pres24 = cicloRCMCI_withTwoIntercooling_withThreeRH.pres[3];
                        puntero_aplicacion.pres25 = cicloRCMCI_withTwoIntercooling_withThreeRH.pres[4];
                        puntero_aplicacion.pres26 = cicloRCMCI_withTwoIntercooling_withThreeRH.pres[5];
                        puntero_aplicacion.pres27 = cicloRCMCI_withTwoIntercooling_withThreeRH.pres[6];
                        puntero_aplicacion.pres28 = cicloRCMCI_withTwoIntercooling_withThreeRH.pres[7];
                        puntero_aplicacion.pres29 = cicloRCMCI_withTwoIntercooling_withThreeRH.pres[8];
                        puntero_aplicacion.pres210 = cicloRCMCI_withTwoIntercooling_withThreeRH.pres[9];
                        puntero_aplicacion.pres211 = cicloRCMCI_withTwoIntercooling_withThreeRH.pres[10];
                        puntero_aplicacion.pres212 = cicloRCMCI_withTwoIntercooling_withThreeRH.pres[11];
                        puntero_aplicacion.pres213 = cicloRCMCI_withTwoIntercooling_withThreeRH.pres[12];
                        puntero_aplicacion.pres214 = cicloRCMCI_withTwoIntercooling_withThreeRH.pres[13];
                        puntero_aplicacion.pres215 = cicloRCMCI_withTwoIntercooling_withThreeRH.pres[14];
                        puntero_aplicacion.pres216 = cicloRCMCI_withTwoIntercooling_withThreeRH.pres[15];
                        puntero_aplicacion.pres217 = cicloRCMCI_withTwoIntercooling_withThreeRH.pres[16];
                        puntero_aplicacion.pres218 = cicloRCMCI_withTwoIntercooling_withThreeRH.pres[17];
                        puntero_aplicacion.pres219 = cicloRCMCI_withTwoIntercooling_withThreeRH.pres[18];
                        puntero_aplicacion.pres220 = cicloRCMCI_withTwoIntercooling_withThreeRH.pres[19];

                        puntero_aplicacion.PHX1 = cicloRCMCI_withTwoIntercooling_withThreeRH.PHX.Q_dot;
                        puntero_aplicacion.RHX1 = cicloRCMCI_withTwoIntercooling_withThreeRH.RHX1.Q_dot;
                        puntero_aplicacion.RHX2 = cicloRCMCI_withTwoIntercooling_withThreeRH.RHX2.Q_dot;
                        puntero_aplicacion.RHX3 = cicloRCMCI_withTwoIntercooling_withThreeRH.RHX3.Q_dot;

                        puntero_aplicacion.LT_Q = cicloRCMCI_withTwoIntercooling_withThreeRH.LT.Q_dot;
                        puntero_aplicacion.LT_mdotc = cicloRCMCI_withTwoIntercooling_withThreeRH.LT.m_dot_design[0];
                        puntero_aplicacion.LT_mdoth = cicloRCMCI_withTwoIntercooling_withThreeRH.LT.m_dot_design[1];
                        puntero_aplicacion.LT_Tcin = cicloRCMCI_withTwoIntercooling_withThreeRH.LT.T_c_in;
                        puntero_aplicacion.LT_Thin = cicloRCMCI_withTwoIntercooling_withThreeRH.LT.T_h_in;
                        puntero_aplicacion.LT_Pcin = cicloRCMCI_withTwoIntercooling_withThreeRH.LT.P_c_in;
                        puntero_aplicacion.LT_Phin = cicloRCMCI_withTwoIntercooling_withThreeRH.LT.P_h_in;
                        puntero_aplicacion.LT_Pcout = cicloRCMCI_withTwoIntercooling_withThreeRH.LT.P_c_out;
                        puntero_aplicacion.LT_Phout = cicloRCMCI_withTwoIntercooling_withThreeRH.LT.P_h_out;
                        puntero_aplicacion.LT_Effc = cicloRCMCI_withTwoIntercooling_withThreeRH.LT.eff;

                        puntero_aplicacion.HT_Q = cicloRCMCI_withTwoIntercooling_withThreeRH.HT.Q_dot;
                        puntero_aplicacion.HT_mdotc = cicloRCMCI_withTwoIntercooling_withThreeRH.HT.m_dot_design[0];
                        puntero_aplicacion.HT_mdoth = cicloRCMCI_withTwoIntercooling_withThreeRH.HT.m_dot_design[1];
                        puntero_aplicacion.HT_Tcin = cicloRCMCI_withTwoIntercooling_withThreeRH.HT.T_c_in;
                        puntero_aplicacion.HT_Thin = cicloRCMCI_withTwoIntercooling_withThreeRH.HT.T_h_in;
                        puntero_aplicacion.HT_Pcin = cicloRCMCI_withTwoIntercooling_withThreeRH.HT.P_c_in;
                        puntero_aplicacion.HT_Phin = cicloRCMCI_withTwoIntercooling_withThreeRH.HT.P_h_in;
                        puntero_aplicacion.HT_Pcout = cicloRCMCI_withTwoIntercooling_withThreeRH.HT.P_c_out;
                        puntero_aplicacion.HT_Phout = cicloRCMCI_withTwoIntercooling_withThreeRH.HT.P_h_out;
                        puntero_aplicacion.HT_Effc = cicloRCMCI_withTwoIntercooling_withThreeRH.HT.eff;

                        puntero_aplicacion.PC1 = -cicloRCMCI_withTwoIntercooling_withThreeRH.PC1.Q_dot;
                        puntero_aplicacion.PC2 = -cicloRCMCI_withTwoIntercooling_withThreeRH.PC2.Q_dot;
                        puntero_aplicacion.PC3 = -cicloRCMCI_withTwoIntercooling_withThreeRH.COOLER.Q_dot;

                        eta_thermal2_list.Add(puntero_aplicacion.eta_thermal2);
                        recomp_frac2_list.Add(puntero_aplicacion.recomp_frac2);
                        p_mc1_in2_list.Add(puntero_aplicacion.p_mc1_in2);
                        p_mc1_out2_list.Add(puntero_aplicacion.p_mc1_out2);
                        p_mc2_out2_list.Add(puntero_aplicacion.p_mc2_out2);
                        p_rhx1_list.Add(puntero_aplicacion.p_rhx1_in2);
                        p_rhx2_list.Add(puntero_aplicacion.p_rhx2_in2);
                        p_rhx3_list.Add(puntero_aplicacion.p_rhx3_in2);
                        ua_LT_list.Add(puntero_aplicacion.ua_lt2);
                        ua_HT_list.Add(puntero_aplicacion.ua_ht2);

                        listBox1.Items.Add(counter.ToString());
                        listBox2.Items.Add(puntero_aplicacion.eta_thermal2.ToString());
                        listBox3.Items.Add(puntero_aplicacion.recomp_frac2.ToString());
                        listBox4.Items.Add(puntero_aplicacion.p_mc1_in2.ToString());
                        listBox7.Items.Add(puntero_aplicacion.p_mc1_out2.ToString());
                        listBox24.Items.Add(puntero_aplicacion.p_mc2_in2.ToString());
                        listBox23.Items.Add(puntero_aplicacion.p_mc2_out2.ToString());
                        listBox19.Items.Add(puntero_aplicacion.p_rhx1_in2.ToString());
                        listBox21.Items.Add(puntero_aplicacion.p_rhx2_in2.ToString());
                        listBox27.Items.Add(puntero_aplicacion.p_rhx3_in2.ToString());
                        listBox5.Items.Add(puntero_aplicacion.ua_lt2.ToString());
                        listBox6.Items.Add(puntero_aplicacion.ua_ht2.ToString());
                        listBox8.Items.Add(puntero_aplicacion.temp27.ToString());
                        listBox9.Items.Add(puntero_aplicacion.temp28.ToString());

                        double LTR_min_DT_1 = cicloRCMCI_withTwoIntercooling_withThreeRH.temp[7] - cicloRCMCI_withTwoIntercooling_withThreeRH.temp[2];
                        double LTR_min_DT_2 = cicloRCMCI_withTwoIntercooling_withThreeRH.temp[8] - cicloRCMCI_withTwoIntercooling_withThreeRH.temp[1];
                        double LTR_min_DT_paper = Math.Min(LTR_min_DT_1, LTR_min_DT_2);

                        double HTR_min_DT_1 = cicloRCMCI_withTwoIntercooling_withThreeRH.temp[7] - cicloRCMCI_withTwoIntercooling_withThreeRH.temp[3];
                        double HTR_min_DT_2 = cicloRCMCI_withTwoIntercooling_withThreeRH.temp[6] - cicloRCMCI_withTwoIntercooling_withThreeRH.temp[4];
                        double HTR_min_DT_paper = Math.Min(HTR_min_DT_1, HTR_min_DT_2);

                        //MC1_in(kPa)
                        xlWorkSheet1.Cells[counter_Excel + 1, 1] = Convert.ToString(puntero_aplicacion.p_mc1_in2);
                        //MC1_out(kPa)
                        xlWorkSheet1.Cells[counter_Excel + 1, 2] = Convert.ToString(puntero_aplicacion.p_mc1_out2);
                        //MC2_out(kPa)
                        xlWorkSheet1.Cells[counter_Excel + 1, 3] = Convert.ToString(puntero_aplicacion.p_mc2_out2);
                        //P_rhx1(kPa)
                        xlWorkSheet1.Cells[counter_Excel + 1, 4] = Convert.ToString(puntero_aplicacion.p_rhx1_in2);
                        //P_rhx2(kPa)
                        xlWorkSheet1.Cells[counter_Excel + 1, 5] = Convert.ToString(puntero_aplicacion.p_rhx2_in2);
                        //P_rhx3(kPa)
                        xlWorkSheet1.Cells[counter_Excel + 1, 6] = Convert.ToString(puntero_aplicacion.p_rhx3_in2);
                        //CIT (MC1)
                        xlWorkSheet1.Cells[counter_Excel + 1, 7] = Convert.ToString(puntero_aplicacion.t_mc1_in2 - 273.15);
                        //LT UA(kW/K)
                        xlWorkSheet1.Cells[counter_Excel + 1, 8] = Convert.ToString(puntero_aplicacion.ua_lt2);
                        //HT UA(kW/K)
                        xlWorkSheet1.Cells[counter_Excel + 1, 9] = Convert.ToString(puntero_aplicacion.ua_ht2);
                        //Rec.Frac.
                        xlWorkSheet1.Cells[counter_Excel + 1, 10] = puntero_aplicacion.recomp_frac2.ToString();
                        //Eff.(%)
                        xlWorkSheet1.Cells[counter_Excel + 1, 11] = (puntero_aplicacion.eta_thermal2 * 100).ToString();
                        //LTR Eff.(%)
                        xlWorkSheet1.Cells[counter_Excel + 1, 12] = cicloRCMCI_withTwoIntercooling_withThreeRH.LT.eff.ToString();
                        //LTR Pinch(ºC)
                        xlWorkSheet1.Cells[counter_Excel + 1, 13] = LTR_min_DT_paper.ToString();
                        //HTR Eff.(%)
                        xlWorkSheet1.Cells[counter_Excel + 1, 14] = cicloRCMCI_withTwoIntercooling_withThreeRH.HT.eff.ToString();
                        //HTR Pinch(ºC)
                        xlWorkSheet1.Cells[counter_Excel + 1, 15] = HTR_min_DT_paper.ToString();

                        counter_Excel++;

                        return puntero_aplicacion.eta_thermal2;
                    };

                    solver.SetMaxObjective(funcion);

                    double? finalScore;

                    var result = solver.Optimize(initialValue, out finalScore);

                    Double max_eta_thermal = 0.0;

                    max_eta_thermal = eta_thermal2_list.Max();

                    var maxIndex = eta_thermal2_list.IndexOf(eta_thermal2_list.Max());

                    textBox86.Text = eta_thermal2_list[maxIndex].ToString();
                    textBox90.Text = recomp_frac2_list[maxIndex].ToString();
                    textBox91.Text = p_mc1_in2_list[maxIndex].ToString();
                    textBox2.Text = p_mc1_out2_list[maxIndex].ToString();
                    textBox4.Text = p_mc2_out2_list[maxIndex].ToString();
                    textBox6.Text = p_rhx1_list[maxIndex].ToString();
                    textBox5.Text = p_rhx2_list[maxIndex].ToString();
                    textBox7.Text = p_rhx3_list[maxIndex].ToString();
                    textBox82.Text = ua_LT_list[maxIndex].ToString();
                    textBox83.Text = ua_HT_list[maxIndex].ToString();

                    //Copy results as design-point inputs
                    if (checkBox3.Checked == true)
                    {
                        puntero_aplicacion.textBox15.Text = recomp_frac2_list[maxIndex].ToString();
                        puntero_aplicacion.textBox3.Text = p_mc1_in2_list[maxIndex].ToString();
                        puntero_aplicacion.textBox8.Text = p_mc1_out2_list[maxIndex].ToString();
                        puntero_aplicacion.textBox23.Text = p_mc1_out2_list[maxIndex].ToString();
                        puntero_aplicacion.textBox22.Text = p_mc2_out2_list[maxIndex].ToString();
                        puntero_aplicacion.textBox95.Text = p_mc2_out2_list[maxIndex].ToString();
                        puntero_aplicacion.textBox7.Text = p_rhx1_list[maxIndex].ToString();
                        puntero_aplicacion.textBox107.Text = p_rhx2_list[maxIndex].ToString();
                        puntero_aplicacion.textBox115.Text = p_rhx3_list[maxIndex].ToString();
                        puntero_aplicacion.textBox17.Text = ua_LT_list[maxIndex].ToString();
                        puntero_aplicacion.textBox16.Text = ua_HT_list[maxIndex].ToString();
                    }

                    //Closing Excel Book
                    xlWorkBook1.SaveAs(textBox3.Text + "RCMCI_with_Two_Intercooling_with_Three_ReHeating" + ".xls", Excel.XlFileFormat.xlWorkbookNormal, misValue1, misValue1, misValue1, misValue1, Excel.XlSaveAsAccessMode.xlExclusive, misValue1, misValue1, misValue1, misValue1, misValue1);

                    xlWorkBook1.Close(true, misValue1, misValue1);
                    xlApp1.Quit();

                    releaseObject(xlWorkSheet1);
                    //releaseObject(xlWorkSheet2);
                    releaseObject(xlWorkBook1);
                    releaseObject(xlApp1);
                }
            } //end UA optimization
        }

        //Run CIT optimizations
        private void button7_Click(object sender, EventArgs e)
        {
            int counter = 0;

            double initial_mc1_in_value = 0;
            double initial_mc1_out_value = 0;
            double initial_mc2_out_value = 0;

            int counter_Excel = 4;

            Excel.Application xlApp1;
            Excel.Workbook xlWorkBook1;
            Excel.Worksheet xlWorkSheet1;
            //Excel.Worksheet xlWorkSheet2;

            object misValue1 = System.Reflection.Missing.Value;

            xlApp1 = new Excel.Application();
            xlApp1.DisplayAlerts = false;
            xlWorkBook1 = xlApp1.Workbooks.Add(misValue1);

            xlWorkSheet1 = (Excel.Worksheet)xlWorkBook1.Worksheets.Add();

            double initial_CIP_value = 0;

            //xlWorkSheet1 = (Excel.Worksheet)xlWorkBook1.Worksheets.get_Item(xlWorkBook1.Worksheets.Count);    

            //Loop for UA optimization
            for (double j = Convert.ToDouble(textBox11.Text); j <= Convert.ToDouble(textBox10.Text); j = j + Convert.ToDouble(textBox9.Text))
            {
                puntero_aplicacion.ua_lt2 = j / 2;
                puntero_aplicacion.ua_ht2 = j / 2;

                //Loop for CIT optimization
                for (double i = Convert.ToDouble(textBox57.Text); i <= Convert.ToDouble(textBox56.Text); i = i + Convert.ToDouble(textBox55.Text))
                {
                    counter = 0;

                    //Optimize UA false
                    if (checkBox2.Checked == false)
                    {
                        //PureFluid
                        if (puntero_aplicacion.comboBox1.Text == "PureFluid")
                        {
                            puntero_aplicacion.category = RefrigerantCategory.PureFluid;
                            puntero_aplicacion.luis.core1(puntero_aplicacion.comboBox1.Text, puntero_aplicacion.category);
                        }

                        //NewMixture
                        if (puntero_aplicacion.comboBox1.Text == "NewMixture")
                        {
                            puntero_aplicacion.category = RefrigerantCategory.NewMixture;
                            puntero_aplicacion.luis.core1(puntero_aplicacion.comboBox2.Text + "=" + puntero_aplicacion.textBox35.Text + "," + puntero_aplicacion.comboBox16.Text + "=" + puntero_aplicacion.textBox36.Text, puntero_aplicacion.category);
                        }

                        if (puntero_aplicacion.comboBox1.Text == "PredefinedMixture")
                        {
                            puntero_aplicacion.category = RefrigerantCategory.PredefinedMixture;
                        }

                        if (puntero_aplicacion.comboBox1.Text == "PseudoPureFluid")
                        {
                            puntero_aplicacion.category = RefrigerantCategory.PseudoPureFluid;
                        }

                        if (puntero_aplicacion.comboBox3.Text == "DEF")
                        {
                            puntero_aplicacion.referencestate = ReferenceState.DEF;
                        }
                        if (puntero_aplicacion.comboBox3.Text == "ASH")
                        {
                            puntero_aplicacion.referencestate = ReferenceState.ASH;
                        }
                        if (puntero_aplicacion.comboBox3.Text == "IIR")
                        {
                            puntero_aplicacion.referencestate = ReferenceState.IIR;
                        }
                        if (puntero_aplicacion.comboBox3.Text == "NBP")
                        {
                            puntero_aplicacion.referencestate = ReferenceState.NBP;
                        }

                        puntero_aplicacion.luis.working_fluid.Category = puntero_aplicacion.category;
                        puntero_aplicacion.luis.working_fluid.reference = puntero_aplicacion.referencestate;

                        puntero_aplicacion.luis.wmm = puntero_aplicacion.luis.working_fluid.MolecularWeight;

                        //Store Input Data from Graphical User Interface GUI into variables
                        puntero_aplicacion.w_dot_net2 = Convert.ToDouble(puntero_aplicacion.textBox1.Text);
                        puntero_aplicacion.t_mc1_in2 = Convert.ToDouble(puntero_aplicacion.textBox2.Text);
                        puntero_aplicacion.t_mc2_in2 = Convert.ToDouble(puntero_aplicacion.textBox28.Text);
                        puntero_aplicacion.t_mc3_in2 = Convert.ToDouble(puntero_aplicacion.textBox93.Text);
                        puntero_aplicacion.t_t_in2 = Convert.ToDouble(puntero_aplicacion.textBox4.Text);
                        puntero_aplicacion.p_mc1_in2 = Convert.ToDouble(puntero_aplicacion.textBox3.Text);
                        puntero_aplicacion.p_mc1_out2 = Convert.ToDouble(puntero_aplicacion.textBox8.Text);
                        puntero_aplicacion.p_mc2_in2 = Convert.ToDouble(puntero_aplicacion.textBox23.Text);
                        puntero_aplicacion.p_mc2_out2 = Convert.ToDouble(puntero_aplicacion.textBox22.Text);
                        puntero_aplicacion.p_mc3_in2 = Convert.ToDouble(puntero_aplicacion.textBox95.Text);
                        puntero_aplicacion.p_mc3_out2 = Convert.ToDouble(puntero_aplicacion.textBox94.Text);
                        puntero_aplicacion.p_rhx1_in2 = Convert.ToDouble(puntero_aplicacion.textBox7.Text);
                        puntero_aplicacion.t_rht1_in2 = Convert.ToDouble(puntero_aplicacion.textBox6.Text);
                        puntero_aplicacion.p_rhx2_in2 = Convert.ToDouble(puntero_aplicacion.textBox107.Text);
                        puntero_aplicacion.t_rht2_in2 = Convert.ToDouble(puntero_aplicacion.textBox106.Text);
                        puntero_aplicacion.p_rhx3_in2 = Convert.ToDouble(puntero_aplicacion.textBox115.Text);
                        puntero_aplicacion.t_rht3_in2 = Convert.ToDouble(puntero_aplicacion.textBox114.Text);
                        //puntero_aplicacion.ua_lt2 = Convert.ToDouble(puntero_aplicacion.textBox17.Text);
                        //puntero_aplicacion.ua_ht2 = Convert.ToDouble(puntero_aplicacion.textBox16.Text);
                        puntero_aplicacion.recomp_frac2 = Convert.ToDouble(puntero_aplicacion.textBox15.Text);
                        puntero_aplicacion.eta1_mc2 = Convert.ToDouble(puntero_aplicacion.textBox14.Text);
                        puntero_aplicacion.eta2_mc2 = Convert.ToDouble(puntero_aplicacion.textBox27.Text);
                        puntero_aplicacion.eta3_mc2 = Convert.ToDouble(puntero_aplicacion.textBox92.Text);
                        puntero_aplicacion.eta_rc2 = Convert.ToDouble(puntero_aplicacion.textBox13.Text);
                        puntero_aplicacion.eta_t2 = Convert.ToDouble(puntero_aplicacion.textBox19.Text);
                        puntero_aplicacion.eta_trh1 = Convert.ToDouble(puntero_aplicacion.textBox18.Text);
                        puntero_aplicacion.eta_trh2 = Convert.ToDouble(puntero_aplicacion.textBox108.Text);
                        puntero_aplicacion.eta_trh3 = Convert.ToDouble(puntero_aplicacion.textBox113.Text);
                        puntero_aplicacion.n_sub_hxrs2 = Convert.ToInt64(puntero_aplicacion.textBox20.Text);
                        puntero_aplicacion.tol2 = Convert.ToDouble(puntero_aplicacion.textBox21.Text);
                        puntero_aplicacion.dp2_lt1 = Convert.ToDouble(puntero_aplicacion.textBox5.Text);
                        puntero_aplicacion.dp2_ht1 = Convert.ToDouble(puntero_aplicacion.textBox12.Text);
                        puntero_aplicacion.dp1_pc1 = Convert.ToDouble(puntero_aplicacion.textBox11.Text);
                        puntero_aplicacion.dp2_pc1 = Convert.ToDouble(puntero_aplicacion.textBox24.Text);
                        puntero_aplicacion.dp3_pc1 = Convert.ToDouble(puntero_aplicacion.textBox96.Text);
                        puntero_aplicacion.dp2_phx1 = Convert.ToDouble(puntero_aplicacion.textBox10.Text);
                        puntero_aplicacion.dp2_rhx12 = Convert.ToDouble(puntero_aplicacion.textBox9.Text);
                        puntero_aplicacion.dp2_rhx22 = Convert.ToDouble(puntero_aplicacion.textBox105.Text);
                        puntero_aplicacion.dp2_rhx32 = Convert.ToDouble(puntero_aplicacion.textBox116.Text);
                        puntero_aplicacion.dp2_lt2 = Convert.ToDouble(puntero_aplicacion.textBox26.Text);
                        puntero_aplicacion.dp2_ht2 = Convert.ToDouble(puntero_aplicacion.textBox25.Text);

                        core.RCMCIwithTwoIntercoolingwithThreeReheating cicloRCMCI_withTwoIntercooling_withThreeRH = new core.RCMCIwithTwoIntercoolingwithThreeReheating();

                        double UA_Total = puntero_aplicacion.ua_lt2 + puntero_aplicacion.ua_ht2;

                        double LT_fraction = 0.1;

                        List<Double> recomp_frac2_list = new List<Double>();
                        List<Double> p_mc1_in2_list = new List<Double>();
                        List<Double> p_mc1_out2_list = new List<Double>();
                        List<Double> p_mc2_out2_list = new List<Double>();
                        List<Double> p_rhx1_list = new List<Double>();
                        List<Double> p_rhx2_list = new List<Double>();
                        List<Double> p_rhx3_list = new List<Double>();
                        List<Double> eta_thermal2_list = new List<Double>();
                        List<Double> ua_LT_list = new List<Double>();
                        List<Double> ua_HT_list = new List<Double>();

                        List<Double> t1_list = new List<Double>();
                        List<Double> t2_list = new List<Double>();
                        List<Double> t3_list = new List<Double>();
                        List<Double> t4_list = new List<Double>();
                        List<Double> t5_list = new List<Double>();
                        List<Double> t6_list = new List<Double>();
                        List<Double> t7_list = new List<Double>();
                        List<Double> t8_list = new List<Double>();
                        List<Double> t9_list = new List<Double>();
                        List<Double> t10_list = new List<Double>();
                        List<Double> t13_list = new List<Double>();
                        List<Double> t14_list = new List<Double>();
                        List<Double> t15_list = new List<Double>();
                        List<Double> t16_list = new List<Double>();
                        List<Double> t17_list = new List<Double>();
                        List<Double> t18_list = new List<Double>();
                        List<Double> t19_list = new List<Double>();
                        List<Double> t20_list = new List<Double>();

                        List<Double> p1_list = new List<Double>();
                        List<Double> p2_list = new List<Double>();
                        List<Double> p3_list = new List<Double>();
                        List<Double> p4_list = new List<Double>();
                        List<Double> p5_list = new List<Double>();
                        List<Double> p6_list = new List<Double>();
                        List<Double> p7_list = new List<Double>();
                        List<Double> p8_list = new List<Double>();
                        List<Double> p9_list = new List<Double>();
                        List<Double> p10_list = new List<Double>();
                        List<Double> p13_list = new List<Double>();
                        List<Double> p14_list = new List<Double>();
                        List<Double> p15_list = new List<Double>();
                        List<Double> p16_list = new List<Double>();
                        List<Double> p17_list = new List<Double>();
                        List<Double> p18_list = new List<Double>();
                        List<Double> p19_list = new List<Double>();
                        List<Double> p20_list = new List<Double>();

                        List<Double> HT_Eff_list = new List<Double>();
                        List<Double> LT_Eff_list = new List<Double>();

                        NLoptAlgorithm algorithm_type = NLoptAlgorithm.LN_BOBYQA;

                        if (comboBox19.Text == "BOBYQA")
                            algorithm_type = NLoptAlgorithm.LN_BOBYQA;
                        else if (comboBox19.Text == "COBYLA")
                            algorithm_type = NLoptAlgorithm.LN_COBYLA;
                        else if (comboBox19.Text == "SUBPLEX")
                            algorithm_type = NLoptAlgorithm.LN_SBPLX;
                        else if (comboBox19.Text == "NELDER-MEAD")
                            algorithm_type = NLoptAlgorithm.LN_NELDERMEAD;
                        else if (comboBox19.Text == "NEWUOA")
                            algorithm_type = NLoptAlgorithm.LN_NEWUOA;
                        else if (comboBox19.Text == "PRAXIS")
                            algorithm_type = NLoptAlgorithm.LN_PRAXIS;

                        if (i == Convert.ToDouble(textBox57.Text))
                        {
                            if (checkBox6.Checked == true)
                            {
                                initial_CIP_value = Convert.ToDouble(textBox1.Text);
                            }
                            else
                            {
                                initial_CIP_value = puntero_aplicacion.MixtureCriticalPressure;
                            }

                            xlWorkSheet1.Name = puntero_aplicacion.comboBox2.Text + " Mixture";

                            //puntero_aplicacion.comboBox2.Text + "=" + puntero_aplicacion.textBox68.Text + "," + puntero_aplicacion.comboBox6.Text + "=" + puntero_aplicacion.textBox69.Text + "," + puntero_aplicacion.comboBox12.Text + "=" + puntero_aplicacion.textBox33.Text + "," + puntero_aplicacion.comboBox7.Text + "=" + puntero_aplicacion.textBox34.Text
                            xlWorkSheet1.Cells[1, 1] = puntero_aplicacion.comboBox2.Text + ":" + puntero_aplicacion.textBox33.Text + "," + puntero_aplicacion.comboBox6.Text + ":" + puntero_aplicacion.textBox34.Text + "," + puntero_aplicacion.comboBox12.Text + ":" + puntero_aplicacion.textBox68.Text + "," + puntero_aplicacion.comboBox7.Text + ":" + puntero_aplicacion.textBox69.Text;
                            xlWorkSheet1.Cells[1, 2] = "Pcrit(kPa)";
                            xlWorkSheet1.Cells[1, 3] = "Tcrit(ºC)";

                            xlWorkSheet1.Cells[2, 1] = "";
                            xlWorkSheet1.Cells[2, 2] = Convert.ToString(puntero_aplicacion.MixtureCriticalPressure);
                            xlWorkSheet1.Cells[2, 3] = Convert.ToString(puntero_aplicacion.MixtureCriticalTemperature - 273.15);

                            xlWorkSheet1.Cells[3, 1] = "";
                            xlWorkSheet1.Cells[3, 2] = "";
                            xlWorkSheet1.Cells[4, 3] = "";

                            xlWorkSheet1.Cells[4, 1] = "MC1_in(kPa)";
                            xlWorkSheet1.Cells[4, 2] = "MC1_out(kPa)";
                            xlWorkSheet1.Cells[4, 3] = "MC2_out(kPa)";
                            xlWorkSheet1.Cells[4, 4] = "P_rhx1(kPa)";
                            xlWorkSheet1.Cells[4, 5] = "P_rhx2(kPa)";
                            xlWorkSheet1.Cells[4, 6] = "P_rhx3(kPa)";
                            xlWorkSheet1.Cells[4, 7] = "CIT(K)";
                            xlWorkSheet1.Cells[4, 8] = "LT UA(kW/K)";
                            xlWorkSheet1.Cells[4, 9] = "HT UA(kW/K)";
                            xlWorkSheet1.Cells[4, 10] = "Rec.Frac.";
                            xlWorkSheet1.Cells[4, 11] = "Eff.(%)";
                            xlWorkSheet1.Cells[4, 12] = "LTR Eff.(%)";
                            xlWorkSheet1.Cells[4, 13] = "LTR Pinch(ºC)";
                            xlWorkSheet1.Cells[4, 14] = "HTR Eff.(%)";
                            xlWorkSheet1.Cells[4, 15] = "HTR Pinch(ºC)";
                            xlWorkSheet1.Cells[4, 16] = "PTC_Apperture_Area(m2)";
                            xlWorkSheet1.Cells[4, 17] = "PTC_Pressure_Drop(bar)";
                            xlWorkSheet1.Cells[4, 18] = "LF_Apperture_Area(m2)";
                            xlWorkSheet1.Cells[4, 19] = "LF_Pressure_Drop(bar)";
                            xlWorkSheet1.Cells[4, 20] = "PTC1_Apperture_Area(m2)";
                            xlWorkSheet1.Cells[4, 21] = "PTC1_Pressure_Drop(bar)";
                            xlWorkSheet1.Cells[4, 22] = "LF1_Apperture_Area(m2)";
                            xlWorkSheet1.Cells[4, 23] = "LF1_Pressure_Drop(bar)";
                            xlWorkSheet1.Cells[4, 24] = "PTC2_Apperture_Area(m2)";
                            xlWorkSheet1.Cells[4, 25] = "PTC2_Pressure_Drop(bar)";
                            xlWorkSheet1.Cells[4, 26] = "LF2_Apperture_Area(m2)";
                            xlWorkSheet1.Cells[4, 27] = "LF2_Pressure_Drop(bar)";
                            xlWorkSheet1.Cells[4, 28] = "PTC3_Apperture_Area(m2)";
                            xlWorkSheet1.Cells[4, 29] = "PTC3_Pressure_Drop(bar)";
                            xlWorkSheet1.Cells[4, 30] = "LF3_Apperture_Area(m2)";
                            xlWorkSheet1.Cells[4, 31] = "LF3_Pressure_Drop(bar)";
                        }

                        using (var solver = new NLoptSolver(algorithm_type, 7, 0.000001, 10000))
                        {
                            solver.SetLowerBounds(new[] { 0.0, initial_CIP_value, initial_CIP_value,
                            initial_CIP_value, initial_CIP_value, initial_CIP_value , initial_CIP_value});

                            solver.SetUpperBounds(new[] { 1.0, (puntero_aplicacion.p_mc3_out2 / 1.1),
                            (puntero_aplicacion.p_mc3_out2 / 1.1), (puntero_aplicacion.p_mc3_out2 / 1.1),
                            puntero_aplicacion.p_mc3_out2, puntero_aplicacion.p_mc3_out2 ,
                            puntero_aplicacion.p_mc3_out2});

                            solver.SetInitialStepSize(new[] { 0.05, 250.0, 250.0, 250.0, 1000.0, 1000.0, 1000.0 });

                            var initialValue = new[] { 0.2, initial_CIP_value + 1500.0, initial_CIP_value + 2000.0,
                            initial_CIP_value + 3000.0, initial_CIP_value + 6000.0, initial_CIP_value + 5000.0,
                            initial_CIP_value + 4000.0 };

                            Func<double[], double> funcion = delegate (double[] variables)
                            {
                                puntero_aplicacion.luis.RecompCycle_RCMCI_with_Two_Intercooling_with_ThreeReheating(puntero_aplicacion.luis,
                                ref cicloRCMCI_withTwoIntercooling_withThreeRH, puntero_aplicacion.w_dot_net2,
                                i, puntero_aplicacion.t_t_in2, puntero_aplicacion.t_rht1_in2,
                                variables[4], puntero_aplicacion.t_rht2_in2, variables[5], puntero_aplicacion.t_rht3_in2, 
                                variables[6], variables[2], variables[3], variables[1], i, variables[2], variables[3], i,
                                puntero_aplicacion.p_mc3_out2, puntero_aplicacion.ua_lt2, puntero_aplicacion.ua_ht2,
                                puntero_aplicacion.eta2_mc2, puntero_aplicacion.eta_rc2, puntero_aplicacion.eta1_mc2,
                                puntero_aplicacion.eta3_mc2, puntero_aplicacion.eta_t2, puntero_aplicacion.eta_trh1,
                                puntero_aplicacion.eta_trh2, puntero_aplicacion.eta_trh3, puntero_aplicacion.n_sub_hxrs2,
                                variables[0], puntero_aplicacion.tol2, puntero_aplicacion.eta_thermal2,
                                -puntero_aplicacion.dp2_lt1, -puntero_aplicacion.dp2_lt2, -puntero_aplicacion.dp2_ht1,
                                -puntero_aplicacion.dp2_ht2, -puntero_aplicacion.dp1_pc1, -puntero_aplicacion.dp1_pc2,
                                -puntero_aplicacion.dp2_phx1, -puntero_aplicacion.dp2_phx2, -puntero_aplicacion.dp2_rhx11,
                                -puntero_aplicacion.dp2_rhx12, -puntero_aplicacion.dp2_rhx21, -puntero_aplicacion.dp2_rhx22,
                                -puntero_aplicacion.dp2_rhx31, -puntero_aplicacion.dp2_rhx32, -puntero_aplicacion.dp2_pc1,
                                -puntero_aplicacion.dp2_pc2, -puntero_aplicacion.dp3_pc1, -puntero_aplicacion.dp3_pc2);

                                counter++;

                                puntero_aplicacion.massflow2 = cicloRCMCI_withTwoIntercooling_withThreeRH.m_dot_turbine;
                                puntero_aplicacion.w_dot_net2 = cicloRCMCI_withTwoIntercooling_withThreeRH.W_dot_net;

                                puntero_aplicacion.eta_thermal2 = cicloRCMCI_withTwoIntercooling_withThreeRH.eta_thermal;
                                puntero_aplicacion.recomp_frac2 = variables[0];
                                puntero_aplicacion.p_mc1_in2 = variables[1];
                                puntero_aplicacion.p_mc1_out2 = variables[2];
                                puntero_aplicacion.p_mc2_in2 = variables[2];
                                puntero_aplicacion.p_mc2_out2 = variables[3];
                                puntero_aplicacion.p_mc3_in2 = variables[3];
                                puntero_aplicacion.p_rhx1_in2 = variables[4];
                                puntero_aplicacion.p_rhx2_in2 = variables[5];
                                puntero_aplicacion.p_rhx3_in2 = variables[6];

                                puntero_aplicacion.temp21 = cicloRCMCI_withTwoIntercooling_withThreeRH.temp[0];
                                puntero_aplicacion.temp22 = cicloRCMCI_withTwoIntercooling_withThreeRH.temp[1];
                                puntero_aplicacion.temp23 = cicloRCMCI_withTwoIntercooling_withThreeRH.temp[2];
                                puntero_aplicacion.temp24 = cicloRCMCI_withTwoIntercooling_withThreeRH.temp[3];
                                puntero_aplicacion.temp25 = cicloRCMCI_withTwoIntercooling_withThreeRH.temp[4];
                                puntero_aplicacion.temp26 = cicloRCMCI_withTwoIntercooling_withThreeRH.temp[5];
                                puntero_aplicacion.temp27 = cicloRCMCI_withTwoIntercooling_withThreeRH.temp[6];
                                puntero_aplicacion.temp28 = cicloRCMCI_withTwoIntercooling_withThreeRH.temp[7];
                                puntero_aplicacion.temp29 = cicloRCMCI_withTwoIntercooling_withThreeRH.temp[8];
                                puntero_aplicacion.temp210 = cicloRCMCI_withTwoIntercooling_withThreeRH.temp[9];
                                puntero_aplicacion.temp211 = cicloRCMCI_withTwoIntercooling_withThreeRH.temp[10];
                                puntero_aplicacion.temp212 = cicloRCMCI_withTwoIntercooling_withThreeRH.temp[11];
                                puntero_aplicacion.temp213 = cicloRCMCI_withTwoIntercooling_withThreeRH.temp[12];
                                puntero_aplicacion.temp214 = cicloRCMCI_withTwoIntercooling_withThreeRH.temp[13];
                                puntero_aplicacion.temp215 = cicloRCMCI_withTwoIntercooling_withThreeRH.temp[14];
                                puntero_aplicacion.temp216 = cicloRCMCI_withTwoIntercooling_withThreeRH.temp[15];
                                puntero_aplicacion.temp217 = cicloRCMCI_withTwoIntercooling_withThreeRH.temp[16];
                                puntero_aplicacion.temp218 = cicloRCMCI_withTwoIntercooling_withThreeRH.temp[17];
                                puntero_aplicacion.temp219 = cicloRCMCI_withTwoIntercooling_withThreeRH.temp[18];
                                puntero_aplicacion.temp220 = cicloRCMCI_withTwoIntercooling_withThreeRH.temp[19];

                                puntero_aplicacion.pres21 = cicloRCMCI_withTwoIntercooling_withThreeRH.pres[0];
                                puntero_aplicacion.pres22 = cicloRCMCI_withTwoIntercooling_withThreeRH.pres[1];
                                puntero_aplicacion.pres23 = cicloRCMCI_withTwoIntercooling_withThreeRH.pres[2];
                                puntero_aplicacion.pres24 = cicloRCMCI_withTwoIntercooling_withThreeRH.pres[3];
                                puntero_aplicacion.pres25 = cicloRCMCI_withTwoIntercooling_withThreeRH.pres[4];
                                puntero_aplicacion.pres26 = cicloRCMCI_withTwoIntercooling_withThreeRH.pres[5];
                                puntero_aplicacion.pres27 = cicloRCMCI_withTwoIntercooling_withThreeRH.pres[6];
                                puntero_aplicacion.pres28 = cicloRCMCI_withTwoIntercooling_withThreeRH.pres[7];
                                puntero_aplicacion.pres29 = cicloRCMCI_withTwoIntercooling_withThreeRH.pres[8];
                                puntero_aplicacion.pres210 = cicloRCMCI_withTwoIntercooling_withThreeRH.pres[9];
                                puntero_aplicacion.pres211 = cicloRCMCI_withTwoIntercooling_withThreeRH.pres[10];
                                puntero_aplicacion.pres212 = cicloRCMCI_withTwoIntercooling_withThreeRH.pres[11];
                                puntero_aplicacion.pres213 = cicloRCMCI_withTwoIntercooling_withThreeRH.pres[12];
                                puntero_aplicacion.pres214 = cicloRCMCI_withTwoIntercooling_withThreeRH.pres[13];
                                puntero_aplicacion.pres215 = cicloRCMCI_withTwoIntercooling_withThreeRH.pres[14];
                                puntero_aplicacion.pres216 = cicloRCMCI_withTwoIntercooling_withThreeRH.pres[15];
                                puntero_aplicacion.pres217 = cicloRCMCI_withTwoIntercooling_withThreeRH.pres[16];
                                puntero_aplicacion.pres218 = cicloRCMCI_withTwoIntercooling_withThreeRH.pres[17];
                                puntero_aplicacion.pres219 = cicloRCMCI_withTwoIntercooling_withThreeRH.pres[18];
                                puntero_aplicacion.pres220 = cicloRCMCI_withTwoIntercooling_withThreeRH.pres[19];

                                puntero_aplicacion.PHX1 = cicloRCMCI_withTwoIntercooling_withThreeRH.PHX.Q_dot;
                                puntero_aplicacion.RHX1 = cicloRCMCI_withTwoIntercooling_withThreeRH.RHX1.Q_dot;
                                puntero_aplicacion.RHX2 = cicloRCMCI_withTwoIntercooling_withThreeRH.RHX2.Q_dot;
                                puntero_aplicacion.RHX3 = cicloRCMCI_withTwoIntercooling_withThreeRH.RHX3.Q_dot;

                                puntero_aplicacion.LT_Q = cicloRCMCI_withTwoIntercooling_withThreeRH.LT.Q_dot;
                                puntero_aplicacion.LT_mdotc = cicloRCMCI_withTwoIntercooling_withThreeRH.LT.m_dot_design[0];
                                puntero_aplicacion.LT_mdoth = cicloRCMCI_withTwoIntercooling_withThreeRH.LT.m_dot_design[1];
                                puntero_aplicacion.LT_Tcin = cicloRCMCI_withTwoIntercooling_withThreeRH.LT.T_c_in;
                                puntero_aplicacion.LT_Thin = cicloRCMCI_withTwoIntercooling_withThreeRH.LT.T_h_in;
                                puntero_aplicacion.LT_Pcin = cicloRCMCI_withTwoIntercooling_withThreeRH.LT.P_c_in;
                                puntero_aplicacion.LT_Phin = cicloRCMCI_withTwoIntercooling_withThreeRH.LT.P_h_in;
                                puntero_aplicacion.LT_Pcout = cicloRCMCI_withTwoIntercooling_withThreeRH.LT.P_c_out;
                                puntero_aplicacion.LT_Phout = cicloRCMCI_withTwoIntercooling_withThreeRH.LT.P_h_out;
                                puntero_aplicacion.LT_Effc = cicloRCMCI_withTwoIntercooling_withThreeRH.LT.eff;

                                puntero_aplicacion.HT_Q = cicloRCMCI_withTwoIntercooling_withThreeRH.HT.Q_dot;
                                puntero_aplicacion.HT_mdotc = cicloRCMCI_withTwoIntercooling_withThreeRH.HT.m_dot_design[0];
                                puntero_aplicacion.HT_mdoth = cicloRCMCI_withTwoIntercooling_withThreeRH.HT.m_dot_design[1];
                                puntero_aplicacion.HT_Tcin = cicloRCMCI_withTwoIntercooling_withThreeRH.HT.T_c_in;
                                puntero_aplicacion.HT_Thin = cicloRCMCI_withTwoIntercooling_withThreeRH.HT.T_h_in;
                                puntero_aplicacion.HT_Pcin = cicloRCMCI_withTwoIntercooling_withThreeRH.HT.P_c_in;
                                puntero_aplicacion.HT_Phin = cicloRCMCI_withTwoIntercooling_withThreeRH.HT.P_h_in;
                                puntero_aplicacion.HT_Pcout = cicloRCMCI_withTwoIntercooling_withThreeRH.HT.P_c_out;
                                puntero_aplicacion.HT_Phout = cicloRCMCI_withTwoIntercooling_withThreeRH.HT.P_h_out;
                                puntero_aplicacion.HT_Effc = cicloRCMCI_withTwoIntercooling_withThreeRH.HT.eff;

                                puntero_aplicacion.PC1 = -cicloRCMCI_withTwoIntercooling_withThreeRH.PC1.Q_dot;
                                puntero_aplicacion.PC2 = -cicloRCMCI_withTwoIntercooling_withThreeRH.PC2.Q_dot;
                                puntero_aplicacion.PC3 = -cicloRCMCI_withTwoIntercooling_withThreeRH.COOLER.Q_dot;

                                eta_thermal2_list.Add(puntero_aplicacion.eta_thermal2);
                                recomp_frac2_list.Add(puntero_aplicacion.recomp_frac2);
                                p_mc1_in2_list.Add(puntero_aplicacion.p_mc1_in2);
                                p_mc1_out2_list.Add(puntero_aplicacion.p_mc1_out2);
                                p_mc2_out2_list.Add(puntero_aplicacion.p_mc2_out2);
                                p_rhx1_list.Add(puntero_aplicacion.p_rhx1_in2);
                                p_rhx2_list.Add(puntero_aplicacion.p_rhx2_in2);
                                p_rhx3_list.Add(puntero_aplicacion.p_rhx3_in2);
                                ua_LT_list.Add(puntero_aplicacion.ua_lt2);
                                ua_HT_list.Add(puntero_aplicacion.ua_ht2);

                                HT_Eff_list.Add(cicloRCMCI_withTwoIntercooling_withThreeRH.HT.eff);
                                LT_Eff_list.Add(cicloRCMCI_withTwoIntercooling_withThreeRH.LT.eff);

                                t1_list.Add(puntero_aplicacion.temp21);
                                t2_list.Add(puntero_aplicacion.temp22);
                                t3_list.Add(puntero_aplicacion.temp23);
                                t4_list.Add(puntero_aplicacion.temp24);
                                t5_list.Add(puntero_aplicacion.temp25);
                                t6_list.Add(puntero_aplicacion.temp26);
                                t7_list.Add(puntero_aplicacion.temp27);
                                t8_list.Add(puntero_aplicacion.temp28);
                                t9_list.Add(puntero_aplicacion.temp29);
                                t10_list.Add(puntero_aplicacion.temp210);
                                t13_list.Add(puntero_aplicacion.temp213);
                                t14_list.Add(puntero_aplicacion.temp214);
                                t15_list.Add(puntero_aplicacion.temp215);
                                t16_list.Add(puntero_aplicacion.temp216);
                                t17_list.Add(puntero_aplicacion.temp217);
                                t18_list.Add(puntero_aplicacion.temp218);
                                t19_list.Add(puntero_aplicacion.temp219);
                                t20_list.Add(puntero_aplicacion.temp220);

                                p1_list.Add(puntero_aplicacion.pres21);
                                p2_list.Add(puntero_aplicacion.pres22);
                                p3_list.Add(puntero_aplicacion.pres23);
                                p4_list.Add(puntero_aplicacion.pres24);
                                p5_list.Add(puntero_aplicacion.pres25);
                                p6_list.Add(puntero_aplicacion.pres26);
                                p7_list.Add(puntero_aplicacion.pres27);
                                p8_list.Add(puntero_aplicacion.pres28);
                                p9_list.Add(puntero_aplicacion.pres29);
                                p10_list.Add(puntero_aplicacion.pres210);
                                p13_list.Add(puntero_aplicacion.pres213);
                                p14_list.Add(puntero_aplicacion.pres214);
                                p15_list.Add(puntero_aplicacion.pres215);
                                p16_list.Add(puntero_aplicacion.pres216);
                                p17_list.Add(puntero_aplicacion.pres217);
                                p18_list.Add(puntero_aplicacion.pres218);
                                p19_list.Add(puntero_aplicacion.pres219);
                                p20_list.Add(puntero_aplicacion.pres220);
                               
                                listBox1.Items.Add(counter.ToString());
                                listBox2.Items.Add(puntero_aplicacion.eta_thermal2.ToString());
                                listBox3.Items.Add(puntero_aplicacion.recomp_frac2.ToString());
                                listBox4.Items.Add(puntero_aplicacion.p_mc1_in2.ToString());
                                listBox7.Items.Add(puntero_aplicacion.p_mc1_out2.ToString());
                                listBox24.Items.Add(puntero_aplicacion.p_mc2_in2.ToString());
                                listBox23.Items.Add(puntero_aplicacion.p_mc2_out2.ToString());
                                listBox19.Items.Add(puntero_aplicacion.p_rhx1_in2.ToString());
                                listBox21.Items.Add(puntero_aplicacion.p_rhx2_in2.ToString());
                                listBox27.Items.Add(puntero_aplicacion.p_rhx3_in2.ToString());
                                listBox5.Items.Add(puntero_aplicacion.ua_lt2.ToString());
                                listBox6.Items.Add(puntero_aplicacion.ua_ht2.ToString());
                                listBox8.Items.Add(puntero_aplicacion.temp27.ToString());
                                listBox9.Items.Add(puntero_aplicacion.temp28.ToString());

                                return puntero_aplicacion.eta_thermal2;
                            };

                            solver.SetMaxObjective(funcion);

                            double? finalScore;

                            var result = solver.Optimize(initialValue, out finalScore);

                            Double max_eta_thermal = 0.0;

                            max_eta_thermal = eta_thermal2_list.Max();

                            var maxIndex = eta_thermal2_list.IndexOf(eta_thermal2_list.Max());

                            textBox86.Text = eta_thermal2_list[maxIndex].ToString();
                            textBox90.Text = recomp_frac2_list[maxIndex].ToString();
                            textBox91.Text = p_mc1_in2_list[maxIndex].ToString();
                            textBox2.Text = p_mc1_out2_list[maxIndex].ToString();
                            textBox4.Text = p_mc2_out2_list[maxIndex].ToString();
                            textBox6.Text = p_rhx1_list[maxIndex].ToString();
                            textBox5.Text = p_rhx2_list[maxIndex].ToString();
                            textBox7.Text = p_rhx3_list[maxIndex].ToString();
                            textBox82.Text = ua_LT_list[maxIndex].ToString();
                            textBox83.Text = ua_HT_list[maxIndex].ToString();

                            //Copy results as design-point inputs
                            if (checkBox3.Checked == true)
                            {
                                puntero_aplicacion.textBox15.Text = recomp_frac2_list[maxIndex].ToString();
                                puntero_aplicacion.textBox3.Text = p_mc1_in2_list[maxIndex].ToString();
                                puntero_aplicacion.textBox8.Text = p_mc1_out2_list[maxIndex].ToString();
                                puntero_aplicacion.textBox23.Text = p_mc1_out2_list[maxIndex].ToString();
                                puntero_aplicacion.textBox22.Text = p_mc2_out2_list[maxIndex].ToString();
                                puntero_aplicacion.textBox95.Text = p_mc2_out2_list[maxIndex].ToString();
                                puntero_aplicacion.textBox7.Text = p_rhx1_list[maxIndex].ToString();
                                puntero_aplicacion.textBox107.Text = p_rhx2_list[maxIndex].ToString();
                                puntero_aplicacion.textBox115.Text = p_rhx3_list[maxIndex].ToString();
                                puntero_aplicacion.textBox17.Text = ua_LT_list[maxIndex].ToString();
                                puntero_aplicacion.textBox16.Text = ua_HT_list[maxIndex].ToString();
                                puntero_aplicacion.textBox2.Text = i.ToString();
                                puntero_aplicacion.textBox28.Text = i.ToString();
                                puntero_aplicacion.textBox93.Text = i.ToString();
                            }

                            //The variable 'i' is the loop counter for the CIT
                            listBox18.Items.Add(i.ToString());
                            listBox17.Items.Add(eta_thermal2_list[maxIndex].ToString());
                            listBox16.Items.Add(recomp_frac2_list[maxIndex].ToString());
                            listBox15.Items.Add(p_mc1_in2_list[maxIndex].ToString());
                            listBox10.Items.Add(p_mc1_out2_list[maxIndex].ToString());
                            listBox26.Items.Add(p_mc1_out2_list[maxIndex].ToString());
                            listBox25.Items.Add(p_mc2_out2_list[maxIndex].ToString());
                            listBox20.Items.Add(p_rhx1_list[maxIndex].ToString());
                            listBox22.Items.Add(p_rhx2_list[maxIndex].ToString());
                            listBox28.Items.Add(p_rhx3_list[maxIndex].ToString());
                            listBox14.Items.Add(ua_LT_list[maxIndex].ToString());
                            listBox13.Items.Add(ua_HT_list[maxIndex].ToString());
                            listBox11.Items.Add(t8_list[maxIndex].ToString());
                            listBox12.Items.Add(t9_list[maxIndex].ToString());

                            //MAIN SOLAR FIELD CALCULATION
                            PTC_SF_Calculation PTC = new PTC_SF_Calculation();
                            PTC.calledForSensingAnalysis = true;
                            PTC.comboBox1.Text = "Solar Salt";
                            PTC.comboBox2.Text = "PureFluid";
                            PTC.comboBox13.Text = puntero_aplicacion.comboBox2.Text;
                            PTC.comboBox14.Text = puntero_aplicacion.comboBox6.Text;
                            //PTC.textBox31.Text = this.textBox31.Text;
                            //PTC.textBox36.Text = this.textBox36.Text;

                            if (comboBox4.Text == "Parabolic")
                            {
                                PTC.textBox7.Text = "0.141";
                                PTC.textBox8.Text = "6.48e-9";
                            }
                            else if (comboBox4.Text == "Parabolic with cavity receiver (Norwich)")
                            {
                                PTC.textBox7.Text = "0.3";
                                PTC.textBox8.Text = "3.25e-9";
                            }

                            PTC.textBox1.Text = Convert.ToString(puntero_aplicacion.PHX1);
                            PTC.textBox2.Text = Convert.ToString(puntero_aplicacion.massflow2);
                            PTC.textBox3.Text = Convert.ToString(puntero_aplicacion.temp25);
                            PTC.textBox6.Text = Convert.ToString(puntero_aplicacion.temp26);
                            PTC.textBox4.Text = Convert.ToString(puntero_aplicacion.pres25);
                            PTC.textBox5.Text = Convert.ToString(puntero_aplicacion.pres26);
                            PTC.textBox107.Text = Convert.ToString(10);
                            PTC.button1_Click(this, e);
                            puntero_aplicacion.PTC_Main_SF_Effective_Apperture_Area = PTC.ReflectorApertureAreaResult;
                            puntero_aplicacion.PTC_Main_SF_Pressure_drop = PTC.Total_Pressure_DropResult;

                            //MAIN SOLAR FIELD CALCULATION
                            LF_SF_Calculation LF = new LF_SF_Calculation();
                            LF.calledForSensingAnalysis = true;
                            LF.comboBox1.Text = "Solar Salt";
                            LF.comboBox2.Text = "PureFluid";
                            LF.comboBox13.Text = puntero_aplicacion.comboBox2.Text;
                            LF.comboBox14.Text = puntero_aplicacion.comboBox6.Text;
                            //LF.textBox31.Text = this.textBox31.Text;
                            //LF.textBox36.Text = this.textBox36.Text;
                            LF.textBox1.Text = Convert.ToString(puntero_aplicacion.PHX1);
                            LF.textBox2.Text = Convert.ToString(puntero_aplicacion.massflow2);
                            LF.textBox3.Text = Convert.ToString(puntero_aplicacion.temp25);
                            LF.textBox6.Text = Convert.ToString(puntero_aplicacion.temp26);
                            LF.textBox4.Text = Convert.ToString(puntero_aplicacion.pres25);
                            LF.textBox5.Text = Convert.ToString(puntero_aplicacion.pres26);
                            LF.textBox107.Text = Convert.ToString(10);
                            LF.button1_Click(this, e);
                            puntero_aplicacion.LF_Main_SF_Effective_Apperture_Area = LF.ReflectorApertureAreaResult;
                            puntero_aplicacion.LF_Main_SF_Pressure_drop = LF.Total_Pressure_DropResult;

                            //MAIN SOLAR FIELD CALCULATION
                            PTC_SF_Calculation PTC1 = new PTC_SF_Calculation();
                            PTC1.calledForSensingAnalysis = true;
                            PTC1.comboBox1.Text = "Solar Salt";
                            PTC1.comboBox2.Text = "PureFluid";
                            PTC1.comboBox13.Text = puntero_aplicacion.comboBox2.Text;
                            PTC1.comboBox14.Text = puntero_aplicacion.comboBox6.Text;
                            //PTC.textBox31.Text = this.textBox31.Text;
                            //PTC.textBox36.Text = this.textBox36.Text;

                            if (comboBox4.Text == "Parabolic")
                            {
                                PTC1.textBox7.Text = "0.141";
                                PTC1.textBox8.Text = "6.48e-9";
                            }
                            else if (comboBox4.Text == "Parabolic with cavity receiver (Norwich)")
                            {
                                PTC1.textBox7.Text = "0.3";
                                PTC1.textBox8.Text = "3.25e-9";
                            }

                            PTC1.textBox1.Text = Convert.ToString(puntero_aplicacion.RHX1);
                            PTC1.textBox2.Text = Convert.ToString(puntero_aplicacion.massflow2);
                            PTC1.textBox3.Text = Convert.ToString(puntero_aplicacion.temp215);
                            PTC1.textBox6.Text = Convert.ToString(puntero_aplicacion.temp216);
                            PTC1.textBox4.Text = Convert.ToString(puntero_aplicacion.pres215);
                            PTC1.textBox5.Text = Convert.ToString(puntero_aplicacion.pres216);
                            PTC1.textBox107.Text = Convert.ToString(10);
                            PTC1.button1_Click(this, e);
                            puntero_aplicacion.PTC_ReHeating1_SF_Effective_Apperture_Area = PTC.ReflectorApertureAreaResult;
                            puntero_aplicacion.PTC_ReHeating1_SF_Pressure_drop = PTC.Total_Pressure_DropResult;

                            //MAIN SOLAR FIELD CALCULATION
                            LF_SF_Calculation LF1 = new LF_SF_Calculation();
                            LF1.calledForSensingAnalysis = true;
                            LF1.comboBox1.Text = "Solar Salt";
                            LF1.comboBox2.Text = "PureFluid";
                            LF1.comboBox13.Text = puntero_aplicacion.comboBox2.Text;
                            LF1.comboBox14.Text = puntero_aplicacion.comboBox6.Text;
                            //LF.textBox31.Text = this.textBox31.Text;
                            //LF.textBox36.Text = this.textBox36.Text;
                            LF1.textBox1.Text = Convert.ToString(puntero_aplicacion.RHX1);
                            LF1.textBox2.Text = Convert.ToString(puntero_aplicacion.massflow2);
                            LF1.textBox3.Text = Convert.ToString(puntero_aplicacion.temp215);
                            LF1.textBox6.Text = Convert.ToString(puntero_aplicacion.temp216);
                            LF1.textBox4.Text = Convert.ToString(puntero_aplicacion.pres215);
                            LF1.textBox5.Text = Convert.ToString(puntero_aplicacion.pres216);
                            LF1.textBox107.Text = Convert.ToString(10);
                            LF1.button1_Click(this, e);
                            puntero_aplicacion.LF_ReHeating1_SF_Effective_Apperture_Area = LF.ReflectorApertureAreaResult;
                            puntero_aplicacion.LF_ReHeating1_SF_Pressure_drop = LF.Total_Pressure_DropResult;

                            //MAIN SOLAR FIELD CALCULATION
                            PTC_SF_Calculation PTC2 = new PTC_SF_Calculation();
                            PTC2.calledForSensingAnalysis = true;
                            PTC2.comboBox1.Text = "Solar Salt";
                            PTC2.comboBox2.Text = "PureFluid";
                            PTC2.comboBox13.Text = puntero_aplicacion.comboBox2.Text;
                            PTC2.comboBox14.Text = puntero_aplicacion.comboBox6.Text;
                            //PTC.textBox31.Text = this.textBox31.Text;
                            //PTC.textBox36.Text = this.textBox36.Text;

                            if (comboBox4.Text == "Parabolic")
                            {
                                PTC2.textBox7.Text = "0.141";
                                PTC2.textBox8.Text = "6.48e-9";
                            }
                            else if (comboBox4.Text == "Parabolic with cavity receiver (Norwich)")
                            {
                                PTC2.textBox7.Text = "0.3";
                                PTC2.textBox8.Text = "3.25e-9";
                            }

                            PTC2.textBox1.Text = Convert.ToString(puntero_aplicacion.RHX2);
                            PTC2.textBox2.Text = Convert.ToString(puntero_aplicacion.massflow2);
                            PTC2.textBox3.Text = Convert.ToString(puntero_aplicacion.temp217);
                            PTC2.textBox6.Text = Convert.ToString(puntero_aplicacion.temp218);
                            PTC2.textBox4.Text = Convert.ToString(puntero_aplicacion.pres217);
                            PTC2.textBox5.Text = Convert.ToString(puntero_aplicacion.pres218);
                            PTC2.textBox107.Text = Convert.ToString(10);
                            PTC2.button1_Click(this, e);
                            puntero_aplicacion.PTC_ReHeating2_SF_Effective_Apperture_Area = PTC.ReflectorApertureAreaResult;
                            puntero_aplicacion.PTC_ReHeating2_SF_Pressure_drop = PTC.Total_Pressure_DropResult;

                            //MAIN SOLAR FIELD CALCULATION
                            LF_SF_Calculation LF2 = new LF_SF_Calculation();
                            LF2.calledForSensingAnalysis = true;
                            LF2.comboBox1.Text = "Solar Salt";
                            LF2.comboBox2.Text = "PureFluid";
                            LF2.comboBox13.Text = puntero_aplicacion.comboBox2.Text;
                            LF2.comboBox14.Text = puntero_aplicacion.comboBox6.Text;
                            //LF.textBox31.Text = this.textBox31.Text;
                            //LF.textBox36.Text = this.textBox36.Text;
                            LF2.textBox1.Text = Convert.ToString(puntero_aplicacion.RHX2);
                            LF2.textBox2.Text = Convert.ToString(puntero_aplicacion.massflow2);
                            LF2.textBox3.Text = Convert.ToString(puntero_aplicacion.temp217);
                            LF2.textBox6.Text = Convert.ToString(puntero_aplicacion.temp218);
                            LF2.textBox4.Text = Convert.ToString(puntero_aplicacion.pres217);
                            LF2.textBox5.Text = Convert.ToString(puntero_aplicacion.pres218);
                            LF2.textBox107.Text = Convert.ToString(10);
                            LF2.button1_Click(this, e);
                            puntero_aplicacion.LF_ReHeating2_SF_Effective_Apperture_Area = LF.ReflectorApertureAreaResult;
                            puntero_aplicacion.LF_ReHeating2_SF_Pressure_drop = LF.Total_Pressure_DropResult;

                            //MAIN SOLAR FIELD CALCULATION
                            PTC_SF_Calculation PTC3 = new PTC_SF_Calculation();
                            PTC3.calledForSensingAnalysis = true;
                            PTC3.comboBox1.Text = "Solar Salt";
                            PTC3.comboBox2.Text = "PureFluid";
                            PTC3.comboBox13.Text = puntero_aplicacion.comboBox2.Text;
                            PTC3.comboBox14.Text = puntero_aplicacion.comboBox6.Text;
                            //PTC.textBox31.Text = this.textBox31.Text;
                            //PTC.textBox36.Text = this.textBox36.Text;

                            if (comboBox4.Text == "Parabolic")
                            {
                                PTC3.textBox7.Text = "0.141";
                                PTC3.textBox8.Text = "6.48e-9";
                            }
                            else if (comboBox4.Text == "Parabolic with cavity receiver (Norwich)")
                            {
                                PTC3.textBox7.Text = "0.3";
                                PTC3.textBox8.Text = "3.25e-9";
                            }

                            PTC3.textBox1.Text = Convert.ToString(puntero_aplicacion.RHX3);
                            PTC3.textBox2.Text = Convert.ToString(puntero_aplicacion.massflow2);
                            PTC3.textBox3.Text = Convert.ToString(puntero_aplicacion.temp219);
                            PTC3.textBox6.Text = Convert.ToString(puntero_aplicacion.temp220);
                            PTC3.textBox4.Text = Convert.ToString(puntero_aplicacion.pres219);
                            PTC3.textBox5.Text = Convert.ToString(puntero_aplicacion.pres220);
                            PTC3.textBox107.Text = Convert.ToString(10);
                            PTC3.button1_Click(this, e);
                            puntero_aplicacion.PTC_ReHeating3_SF_Effective_Apperture_Area = PTC.ReflectorApertureAreaResult;
                            puntero_aplicacion.PTC_ReHeating3_SF_Pressure_drop = PTC.Total_Pressure_DropResult;

                            //MAIN SOLAR FIELD CALCULATION
                            LF_SF_Calculation LF3 = new LF_SF_Calculation();
                            LF3.calledForSensingAnalysis = true;
                            LF3.comboBox1.Text = "Solar Salt";
                            LF3.comboBox2.Text = "PureFluid";
                            LF3.comboBox13.Text = puntero_aplicacion.comboBox2.Text;
                            LF3.comboBox14.Text = puntero_aplicacion.comboBox6.Text;
                            //LF.textBox31.Text = this.textBox31.Text;
                            //LF.textBox36.Text = this.textBox36.Text;
                            LF3.textBox1.Text = Convert.ToString(puntero_aplicacion.RHX3);
                            LF3.textBox2.Text = Convert.ToString(puntero_aplicacion.massflow2);
                            LF3.textBox3.Text = Convert.ToString(puntero_aplicacion.temp219);
                            LF3.textBox6.Text = Convert.ToString(puntero_aplicacion.temp220);
                            LF3.textBox4.Text = Convert.ToString(puntero_aplicacion.pres219);
                            LF3.textBox5.Text = Convert.ToString(puntero_aplicacion.pres220);
                            LF3.textBox107.Text = Convert.ToString(10);
                            LF3.button1_Click(this, e);
                            puntero_aplicacion.LF_ReHeating3_SF_Effective_Apperture_Area = LF.ReflectorApertureAreaResult;
                            puntero_aplicacion.LF_ReHeating3_SF_Pressure_drop = LF.Total_Pressure_DropResult;

                            //Copy results to EXCEL
                            double LTR_min_DT_1 = t8_list[maxIndex] - t3_list[maxIndex];
                            double LTR_min_DT_2 = t9_list[maxIndex] - t2_list[maxIndex];
                            double LTR_min_DT_paper = Math.Min(LTR_min_DT_1, LTR_min_DT_2);

                            double HTR_min_DT_1 = t8_list[maxIndex] - t4_list[maxIndex];
                            double HTR_min_DT_2 = t7_list[maxIndex] - t5_list[maxIndex];
                            double HTR_min_DT_paper = Math.Min(HTR_min_DT_1, HTR_min_DT_2);

                            //MC1_in(kPa)
                            xlWorkSheet1.Cells[counter_Excel + 1, 1] = p_mc1_in2_list[maxIndex].ToString();
                            //MC1_out(kPa)
                            xlWorkSheet1.Cells[counter_Excel + 1, 2] = p_mc1_out2_list[maxIndex].ToString();
                            //MC2_out(kPa)
                            xlWorkSheet1.Cells[counter_Excel + 1, 3] = p_mc2_out2_list[maxIndex].ToString();
                            //P_rhx1(kPa)
                            xlWorkSheet1.Cells[counter_Excel + 1, 4] = p_rhx1_list[maxIndex].ToString();
                            //P_rhx2(kPa)
                            xlWorkSheet1.Cells[counter_Excel + 1, 5] = p_rhx2_list[maxIndex].ToString();
                            //P_rhx3(kPa)
                            xlWorkSheet1.Cells[counter_Excel + 1, 6] = p_rhx3_list[maxIndex].ToString();
                            //CIT
                            xlWorkSheet1.Cells[counter_Excel + 1, 7] = Convert.ToString(i - 273.15);
                            //LT UA(kW/K)
                            xlWorkSheet1.Cells[counter_Excel + 1, 8] = Convert.ToString(puntero_aplicacion.ua_lt2);
                            //HT UA(kW/K)
                            xlWorkSheet1.Cells[counter_Excel + 1, 9] = Convert.ToString(puntero_aplicacion.ua_ht2);
                            //Rec.Frac.
                            xlWorkSheet1.Cells[counter_Excel + 1, 10] = recomp_frac2_list[maxIndex].ToString();
                            //Eff.(%)
                            xlWorkSheet1.Cells[counter_Excel + 1, 11] = (eta_thermal2_list[maxIndex] * 100).ToString();
                            //LTR Eff.(%)
                            xlWorkSheet1.Cells[counter_Excel + 1, 12] = cicloRCMCI_withTwoIntercooling_withThreeRH.LT.eff.ToString();
                            //LTR Pinch(ºC)
                            xlWorkSheet1.Cells[counter_Excel + 1, 13] = LTR_min_DT_paper.ToString();
                            //HTR Eff.(%)
                            xlWorkSheet1.Cells[counter_Excel + 1, 14] = cicloRCMCI_withTwoIntercooling_withThreeRH.HT.eff.ToString();
                            //HTR Pinch(ºC)
                            xlWorkSheet1.Cells[counter_Excel + 1, 15] = HTR_min_DT_paper.ToString();
                            //PTC_Apperture_Area(m2)
                            xlWorkSheet1.Cells[counter_Excel + 1, 16] = puntero_aplicacion.PTC_Main_SF_Effective_Apperture_Area.ToString();
                            //PTC_Pressure_Drop(bar)
                            xlWorkSheet1.Cells[counter_Excel + 1, 17] = puntero_aplicacion.PTC_Main_SF_Pressure_drop.ToString();
                            //LF_Apperture_Area(m2)
                            xlWorkSheet1.Cells[counter_Excel + 1, 18] = puntero_aplicacion.LF_Main_SF_Effective_Apperture_Area.ToString();
                            //LF_Pressure_Drop(bar)
                            xlWorkSheet1.Cells[counter_Excel + 1, 19] = puntero_aplicacion.LF_Main_SF_Pressure_drop.ToString();
                            //PTC1_Apperture_Area(m2)
                            xlWorkSheet1.Cells[counter_Excel + 1, 20] = puntero_aplicacion.PTC_ReHeating1_SF_Effective_Apperture_Area.ToString();
                            //PTC1_Pressure_Drop(bar)
                            xlWorkSheet1.Cells[counter_Excel + 1, 21] = puntero_aplicacion.PTC_ReHeating1_SF_Pressure_drop.ToString();
                            //LF1_Apperture_Area(m2)
                            xlWorkSheet1.Cells[counter_Excel + 1, 22] = puntero_aplicacion.LF_ReHeating1_SF_Effective_Apperture_Area.ToString();
                            //LF1_Pressure_Drop(bar)
                            xlWorkSheet1.Cells[counter_Excel + 1, 23] = puntero_aplicacion.LF_ReHeating1_SF_Pressure_drop.ToString();
                            //PTC2_Apperture_Area(m2)
                            xlWorkSheet1.Cells[counter_Excel + 1, 24] = puntero_aplicacion.PTC_ReHeating2_SF_Effective_Apperture_Area.ToString();
                            //PTC2_Pressure_Drop(bar)
                            xlWorkSheet1.Cells[counter_Excel + 1, 25] = puntero_aplicacion.PTC_ReHeating2_SF_Pressure_drop.ToString();
                            //LF2_Apperture_Area(m2)
                            xlWorkSheet1.Cells[counter_Excel + 1, 26] = puntero_aplicacion.LF_ReHeating2_SF_Effective_Apperture_Area.ToString();
                            //LF2_Pressure_Drop(bar)
                            xlWorkSheet1.Cells[counter_Excel + 1, 27] = puntero_aplicacion.LF_ReHeating2_SF_Pressure_drop.ToString();
                            //PTC3_Apperture_Area(m2)
                            xlWorkSheet1.Cells[counter_Excel + 1, 28] = puntero_aplicacion.PTC_ReHeating3_SF_Effective_Apperture_Area.ToString();
                            //PTC3_Pressure_Drop(bar)
                            xlWorkSheet1.Cells[counter_Excel + 1, 29] = puntero_aplicacion.PTC_ReHeating3_SF_Pressure_drop.ToString();
                            //LF3_Apperture_Area(m2)
                            xlWorkSheet1.Cells[counter_Excel + 1, 30] = puntero_aplicacion.LF_ReHeating3_SF_Effective_Apperture_Area.ToString();
                            //LF3_Pressure_Drop(bar)
                            xlWorkSheet1.Cells[counter_Excel + 1, 31] = puntero_aplicacion.LF_ReHeating3_SF_Pressure_drop.ToString();

                            counter_Excel++;

                            initial_mc1_in_value = puntero_aplicacion.p_mc1_in2;
                            initial_mc1_out_value = puntero_aplicacion.p_mc1_out2;
                            initial_mc2_out_value = puntero_aplicacion.p_mc2_out2;
                        }
                    } //end UA optimization false

                    //Optimize UA true
                    else if (checkBox2.Checked == true)
                    {
                        //PureFluid
                        if (puntero_aplicacion.comboBox1.Text == "PureFluid")
                        {
                            puntero_aplicacion.category = RefrigerantCategory.PureFluid;
                            puntero_aplicacion.luis.core1(puntero_aplicacion.comboBox1.Text, puntero_aplicacion.category);
                        }

                        //NewMixture
                        if (puntero_aplicacion.comboBox1.Text == "NewMixture")
                        {
                            puntero_aplicacion.category = RefrigerantCategory.NewMixture;
                            puntero_aplicacion.luis.core1(puntero_aplicacion.comboBox2.Text + "=" + puntero_aplicacion.textBox35.Text + "," + puntero_aplicacion.comboBox16.Text + "=" + puntero_aplicacion.textBox36.Text, puntero_aplicacion.category);
                        }

                        if (puntero_aplicacion.comboBox1.Text == "PredefinedMixture")
                        {
                            puntero_aplicacion.category = RefrigerantCategory.PredefinedMixture;
                        }

                        if (puntero_aplicacion.comboBox1.Text == "PseudoPureFluid")
                        {
                            puntero_aplicacion.category = RefrigerantCategory.PseudoPureFluid;
                        }

                        if (puntero_aplicacion.comboBox3.Text == "DEF")
                        {
                            puntero_aplicacion.referencestate = ReferenceState.DEF;
                        }
                        if (puntero_aplicacion.comboBox3.Text == "ASH")
                        {
                            puntero_aplicacion.referencestate = ReferenceState.ASH;
                        }
                        if (puntero_aplicacion.comboBox3.Text == "IIR")
                        {
                            puntero_aplicacion.referencestate = ReferenceState.IIR;
                        }
                        if (puntero_aplicacion.comboBox3.Text == "NBP")
                        {
                            puntero_aplicacion.referencestate = ReferenceState.NBP;
                        }

                        puntero_aplicacion.luis.working_fluid.Category = puntero_aplicacion.category;
                        puntero_aplicacion.luis.working_fluid.reference = puntero_aplicacion.referencestate;

                        puntero_aplicacion.luis.wmm = puntero_aplicacion.luis.working_fluid.MolecularWeight;

                        //Store Input Data from Graphical User Interface GUI into variables
                        puntero_aplicacion.w_dot_net2 = Convert.ToDouble(puntero_aplicacion.textBox1.Text);
                        puntero_aplicacion.t_mc1_in2 = Convert.ToDouble(puntero_aplicacion.textBox2.Text);
                        puntero_aplicacion.t_mc2_in2 = Convert.ToDouble(puntero_aplicacion.textBox28.Text);
                        puntero_aplicacion.t_mc3_in2 = Convert.ToDouble(puntero_aplicacion.textBox93.Text);
                        puntero_aplicacion.t_t_in2 = Convert.ToDouble(puntero_aplicacion.textBox4.Text);
                        puntero_aplicacion.p_mc1_in2 = Convert.ToDouble(puntero_aplicacion.textBox3.Text);
                        puntero_aplicacion.p_mc1_out2 = Convert.ToDouble(puntero_aplicacion.textBox8.Text);
                        puntero_aplicacion.p_mc2_in2 = Convert.ToDouble(puntero_aplicacion.textBox23.Text);
                        puntero_aplicacion.p_mc2_out2 = Convert.ToDouble(puntero_aplicacion.textBox22.Text);
                        puntero_aplicacion.p_mc3_in2 = Convert.ToDouble(puntero_aplicacion.textBox95.Text);
                        puntero_aplicacion.p_mc3_out2 = Convert.ToDouble(puntero_aplicacion.textBox94.Text);
                        puntero_aplicacion.p_rhx1_in2 = Convert.ToDouble(puntero_aplicacion.textBox7.Text);
                        puntero_aplicacion.t_rht1_in2 = Convert.ToDouble(puntero_aplicacion.textBox6.Text);
                        puntero_aplicacion.p_rhx2_in2 = Convert.ToDouble(puntero_aplicacion.textBox107.Text);
                        puntero_aplicacion.t_rht2_in2 = Convert.ToDouble(puntero_aplicacion.textBox106.Text);
                        puntero_aplicacion.p_rhx3_in2 = Convert.ToDouble(puntero_aplicacion.textBox115.Text);
                        puntero_aplicacion.t_rht3_in2 = Convert.ToDouble(puntero_aplicacion.textBox114.Text);
                        //puntero_aplicacion.ua_lt2 = Convert.ToDouble(puntero_aplicacion.textBox17.Text);
                        //puntero_aplicacion.ua_ht2 = Convert.ToDouble(puntero_aplicacion.textBox16.Text);
                        puntero_aplicacion.recomp_frac2 = Convert.ToDouble(puntero_aplicacion.textBox15.Text);
                        puntero_aplicacion.eta1_mc2 = Convert.ToDouble(puntero_aplicacion.textBox14.Text);
                        puntero_aplicacion.eta2_mc2 = Convert.ToDouble(puntero_aplicacion.textBox27.Text);
                        puntero_aplicacion.eta3_mc2 = Convert.ToDouble(puntero_aplicacion.textBox92.Text);
                        puntero_aplicacion.eta_rc2 = Convert.ToDouble(puntero_aplicacion.textBox13.Text);
                        puntero_aplicacion.eta_t2 = Convert.ToDouble(puntero_aplicacion.textBox19.Text);
                        puntero_aplicacion.eta_trh1 = Convert.ToDouble(puntero_aplicacion.textBox18.Text);
                        puntero_aplicacion.eta_trh2 = Convert.ToDouble(puntero_aplicacion.textBox108.Text);
                        puntero_aplicacion.eta_trh3 = Convert.ToDouble(puntero_aplicacion.textBox113.Text);
                        puntero_aplicacion.n_sub_hxrs2 = Convert.ToInt64(puntero_aplicacion.textBox20.Text);
                        puntero_aplicacion.tol2 = Convert.ToDouble(puntero_aplicacion.textBox21.Text);
                        puntero_aplicacion.dp2_lt1 = Convert.ToDouble(puntero_aplicacion.textBox5.Text);
                        puntero_aplicacion.dp2_ht1 = Convert.ToDouble(puntero_aplicacion.textBox12.Text);
                        puntero_aplicacion.dp1_pc1 = Convert.ToDouble(puntero_aplicacion.textBox11.Text);
                        puntero_aplicacion.dp2_pc1 = Convert.ToDouble(puntero_aplicacion.textBox24.Text);
                        puntero_aplicacion.dp3_pc1 = Convert.ToDouble(puntero_aplicacion.textBox96.Text);
                        puntero_aplicacion.dp2_phx1 = Convert.ToDouble(puntero_aplicacion.textBox10.Text);
                        puntero_aplicacion.dp2_rhx12 = Convert.ToDouble(puntero_aplicacion.textBox9.Text);
                        puntero_aplicacion.dp2_rhx22 = Convert.ToDouble(puntero_aplicacion.textBox105.Text);
                        puntero_aplicacion.dp2_rhx32 = Convert.ToDouble(puntero_aplicacion.textBox116.Text);
                        puntero_aplicacion.dp2_lt2 = Convert.ToDouble(puntero_aplicacion.textBox26.Text);
                        puntero_aplicacion.dp2_ht2 = Convert.ToDouble(puntero_aplicacion.textBox25.Text);

                        core.RCMCIwithTwoIntercoolingwithThreeReheating cicloRCMCI_withTwoIntercooling_withThreeRH = new core.RCMCIwithTwoIntercoolingwithThreeReheating();

                        double UA_Total = puntero_aplicacion.ua_lt2 + puntero_aplicacion.ua_ht2;

                        double LT_fraction = 0.1;

                        List<Double> recomp_frac2_list = new List<Double>();
                        List<Double> p_mc1_in2_list = new List<Double>();
                        List<Double> p_mc1_out2_list = new List<Double>();
                        List<Double> p_mc2_out2_list = new List<Double>();
                        List<Double> p_rhx1_list = new List<Double>();
                        List<Double> p_rhx2_list = new List<Double>();
                        List<Double> p_rhx3_list = new List<Double>();
                        List<Double> eta_thermal2_list = new List<Double>();
                        List<Double> ua_LT_list = new List<Double>();
                        List<Double> ua_HT_list = new List<Double>();

                        List<Double> t1_list = new List<Double>();
                        List<Double> t2_list = new List<Double>();
                        List<Double> t3_list = new List<Double>();
                        List<Double> t4_list = new List<Double>();
                        List<Double> t5_list = new List<Double>();
                        List<Double> t6_list = new List<Double>();
                        List<Double> t7_list = new List<Double>();
                        List<Double> t8_list = new List<Double>();
                        List<Double> t9_list = new List<Double>();
                        List<Double> t10_list = new List<Double>();
                        List<Double> t13_list = new List<Double>();
                        List<Double> t14_list = new List<Double>();
                        List<Double> t15_list = new List<Double>();
                        List<Double> t16_list = new List<Double>();
                        List<Double> t17_list = new List<Double>();
                        List<Double> t18_list = new List<Double>();
                        List<Double> t19_list = new List<Double>();
                        List<Double> t20_list = new List<Double>();

                        List<Double> p1_list = new List<Double>();
                        List<Double> p2_list = new List<Double>();
                        List<Double> p3_list = new List<Double>();
                        List<Double> p4_list = new List<Double>();
                        List<Double> p5_list = new List<Double>();
                        List<Double> p6_list = new List<Double>();
                        List<Double> p7_list = new List<Double>();
                        List<Double> p8_list = new List<Double>();
                        List<Double> p9_list = new List<Double>();
                        List<Double> p10_list = new List<Double>();
                        List<Double> p13_list = new List<Double>();
                        List<Double> p14_list = new List<Double>();
                        List<Double> p15_list = new List<Double>();
                        List<Double> p16_list = new List<Double>();
                        List<Double> p17_list = new List<Double>();
                        List<Double> p18_list = new List<Double>();
                        List<Double> p19_list = new List<Double>();
                        List<Double> p20_list = new List<Double>();

                        List<Double> HT_Eff_list = new List<Double>();
                        List<Double> LT_Eff_list = new List<Double>();

                        NLoptAlgorithm algorithm_type = NLoptAlgorithm.LN_BOBYQA;

                        if (comboBox19.Text == "BOBYQA")
                            algorithm_type = NLoptAlgorithm.LN_BOBYQA;
                        else if (comboBox19.Text == "COBYLA")
                            algorithm_type = NLoptAlgorithm.LN_COBYLA;
                        else if (comboBox19.Text == "SUBPLEX")
                            algorithm_type = NLoptAlgorithm.LN_SBPLX;
                        else if (comboBox19.Text == "NELDER-MEAD")
                            algorithm_type = NLoptAlgorithm.LN_NELDERMEAD;
                        else if (comboBox19.Text == "NEWUOA")
                            algorithm_type = NLoptAlgorithm.LN_NEWUOA;
                        else if (comboBox19.Text == "PRAXIS")
                            algorithm_type = NLoptAlgorithm.LN_PRAXIS;

                        if (i == Convert.ToDouble(textBox57.Text))
                        {
                            if (checkBox6.Checked == true)
                            {
                                initial_CIP_value = Convert.ToDouble(textBox1.Text);
                            }
                            else
                            {
                                initial_CIP_value = puntero_aplicacion.MixtureCriticalPressure;
                            }

                            xlWorkSheet1.Name = puntero_aplicacion.comboBox2.Text + " Mixture";

                            //puntero_aplicacion.comboBox2.Text + "=" + puntero_aplicacion.textBox68.Text + "," + puntero_aplicacion.comboBox6.Text + "=" + puntero_aplicacion.textBox69.Text + "," + puntero_aplicacion.comboBox12.Text + "=" + puntero_aplicacion.textBox33.Text + "," + puntero_aplicacion.comboBox7.Text + "=" + puntero_aplicacion.textBox34.Text
                            xlWorkSheet1.Cells[1, 1] = puntero_aplicacion.comboBox2.Text + ":" + puntero_aplicacion.textBox33.Text + "," + puntero_aplicacion.comboBox6.Text + ":" + puntero_aplicacion.textBox34.Text + "," + puntero_aplicacion.comboBox12.Text + ":" + puntero_aplicacion.textBox68.Text + "," + puntero_aplicacion.comboBox7.Text + ":" + puntero_aplicacion.textBox69.Text;
                            xlWorkSheet1.Cells[1, 2] = "Pcrit(kPa)";
                            xlWorkSheet1.Cells[1, 3] = "Tcrit(ºC)";

                            xlWorkSheet1.Cells[2, 1] = "";
                            xlWorkSheet1.Cells[2, 2] = Convert.ToString(puntero_aplicacion.MixtureCriticalPressure);
                            xlWorkSheet1.Cells[2, 3] = Convert.ToString(puntero_aplicacion.MixtureCriticalTemperature - 273.15);

                            xlWorkSheet1.Cells[3, 1] = "";
                            xlWorkSheet1.Cells[3, 2] = "";
                            xlWorkSheet1.Cells[4, 3] = "";

                            xlWorkSheet1.Cells[4, 1] = "MC1_in(kPa)";
                            xlWorkSheet1.Cells[4, 2] = "MC1_out(kPa)";
                            xlWorkSheet1.Cells[4, 3] = "MC2_out(kPa)";
                            xlWorkSheet1.Cells[4, 4] = "P_rhx1(kPa)";
                            xlWorkSheet1.Cells[4, 5] = "P_rhx2(kPa)";
                            xlWorkSheet1.Cells[4, 6] = "P_rhx3(kPa)";
                            xlWorkSheet1.Cells[4, 7] = "CIT(K)";
                            xlWorkSheet1.Cells[4, 8] = "LT UA(kW/K)";
                            xlWorkSheet1.Cells[4, 9] = "HT UA(kW/K)";
                            xlWorkSheet1.Cells[4, 10] = "Rec.Frac.";
                            xlWorkSheet1.Cells[4, 11] = "Eff.(%)";
                            xlWorkSheet1.Cells[4, 12] = "LTR Eff.(%)";
                            xlWorkSheet1.Cells[4, 13] = "LTR Pinch(ºC)";
                            xlWorkSheet1.Cells[4, 14] = "HTR Eff.(%)";
                            xlWorkSheet1.Cells[4, 15] = "HTR Pinch(ºC)";
                            xlWorkSheet1.Cells[4, 16] = "PTC_Apperture_Area(m2)";
                            xlWorkSheet1.Cells[4, 17] = "PTC_Pressure_Drop(bar)";
                            xlWorkSheet1.Cells[4, 18] = "LF_Apperture_Area(m2)";
                            xlWorkSheet1.Cells[4, 19] = "LF_Pressure_Drop(bar)";
                            xlWorkSheet1.Cells[4, 20] = "PTC1_Apperture_Area(m2)";
                            xlWorkSheet1.Cells[4, 21] = "PTC1_Pressure_Drop(bar)";
                            xlWorkSheet1.Cells[4, 22] = "LF1_Apperture_Area(m2)";
                            xlWorkSheet1.Cells[4, 23] = "LF1_Pressure_Drop(bar)";
                            xlWorkSheet1.Cells[4, 24] = "PTC2_Apperture_Area(m2)";
                            xlWorkSheet1.Cells[4, 25] = "PTC2_Pressure_Drop(bar)";
                            xlWorkSheet1.Cells[4, 26] = "LF2_Apperture_Area(m2)";
                            xlWorkSheet1.Cells[4, 27] = "LF2_Pressure_Drop(bar)";
                            xlWorkSheet1.Cells[4, 28] = "PTC3_Apperture_Area(m2)";
                            xlWorkSheet1.Cells[4, 29] = "PTC3_Pressure_Drop(bar)";
                            xlWorkSheet1.Cells[4, 30] = "LF3_Apperture_Area(m2)";
                            xlWorkSheet1.Cells[4, 31] = "LF3_Pressure_Drop(bar)";
                        }

                        using (var solver = new NLoptSolver(algorithm_type, 8, 0.000001, 10000))
                        {
                            solver.SetLowerBounds(new[] { 0.0, initial_CIP_value, initial_CIP_value,
                            initial_CIP_value, initial_CIP_value, initial_CIP_value , initial_CIP_value, 0.0});

                            solver.SetUpperBounds(new[] { 1.0, (puntero_aplicacion.p_mc3_out2 / 1.1),
                            (puntero_aplicacion.p_mc3_out2 / 1.1), (puntero_aplicacion.p_mc3_out2 / 1.1),
                            puntero_aplicacion.p_mc3_out2, puntero_aplicacion.p_mc3_out2 ,
                            puntero_aplicacion.p_mc3_out2, 1.0});

                            solver.SetInitialStepSize(new[] { 0.05, 250.0, 250.0, 250.0, 1000.0, 1000.0, 1000.0, 0.05 });

                            var initialValue = new[] { 0.2, initial_CIP_value + 1500.0, initial_CIP_value + 2000.0,
                            initial_CIP_value + 3000.0, initial_CIP_value + 6000.0, initial_CIP_value + 5000.0,
                            initial_CIP_value + 4000.0, 0.5 };

                            Func<double[], double> funcion = delegate (double[] variables)
                            {
                                puntero_aplicacion.luis.RecompCycle_RCMCI_with_Two_Intercooling_with_ThreeReheating_for_optimization(puntero_aplicacion.luis,
                                ref cicloRCMCI_withTwoIntercooling_withThreeRH, puntero_aplicacion.w_dot_net2,
                                i, puntero_aplicacion.t_t_in2, puntero_aplicacion.t_rht1_in2,
                                variables[4], puntero_aplicacion.t_rht2_in2, variables[5],
                                puntero_aplicacion.t_rht3_in2, variables[6], variables[2],
                                variables[3], variables[1], i, variables[2], variables[3], i,
                                puntero_aplicacion.p_mc3_out2, variables[7], UA_Total, puntero_aplicacion.eta2_mc2, 
                                puntero_aplicacion.eta_rc2, puntero_aplicacion.eta1_mc2, puntero_aplicacion.eta3_mc2, 
                                puntero_aplicacion.eta_t2, puntero_aplicacion.eta_trh1, puntero_aplicacion.eta_trh2, 
                                puntero_aplicacion.eta_trh3, puntero_aplicacion.n_sub_hxrs2, variables[0], 
                                puntero_aplicacion.tol2, puntero_aplicacion.eta_thermal2, -puntero_aplicacion.dp2_lt1,
                                -puntero_aplicacion.dp2_lt2, -puntero_aplicacion.dp2_ht1, -puntero_aplicacion.dp2_ht2,
                                -puntero_aplicacion.dp1_pc1, -puntero_aplicacion.dp1_pc2, -puntero_aplicacion.dp2_phx1,
                                -puntero_aplicacion.dp2_phx2, -puntero_aplicacion.dp2_rhx11, -puntero_aplicacion.dp2_rhx12, 
                                -puntero_aplicacion.dp2_rhx21, -puntero_aplicacion.dp2_rhx22, -puntero_aplicacion.dp2_rhx31,
                                -puntero_aplicacion.dp2_rhx32, -puntero_aplicacion.dp2_pc1, -puntero_aplicacion.dp2_pc2, 
                                -puntero_aplicacion.dp3_pc1, -puntero_aplicacion.dp3_pc2);

                                counter++;

                                puntero_aplicacion.massflow2 = cicloRCMCI_withTwoIntercooling_withThreeRH.m_dot_turbine;
                                puntero_aplicacion.w_dot_net2 = cicloRCMCI_withTwoIntercooling_withThreeRH.W_dot_net;

                                puntero_aplicacion.eta_thermal2 = cicloRCMCI_withTwoIntercooling_withThreeRH.eta_thermal;
                                puntero_aplicacion.recomp_frac2 = variables[0];
                                puntero_aplicacion.p_mc1_in2 = variables[1];
                                puntero_aplicacion.p_mc1_out2 = variables[2];
                                puntero_aplicacion.p_mc2_in2 = variables[2];
                                puntero_aplicacion.p_mc2_out2 = variables[3];
                                puntero_aplicacion.p_mc3_in2 = variables[3];
                                puntero_aplicacion.p_rhx1_in2 = variables[4];
                                puntero_aplicacion.p_rhx2_in2 = variables[5];
                                puntero_aplicacion.p_rhx3_in2 = variables[6];
                                LT_fraction = variables[7];
                                puntero_aplicacion.ua_lt2 = UA_Total * LT_fraction;
                                puntero_aplicacion.ua_ht2 = UA_Total * (1 - LT_fraction);

                                puntero_aplicacion.temp21 = cicloRCMCI_withTwoIntercooling_withThreeRH.temp[0];
                                puntero_aplicacion.temp22 = cicloRCMCI_withTwoIntercooling_withThreeRH.temp[1];
                                puntero_aplicacion.temp23 = cicloRCMCI_withTwoIntercooling_withThreeRH.temp[2];
                                puntero_aplicacion.temp24 = cicloRCMCI_withTwoIntercooling_withThreeRH.temp[3];
                                puntero_aplicacion.temp25 = cicloRCMCI_withTwoIntercooling_withThreeRH.temp[4];
                                puntero_aplicacion.temp26 = cicloRCMCI_withTwoIntercooling_withThreeRH.temp[5];
                                puntero_aplicacion.temp27 = cicloRCMCI_withTwoIntercooling_withThreeRH.temp[6];
                                puntero_aplicacion.temp28 = cicloRCMCI_withTwoIntercooling_withThreeRH.temp[7];
                                puntero_aplicacion.temp29 = cicloRCMCI_withTwoIntercooling_withThreeRH.temp[8];
                                puntero_aplicacion.temp210 = cicloRCMCI_withTwoIntercooling_withThreeRH.temp[9];
                                puntero_aplicacion.temp211 = cicloRCMCI_withTwoIntercooling_withThreeRH.temp[10];
                                puntero_aplicacion.temp212 = cicloRCMCI_withTwoIntercooling_withThreeRH.temp[11];
                                puntero_aplicacion.temp213 = cicloRCMCI_withTwoIntercooling_withThreeRH.temp[12];
                                puntero_aplicacion.temp214 = cicloRCMCI_withTwoIntercooling_withThreeRH.temp[13];
                                puntero_aplicacion.temp215 = cicloRCMCI_withTwoIntercooling_withThreeRH.temp[14];
                                puntero_aplicacion.temp216 = cicloRCMCI_withTwoIntercooling_withThreeRH.temp[15];
                                puntero_aplicacion.temp217 = cicloRCMCI_withTwoIntercooling_withThreeRH.temp[16];
                                puntero_aplicacion.temp218 = cicloRCMCI_withTwoIntercooling_withThreeRH.temp[17];
                                puntero_aplicacion.temp219 = cicloRCMCI_withTwoIntercooling_withThreeRH.temp[18];
                                puntero_aplicacion.temp220 = cicloRCMCI_withTwoIntercooling_withThreeRH.temp[19];

                                puntero_aplicacion.pres21 = cicloRCMCI_withTwoIntercooling_withThreeRH.pres[0];
                                puntero_aplicacion.pres22 = cicloRCMCI_withTwoIntercooling_withThreeRH.pres[1];
                                puntero_aplicacion.pres23 = cicloRCMCI_withTwoIntercooling_withThreeRH.pres[2];
                                puntero_aplicacion.pres24 = cicloRCMCI_withTwoIntercooling_withThreeRH.pres[3];
                                puntero_aplicacion.pres25 = cicloRCMCI_withTwoIntercooling_withThreeRH.pres[4];
                                puntero_aplicacion.pres26 = cicloRCMCI_withTwoIntercooling_withThreeRH.pres[5];
                                puntero_aplicacion.pres27 = cicloRCMCI_withTwoIntercooling_withThreeRH.pres[6];
                                puntero_aplicacion.pres28 = cicloRCMCI_withTwoIntercooling_withThreeRH.pres[7];
                                puntero_aplicacion.pres29 = cicloRCMCI_withTwoIntercooling_withThreeRH.pres[8];
                                puntero_aplicacion.pres210 = cicloRCMCI_withTwoIntercooling_withThreeRH.pres[9];
                                puntero_aplicacion.pres211 = cicloRCMCI_withTwoIntercooling_withThreeRH.pres[10];
                                puntero_aplicacion.pres212 = cicloRCMCI_withTwoIntercooling_withThreeRH.pres[11];
                                puntero_aplicacion.pres213 = cicloRCMCI_withTwoIntercooling_withThreeRH.pres[12];
                                puntero_aplicacion.pres214 = cicloRCMCI_withTwoIntercooling_withThreeRH.pres[13];
                                puntero_aplicacion.pres215 = cicloRCMCI_withTwoIntercooling_withThreeRH.pres[14];
                                puntero_aplicacion.pres216 = cicloRCMCI_withTwoIntercooling_withThreeRH.pres[15];
                                puntero_aplicacion.pres217 = cicloRCMCI_withTwoIntercooling_withThreeRH.pres[16];
                                puntero_aplicacion.pres218 = cicloRCMCI_withTwoIntercooling_withThreeRH.pres[17];
                                puntero_aplicacion.pres219 = cicloRCMCI_withTwoIntercooling_withThreeRH.pres[18];
                                puntero_aplicacion.pres220 = cicloRCMCI_withTwoIntercooling_withThreeRH.pres[19];

                                puntero_aplicacion.PHX1 = cicloRCMCI_withTwoIntercooling_withThreeRH.PHX.Q_dot;
                                puntero_aplicacion.RHX1 = cicloRCMCI_withTwoIntercooling_withThreeRH.RHX1.Q_dot;
                                puntero_aplicacion.RHX2 = cicloRCMCI_withTwoIntercooling_withThreeRH.RHX2.Q_dot;
                                puntero_aplicacion.RHX3 = cicloRCMCI_withTwoIntercooling_withThreeRH.RHX3.Q_dot;

                                puntero_aplicacion.LT_Q = cicloRCMCI_withTwoIntercooling_withThreeRH.LT.Q_dot;
                                puntero_aplicacion.LT_mdotc = cicloRCMCI_withTwoIntercooling_withThreeRH.LT.m_dot_design[0];
                                puntero_aplicacion.LT_mdoth = cicloRCMCI_withTwoIntercooling_withThreeRH.LT.m_dot_design[1];
                                puntero_aplicacion.LT_Tcin = cicloRCMCI_withTwoIntercooling_withThreeRH.LT.T_c_in;
                                puntero_aplicacion.LT_Thin = cicloRCMCI_withTwoIntercooling_withThreeRH.LT.T_h_in;
                                puntero_aplicacion.LT_Pcin = cicloRCMCI_withTwoIntercooling_withThreeRH.LT.P_c_in;
                                puntero_aplicacion.LT_Phin = cicloRCMCI_withTwoIntercooling_withThreeRH.LT.P_h_in;
                                puntero_aplicacion.LT_Pcout = cicloRCMCI_withTwoIntercooling_withThreeRH.LT.P_c_out;
                                puntero_aplicacion.LT_Phout = cicloRCMCI_withTwoIntercooling_withThreeRH.LT.P_h_out;
                                puntero_aplicacion.LT_Effc = cicloRCMCI_withTwoIntercooling_withThreeRH.LT.eff;

                                puntero_aplicacion.HT_Q = cicloRCMCI_withTwoIntercooling_withThreeRH.HT.Q_dot;
                                puntero_aplicacion.HT_mdotc = cicloRCMCI_withTwoIntercooling_withThreeRH.HT.m_dot_design[0];
                                puntero_aplicacion.HT_mdoth = cicloRCMCI_withTwoIntercooling_withThreeRH.HT.m_dot_design[1];
                                puntero_aplicacion.HT_Tcin = cicloRCMCI_withTwoIntercooling_withThreeRH.HT.T_c_in;
                                puntero_aplicacion.HT_Thin = cicloRCMCI_withTwoIntercooling_withThreeRH.HT.T_h_in;
                                puntero_aplicacion.HT_Pcin = cicloRCMCI_withTwoIntercooling_withThreeRH.HT.P_c_in;
                                puntero_aplicacion.HT_Phin = cicloRCMCI_withTwoIntercooling_withThreeRH.HT.P_h_in;
                                puntero_aplicacion.HT_Pcout = cicloRCMCI_withTwoIntercooling_withThreeRH.HT.P_c_out;
                                puntero_aplicacion.HT_Phout = cicloRCMCI_withTwoIntercooling_withThreeRH.HT.P_h_out;
                                puntero_aplicacion.HT_Effc = cicloRCMCI_withTwoIntercooling_withThreeRH.HT.eff;

                                puntero_aplicacion.PC1 = -cicloRCMCI_withTwoIntercooling_withThreeRH.PC1.Q_dot;
                                puntero_aplicacion.PC2 = -cicloRCMCI_withTwoIntercooling_withThreeRH.PC2.Q_dot;
                                puntero_aplicacion.PC3 = -cicloRCMCI_withTwoIntercooling_withThreeRH.COOLER.Q_dot;

                                eta_thermal2_list.Add(puntero_aplicacion.eta_thermal2);
                                recomp_frac2_list.Add(puntero_aplicacion.recomp_frac2);
                                p_mc1_in2_list.Add(puntero_aplicacion.p_mc1_in2);
                                p_mc1_out2_list.Add(puntero_aplicacion.p_mc1_out2);
                                p_mc2_out2_list.Add(puntero_aplicacion.p_mc2_out2);
                                p_rhx1_list.Add(puntero_aplicacion.p_rhx1_in2);
                                p_rhx2_list.Add(puntero_aplicacion.p_rhx2_in2);
                                p_rhx3_list.Add(puntero_aplicacion.p_rhx3_in2);
                                ua_LT_list.Add(puntero_aplicacion.ua_lt2);
                                ua_HT_list.Add(puntero_aplicacion.ua_ht2);

                                HT_Eff_list.Add(cicloRCMCI_withTwoIntercooling_withThreeRH.HT.eff);
                                LT_Eff_list.Add(cicloRCMCI_withTwoIntercooling_withThreeRH.LT.eff);

                                t1_list.Add(puntero_aplicacion.temp21);
                                t2_list.Add(puntero_aplicacion.temp22);
                                t3_list.Add(puntero_aplicacion.temp23);
                                t4_list.Add(puntero_aplicacion.temp24);
                                t5_list.Add(puntero_aplicacion.temp25);
                                t6_list.Add(puntero_aplicacion.temp26);
                                t7_list.Add(puntero_aplicacion.temp27);
                                t8_list.Add(puntero_aplicacion.temp28);
                                t9_list.Add(puntero_aplicacion.temp29);
                                t10_list.Add(puntero_aplicacion.temp210);
                                t13_list.Add(puntero_aplicacion.temp213);
                                t14_list.Add(puntero_aplicacion.temp214);
                                t15_list.Add(puntero_aplicacion.temp215);
                                t16_list.Add(puntero_aplicacion.temp216);
                                t17_list.Add(puntero_aplicacion.temp217);
                                t18_list.Add(puntero_aplicacion.temp218);
                                t19_list.Add(puntero_aplicacion.temp219);
                                t20_list.Add(puntero_aplicacion.temp220);

                                p1_list.Add(puntero_aplicacion.pres21);
                                p2_list.Add(puntero_aplicacion.pres22);
                                p3_list.Add(puntero_aplicacion.pres23);
                                p4_list.Add(puntero_aplicacion.pres24);
                                p5_list.Add(puntero_aplicacion.pres25);
                                p6_list.Add(puntero_aplicacion.pres26);
                                p7_list.Add(puntero_aplicacion.pres27);
                                p8_list.Add(puntero_aplicacion.pres28);
                                p9_list.Add(puntero_aplicacion.pres29);
                                p10_list.Add(puntero_aplicacion.pres210);
                                p13_list.Add(puntero_aplicacion.pres213);
                                p14_list.Add(puntero_aplicacion.pres214);
                                p15_list.Add(puntero_aplicacion.pres215);
                                p16_list.Add(puntero_aplicacion.pres216);
                                p17_list.Add(puntero_aplicacion.pres217);
                                p18_list.Add(puntero_aplicacion.pres218);
                                p19_list.Add(puntero_aplicacion.pres219);
                                p20_list.Add(puntero_aplicacion.pres220);

                                listBox1.Items.Add(counter.ToString());
                                listBox2.Items.Add(puntero_aplicacion.eta_thermal2.ToString());
                                listBox3.Items.Add(puntero_aplicacion.recomp_frac2.ToString());
                                listBox4.Items.Add(puntero_aplicacion.p_mc1_in2.ToString());
                                listBox7.Items.Add(puntero_aplicacion.p_mc1_out2.ToString());
                                listBox24.Items.Add(puntero_aplicacion.p_mc2_in2.ToString());
                                listBox23.Items.Add(puntero_aplicacion.p_mc2_out2.ToString());
                                listBox19.Items.Add(puntero_aplicacion.p_rhx1_in2.ToString());
                                listBox21.Items.Add(puntero_aplicacion.p_rhx2_in2.ToString());
                                listBox27.Items.Add(puntero_aplicacion.p_rhx3_in2.ToString());
                                listBox5.Items.Add(puntero_aplicacion.ua_lt2.ToString());
                                listBox6.Items.Add(puntero_aplicacion.ua_ht2.ToString());
                                listBox8.Items.Add(puntero_aplicacion.temp27.ToString());
                                listBox9.Items.Add(puntero_aplicacion.temp28.ToString());

                                return puntero_aplicacion.eta_thermal2;
                            };

                            solver.SetMaxObjective(funcion);

                            double? finalScore;

                            var result = solver.Optimize(initialValue, out finalScore);

                            Double max_eta_thermal = 0.0;

                            max_eta_thermal = eta_thermal2_list.Max();

                            var maxIndex = eta_thermal2_list.IndexOf(eta_thermal2_list.Max());

                            textBox86.Text = eta_thermal2_list[maxIndex].ToString();
                            textBox90.Text = recomp_frac2_list[maxIndex].ToString();
                            textBox91.Text = p_mc1_in2_list[maxIndex].ToString();
                            textBox2.Text = p_mc1_out2_list[maxIndex].ToString();
                            textBox4.Text = p_mc2_out2_list[maxIndex].ToString();
                            textBox6.Text = p_rhx1_list[maxIndex].ToString();
                            textBox5.Text = p_rhx2_list[maxIndex].ToString();
                            textBox7.Text = p_rhx3_list[maxIndex].ToString();
                            textBox82.Text = ua_LT_list[maxIndex].ToString();
                            textBox83.Text = ua_HT_list[maxIndex].ToString();

                            //Copy results as design-point inputs
                            if (checkBox3.Checked == true)
                            {
                                puntero_aplicacion.textBox15.Text = recomp_frac2_list[maxIndex].ToString();
                                puntero_aplicacion.textBox3.Text = p_mc1_in2_list[maxIndex].ToString();
                                puntero_aplicacion.textBox8.Text = p_mc1_out2_list[maxIndex].ToString();
                                puntero_aplicacion.textBox23.Text = p_mc1_out2_list[maxIndex].ToString();
                                puntero_aplicacion.textBox22.Text = p_mc2_out2_list[maxIndex].ToString();
                                puntero_aplicacion.textBox95.Text = p_mc2_out2_list[maxIndex].ToString();
                                puntero_aplicacion.textBox7.Text = p_rhx1_list[maxIndex].ToString();
                                puntero_aplicacion.textBox107.Text = p_rhx2_list[maxIndex].ToString();
                                puntero_aplicacion.textBox115.Text = p_rhx3_list[maxIndex].ToString();
                                puntero_aplicacion.textBox17.Text = ua_LT_list[maxIndex].ToString();
                                puntero_aplicacion.textBox16.Text = ua_HT_list[maxIndex].ToString();
                                puntero_aplicacion.textBox2.Text = i.ToString();
                                puntero_aplicacion.textBox28.Text = i.ToString();
                                puntero_aplicacion.textBox93.Text = i.ToString();
                            }

                            //The variable 'i' is the loop counter for the CIT
                            listBox18.Items.Add(i.ToString());
                            listBox17.Items.Add(eta_thermal2_list[maxIndex].ToString());
                            listBox16.Items.Add(recomp_frac2_list[maxIndex].ToString());
                            listBox15.Items.Add(p_mc1_in2_list[maxIndex].ToString());
                            listBox10.Items.Add(p_mc1_out2_list[maxIndex].ToString());
                            listBox26.Items.Add(p_mc1_out2_list[maxIndex].ToString());
                            listBox25.Items.Add(p_mc2_out2_list[maxIndex].ToString());
                            listBox20.Items.Add(p_rhx1_list[maxIndex].ToString());
                            listBox22.Items.Add(p_rhx2_list[maxIndex].ToString());
                            listBox28.Items.Add(p_rhx3_list[maxIndex].ToString());
                            listBox14.Items.Add(ua_LT_list[maxIndex].ToString());
                            listBox13.Items.Add(ua_HT_list[maxIndex].ToString());
                            listBox11.Items.Add(t8_list[maxIndex].ToString());
                            listBox12.Items.Add(t9_list[maxIndex].ToString());

                            //MAIN SOLAR FIELD CALCULATION
                            PTC_SF_Calculation PTC = new PTC_SF_Calculation();
                            PTC.calledForSensingAnalysis = true;
                            PTC.comboBox1.Text = "Solar Salt";
                            PTC.comboBox2.Text = "PureFluid";
                            PTC.comboBox13.Text = puntero_aplicacion.comboBox2.Text;
                            PTC.comboBox14.Text = puntero_aplicacion.comboBox6.Text;
                            //PTC.textBox31.Text = this.textBox31.Text;
                            //PTC.textBox36.Text = this.textBox36.Text;

                            if (comboBox4.Text == "Parabolic")
                            {
                                PTC.textBox7.Text = "0.141";
                                PTC.textBox8.Text = "6.48e-9";
                            }
                            else if (comboBox4.Text == "Parabolic with cavity receiver (Norwich)")
                            {
                                PTC.textBox7.Text = "0.3";
                                PTC.textBox8.Text = "3.25e-9";
                            }

                            PTC.textBox1.Text = Convert.ToString(puntero_aplicacion.PHX1);
                            PTC.textBox2.Text = Convert.ToString(puntero_aplicacion.massflow2);
                            PTC.textBox3.Text = Convert.ToString(puntero_aplicacion.temp25);
                            PTC.textBox6.Text = Convert.ToString(puntero_aplicacion.temp26);
                            PTC.textBox4.Text = Convert.ToString(puntero_aplicacion.pres25);
                            PTC.textBox5.Text = Convert.ToString(puntero_aplicacion.pres26);
                            PTC.textBox107.Text = Convert.ToString(10);
                            PTC.button1_Click(this, e);
                            puntero_aplicacion.PTC_Main_SF_Effective_Apperture_Area = PTC.ReflectorApertureAreaResult;
                            puntero_aplicacion.PTC_Main_SF_Pressure_drop = PTC.Total_Pressure_DropResult;

                            //MAIN SOLAR FIELD CALCULATION
                            LF_SF_Calculation LF = new LF_SF_Calculation();
                            LF.calledForSensingAnalysis = true;
                            LF.comboBox1.Text = "Solar Salt";
                            LF.comboBox2.Text = "PureFluid";
                            LF.comboBox13.Text = puntero_aplicacion.comboBox2.Text;
                            LF.comboBox14.Text = puntero_aplicacion.comboBox6.Text;
                            //LF.textBox31.Text = this.textBox31.Text;
                            //LF.textBox36.Text = this.textBox36.Text;
                            LF.textBox1.Text = Convert.ToString(puntero_aplicacion.PHX1);
                            LF.textBox2.Text = Convert.ToString(puntero_aplicacion.massflow2);
                            LF.textBox3.Text = Convert.ToString(puntero_aplicacion.temp25);
                            LF.textBox6.Text = Convert.ToString(puntero_aplicacion.temp26);
                            LF.textBox4.Text = Convert.ToString(puntero_aplicacion.pres25);
                            LF.textBox5.Text = Convert.ToString(puntero_aplicacion.pres26);
                            LF.textBox107.Text = Convert.ToString(10);
                            LF.button1_Click(this, e);
                            puntero_aplicacion.LF_Main_SF_Effective_Apperture_Area = LF.ReflectorApertureAreaResult;
                            puntero_aplicacion.LF_Main_SF_Pressure_drop = LF.Total_Pressure_DropResult;

                            //MAIN SOLAR FIELD CALCULATION
                            PTC_SF_Calculation PTC1 = new PTC_SF_Calculation();
                            PTC1.calledForSensingAnalysis = true;
                            PTC1.comboBox1.Text = "Solar Salt";
                            PTC1.comboBox2.Text = "PureFluid";
                            PTC1.comboBox13.Text = puntero_aplicacion.comboBox2.Text;
                            PTC1.comboBox14.Text = puntero_aplicacion.comboBox6.Text;
                            //PTC.textBox31.Text = this.textBox31.Text;
                            //PTC.textBox36.Text = this.textBox36.Text;

                            if (comboBox4.Text == "Parabolic")
                            {
                                PTC1.textBox7.Text = "0.141";
                                PTC1.textBox8.Text = "6.48e-9";
                            }
                            else if (comboBox4.Text == "Parabolic with cavity receiver (Norwich)")
                            {
                                PTC1.textBox7.Text = "0.3";
                                PTC1.textBox8.Text = "3.25e-9";
                            }

                            PTC1.textBox1.Text = Convert.ToString(puntero_aplicacion.RHX1);
                            PTC1.textBox2.Text = Convert.ToString(puntero_aplicacion.massflow2);
                            PTC1.textBox3.Text = Convert.ToString(puntero_aplicacion.temp215);
                            PTC1.textBox6.Text = Convert.ToString(puntero_aplicacion.temp216);
                            PTC1.textBox4.Text = Convert.ToString(puntero_aplicacion.pres215);
                            PTC1.textBox5.Text = Convert.ToString(puntero_aplicacion.pres216);
                            PTC1.textBox107.Text = Convert.ToString(10);
                            PTC1.button1_Click(this, e);
                            puntero_aplicacion.PTC_ReHeating1_SF_Effective_Apperture_Area = PTC.ReflectorApertureAreaResult;
                            puntero_aplicacion.PTC_ReHeating1_SF_Pressure_drop = PTC.Total_Pressure_DropResult;

                            //MAIN SOLAR FIELD CALCULATION
                            LF_SF_Calculation LF1 = new LF_SF_Calculation();
                            LF1.calledForSensingAnalysis = true;
                            LF1.comboBox1.Text = "Solar Salt";
                            LF1.comboBox2.Text = "PureFluid";
                            LF1.comboBox13.Text = puntero_aplicacion.comboBox2.Text;
                            LF1.comboBox14.Text = puntero_aplicacion.comboBox6.Text;
                            //LF.textBox31.Text = this.textBox31.Text;
                            //LF.textBox36.Text = this.textBox36.Text;
                            LF1.textBox1.Text = Convert.ToString(puntero_aplicacion.RHX1);
                            LF1.textBox2.Text = Convert.ToString(puntero_aplicacion.massflow2);
                            LF1.textBox3.Text = Convert.ToString(puntero_aplicacion.temp215);
                            LF1.textBox6.Text = Convert.ToString(puntero_aplicacion.temp216);
                            LF1.textBox4.Text = Convert.ToString(puntero_aplicacion.pres215);
                            LF1.textBox5.Text = Convert.ToString(puntero_aplicacion.pres216);
                            LF1.textBox107.Text = Convert.ToString(10);
                            LF1.button1_Click(this, e);
                            puntero_aplicacion.LF_ReHeating1_SF_Effective_Apperture_Area = LF.ReflectorApertureAreaResult;
                            puntero_aplicacion.LF_ReHeating1_SF_Pressure_drop = LF.Total_Pressure_DropResult;

                            //MAIN SOLAR FIELD CALCULATION
                            PTC_SF_Calculation PTC2 = new PTC_SF_Calculation();
                            PTC2.calledForSensingAnalysis = true;
                            PTC2.comboBox1.Text = "Solar Salt";
                            PTC2.comboBox2.Text = "PureFluid";
                            PTC2.comboBox13.Text = puntero_aplicacion.comboBox2.Text;
                            PTC2.comboBox14.Text = puntero_aplicacion.comboBox6.Text;
                            //PTC.textBox31.Text = this.textBox31.Text;
                            //PTC.textBox36.Text = this.textBox36.Text;

                            if (comboBox4.Text == "Parabolic")
                            {
                                PTC2.textBox7.Text = "0.141";
                                PTC2.textBox8.Text = "6.48e-9";
                            }
                            else if (comboBox4.Text == "Parabolic with cavity receiver (Norwich)")
                            {
                                PTC2.textBox7.Text = "0.3";
                                PTC2.textBox8.Text = "3.25e-9";
                            }

                            PTC2.textBox1.Text = Convert.ToString(puntero_aplicacion.RHX2);
                            PTC2.textBox2.Text = Convert.ToString(puntero_aplicacion.massflow2);
                            PTC2.textBox3.Text = Convert.ToString(puntero_aplicacion.temp217);
                            PTC2.textBox6.Text = Convert.ToString(puntero_aplicacion.temp218);
                            PTC2.textBox4.Text = Convert.ToString(puntero_aplicacion.pres217);
                            PTC2.textBox5.Text = Convert.ToString(puntero_aplicacion.pres218);
                            PTC2.textBox107.Text = Convert.ToString(10);
                            PTC2.button1_Click(this, e);
                            puntero_aplicacion.PTC_ReHeating2_SF_Effective_Apperture_Area = PTC.ReflectorApertureAreaResult;
                            puntero_aplicacion.PTC_ReHeating2_SF_Pressure_drop = PTC.Total_Pressure_DropResult;

                            //MAIN SOLAR FIELD CALCULATION
                            LF_SF_Calculation LF2 = new LF_SF_Calculation();
                            LF2.calledForSensingAnalysis = true;
                            LF2.comboBox1.Text = "Solar Salt";
                            LF2.comboBox2.Text = "PureFluid";
                            LF2.comboBox13.Text = puntero_aplicacion.comboBox2.Text;
                            LF2.comboBox14.Text = puntero_aplicacion.comboBox6.Text;
                            //LF.textBox31.Text = this.textBox31.Text;
                            //LF.textBox36.Text = this.textBox36.Text;
                            LF2.textBox1.Text = Convert.ToString(puntero_aplicacion.RHX2);
                            LF2.textBox2.Text = Convert.ToString(puntero_aplicacion.massflow2);
                            LF2.textBox3.Text = Convert.ToString(puntero_aplicacion.temp217);
                            LF2.textBox6.Text = Convert.ToString(puntero_aplicacion.temp218);
                            LF2.textBox4.Text = Convert.ToString(puntero_aplicacion.pres217);
                            LF2.textBox5.Text = Convert.ToString(puntero_aplicacion.pres218);
                            LF2.textBox107.Text = Convert.ToString(10);
                            LF2.button1_Click(this, e);
                            puntero_aplicacion.LF_ReHeating2_SF_Effective_Apperture_Area = LF.ReflectorApertureAreaResult;
                            puntero_aplicacion.LF_ReHeating2_SF_Pressure_drop = LF.Total_Pressure_DropResult;

                            //MAIN SOLAR FIELD CALCULATION
                            PTC_SF_Calculation PTC3 = new PTC_SF_Calculation();
                            PTC3.calledForSensingAnalysis = true;
                            PTC3.comboBox1.Text = "Solar Salt";
                            PTC3.comboBox2.Text = "PureFluid";
                            PTC3.comboBox13.Text = puntero_aplicacion.comboBox2.Text;
                            PTC3.comboBox14.Text = puntero_aplicacion.comboBox6.Text;
                            //PTC.textBox31.Text = this.textBox31.Text;
                            //PTC.textBox36.Text = this.textBox36.Text;

                            if (comboBox4.Text == "Parabolic")
                            {
                                PTC3.textBox7.Text = "0.141";
                                PTC3.textBox8.Text = "6.48e-9";
                            }
                            else if (comboBox4.Text == "Parabolic with cavity receiver (Norwich)")
                            {
                                PTC3.textBox7.Text = "0.3";
                                PTC3.textBox8.Text = "3.25e-9";
                            }

                            PTC3.textBox1.Text = Convert.ToString(puntero_aplicacion.RHX3);
                            PTC3.textBox2.Text = Convert.ToString(puntero_aplicacion.massflow2);
                            PTC3.textBox3.Text = Convert.ToString(puntero_aplicacion.temp219);
                            PTC3.textBox6.Text = Convert.ToString(puntero_aplicacion.temp220);
                            PTC3.textBox4.Text = Convert.ToString(puntero_aplicacion.pres219);
                            PTC3.textBox5.Text = Convert.ToString(puntero_aplicacion.pres220);
                            PTC3.textBox107.Text = Convert.ToString(10);
                            PTC3.button1_Click(this, e);
                            puntero_aplicacion.PTC_ReHeating3_SF_Effective_Apperture_Area = PTC.ReflectorApertureAreaResult;
                            puntero_aplicacion.PTC_ReHeating3_SF_Pressure_drop = PTC.Total_Pressure_DropResult;

                            //MAIN SOLAR FIELD CALCULATION
                            LF_SF_Calculation LF3 = new LF_SF_Calculation();
                            LF3.calledForSensingAnalysis = true;
                            LF3.comboBox1.Text = "Solar Salt";
                            LF3.comboBox2.Text = "PureFluid";
                            LF3.comboBox13.Text = puntero_aplicacion.comboBox2.Text;
                            LF3.comboBox14.Text = puntero_aplicacion.comboBox6.Text;
                            //LF.textBox31.Text = this.textBox31.Text;
                            //LF.textBox36.Text = this.textBox36.Text;
                            LF3.textBox1.Text = Convert.ToString(puntero_aplicacion.RHX3);
                            LF3.textBox2.Text = Convert.ToString(puntero_aplicacion.massflow2);
                            LF3.textBox3.Text = Convert.ToString(puntero_aplicacion.temp219);
                            LF3.textBox6.Text = Convert.ToString(puntero_aplicacion.temp220);
                            LF3.textBox4.Text = Convert.ToString(puntero_aplicacion.pres219);
                            LF3.textBox5.Text = Convert.ToString(puntero_aplicacion.pres220);
                            LF3.textBox107.Text = Convert.ToString(10);
                            LF3.button1_Click(this, e);
                            puntero_aplicacion.LF_ReHeating3_SF_Effective_Apperture_Area = LF.ReflectorApertureAreaResult;
                            puntero_aplicacion.LF_ReHeating3_SF_Pressure_drop = LF.Total_Pressure_DropResult;

                            //Copy results to EXCEL
                            double LTR_min_DT_1 = t8_list[maxIndex] - t3_list[maxIndex];
                            double LTR_min_DT_2 = t9_list[maxIndex] - t2_list[maxIndex];
                            double LTR_min_DT_paper = Math.Min(LTR_min_DT_1, LTR_min_DT_2);

                            double HTR_min_DT_1 = t8_list[maxIndex] - t4_list[maxIndex];
                            double HTR_min_DT_2 = t7_list[maxIndex] - t5_list[maxIndex];
                            double HTR_min_DT_paper = Math.Min(HTR_min_DT_1, HTR_min_DT_2);

                            //MC1_in(kPa)
                            xlWorkSheet1.Cells[counter_Excel + 1, 1] = p_mc1_in2_list[maxIndex].ToString();
                            //MC1_out(kPa)
                            xlWorkSheet1.Cells[counter_Excel + 1, 2] = p_mc1_out2_list[maxIndex].ToString();
                            //MC2_out(kPa)
                            xlWorkSheet1.Cells[counter_Excel + 1, 3] = p_mc2_out2_list[maxIndex].ToString();
                            //P_rhx1(kPa)
                            xlWorkSheet1.Cells[counter_Excel + 1, 4] = p_rhx1_list[maxIndex].ToString();
                            //P_rhx2(kPa)
                            xlWorkSheet1.Cells[counter_Excel + 1, 5] = p_rhx2_list[maxIndex].ToString();
                            //P_rhx3(kPa)
                            xlWorkSheet1.Cells[counter_Excel + 1, 6] = p_rhx3_list[maxIndex].ToString();
                            //CIT
                            xlWorkSheet1.Cells[counter_Excel + 1, 7] = Convert.ToString(i - 273.15);
                            //LT UA(kW/K)
                            xlWorkSheet1.Cells[counter_Excel + 1, 8] = Convert.ToString(puntero_aplicacion.ua_lt2);
                            //HT UA(kW/K)
                            xlWorkSheet1.Cells[counter_Excel + 1, 9] = Convert.ToString(puntero_aplicacion.ua_ht2);
                            //Rec.Frac.
                            xlWorkSheet1.Cells[counter_Excel + 1, 10] = recomp_frac2_list[maxIndex].ToString();
                            //Eff.(%)
                            xlWorkSheet1.Cells[counter_Excel + 1, 11] = (eta_thermal2_list[maxIndex] * 100).ToString();
                            //LTR Eff.(%)
                            xlWorkSheet1.Cells[counter_Excel + 1, 12] = cicloRCMCI_withTwoIntercooling_withThreeRH.LT.eff.ToString();
                            //LTR Pinch(ºC)
                            xlWorkSheet1.Cells[counter_Excel + 1, 13] = LTR_min_DT_paper.ToString();
                            //HTR Eff.(%)
                            xlWorkSheet1.Cells[counter_Excel + 1, 14] = cicloRCMCI_withTwoIntercooling_withThreeRH.HT.eff.ToString();
                            //HTR Pinch(ºC)
                            xlWorkSheet1.Cells[counter_Excel + 1, 15] = HTR_min_DT_paper.ToString();
                            //PTC_Apperture_Area(m2)
                            xlWorkSheet1.Cells[counter_Excel + 1, 16] = puntero_aplicacion.PTC_Main_SF_Effective_Apperture_Area.ToString();
                            //PTC_Pressure_Drop(bar)
                            xlWorkSheet1.Cells[counter_Excel + 1, 17] = puntero_aplicacion.PTC_Main_SF_Pressure_drop.ToString();
                            //LF_Apperture_Area(m2)
                            xlWorkSheet1.Cells[counter_Excel + 1, 18] = puntero_aplicacion.LF_Main_SF_Effective_Apperture_Area.ToString();
                            //LF_Pressure_Drop(bar)
                            xlWorkSheet1.Cells[counter_Excel + 1, 19] = puntero_aplicacion.LF_Main_SF_Pressure_drop.ToString();
                            //PTC1_Apperture_Area(m2)
                            xlWorkSheet1.Cells[counter_Excel + 1, 20] = puntero_aplicacion.PTC_ReHeating1_SF_Effective_Apperture_Area.ToString();
                            //PTC1_Pressure_Drop(bar)
                            xlWorkSheet1.Cells[counter_Excel + 1, 21] = puntero_aplicacion.PTC_ReHeating1_SF_Pressure_drop.ToString();
                            //LF1_Apperture_Area(m2)
                            xlWorkSheet1.Cells[counter_Excel + 1, 22] = puntero_aplicacion.LF_ReHeating1_SF_Effective_Apperture_Area.ToString();
                            //LF1_Pressure_Drop(bar)
                            xlWorkSheet1.Cells[counter_Excel + 1, 23] = puntero_aplicacion.LF_ReHeating1_SF_Pressure_drop.ToString();
                            //PTC2_Apperture_Area(m2)
                            xlWorkSheet1.Cells[counter_Excel + 1, 24] = puntero_aplicacion.PTC_ReHeating2_SF_Effective_Apperture_Area.ToString();
                            //PTC2_Pressure_Drop(bar)
                            xlWorkSheet1.Cells[counter_Excel + 1, 25] = puntero_aplicacion.PTC_ReHeating2_SF_Pressure_drop.ToString();
                            //LF2_Apperture_Area(m2)
                            xlWorkSheet1.Cells[counter_Excel + 1, 26] = puntero_aplicacion.LF_ReHeating2_SF_Effective_Apperture_Area.ToString();
                            //LF2_Pressure_Drop(bar)
                            xlWorkSheet1.Cells[counter_Excel + 1, 27] = puntero_aplicacion.LF_ReHeating2_SF_Pressure_drop.ToString();
                            //PTC3_Apperture_Area(m2)
                            xlWorkSheet1.Cells[counter_Excel + 1, 28] = puntero_aplicacion.PTC_ReHeating3_SF_Effective_Apperture_Area.ToString();
                            //PTC3_Pressure_Drop(bar)
                            xlWorkSheet1.Cells[counter_Excel + 1, 29] = puntero_aplicacion.PTC_ReHeating3_SF_Pressure_drop.ToString();
                            //LF3_Apperture_Area(m2)
                            xlWorkSheet1.Cells[counter_Excel + 1, 30] = puntero_aplicacion.LF_ReHeating3_SF_Effective_Apperture_Area.ToString();
                            //LF3_Pressure_Drop(bar)
                            xlWorkSheet1.Cells[counter_Excel + 1, 31] = puntero_aplicacion.LF_ReHeating3_SF_Pressure_drop.ToString();

                            counter_Excel++;

                            initial_mc1_in_value = puntero_aplicacion.p_mc1_in2;
                            initial_mc1_out_value = puntero_aplicacion.p_mc1_out2;
                            initial_mc2_out_value = puntero_aplicacion.p_mc2_out2;
                        }
                    } //end UA optimization false
                }
            }

            //Closing Excel Book
            xlWorkBook1.SaveAs(textBox3.Text + "RCMCI_with_Two_Intercooling_with_Three_ReHeating" + ".xls", Excel.XlFileFormat.xlWorkbookNormal, misValue1, misValue1, misValue1, misValue1, Excel.XlSaveAsAccessMode.xlExclusive, misValue1, misValue1, misValue1, misValue1, misValue1);

            xlWorkBook1.Close(true, misValue1, misValue1);
            xlApp1.Quit();

            releaseObject(xlWorkSheet1);
            //releaseObject(xlWorkSheet2);
            releaseObject(xlWorkBook1);
            releaseObject(xlApp1);
        }
    }
}