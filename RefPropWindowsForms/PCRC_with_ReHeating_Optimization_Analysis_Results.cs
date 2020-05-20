﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using sc.net;

using NLoptNet;

using Excel = Microsoft.Office.Interop.Excel;

using System.Reflection;

namespace RefPropWindowsForms
{
    public partial class PCRC_with_ReHeating_Optimization_Analysis_Results : Form
    {
        PCRC puntero_aplicacion;
        public PCRC_with_ReHeating_Optimization_Analysis_Results(PCRC puntero1)
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

        //Ok button
        private void Button1_Click(object sender, EventArgs e)
        {

        }

        //Cancel button
        private void Button4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        //Run Optimization
        private void Button3_Click(object sender, EventArgs e)
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

            //xlWorkSheet1 = (Excel.Worksheet)xlWorkBook1.Worksheets.get_Item(xlWorkBook1.Worksheets.Count);           

            double initial_CIP_value = 0;

            //UA optimization false
            if (checkBox2.Checked == false)
            {
                //PureFluid
                if (puntero_aplicacion.comboBox1.Text == "PureFluid")
                {
                    puntero_aplicacion.category = RefrigerantCategory.PureFluid;
                    puntero_aplicacion.luis.core1(puntero_aplicacion.comboBox2.Text, puntero_aplicacion.category);
                }

                //NewMixture
                if (puntero_aplicacion.comboBox1.Text == "NewMixture")
                {
                    puntero_aplicacion.category = RefrigerantCategory.NewMixture;
                    puntero_aplicacion.luis.core1(puntero_aplicacion.comboBox2.Text + "=" + puntero_aplicacion.textBox35.Text + "," + puntero_aplicacion.comboBox16.Text + "=" + puntero_aplicacion.textBox36.Text + "," + puntero_aplicacion.comboBox18.Text + "=" + puntero_aplicacion.textBox87.Text + "," + puntero_aplicacion.comboBox17.Text + "=" + puntero_aplicacion.textBox88.Text, puntero_aplicacion.category);
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

                puntero_aplicacion.w_dot_net2 = Convert.ToDouble(puntero_aplicacion.textBox1.Text);
                puntero_aplicacion.t_mc_in2 = Convert.ToDouble(puntero_aplicacion.textBox2.Text);
                puntero_aplicacion.t_t_in2 = Convert.ToDouble(puntero_aplicacion.textBox4.Text);
                puntero_aplicacion.p_mc_in2 = Convert.ToDouble(puntero_aplicacion.textBox3.Text);
                puntero_aplicacion.p_mc_out2 = Convert.ToDouble(puntero_aplicacion.textBox28.Text);
                puntero_aplicacion.p_pc_in2 = Convert.ToDouble(puntero_aplicacion.textBox23.Text);
                puntero_aplicacion.p_pc_out2 = Convert.ToDouble(puntero_aplicacion.textBox8.Text);
                puntero_aplicacion.t_pc_in2 = Convert.ToDouble(puntero_aplicacion.textBox22.Text);
                puntero_aplicacion.p_rhx_in2 = Convert.ToDouble(puntero_aplicacion.textBox7.Text);
                puntero_aplicacion.t_rht_in2 = Convert.ToDouble(puntero_aplicacion.textBox6.Text);
                puntero_aplicacion.dp2_lt1 = Convert.ToDouble(puntero_aplicacion.textBox5.Text);
                puntero_aplicacion.dp2_ht1 = Convert.ToDouble(puntero_aplicacion.textBox12.Text);
                puntero_aplicacion.dp2_pc1 = Convert.ToDouble(puntero_aplicacion.textBox11.Text);
                puntero_aplicacion.dp2_phx1 = Convert.ToDouble(puntero_aplicacion.textBox10.Text);
                puntero_aplicacion.dp2_rhx1 = Convert.ToDouble(puntero_aplicacion.textBox9.Text);
                puntero_aplicacion.dp2_lt2 = Convert.ToDouble(puntero_aplicacion.textBox26.Text);
                puntero_aplicacion.dp2_ht2 = Convert.ToDouble(puntero_aplicacion.textBox25.Text);
                puntero_aplicacion.dp2_cooler2 = Convert.ToDouble(puntero_aplicacion.textBox27.Text);
                puntero_aplicacion.ua_lt2 = Convert.ToDouble(puntero_aplicacion.textBox17.Text);
                puntero_aplicacion.ua_ht2 = Convert.ToDouble(puntero_aplicacion.textBox16.Text);
                puntero_aplicacion.recomp_frac2 = Convert.ToDouble(puntero_aplicacion.textBox15.Text);
                puntero_aplicacion.eta_mc2 = Convert.ToDouble(puntero_aplicacion.textBox14.Text);
                puntero_aplicacion.eta_rc2 = Convert.ToDouble(puntero_aplicacion.textBox13.Text);
                puntero_aplicacion.eta_pc2 = Convert.ToDouble(puntero_aplicacion.textBox24.Text);
                puntero_aplicacion.eta_t2 = Convert.ToDouble(puntero_aplicacion.textBox19.Text);
                puntero_aplicacion.eta_trh2 = Convert.ToDouble(puntero_aplicacion.textBox18.Text);
                puntero_aplicacion.n_sub_hxrs2 = Convert.ToInt64(puntero_aplicacion.textBox20.Text);
                puntero_aplicacion.tol2 = Convert.ToDouble(puntero_aplicacion.textBox21.Text);

                puntero_aplicacion.luis.wmm = puntero_aplicacion.luis.working_fluid.MolecularWeight;

                core.PCRCwithReheating cicloPCRC_withRH = new core.PCRCwithReheating();

                double UA_Total = puntero_aplicacion.ua_lt2 + puntero_aplicacion.ua_ht2;

                double LT_fraction = 0.1;

                int counter = 0;

                List<Double> recomp_frac2_list = new List<Double>();
                List<Double> p_pc_in2_list = new List<Double>();
                List<Double> p_pc_out2_list = new List<Double>();
                List<Double> p_rhx_in2_list = new List<Double>();
                List<Double> eta_thermal2_list = new List<Double>();

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

                xlWorkSheet1.Cells[1, 1] = puntero_aplicacion.comboBox2.Text + ":" + puntero_aplicacion.textBox35.Text + "," + puntero_aplicacion.comboBox16.Text + ":" + puntero_aplicacion.textBox36.Text + "," + puntero_aplicacion.comboBox18.Text + ":" + puntero_aplicacion.textBox87.Text + "," + puntero_aplicacion.comboBox17.Text + ":" + puntero_aplicacion.textBox88.Text;
                xlWorkSheet1.Cells[1, 2] = "Pcrit(kPa)";
                xlWorkSheet1.Cells[1, 3] = "Tcrit(ºC)";

                xlWorkSheet1.Cells[2, 1] = "";
                xlWorkSheet1.Cells[2, 2] = Convert.ToString(puntero_aplicacion.MixtureCriticalPressure);
                xlWorkSheet1.Cells[2, 3] = Convert.ToString(puntero_aplicacion.MixtureCriticalTemperature - 273.15);

                xlWorkSheet1.Cells[3, 1] = "";
                xlWorkSheet1.Cells[3, 2] = "";
                xlWorkSheet1.Cells[4, 3] = "";

                xlWorkSheet1.Cells[4, 1] = "PC_in(kPa)";
                xlWorkSheet1.Cells[4, 2] = "PC_out(kPa)";
                xlWorkSheet1.Cells[4, 3] = "CIT(K)";
                xlWorkSheet1.Cells[4, 4] = "LT UA(kW/K)";
                xlWorkSheet1.Cells[4, 5] = "HT UA(kW/K)";
                xlWorkSheet1.Cells[4, 6] = "Rec.Frac.";
                xlWorkSheet1.Cells[4, 7] = "P_rhx(kPa)";
                xlWorkSheet1.Cells[4, 8] = "Eff.(%)";
                xlWorkSheet1.Cells[4, 9] = "LTR Eff.(%)";
                xlWorkSheet1.Cells[4, 10] = "LTR Pinch(ºC)";
                xlWorkSheet1.Cells[4, 11] = "HTR Eff.(%)";
                xlWorkSheet1.Cells[4, 12] = "HTR Pinch(ºC)";

                using (var solver = new NLoptSolver(algorithm_type, 4, 0.01, 10000))
                {
                    solver.SetLowerBounds(new[] { 0.0, initial_CIP_value, (initial_CIP_value + 500), 11000});
                    solver.SetUpperBounds(new[] { 1.0, 125000, (puntero_aplicacion.p_mc_out2 / 1.5), 18000 });

                    solver.SetInitialStepSize(new[] { 0.05, 100, 100, 500 });

                    var initialValue = new[] { 0.2, initial_CIP_value, (initial_CIP_value + 500), 11000 };

                    Func<double[], double> funcion = delegate (double[] variables)
                    {
                        puntero_aplicacion.luis.RecompCycle_PCRC_with_Reheating(puntero_aplicacion.luis, ref cicloPCRC_withRH, puntero_aplicacion.w_dot_net2,
                        puntero_aplicacion.t_mc_in2, puntero_aplicacion.t_t_in2, puntero_aplicacion.t_rht_in2, variables[3], puntero_aplicacion.p_mc_in2, puntero_aplicacion.p_mc_out2, variables[1], puntero_aplicacion.t_pc_in2, variables[2],
                        puntero_aplicacion.ua_lt2, puntero_aplicacion.ua_ht2, puntero_aplicacion.eta_mc2, puntero_aplicacion.eta_rc2, puntero_aplicacion.eta_pc2, puntero_aplicacion.eta_t2, puntero_aplicacion.eta_trh2, puntero_aplicacion.n_sub_hxrs2,
                        variables[0], puntero_aplicacion.tol2, puntero_aplicacion.eta_thermal2, -puntero_aplicacion.dp2_lt1, -puntero_aplicacion.dp2_lt2, -puntero_aplicacion.dp2_ht1, -puntero_aplicacion.dp2_ht2,
                        -puntero_aplicacion.dp2_pc1, -puntero_aplicacion.dp2_pc2, -puntero_aplicacion.dp2_phx1, -puntero_aplicacion.dp2_phx2, -puntero_aplicacion.dp2_rhx1, -puntero_aplicacion.dp2_rhx2, -puntero_aplicacion.dp2_cooler1, -puntero_aplicacion.dp2_cooler2);

                        counter++;

                        puntero_aplicacion.massflow2 = cicloPCRC_withRH.m_dot_turbine;
                        puntero_aplicacion.w_dot_net2 = cicloPCRC_withRH.W_dot_net;
                        puntero_aplicacion.eta_thermal2 = cicloPCRC_withRH.eta_thermal;
                        puntero_aplicacion.recomp_frac2 = variables[0];
                        puntero_aplicacion.p_pc_in2 = variables[1];
                        puntero_aplicacion.p_pc_out2 = variables[2];
                        puntero_aplicacion.p_rhx_in2 = variables[3];

                        puntero_aplicacion.temp21 = cicloPCRC_withRH.temp[0];
                        puntero_aplicacion.temp22 = cicloPCRC_withRH.temp[1];
                        puntero_aplicacion.temp23 = cicloPCRC_withRH.temp[2];
                        puntero_aplicacion.temp24 = cicloPCRC_withRH.temp[3];
                        puntero_aplicacion.temp25 = cicloPCRC_withRH.temp[4];
                        puntero_aplicacion.temp26 = cicloPCRC_withRH.temp[5];
                        puntero_aplicacion.temp27 = cicloPCRC_withRH.temp[6];
                        puntero_aplicacion.temp28 = cicloPCRC_withRH.temp[7];
                        puntero_aplicacion.temp29 = cicloPCRC_withRH.temp[8];
                        puntero_aplicacion.temp210 = cicloPCRC_withRH.temp[9];
                        puntero_aplicacion.temp211 = cicloPCRC_withRH.temp[10];
                        puntero_aplicacion.temp212 = cicloPCRC_withRH.temp[11];
                        puntero_aplicacion.temp213 = cicloPCRC_withRH.temp[12];
                        puntero_aplicacion.temp214 = cicloPCRC_withRH.temp[13];

                        puntero_aplicacion.pres21 = cicloPCRC_withRH.pres[0];
                        puntero_aplicacion.pres22 = cicloPCRC_withRH.pres[1];
                        puntero_aplicacion.pres23 = cicloPCRC_withRH.pres[2];
                        puntero_aplicacion.pres24 = cicloPCRC_withRH.pres[3];
                        puntero_aplicacion.pres25 = cicloPCRC_withRH.pres[4];
                        puntero_aplicacion.pres26 = cicloPCRC_withRH.pres[5];
                        puntero_aplicacion.pres27 = cicloPCRC_withRH.pres[6];
                        puntero_aplicacion.pres28 = cicloPCRC_withRH.pres[7];
                        puntero_aplicacion.pres29 = cicloPCRC_withRH.pres[8];
                        puntero_aplicacion.pres210 = cicloPCRC_withRH.pres[9];
                        puntero_aplicacion.pres211 = cicloPCRC_withRH.pres[10];
                        puntero_aplicacion.pres212 = cicloPCRC_withRH.pres[11];
                        puntero_aplicacion.pres213 = cicloPCRC_withRH.pres[12];
                        puntero_aplicacion.pres214 = cicloPCRC_withRH.pres[13];

                        puntero_aplicacion.PHX1 = cicloPCRC_withRH.PHX.Q_dot;
                        puntero_aplicacion.RHX1 = cicloPCRC_withRH.RHX.Q_dot;

                        puntero_aplicacion.LT_Q = cicloPCRC_withRH.LT.Q_dot;
                        puntero_aplicacion.LT_mdotc = cicloPCRC_withRH.LT.m_dot_design[0];
                        puntero_aplicacion.LT_mdoth = cicloPCRC_withRH.LT.m_dot_design[1];
                        puntero_aplicacion.LT_Tcin = cicloPCRC_withRH.LT.T_c_in;
                        puntero_aplicacion.LT_Thin = cicloPCRC_withRH.LT.T_h_in;
                        puntero_aplicacion.LT_Pcin = cicloPCRC_withRH.LT.P_c_in;
                        puntero_aplicacion.LT_Phin = cicloPCRC_withRH.LT.P_h_in;
                        puntero_aplicacion.LT_Pcout = cicloPCRC_withRH.LT.P_c_out;
                        puntero_aplicacion.LT_Phout = cicloPCRC_withRH.LT.P_h_out;
                        puntero_aplicacion.LT_Effc = cicloPCRC_withRH.LT.eff;

                        puntero_aplicacion.HT_Q = cicloPCRC_withRH.HT.Q_dot;
                        puntero_aplicacion.HT_mdotc = cicloPCRC_withRH.HT.m_dot_design[0];
                        puntero_aplicacion.HT_mdoth = cicloPCRC_withRH.HT.m_dot_design[1];
                        puntero_aplicacion.HT_Tcin = cicloPCRC_withRH.HT.T_c_in;
                        puntero_aplicacion.HT_Thin = cicloPCRC_withRH.HT.T_h_in;
                        puntero_aplicacion.HT_Pcin = cicloPCRC_withRH.HT.P_c_in;
                        puntero_aplicacion.HT_Phin = cicloPCRC_withRH.HT.P_h_in;
                        puntero_aplicacion.HT_Pcout = cicloPCRC_withRH.HT.P_c_out;
                        puntero_aplicacion.HT_Phout = cicloPCRC_withRH.HT.P_h_out;
                        puntero_aplicacion.HT_Effc = cicloPCRC_withRH.HT.eff;

                        puntero_aplicacion.PC1 = -cicloPCRC_withRH.PC.Q_dot;
                        puntero_aplicacion.COOLER1 = -cicloPCRC_withRH.COOLER.Q_dot;
                        
                        eta_thermal2_list.Add(puntero_aplicacion.eta_thermal2);
                        recomp_frac2_list.Add(puntero_aplicacion.recomp_frac2);
                        p_pc_in2_list.Add(puntero_aplicacion.p_pc_in2);
                        p_pc_out2_list.Add(puntero_aplicacion.p_pc_out2);
                        p_rhx_in2_list.Add(puntero_aplicacion.p_rhx_in2);

                        listBox1.Items.Add(counter.ToString());
                        listBox2.Items.Add(puntero_aplicacion.eta_thermal2.ToString());
                        listBox3.Items.Add(puntero_aplicacion.recomp_frac2.ToString());
                        listBox4.Items.Add(puntero_aplicacion.p_pc_in2.ToString());
                        listBox9.Items.Add(puntero_aplicacion.p_pc_out2.ToString());
                        listBox19.Items.Add(puntero_aplicacion.p_rhx_in2.ToString());
                        listBox5.Items.Add(puntero_aplicacion.ua_lt2.ToString());
                        listBox6.Items.Add(puntero_aplicacion.ua_ht2.ToString());
                        listBox7.Items.Add(puntero_aplicacion.temp27.ToString());
                        listBox8.Items.Add(puntero_aplicacion.temp28.ToString());

                        double LTR_min_DT_1 = cicloPCRC_withRH.temp[7] - cicloPCRC_withRH.temp[2];
                        double LTR_min_DT_2 = cicloPCRC_withRH.temp[8] - cicloPCRC_withRH.temp[1];
                        double LTR_min_DT_paper = Math.Min(LTR_min_DT_1, LTR_min_DT_2);

                        double HTR_min_DT_1 = cicloPCRC_withRH.temp[7] - cicloPCRC_withRH.temp[3];
                        double HTR_min_DT_2 = cicloPCRC_withRH.temp[6] - cicloPCRC_withRH.temp[4];
                        double HTR_min_DT_paper = Math.Min(HTR_min_DT_1, HTR_min_DT_2);

                        //PC_in(kPa)
                        xlWorkSheet1.Cells[counter_Excel + 1, 1] = Convert.ToString(puntero_aplicacion.p_pc_in2);
                        //PC_out(kPa)
                        xlWorkSheet1.Cells[counter_Excel + 1, 2] = Convert.ToString(puntero_aplicacion.p_pc_out2);
                        //CIT
                        xlWorkSheet1.Cells[counter_Excel + 1, 3] = Convert.ToString(puntero_aplicacion.t_mc_in2 - 273.15);
                        //LT UA(kW/K)
                        xlWorkSheet1.Cells[counter_Excel + 1, 4] = Convert.ToString(puntero_aplicacion.ua_lt2);
                        //HT UA(kW/K)
                        xlWorkSheet1.Cells[counter_Excel + 1, 5] = Convert.ToString(puntero_aplicacion.ua_ht2);
                        //Rec.Frac.
                        xlWorkSheet1.Cells[counter_Excel + 1, 6] = puntero_aplicacion.recomp_frac2.ToString();
                        //P_rhx_in
                        xlWorkSheet1.Cells[counter_Excel + 1, 7] = puntero_aplicacion.p_rhx_in2.ToString();
                        //Eff.(%)
                        xlWorkSheet1.Cells[counter_Excel + 1, 8] = (puntero_aplicacion.eta_thermal2 * 100).ToString();
                        //LTR Eff.(%)
                        xlWorkSheet1.Cells[counter_Excel + 1, 9] = cicloPCRC_withRH.LT.eff.ToString();
                        //LTR Pinch(ºC)
                        xlWorkSheet1.Cells[counter_Excel + 1, 10] = LTR_min_DT_paper.ToString();
                        //HTR Eff.(%)
                        xlWorkSheet1.Cells[counter_Excel + 1, 11] = cicloPCRC_withRH.HT.eff.ToString();
                        //HTR Pinch(ºC)
                        xlWorkSheet1.Cells[counter_Excel + 1, 12] = HTR_min_DT_paper.ToString();
                       
                        counter_Excel++;

                        return puntero_aplicacion.eta_thermal2;
                    };

                    solver.SetMaxObjective(funcion);

                    double? finalScore;

                    var result = solver.Optimize(initialValue, out finalScore);

                    Double max_eta_thermal = 0.0;

                    max_eta_thermal = eta_thermal2_list.Max();

                    var maxIndex = eta_thermal2_list.IndexOf(eta_thermal2_list.Max());

                    textBox91.Text = p_pc_in2_list[maxIndex].ToString();
                    textBox2.Text = p_pc_out2_list[maxIndex].ToString();
                    textBox3.Text = p_rhx_in2_list[maxIndex].ToString();
                    textBox90.Text = recomp_frac2_list[maxIndex].ToString();
                    textBox86.Text = eta_thermal2_list[maxIndex].ToString();

                    //Copy results as design-point inputs
                    if (checkBox3.Checked == true)
                    {
                        puntero_aplicacion.textBox15.Text = recomp_frac2_list[maxIndex].ToString();
                        puntero_aplicacion.textBox23.Text = p_pc_in2_list[maxIndex].ToString();
                        puntero_aplicacion.textBox8.Text = p_pc_out2_list[maxIndex].ToString();
                        puntero_aplicacion.textBox3.Text = p_pc_out2_list[maxIndex].ToString();
                        puntero_aplicacion.textBox7.Text = p_rhx_in2_list[maxIndex].ToString();
                    }

                    //Closing Excel Book
                    xlWorkBook1.SaveAs(textBox4.Text + "PCRC_with_ReHeating_" + xlWorkSheet1.Name + ".xls", Excel.XlFileFormat.xlWorkbookNormal, misValue1, misValue1, misValue1, misValue1, Excel.XlSaveAsAccessMode.xlExclusive, misValue1, misValue1, misValue1, misValue1, misValue1);

                    xlWorkBook1.Close(true, misValue1, misValue1);
                    xlApp1.Quit();

                    releaseObject(xlWorkSheet1);
                    //releaseObject(xlWorkSheet2);
                    releaseObject(xlWorkBook1);
                    releaseObject(xlApp1);
                }
            }

            //-------------------------------------------------------------------------

            //UA optimization true
            else if (checkBox2.Checked == true)
            {
                //PureFluid
                if (puntero_aplicacion.comboBox1.Text == "PureFluid")
                {
                    puntero_aplicacion.category = RefrigerantCategory.PureFluid;
                    puntero_aplicacion.luis.core1(puntero_aplicacion.comboBox2.Text, puntero_aplicacion.category);
                }

                //NewMixture
                if (puntero_aplicacion.comboBox1.Text == "NewMixture")
                {
                    puntero_aplicacion.category = RefrigerantCategory.NewMixture;
                    puntero_aplicacion.luis.core1(puntero_aplicacion.comboBox2.Text + "=" + puntero_aplicacion.textBox35.Text + "," + puntero_aplicacion.comboBox16.Text + "=" + puntero_aplicacion.textBox36.Text + "," + puntero_aplicacion.comboBox18.Text + "=" + puntero_aplicacion.textBox87.Text + "," + puntero_aplicacion.comboBox17.Text + "=" + puntero_aplicacion.textBox88.Text, puntero_aplicacion.category);
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

                puntero_aplicacion.w_dot_net2 = Convert.ToDouble(puntero_aplicacion.textBox1.Text);
                puntero_aplicacion.t_mc_in2 = Convert.ToDouble(puntero_aplicacion.textBox2.Text);
                puntero_aplicacion.t_t_in2 = Convert.ToDouble(puntero_aplicacion.textBox4.Text);
                puntero_aplicacion.p_mc_in2 = Convert.ToDouble(puntero_aplicacion.textBox3.Text);
                puntero_aplicacion.p_mc_out2 = Convert.ToDouble(puntero_aplicacion.textBox28.Text);
                puntero_aplicacion.p_pc_in2 = Convert.ToDouble(puntero_aplicacion.textBox23.Text);
                puntero_aplicacion.p_pc_out2 = Convert.ToDouble(puntero_aplicacion.textBox8.Text);
                puntero_aplicacion.t_pc_in2 = Convert.ToDouble(puntero_aplicacion.textBox22.Text);
                puntero_aplicacion.p_rhx_in2 = Convert.ToDouble(puntero_aplicacion.textBox7.Text);
                puntero_aplicacion.t_rht_in2 = Convert.ToDouble(puntero_aplicacion.textBox6.Text);
                puntero_aplicacion.dp2_lt1 = Convert.ToDouble(puntero_aplicacion.textBox5.Text);
                puntero_aplicacion.dp2_ht1 = Convert.ToDouble(puntero_aplicacion.textBox12.Text);
                puntero_aplicacion.dp2_pc1 = Convert.ToDouble(puntero_aplicacion.textBox11.Text);
                puntero_aplicacion.dp2_phx1 = Convert.ToDouble(puntero_aplicacion.textBox10.Text);
                puntero_aplicacion.dp2_rhx1 = Convert.ToDouble(puntero_aplicacion.textBox9.Text);
                puntero_aplicacion.dp2_lt2 = Convert.ToDouble(puntero_aplicacion.textBox26.Text);
                puntero_aplicacion.dp2_ht2 = Convert.ToDouble(puntero_aplicacion.textBox25.Text);
                puntero_aplicacion.dp2_cooler2 = Convert.ToDouble(puntero_aplicacion.textBox27.Text);
                puntero_aplicacion.ua_lt2 = Convert.ToDouble(puntero_aplicacion.textBox17.Text);
                puntero_aplicacion.ua_ht2 = Convert.ToDouble(puntero_aplicacion.textBox16.Text);
                puntero_aplicacion.recomp_frac2 = Convert.ToDouble(puntero_aplicacion.textBox15.Text);
                puntero_aplicacion.eta_mc2 = Convert.ToDouble(puntero_aplicacion.textBox14.Text);
                puntero_aplicacion.eta_rc2 = Convert.ToDouble(puntero_aplicacion.textBox13.Text);
                puntero_aplicacion.eta_pc2 = Convert.ToDouble(puntero_aplicacion.textBox24.Text);
                puntero_aplicacion.eta_t2 = Convert.ToDouble(puntero_aplicacion.textBox19.Text);
                puntero_aplicacion.eta_trh2 = Convert.ToDouble(puntero_aplicacion.textBox18.Text);
                puntero_aplicacion.n_sub_hxrs2 = Convert.ToInt64(puntero_aplicacion.textBox20.Text);
                puntero_aplicacion.tol2 = Convert.ToDouble(puntero_aplicacion.textBox21.Text);

                puntero_aplicacion.luis.wmm = puntero_aplicacion.luis.working_fluid.MolecularWeight;

                core.PCRCwithReheating cicloPCRC_withRH = new core.PCRCwithReheating();

                double UA_Total = puntero_aplicacion.ua_lt2 + puntero_aplicacion.ua_ht2;

                double LT_fraction = 0.1;

                int counter = 0;

                List<Double> recomp_frac2_list = new List<Double>();
                List<Double> p_pc_in2_list = new List<Double>();
                List<Double> p_pc_out2_list = new List<Double>();
                List<Double> p_rhx_in2_list = new List<Double>();
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

                xlWorkSheet1.Cells[1, 1] = puntero_aplicacion.comboBox2.Text + ":" + puntero_aplicacion.textBox35.Text + "," + puntero_aplicacion.comboBox16.Text + ":" + puntero_aplicacion.textBox36.Text + "," + puntero_aplicacion.comboBox18.Text + ":" + puntero_aplicacion.textBox87.Text + "," + puntero_aplicacion.comboBox17.Text + ":" + puntero_aplicacion.textBox88.Text;
                xlWorkSheet1.Cells[1, 2] = "Pcrit(kPa)";
                xlWorkSheet1.Cells[1, 3] = "Tcrit(ºC)";

                xlWorkSheet1.Cells[2, 1] = "";
                xlWorkSheet1.Cells[2, 2] = Convert.ToString(puntero_aplicacion.MixtureCriticalPressure);
                xlWorkSheet1.Cells[2, 3] = Convert.ToString(puntero_aplicacion.MixtureCriticalTemperature - 273.15);

                xlWorkSheet1.Cells[3, 1] = "";
                xlWorkSheet1.Cells[3, 2] = "";
                xlWorkSheet1.Cells[4, 3] = "";

                xlWorkSheet1.Cells[4, 1] = "PC_in(kPa)";
                xlWorkSheet1.Cells[4, 2] = "PC_out(kPa)";
                xlWorkSheet1.Cells[4, 3] = "CIT(K)";
                xlWorkSheet1.Cells[4, 4] = "LT UA(kW/K)";
                xlWorkSheet1.Cells[4, 5] = "HT UA(kW/K)";
                xlWorkSheet1.Cells[4, 6] = "Rec.Frac.";
                xlWorkSheet1.Cells[4, 7] = "P_rhx(kPa)";
                xlWorkSheet1.Cells[4, 8] = "Eff.(%)";
                xlWorkSheet1.Cells[4, 9] = "LTR Eff.(%)";
                xlWorkSheet1.Cells[4, 10] = "LTR Pinch(ºC)";
                xlWorkSheet1.Cells[4, 11] = "HTR Eff.(%)";
                xlWorkSheet1.Cells[4, 12] = "HTR Pinch(ºC)";             

                using (var solver = new NLoptSolver(algorithm_type, 5, 0.01, 10000))
                {
                    solver.SetLowerBounds(new[] { 0.0, initial_CIP_value, (initial_CIP_value + 500), 11000, 0.2 });
                    solver.SetUpperBounds(new[] { 1.0, 125000, (puntero_aplicacion.p_mc_out2 / 1.5), 18000, 0.8 });

                    solver.SetInitialStepSize(new[] { 0.05, 100, 100, 500, 0.05 });

                    var initialValue = new[] { 0.2, initial_CIP_value, (initial_CIP_value + 500), 11000, 0.5 };

                    Func<double[], double> funcion = delegate (double[] variables)
                    {
                        puntero_aplicacion.luis.RecompCycle_PCRC_with_Reheating_for_Optimization(puntero_aplicacion.luis, ref cicloPCRC_withRH, puntero_aplicacion.w_dot_net2,
                        puntero_aplicacion.t_mc_in2, puntero_aplicacion.t_t_in2, puntero_aplicacion.t_rht_in2, variables[3], variables[2], puntero_aplicacion.p_mc_out2, variables[1], puntero_aplicacion.t_pc_in2, variables[2],
                        variables[4], UA_Total, puntero_aplicacion.eta_mc2, puntero_aplicacion.eta_rc2, puntero_aplicacion.eta_pc2, puntero_aplicacion.eta_t2, puntero_aplicacion.eta_trh2, puntero_aplicacion.n_sub_hxrs2,
                        variables[0], puntero_aplicacion.tol2, puntero_aplicacion.eta_thermal2, -puntero_aplicacion.dp2_lt1, -puntero_aplicacion.dp2_lt2, -puntero_aplicacion.dp2_ht1, -puntero_aplicacion.dp2_ht2,
                        -puntero_aplicacion.dp2_pc1, -puntero_aplicacion.dp2_pc2, -puntero_aplicacion.dp2_phx1, -puntero_aplicacion.dp2_phx2, -puntero_aplicacion.dp2_rhx1, -puntero_aplicacion.dp2_rhx2, -puntero_aplicacion.dp2_cooler1, -puntero_aplicacion.dp2_cooler2);

                        counter++;

                        puntero_aplicacion.massflow2 = cicloPCRC_withRH.m_dot_turbine;
                        puntero_aplicacion.w_dot_net2 = cicloPCRC_withRH.W_dot_net;

                        puntero_aplicacion.eta_thermal2 = cicloPCRC_withRH.eta_thermal;
                        puntero_aplicacion.recomp_frac2 = variables[0];
                        puntero_aplicacion.p_pc_in2 = variables[1];
                        puntero_aplicacion.p_pc_out2 = variables[2];
                        puntero_aplicacion.p_rhx_in2 = variables[3];
                        LT_fraction = variables[4];
                        puntero_aplicacion.ua_lt2 = UA_Total * LT_fraction;
                        puntero_aplicacion.ua_ht2 = UA_Total * (1 - LT_fraction);

                        puntero_aplicacion.temp21 = cicloPCRC_withRH.temp[0];
                        puntero_aplicacion.temp22 = cicloPCRC_withRH.temp[1];
                        puntero_aplicacion.temp23 = cicloPCRC_withRH.temp[2];
                        puntero_aplicacion.temp24 = cicloPCRC_withRH.temp[3];
                        puntero_aplicacion.temp25 = cicloPCRC_withRH.temp[4];
                        puntero_aplicacion.temp26 = cicloPCRC_withRH.temp[5];
                        puntero_aplicacion.temp27 = cicloPCRC_withRH.temp[6];
                        puntero_aplicacion.temp28 = cicloPCRC_withRH.temp[7];
                        puntero_aplicacion.temp29 = cicloPCRC_withRH.temp[8];
                        puntero_aplicacion.temp210 = cicloPCRC_withRH.temp[9];
                        puntero_aplicacion.temp211 = cicloPCRC_withRH.temp[10];
                        puntero_aplicacion.temp212 = cicloPCRC_withRH.temp[11];
                        puntero_aplicacion.temp213 = cicloPCRC_withRH.temp[12];
                        puntero_aplicacion.temp214 = cicloPCRC_withRH.temp[13];

                        puntero_aplicacion.pres21 = cicloPCRC_withRH.pres[0];
                        puntero_aplicacion.pres22 = cicloPCRC_withRH.pres[1];
                        puntero_aplicacion.pres23 = cicloPCRC_withRH.pres[2];
                        puntero_aplicacion.pres24 = cicloPCRC_withRH.pres[3];
                        puntero_aplicacion.pres25 = cicloPCRC_withRH.pres[4];
                        puntero_aplicacion.pres26 = cicloPCRC_withRH.pres[5];
                        puntero_aplicacion.pres27 = cicloPCRC_withRH.pres[6];
                        puntero_aplicacion.pres28 = cicloPCRC_withRH.pres[7];
                        puntero_aplicacion.pres29 = cicloPCRC_withRH.pres[8];
                        puntero_aplicacion.pres210 = cicloPCRC_withRH.pres[9];
                        puntero_aplicacion.pres211 = cicloPCRC_withRH.pres[10];
                        puntero_aplicacion.pres212 = cicloPCRC_withRH.pres[11];
                        puntero_aplicacion.pres213 = cicloPCRC_withRH.pres[12];
                        puntero_aplicacion.pres214 = cicloPCRC_withRH.pres[13];

                        puntero_aplicacion.PHX1 = cicloPCRC_withRH.PHX.Q_dot;
                        puntero_aplicacion.RHX1 = cicloPCRC_withRH.RHX.Q_dot;

                        puntero_aplicacion.LT_Q = cicloPCRC_withRH.LT.Q_dot;
                        puntero_aplicacion.LT_mdotc = cicloPCRC_withRH.LT.m_dot_design[0];
                        puntero_aplicacion.LT_mdoth = cicloPCRC_withRH.LT.m_dot_design[1];
                        puntero_aplicacion.LT_Tcin = cicloPCRC_withRH.LT.T_c_in;
                        puntero_aplicacion.LT_Thin = cicloPCRC_withRH.LT.T_h_in;
                        puntero_aplicacion.LT_Pcin = cicloPCRC_withRH.LT.P_c_in;
                        puntero_aplicacion.LT_Phin = cicloPCRC_withRH.LT.P_h_in;
                        puntero_aplicacion.LT_Pcout = cicloPCRC_withRH.LT.P_c_out;
                        puntero_aplicacion.LT_Phout = cicloPCRC_withRH.LT.P_h_out;
                        puntero_aplicacion.LT_Effc = cicloPCRC_withRH.LT.eff;

                        puntero_aplicacion.HT_Q = cicloPCRC_withRH.HT.Q_dot;
                        puntero_aplicacion.HT_mdotc = cicloPCRC_withRH.HT.m_dot_design[0];
                        puntero_aplicacion.HT_mdoth = cicloPCRC_withRH.HT.m_dot_design[1];
                        puntero_aplicacion.HT_Tcin = cicloPCRC_withRH.HT.T_c_in;
                        puntero_aplicacion.HT_Thin = cicloPCRC_withRH.HT.T_h_in;
                        puntero_aplicacion.HT_Pcin = cicloPCRC_withRH.HT.P_c_in;
                        puntero_aplicacion.HT_Phin = cicloPCRC_withRH.HT.P_h_in;
                        puntero_aplicacion.HT_Pcout = cicloPCRC_withRH.HT.P_c_out;
                        puntero_aplicacion.HT_Phout = cicloPCRC_withRH.HT.P_h_out;
                        puntero_aplicacion.HT_Effc = cicloPCRC_withRH.HT.eff;

                        puntero_aplicacion.PC1 = -cicloPCRC_withRH.PC.Q_dot;
                        puntero_aplicacion.COOLER1 = -cicloPCRC_withRH.COOLER.Q_dot;
                                               
                        eta_thermal2_list.Add(puntero_aplicacion.eta_thermal2);
                        recomp_frac2_list.Add(puntero_aplicacion.recomp_frac2);
                        p_pc_in2_list.Add(puntero_aplicacion.p_pc_in2);
                        p_pc_out2_list.Add(puntero_aplicacion.p_pc_out2);
                        p_rhx_in2_list.Add(puntero_aplicacion.p_rhx_in2);
                        ua_LT_list.Add(puntero_aplicacion.ua_lt2);
                        ua_HT_list.Add(puntero_aplicacion.ua_ht2);

                        listBox1.Items.Add(counter.ToString());
                        listBox2.Items.Add(puntero_aplicacion.eta_thermal2.ToString());
                        listBox3.Items.Add(puntero_aplicacion.recomp_frac2.ToString());
                        listBox4.Items.Add(puntero_aplicacion.p_pc_in2.ToString());
                        listBox9.Items.Add(puntero_aplicacion.p_pc_out2.ToString());
                        listBox19.Items.Add(puntero_aplicacion.p_rhx_in2.ToString());
                        listBox5.Items.Add(puntero_aplicacion.ua_lt2.ToString());
                        listBox6.Items.Add(puntero_aplicacion.ua_ht2.ToString());
                        listBox7.Items.Add(puntero_aplicacion.temp27.ToString());
                        listBox8.Items.Add(puntero_aplicacion.temp28.ToString());

                        double LTR_min_DT_1 = cicloPCRC_withRH.temp[7] - cicloPCRC_withRH.temp[2];
                        double LTR_min_DT_2 = cicloPCRC_withRH.temp[8] - cicloPCRC_withRH.temp[1];
                        double LTR_min_DT_paper = Math.Min(LTR_min_DT_1, LTR_min_DT_2);

                        double HTR_min_DT_1 = cicloPCRC_withRH.temp[7] - cicloPCRC_withRH.temp[3];
                        double HTR_min_DT_2 = cicloPCRC_withRH.temp[6] - cicloPCRC_withRH.temp[4];
                        double HTR_min_DT_paper = Math.Min(HTR_min_DT_1, HTR_min_DT_2);

                        //PC_in(kPa)
                        xlWorkSheet1.Cells[counter_Excel + 1, 1] = Convert.ToString(puntero_aplicacion.p_pc_in2);
                        //PC_out(kPa)
                        xlWorkSheet1.Cells[counter_Excel + 1, 2] = Convert.ToString(puntero_aplicacion.p_pc_out2);
                        //CIT
                        xlWorkSheet1.Cells[counter_Excel + 1, 3] = Convert.ToString(puntero_aplicacion.t_mc_in2 - 273.15);
                        //LT UA(kW/K)
                        xlWorkSheet1.Cells[counter_Excel + 1, 4] = Convert.ToString(puntero_aplicacion.ua_lt2);
                        //HT UA(kW/K)
                        xlWorkSheet1.Cells[counter_Excel + 1, 5] = Convert.ToString(puntero_aplicacion.ua_ht2);
                        //Rec.Frac.
                        xlWorkSheet1.Cells[counter_Excel + 1, 6] = puntero_aplicacion.recomp_frac2.ToString();
                        //P_rhx_in
                        xlWorkSheet1.Cells[counter_Excel + 1, 7] = puntero_aplicacion.p_rhx_in2.ToString();
                        //Eff.(%)
                        xlWorkSheet1.Cells[counter_Excel + 1, 8] = (puntero_aplicacion.eta_thermal2 * 100).ToString();
                        //LTR Eff.(%)
                        xlWorkSheet1.Cells[counter_Excel + 1, 9] = cicloPCRC_withRH.LT.eff.ToString();
                        //LTR Pinch(ºC)
                        xlWorkSheet1.Cells[counter_Excel + 1, 10] = LTR_min_DT_paper.ToString();
                        //HTR Eff.(%)
                        xlWorkSheet1.Cells[counter_Excel + 1, 11] = cicloPCRC_withRH.HT.eff.ToString();
                        //HTR Pinch(ºC)
                        xlWorkSheet1.Cells[counter_Excel + 1, 12] = HTR_min_DT_paper.ToString();
                       
                        counter_Excel++;

                        return puntero_aplicacion.eta_thermal2;
                    };

                    solver.SetMaxObjective(funcion);

                    double? finalScore;

                    var result = solver.Optimize(initialValue, out finalScore);

                    Double max_eta_thermal = 0.0;

                    max_eta_thermal = eta_thermal2_list.Max();

                    var maxIndex = eta_thermal2_list.IndexOf(eta_thermal2_list.Max());

                    textBox91.Text = p_pc_in2_list[maxIndex].ToString();
                    textBox2.Text = p_pc_out2_list[maxIndex].ToString();
                    textBox3.Text = p_rhx_in2_list[maxIndex].ToString();
                    textBox90.Text = recomp_frac2_list[maxIndex].ToString();
                    textBox86.Text = eta_thermal2_list[maxIndex].ToString();
                    textBox82.Text = ua_LT_list[maxIndex].ToString();
                    textBox83.Text = ua_HT_list[maxIndex].ToString();

                    //Copy results as design-point inputs
                    if (checkBox3.Checked == true)
                    {
                        puntero_aplicacion.textBox15.Text = recomp_frac2_list[maxIndex].ToString();
                        puntero_aplicacion.textBox23.Text = p_pc_in2_list[maxIndex].ToString();
                        puntero_aplicacion.textBox8.Text = p_pc_out2_list[maxIndex].ToString();
                        puntero_aplicacion.textBox3.Text = p_pc_out2_list[maxIndex].ToString();
                        puntero_aplicacion.textBox7.Text = p_rhx_in2_list[maxIndex].ToString();
                        puntero_aplicacion.textBox17.Text = ua_LT_list[maxIndex].ToString();
                        puntero_aplicacion.textBox16.Text = ua_HT_list[maxIndex].ToString();
                    }

                    //Closing Excel Book
                    xlWorkBook1.SaveAs(textBox4.Text + "PCRC_with_ReHeating_" + xlWorkSheet1.Name + ".xls", Excel.XlFileFormat.xlWorkbookNormal, misValue1, misValue1, misValue1, misValue1, Excel.XlSaveAsAccessMode.xlExclusive, misValue1, misValue1, misValue1, misValue1, misValue1);

                    xlWorkBook1.Close(true, misValue1, misValue1);
                    xlApp1.Quit();

                    releaseObject(xlWorkSheet1);
                    //releaseObject(xlWorkSheet2);
                    releaseObject(xlWorkBook1);
                    releaseObject(xlApp1);
                }
            }
        }

        //Run Design-Point
        private void Button8_Click(object sender, EventArgs e)
        {

        }

        //Run CIT Optimization
        private void Button7_Click(object sender, EventArgs e)
        {
            int counter = 0;

            double initial_pc_in_value = 0;
            double initial_pc_out_value = 0;

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

                    //UA optimization false
                    if (checkBox2.Checked == false)
                    {
                        //PureFluid
                        if (puntero_aplicacion.comboBox1.Text == "PureFluid")
                        {
                            puntero_aplicacion.category = RefrigerantCategory.PureFluid;
                            puntero_aplicacion.luis.core1(puntero_aplicacion.comboBox2.Text, puntero_aplicacion.category);
                        }

                        //NewMixture
                        if (puntero_aplicacion.comboBox1.Text == "NewMixture")
                        {
                            puntero_aplicacion.category = RefrigerantCategory.NewMixture;
                            puntero_aplicacion.luis.core1(puntero_aplicacion.comboBox2.Text + "=" + puntero_aplicacion.textBox35.Text + "," + puntero_aplicacion.comboBox16.Text + "=" + puntero_aplicacion.textBox36.Text + "," + puntero_aplicacion.comboBox18.Text + "=" + puntero_aplicacion.textBox87.Text + "," + puntero_aplicacion.comboBox17.Text + "=" + puntero_aplicacion.textBox88.Text, puntero_aplicacion.category);
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

                        puntero_aplicacion.w_dot_net2 = Convert.ToDouble(puntero_aplicacion.textBox1.Text);
                        puntero_aplicacion.t_mc_in2 = Convert.ToDouble(puntero_aplicacion.textBox2.Text);
                        puntero_aplicacion.t_t_in2 = Convert.ToDouble(puntero_aplicacion.textBox4.Text);
                        puntero_aplicacion.p_mc_in2 = Convert.ToDouble(puntero_aplicacion.textBox3.Text);
                        puntero_aplicacion.p_mc_out2 = Convert.ToDouble(puntero_aplicacion.textBox28.Text);
                        puntero_aplicacion.p_pc_in2 = Convert.ToDouble(puntero_aplicacion.textBox23.Text);
                        puntero_aplicacion.p_pc_out2 = Convert.ToDouble(puntero_aplicacion.textBox8.Text);
                        puntero_aplicacion.t_pc_in2 = Convert.ToDouble(puntero_aplicacion.textBox22.Text);
                        puntero_aplicacion.p_rhx_in2 = Convert.ToDouble(puntero_aplicacion.textBox7.Text);
                        puntero_aplicacion.t_rht_in2 = Convert.ToDouble(puntero_aplicacion.textBox6.Text);
                        puntero_aplicacion.dp2_lt1 = Convert.ToDouble(puntero_aplicacion.textBox5.Text);
                        puntero_aplicacion.dp2_ht1 = Convert.ToDouble(puntero_aplicacion.textBox12.Text);
                        puntero_aplicacion.dp2_pc1 = Convert.ToDouble(puntero_aplicacion.textBox11.Text);
                        puntero_aplicacion.dp2_phx1 = Convert.ToDouble(puntero_aplicacion.textBox10.Text);
                        puntero_aplicacion.dp2_rhx1 = Convert.ToDouble(puntero_aplicacion.textBox9.Text);
                        puntero_aplicacion.dp2_lt2 = Convert.ToDouble(puntero_aplicacion.textBox26.Text);
                        puntero_aplicacion.dp2_ht2 = Convert.ToDouble(puntero_aplicacion.textBox25.Text);
                        puntero_aplicacion.dp2_cooler2 = Convert.ToDouble(puntero_aplicacion.textBox27.Text);
                        //puntero_aplicacion.ua_lt2 = Convert.ToDouble(puntero_aplicacion.textBox17.Text);
                        //puntero_aplicacion.ua_ht2 = Convert.ToDouble(puntero_aplicacion.textBox16.Text);
                        puntero_aplicacion.recomp_frac2 = Convert.ToDouble(puntero_aplicacion.textBox15.Text);
                        puntero_aplicacion.eta_mc2 = Convert.ToDouble(puntero_aplicacion.textBox14.Text);
                        puntero_aplicacion.eta_rc2 = Convert.ToDouble(puntero_aplicacion.textBox13.Text);
                        puntero_aplicacion.eta_pc2 = Convert.ToDouble(puntero_aplicacion.textBox24.Text);
                        puntero_aplicacion.eta_t2 = Convert.ToDouble(puntero_aplicacion.textBox19.Text);
                        puntero_aplicacion.eta_trh2 = Convert.ToDouble(puntero_aplicacion.textBox18.Text);
                        puntero_aplicacion.n_sub_hxrs2 = Convert.ToInt64(puntero_aplicacion.textBox20.Text);
                        puntero_aplicacion.tol2 = Convert.ToDouble(puntero_aplicacion.textBox21.Text);

                        puntero_aplicacion.luis.wmm = puntero_aplicacion.luis.working_fluid.MolecularWeight;

                        core.PCRCwithReheating cicloPCRC_withRH = new core.PCRCwithReheating();

                        double UA_Total = puntero_aplicacion.ua_lt2 + puntero_aplicacion.ua_ht2;

                        double LT_fraction = 0.1;

                        List<Double> recomp_frac2_list = new List<Double>();
                        List<Double> p_pc_in2_list = new List<Double>();
                        List<Double> p_pc_out2_list = new List<Double>();
                        List<Double> p_rhx_in2_list = new List<Double>();
                        List<Double> eta_thermal2_list = new List<Double>();
                        List<Double> massflow2_list = new List<Double>();
                        List<Double> ua_lt2_list = new List<Double>();
                        List<Double> ua_ht2_list = new List<Double>();

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

                        List<Double> HT_Eff_list = new List<Double>();
                        List<Double> LT_Eff_list = new List<Double>();

                        List<Double> PHX_Q_list = new List<Double>();
                        List<Double> RHX_Q_list = new List<Double>();

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
                                initial_pc_in_value = Convert.ToDouble(textBox1.Text);
                                initial_pc_out_value = Convert.ToDouble(textBox1.Text) + 500;
                            }
                            else
                            {
                                initial_pc_in_value = puntero_aplicacion.MixtureCriticalPressure;
                                initial_pc_out_value = puntero_aplicacion.MixtureCriticalPressure + 500;
                            }

                            xlWorkSheet1.Name = puntero_aplicacion.comboBox2.Text + " Mixture";

                            xlWorkSheet1.Cells[1, 1] = puntero_aplicacion.comboBox2.Text + ":" + puntero_aplicacion.textBox35.Text + "," + puntero_aplicacion.comboBox16.Text + ":" + puntero_aplicacion.textBox36.Text + "," + puntero_aplicacion.comboBox18.Text + ":" + puntero_aplicacion.textBox87.Text + "," + puntero_aplicacion.comboBox17.Text + ":" + puntero_aplicacion.textBox88.Text;
                            xlWorkSheet1.Cells[1, 2] = "Pcrit(kPa)";
                            xlWorkSheet1.Cells[1, 3] = "Tcrit(ºC)";

                            xlWorkSheet1.Cells[2, 1] = "";
                            xlWorkSheet1.Cells[2, 2] = Convert.ToString(puntero_aplicacion.MixtureCriticalPressure);
                            xlWorkSheet1.Cells[2, 3] = Convert.ToString(puntero_aplicacion.MixtureCriticalTemperature - 273.15);

                            xlWorkSheet1.Cells[3, 1] = "";
                            xlWorkSheet1.Cells[3, 2] = "";
                            xlWorkSheet1.Cells[4, 3] = "";

                            xlWorkSheet1.Cells[4, 1] = "PC_in(kPa)";
                            xlWorkSheet1.Cells[4, 2] = "PC_out(kPa)";
                            xlWorkSheet1.Cells[4, 3] = "CIT(K)";
                            xlWorkSheet1.Cells[4, 4] = "LT UA(kW/K)";
                            xlWorkSheet1.Cells[4, 5] = "HT UA(kW/K)";
                            xlWorkSheet1.Cells[4, 6] = "Rec.Frac.";
                            xlWorkSheet1.Cells[4, 7] = "P_rhx(kPa)";
                            xlWorkSheet1.Cells[4, 8] = "Eff.(%)";
                            xlWorkSheet1.Cells[4, 9] = "LTR Eff.(%)";
                            xlWorkSheet1.Cells[4, 10] = "LTR Pinch(ºC)";
                            xlWorkSheet1.Cells[4, 11] = "HTR Eff.(%)";
                            xlWorkSheet1.Cells[4, 12] = "HTR Pinch(ºC)";

                            xlWorkSheet1.Cells[4, 13] = "PTC_Apperture_Area(m2)";
                            xlWorkSheet1.Cells[4, 14] = "PTC_Pressure_Drop(bar)";
                            xlWorkSheet1.Cells[4, 15] = "LF_Apperture_Area(m2)";
                            xlWorkSheet1.Cells[4, 16] = "LF_Pressure_Drop(bar)";
                            xlWorkSheet1.Cells[4, 17] = "PTC_RHX_Apperture_Area(m2)";
                            xlWorkSheet1.Cells[4, 18] = "PTC_RHX_Pressure_Drop(bar)";
                            xlWorkSheet1.Cells[4, 19] = "LF_RHX_Apperture_Area(m2)";
                            xlWorkSheet1.Cells[4, 20] = "LF_RHX_Pressure_Drop(bar)";
                        }

                        using (var solver = new NLoptSolver(algorithm_type, 4, 0.01, 10000))
                        {
                            solver.SetLowerBounds(new[] { 0.0, initial_pc_in_value, initial_pc_out_value, 11000 });
                            solver.SetUpperBounds(new[] { 1.0, 125000, (puntero_aplicacion.p_mc_out2 / 1.5), 18000 });

                            solver.SetInitialStepSize(new[] { 0.05, 100, 100, 500 });

                            var initialValue = new[] { 0.2, initial_pc_in_value, initial_pc_out_value, 11000 };

                            Func<double[], double> funcion = delegate (double[] variables)
                            {
                                puntero_aplicacion.luis.RecompCycle_PCRC_with_Reheating(puntero_aplicacion.luis, ref cicloPCRC_withRH, puntero_aplicacion.w_dot_net2,
                                i, puntero_aplicacion.t_t_in2, puntero_aplicacion.t_rht_in2, variables[3], puntero_aplicacion.p_mc_in2, puntero_aplicacion.p_mc_out2, variables[1], i, variables[2],
                                puntero_aplicacion.ua_lt2, puntero_aplicacion.ua_ht2, puntero_aplicacion.eta_mc2, puntero_aplicacion.eta_rc2, puntero_aplicacion.eta_pc2, puntero_aplicacion.eta_t2, puntero_aplicacion.eta_trh2, puntero_aplicacion.n_sub_hxrs2,
                                variables[0], puntero_aplicacion.tol2, puntero_aplicacion.eta_thermal2, -puntero_aplicacion.dp2_lt1, -puntero_aplicacion.dp2_lt2, -puntero_aplicacion.dp2_ht1, -puntero_aplicacion.dp2_ht2,
                                -puntero_aplicacion.dp2_pc1, -puntero_aplicacion.dp2_pc2, -puntero_aplicacion.dp2_phx1, -puntero_aplicacion.dp2_phx2, -puntero_aplicacion.dp2_rhx1, -puntero_aplicacion.dp2_rhx2, -puntero_aplicacion.dp2_cooler1, -puntero_aplicacion.dp2_cooler2);

                                counter++;

                                puntero_aplicacion.massflow2 = cicloPCRC_withRH.m_dot_turbine;
                                puntero_aplicacion.w_dot_net2 = cicloPCRC_withRH.W_dot_net;
                                puntero_aplicacion.eta_thermal2 = cicloPCRC_withRH.eta_thermal;
                                puntero_aplicacion.recomp_frac2 = variables[0];
                                puntero_aplicacion.p_pc_in2 = variables[1];
                                puntero_aplicacion.p_pc_out2 = variables[2];
                                puntero_aplicacion.p_rhx_in2 = variables[3];

                                puntero_aplicacion.temp21 = cicloPCRC_withRH.temp[0];
                                puntero_aplicacion.temp22 = cicloPCRC_withRH.temp[1];
                                puntero_aplicacion.temp23 = cicloPCRC_withRH.temp[2];
                                puntero_aplicacion.temp24 = cicloPCRC_withRH.temp[3];
                                puntero_aplicacion.temp25 = cicloPCRC_withRH.temp[4];
                                puntero_aplicacion.temp26 = cicloPCRC_withRH.temp[5];
                                puntero_aplicacion.temp27 = cicloPCRC_withRH.temp[6];
                                puntero_aplicacion.temp28 = cicloPCRC_withRH.temp[7];
                                puntero_aplicacion.temp29 = cicloPCRC_withRH.temp[8];
                                puntero_aplicacion.temp210 = cicloPCRC_withRH.temp[9];
                                puntero_aplicacion.temp211 = cicloPCRC_withRH.temp[10];
                                puntero_aplicacion.temp212 = cicloPCRC_withRH.temp[11];
                                puntero_aplicacion.temp213 = cicloPCRC_withRH.temp[12];
                                puntero_aplicacion.temp214 = cicloPCRC_withRH.temp[13];

                                puntero_aplicacion.pres21 = cicloPCRC_withRH.pres[0];
                                puntero_aplicacion.pres22 = cicloPCRC_withRH.pres[1];
                                puntero_aplicacion.pres23 = cicloPCRC_withRH.pres[2];
                                puntero_aplicacion.pres24 = cicloPCRC_withRH.pres[3];
                                puntero_aplicacion.pres25 = cicloPCRC_withRH.pres[4];
                                puntero_aplicacion.pres26 = cicloPCRC_withRH.pres[5];
                                puntero_aplicacion.pres27 = cicloPCRC_withRH.pres[6];
                                puntero_aplicacion.pres28 = cicloPCRC_withRH.pres[7];
                                puntero_aplicacion.pres29 = cicloPCRC_withRH.pres[8];
                                puntero_aplicacion.pres210 = cicloPCRC_withRH.pres[9];
                                puntero_aplicacion.pres211 = cicloPCRC_withRH.pres[10];
                                puntero_aplicacion.pres212 = cicloPCRC_withRH.pres[11];
                                puntero_aplicacion.pres213 = cicloPCRC_withRH.pres[12];
                                puntero_aplicacion.pres214 = cicloPCRC_withRH.pres[13];

                                puntero_aplicacion.PHX1 = cicloPCRC_withRH.PHX.Q_dot;
                                puntero_aplicacion.RHX1 = cicloPCRC_withRH.RHX.Q_dot;

                                puntero_aplicacion.LT_Q = cicloPCRC_withRH.LT.Q_dot;
                                puntero_aplicacion.LT_mdotc = cicloPCRC_withRH.LT.m_dot_design[0];
                                puntero_aplicacion.LT_mdoth = cicloPCRC_withRH.LT.m_dot_design[1];
                                puntero_aplicacion.LT_Tcin = cicloPCRC_withRH.LT.T_c_in;
                                puntero_aplicacion.LT_Thin = cicloPCRC_withRH.LT.T_h_in;
                                puntero_aplicacion.LT_Pcin = cicloPCRC_withRH.LT.P_c_in;
                                puntero_aplicacion.LT_Phin = cicloPCRC_withRH.LT.P_h_in;
                                puntero_aplicacion.LT_Pcout = cicloPCRC_withRH.LT.P_c_out;
                                puntero_aplicacion.LT_Phout = cicloPCRC_withRH.LT.P_h_out;
                                puntero_aplicacion.LT_Effc = cicloPCRC_withRH.LT.eff;

                                puntero_aplicacion.HT_Q = cicloPCRC_withRH.HT.Q_dot;
                                puntero_aplicacion.HT_mdotc = cicloPCRC_withRH.HT.m_dot_design[0];
                                puntero_aplicacion.HT_mdoth = cicloPCRC_withRH.HT.m_dot_design[1];
                                puntero_aplicacion.HT_Tcin = cicloPCRC_withRH.HT.T_c_in;
                                puntero_aplicacion.HT_Thin = cicloPCRC_withRH.HT.T_h_in;
                                puntero_aplicacion.HT_Pcin = cicloPCRC_withRH.HT.P_c_in;
                                puntero_aplicacion.HT_Phin = cicloPCRC_withRH.HT.P_h_in;
                                puntero_aplicacion.HT_Pcout = cicloPCRC_withRH.HT.P_c_out;
                                puntero_aplicacion.HT_Phout = cicloPCRC_withRH.HT.P_h_out;
                                puntero_aplicacion.HT_Effc = cicloPCRC_withRH.HT.eff;

                                puntero_aplicacion.PC1 = -cicloPCRC_withRH.PC.Q_dot;
                                puntero_aplicacion.COOLER1 = -cicloPCRC_withRH.COOLER.Q_dot;

                                massflow2_list.Add(puntero_aplicacion.massflow2);
                                eta_thermal2_list.Add(puntero_aplicacion.eta_thermal2);
                                recomp_frac2_list.Add(puntero_aplicacion.recomp_frac2);
                                p_pc_in2_list.Add(puntero_aplicacion.p_pc_in2);
                                p_pc_out2_list.Add(puntero_aplicacion.p_pc_out2);
                                p_rhx_in2_list.Add(puntero_aplicacion.p_rhx_in2);
                                ua_lt2_list.Add(puntero_aplicacion.ua_lt2);
                                ua_ht2_list.Add(puntero_aplicacion.ua_ht2);

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

                                PHX_Q_list.Add(cicloPCRC_withRH.PHX.Q_dot);
                                RHX_Q_list.Add(cicloPCRC_withRH.RHX.Q_dot);

                                HT_Eff_list.Add(cicloPCRC_withRH.HT.eff);
                                LT_Eff_list.Add(cicloPCRC_withRH.LT.eff);

                                listBox1.Items.Add(counter.ToString());
                                listBox2.Items.Add(puntero_aplicacion.eta_thermal2.ToString());
                                listBox3.Items.Add(puntero_aplicacion.recomp_frac2.ToString());
                                listBox4.Items.Add(puntero_aplicacion.p_pc_in2.ToString());
                                listBox9.Items.Add(puntero_aplicacion.p_pc_out2.ToString());
                                listBox19.Items.Add(puntero_aplicacion.p_rhx_in2.ToString());
                                listBox5.Items.Add(puntero_aplicacion.ua_lt2.ToString());
                                listBox6.Items.Add(puntero_aplicacion.ua_ht2.ToString());

                                return puntero_aplicacion.eta_thermal2;
                            };

                            solver.SetMaxObjective(funcion);

                            double? finalScore;

                            var result = solver.Optimize(initialValue, out finalScore);

                            Double max_eta_thermal = 0.0;

                            max_eta_thermal = eta_thermal2_list.Max();

                            var maxIndex = eta_thermal2_list.IndexOf(eta_thermal2_list.Max());

                            textBox91.Text = p_pc_in2_list[maxIndex].ToString();
                            textBox2.Text = p_pc_out2_list[maxIndex].ToString();
                            textBox90.Text = recomp_frac2_list[maxIndex].ToString();
                            textBox3.Text = p_rhx_in2_list[maxIndex].ToString();
                            textBox86.Text = eta_thermal2_list[maxIndex].ToString();

                            //Copy results as design-point inputs
                            if (checkBox3.Checked == true)
                            {
                                puntero_aplicacion.textBox15.Text = recomp_frac2_list[maxIndex].ToString();
                                puntero_aplicacion.textBox23.Text = p_pc_in2_list[maxIndex].ToString();
                                puntero_aplicacion.textBox8.Text = p_pc_out2_list[maxIndex].ToString();
                                puntero_aplicacion.textBox3.Text = p_pc_out2_list[maxIndex].ToString();
                                puntero_aplicacion.textBox7.Text = p_rhx_in2_list[maxIndex].ToString();
                            }

                            //The variable 'i' is the loop counter for the CIT
                            listBox18.Items.Add(i.ToString());
                            listBox17.Items.Add(eta_thermal2_list[maxIndex].ToString());
                            listBox16.Items.Add(recomp_frac2_list[maxIndex].ToString());
                            listBox15.Items.Add(p_pc_in2_list[maxIndex].ToString());
                            listBox10.Items.Add(p_pc_out2_list[maxIndex].ToString());
                            listBox20.Items.Add(p_rhx_in2_list[maxIndex].ToString());
                            listBox11.Items.Add(t8_list[maxIndex].ToString());
                            listBox12.Items.Add(t9_list[maxIndex].ToString());

                            //MAIN SOLAR FIELD CALCULATION
                            PTC_SF_Calculation PTC = new PTC_SF_Calculation();
                            PTC.calledForSensingAnalysis = true;
                            PTC.comboBox1.Text = "Solar Salt";
                            PTC.comboBox2.Text = "PureFluid";
                            PTC.comboBox13.Text = puntero_aplicacion.comboBox2.Text;
                            PTC.comboBox14.Text = puntero_aplicacion.comboBox16.Text;
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

                            LF_SF_Calculation LF = new LF_SF_Calculation();
                            LF.calledForSensingAnalysis = true;
                            LF.comboBox1.Text = "Solar Salt";
                            LF.comboBox2.Text = "PureFluid";
                            LF.comboBox13.Text = puntero_aplicacion.comboBox2.Text;
                            LF.comboBox14.Text = puntero_aplicacion.comboBox16.Text;
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

                            //REHEATING SOLAR FIELD CALCULATION
                            PTC_SF_Calculation PTC_RHX = new PTC_SF_Calculation();
                            PTC_RHX.calledForSensingAnalysis = true;
                            PTC_RHX.comboBox1.Text = "Solar Salt";
                            PTC_RHX.comboBox2.Text = "PureFluid";
                            PTC_RHX.comboBox13.Text = puntero_aplicacion.comboBox2.Text;
                            PTC_RHX.comboBox14.Text = puntero_aplicacion.comboBox16.Text;
                            //PTC.textBox31.Text = this.textBox31.Text;
                            //PTC.textBox36.Text = this.textBox36.Text;

                            if (comboBox1.Text == "Parabolic")
                            {
                                PTC_RHX.textBox7.Text = "0.141";
                                PTC_RHX.textBox8.Text = "6.48e-9";
                            }
                            else if (comboBox1.Text == "Parabolic with cavity receiver (Norwich)")
                            {
                                PTC_RHX.textBox7.Text = "0.3";
                                PTC_RHX.textBox8.Text = "3.25e-9";
                            }

                            PTC_RHX.textBox1.Text = Convert.ToString(puntero_aplicacion.RHX1);
                            PTC_RHX.textBox2.Text = Convert.ToString(puntero_aplicacion.massflow2);
                            PTC_RHX.textBox3.Text = Convert.ToString(puntero_aplicacion.temp211);
                            PTC_RHX.textBox6.Text = Convert.ToString(puntero_aplicacion.temp212);
                            PTC_RHX.textBox4.Text = Convert.ToString(puntero_aplicacion.pres211);
                            PTC_RHX.textBox5.Text = Convert.ToString(puntero_aplicacion.pres212);
                            PTC_RHX.textBox107.Text = Convert.ToString(10);
                            PTC_RHX.button1_Click(this, e);
                            puntero_aplicacion.PTC_ReHeating_SF_Effective_Apperture_Area = PTC_RHX.ReflectorApertureAreaResult;
                            puntero_aplicacion.PTC_ReHeating_SF_Pressure_drop = PTC_RHX.Total_Pressure_DropResult;

                            LF_SF_Calculation LF_RHX = new LF_SF_Calculation();
                            LF_RHX.calledForSensingAnalysis = true;
                            LF_RHX.comboBox1.Text = "Solar Salt";
                            LF_RHX.comboBox2.Text = "PureFluid";
                            LF_RHX.comboBox13.Text = puntero_aplicacion.comboBox2.Text;
                            LF_RHX.comboBox14.Text = puntero_aplicacion.comboBox16.Text;
                            //LF.textBox31.Text = this.textBox31.Text;
                            //LF.textBox36.Text = this.textBox36.Text;
                            LF_RHX.textBox1.Text = Convert.ToString(puntero_aplicacion.RHX1);
                            LF_RHX.textBox2.Text = Convert.ToString(puntero_aplicacion.massflow2);
                            LF_RHX.textBox3.Text = Convert.ToString(puntero_aplicacion.temp211);
                            LF_RHX.textBox6.Text = Convert.ToString(puntero_aplicacion.temp212);
                            LF_RHX.textBox4.Text = Convert.ToString(puntero_aplicacion.pres211);
                            LF_RHX.textBox5.Text = Convert.ToString(puntero_aplicacion.pres212);
                            LF_RHX.textBox107.Text = Convert.ToString(10);
                            LF_RHX.button1_Click(this, e);
                            puntero_aplicacion.LF_ReHeating_SF_Effective_Apperture_Area = LF_RHX.ReflectorApertureAreaResult;
                            puntero_aplicacion.LF_ReHeating_SF_Pressure_drop = LF_RHX.Total_Pressure_DropResult;

                            //Copy results to EXCEL
                            double LTR_min_DT_1 = t8_list[maxIndex] - t3_list[maxIndex];
                            double LTR_min_DT_2 = t9_list[maxIndex] - t2_list[maxIndex];
                            double LTR_min_DT_paper = Math.Min(LTR_min_DT_1, LTR_min_DT_2);

                            double HTR_min_DT_1 = t8_list[maxIndex] - t4_list[maxIndex];
                            double HTR_min_DT_2 = t7_list[maxIndex] - t5_list[maxIndex];
                            double HTR_min_DT_paper = Math.Min(HTR_min_DT_1, HTR_min_DT_2);

                            //PC_in(kPa)
                            xlWorkSheet1.Cells[counter_Excel + 1, 1] = Convert.ToString(p_pc_in2_list[maxIndex]);
                            //PC_out(kPa)
                            xlWorkSheet1.Cells[counter_Excel + 1, 2] = Convert.ToString(p_pc_out2_list[maxIndex]);
                            //CIT
                            xlWorkSheet1.Cells[counter_Excel + 1, 3] = Convert.ToString(i - 273.15);
                            //LT UA(kW/K)
                            xlWorkSheet1.Cells[counter_Excel + 1, 4] = ua_lt2_list[maxIndex].ToString();
                            //HT UA(kW/K)
                            xlWorkSheet1.Cells[counter_Excel + 1, 5] = ua_ht2_list[maxIndex].ToString();
                            //Rec.Frac.
                            xlWorkSheet1.Cells[counter_Excel + 1, 6] = recomp_frac2_list[maxIndex].ToString();
                            //P_rhx_in
                            xlWorkSheet1.Cells[counter_Excel + 1, 7] = p_rhx_in2_list[maxIndex].ToString();
                            //Eff.(%)
                            xlWorkSheet1.Cells[counter_Excel + 1, 8] = (eta_thermal2_list[maxIndex] * 100).ToString();
                            //LTR Eff.(%)
                            xlWorkSheet1.Cells[counter_Excel + 1, 9] = LT_Eff_list[maxIndex].ToString();
                            //LTR Pinch(ºC)
                            xlWorkSheet1.Cells[counter_Excel + 1, 10] = LTR_min_DT_paper.ToString();
                            //HTR Eff.(%)
                            xlWorkSheet1.Cells[counter_Excel + 1, 11] = HT_Eff_list[maxIndex].ToString();
                            //HTR Pinch(ºC)
                            xlWorkSheet1.Cells[counter_Excel + 1, 12] = HTR_min_DT_paper.ToString();
                            //PTC_Apperture_Area(m2)
                            xlWorkSheet1.Cells[counter_Excel + 1, 13] = puntero_aplicacion.PTC_Main_SF_Effective_Apperture_Area.ToString();
                            //PTC_Pressure_Drop(bar)
                            xlWorkSheet1.Cells[counter_Excel + 1, 14] = puntero_aplicacion.PTC_Main_SF_Pressure_drop.ToString();
                            //LF_Apperture_Area(m2)
                            xlWorkSheet1.Cells[counter_Excel + 1, 15] = puntero_aplicacion.LF_Main_SF_Effective_Apperture_Area.ToString();
                            //LF_Pressure_Drop(bar)
                            xlWorkSheet1.Cells[counter_Excel + 1, 16] = puntero_aplicacion.LF_Main_SF_Pressure_drop.ToString();
                            //PTC_RHX_Apperture_Area(m2)
                            xlWorkSheet1.Cells[counter_Excel + 1, 17] = puntero_aplicacion.PTC_ReHeating_SF_Effective_Apperture_Area.ToString();
                            //PTC_RHX_Pressure_Drop(bar)
                            xlWorkSheet1.Cells[counter_Excel + 1, 18] = puntero_aplicacion.PTC_ReHeating_SF_Pressure_drop.ToString();
                            //LF_RHX_Apperture_Area(m2)
                            xlWorkSheet1.Cells[counter_Excel + 1, 19] = puntero_aplicacion.LF_ReHeating_SF_Effective_Apperture_Area.ToString();
                            //LF_RHX_Pressure_Drop(bar)
                            xlWorkSheet1.Cells[counter_Excel + 1, 20] = puntero_aplicacion.LF_ReHeating_SF_Pressure_drop.ToString();

                            counter_Excel++;

                            initial_pc_in_value = puntero_aplicacion.p_pc_in2;
                            initial_pc_out_value = puntero_aplicacion.p_pc_out2;
                        }
                    }

                    //-------------------------------------------------------------------------

                    //UA optimization true
                    else if (checkBox2.Checked == true)
                    {
                        //PureFluid
                        if (puntero_aplicacion.comboBox1.Text == "PureFluid")
                        {
                            puntero_aplicacion.category = RefrigerantCategory.PureFluid;
                            puntero_aplicacion.luis.core1(puntero_aplicacion.comboBox2.Text, puntero_aplicacion.category);
                        }

                        //NewMixture
                        if (puntero_aplicacion.comboBox1.Text == "NewMixture")
                        {
                            puntero_aplicacion.category = RefrigerantCategory.NewMixture;
                            puntero_aplicacion.luis.core1(puntero_aplicacion.comboBox2.Text + "=" + puntero_aplicacion.textBox35.Text + "," + puntero_aplicacion.comboBox16.Text + "=" + puntero_aplicacion.textBox36.Text + "," + puntero_aplicacion.comboBox18.Text + "=" + puntero_aplicacion.textBox87.Text + "," + puntero_aplicacion.comboBox17.Text + "=" + puntero_aplicacion.textBox88.Text, puntero_aplicacion.category);
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

                        puntero_aplicacion.w_dot_net2 = Convert.ToDouble(puntero_aplicacion.textBox1.Text);
                        puntero_aplicacion.t_mc_in2 = Convert.ToDouble(puntero_aplicacion.textBox2.Text);
                        puntero_aplicacion.t_t_in2 = Convert.ToDouble(puntero_aplicacion.textBox4.Text);
                        puntero_aplicacion.p_mc_in2 = Convert.ToDouble(puntero_aplicacion.textBox3.Text);
                        puntero_aplicacion.p_mc_out2 = Convert.ToDouble(puntero_aplicacion.textBox28.Text);
                        puntero_aplicacion.p_pc_in2 = Convert.ToDouble(puntero_aplicacion.textBox23.Text);
                        puntero_aplicacion.p_pc_out2 = Convert.ToDouble(puntero_aplicacion.textBox8.Text);
                        puntero_aplicacion.t_pc_in2 = Convert.ToDouble(puntero_aplicacion.textBox22.Text);
                        puntero_aplicacion.p_rhx_in2 = Convert.ToDouble(puntero_aplicacion.textBox7.Text);
                        puntero_aplicacion.t_rht_in2 = Convert.ToDouble(puntero_aplicacion.textBox6.Text);
                        puntero_aplicacion.dp2_lt1 = Convert.ToDouble(puntero_aplicacion.textBox5.Text);
                        puntero_aplicacion.dp2_ht1 = Convert.ToDouble(puntero_aplicacion.textBox12.Text);
                        puntero_aplicacion.dp2_pc1 = Convert.ToDouble(puntero_aplicacion.textBox11.Text);
                        puntero_aplicacion.dp2_phx1 = Convert.ToDouble(puntero_aplicacion.textBox10.Text);
                        puntero_aplicacion.dp2_rhx1 = Convert.ToDouble(puntero_aplicacion.textBox9.Text);
                        puntero_aplicacion.dp2_lt2 = Convert.ToDouble(puntero_aplicacion.textBox26.Text);
                        puntero_aplicacion.dp2_ht2 = Convert.ToDouble(puntero_aplicacion.textBox25.Text);
                        puntero_aplicacion.dp2_cooler2 = Convert.ToDouble(puntero_aplicacion.textBox27.Text);
                        //puntero_aplicacion.ua_lt2 = Convert.ToDouble(puntero_aplicacion.textBox17.Text);
                        //puntero_aplicacion.ua_ht2 = Convert.ToDouble(puntero_aplicacion.textBox16.Text);
                        puntero_aplicacion.recomp_frac2 = Convert.ToDouble(puntero_aplicacion.textBox15.Text);
                        puntero_aplicacion.eta_mc2 = Convert.ToDouble(puntero_aplicacion.textBox14.Text);
                        puntero_aplicacion.eta_rc2 = Convert.ToDouble(puntero_aplicacion.textBox13.Text);
                        puntero_aplicacion.eta_pc2 = Convert.ToDouble(puntero_aplicacion.textBox24.Text);
                        puntero_aplicacion.eta_t2 = Convert.ToDouble(puntero_aplicacion.textBox19.Text);
                        puntero_aplicacion.eta_trh2 = Convert.ToDouble(puntero_aplicacion.textBox18.Text);
                        puntero_aplicacion.n_sub_hxrs2 = Convert.ToInt64(puntero_aplicacion.textBox20.Text);
                        puntero_aplicacion.tol2 = Convert.ToDouble(puntero_aplicacion.textBox21.Text);

                        puntero_aplicacion.luis.wmm = puntero_aplicacion.luis.working_fluid.MolecularWeight;

                        core.PCRCwithReheating cicloPCRC_withRH = new core.PCRCwithReheating();

                        double UA_Total = puntero_aplicacion.ua_lt2 + puntero_aplicacion.ua_ht2;

                        double LT_fraction = 0.1;

                        List<Double> massflow2_list = new List<Double>();
                        List<Double> recomp_frac2_list = new List<Double>();
                        List<Double> p_pc_in2_list = new List<Double>();
                        List<Double> p_pc_out2_list = new List<Double>();
                        List<Double> p_rhx_in2_list = new List<Double>();
                        List<Double> eta_thermal2_list = new List<Double>();
                        List<Double> PHX_Q2_list = new List<Double>();
                        List<Double> ua_lt2_list = new List<Double>();
                        List<Double> ua_ht2_list = new List<Double>();

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

                        List<Double> HT_Eff_list = new List<Double>();
                        List<Double> LT_Eff_list = new List<Double>();

                        List<Double> PHX_Q_list = new List<Double>();
                        List<Double> RHX_Q_list = new List<Double>();

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
                                initial_pc_in_value = Convert.ToDouble(textBox1.Text);
                                initial_pc_out_value = Convert.ToDouble(textBox1.Text) + 500;
                            }
                            else
                            {
                                initial_pc_in_value = puntero_aplicacion.MixtureCriticalPressure;
                                initial_pc_out_value = puntero_aplicacion.MixtureCriticalPressure + 500;
                            }

                            xlWorkSheet1.Name = puntero_aplicacion.comboBox2.Text + " Mixture";

                            xlWorkSheet1.Cells[1, 1] = puntero_aplicacion.comboBox2.Text + ":" + puntero_aplicacion.textBox35.Text + "," + puntero_aplicacion.comboBox16.Text + ":" + puntero_aplicacion.textBox36.Text + "," + puntero_aplicacion.comboBox18.Text + ":" + puntero_aplicacion.textBox87.Text + "," + puntero_aplicacion.comboBox17.Text + ":" + puntero_aplicacion.textBox88.Text;
                            xlWorkSheet1.Cells[1, 2] = "Pcrit(kPa)";
                            xlWorkSheet1.Cells[1, 3] = "Tcrit(ºC)";

                            xlWorkSheet1.Cells[2, 1] = "";
                            xlWorkSheet1.Cells[2, 2] = Convert.ToString(puntero_aplicacion.MixtureCriticalPressure);
                            xlWorkSheet1.Cells[2, 3] = Convert.ToString(puntero_aplicacion.MixtureCriticalTemperature - 273.15);

                            xlWorkSheet1.Cells[3, 1] = "";
                            xlWorkSheet1.Cells[3, 2] = "";
                            xlWorkSheet1.Cells[4, 3] = "";

                            xlWorkSheet1.Cells[4, 1] = "PC_in(kPa)";
                            xlWorkSheet1.Cells[4, 2] = "PC_out(kPa)";
                            xlWorkSheet1.Cells[4, 3] = "CIT(K)";
                            xlWorkSheet1.Cells[4, 4] = "LT UA(kW/K)";
                            xlWorkSheet1.Cells[4, 5] = "HT UA(kW/K)";
                            xlWorkSheet1.Cells[4, 6] = "Rec.Frac.";
                            xlWorkSheet1.Cells[4, 7] = "P_rhx(kPa)";
                            xlWorkSheet1.Cells[4, 8] = "Eff.(%)";
                            xlWorkSheet1.Cells[4, 9] = "LTR Eff.(%)";
                            xlWorkSheet1.Cells[4, 10] = "LTR Pinch(ºC)";
                            xlWorkSheet1.Cells[4, 11] = "HTR Eff.(%)";
                            xlWorkSheet1.Cells[4, 12] = "HTR Pinch(ºC)";

                            xlWorkSheet1.Cells[4, 13] = "PTC_Apperture_Area(m2)";
                            xlWorkSheet1.Cells[4, 14] = "PTC_Pressure_Drop(bar)";
                            xlWorkSheet1.Cells[4, 15] = "LF_Apperture_Area(m2)";
                            xlWorkSheet1.Cells[4, 16] = "LF_Pressure_Drop(bar)";
                            xlWorkSheet1.Cells[4, 17] = "PTC_RHX_Apperture_Area(m2)";
                            xlWorkSheet1.Cells[4, 18] = "PTC_RHX_Pressure_Drop(bar)";
                            xlWorkSheet1.Cells[4, 19] = "LF_RHX_Apperture_Area(m2)";
                            xlWorkSheet1.Cells[4, 20] = "LF_RHX_Pressure_Drop(bar)";
                        }

                        using (var solver = new NLoptSolver(algorithm_type, 5, 0.01, 10000))
                        {
                            solver.SetLowerBounds(new[] { 0.0, initial_pc_in_value, initial_pc_out_value, 11000, 0.2 });
                            solver.SetUpperBounds(new[] { 1.0, 125000, (puntero_aplicacion.p_mc_out2 / 1.5), 18000, 0.8 });

                            solver.SetInitialStepSize(new[] { 0.05, 100, 100, 500, 0.05 });

                            var initialValue = new[] { 0.2, initial_pc_in_value, initial_pc_out_value, 11000, 0.5 };

                            Func<double[], double> funcion = delegate (double[] variables)
                            {
                                puntero_aplicacion.luis.RecompCycle_PCRC_with_Reheating_for_Optimization(puntero_aplicacion.luis, ref cicloPCRC_withRH, puntero_aplicacion.w_dot_net2,
                                i, puntero_aplicacion.t_t_in2, puntero_aplicacion.t_rht_in2, variables[3], variables[2], puntero_aplicacion.p_mc_out2, variables[1], i, variables[2],
                                variables[4], UA_Total, puntero_aplicacion.eta_mc2, puntero_aplicacion.eta_rc2, puntero_aplicacion.eta_pc2, puntero_aplicacion.eta_t2, puntero_aplicacion.eta_trh2, puntero_aplicacion.n_sub_hxrs2,
                                variables[0], puntero_aplicacion.tol2, puntero_aplicacion.eta_thermal2, -puntero_aplicacion.dp2_lt1, -puntero_aplicacion.dp2_lt2, -puntero_aplicacion.dp2_ht1, -puntero_aplicacion.dp2_ht2,
                                -puntero_aplicacion.dp2_pc1, -puntero_aplicacion.dp2_pc2, -puntero_aplicacion.dp2_phx1, -puntero_aplicacion.dp2_phx2, -puntero_aplicacion.dp2_rhx1, -puntero_aplicacion.dp2_rhx2, -puntero_aplicacion.dp2_cooler1, -puntero_aplicacion.dp2_cooler2);

                                counter++;

                                puntero_aplicacion.massflow2 = cicloPCRC_withRH.m_dot_turbine;
                                puntero_aplicacion.w_dot_net2 = cicloPCRC_withRH.W_dot_net;

                                puntero_aplicacion.eta_thermal2 = cicloPCRC_withRH.eta_thermal;
                                puntero_aplicacion.recomp_frac2 = variables[0];
                                puntero_aplicacion.p_pc_in2 = variables[1];
                                puntero_aplicacion.p_pc_out2 = variables[2];
                                puntero_aplicacion.p_rhx_in2 = variables[3];
                                LT_fraction = variables[4];
                                puntero_aplicacion.ua_lt2 = UA_Total * LT_fraction;
                                puntero_aplicacion.ua_ht2 = UA_Total * (1 - LT_fraction);

                                puntero_aplicacion.temp21 = cicloPCRC_withRH.temp[0];
                                puntero_aplicacion.temp22 = cicloPCRC_withRH.temp[1];
                                puntero_aplicacion.temp23 = cicloPCRC_withRH.temp[2];
                                puntero_aplicacion.temp24 = cicloPCRC_withRH.temp[3];
                                puntero_aplicacion.temp25 = cicloPCRC_withRH.temp[4];
                                puntero_aplicacion.temp26 = cicloPCRC_withRH.temp[5];
                                puntero_aplicacion.temp27 = cicloPCRC_withRH.temp[6];
                                puntero_aplicacion.temp28 = cicloPCRC_withRH.temp[7];
                                puntero_aplicacion.temp29 = cicloPCRC_withRH.temp[8];
                                puntero_aplicacion.temp210 = cicloPCRC_withRH.temp[9];
                                puntero_aplicacion.temp211 = cicloPCRC_withRH.temp[10];
                                puntero_aplicacion.temp212 = cicloPCRC_withRH.temp[11];
                                puntero_aplicacion.temp213 = cicloPCRC_withRH.temp[12];
                                puntero_aplicacion.temp214 = cicloPCRC_withRH.temp[13];

                                puntero_aplicacion.pres21 = cicloPCRC_withRH.pres[0];
                                puntero_aplicacion.pres22 = cicloPCRC_withRH.pres[1];
                                puntero_aplicacion.pres23 = cicloPCRC_withRH.pres[2];
                                puntero_aplicacion.pres24 = cicloPCRC_withRH.pres[3];
                                puntero_aplicacion.pres25 = cicloPCRC_withRH.pres[4];
                                puntero_aplicacion.pres26 = cicloPCRC_withRH.pres[5];
                                puntero_aplicacion.pres27 = cicloPCRC_withRH.pres[6];
                                puntero_aplicacion.pres28 = cicloPCRC_withRH.pres[7];
                                puntero_aplicacion.pres29 = cicloPCRC_withRH.pres[8];
                                puntero_aplicacion.pres210 = cicloPCRC_withRH.pres[9];
                                puntero_aplicacion.pres211 = cicloPCRC_withRH.pres[10];
                                puntero_aplicacion.pres212 = cicloPCRC_withRH.pres[11];
                                puntero_aplicacion.pres213 = cicloPCRC_withRH.pres[12];
                                puntero_aplicacion.pres214 = cicloPCRC_withRH.pres[13];

                                puntero_aplicacion.PHX1 = cicloPCRC_withRH.PHX.Q_dot;
                                puntero_aplicacion.RHX1 = cicloPCRC_withRH.RHX.Q_dot;

                                puntero_aplicacion.LT_Q = cicloPCRC_withRH.LT.Q_dot;
                                puntero_aplicacion.LT_mdotc = cicloPCRC_withRH.LT.m_dot_design[0];
                                puntero_aplicacion.LT_mdoth = cicloPCRC_withRH.LT.m_dot_design[1];
                                puntero_aplicacion.LT_Tcin = cicloPCRC_withRH.LT.T_c_in;
                                puntero_aplicacion.LT_Thin = cicloPCRC_withRH.LT.T_h_in;
                                puntero_aplicacion.LT_Pcin = cicloPCRC_withRH.LT.P_c_in;
                                puntero_aplicacion.LT_Phin = cicloPCRC_withRH.LT.P_h_in;
                                puntero_aplicacion.LT_Pcout = cicloPCRC_withRH.LT.P_c_out;
                                puntero_aplicacion.LT_Phout = cicloPCRC_withRH.LT.P_h_out;
                                puntero_aplicacion.LT_Effc = cicloPCRC_withRH.LT.eff;

                                puntero_aplicacion.HT_Q = cicloPCRC_withRH.HT.Q_dot;
                                puntero_aplicacion.HT_mdotc = cicloPCRC_withRH.HT.m_dot_design[0];
                                puntero_aplicacion.HT_mdoth = cicloPCRC_withRH.HT.m_dot_design[1];
                                puntero_aplicacion.HT_Tcin = cicloPCRC_withRH.HT.T_c_in;
                                puntero_aplicacion.HT_Thin = cicloPCRC_withRH.HT.T_h_in;
                                puntero_aplicacion.HT_Pcin = cicloPCRC_withRH.HT.P_c_in;
                                puntero_aplicacion.HT_Phin = cicloPCRC_withRH.HT.P_h_in;
                                puntero_aplicacion.HT_Pcout = cicloPCRC_withRH.HT.P_c_out;
                                puntero_aplicacion.HT_Phout = cicloPCRC_withRH.HT.P_h_out;
                                puntero_aplicacion.HT_Effc = cicloPCRC_withRH.HT.eff;

                                puntero_aplicacion.PC1 = -cicloPCRC_withRH.PC.Q_dot;
                                puntero_aplicacion.COOLER1 = -cicloPCRC_withRH.COOLER.Q_dot;

                                massflow2_list.Add(puntero_aplicacion.massflow2);
                                eta_thermal2_list.Add(puntero_aplicacion.eta_thermal2);
                                recomp_frac2_list.Add(puntero_aplicacion.recomp_frac2);
                                p_pc_in2_list.Add(puntero_aplicacion.p_pc_in2);
                                p_pc_out2_list.Add(puntero_aplicacion.p_pc_out2);
                                p_rhx_in2_list.Add(puntero_aplicacion.p_rhx_in2);
                                ua_lt2_list.Add(puntero_aplicacion.ua_lt2);
                                ua_ht2_list.Add(puntero_aplicacion.ua_ht2);

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

                                PHX_Q_list.Add(cicloPCRC_withRH.PHX.Q_dot);
                                RHX_Q_list.Add(cicloPCRC_withRH.RHX.Q_dot);

                                HT_Eff_list.Add(cicloPCRC_withRH.HT.eff);
                                LT_Eff_list.Add(cicloPCRC_withRH.LT.eff);

                                listBox1.Items.Add(counter.ToString());
                                listBox2.Items.Add(puntero_aplicacion.eta_thermal2.ToString());
                                listBox3.Items.Add(puntero_aplicacion.recomp_frac2.ToString());
                                listBox4.Items.Add(puntero_aplicacion.p_pc_in2.ToString());
                                listBox9.Items.Add(puntero_aplicacion.p_pc_out2.ToString());
                                listBox19.Items.Add(puntero_aplicacion.p_rhx_in2.ToString());
                                listBox5.Items.Add(puntero_aplicacion.ua_lt2.ToString());
                                listBox6.Items.Add(puntero_aplicacion.ua_ht2.ToString());

                                return puntero_aplicacion.eta_thermal2;
                            };

                            solver.SetMaxObjective(funcion);

                            double? finalScore;

                            var result = solver.Optimize(initialValue, out finalScore);

                            Double max_eta_thermal = 0.0;

                            max_eta_thermal = eta_thermal2_list.Max();

                            var maxIndex = eta_thermal2_list.IndexOf(eta_thermal2_list.Max());

                            textBox91.Text = p_pc_in2_list[maxIndex].ToString();
                            textBox2.Text = p_pc_out2_list[maxIndex].ToString();
                            textBox90.Text = recomp_frac2_list[maxIndex].ToString();
                            textBox3.Text = p_rhx_in2_list[maxIndex].ToString();
                            textBox86.Text = eta_thermal2_list[maxIndex].ToString();
                            textBox82.Text = ua_lt2_list[maxIndex].ToString();
                            textBox83.Text = ua_ht2_list[maxIndex].ToString();

                            //Copy results as design-point inputs
                            if (checkBox3.Checked == true)
                            {
                                puntero_aplicacion.textBox15.Text = recomp_frac2_list[maxIndex].ToString();
                                puntero_aplicacion.textBox23.Text = p_pc_in2_list[maxIndex].ToString();
                                puntero_aplicacion.textBox8.Text = p_pc_out2_list[maxIndex].ToString();
                                puntero_aplicacion.textBox3.Text = p_pc_out2_list[maxIndex].ToString();
                                puntero_aplicacion.textBox17.Text = ua_lt2_list[maxIndex].ToString();
                                puntero_aplicacion.textBox16.Text = ua_ht2_list[maxIndex].ToString();
                                puntero_aplicacion.textBox7.Text = p_rhx_in2_list[maxIndex].ToString();
                            }

                            //The variable 'i' is the loop counter for the CIT
                            listBox18.Items.Add(i.ToString());
                            listBox17.Items.Add(eta_thermal2_list[maxIndex].ToString());
                            listBox16.Items.Add(recomp_frac2_list[maxIndex].ToString());
                            listBox15.Items.Add(p_pc_in2_list[maxIndex].ToString());
                            listBox10.Items.Add(p_pc_out2_list[maxIndex].ToString());
                            listBox14.Items.Add(ua_lt2_list[maxIndex].ToString());
                            listBox13.Items.Add(ua_ht2_list[maxIndex].ToString());
                            listBox11.Items.Add(t8_list[maxIndex].ToString());
                            listBox12.Items.Add(t9_list[maxIndex].ToString());
                            listBox20.Items.Add(p_rhx_in2_list[maxIndex].ToString());

                            //MAIN SOLAR FIELD CALCULATION
                            PTC_SF_Calculation PTC = new PTC_SF_Calculation();
                            PTC.calledForSensingAnalysis = true;
                            PTC.comboBox1.Text = "Solar Salt";
                            PTC.comboBox2.Text = "PureFluid";
                            PTC.comboBox13.Text = puntero_aplicacion.comboBox2.Text;
                            PTC.comboBox14.Text = puntero_aplicacion.comboBox16.Text;
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

                            LF_SF_Calculation LF = new LF_SF_Calculation();
                            LF.calledForSensingAnalysis = true;
                            LF.comboBox1.Text = "Solar Salt";
                            LF.comboBox2.Text = "PureFluid";
                            LF.comboBox13.Text = puntero_aplicacion.comboBox2.Text;
                            LF.comboBox14.Text = puntero_aplicacion.comboBox16.Text;
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

                            //REHEATING SOLAR FIELD CALCULATION
                            PTC_SF_Calculation PTC_RHX = new PTC_SF_Calculation();
                            PTC_RHX.calledForSensingAnalysis = true;
                            PTC_RHX.comboBox1.Text = "Solar Salt";
                            PTC_RHX.comboBox2.Text = "PureFluid";
                            PTC_RHX.comboBox13.Text = puntero_aplicacion.comboBox2.Text;
                            PTC_RHX.comboBox14.Text = puntero_aplicacion.comboBox16.Text;
                            //PTC.textBox31.Text = this.textBox31.Text;
                            //PTC.textBox36.Text = this.textBox36.Text;

                            if (comboBox1.Text == "Parabolic")
                            {
                                PTC_RHX.textBox7.Text = "0.141";
                                PTC_RHX.textBox8.Text = "6.48e-9";
                            }
                            else if (comboBox1.Text == "Parabolic with cavity receiver (Norwich)")
                            {
                                PTC_RHX.textBox7.Text = "0.3";
                                PTC_RHX.textBox8.Text = "3.25e-9";
                            }

                            PTC_RHX.textBox1.Text = Convert.ToString(puntero_aplicacion.RHX1);
                            PTC_RHX.textBox2.Text = Convert.ToString(puntero_aplicacion.massflow2);
                            PTC_RHX.textBox3.Text = Convert.ToString(puntero_aplicacion.temp211);
                            PTC_RHX.textBox6.Text = Convert.ToString(puntero_aplicacion.temp212);
                            PTC_RHX.textBox4.Text = Convert.ToString(puntero_aplicacion.pres211);
                            PTC_RHX.textBox5.Text = Convert.ToString(puntero_aplicacion.pres212);
                            PTC_RHX.textBox107.Text = Convert.ToString(10);
                            PTC_RHX.button1_Click(this, e);
                            puntero_aplicacion.PTC_ReHeating_SF_Effective_Apperture_Area = PTC_RHX.ReflectorApertureAreaResult;
                            puntero_aplicacion.PTC_ReHeating_SF_Pressure_drop = PTC_RHX.Total_Pressure_DropResult;

                            LF_SF_Calculation LF_RHX = new LF_SF_Calculation();
                            LF_RHX.calledForSensingAnalysis = true;
                            LF_RHX.comboBox1.Text = "Solar Salt";
                            LF_RHX.comboBox2.Text = "PureFluid";
                            LF_RHX.comboBox13.Text = puntero_aplicacion.comboBox2.Text;
                            LF_RHX.comboBox14.Text = puntero_aplicacion.comboBox16.Text;
                            //LF.textBox31.Text = this.textBox31.Text;
                            //LF.textBox36.Text = this.textBox36.Text;
                            LF_RHX.textBox1.Text = Convert.ToString(puntero_aplicacion.RHX1);
                            LF_RHX.textBox2.Text = Convert.ToString(puntero_aplicacion.massflow2);
                            LF_RHX.textBox3.Text = Convert.ToString(puntero_aplicacion.temp211);
                            LF_RHX.textBox6.Text = Convert.ToString(puntero_aplicacion.temp212);
                            LF_RHX.textBox4.Text = Convert.ToString(puntero_aplicacion.pres211);
                            LF_RHX.textBox5.Text = Convert.ToString(puntero_aplicacion.pres212);
                            LF_RHX.textBox107.Text = Convert.ToString(10);
                            LF_RHX.button1_Click(this, e);
                            puntero_aplicacion.LF_ReHeating_SF_Effective_Apperture_Area = LF_RHX.ReflectorApertureAreaResult;
                            puntero_aplicacion.LF_ReHeating_SF_Pressure_drop = LF_RHX.Total_Pressure_DropResult;

                            //Copy results to EXCEL
                            double LTR_min_DT_1 = t8_list[maxIndex] - t3_list[maxIndex];
                            double LTR_min_DT_2 = t9_list[maxIndex] - t2_list[maxIndex];
                            double LTR_min_DT_paper = Math.Min(LTR_min_DT_1, LTR_min_DT_2);

                            double HTR_min_DT_1 = t8_list[maxIndex] - t4_list[maxIndex];
                            double HTR_min_DT_2 = t7_list[maxIndex] - t5_list[maxIndex];
                            double HTR_min_DT_paper = Math.Min(HTR_min_DT_1, HTR_min_DT_2);

                            //PC_in(kPa)
                            xlWorkSheet1.Cells[counter_Excel + 1, 1] = Convert.ToString(p_pc_in2_list[maxIndex]);
                            //PC_out(kPa)
                            xlWorkSheet1.Cells[counter_Excel + 1, 2] = Convert.ToString(p_pc_out2_list[maxIndex]);
                            //CIT
                            xlWorkSheet1.Cells[counter_Excel + 1, 3] = Convert.ToString(i - 273.15);
                            //LT UA(kW/K)
                            xlWorkSheet1.Cells[counter_Excel + 1, 4] = ua_lt2_list[maxIndex].ToString();
                            //HT UA(kW/K)
                            xlWorkSheet1.Cells[counter_Excel + 1, 5] = ua_ht2_list[maxIndex].ToString();
                            //Rec.Frac.
                            xlWorkSheet1.Cells[counter_Excel + 1, 6] = recomp_frac2_list[maxIndex].ToString();
                            //P_rhx_in
                            xlWorkSheet1.Cells[counter_Excel + 1, 7] = p_rhx_in2_list[maxIndex].ToString();
                            //Eff.(%)
                            xlWorkSheet1.Cells[counter_Excel + 1, 8] = (eta_thermal2_list[maxIndex] * 100).ToString();
                            //LTR Eff.(%)
                            xlWorkSheet1.Cells[counter_Excel + 1, 9] = LT_Eff_list[maxIndex].ToString();
                            //LTR Pinch(ºC)
                            xlWorkSheet1.Cells[counter_Excel + 1, 10] = LTR_min_DT_paper.ToString();
                            //HTR Eff.(%)
                            xlWorkSheet1.Cells[counter_Excel + 1, 11] = HT_Eff_list[maxIndex].ToString();
                            //HTR Pinch(ºC)
                            xlWorkSheet1.Cells[counter_Excel + 1, 12] = HTR_min_DT_paper.ToString();
                            //PTC_Apperture_Area(m2)
                            xlWorkSheet1.Cells[counter_Excel + 1, 13] = puntero_aplicacion.PTC_Main_SF_Effective_Apperture_Area.ToString();
                            //PTC_Pressure_Drop(bar)
                            xlWorkSheet1.Cells[counter_Excel + 1, 14] = puntero_aplicacion.PTC_Main_SF_Pressure_drop.ToString();
                            //LF_Apperture_Area(m2)
                            xlWorkSheet1.Cells[counter_Excel + 1, 15] = puntero_aplicacion.LF_Main_SF_Effective_Apperture_Area.ToString();
                            //LF_Pressure_Drop(bar)
                            xlWorkSheet1.Cells[counter_Excel + 1, 16] = puntero_aplicacion.LF_Main_SF_Pressure_drop.ToString();
                            //PTC_RHX_Apperture_Area(m2)
                            xlWorkSheet1.Cells[counter_Excel + 1, 17] = puntero_aplicacion.PTC_ReHeating_SF_Effective_Apperture_Area.ToString();
                            //PTC_RHX_Pressure_Drop(bar)
                            xlWorkSheet1.Cells[counter_Excel + 1, 18] = puntero_aplicacion.PTC_ReHeating_SF_Pressure_drop.ToString();
                            //LF_RHX_Apperture_Area(m2)
                            xlWorkSheet1.Cells[counter_Excel + 1, 19] = puntero_aplicacion.LF_ReHeating_SF_Effective_Apperture_Area.ToString();
                            //LF_RHX_Pressure_Drop(bar)
                            xlWorkSheet1.Cells[counter_Excel + 1, 20] = puntero_aplicacion.LF_ReHeating_SF_Pressure_drop.ToString();

                            counter_Excel++;

                            initial_pc_in_value = puntero_aplicacion.p_pc_in2;
                            initial_pc_out_value = puntero_aplicacion.p_pc_out2;
                        }
                    } //checkBox2.Checked (optimize UA)
                
                } //loop for CIT optimization analysis

            }  //loop for UA optimization analysis

            //Closing Excel Book
            xlWorkBook1.SaveAs(textBox4.Text + "CIT_Optimization_PCRC_with_ReHeating_" + xlWorkSheet1.Name + ".xls", Excel.XlFileFormat.xlWorkbookNormal, misValue1, misValue1, misValue1, misValue1, Excel.XlSaveAsAccessMode.xlExclusive, misValue1, misValue1, misValue1, misValue1, misValue1);

            xlWorkBook1.Close(true, misValue1, misValue1);
            xlApp1.Quit();

            releaseObject(xlWorkSheet1);
            //releaseObject(xlWorkSheet2);
            releaseObject(xlWorkBook1);
            releaseObject(xlApp1);
        }

        //Clear Lists
        private void Button9_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            listBox5.Items.Clear();
            listBox6.Items.Clear();
            listBox7.Items.Clear();
            listBox8.Items.Clear();
            listBox9.Items.Clear();
            listBox10.Items.Clear();
            listBox11.Items.Clear();
            listBox12.Items.Clear();
            listBox13.Items.Clear();
            listBox14.Items.Clear();
            listBox15.Items.Clear();
            listBox16.Items.Clear();
            listBox17.Items.Clear();
            listBox18.Items.Clear();
            listBox19.Items.Clear();
            listBox20.Items.Clear();
        }

        private void PCRC_with_ReHeating_Optimization_Analysis_Results_Load(object sender, EventArgs e)
        {
            textBox1.Text = puntero_aplicacion.textBox69.Text;
        }
    }
}
