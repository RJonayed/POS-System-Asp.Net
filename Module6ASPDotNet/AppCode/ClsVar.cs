using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Net;


    public class ClsVar
    {
//      ClsMain cm = new ClsMain();

        public static string gblPwdForShow = "Show";
        public static string gblAdminUID = "morshed";
    public static string  gblAdminPwd="";
        public static string gblToGetDateDDMMYYYY;
        public static string logRmk = "";
        public static string gblDtFormatForShow = "dd MMM yyyy";
        public static string gblFromDtStrDMY = "";
        public static string gblToDtStrDMY = "";
        public static string gblFromDtStrMDY = "";
        public static string gblToDtStrMDY = "";

        public static string gblyFrom = "";
        public static string gblmFrom = "";
        public static string gbldFrom = "";
        public static string gblyTo = "";
        public static string gblmTo = "";
        public static string gbldTo = "";
        public static string gblLockDate = "";

        public static string gblSecretCode;
        public static bool GblBarcode;
        public static string HostName;
    //public static string gblServerName = "27.147.182.114\\mssql2012";
    public static string gblServerName = ".\\mssql2012";
//public static string gblServerName = "119.18.146.140,49170\\mssql2012";
    //public static string gblServerName = ".\\mssql2012";
    public static string gblDataBaseName="PPT";
        public static string gblUserID="sa";
        public static string gblPassword ="power@2012";
        //public static string gblPassword = "Asdf@1234";
        public static string GblCnStr;
        public static string BackPicPath;
        public static string GblRptHead1;
        public static string GblRptHead2;
        public static double GblOpBalForLadger = 0;
        public static string GblSelFor;
        public static string GblRptName;
        public static string GblComName;
        public static string GblAddress;
        public static string GblPhone;
        public static string GblHeadName;
        public static string GblPcName;//=Dns.GetHostName();
        public static string GblUserCode="0";
        public static string GblUserName="" ;
        public static string GblComId;
        public static string GblSalaryStyle = "BGMEA";
        public static string GblDollarRate="0";
        public static double GblClosBalForLadger = 0; 

        public static string SqlPassword="";
        public static string ServerName;
        public static string DataBaseName;

        public static string FileName;
        public static string FilePath;
        public static string GblFrmBackColor;
        public static Int32 GblFormWidth;
        public static Int32 GblFormHeight;
        public static Int32 GblMonthNo;
        public static Int32 GblMonthDays;
        public static string GblFDate;
        public static string GblLDate;
        public static Int32 GblVarForTimer;

        //---------------------for security-------------
        public static string vwSalary;

        public static Boolean SaveEmployeeInfo;
        public static Boolean DelEmployeeInfo;
        public static Boolean VwEmployeeInfo;
        public static Boolean EdtEmployeeInfo;

        public static Boolean SaveEducationInfo;
        public static Boolean DelEducationInfo;
        public static Boolean VwEducationInfo;
        public static Boolean EdtEducationInfo;

        public static Boolean SaveEmpExpInfo;
        public static Boolean DelEmpExpInfo;
        public static Boolean VwEmpExpInfo;
        public static Boolean EdtEmpExpInfo;

        public static Boolean SaveSection;
        public static Boolean DelSection;
        public static Boolean VwSection;
        public static Boolean EdtSection;

        public static Boolean SaveDesignation;
        public static Boolean DelDesignation;
        public static Boolean VwDesignation;
        public static Boolean EdtDesignation;

        public static Boolean SaveLine;
        public static Boolean DelLine;
        public static Boolean VwLine;
        public static Boolean EdtLine;

        public static Boolean SaveBrance;
        public static Boolean DelBrance;
        public static Boolean VwBrance;
        public static Boolean EdtBrance;

        public static Boolean SaveMachineCreation;
        public static Boolean DelMachineCreation;
        public static Boolean VwMachineCreation;
        public static Boolean EdtMachineCreation;

        public static Boolean SaveMaterialType;
        public static Boolean DelMaterialType;
        public static Boolean VwMaterialType;
        public static Boolean EdtMaterialType;

        public static Boolean SaveUnitInfo;
        public static Boolean DelUnitInfo;
        public static Boolean VwUnitInfo;
        public static Boolean EdtUnitInfo;

        public static Boolean SaveMachineDetails;
        public static Boolean DelMachineDetails;
        public static Boolean VwMachineDetails;

        public static Boolean EdtMachinDetails;

        public static Boolean SaveNcrCreation;
        public static Boolean DelNcrCreation;
        public static Boolean VwNcrCreation;
        public static Boolean EdtNcrCreation;

        public static Boolean SaveSecurity;
        public static Boolean VwSecurity;
        public static Boolean EdtSecurity;

        public static Boolean SaveSiftingTime;
        public static Boolean DelSiftingTime;
        public static Boolean VwSiftingTime;
        public static Boolean EdtSiftingTime;

        public static Boolean SaveDatabaseBackup;
        public static Boolean VwDatabaseBackup;

        public static Boolean SaveUserCreation;
        public static Boolean EdtUserCreation;
        public static Boolean VwUserCreation;

        public static Boolean SaveGlobalSetup;
        public static Boolean VwGlobalSetup;

        public static Boolean SavePasswordChange;
        public static Boolean VwPasswordChange;

        public static Boolean SaveProductionInfo;
        public static Boolean DelProductionInfo;
        public static Boolean VwProductionInfo;
        public static Boolean EdtProductionInfo;

        public static Boolean SaveDelivaryInfo;
        public static Boolean DelDelivaryInfo;
        public static Boolean VwDelivaryInfo;
        public static Boolean EdtDelivaryInfo;

        public static Boolean SaveProductIn;
        public static Boolean DelProductIn;
        public static Boolean VwProductIn;
        public static Boolean EdtProductIn;

        public static Boolean SaveProductOut;
        public static Boolean DelProductOut;
        public static Boolean VwProductOut;
        public static Boolean EdtProductOut;

        public static Boolean SaveDailyAttn;
        public static Boolean DelDailyAttn;
        public static Boolean VwDailyAttn;
        public static Boolean EdtDailyAttn;

        public static Boolean SaveMonthlyAttn;
        public static Boolean DelMonthlyAttn;
        public static Boolean VwMonthlyAttn;
        public static Boolean EdtMontlyAttn;

        public static Boolean SaveHolidayAssign;
        public static Boolean DelHolidayAssign;
        public static Boolean VwHolidayAssign;
        public static Boolean EdtHolidayAssign;


        public static Boolean SaveLeaveTransaction;
        public static Boolean DelLeaveTransaction;
        public static Boolean VwLeaveTransaction;
        public static Boolean EdtLeaveTransaction;

        public static Boolean SaveAdvance;
        public static Boolean DelAdvance;
        public static Boolean VwAdvance;
        public static Boolean EdtAdvance;

        public static Boolean SaveAdvanceDetails;
        public static Boolean DelAdvanceDetails;
        public static Boolean VwAdvanceDetails;
        public static Boolean EdtAdvanceDetails;

        public static Boolean SaveSalaryIncrement;
        public static Boolean DelSalaryIncrement;
        public static Boolean VwSalaryIncrement;
        public static Boolean EdtSalaryIncrement;

        public static Boolean SaveMasterStock;
        public static Boolean DelMasterStock;
        public static Boolean VwMasterStock;
        public static Boolean EdtMasterStock;

        public static Boolean SaveOrderDetails;
        public static Boolean DelOrderDetails;
        public static Boolean VwOrderDetails;
        public static Boolean EdtOrderDetails;

        public static Boolean SaveEvaluation;
        public static Boolean DelEvaluation;
        public static Boolean VwEvaluation;
        public static Boolean EdtEvaluation;

        public static Boolean SaveConsumption;
        public static Boolean DelConsumption;
        public static Boolean VwConsumption;
        public static Boolean EdtConsumption;

        public static Boolean VwEarnLeave;
        public static Boolean SaveEarnLeave;

        public static Boolean VwSalaryReport;
        public static Boolean SaveSalaryReport;

        public static Boolean VwOrderDetailsInfo;

        public static Boolean SavePullData;














    }




