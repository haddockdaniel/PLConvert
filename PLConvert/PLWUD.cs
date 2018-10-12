// Decompiled with JetBrains decompiler
// Type: PLConvert.PLWUD
// Assembly: PLConvert, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DC1F0050-AC43-49A6-B4BD-95C619E8FF70
// Assembly location: C:\Users\haddocdx\Desktop\Conv DLLs\PLConvert.dll

using System;
using System.Collections.Generic;

namespace PLConvert
{
  public class PLWUD : TransactionData
  {
    private CPostItem m_MatterID;
    private CPostItem m_InvID;
    private CPostItem m_ExplCode;
    private CPostItem m_Explanation;
    private CPostItem m_TaskID;
    private CPostItem m_UserID;
    private CPostItem m_Date;
    private CPostItem m_EntryType;
    public PLWOAlloc Alloc;
    public List<PLWOAlloc> m_AllocArray;

    public int Date
    {
      get
      {
        return this.m_Date.nValue;
      }
      set
      {
        if ((value < 19820101 ? 1 : (value > 21991231 ? 1 : 0)) != 0)
          this.m_Date.SetValue(21991231);
        else
          this.m_Date.SetValue(value);
      }
    }

    public string Explanation
    {
      get
      {
        return this.m_Explanation.sValue;
      }
      set
      {
        this.m_Explanation.SetValue(value);
      }
    }

    public int ExplCodeID
    {
      get
      {
        return this.m_ExplCode.nValue;
      }
      set
      {
        this.m_ExplCode.SetValue(value);
      }
    }

    public string ExplCodeNN
    {
      get
      {
        return PLExpCode.GetNNFromID(this.m_ExplCode.nValue);
      }
      set
      {
        this.m_ExplCode.SetValue(PLExpCode.GetIDFromNN(value));
      }
    }

    public int InvID
    {
      get
      {
        return this.m_InvID.nValue;
      }
      set
      {
        this.m_InvID.SetValue(value);
      }
    }

    public int MatterID
    {
      get
      {
        return this.m_MatterID.nValue;
      }
      set
      {
        this.m_MatterID.SetValue(value);
      }
    }

    public string MatterNN
    {
      get
      {
        return PLMatter.GetNNFromID(this.m_MatterID.nValue);
      }
      set
      {
        this.m_MatterID.SetValue(PLMatter.GetIDFromNN(value));
      }
    }

    public int TaskID
    {
      get
      {
        return this.m_TaskID.nValue;
      }
      set
      {
        this.m_TaskID.SetValue(value);
      }
    }

    public string TaskNN
    {
      get
      {
        return PLTask.GetNNFromID(this.m_TaskID.nValue);
      }
      set
      {
        this.m_TaskID.SetValue(PLTask.GetIDFromNN(value));
      }
    }

    public int UserID
    {
      get
      {
        return this.m_UserID.nValue;
      }
      set
      {
        this.m_UserID.SetValue(value);
      }
    }

    public PLWUD()
    {
      this.Initialize();
    }

    public PLWUD.eWOAllocEntryType EntryType
    {
      get
      {
        return (PLWUD.eWOAllocEntryType) this.m_EntryType.nValue;
      }
      set
      {
        this.m_EntryType.nValue = (int) value;
        this.m_EntryType.m_bIsSet = true;
      }
    }

    public override void AddRecord()
    {
      if ((int) this.m_hndPOST == 0)
      {
        this.m_hndPOST = this.GetLink().TablePOST_CreateHandle(this.m_sTableName, 0);
        this.GetLink().TablePOST_AddDirective(this.m_hndPOST, "allowentonclosedmtr", PLBilling.m_bAllowEntOnClosedMtr ? "1" : "0");
      }
      if (this.TaskID == 0)
        this.TaskNN = "WD";
      base.AddRecord();
      this.m_EntryType.SetValue(5121);
      this.m_EntryType.AddField(this.m_hndPOST);
      for (int nRepeat = 1; nRepeat <= this.m_AllocArray.Count; ++nRepeat)
        this.m_AllocArray[nRepeat - 1].AddRepeatFields(this.m_hndPOST, nRepeat);
      this.m_AllocArray.Clear();
      this.GetLink().TablePOST_AddRecord(this.m_hndPOST);
      PLWUD plwud = this;
      plwud.m_lCounter = plwud.m_lCounter + 1;
      if (this.m_lCounter < PLXMLData.m_nMaxCounter)
        return;
      this.SendLast();
    }

    public void AddWOAllocation()
    {
      this.m_AllocArray.Add(new PLWOAlloc(this.Alloc.LawyerID, this.Alloc.GLID, this.Alloc.Amount, this.Alloc.EntryType));
      this.Alloc.Clear();
    }

    public override void Clear()
    {
      base.Clear();
      this.Alloc.Clear();
      this.m_AllocArray.Clear();
    }

    protected override bool GetAllowEntOnClosedMtr()
    {
      return PLBilling.m_bAllowEntOnClosedMtr;
    }

    public override void GetExistingRecord()
    {
      base.GetExistingRecord();
      this.m_AllocArray.Clear();
      int recurringFieldCount = this.GetLink().TableGET_RecordRecurringField_Count(this.m_hndExisting, "WOSplitGLID");
      for (int nRepeat = 1; nRepeat <= recurringFieldCount; ++nRepeat)
      {
        this.Alloc.GetRepeatFields(this.m_hndExisting, nRepeat);
        this.AddWOAllocation();
      }
    }

    public override void GetRecord()
    {
      base.GetRecord();
      this.m_AllocArray.Clear();
      int recurringFieldCount = this.GetLink().TableGET_RecordRecurringField_Count(this.m_hndGET, "WOSplitGLID");
      for (int nRepeat = 1; nRepeat <= recurringFieldCount; ++nRepeat)
      {
        this.Alloc.GetRepeatFields(this.m_hndGET, nRepeat);
        this.AddWOAllocation();
      }
    }

    protected override void Initialize()
    {
      this.m_sTableName = "WriteUpDown";
      List<CPostItem> postItems1 = this.PostItems;
      CPostItem cpostItem1 = new CPostItem(CPostItem.DataType.LONG, "WriteUpDownID");
      CPostItem cpostItem2 = cpostItem1;
      this.m_ID = cpostItem1;
      postItems1.Add(cpostItem2);
      List<CPostItem> postItems2 = this.PostItems;
      CPostItem cpostItem3 = new CPostItem(CPostItem.DataType.LONG, "InvoiceID");
      CPostItem cpostItem4 = cpostItem3;
      this.m_InvID = cpostItem3;
      postItems2.Add(cpostItem4);
      List<CPostItem> postItems3 = this.PostItems;
      CPostItem cpostItem5 = new CPostItem(CPostItem.DataType.LONG, "MatterID");
      CPostItem cpostItem6 = cpostItem5;
      this.m_MatterID = cpostItem5;
      postItems3.Add(cpostItem6);
      List<CPostItem> postItems4 = this.PostItems;
      CPostItem cpostItem7 = new CPostItem(CPostItem.DataType.LONG, "ExplCodeID");
      CPostItem cpostItem8 = cpostItem7;
      this.m_ExplCode = cpostItem7;
      postItems4.Add(cpostItem8);
      List<CPostItem> postItems5 = this.PostItems;
      CPostItem cpostItem9 = new CPostItem(CPostItem.DataType.STRING, "WriteUpDownExplanation");
      CPostItem cpostItem10 = cpostItem9;
      this.m_Explanation = cpostItem9;
      postItems5.Add(cpostItem10);
      List<CPostItem> postItems6 = this.PostItems;
      CPostItem cpostItem11 = new CPostItem(CPostItem.DataType.LONG, "TaskCodeID");
      CPostItem cpostItem12 = cpostItem11;
      this.m_TaskID = cpostItem11;
      postItems6.Add(cpostItem12);
      List<CPostItem> postItems7 = this.PostItems;
      CPostItem cpostItem13 = new CPostItem(CPostItem.DataType.LONG, "UserID");
      CPostItem cpostItem14 = cpostItem13;
      this.m_UserID = cpostItem13;
      postItems7.Add(cpostItem14);
      List<CPostItem> postItems8 = this.PostItems;
      CPostItem cpostItem15 = new CPostItem(CPostItem.DataType.LONG, "WriteUpDownStatus");
      CPostItem cpostItem16 = cpostItem15;
      this.m_Status = cpostItem15;
      postItems8.Add(cpostItem16);
      List<CPostItem> postItems9 = this.PostItems;
      CPostItem cpostItem17 = new CPostItem(CPostItem.DataType.LONG, "WriteUpDownDate");
      CPostItem cpostItem18 = cpostItem17;
      this.m_Date = cpostItem17;
      postItems9.Add(cpostItem18);
      List<CPostItem> postItems10 = this.PostItems;
      CPostItem cpostItem19 = new CPostItem(CPostItem.DataType.LONG, "WriteUpDownEntryType");
      CPostItem cpostItem20 = cpostItem19;
      this.m_EntryType = cpostItem19;
      postItems10.Add(cpostItem20);
      List<CPostItem> postItems11 = this.PostItems;
      CPostItem cpostItem21 = new CPostItem(CPostItem.DataType.STRING, "WriteUpDownQuickBooksID");
      CPostItem cpostItem22 = cpostItem21;
      this.m_QuickBooksID = cpostItem21;
      postItems11.Add(cpostItem22);
      this.Alloc = new PLWOAlloc();
      this.m_AllocArray = new List<PLWOAlloc>();
    }

    public bool Send(ref int nInvID, ref int nInvNum, ref int nInvDate)
    {
      object nProcessed = new object();
      object nExceptions = new object();
      object vunIDCreated = new object();
      object nExceptionError = new object();
      object szExceptionErrorMsg = new object();
      object szExceptionSentData = new object();
      object szValue = new object();
      short num = 0;
      string empty = string.Empty;
      this.m_lSendErrorCount = 0L;
      this.GetLink().TablePOST_Send(this.m_hndPOST, ref nProcessed, ref nExceptions);
      num = Convert.ToInt16(nProcessed);
      short int16 = Convert.ToInt16(nExceptions);
      PLXMLData.m_lErrorCount += (long) int16;
      bool flag;
      if ((int) int16 > 0)
      {
        this.GetLink().TablePOST_DumpExceptionsToLinkLog(this.m_hndPOST);
        PLWUD plwud = this;
        plwud.m_lSendErrorCount = plwud.m_lSendErrorCount + 1L;
        flag = false;
      }
      else if (this.GetLink().TablePOST_GetNextResult(this.m_hndPOST, ref vunIDCreated, ref nExceptionError, ref szExceptionErrorMsg, ref szExceptionSentData) == 0)
      {
        if ((!this.UseReverseEntryID ? 0 : (this.m_ReverseEntryID != null ? 1 : 0)) != 0)
        {
          this.GetLink().TablePOST_ResultDataField_String(this.m_hndPOST, this.m_ReverseEntryID.sLinkName, empty, ref szValue);
          this.ReverseEntryID = Convert.ToInt32(szValue);
        }
        flag = true;
      }
      else
        flag = false;
      return flag;
    }

    public override void SendLast()
    {
      int nInvID = 0;
      int nInvNum = 0;
      int nInvDate = 0;
      if (this.m_lCounter > 0)
      {
        this.Send(ref nInvID, ref nInvNum, ref nInvDate);
        this.m_lCounter = 0;
      }
      if ((int) this.m_hndPOST == 0)
        return;
      this.GetLink().TablePOST_CloseHandle(this.m_hndPOST);
      this.m_hndPOST = 0U;
    }

    public enum eWOAllocEntryType
    {
      FEE_WO_STAX_ADJ = 800,
      FEE_WO_STAX_BADDEBT = 801,
      FEE_WO_GST_ADJ = 802,
      FEE_WO_GST_BADDEBT = 803,
      FEE_WO_ADJ = 998,
      FEE_WO_BADDEBT = 999,
      DISB_WO_STAX_ADJ = 1800,
      DISB_WO_STAX_BADDEBT = 1801,
      DISB_WO_GST_ADJ = 1802,
      DISB_WO_GST_BADDEBT = 1803,
      DISB_WO_ADJ = 1898,
      DISB_WO_BADDEBT = 1899,
    }
  }
}
