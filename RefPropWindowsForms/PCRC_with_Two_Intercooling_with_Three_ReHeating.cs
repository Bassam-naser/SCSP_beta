﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Diagnostics;
using System.Reflection;

using System.Data.Common;
using System.Threading;
using System.Text;

using Excel = Microsoft.Office.Interop.Excel;

using sc.net;

namespace RefPropWindowsForms
{
    public partial class PCRC_with_Two_Intercooling_with_Three_ReHeating : Form
    {
        public double MixtureCriticalPressure = 0.0;
        public double MixtureCriticalTemperature = 0.0;

        public core luis = new core();

        public Net_Power Net_Power_dialog;

        public Diagrams Diagrams_dialog;

        public Final_Report Final_Report_dialog;

        public Generator Generator_dialog;

        public Estimated_Cost Estimated_Cost_Dialog;

        public Fresnel SF_PHX_LF;
        public Fresnel SF_RHX1_LF;
        public Fresnel SF_RHX2_LF;
        public Fresnel SF_RHX3_LF;

        public PTC_Solar_Field SF_PHX;
        public PTC_Solar_Field SF_RHX1;
        public PTC_Solar_Field SF_RHX2;
        public PTC_Solar_Field SF_RHX3;

        //Dual-Loop option
        public Double PHX1_temp_out = 0;
        public Double PHX1_Q = 0;
        public Double PHX1_pres_out = 0;
        public Double DP_PHX1 = 0;
        public Double PHX1_h_in = 0;
        public Double PHX1_h_out = 0;
        public Double PHX2_Q = 0;
        public Double PHX2_pres_out = 0;
        public Double DP_PHX2 = 0;
        public Double PHX2_h_in = 0;
        public Double PHX2_h_out = 0;

        public PreeCooler Precooler_dialog1;
        public PreeCooler Precooler_dialog2;
        public PreeCooler Precooler_dialog3;

        public HeatExchangerUA LT_Recuperator;
        public HeatExchangerUA HT_Recuperator;

        public Radial_Turbine Main_Turbine;
        public Radial_Turbine ReHeating_Turbine1;
        public Radial_Turbine ReHeating_Turbine2;
        public Radial_Turbine ReHeating_Turbine3;

        //First calculate the Main Compressor Rotational speed and after send that value to the Turbines
        public Double N_design_Main_Compressor;

        public snl_compressor_tsr Main_Compressor;
        public snl_compressor_tsr ReCompressor, Pre_Compressor1, Pre_Compressor2;

        //Input Data:
        public RefrigerantCategory category;
        public ReferenceState referencestate;
        public Int64 Error_code;

        public Double wmm;

        //STORING RESULTS
        //"Parabolic" or "Fresnel"
        public String Collector_Type_Main_SF;
        public String Collector_Type_ReHeating_SF;

        //Main Solar Field 
        public Double PTC_Main_SF_Effective_Apperture_Area;
        public Double LF_Main_SF_Effective_Apperture_Area;

        public Double PTC_Main_Solar_Impinging_flowpath, PTC_Main_Solar_Energy_Absorbed_flowpath, PTC_Main_Energy_Loss_flowpath, PTC_Main_Net_Absorbed_flowpath;
        public Double PTC_Main_Net_Absorbed_SF, PTC_Main_Collector_Efficiency, PTC_Main_SF_Pressure_drop, PTC_Main_calculated_mass_flux, PTC_Main_calculated_Number_Rows;
        public Double PTC_Main_calculated_Row_length;

        public Double PTC_Main_SF_Pump_Calculated_Power, PTC_Main_SF_Pump_isoentropic_eff, PTC_Main_SF_Pump_Hydraulic_Power, PTC_Main_SF_Pump_Mechanical_eff;
        public Double PTC_Main_SF_Pump_Shaft_Work, PTC_Main_SF_Pump_Motor_eff, PTC_Main_SF_Pump_Motor_Elec_Consump, PTC_Main_SF_Pump_Motor_NamePlate_Design, PTC_Main_SF_Pump_Motor_NamePlate;

        public Double LF_Main_Solar_Impinging_flowpath, LF_Main_Solar_Energy_Absorbed_flowpath, LF_Main_Energy_Loss_flowpath, LF_Main_Net_Absorbed_flowpath;
        public Double LF_Main_Net_Absorbed_SF, LF_Main_Collector_Efficiency, LF_Main_SF_Pressure_drop, LF_Main_calculated_mass_flux, LF_Main_calculated_Number_Rows;
        public Double LF_Main_calculated_Row_length;

        public Double LF_Main_SF_Pump_Calculated_Power, LF_Main_SF_Pump_isoentropic_eff, LF_Main_SF_Pump_Hydraulic_Power, LF_Main_SF_Pump_Mechanical_eff;
        public Double LF_Main_SF_Pump_Shaft_Work, LF_Main_SF_Pump_Motor_eff, LF_Main_SF_Pump_Motor_Elec_Consump, LF_Main_SF_Pump_Motor_NamePlate_Design, LF_Main_SF_Pump_Motor_NamePlate;

        //ReHeating1 Solar Field
        public Double PTC_ReHeating1_SF_Effective_Apperture_Area;
        public Double LF_ReHeating1_SF_Effective_Apperture_Area;

        public Double PTC_ReHeating1_Solar_Impinging_flowpath, PTC_ReHeating1_Solar_Energy_Absorbed_flowpath, PTC_ReHeating1_Energy_Loss_flowpath, PTC_ReHeating1_Net_Absorbed_flowpath;
        public Double PTC_ReHeating1_Net_Absorbed_SF, PTC_ReHeating1_Collector_Efficiency, PTC_ReHeating1_SF_Pressure_drop, PTC_ReHeating1_calculated_mass_flux, PTC_ReHeating1_calculated_Number_Rows;
        public Double PTC_ReHeating1_calculated_Row_length;

        public Double PTC_ReHeating1_SF_Pump_Calculated_Power, PTC_ReHeating1_SF_Pump_isoentropic_eff, PTC_ReHeating1_SF_Pump_Hydraulic_Power, PTC_ReHeating1_SF_Pump_Mechanical_eff;
        public Double PTC_ReHeating1_SF_Pump_Shaft_Work, PTC_ReHeating1_SF_Pump_Motor_eff, PTC_ReHeating1_SF_Pump_Motor_Elec_Consump, PTC_ReHeating1_SF_Pump_Motor_NamePlate_Design, PTC_ReHeating1_SF_Pump_Motor_NamePlate;
        public Double Dual_Loop_PTC_Main_SF_Pump_Motor_Elec_Consump_1, Dual_Loop_PTC_Main_SF_Pump_Motor_Elec_Consump_2;

        public Double LF_ReHeating1_Solar_Impinging_flowpath, LF_ReHeating1_Solar_Energy_Absorbed_flowpath, LF_ReHeating1_Energy_Loss_flowpath, LF_ReHeating1_Net_Absorbed_flowpath;
        public Double LF_ReHeating1_Net_Absorbed_SF, LF_ReHeating1_Collector_Efficiency, LF_ReHeating1_SF_Pressure_drop, LF_ReHeating1_calculated_mass_flux, LF_ReHeating1_calculated_Number_Rows;
        public Double LF_ReHeating1_calculated_Row_length;

        public Double LF_ReHeating1_SF_Pump_Calculated_Power, LF_ReHeating1_SF_Pump_isoentropic_eff, LF_ReHeating1_SF_Pump_Hydraulic_Power, LF_ReHeating1_SF_Pump_Mechanical_eff;
        public Double LF_ReHeating1_SF_Pump_Shaft_Work, LF_ReHeating1_SF_Pump_Motor_eff, LF_ReHeating1_SF_Pump_Motor_Elec_Consump, LF_ReHeating1_SF_Pump_Motor_NamePlate_Design, LF_ReHeating1_SF_Pump_Motor_NamePlate;
        public Double Dual_Loop_LF_Main_SF_Pump_Motor_Elec_Consump_1, Dual_Loop_LF_Main_SF_Pump_Motor_Elec_Consump_2;

        //ReHeating2 Solar Field
        public Double PTC_ReHeating2_SF_Effective_Apperture_Area;
        public Double LF_ReHeating2_SF_Effective_Apperture_Area;

        public Double PTC_ReHeating2_Solar_Impinging_flowpath, PTC_ReHeating2_Solar_Energy_Absorbed_flowpath, PTC_ReHeating2_Energy_Loss_flowpath, PTC_ReHeating2_Net_Absorbed_flowpath;
        public Double PTC_ReHeating2_Net_Absorbed_SF, PTC_ReHeating2_Collector_Efficiency, PTC_ReHeating2_SF_Pressure_drop, PTC_ReHeating2_calculated_mass_flux, PTC_ReHeating2_calculated_Number_Rows;
        public Double PTC_ReHeating2_calculated_Row_length;

        public Double PTC_ReHeating2_SF_Pump_Calculated_Power, PTC_ReHeating2_SF_Pump_isoentropic_eff, PTC_ReHeating2_SF_Pump_Hydraulic_Power, PTC_ReHeating2_SF_Pump_Mechanical_eff;
        public Double PTC_ReHeating2_SF_Pump_Shaft_Work, PTC_ReHeating2_SF_Pump_Motor_eff, PTC_ReHeating2_SF_Pump_Motor_Elec_Consump, PTC_ReHeating2_SF_Pump_Motor_NamePlate_Design, PTC_ReHeating2_SF_Pump_Motor_NamePlate;
        //public Double Dual_Loop_PTC_Main_SF_Pump_Motor_Elec_Consump_1, Dual_Loop_PTC_Main_SF_Pump_Motor_Elec_Consump_2;

        public Double LF_ReHeating2_Solar_Impinging_flowpath, LF_ReHeating2_Solar_Energy_Absorbed_flowpath, LF_ReHeating2_Energy_Loss_flowpath, LF_ReHeating2_Net_Absorbed_flowpath;
        public Double LF_ReHeating2_Net_Absorbed_SF, LF_ReHeating2_Collector_Efficiency, LF_ReHeating2_SF_Pressure_drop, LF_ReHeating2_calculated_mass_flux, LF_ReHeating2_calculated_Number_Rows;
        public Double LF_ReHeating2_calculated_Row_length;

        public Double LF_ReHeating2_SF_Pump_Calculated_Power, LF_ReHeating2_SF_Pump_isoentropic_eff, LF_ReHeating2_SF_Pump_Hydraulic_Power, LF_ReHeating2_SF_Pump_Mechanical_eff;
        public Double LF_ReHeating2_SF_Pump_Shaft_Work, LF_ReHeating2_SF_Pump_Motor_eff, LF_ReHeating2_SF_Pump_Motor_Elec_Consump, LF_ReHeating2_SF_Pump_Motor_NamePlate_Design, LF_ReHeating2_SF_Pump_Motor_NamePlate;
        //public Double Dual_Loop_LF_Main_SF_Pump_Motor_Elec_Consump_1, Dual_Loop_LF_Main_SF_Pump_Motor_Elec_Consump_2;

        //ReHeating3 Solar Field
        public Double PTC_ReHeating3_SF_Effective_Apperture_Area;
        public Double LF_ReHeating3_SF_Effective_Apperture_Area;

        public Double PTC_ReHeating3_Solar_Impinging_flowpath, PTC_ReHeating3_Solar_Energy_Absorbed_flowpath, PTC_ReHeating3_Energy_Loss_flowpath, PTC_ReHeating3_Net_Absorbed_flowpath;
        public Double PTC_ReHeating3_Net_Absorbed_SF, PTC_ReHeating3_Collector_Efficiency, PTC_ReHeating3_SF_Pressure_drop, PTC_ReHeating3_calculated_mass_flux, PTC_ReHeating3_calculated_Number_Rows;
        public Double PTC_ReHeating3_calculated_Row_length;

        public Double PTC_ReHeating3_SF_Pump_Calculated_Power, PTC_ReHeating3_SF_Pump_isoentropic_eff, PTC_ReHeating3_SF_Pump_Hydraulic_Power, PTC_ReHeating3_SF_Pump_Mechanical_eff;
        public Double PTC_ReHeating3_SF_Pump_Shaft_Work, PTC_ReHeating3_SF_Pump_Motor_eff, PTC_ReHeating3_SF_Pump_Motor_Elec_Consump, PTC_ReHeating3_SF_Pump_Motor_NamePlate_Design, PTC_ReHeating3_SF_Pump_Motor_NamePlate;
        //public Double Dual_Loop_PTC_Main_SF_Pump_Motor_Elec_Consump_1, Dual_Loop_PTC_Main_SF_Pump_Motor_Elec_Consump_2;

        public Double LF_ReHeating3_Solar_Impinging_flowpath, LF_ReHeating3_Solar_Energy_Absorbed_flowpath, LF_ReHeating3_Energy_Loss_flowpath, LF_ReHeating3_Net_Absorbed_flowpath;
        public Double LF_ReHeating3_Net_Absorbed_SF, LF_ReHeating3_Collector_Efficiency, LF_ReHeating3_SF_Pressure_drop, LF_ReHeating3_calculated_mass_flux, LF_ReHeating3_calculated_Number_Rows;
        public Double LF_ReHeating3_calculated_Row_length;

        public Double LF_ReHeating3_SF_Pump_Calculated_Power, LF_ReHeating3_SF_Pump_isoentropic_eff, LF_ReHeating3_SF_Pump_Hydraulic_Power, LF_ReHeating3_SF_Pump_Mechanical_eff;
        public Double LF_ReHeating3_SF_Pump_Shaft_Work, LF_ReHeating3_SF_Pump_Motor_eff, LF_ReHeating3_SF_Pump_Motor_Elec_Consump, LF_ReHeating3_SF_Pump_Motor_NamePlate_Design, LF_ReHeating3_SF_Pump_Motor_NamePlate;
        //public Double Dual_Loop_LF_Main_SF_Pump_Motor_Elec_Consump_1, Dual_Loop_LF_Main_SF_Pump_Motor_Elec_Consump_2;

        //Primary Heat Exchanger (PHX) 
        public Double PHX_Qdot, PHX_Num_HXs, PHX_mdot_c, PHX_mdot_h, PHX_cold_Pin, PHX_cold_Tin, PHX_cold_Pout, PHX_cold_Tout;
        public Double PHX_hot_Pin, PHX_hot_Tin, PHX_hot_Pout, PHX_hot_Tout;
        public Double PHX_UA, PHX_NTU, PHX_CR, PHX_min_DT, PHX_Effectiveness, PHX_Q_per_module, PHX_number_modules, PHX_min_DT_input;
        //public Double PHX_mdot_h_module, PHX_mdot_c_module, PHX_UA_module, PHX_NTU_module, PHX_CR_module, PHX_min_DT_module, PHX_Effectiveness_module;

        public Double[] PHX_T_cold = new Double[25];
        public Double[] PHX_T_hot = new Double[25];

        public Double[] PHX_UA_local = new Double[25];
        public Double[] PHX_NTU_local = new Double[25];
        public Double[] PHX_CR_local = new Double[25];
        public Double[] PHX_Effec_local = new Double[25];
        public Double[] PHX_C_dot_c_local = new Double[25];
        public Double[] PHX_C_dot_h_local = new Double[25];

        public Double[] PHX_UA_local_module = new Double[25];
        public Double[] PHX_NTU_local_module = new Double[25];
        public Double[] PHX_CR_local_module = new Double[25];
        public Double[] PHX_Effec_local_module = new Double[25];
        public Double[] PHX_C_dot_c_local_module = new Double[25];
        public Double[] PHX_C_dot_h_local_module = new Double[25];

        //ReHeating1 Heat Exchanger (RHX1)
        public Double RHX1_Qdot, RHX1_Num_HXs, RHX1_mdot_c, RHX1_mdot_h, RHX1_cold_Pin, RHX1_cold_Tin, RHX1_cold_Pout, RHX1_cold_Tout;
        public Double RHX1_hot_Pin, RHX1_hot_Tin, RHX1_hot_Pout, RHX1_hot_Tout;
        public Double RHX1_UA, RHX1_NTU, RHX1_CR, RHX1_min_DT, RHX1_Effectiveness, RHX1_Q_per_module, RHX1_number_modules, RHX1_min_DT_input;
        public Double RHX1_mdot_h_module, RHX1_mdot_c_module, RHX1_UA_module, RHX1_NTU_module, RHX1_CR_module, RHX1_min_DT_module, RHX1_Effectiveness_module;

        public Double[] RHX1_T_cold = new Double[25];
        public Double[] RHX1_T_hot = new Double[25];

        public Double[] RHX1_UA_local = new Double[25];
        public Double[] RHX1_NTU_local = new Double[25];
        public Double[] RHX1_CR_local = new Double[25];
        public Double[] RHX1_Effec_local = new Double[25];
        public Double[] RHX1_C_dot_c_local = new Double[25];
        public Double[] RHX1_C_dot_h_local = new Double[25];

        public Double[] RHX1_UA_local_module = new Double[25];
        public Double[] RHX1_NTU_local_module = new Double[25];
        public Double[] RHX1_CR_local_module = new Double[25];
        public Double[] RHX1_Effec_local_module = new Double[25];
        public Double[] RHX1_C_dot_c_local_module = new Double[25];
        public Double[] RHX1_C_dot_h_local_module = new Double[25];

        //ReHeating2 Heat Exchanger (RHX2)
        public Double RHX2_Qdot, RHX2_Num_HXs, RHX2_mdot_c, RHX2_mdot_h, RHX2_cold_Pin, RHX2_cold_Tin, RHX2_cold_Pout, RHX2_cold_Tout;
        public Double RHX2_hot_Pin, RHX2_hot_Tin, RHX2_hot_Pout, RHX2_hot_Tout;
        public Double RHX2_UA, RHX2_NTU, RHX2_CR, RHX2_min_DT, RHX2_Effectiveness, RHX2_Q_per_module, RHX2_number_modules, RHX2_min_DT_input;
        public Double RHX2_mdot_h_module, RHX2_mdot_c_module, RHX2_UA_module, RHX2_NTU_module, RHX2_CR_module, RHX2_min_DT_module, RHX2_Effectiveness_module;

        public Double[] RHX2_T_cold = new Double[25];
        public Double[] RHX2_T_hot = new Double[25];

        public Double[] RHX2_UA_local = new Double[25];
        public Double[] RHX2_NTU_local = new Double[25];
        public Double[] RHX2_CR_local = new Double[25];
        public Double[] RHX2_Effec_local = new Double[25];
        public Double[] RHX2_C_dot_c_local = new Double[25];
        public Double[] RHX2_C_dot_h_local = new Double[25];

        public Double[] RHX2_UA_local_module = new Double[25];
        public Double[] RHX2_NTU_local_module = new Double[25];
        public Double[] RHX2_CR_local_module = new Double[25];
        public Double[] RHX2_Effec_local_module = new Double[25];
        public Double[] RHX2_C_dot_c_local_module = new Double[25];
        public Double[] RHX2_C_dot_h_local_module = new Double[25];

        //ReHeating3 Heat Exchanger (RHX3)
        public Double RHX3_Qdot, RHX3_Num_HXs, RHX3_mdot_c, RHX3_mdot_h, RHX3_cold_Pin, RHX3_cold_Tin, RHX3_cold_Pout, RHX3_cold_Tout;
        public Double RHX3_hot_Pin, RHX3_hot_Tin, RHX3_hot_Pout, RHX3_hot_Tout;
        public Double RHX3_UA, RHX3_NTU, RHX3_CR, RHX3_min_DT, RHX3_Effectiveness, RHX3_Q_per_module, RHX3_number_modules, RHX3_min_DT_input;
        public Double RHX3_mdot_h_module, RHX3_mdot_c_module, RHX3_UA_module, RHX3_NTU_module, RHX3_CR_module, RHX3_min_DT_module, RHX3_Effectiveness_module;

        public Double[] RHX3_T_cold = new Double[25];
        public Double[] RHX3_T_hot = new Double[25];

        public Double[] RHX3_UA_local = new Double[25];
        public Double[] RHX3_NTU_local = new Double[25];
        public Double[] RHX3_CR_local = new Double[25];
        public Double[] RHX3_Effec_local = new Double[25];
        public Double[] RHX3_C_dot_c_local = new Double[25];
        public Double[] RHX3_C_dot_h_local = new Double[25];

        public Double[] RHX3_UA_local_module = new Double[25];
        public Double[] RHX3_NTU_local_module = new Double[25];
        public Double[] RHX3_CR_local_module = new Double[25];
        public Double[] RHX3_Effec_local_module = new Double[25];
        public Double[] RHX3_C_dot_c_local_module = new Double[25];
        public Double[] RHX3_C_dot_h_local_module = new Double[25];

        //Generator Information
        public Double Generator_Name_Plate_Power, Generator_Power_Output, Generator_Total_Loss;
        public Double Generator_Shaft_Power, Gear_Efficiency, Rating_Point_Efficiency;
        public Double Generator_Mechanical_Loss, Generator_Electrical_Loss, Rating_Design_Point_Load;

        //SF and ACHE Pumps electrical consumption
        public Double Main_SF_Pump_Electrical_Consumption, ReHeating_SF_Pump_Electrical_Consumption;
        public Double UHS_Water_Pump, ACHE_fans;

        //Main Compressor results
        public Double Main_Compressor_Pin, Main_Compressor_Tin, Main_Compressor_Pout, Main_Compressor_Tout;
        public Double Main_Compressor_Flow, Main_Compressor_Diameter, Main_Compressor_Rotation_Velocity;
        public Double Main_Compressor_Efficiency, Main_Compressor_Phi; //Main_Compressor_Phi is the Compressor Flow Factor
        public Boolean Main_Compressor_Surge;

        //Pre-Compressor1 results
        public Double Pre_Compressor1_Pin, Pre_Compressor1_Tin, Pre_Compressor1_Pout, Pre_Compressor1_Tout;
        public Double Pre_Compressor1_Flow, Pre_Compressor1_Diameter1, Pre_Compressor1_Diameter2, Pre_Compressor1_Rotation_Velocity;
        public Double Pre_Compressor1_Efficiency, Pre_Compressor1_Phi; //Pre_Compressor_Phi is the Compressor Flow Factor
        public Boolean Pre_Compressor1_Surge;

        //Pre-Compressor2 results
        public Double Pre_Compressor2_Pin, Pre_Compressor2_Tin, Pre_Compressor2_Pout, Pre_Compressor2_Tout;

        public Double Pre_Compressor2_Flow, Pre_Compressor2_Diameter1, Pre_Compressor2_Diameter2, Pre_Compressor2_Rotation_Velocity;

        public Double Pre_Compressor2_Efficiency, Pre_Compressor2_Phi; //Pre_Compressor_Phi is the Compressor Flow Factor
        public Boolean Pre_Compressor2_Surge;

        //Recompressor results
        public Double ReCompressor_Pin, ReCompressor_Tin, ReCompressor_Pout, ReCompressor_Tout;
        public Double ReCompressor_Flow, ReCompressor_Diameter1, ReCompressor_Diameter2, ReCompressor_Rotation_Velocity;

        public Double ReCompressor_Efficiency, ReCompressor_Phi; //Main_Compressor_Phi is the Compressor Flow Factor

        public Boolean ReCompressor_Surge;

        //Main Turbine results
        public Double Main_Turbine_Pin, Main_Turbine_Tin, Main_Turbine_Pout, Main_Turbine_Tout;
        public Double Main_Turbine_Flow, Main_Turbine_Rotary_Velocity, Main_Turbine_Diameter, Main_Turbine_Efficiency, Main_Turbine_Anozzle;
        public Double Main_Turbine_nu, Main_Turbine_w_Tip_Ratio;

        //ReHeating1 Turbine results
        public Double ReHeating1_Turbine_Pin, ReHeating1_Turbine_Tin, ReHeating1_Turbine_Pout, ReHeating1_Turbine_Tout;
        public Double ReHeating1_Turbine_Flow, ReHeating1_Turbine_Rotary_Velocity, ReHeating1_Turbine_Diameter, ReHeating1_Turbine_Efficiency, ReHeating1_Turbine_Anozzle;
        public Double ReHeating1_Turbine_nu, ReHeating1_Turbine_w_Tip_Ratio;

        //ReHeating2 Turbine results
        public Double ReHeating2_Turbine_Pin, ReHeating2_Turbine_Tin, ReHeating2_Turbine_Pout, ReHeating2_Turbine_Tout;
        public Double ReHeating2_Turbine_Flow, ReHeating2_Turbine_Rotary_Velocity, ReHeating2_Turbine_Diameter, ReHeating2_Turbine_Efficiency, ReHeating2_Turbine_Anozzle;
        public Double ReHeating2_Turbine_nu, ReHeating2_Turbine_w_Tip_Ratio;

        //ReHeating3 Turbine results
        public Double ReHeating3_Turbine_Pin, ReHeating3_Turbine_Tin, ReHeating3_Turbine_Pout, ReHeating3_Turbine_Tout;
        public Double ReHeating3_Turbine_Flow, ReHeating3_Turbine_Rotary_Velocity, ReHeating3_Turbine_Diameter, ReHeating3_Turbine_Efficiency, ReHeating3_Turbine_Anozzle;
        public Double ReHeating3_Turbine_nu, ReHeating3_Turbine_w_Tip_Ratio;

        //LTR results 
        public Double LTR_Qdot, LTR_Num_HXs, LTR_mdot_c, LTR_mdot_h, LTR_cold_Pin, LTR_cold_Tin, LTR_cold_Pout, LTR_cold_Tout;
        public Double LTR_hot_Pin, LTR_hot_Tin, LTR_hot_Pout, LTR_hot_Tout;
        public Double LTR_UA, LTR_NTU, LTR_CR, LTR_min_DT, LTR_Effectiveness, LTR_Q_per_module, LTR_number_modules;
        public Double LTR_mdot_h_module, LTR_mdot_c_module, LTR_UA_module, LTR_NTU_module, LTR_CR_module, LTR_min_DT_module, LTR_Effectiveness_module;

        public Double[] LTR_T_cold = new Double[25];

        public Double[] LTR_T_hot = new Double[25];

        public Double[] LTR_UA_local = new Double[25];

        public Double[] LTR_NTU_local = new Double[25];

        public Double[] LTR_CR_local = new Double[25];

        public Double[] LTR_Effec_local = new Double[25];
        public Double[] LTR_C_dot_c_local = new Double[25];

        public Double[] LTR_C_dot_h_local = new Double[25];

        public Double[] LTR_UA_local_module = new Double[25];

        public Double[] LTR_NTU_local_module = new Double[25];
        public Double[] LTR_CR_local_module = new Double[25];
        public Double[] LTR_Effec_local_module = new Double[25];
        public Double[] LTR_C_dot_c_local_module = new Double[25];
        public Double[] LTR_C_dot_h_local_module = new Double[25];

        //HTR results
        public Double HTR_Qdot, HTR_Num_HXs, HTR_mdot_c, HTR_mdot_h, HTR_cold_Pin, HTR_cold_Tin, HTR_cold_Pout, HTR_cold_Tout;
        public Double HTR_hot_Pin, HTR_hot_Tin, HTR_hot_Pout, HTR_hot_Tout;
        public Double HTR_UA, HTR_NTU, HTR_CR, HTR_min_DT, HTR_Effectiveness, HTR_Q_per_module, HTR_number_modules;
        public Double HTR_mdot_h_module, HTR_mdot_c_module, HTR_UA_module, HTR_NTU_module, HTR_CR_module, HTR_min_DT_module, HTR_Effectiveness_module;

        public Double[] HTR_T_cold = new Double[25];
        public Double[] HTR_T_hot = new Double[25];

        public Double[] HTR_UA_local = new Double[25];
        public Double[] HTR_NTU_local = new Double[25];
        public Double[] HTR_CR_local = new Double[25];
        public Double[] HTR_Effec_local = new Double[25];
        public Double[] HTR_C_dot_c_local = new Double[25];
        public Double[] HTR_C_dot_h_local = new Double[25];

        public Double[] HTR_UA_local_module = new Double[25];
        public Double[] HTR_NTU_local_module = new Double[25];
        public Double[] HTR_CR_local_module = new Double[25];
        public Double[] HTR_Effec_local_module = new Double[25];
        public Double[] HTR_C_dot_c_local_module = new Double[25];
        public Double[] HTR_C_dot_h_local_module = new Double[25];

        public Double specific_work_main_turbine = 0;
        public Double specific_work_reheating1_turbine = 0;
        public Double specific_work_reheating2_turbine = 0;
        public Double specific_work_reheating3_turbine = 0;
        public Double specific_work_compressor1 = 0;
        public Double specific_work_compressor2 = 0;
        public Double specific_work_compressor3 = 0;
        public Double specific_work_compressor4 = 0;
        public Double Miscellanous_Auxiliaries = 0;
        public Double Total_Auxiliaries = 0;

        public Double w_dot_net2;
        public Double t_mc_in2;
        public Double t_t_in2;
        public Double p_rhx1_in2;
        public Double t_rht1_in2;
        public Double p_rhx2_in2;
        public Double t_rht2_in2;
        public Double p_rhx3_in2;
        public Double t_rht3_in2;
        public Double ua_lt2, ua_ht2;
        public Double eta_mc2;
        public Double eta_rc2;
        public Double eta_pc12;
        public Double eta_pc22;
        public Double eta_t2;
        public Double eta_trh12;
        public Double eta_trh22;
        public Double eta_trh32;
        public Int64 n_sub_hxrs2;
        public Double p_mc_in2;
        public Double p_mc_out2;
        public Double p_pc1_in2;
        public Double t_pc1_in2;
        public Double p_pc1_out2;
        public Double p_pc2_in2;
        public Double t_pc2_in2;
        public Double p_pc2_out2;
        public Double recomp_frac2;
        public Double tol2;
        public Double eta_thermal2;

        public Double dp2_lt1, dp2_lt2;
        public Double dp2_ht1, dp2_ht2;
        public Double dp2_pc11, dp2_pc12;
        public Double dp2_pc21, dp2_pc22;
        public Double dp2_phx1, dp2_phx2;
        public Double dp2_rhx11, dp2_rhx12;
        public Double dp2_rhx21, dp2_rhx22;
        public Double dp2_rhx31, dp2_rhx32;
        public Double dp2_cooler1, dp2_cooler2;

        public Double temp21;
        public Double temp22;
        public Double temp23;
        public Double temp24;
        public Double temp25;
        public Double temp26;
        public Double temp27;
        public Double temp28;
        public Double temp29;
        public Double temp210;
        public Double temp211;
        public Double temp212;
        public Double temp213;
        public Double temp214;
        public Double temp215;
        public Double temp216;
        public Double temp217;
        public Double temp218;
        public Double temp219;
        public Double temp220;

        public Double pres21;
        public Double pres22;
        public Double pres23;
        public Double pres24;
        public Double pres25;
        public Double pres26;
        public Double pres27;
        public Double pres28;
        public Double pres29;
        public Double pres210;
        public Double pres211;
        public Double pres212;
        public Double pres213;
        public Double pres214;
        public Double pres215;
        public Double pres216;
        public Double pres217;
        public Double pres218;
        public Double pres219;
        public Double pres220;

        public Double enth21;
        public Double enth22;
        public Double enth23;
        public Double enth24;
        public Double enth25;
        public Double enth26;
        public Double enth27;
        public Double enth28;
        public Double enth29;
        public Double enth210;
        public Double enth211;
        public Double enth212;
        public Double enth213;
        public Double enth214;
        public Double enth215;
        public Double enth216;
        public Double enth217;
        public Double enth218;
        public Double enth219;
        public Double enth220;

        public Double entr21;
        public Double entr22;
        public Double entr23;
        public Double entr24;
        public Double entr25;
        public Double entr26;
        public Double entr27;
        public Double entr28;
        public Double entr29;
        public Double entr210;
        public Double entr211;
        public Double entr212;
        public Double entr213;
        public Double entr214;
        public Double entr215;
        public Double entr216;
        public Double entr217;
        public Double entr218;
        public Double entr219;
        public Double entr220;

        public Double massflow2;
        public Double LT_mdoth, LT_mdotc, LT_Tcin, LT_Thin, LT_Pcin, LT_Phin;
        public Double LT_Pcout, LT_Phout, LT_Q, HT_mdoth, HT_mdotc, HT_Tcin, HT_Thin;
        public Double HT_Pcin, HT_Phin, HT_Pcout, HT_Phout, HT_Q, LT_UA, HT_UA;
        public Double LT_Effc, HT_Effc;

        public Double PHX1, RHX1, RHX2, RHX3, PC11, PC21, PC31;

        public PCRC_with_Two_Intercooling_with_Three_ReHeating()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "PureFluid")
            {
                comboBox6.Enabled = false;
                comboBox12.Enabled = false;
                comboBox7.Enabled = false;
                textBox68.Enabled = false;
                textBox69.Enabled = false;
                textBox33.Enabled = false;
                textBox34.Enabled = false;
                button11.Enabled = false;
                button2.Enabled = true;
            }

            else if (comboBox1.Text == "NewMixture")
            {
                comboBox6.Enabled = true;
                comboBox12.Enabled = true;
                comboBox7.Enabled = true;
                textBox68.Enabled = true;
                textBox69.Enabled = true;
                textBox33.Enabled = true;
                textBox34.Enabled = true;
                button11.Enabled = true;
                button2.Enabled = false;

                Refrigerant working_fluid = new Refrigerant(RefrigerantCategory.NewMixture, this.comboBox2.Text + "=" + textBox68.Text + "," + this.comboBox6.Text + "=" + textBox69.Text + "," + this.comboBox12.Text + "=" + textBox33.Text + "," + this.comboBox7.Text + "=" + textBox34.Text, ReferenceState.DEF);

                textBox32.Text = Convert.ToString(working_fluid.CriticalPressure);
                textBox31.Text = Convert.ToString(working_fluid.CriticalTemperature);
                textBox30.Text = Convert.ToString(working_fluid.CriticalDensity);
            }
        }

        //Mixtures Calculation
        private void button20_Click(object sender, EventArgs e)
        {
            int maxIterations = 5;
            int numIterations = 0;

            //PureFluid
            if (comboBox1.Text == "PureFluid")
            {
                category = RefrigerantCategory.PureFluid;
                luis.core1(this.comboBox1.Text, category);
            }

            //NewMixture
            if (comboBox1.Text == "NewMixture")
            {
                category = RefrigerantCategory.NewMixture;
                luis.core1(this.comboBox2.Text + "=" + textBox68.Text + "," + this.comboBox6.Text + "=" + textBox69.Text + "," + this.comboBox12.Text + "=" + textBox33.Text + "," + this.comboBox7.Text + "=" + textBox34.Text, category);
            }

            if (comboBox1.Text == "PredefinedMixture")
            {
                category = RefrigerantCategory.PredefinedMixture;
            }

            if (comboBox1.Text == "PseudoPureFluid")
            {
                category = RefrigerantCategory.PseudoPureFluid;
            }

            if (comboBox3.Text == "DEF")
            {
                referencestate = ReferenceState.DEF;
            }
            if (comboBox3.Text == "ASH")
            {
                referencestate = ReferenceState.ASH;
            }
            if (comboBox3.Text == "IIR")
            {
                referencestate = ReferenceState.IIR;
            }
            if (comboBox3.Text == "NBP")
            {
                referencestate = ReferenceState.NBP;
            }

            luis.working_fluid.Category = category;
            luis.working_fluid.reference = referencestate;

            w_dot_net2 = Convert.ToDouble(textBox1.Text);
            t_mc_in2 = Convert.ToDouble(textBox2.Text);
            t_t_in2 = Convert.ToDouble(textBox4.Text);
            t_rht1_in2 = Convert.ToDouble(textBox100.Text);
            p_rhx1_in2 = Convert.ToDouble(textBox99.Text);
            t_rht2_in2 = Convert.ToDouble(textBox101.Text);
            p_rhx2_in2 = Convert.ToDouble(textBox102.Text);
            t_rht3_in2 = Convert.ToDouble(textBox108.Text);
            p_rhx3_in2 = Convert.ToDouble(textBox109.Text);
            ua_lt2 = Convert.ToDouble(textBox17.Text);
            ua_ht2 = Convert.ToDouble(textBox16.Text);
            eta_mc2 = Convert.ToDouble(textBox14.Text);
            eta_rc2 = Convert.ToDouble(textBox13.Text);
            eta_pc22 = Convert.ToDouble(textBox24.Text);
            eta_pc12 = Convert.ToDouble(textBox83.Text);
            eta_t2 = Convert.ToDouble(textBox19.Text);
            eta_trh12 = Convert.ToDouble(textBox88.Text);
            eta_trh22 = Convert.ToDouble(textBox103.Text);
            eta_trh32 = Convert.ToDouble(textBox9.Text);
            n_sub_hxrs2 = Convert.ToInt64(textBox20.Text);
            p_mc_in2 = Convert.ToDouble(textBox3.Text);
            p_mc_out2 = Convert.ToDouble(textBox28.Text);
            p_pc2_in2 = Convert.ToDouble(textBox23.Text);
            t_pc2_in2 = Convert.ToDouble(textBox22.Text);
            p_pc2_out2 = Convert.ToDouble(textBox8.Text);
            p_pc1_in2 = Convert.ToDouble(textBox86.Text);
            t_pc1_in2 = Convert.ToDouble(textBox84.Text);
            p_pc1_out2 = Convert.ToDouble(textBox87.Text);
            recomp_frac2 = Convert.ToDouble(textBox15.Text);
            tol2 = Convert.ToDouble(textBox21.Text);
            //eta_thermal2 = Convert.ToDouble(textBox50.Text);

            dp2_lt1 = Convert.ToDouble(textBox5.Text);
            dp2_lt2 = Convert.ToDouble(textBox26.Text);
            dp2_ht1 = Convert.ToDouble(textBox12.Text);
            dp2_ht2 = Convert.ToDouble(textBox25.Text);
            dp2_pc11 = Convert.ToDouble(textBox11.Text);
            dp2_pc21 = Convert.ToDouble(textBox85.Text);
            //dp2_pc2 = Convert.ToDouble(textBox11.Text);
            dp2_phx1 = Convert.ToDouble(textBox10.Text);
            dp2_rhx11 = Convert.ToDouble(textBox89.Text);
            dp2_rhx21 = Convert.ToDouble(textBox98.Text);
            dp2_rhx31 = Convert.ToDouble(textBox29.Text);
            //dp2_phx2 = Convert.ToDouble(textBox1.Text);
            //dp2_rhx1 = Convert.ToDouble(textBox1.Text);
            //dp2_rhx2 = Convert.ToDouble(textBox1.Text);
            //dp2_cooler1 = Convert.ToDouble(textBox1.Text);
            dp2_cooler2 = Convert.ToDouble(textBox27.Text);

            luis.wmm = luis.working_fluid.MolecularWeight;

            core.PCRCwithTwoIntercoolingWithThreeReheating cicloPCRC_withTwoIntercoolingwithThreeRH = new core.PCRCwithTwoIntercoolingWithThreeReheating();

            //increasingCIP:

            luis.RecompCycle_PCRC_withTwoIntercooling_withThreeReheating(luis, ref cicloPCRC_withTwoIntercoolingwithThreeRH,
                w_dot_net2, t_t_in2, p_rhx1_in2, t_rht1_in2, p_rhx2_in2, t_rht2_in2, p_rhx3_in2, t_rht3_in2, t_mc_in2,
                p_mc_in2, p_mc_out2, p_pc1_in2, t_pc1_in2, p_pc1_out2, p_pc2_in2, t_pc2_in2, p_pc2_out2, ua_lt2, ua_ht2, 
                eta_mc2, eta_rc2, eta_pc12, eta_pc22, eta_t2, eta_trh12, eta_trh22, eta_trh32, n_sub_hxrs2, recomp_frac2,
                tol2, eta_thermal2, -dp2_lt1, -dp2_lt2, -dp2_ht1, -dp2_ht2, -dp2_pc11, -dp2_pc12, -dp2_pc21, -dp2_pc22,
                -dp2_phx1, -dp2_phx2, -dp2_rhx11, -dp2_rhx12, -dp2_rhx21, -dp2_rhx22, -dp2_rhx31, -dp2_rhx32, -dp2_cooler1, 
                -dp2_cooler2);

            //if (cicloPCRC_withoutRH.eta_thermal == 0)
            //{
            //    p_mc_in2 = p_mc_in2 + 10.0;
            //    numIterations++;

            //    if (numIterations < maxIterations)
            //    {
            //        goto increasingCIP;
            //    }
            //}

            massflow2 = cicloPCRC_withTwoIntercoolingwithThreeRH.m_dot_turbine;
            w_dot_net2 = cicloPCRC_withTwoIntercoolingwithThreeRH.W_dot_net;
            eta_thermal2 = cicloPCRC_withTwoIntercoolingwithThreeRH.eta_thermal;
            recomp_frac2 = cicloPCRC_withTwoIntercoolingwithThreeRH.recomp_frac;

            temp21 = cicloPCRC_withTwoIntercoolingwithThreeRH.temp[0];
            temp22 = cicloPCRC_withTwoIntercoolingwithThreeRH.temp[1];
            temp23 = cicloPCRC_withTwoIntercoolingwithThreeRH.temp[2];
            temp24 = cicloPCRC_withTwoIntercoolingwithThreeRH.temp[3];
            temp25 = cicloPCRC_withTwoIntercoolingwithThreeRH.temp[4];
            temp26 = cicloPCRC_withTwoIntercoolingwithThreeRH.temp[5];
            temp27 = cicloPCRC_withTwoIntercoolingwithThreeRH.temp[6];
            temp28 = cicloPCRC_withTwoIntercoolingwithThreeRH.temp[7];
            temp29 = cicloPCRC_withTwoIntercoolingwithThreeRH.temp[8];
            temp210 = cicloPCRC_withTwoIntercoolingwithThreeRH.temp[9];
            temp211 = cicloPCRC_withTwoIntercoolingwithThreeRH.temp[10];
            temp212 = cicloPCRC_withTwoIntercoolingwithThreeRH.temp[11];
            temp213 = cicloPCRC_withTwoIntercoolingwithThreeRH.temp[12];
            temp214 = cicloPCRC_withTwoIntercoolingwithThreeRH.temp[13];
            temp215 = cicloPCRC_withTwoIntercoolingwithThreeRH.temp[14];
            temp216 = cicloPCRC_withTwoIntercoolingwithThreeRH.temp[15];
            temp217 = cicloPCRC_withTwoIntercoolingwithThreeRH.temp[16];
            temp218 = cicloPCRC_withTwoIntercoolingwithThreeRH.temp[17];
            temp219 = cicloPCRC_withTwoIntercoolingwithThreeRH.temp[18];
            temp220 = cicloPCRC_withTwoIntercoolingwithThreeRH.temp[19];

            pres21 = cicloPCRC_withTwoIntercoolingwithThreeRH.pres[0];
            pres22 = cicloPCRC_withTwoIntercoolingwithThreeRH.pres[1];
            pres23 = cicloPCRC_withTwoIntercoolingwithThreeRH.pres[2];
            pres24 = cicloPCRC_withTwoIntercoolingwithThreeRH.pres[3];
            pres25 = cicloPCRC_withTwoIntercoolingwithThreeRH.pres[4];
            pres26 = cicloPCRC_withTwoIntercoolingwithThreeRH.pres[5];
            pres27 = cicloPCRC_withTwoIntercoolingwithThreeRH.pres[6];
            pres28 = cicloPCRC_withTwoIntercoolingwithThreeRH.pres[7];
            pres29 = cicloPCRC_withTwoIntercoolingwithThreeRH.pres[8];
            pres210 = cicloPCRC_withTwoIntercoolingwithThreeRH.pres[9];
            pres211 = cicloPCRC_withTwoIntercoolingwithThreeRH.pres[10];
            pres212 = cicloPCRC_withTwoIntercoolingwithThreeRH.pres[11];
            pres213 = cicloPCRC_withTwoIntercoolingwithThreeRH.pres[12];
            pres214 = cicloPCRC_withTwoIntercoolingwithThreeRH.pres[13];
            pres215 = cicloPCRC_withTwoIntercoolingwithThreeRH.pres[14];
            pres216 = cicloPCRC_withTwoIntercoolingwithThreeRH.pres[15];
            pres217 = cicloPCRC_withTwoIntercoolingwithThreeRH.pres[16];
            pres218 = cicloPCRC_withTwoIntercoolingwithThreeRH.pres[17];
            pres219 = cicloPCRC_withTwoIntercoolingwithThreeRH.pres[18];
            pres220 = cicloPCRC_withTwoIntercoolingwithThreeRH.pres[19];

            //Fill results in the Graphical User Interface (GUI)
            //textBox6.Text = Convert.ToString(N_design_Main_Compressor);

            textBox47.Text = Convert.ToString(temp21);
            textBox46.Text = Convert.ToString(temp22);
            textBox45.Text = Convert.ToString(temp23);
            textBox44.Text = Convert.ToString(temp24);
            textBox43.Text = Convert.ToString(temp25);
            textBox42.Text = Convert.ToString(temp26);
            textBox35.Text = Convert.ToString(temp27);
            textBox18.Text = Convert.ToString(temp28);
            textBox7.Text = Convert.ToString(temp29);
            textBox6.Text = Convert.ToString(temp210);
            textBox57.Text = Convert.ToString(temp211);
            textBox56.Text = Convert.ToString(temp212);
            textBox70.Text = Convert.ToString(temp213);
            textBox81.Text = Convert.ToString(temp214);
            textBox90.Text = Convert.ToString(temp215);
            textBox92.Text = Convert.ToString(temp216);
            textBox96.Text = Convert.ToString(temp217);
            textBox94.Text = Convert.ToString(temp218);
            textBox106.Text = Convert.ToString(temp219);
            textBox104.Text = Convert.ToString(temp220);

            textBox54.Text = Convert.ToString(pres21);
            textBox53.Text = Convert.ToString(pres22);
            textBox52.Text = Convert.ToString(pres23);
            textBox51.Text = Convert.ToString(pres24);
            textBox37.Text = Convert.ToString(pres25);
            textBox36.Text = Convert.ToString(pres26);
            textBox41.Text = Convert.ToString(pres27);
            textBox40.Text = Convert.ToString(pres28);
            textBox39.Text = Convert.ToString(pres29);
            textBox38.Text = Convert.ToString(pres210);
            textBox59.Text = Convert.ToString(pres211);
            textBox58.Text = Convert.ToString(pres212);
            textBox80.Text = Convert.ToString(pres213);
            textBox82.Text = Convert.ToString(pres214);
            textBox91.Text = Convert.ToString(pres215);
            textBox93.Text = Convert.ToString(pres216);
            textBox97.Text = Convert.ToString(pres217);
            textBox95.Text = Convert.ToString(pres218);
            textBox107.Text = Convert.ToString(pres219);
            textBox105.Text = Convert.ToString(pres220);

            String point1_state, point2_state, point3_state, point4_state, point5_state, point6_state;
            String point7_state, point8_state, point9_state, point10_state, point11_state, point12_state,
                   point13_state, point14_state, point15_state, point16_state, point17_state, point18_state,
                   point19_state, point20_state;

            luis.working_fluid.FindStateWithTP(temp21, pres21);
            enth21 = luis.working_fluid.Enthalpy;
            entr21 = luis.working_fluid.Entropy;

            luis.working_fluid.FindStateWithTP(temp22, pres22);
            enth22 = luis.working_fluid.Enthalpy;
            entr22 = luis.working_fluid.Entropy;

            luis.working_fluid.FindStateWithTP(temp23, pres23);
            enth23 = luis.working_fluid.Enthalpy;
            entr23 = luis.working_fluid.Entropy;

            luis.working_fluid.FindStateWithTP(temp24, pres24);
            enth24 = luis.working_fluid.Enthalpy;
            entr24 = luis.working_fluid.Entropy;

            luis.working_fluid.FindStateWithTP(temp25, pres25);
            enth25 = luis.working_fluid.Enthalpy;
            entr25 = luis.working_fluid.Entropy;

            luis.working_fluid.FindStateWithTP(temp26, pres26);
            enth26 = luis.working_fluid.Enthalpy;
            entr26 = luis.working_fluid.Entropy;

            luis.working_fluid.FindStateWithTP(temp27, pres27);
            enth27 = luis.working_fluid.Enthalpy;
            entr27 = luis.working_fluid.Entropy;

            luis.working_fluid.FindStateWithTP(temp28, pres28);
            enth28 = luis.working_fluid.Enthalpy;
            entr28 = luis.working_fluid.Entropy;

            luis.working_fluid.FindStateWithTP(temp29, pres29);
            enth29 = luis.working_fluid.Enthalpy;
            entr29 = luis.working_fluid.Entropy;

            luis.working_fluid.FindStateWithTP(temp210, pres210);
            enth210 = luis.working_fluid.Enthalpy;
            entr210 = luis.working_fluid.Entropy;

            luis.working_fluid.FindStateWithTP(temp211, pres211);
            enth211 = luis.working_fluid.Enthalpy;
            entr211 = luis.working_fluid.Entropy;

            luis.working_fluid.FindStateWithTP(temp212, pres212);
            enth212 = luis.working_fluid.Enthalpy;
            entr212 = luis.working_fluid.Entropy;

            luis.working_fluid.FindStateWithTP(temp213, pres213);
            enth213 = luis.working_fluid.Enthalpy;
            entr213 = luis.working_fluid.Entropy;

            luis.working_fluid.FindStateWithTP(temp214, pres214);
            enth214 = luis.working_fluid.Enthalpy;
            entr214 = luis.working_fluid.Entropy;

            luis.working_fluid.FindStateWithTP(temp215, pres215);
            enth215 = luis.working_fluid.Enthalpy;
            entr215 = luis.working_fluid.Entropy;

            luis.working_fluid.FindStateWithTP(temp216, pres216);
            enth216 = luis.working_fluid.Enthalpy;
            entr216 = luis.working_fluid.Entropy;

            luis.working_fluid.FindStateWithTP(temp217, pres217);
            enth217 = luis.working_fluid.Enthalpy;
            entr217 = luis.working_fluid.Entropy;

            luis.working_fluid.FindStateWithTP(temp218, pres218);
            enth218 = luis.working_fluid.Enthalpy;
            entr218 = luis.working_fluid.Entropy;

            luis.working_fluid.FindStateWithTP(temp219, pres219);
            enth219 = luis.working_fluid.Enthalpy;
            entr219 = luis.working_fluid.Entropy;

            luis.working_fluid.FindStateWithTP(temp220, pres220);
            enth220 = luis.working_fluid.Enthalpy;
            entr220 = luis.working_fluid.Entropy;

            point1_state = "Pressure (kPa):" + Convert.ToString(pres21) + Environment.NewLine +
                            "Temperature (K):" + Convert.ToString(temp21) + Environment.NewLine +
                            "Entalphy (kJ/kg):" + Convert.ToString(enth21) + Environment.NewLine +
                            "Entrophy (kJ/kg K):" + Convert.ToString(entr21) + Environment.NewLine;

            point2_state = "Pressure (kPa):" + Convert.ToString(pres22) + Environment.NewLine +
                            "Temperature (K):" + Convert.ToString(temp22) + Environment.NewLine +
                            "Entalphy (kJ/kg):" + Convert.ToString(enth22) + Environment.NewLine +
                            "Entrophy (kJ/kg K):" + Convert.ToString(entr22) + Environment.NewLine;

            point3_state = "Pressure (kPa):" + Convert.ToString(pres23) + Environment.NewLine +
                        "Temperature (K):" + Convert.ToString(temp23) + Environment.NewLine +
                        "Entalphy (kJ/kg):" + Convert.ToString(enth23) + Environment.NewLine +
                        "Entrophy (kJ/kg K):" + Convert.ToString(entr23) + Environment.NewLine;

            point4_state = "Pressure (kPa):" + Convert.ToString(pres24) + Environment.NewLine +
                        "Temperature (K):" + Convert.ToString(temp24) + Environment.NewLine +
                        "Entalphy (kJ/kg):" + Convert.ToString(enth24) + Environment.NewLine +
                        "Entrophy (kJ/kg K):" + Convert.ToString(entr24) + Environment.NewLine;

            point5_state = "Pressure (kPa):" + Convert.ToString(pres25) + Environment.NewLine +
                        "Temperature (K):" + Convert.ToString(temp25) + Environment.NewLine +
                        "Entalphy (kJ/kg):" + Convert.ToString(enth25) + Environment.NewLine +
                        "Entrophy (kJ/kg K):" + Convert.ToString(entr25) + Environment.NewLine;

            point6_state = "Pressure (kPa):" + Convert.ToString(pres26) + Environment.NewLine +
                        "Temperature (K):" + Convert.ToString(temp26) + Environment.NewLine +
                        "Entalphy (kJ/kg):" + Convert.ToString(enth26) + Environment.NewLine +
                        "Entrophy (kJ/kg K):" + Convert.ToString(entr26) + Environment.NewLine;

            point7_state = "Pressure (kPa):" + Convert.ToString(pres27) + Environment.NewLine +
                        "Temperature (K):" + Convert.ToString(temp27) + Environment.NewLine +
                        "Entalphy (kJ/kg):" + Convert.ToString(enth27) + Environment.NewLine +
                        "Entrophy (kJ/kg K):" + Convert.ToString(entr27) + Environment.NewLine;

            point8_state = "Pressure (kPa):" + Convert.ToString(pres28) + Environment.NewLine +
                        "Temperature (K):" + Convert.ToString(temp28) + Environment.NewLine +
                        "Entalphy (kJ/kg):" + Convert.ToString(enth28) + Environment.NewLine +
                        "Entrophy (kJ/kg K):" + Convert.ToString(entr28) + Environment.NewLine;

            point9_state = "Pressure (kPa):" + Convert.ToString(pres29) + Environment.NewLine +
                        "Temperature (K):" + Convert.ToString(temp29) + Environment.NewLine +
                        "Entalphy (kJ/kg):" + Convert.ToString(enth29) + Environment.NewLine +
                        "Entrophy (kJ/kg K):" + Convert.ToString(entr29) + Environment.NewLine;

            point10_state = "Pressure (kPa):" + Convert.ToString(pres210) + Environment.NewLine +
                        "Temperature (K):" + Convert.ToString(temp210) + Environment.NewLine +
                        "Entalphy (kJ/kg):" + Convert.ToString(enth210) + Environment.NewLine +
                        "Entrophy (kJ/kg K):" + Convert.ToString(entr210) + Environment.NewLine;

            point11_state = "Pressure (kPa):" + Convert.ToString(pres211) + Environment.NewLine +
                        "Temperature (K):" + Convert.ToString(temp211) + Environment.NewLine +
                        "Entalphy (kJ/kg):" + Convert.ToString(enth211) + Environment.NewLine +
                        "Entrophy (kJ/kg K):" + Convert.ToString(entr211) + Environment.NewLine;

            point12_state = "Pressure (kPa):" + Convert.ToString(pres212) + Environment.NewLine +
                        "Temperature (K):" + Convert.ToString(temp212) + Environment.NewLine +
                        "Entalphy (kJ/kg):" + Convert.ToString(enth212) + Environment.NewLine +
                        "Entrophy (kJ/kg K):" + Convert.ToString(entr212) + Environment.NewLine;

            point13_state = "Pressure (kPa):" + Convert.ToString(pres213) + Environment.NewLine +
                        "Temperature (K):" + Convert.ToString(temp213) + Environment.NewLine +
                        "Entalphy (kJ/kg):" + Convert.ToString(enth213) + Environment.NewLine +
                        "Entrophy (kJ/kg K):" + Convert.ToString(entr213) + Environment.NewLine;

            point14_state = "Pressure (kPa):" + Convert.ToString(pres214) + Environment.NewLine +
                        "Temperature (K):" + Convert.ToString(temp214) + Environment.NewLine +
                        "Entalphy (kJ/kg):" + Convert.ToString(enth214) + Environment.NewLine +
                        "Entrophy (kJ/kg K):" + Convert.ToString(entr214) + Environment.NewLine;

            point15_state = "Pressure (kPa):" + Convert.ToString(pres215) + Environment.NewLine +
                       "Temperature (K):" + Convert.ToString(temp215) + Environment.NewLine +
                       "Entalphy (kJ/kg):" + Convert.ToString(enth215) + Environment.NewLine +
                       "Entrophy (kJ/kg K):" + Convert.ToString(entr215) + Environment.NewLine;

            point16_state = "Pressure (kPa):" + Convert.ToString(pres216) + Environment.NewLine +
                       "Temperature (K):" + Convert.ToString(temp216) + Environment.NewLine +
                       "Entalphy (kJ/kg):" + Convert.ToString(enth216) + Environment.NewLine +
                       "Entrophy (kJ/kg K):" + Convert.ToString(entr216) + Environment.NewLine;

            point17_state = "Pressure (kPa):" + Convert.ToString(pres217) + Environment.NewLine +
                     "Temperature (K):" + Convert.ToString(temp217) + Environment.NewLine +
                     "Entalphy (kJ/kg):" + Convert.ToString(enth217) + Environment.NewLine +
                     "Entrophy (kJ/kg K):" + Convert.ToString(entr217) + Environment.NewLine;

            point18_state = "Pressure (kPa):" + Convert.ToString(pres218) + Environment.NewLine +
                     "Temperature (K):" + Convert.ToString(temp218) + Environment.NewLine +
                     "Entalphy (kJ/kg):" + Convert.ToString(enth218) + Environment.NewLine +
                     "Entrophy (kJ/kg K):" + Convert.ToString(entr218) + Environment.NewLine;

            point19_state = "Pressure (kPa):" + Convert.ToString(pres219) + Environment.NewLine +
                    "Temperature (K):" + Convert.ToString(temp219) + Environment.NewLine +
                    "Entalphy (kJ/kg):" + Convert.ToString(enth219) + Environment.NewLine +
                    "Entrophy (kJ/kg K):" + Convert.ToString(entr219) + Environment.NewLine;

            point20_state = "Pressure (kPa):" + Convert.ToString(pres220) + Environment.NewLine +
                    "Temperature (K):" + Convert.ToString(temp220) + Environment.NewLine +
                    "Entalphy (kJ/kg):" + Convert.ToString(enth220) + Environment.NewLine +
                    "Entrophy (kJ/kg K):" + Convert.ToString(entr220) + Environment.NewLine;

            textBox48.Text = Convert.ToString(w_dot_net2);
            textBox49.Text = Convert.ToString(massflow2);
            textBox50.Text = Convert.ToString(eta_thermal2 * 100);

            toolTip1.SetToolTip(label55, point1_state);
            toolTip2.SetToolTip(label57, point2_state);
            toolTip3.SetToolTip(label59, point3_state);
            toolTip4.SetToolTip(label60, point4_state);
            toolTip5.SetToolTip(label61, point5_state);
            toolTip6.SetToolTip(label62, point6_state);
            toolTip7.SetToolTip(label63, point7_state);
            toolTip8.SetToolTip(label65, point8_state);
            toolTip9.SetToolTip(label66, point9_state);
            toolTip10.SetToolTip(label67, point10_state);
            toolTip10.SetToolTip(label67, point10_state);

            //If High temperature checkBox is unchecked
            if (checkBox1.Checked == false)
            {
                PHX1 = cicloPCRC_withTwoIntercoolingwithThreeRH.PHX.Q_dot;
                RHX1 = cicloPCRC_withTwoIntercoolingwithThreeRH.RHX1.Q_dot;
                RHX2 = cicloPCRC_withTwoIntercoolingwithThreeRH.RHX2.Q_dot;
                RHX3 = cicloPCRC_withTwoIntercoolingwithThreeRH.RHX3.Q_dot;

                LT_Q = cicloPCRC_withTwoIntercoolingwithThreeRH.LT.Q_dot;
                LT_mdotc = cicloPCRC_withTwoIntercoolingwithThreeRH.LT.m_dot_design[0];
                LT_mdoth = cicloPCRC_withTwoIntercoolingwithThreeRH.LT.m_dot_design[1];
                LT_Tcin = cicloPCRC_withTwoIntercoolingwithThreeRH.LT.T_c_in;
                LT_Thin = cicloPCRC_withTwoIntercoolingwithThreeRH.LT.T_h_in;
                LT_Pcin = cicloPCRC_withTwoIntercoolingwithThreeRH.LT.P_c_in;
                LT_Phin = cicloPCRC_withTwoIntercoolingwithThreeRH.LT.P_h_in;
                LT_Pcout = cicloPCRC_withTwoIntercoolingwithThreeRH.LT.P_c_out;
                LT_Phout = cicloPCRC_withTwoIntercoolingwithThreeRH.LT.P_h_out;
                LT_Effc = cicloPCRC_withTwoIntercoolingwithThreeRH.LT.eff;

                HT_Q = cicloPCRC_withTwoIntercoolingwithThreeRH.HT.Q_dot;
                HT_mdotc = cicloPCRC_withTwoIntercoolingwithThreeRH.HT.m_dot_design[0];
                HT_mdoth = cicloPCRC_withTwoIntercoolingwithThreeRH.HT.m_dot_design[1];
                HT_Tcin = cicloPCRC_withTwoIntercoolingwithThreeRH.HT.T_c_in;
                HT_Thin = cicloPCRC_withTwoIntercoolingwithThreeRH.HT.T_h_in;
                HT_Pcin = cicloPCRC_withTwoIntercoolingwithThreeRH.HT.P_c_in;
                HT_Phin = cicloPCRC_withTwoIntercoolingwithThreeRH.HT.P_h_in;
                HT_Pcout = cicloPCRC_withTwoIntercoolingwithThreeRH.HT.P_c_out;
                HT_Phout = cicloPCRC_withTwoIntercoolingwithThreeRH.HT.P_h_out;
                HT_Effc = cicloPCRC_withTwoIntercoolingwithThreeRH.HT.eff;

                PC11 = cicloPCRC_withTwoIntercoolingwithThreeRH.PC1.Q_dot;
                PC21 = cicloPCRC_withTwoIntercoolingwithThreeRH.PC2.Q_dot;
                PC31 = cicloPCRC_withTwoIntercoolingwithThreeRH.COOLER.Q_dot;

                //PTC_SF_Calculation PTC = new PTC_SF_Calculation();
                //PTC.calledForSensingAnalysis = true;
                //PTC.comboBox1.Text = "Solar Salt";
                //PTC.comboBox2.Text = "NewMixture";
                //PTC.comboBox13.Text = this.comboBox2.Text;
                //PTC.comboBox14.Text = this.comboBox6.Text;
                ////PTC.textBox31.Text = this.textBox31.Text;
                ////PTC.textBox36.Text = this.textBox36.Text;

                //if (comboBox4.Text == "Parabolic")
                //{
                //    PTC.textBox7.Text = "0.141";
                //    PTC.textBox8.Text = "6.48e-9";
                //}

                //else if (comboBox4.Text == "Parabolic with cavity receiver (Norwich)")
                //{
                //    PTC.textBox7.Text = "0.3";
                //    PTC.textBox8.Text = "3.25e-9";
                //}

                //PTC.textBox1.Text = Convert.ToString(PHX_Q2);
                //PTC.textBox2.Text = Convert.ToString(massflow2);
                //PTC.textBox3.Text = Convert.ToString(temp25);
                //PTC.textBox6.Text = Convert.ToString(temp26);
                //PTC.textBox4.Text = Convert.ToString(pres25);
                //PTC.textBox5.Text = Convert.ToString(pres26);
                //PTC.textBox107.Text = Convert.ToString(10);
                //PTC.SF_PHX.PTC_Solar_Field_ciclo_RC_Design_withoutReHeating(this, 4, "Main_SF");
                //PTC.button1_Click(this, e);
                //PTC_Main_SF_Effective_Apperture_Area = PTC.ReflectorApertureAreaResult;
                //PTC_Main_SF_Pressure_drop = PTC.Total_Pressure_DropResult;

                //LF_SF_Calculation LF = new LF_SF_Calculation();
                //LF.calledForSensingAnalysis = true;
                //LF.comboBox1.Text = "Solar Salt";
                //LF.comboBox2.Text = "NewMixture";
                //LF.comboBox13.Text = this.comboBox2.Text;
                //LF.comboBox14.Text = this.comboBox6.Text;
                ////LF.textBox31.Text = this.textBox31.Text;
                ////LF.textBox36.Text = this.textBox36.Text;
                //LF.textBox1.Text = Convert.ToString(PHX_Q2);
                //LF.textBox2.Text = Convert.ToString(massflow2);
                //LF.textBox3.Text = Convert.ToString(temp25);
                //LF.textBox6.Text = Convert.ToString(temp26);
                //LF.textBox4.Text = Convert.ToString(pres25);
                //LF.textBox5.Text = Convert.ToString(pres26);
                //LF.SF_PHX.LF_Solar_Field_ciclo_RC_Design_withoutReHeating(this, 4, "Main_SF");
                //LF.textBox107.Text = Convert.ToString(10);
                //LF.button1_Click(this, e);
                //LF_Main_SF_Effective_Apperture_Area = LF.ReflectorApertureAreaResult;
                //LF_Main_SF_Pressure_drop = LF.Total_Pressure_DropResult;

                //if (comboBox4.Text == "Dual-Loop")
                //{
                //    //Main SF
                //    comboBox9.Enabled = true;
                //    comboBox11.Enabled = true;
                //    comboBox8.Enabled = true;
                //    comboBox10.Enabled = true;
                //    button17.Enabled = true;
                //    button18.Enabled = true;

                //    button4.Enabled = false;
                //}

                //else if ((comboBox4.Text == "Parabolic") || (comboBox4.Text == "Fresnel"))
                //{
                //    //Main SF
                //    comboBox9.Enabled = false;
                //    comboBox11.Enabled = false;
                //    comboBox8.Enabled = false;
                //    comboBox10.Enabled = false;
                //    button17.Enabled = false;
                //    button18.Enabled = false;

                //    button4.Enabled = true;
                //}

                button7.Enabled = true;
                button15.Enabled = true;
                button28.Enabled = true;
                button4.Enabled = true;
                button6.Enabled = true;
                button9.Enabled = true;
                button11.Enabled = true;
                button19.Enabled = true;
                button12.Enabled = true;
                button5.Enabled = true;
            }

            else
            {
                PHX1 = cicloPCRC_withTwoIntercoolingwithThreeRH.PHX.Q_dot;
                RHX1 = cicloPCRC_withTwoIntercoolingwithThreeRH.RHX1.Q_dot;
                RHX2 = cicloPCRC_withTwoIntercoolingwithThreeRH.RHX2.Q_dot;
                RHX3 = cicloPCRC_withTwoIntercoolingwithThreeRH.RHX3.Q_dot;

                LT_Q = cicloPCRC_withTwoIntercoolingwithThreeRH.LT.Q_dot;
                LT_mdotc = cicloPCRC_withTwoIntercoolingwithThreeRH.LT.m_dot_design[0];
                LT_mdoth = cicloPCRC_withTwoIntercoolingwithThreeRH.LT.m_dot_design[1];
                LT_Tcin = cicloPCRC_withTwoIntercoolingwithThreeRH.LT.T_c_in;
                LT_Thin = cicloPCRC_withTwoIntercoolingwithThreeRH.LT.T_h_in;
                LT_Pcin = cicloPCRC_withTwoIntercoolingwithThreeRH.LT.P_c_in;
                LT_Phin = cicloPCRC_withTwoIntercoolingwithThreeRH.LT.P_h_in;
                LT_Pcout = cicloPCRC_withTwoIntercoolingwithThreeRH.LT.P_c_out;
                LT_Phout = cicloPCRC_withTwoIntercoolingwithThreeRH.LT.P_h_out;
                LT_Effc = cicloPCRC_withTwoIntercoolingwithThreeRH.LT.eff;

                HT_Q = cicloPCRC_withTwoIntercoolingwithThreeRH.HT.Q_dot;
                HT_mdotc = cicloPCRC_withTwoIntercoolingwithThreeRH.HT.m_dot_design[0];
                HT_mdoth = cicloPCRC_withTwoIntercoolingwithThreeRH.HT.m_dot_design[1];
                HT_Tcin = cicloPCRC_withTwoIntercoolingwithThreeRH.HT.T_c_in;
                HT_Thin = cicloPCRC_withTwoIntercoolingwithThreeRH.HT.T_h_in;
                HT_Pcin = cicloPCRC_withTwoIntercoolingwithThreeRH.HT.P_c_in;
                HT_Phin = cicloPCRC_withTwoIntercoolingwithThreeRH.HT.P_h_in;
                HT_Pcout = cicloPCRC_withTwoIntercoolingwithThreeRH.HT.P_c_out;
                HT_Phout = cicloPCRC_withTwoIntercoolingwithThreeRH.HT.P_h_out;
                HT_Effc = cicloPCRC_withTwoIntercoolingwithThreeRH.HT.eff;

                PC11 = cicloPCRC_withTwoIntercoolingwithThreeRH.PC1.Q_dot;
                PC21 = cicloPCRC_withTwoIntercoolingwithThreeRH.PC2.Q_dot;
                PC31 = cicloPCRC_withTwoIntercoolingwithThreeRH.COOLER.Q_dot;
            }

            button7.Enabled = true;
            button15.Enabled = true;
            button28.Enabled = true;
            button4.Enabled = true;
            button6.Enabled = true;
            button9.Enabled = true;
            button11.Enabled = true;
            button19.Enabled = true;
            button12.Enabled = true;
            button5.Enabled = true;
            button30.Enabled = true;
            button33.Enabled = true;
        }

        //Set Critical conditions
        private void button25_Click(object sender, EventArgs e)
        {
            double option1 = 0.0;
            double option2 = 0.0;
            double option3 = 0.0;
            double option4 = 0.0;

            option1 = Convert.ToDouble(this.textBox33.Text);
            option2 = Convert.ToDouble(this.textBox34.Text);
            option3 = Convert.ToDouble(this.textBox68.Text);
            option4 = Convert.ToDouble(this.textBox69.Text);

            if ((option1 == 1) || (option2 == 1) || (option3 == 1) || (option4 == 1))
            {
                Refrigerant working_fluid = new Refrigerant(RefrigerantCategory.NewMixture,
                           this.comboBox2.Text + "=" + textBox33.Text + "," +
                           this.comboBox6.Text + "=" + textBox34.Text + "," +
                           this.comboBox12.Text + "=" + textBox68.Text + "," +
                           this.comboBox7.Text + "=" + textBox69.Text, ReferenceState.DEF);

                textBox32.Text = Convert.ToString(working_fluid.CriticalPressure);
                textBox31.Text = Convert.ToString(working_fluid.CriticalTemperature);
                textBox30.Text = Convert.ToString(working_fluid.CriticalDensity);

                textBox23.Text = Convert.ToString(working_fluid.CriticalPressure);
                textBox2.Text = Convert.ToString(working_fluid.CriticalTemperature);
                textBox22.Text = Convert.ToString(working_fluid.CriticalTemperature);
                textBox84.Text = Convert.ToString(working_fluid.CriticalTemperature);

                MixtureCriticalPressure = working_fluid.CriticalPressure;
                MixtureCriticalTemperature = working_fluid.CriticalTemperature;
            }

            else
            {
                Excel.Application xlApp;
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;

                xlApp = new Excel.Application();

                xlWorkBook = xlApp.Workbooks.Open("C:\\SCSP\\RefPropWindowsForms\\bin\\Debug\\REFPROP.xls");

                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(9);

                //Fluids selection
                xlWorkSheet.Cells[13, 6] = this.comboBox2.Text;
                xlWorkSheet.Cells[14, 6] = this.comboBox6.Text;
                xlWorkSheet.Cells[15, 6] = this.comboBox12.Text;
                xlWorkSheet.Cells[16, 6] = this.comboBox7.Text;

                // % Compositions
                xlWorkSheet.Cells[13, 7] = this.textBox33.Text;
                xlWorkSheet.Cells[14, 7] = this.textBox34.Text;
                xlWorkSheet.Cells[15, 7] = this.textBox68.Text;
                xlWorkSheet.Cells[16, 7] = this.textBox69.Text;

                //MessageBox.Show(xlWorkSheet.get_Range("D68", "D68").Value2.ToString());
                this.textBox23.Text = xlWorkSheet.get_Range("D69", "D69").Value2.ToString();
                this.textBox2.Text = xlWorkSheet.get_Range("D68", "D68").Value2.ToString();
                this.textBox22.Text = xlWorkSheet.get_Range("D68", "D68").Value2.ToString();
                this.textBox84.Text = xlWorkSheet.get_Range("D68", "D68").Value2.ToString();

                MixtureCriticalPressure = xlWorkSheet.get_Range("D69", "D69").Value;
                MixtureCriticalTemperature = xlWorkSheet.get_Range("D68", "D68").Value2;

                this.textBox32.Text = xlWorkSheet.get_Range("D69", "D69").Value2.ToString();
                this.textBox31.Text = xlWorkSheet.get_Range("D68", "D68").Value2.ToString();
                this.textBox30.Text = xlWorkSheet.get_Range("D70", "D70").Value2.ToString();

                //xlWorkBook.SaveAs("C:\\SCSP_Gitlab\\RefPropWindowsForms\\Copia de REFPROP.xlS", 
                //Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, 
                //Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, 
                //misValue);

                xlWorkBook.Close(false, misValue, misValue);

                xlApp.Quit();

                releaseObject(xlWorkSheet);
                releaseObject(xlWorkBook);
                releaseObject(xlApp);
            }
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

        //Optimization Analysis
        private void button36_Click(object sender, EventArgs e)
        {

        }
    }
}
