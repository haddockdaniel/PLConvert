// Decompiled with JetBrains decompiler
// Type: PLConvert.PLGenInfo
// Assembly: PLConvert, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DC1F0050-AC43-49A6-B4BD-95C619E8FF70
// Assembly location: C:\Users\haddocdx\Desktop\Conv DLLs\PLConvert.dll

using System;
using System.Collections.Generic;
using ConvHelper;

namespace PLConvert
{
  public class PLGenInfo : StaticData
  {
    private CPostItem m_StartUpDate;
    private CPostItem m_FirmName;
    private CPostItem m_GSTNumber;
    private CPostItem m_FirmAddress1;
    private CPostItem m_FirmAddress2;
    private CPostItem m_FirmCity;
    private CPostItem m_FirmState;
    private CPostItem m_FirmZip;
    private CPostItem m_FirmCountry;
    private CPostItem m_FirmPhone;
    private CPostItem m_FirmEmail;
    private CPostItem m_FirmWebAddress;
    private CPostItem m_FirmFax;
    private CPostItem m_FirmOtherID1;
    private CPostItem m_FirmOtherID2;
    private CPostItem m_SerialNo;
    private CPostItem m_Version;
    private CPostItem m_DataPath;
    private CPostItem m_Country;
    private CPostItem m_UseGL;
    private CPostItem m_IsCorp;
    private CPostItem m_AcctMethod;
    private CPostItem m_MaxLawyers;
    private CPostItem m_MainStatus;
    private CPostItem m_PSTFlagFees;
    private CPostItem m_PSTFlagDisb;
    private CPostItem m_PSTRateFees;
    private CPostItem m_PSTRateDisb;
    private CPostItem m_PSTOnBillsAfter;
    private CPostItem m_ExcludeWIPB4;
    private CPostItem m_PostITC;
    private CPostItem m_UsingGST;
    private CPostItem m_GSTRateFees;
    private CPostItem m_GSTRateDisb;
    private CPostItem m_GSTSalesTaxRate;
    private CPostItem m_GSTSideBySidePST;
    private CPostItem m_GSTType;
    private CPostItem m_DefaultDept;
    private CPostItem m_AutoTrackTimeReduc;
    private CPostItem m_IsHideCalendar;
    private CPostItem m_IsHidePhoneCalls;
    private CPostItem m_FloatTrustAcctID;
    private CPostItem m_FloatTrustMtrID;
    private CPostItem m_FloatTrustLwrID;
    private CPostItem m_FloatTrustMinBal;
    private CPostItem m_FloatTrustClientThreshold;
    private CPostItem m_FloatTrustClientLimit;
    private CPostItem m_UseResidentWithholdingTax;
    private CPostItem m_ResidentWithholdByFirm;
    private CPostItem m_CombinedTrust;
    private CPostItem m_DefCommissionPct;
    private CPostItem m_DefCommExplCodeID;
    private CPostItem m_DefCommExpl;
    private CPostItem m_WithholdTaxPct;
    private CPostItem m_WithholdTaxMtrID;
    private CPostItem m_ShowGSTonTrust;

    public PLGenInfo.AccMethod AcctMethod
    {
      get
      {
        return (PLGenInfo.AccMethod) this.m_AcctMethod.nValue;
      }
      set
      {
        this.m_AcctMethod.SetValue((int) value);
      }
    }

    public bool AutoTrackTimeReduc
    {
      get
      {
        return this.m_AutoTrackTimeReduc.bValue;
      }
      set
      {
        this.m_AutoTrackTimeReduc.SetValue(value);
      }
    }

    public bool CombinedTrust
    {
      get
      {
        return this.m_CombinedTrust.bValue;
      }
      set
      {
        this.m_CombinedTrust.SetValue(value);
      }
    }

    public char Country
    {
      get
      {
        return this.m_Country.sValue[0];
      }
      set
      {
        this.m_Country.SetValue(new string(value, 1));
      }
    }

    public string DataPath
    {
      get
      {
        return this.m_DataPath.sValue;
      }
      set
      {
        this.m_DataPath.SetValue(value);
      }
    }

    public int DefaultDept
    {
      get
      {
        return this.m_DefaultDept.nValue;
      }
      set
      {
        this.m_DefaultDept.SetValue(value);
      }
    }

    public char DefCommExpl
    {
      get
      {
        return this.m_DefCommExpl.sValue[0];
      }
      set
      {
        this.m_DefCommExpl.SetValue(new string(value, 1));
      }
    }

    public int DefCommExplCodeID
    {
      get
      {
        return this.m_DefCommExplCodeID.nValue;
      }
      set
      {
        this.m_DefCommExplCodeID.SetValue(value);
      }
    }

    public double DefCommissionPct
    {
      get
      {
        return this.m_DefCommissionPct.dValue;
      }
      set
      {
        this.m_DefCommissionPct.SetValue(value);
      }
    }

    public PLDate ExcludeWIPB4
    {
      get
      {
        return (PLDate) this.m_ExcludeWIPB4.nValue;
      }
      set
      {
        this.m_ExcludeWIPB4.SetValue(Convert.ToInt32(value.ToString()));
      }
    }

    public string FirmAddress1
    {
      get
      {
        return this.m_FirmAddress1.sValue;
      }
      set
      {
        this.m_FirmAddress1.SetValue(value);
      }
    }

    public string FirmAddress2
    {
      get
      {
        return this.m_FirmAddress2.sValue;
      }
      set
      {
        this.m_FirmAddress2.SetValue(value);
      }
    }

    public string FirmCity
    {
      get
      {
        return this.m_FirmCity.sValue;
      }
      set
      {
        this.m_FirmCity.SetValue(value);
      }
    }

    public string FirmCountry
    {
      get
      {
        return this.m_FirmCountry.sValue;
      }
      set
      {
        this.m_FirmCountry.SetValue(value);
      }
    }

    public string FirmEmail
    {
      get
      {
        return this.m_FirmEmail.sValue;
      }
      set
      {
        this.m_FirmEmail.SetValue(value);
      }
    }

    public string FirmFax
    {
      get
      {
        return this.m_FirmFax.sValue;
      }
      set
      {
        this.m_FirmFax.SetValue(value);
      }
    }

    public bool FirmIsCorp
    {
      get
      {
        return this.m_IsCorp.bValue;
      }
      set
      {
        this.m_IsCorp.SetValue(value);
      }
    }

    public string FirmName
    {
      get
      {
        return this.m_FirmName.sValue;
      }
      set
      {
        this.m_FirmName.SetValue(value);
      }
    }

    public string FirmOtherID1
    {
      get
      {
        return this.m_FirmOtherID1.sValue;
      }
      set
      {
        this.m_FirmOtherID1.SetValue(value);
      }
    }

    public string FirmOtherID2
    {
      get
      {
        return this.m_FirmOtherID2.sValue;
      }
      set
      {
        this.m_FirmOtherID2.SetValue(value);
      }
    }

    public string FirmPhone
    {
      get
      {
        return this.m_FirmPhone.sValue;
      }
      set
      {
        this.m_FirmPhone.SetValue(value);
      }
    }

    public string FirmState
    {
      get
      {
        return this.m_FirmState.sValue;
      }
      set
      {
        this.m_FirmState.SetValue(value);
      }
    }

    public string FirmWebAddress
    {
      get
      {
        return this.m_FirmWebAddress.sValue;
      }
      set
      {
        this.m_FirmWebAddress.SetValue(value);
      }
    }

    public string FirmZip
    {
      get
      {
        return this.m_FirmZip.sValue;
      }
      set
      {
        this.m_FirmZip.SetValue(value);
      }
    }

    public int FloatTrustAcctID
    {
      get
      {
        return this.m_FloatTrustAcctID.nValue;
      }
      set
      {
        this.m_FloatTrustAcctID.SetValue(value);
      }
    }

    public double FloatTrustClientLimit
    {
      get
      {
        return this.m_FloatTrustClientLimit.dValue;
      }
      set
      {
        this.m_FloatTrustClientLimit.SetValue(value);
      }
    }

    public double FloatTrustClientThreshold
    {
      get
      {
        return this.m_FloatTrustClientThreshold.dValue;
      }
      set
      {
        this.m_FloatTrustClientThreshold.SetValue(value);
      }
    }

    public int FloatTrustLwrID
    {
      get
      {
        return this.m_FloatTrustLwrID.nValue;
      }
      set
      {
        this.m_FloatTrustLwrID.SetValue(value);
      }
    }

    public double FloatTrustMinBal
    {
      get
      {
        return this.m_FloatTrustMinBal.dValue;
      }
      set
      {
        this.m_FloatTrustMinBal.SetValue(value);
      }
    }

    public int FloatTrustMtrID
    {
      get
      {
        return this.m_FloatTrustMtrID.nValue;
      }
      set
      {
        this.m_FloatTrustMtrID.SetValue(value);
      }
    }

    public string GSTNumber
    {
      get
      {
        return this.m_GSTNumber.sValue;
      }
      set
      {
        this.m_GSTNumber.SetValue(value);
      }
    }

    public double GSTRateDisb
    {
      get
      {
        return this.m_GSTRateDisb.dValue;
      }
      set
      {
        this.m_GSTRateDisb.SetValue(value);
      }
    }

    public double GSTRateFees
    {
      get
      {
        return this.m_GSTRateFees.dValue;
      }
      set
      {
        this.m_GSTRateFees.SetValue(value);
      }
    }

    public double GSTSalesTaxRate
    {
      get
      {
        return this.m_GSTSalesTaxRate.dValue;
      }
      set
      {
        this.m_GSTSalesTaxRate.SetValue(value);
      }
    }

    public bool GSTSideBySidePST
    {
      get
      {
        return this.m_GSTSideBySidePST.nValue != 0;
      }
      set
      {
        this.m_GSTSideBySidePST.SetValue(value ? 1 : 0);
      }
    }

    public bool IsHideCalendar
    {
      get
      {
        return this.m_IsHideCalendar.bValue;
      }
      set
      {
        this.m_IsHideCalendar.SetValue(value);
      }
    }

    public bool IsHidePhoneCalls
    {
      get
      {
        return this.m_IsHidePhoneCalls.bValue;
      }
      set
      {
        this.m_IsHidePhoneCalls.SetValue(value);
      }
    }

    public PLGenInfo.eMainStatus MainStatus
    {
      get
      {
        return (PLGenInfo.eMainStatus) this.m_MainStatus.nValue;
      }
      set
      {
        this.m_MainStatus.SetValue((int) value);
      }
    }

    public int MaxLawyers
    {
      get
      {
        return this.m_MaxLawyers.nValue;
      }
    }

    public bool NewMattersTaxable
    {
      get
      {
        return this.m_GSTType.nValue != 0;
      }
      set
      {
        this.m_GSTType.SetValue(value ? 1 : 0);
      }
    }

    public bool PostITC
    {
      get
      {
        return this.m_PostITC.nValue != 0;
      }
      set
      {
        this.m_PostITC.SetValue(value ? 1 : 0);
      }
    }

    public bool PSTFlagDisb
    {
      get
      {
        return this.m_PSTFlagDisb.nValue != 0;
      }
      set
      {
        this.m_PSTFlagDisb.SetValue(value ? 1 : 0);
      }
    }

    public bool PSTFlagFees
    {
      get
      {
        return this.m_PSTFlagFees.nValue != 0;
      }
      set
      {
        this.m_PSTFlagFees.SetValue(value ? 1 : 0);
      }
    }

    public PLDate PSTOnBillsAfter
    {
      get
      {
        return (PLDate) this.m_PSTOnBillsAfter.nValue;
      }
      set
      {
        this.m_PSTOnBillsAfter.SetValue(Convert.ToInt32(value.ToString()));
      }
    }

    public double PSTRateDisb
    {
      get
      {
        return this.m_PSTRateDisb.dValue;
      }
      set
      {
        this.m_PSTRateDisb.SetValue(value);
      }
    }

    public double PSTRateFees
    {
      get
      {
        return this.m_PSTRateFees.dValue;
      }
      set
      {
        this.m_PSTRateFees.SetValue(value);
      }
    }

    public bool ResidentWithholdByFirm
    {
      get
      {
        return this.m_ResidentWithholdByFirm.bValue;
      }
      set
      {
        this.m_ResidentWithholdByFirm.SetValue(value);
      }
    }

    public string SerialNo
    {
      get
      {
        return this.m_SerialNo.sValue;
      }
      set
      {
        this.m_SerialNo.SetValue(value);
      }
    }

    public bool ShowGSTonTrust
    {
      get
      {
        return this.m_ShowGSTonTrust.bValue;
      }
      set
      {
        this.m_ShowGSTonTrust.SetValue(value);
      }
    }

    public PLDate StartUpDate
    {
      get
      {
        return (PLDate) this.m_StartUpDate.nValue;
      }
      set
      {
        this.m_StartUpDate.SetValue(Convert.ToInt32(value.ToString()));
      }
    }

    public int StartUpDateInt
    {
      get
      {
        return this.m_StartUpDate.nValue;
      }
    }

    public bool UseGL
    {
      get
      {
        return this.m_UseGL.bValue;
      }
      set
      {
        this.m_UseGL.SetValue(value);
      }
    }

    public bool UseResidentWithholdingTax
    {
      get
      {
        return this.m_UseResidentWithholdingTax.bValue;
      }
      set
      {
        this.m_UseResidentWithholdingTax.SetValue(value);
      }
    }

    public bool UsingGST
    {
      get
      {
        return this.m_UsingGST.nValue != 0;
      }
      set
      {
        this.m_UsingGST.SetValue(value ? 1 : 0);
      }
    }

    public string Version
    {
      get
      {
        return this.m_Version.sValue;
      }
      set
      {
        this.m_Version.sValue = value;
        this.m_Version.m_bIsSet = true;
      }
    }

    public int WithholdTaxMtrID
    {
      get
      {
        return this.m_WithholdTaxMtrID.nValue;
      }
      set
      {
        this.m_WithholdTaxMtrID.SetValue(value);
      }
    }

    public double WithholdTaxPct
    {
      get
      {
        return this.m_WithholdTaxPct.dValue;
      }
      set
      {
        this.m_WithholdTaxPct.SetValue(value);
      }
    }

    public PLGenInfo()
    {
      this.Initialize();
    }

    public override void AddRecord()
    {
    }

    public override void GetExistingRecord()
    {
    }

    public string GetGenericValue(string sFieldName)
    {
      object obj = new object();
      base.GetLink().TableGET_RecordField_ValueString(this.m_hndExisting, sFieldName, "", ref obj);
      return obj.ToString();
    }

    public override void GetRecord()
    {
      foreach (CPostItem postItem in this.PostItems)
        postItem.GetField(this.m_hndGET);
      this.GetLink().TableGET_CloseHandle(this.m_hndGET);
      this.m_hndGET = 0U;
    }

    protected override void Initialize()
    {
      this.m_sTableName = "Geninfo";
      List<CPostItem> postItems1 = this.PostItems;
      CPostItem cpostItem1 = new CPostItem(CPostItem.DataType.LONG, "SystemStartUpDate");
      CPostItem cpostItem2 = cpostItem1;
      this.m_StartUpDate = cpostItem1;
      postItems1.Add(cpostItem2);
      List<CPostItem> postItems2 = this.PostItems;
      CPostItem cpostItem3 = new CPostItem(CPostItem.DataType.STRING, "FirmName");
      CPostItem cpostItem4 = cpostItem3;
      this.m_FirmName = cpostItem3;
      postItems2.Add(cpostItem4);
      List<CPostItem> postItems3 = this.PostItems;
      CPostItem cpostItem5 = new CPostItem(CPostItem.DataType.STRING, "GSTNumber");
      CPostItem cpostItem6 = cpostItem5;
      this.m_GSTNumber = cpostItem5;
      postItems3.Add(cpostItem6);
      List<CPostItem> postItems4 = this.PostItems;
      CPostItem cpostItem7 = new CPostItem(CPostItem.DataType.STRING, "FirmAddress1");
      CPostItem cpostItem8 = cpostItem7;
      this.m_FirmAddress1 = cpostItem7;
      postItems4.Add(cpostItem8);
      List<CPostItem> postItems5 = this.PostItems;
      CPostItem cpostItem9 = new CPostItem(CPostItem.DataType.STRING, "FirmAddress2");
      CPostItem cpostItem10 = cpostItem9;
      this.m_FirmAddress2 = cpostItem9;
      postItems5.Add(cpostItem10);
      List<CPostItem> postItems6 = this.PostItems;
      CPostItem cpostItem11 = new CPostItem(CPostItem.DataType.STRING, "FirmCity");
      CPostItem cpostItem12 = cpostItem11;
      this.m_FirmCity = cpostItem11;
      postItems6.Add(cpostItem12);
      List<CPostItem> postItems7 = this.PostItems;
      CPostItem cpostItem13 = new CPostItem(CPostItem.DataType.STRING, "FirmState");
      CPostItem cpostItem14 = cpostItem13;
      this.m_FirmState = cpostItem13;
      postItems7.Add(cpostItem14);
      List<CPostItem> postItems8 = this.PostItems;
      CPostItem cpostItem15 = new CPostItem(CPostItem.DataType.STRING, "FirmZip");
      CPostItem cpostItem16 = cpostItem15;
      this.m_FirmZip = cpostItem15;
      postItems8.Add(cpostItem16);
      List<CPostItem> postItems9 = this.PostItems;
      CPostItem cpostItem17 = new CPostItem(CPostItem.DataType.STRING, "FirmCountry");
      CPostItem cpostItem18 = cpostItem17;
      this.m_FirmCountry = cpostItem17;
      postItems9.Add(cpostItem18);
      List<CPostItem> postItems10 = this.PostItems;
      CPostItem cpostItem19 = new CPostItem(CPostItem.DataType.STRING, "FirmPhone");
      CPostItem cpostItem20 = cpostItem19;
      this.m_FirmPhone = cpostItem19;
      postItems10.Add(cpostItem20);
      List<CPostItem> postItems11 = this.PostItems;
      CPostItem cpostItem21 = new CPostItem(CPostItem.DataType.STRING, "FirmEmail");
      CPostItem cpostItem22 = cpostItem21;
      this.m_FirmEmail = cpostItem21;
      postItems11.Add(cpostItem22);
      List<CPostItem> postItems12 = this.PostItems;
      CPostItem cpostItem23 = new CPostItem(CPostItem.DataType.STRING, "FirmWebAddress");
      CPostItem cpostItem24 = cpostItem23;
      this.m_FirmWebAddress = cpostItem23;
      postItems12.Add(cpostItem24);
      List<CPostItem> postItems13 = this.PostItems;
      CPostItem cpostItem25 = new CPostItem(CPostItem.DataType.STRING, "FirmFax");
      CPostItem cpostItem26 = cpostItem25;
      this.m_FirmFax = cpostItem25;
      postItems13.Add(cpostItem26);
      List<CPostItem> postItems14 = this.PostItems;
      CPostItem cpostItem27 = new CPostItem(CPostItem.DataType.STRING, "OtherFirmID1");
      CPostItem cpostItem28 = cpostItem27;
      this.m_FirmOtherID1 = cpostItem27;
      postItems14.Add(cpostItem28);
      List<CPostItem> postItems15 = this.PostItems;
      CPostItem cpostItem29 = new CPostItem(CPostItem.DataType.STRING, "OtherFirmID2");
      CPostItem cpostItem30 = cpostItem29;
      this.m_FirmOtherID2 = cpostItem29;
      postItems15.Add(cpostItem30);
      List<CPostItem> postItems16 = this.PostItems;
      CPostItem cpostItem31 = new CPostItem(CPostItem.DataType.STRING, "Serial");
      CPostItem cpostItem32 = cpostItem31;
      this.m_SerialNo = cpostItem31;
      postItems16.Add(cpostItem32);
      List<CPostItem> postItems17 = this.PostItems;
      CPostItem cpostItem33 = new CPostItem(CPostItem.DataType.STRING, "Version");
      CPostItem cpostItem34 = cpostItem33;
      this.m_Version = cpostItem33;
      postItems17.Add(cpostItem34);
      List<CPostItem> postItems18 = this.PostItems;
      CPostItem cpostItem35 = new CPostItem(CPostItem.DataType.STRING, "Data");
      CPostItem cpostItem36 = cpostItem35;
      this.m_DataPath = cpostItem35;
      postItems18.Add(cpostItem36);
      List<CPostItem> postItems19 = this.PostItems;
      CPostItem cpostItem37 = new CPostItem(CPostItem.DataType.STRING, "Country");
      CPostItem cpostItem38 = cpostItem37;
      this.m_Country = cpostItem37;
      postItems19.Add(cpostItem38);
      List<CPostItem> postItems20 = this.PostItems;
      CPostItem cpostItem39 = new CPostItem(CPostItem.DataType.BOOL, "UseGLAccounting");
      CPostItem cpostItem40 = cpostItem39;
      this.m_UseGL = cpostItem39;
      postItems20.Add(cpostItem40);
      List<CPostItem> postItems21 = this.PostItems;
      CPostItem cpostItem41 = new CPostItem(CPostItem.DataType.BOOL, "IsCorporation");
      CPostItem cpostItem42 = cpostItem41;
      this.m_IsCorp = cpostItem41;
      postItems21.Add(cpostItem42);
      List<CPostItem> postItems22 = this.PostItems;
      CPostItem cpostItem43 = new CPostItem(CPostItem.DataType.LONG, "AccountingMethod");
      CPostItem cpostItem44 = cpostItem43;
      this.m_AcctMethod = cpostItem43;
      postItems22.Add(cpostItem44);
      List<CPostItem> postItems23 = this.PostItems;
      CPostItem cpostItem45 = new CPostItem(CPostItem.DataType.LONG, "MaxLawyers");
      CPostItem cpostItem46 = cpostItem45;
      this.m_MaxLawyers = cpostItem45;
      postItems23.Add(cpostItem46);
      List<CPostItem> postItems24 = this.PostItems;
      CPostItem cpostItem47 = new CPostItem(CPostItem.DataType.LONG, "MainStatus");
      CPostItem cpostItem48 = cpostItem47;
      this.m_MainStatus = cpostItem47;
      postItems24.Add(cpostItem48);
      List<CPostItem> postItems25 = this.PostItems;
      CPostItem cpostItem49 = new CPostItem(CPostItem.DataType.LONG, "PSTFlagFees");
      CPostItem cpostItem50 = cpostItem49;
      this.m_PSTFlagFees = cpostItem49;
      postItems25.Add(cpostItem50);
      List<CPostItem> postItems26 = this.PostItems;
      CPostItem cpostItem51 = new CPostItem(CPostItem.DataType.LONG, "PSTFlagDisb");
      CPostItem cpostItem52 = cpostItem51;
      this.m_PSTFlagDisb = cpostItem51;
      postItems26.Add(cpostItem52);
      List<CPostItem> postItems27 = this.PostItems;
      CPostItem cpostItem53 = new CPostItem(CPostItem.DataType.DOUBLE, "PSTRateFees");
      CPostItem cpostItem54 = cpostItem53;
      this.m_PSTRateFees = cpostItem53;
      postItems27.Add(cpostItem54);
      List<CPostItem> postItems28 = this.PostItems;
      CPostItem cpostItem55 = new CPostItem(CPostItem.DataType.DOUBLE, "PSTRateDisb");
      CPostItem cpostItem56 = cpostItem55;
      this.m_PSTRateDisb = cpostItem55;
      postItems28.Add(cpostItem56);
      List<CPostItem> postItems29 = this.PostItems;
      CPostItem cpostItem57 = new CPostItem(CPostItem.DataType.LONG, "PSTOnBillsAfter");
      CPostItem cpostItem58 = cpostItem57;
      this.m_PSTOnBillsAfter = cpostItem57;
      postItems29.Add(cpostItem58);
      List<CPostItem> postItems30 = this.PostItems;
      CPostItem cpostItem59 = new CPostItem(CPostItem.DataType.LONG, "ExcludeWIPB4");
      CPostItem cpostItem60 = cpostItem59;
      this.m_ExcludeWIPB4 = cpostItem59;
      postItems30.Add(cpostItem60);
      List<CPostItem> postItems31 = this.PostItems;
      CPostItem cpostItem61 = new CPostItem(CPostItem.DataType.LONG, "PostITC");
      CPostItem cpostItem62 = cpostItem61;
      this.m_PostITC = cpostItem61;
      postItems31.Add(cpostItem62);
      List<CPostItem> postItems32 = this.PostItems;
      CPostItem cpostItem63 = new CPostItem(CPostItem.DataType.LONG, "UsingGST");
      CPostItem cpostItem64 = cpostItem63;
      this.m_UsingGST = cpostItem63;
      postItems32.Add(cpostItem64);
      List<CPostItem> postItems33 = this.PostItems;
      CPostItem cpostItem65 = new CPostItem(CPostItem.DataType.DOUBLE, "GSTRateFees");
      CPostItem cpostItem66 = cpostItem65;
      this.m_GSTRateFees = cpostItem65;
      postItems33.Add(cpostItem66);
      List<CPostItem> postItems34 = this.PostItems;
      CPostItem cpostItem67 = new CPostItem(CPostItem.DataType.DOUBLE, "GSTRateDisb");
      CPostItem cpostItem68 = cpostItem67;
      this.m_GSTRateDisb = cpostItem67;
      postItems34.Add(cpostItem68);
      List<CPostItem> postItems35 = this.PostItems;
      CPostItem cpostItem69 = new CPostItem(CPostItem.DataType.DOUBLE, "GSTSalesTaxRate");
      CPostItem cpostItem70 = cpostItem69;
      this.m_GSTSalesTaxRate = cpostItem69;
      postItems35.Add(cpostItem70);
      List<CPostItem> postItems36 = this.PostItems;
      CPostItem cpostItem71 = new CPostItem(CPostItem.DataType.LONG, "GSTSideBySidePST");
      CPostItem cpostItem72 = cpostItem71;
      this.m_GSTSideBySidePST = cpostItem71;
      postItems36.Add(cpostItem72);
      List<CPostItem> postItems37 = this.PostItems;
      CPostItem cpostItem73 = new CPostItem(CPostItem.DataType.LONG, "GSTType");
      CPostItem cpostItem74 = cpostItem73;
      this.m_GSTType = cpostItem73;
      postItems37.Add(cpostItem74);
      List<CPostItem> postItems38 = this.PostItems;
      CPostItem cpostItem75 = new CPostItem(CPostItem.DataType.LONG, "DefaultDept");
      CPostItem cpostItem76 = cpostItem75;
      this.m_DefaultDept = cpostItem75;
      postItems38.Add(cpostItem76);
      List<CPostItem> postItems39 = this.PostItems;
      CPostItem cpostItem77 = new CPostItem(CPostItem.DataType.BOOL, "AutoTrackTimeReduc");
      CPostItem cpostItem78 = cpostItem77;
      this.m_AutoTrackTimeReduc = cpostItem77;
      postItems39.Add(cpostItem78);
      List<CPostItem> postItems40 = this.PostItems;
      CPostItem cpostItem79 = new CPostItem(CPostItem.DataType.BOOL, "IsHideCalendar");
      CPostItem cpostItem80 = cpostItem79;
      this.m_IsHideCalendar = cpostItem79;
      postItems40.Add(cpostItem80);
      List<CPostItem> postItems41 = this.PostItems;
      CPostItem cpostItem81 = new CPostItem(CPostItem.DataType.BOOL, "IsHidePhoneCalls");
      CPostItem cpostItem82 = cpostItem81;
      this.m_IsHidePhoneCalls = cpostItem81;
      postItems41.Add(cpostItem82);
      List<CPostItem> postItems42 = this.PostItems;
      CPostItem cpostItem83 = new CPostItem(CPostItem.DataType.LONG, "FloatTrustAcctID");
      CPostItem cpostItem84 = cpostItem83;
      this.m_FloatTrustAcctID = cpostItem83;
      postItems42.Add(cpostItem84);
      List<CPostItem> postItems43 = this.PostItems;
      CPostItem cpostItem85 = new CPostItem(CPostItem.DataType.LONG, "FloatTrustMtrID");
      CPostItem cpostItem86 = cpostItem85;
      this.m_FloatTrustMtrID = cpostItem85;
      postItems43.Add(cpostItem86);
      List<CPostItem> postItems44 = this.PostItems;
      CPostItem cpostItem87 = new CPostItem(CPostItem.DataType.LONG, "FloatTrustLwrID");
      CPostItem cpostItem88 = cpostItem87;
      this.m_FloatTrustLwrID = cpostItem87;
      postItems44.Add(cpostItem88);
      List<CPostItem> postItems45 = this.PostItems;
      CPostItem cpostItem89 = new CPostItem(CPostItem.DataType.DOUBLE, "FloatTrustMinBal");
      CPostItem cpostItem90 = cpostItem89;
      this.m_FloatTrustMinBal = cpostItem89;
      postItems45.Add(cpostItem90);
      List<CPostItem> postItems46 = this.PostItems;
      CPostItem cpostItem91 = new CPostItem(CPostItem.DataType.DOUBLE, "FloatTrustClientThreshold");
      CPostItem cpostItem92 = cpostItem91;
      this.m_FloatTrustClientThreshold = cpostItem91;
      postItems46.Add(cpostItem92);
      List<CPostItem> postItems47 = this.PostItems;
      CPostItem cpostItem93 = new CPostItem(CPostItem.DataType.DOUBLE, "FloatTrustClientLimit");
      CPostItem cpostItem94 = cpostItem93;
      this.m_FloatTrustClientLimit = cpostItem93;
      postItems47.Add(cpostItem94);
      List<CPostItem> postItems48 = this.PostItems;
      CPostItem cpostItem95 = new CPostItem(CPostItem.DataType.BOOL, "UseResidentWithholdingTax");
      CPostItem cpostItem96 = cpostItem95;
      this.m_UseResidentWithholdingTax = cpostItem95;
      postItems48.Add(cpostItem96);
      List<CPostItem> postItems49 = this.PostItems;
      CPostItem cpostItem97 = new CPostItem(CPostItem.DataType.BOOL, "ResidentWithholdByFirm");
      CPostItem cpostItem98 = cpostItem97;
      this.m_ResidentWithholdByFirm = cpostItem97;
      postItems49.Add(cpostItem98);
      List<CPostItem> postItems50 = this.PostItems;
      CPostItem cpostItem99 = new CPostItem(CPostItem.DataType.BOOL, "CombinedTrust");
      CPostItem cpostItem100 = cpostItem99;
      this.m_CombinedTrust = cpostItem99;
      postItems50.Add(cpostItem100);
      List<CPostItem> postItems51 = this.PostItems;
      CPostItem cpostItem101 = new CPostItem(CPostItem.DataType.DOUBLE, "DefCommissionPct");
      CPostItem cpostItem102 = cpostItem101;
      this.m_DefCommissionPct = cpostItem101;
      postItems51.Add(cpostItem102);
      List<CPostItem> postItems52 = this.PostItems;
      CPostItem cpostItem103 = new CPostItem(CPostItem.DataType.LONG, "DefCommExplCodeID");
      CPostItem cpostItem104 = cpostItem103;
      this.m_DefCommExplCodeID = cpostItem103;
      postItems52.Add(cpostItem104);
      List<CPostItem> postItems53 = this.PostItems;
      CPostItem cpostItem105 = new CPostItem(CPostItem.DataType.STRING, "DefCommExpl");
      CPostItem cpostItem106 = cpostItem105;
      this.m_DefCommExpl = cpostItem105;
      postItems53.Add(cpostItem106);
      List<CPostItem> postItems54 = this.PostItems;
      CPostItem cpostItem107 = new CPostItem(CPostItem.DataType.DOUBLE, "WithholdTaxPct");
      CPostItem cpostItem108 = cpostItem107;
      this.m_WithholdTaxPct = cpostItem107;
      postItems54.Add(cpostItem108);
      List<CPostItem> postItems55 = this.PostItems;
      CPostItem cpostItem109 = new CPostItem(CPostItem.DataType.LONG, "WithholdTaxMtrID");
      CPostItem cpostItem110 = cpostItem109;
      this.m_WithholdTaxMtrID = cpostItem109;
      postItems55.Add(cpostItem110);
      List<CPostItem> postItems56 = this.PostItems;
      CPostItem cpostItem111 = new CPostItem(CPostItem.DataType.BOOL, "ShowGSTonTrust");
      CPostItem cpostItem112 = cpostItem111;
      this.m_ShowGSTonTrust = cpostItem111;
      postItems56.Add(cpostItem112);
      if (this.GetNextRecord() != 0)
        throw new Exception("Unable to access PCLaw, either the correct password was not entered into the Link Login Screen, or PCLaw has not been run since the an update was installed.  Run PCLaw and try again.");
    }

    public override string MakeNN(bool bSetNickName)
    {
      throw new NotImplementedException();
    }

    public override void Send()
    {
    }

    public void Write()
    {
      object nProcessed = new object();
      object nExceptions = new object();
      if ((int) this.m_hndPOST == 0)
        this.m_hndPOST = this.GetLink().TablePOST_CreateHandle(this.m_sTableName, 0);
      foreach (CPostItem postItem in this.PostItems)
        postItem.AddField(this.m_hndPOST);
      base.GetLink().TablePOST_AddRecord(this.m_hndPOST);
      base.GetLink().TablePOST_Send(this.m_hndPOST, ref nProcessed, ref nExceptions);
      short int16_1 = Convert.ToInt16(nProcessed);
      short int16_2 = Convert.ToInt16(nExceptions);
      PLXMLData.m_lErrorCount += (long) int16_2;
      if (((int) int16_2 > 0 ? 1 : (this.m_lCounter != (int) int16_1 ? 1 : 0)) != 0)
        this.GetLink().TablePOST_DumpExceptionsToLinkLog(this.m_hndPOST);
      this.GetLink().TablePOST_Reset(this.m_hndPOST);
      this.GetLink().TablePOST_CloseHandle(this.m_hndPOST);
      this.m_hndPOST = 0U;
    }

    public enum AccMethod
    {
      NOT_SET,
      ACCRUAL,
      MOD_CASH,
      CASH,
    }

    public enum eMainStatus
    {
      IS_INSTALLED = 0,
      IS_TRIAL_OK = 1,
      IS_TRIAL_OVERDUE = 2,
      IS_ILLEGAL = 100,
    }
  }
}
