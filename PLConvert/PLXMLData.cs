// Decompiled with JetBrains decompiler
// Type: PLConvert.PLXMLData
// Assembly: PLConvert, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DC1F0050-AC43-49A6-B4BD-95C619E8FF70
// Assembly location: C:\Users\haddocdx\Desktop\Conv DLLs\PLConvert.dll

using PLXMLLnkLib;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace PLConvert
{
  public abstract class PLXMLData
  {
    public static int m_nMaxCounter = 100;
    protected static long m_lErrorCount = 0;
    protected CPostItem m_Status;
    protected CPostItem m_ID;
    protected string sIDLinkName;
    protected CPostItem m_ExternalID_1;
    protected CPostItem m_ExternalID_2;
    protected CPostItem m_QuickBooksID;
    protected CPostItem m_TransactionNewID;
    protected CPostItem m_TransactionChgID;
    protected bool m_bPostQuickBooksIDOnly;
    protected uint m_hndGET;
    protected uint m_hndExisting;
    public long m_lSendErrorCount;
    public int m_lCounter;
    protected string m_sTableName;
    protected uint m_hndPOST;
    protected List<CPostItem> PostItems;

    public string ExternalID_1
    {
      get
      {
        return this.m_ExternalID_1.sValue;
      }
      set
      {
        this.m_ExternalID_1.SetValue(value);
      }
    }

    public string ExternalID_2
    {
      get
      {
        return this.m_ExternalID_2.sValue;
      }
      set
      {
        this.m_ExternalID_2.SetValue(value);
      }
    }

    public int ID
    {
      get
      {
        return this.m_ID.nValue;
      }
      set
      {
        this.m_ID.SetValue(value);
      }
    }

    public string ID_LinkName
    {
      get
      {
        return this.sIDLinkName;
      }
    }

    public bool PostQuickBooksIDOnly
    {
      get
      {
        return this.m_bPostQuickBooksIDOnly;
      }
      set
      {
        this.m_bPostQuickBooksIDOnly = value;
      }
    }

    public string QuickBooksID
    {
      get
      {
        return this.m_QuickBooksID.sValue;
      }
      set
      {
        this.m_QuickBooksID.SetValue(value);
      }
    }

    public PLXMLData.eSTATUS Status
    {
      get
      {
        return (PLXMLData.eSTATUS) this.m_Status.nValue;
      }
      set
      {
        this.m_Status.SetValue((int) value);
      }
    }

    public int TransactionChgID
    {
      get
      {
        return this.m_TransactionChgID.nValue;
      }
      set
      {
        this.m_TransactionChgID.SetValue(value);
      }
    }

    public int TransactionNewID
    {
      get
      {
        return this.m_TransactionNewID.nValue;
      }
      set
      {
        this.m_TransactionNewID.SetValue(value);
      }
    }

    public PLXMLData()
    {
      this.m_hndPOST = 0U;
      this.m_hndGET = 0U;
      this.m_hndExisting = 0U;
      this.m_lSendErrorCount = 0L;
      this.m_bPostQuickBooksIDOnly = false;
      this.PostItems = new List<CPostItem>();
    }

    public int Add_TableGet_Directive(string sDirective, string sText)
    {
      if ((int) this.m_hndGET == 0)
        this.m_hndGET = this.GetLink().TableGET_CreateHandle(this.m_sTableName, 0, 0, 0U);
      return this.GetLink().TableGET_AddDirective(this.m_hndGET, sDirective, sText);
    }

    public int Add_TablePost_Directive(string sDirective, string sText)
    {
      if ((int) this.m_hndPOST == 0)
        this.m_hndPOST = this.GetLink().TablePOST_CreateHandle(this.m_sTableName, 0);
      return this.GetLink().TablePOST_AddDirective(this.m_hndPOST, sDirective, sText);
    }

    public int AddFilter(string sFieldName, PLXMLData.eFilterCompare eFltrCompare, string sCompareValue, int nExactMatch)
    {
      if ((int) this.m_hndGET == 0)
        this.m_hndGET = this.GetLink().TableGET_CreateHandle(this.m_sTableName, 0, 0, 0U);
      string szCompareType = string.Empty;
      switch (eFltrCompare)
      {
        case PLXMLData.eFilterCompare.EQ:
          szCompareType = "EQ";
          break;
        case PLXMLData.eFilterCompare.NE:
          szCompareType = "NE";
          break;
        case PLXMLData.eFilterCompare.GT:
          szCompareType = "GT";
          break;
        case PLXMLData.eFilterCompare.GTE:
          szCompareType = "GTE";
          break;
        case PLXMLData.eFilterCompare.LT:
          szCompareType = "LT";
          break;
        case PLXMLData.eFilterCompare.LTE:
          szCompareType = "LTE";
          break;
        case PLXMLData.eFilterCompare.OREQ:
          szCompareType = "OREQ";
          break;
        case PLXMLData.eFilterCompare.ORNE:
          szCompareType = "ORNE";
          break;
        case PLXMLData.eFilterCompare.ORGT:
          szCompareType = "ORGT";
          break;
        case PLXMLData.eFilterCompare.ORGTE:
          szCompareType = "ORGTE";
          break;
        case PLXMLData.eFilterCompare.ORLT:
          szCompareType = "ORLT";
          break;
        case PLXMLData.eFilterCompare.ORLTE:
          szCompareType = "ORLTE";
          break;
      }
      return this.GetLink().TableGET_AddFilter(this.m_hndGET, sFieldName, szCompareType, sCompareValue, nExactMatch);
    }

    public virtual void AddRecord()
    {
      if ((int) this.m_hndPOST == 0)
        this.m_hndPOST = this.GetLink().TablePOST_CreateHandle(this.m_sTableName, 0);
      if ((this.PostItems == null ? 0 : ((int) this.m_hndPOST != 0 ? 1 : 0)) == 0)
        return;
      foreach (CPostItem postItem in this.PostItems)
        postItem.AddField(this.m_hndPOST);
      if (this.m_ExternalID_1 != null)
        this.m_ExternalID_1.AddField(this.m_hndPOST);
      if (this.m_ExternalID_2 != null)
        this.m_ExternalID_2.AddField(this.m_hndPOST);
    }

    public int AddSort(string sFieldName, int nAscending)
    {
      if ((int) this.m_hndGET == 0)
        this.m_hndGET = this.GetLink().TableGET_CreateHandle(this.m_sTableName, 0, 0, 0U);
      return this.GetLink().TableGET_AddSort(this.m_hndGET, sFieldName, nAscending);
    }

    public virtual void Clear()
    {
      if (this.PostItems == null)
        return;
      foreach (CPostItem postItem in this.PostItems)
        postItem.Clear();
      if (this.m_ExternalID_1 != null)
        this.m_ExternalID_1.Clear();
      if (this.m_ExternalID_2 != null)
        this.m_ExternalID_2.Clear();
    }

    ~PLXMLData()
    {
    }

    protected virtual bool GetAllowEntOnClosedMtr()
    {
      return false;
    }

    public static long GetErrorCount()
    {
      return PLXMLData.m_lErrorCount;
    }

    public virtual void GetExistingRecord()
    {
      this.Clear();
      if (this.PostItems == null)
        return;
      foreach (CPostItem postItem in this.PostItems)
        postItem.GetField(this.m_hndExisting);
    }

    public uint GetHighestTransactionID()
    {
      if ((int) this.m_hndGET != 0)
        this.GetLink().TableGET_Reset(this.m_hndGET);
      this.m_hndGET = this.GetLink().TableGET_CreateHandle(this.m_sTableName, 0, 0, 0U);
      uint num = 0;
      if ((int) this.m_hndGET != 0)
      {
        this.Add_TableGet_Directive("AddData", "0");
        this.Add_TableGet_Directive("gethighesttran", "1");
        num = this.GetLink().TableGET_GetHighestTran(this.m_hndGET);
      }
      return num;
    }

    protected PCLawATLClass GetLink()
    {
      return PLLink.GetLink();
    }

    public int GetNextRecord()
    {
      if ((int) this.m_hndGET == 0)
        this.m_hndGET = this.GetLink().TableGET_CreateHandle(this.m_sTableName, 0, 0, 0U);
      int num;
      if (this.GetLink().TableGET_GetNextRecord(this.m_hndGET) != 0)
      {
        this.GetLink().TableGET_CloseHandle(this.m_hndGET);
        this.m_hndGET = 0U;
        num = 1;
      }
      else
      {
        this.GetRecord();
        num = 0;
      }
      return num;
    }

    public virtual void GetRecord()
    {
      this.Clear();
      if ((int) this.m_hndGET == 0)
        this.m_hndGET = this.GetLink().TableGET_CreateHandle(this.m_sTableName, 0, 0, 0U);
      if (this.PostItems == null)
        return;
      foreach (CPostItem postItem in this.PostItems)
        postItem.GetField(this.m_hndGET);
    }

    public long GetSendErrorCount()
    {
      return this.m_lSendErrorCount;
    }

    protected abstract void Initialize();

    public void ReadExisting(uint nID)
    {
      if ((int) this.m_hndPOST == 0)
        this.m_hndPOST = this.GetLink().TablePOST_CreateHandle(this.m_sTableName, 0);
      this.m_hndExisting = this.GetLink().TablePOST_ReadExisting(this.m_hndPOST, nID);
      this.GetExistingRecord();
    }

    public void ResetGETHandle()
    {
      this.GetLink().TableGET_Reset(this.m_hndGET);
    }

    public void ResetPOSTHandle()
    {
      this.GetLink().TablePOST_Reset(this.m_hndPOST);
      this.GetLink().TablePOST_AddDirective(this.m_hndPOST, "allowentonclosedmtr", this.GetAllowEntOnClosedMtr() ? "1" : "0");
    }

    public int ResetQuickBooksIDsInPCLaw(uint nStartFromID)
    {
      return PLLink.GetLink().ResetQuickbooksID(this.m_sTableName, nStartFromID);
    }

    public abstract void Send();

    public virtual void SendLast()
    {
      if (this.m_lCounter > 0)
      {
        try
        {
          this.Send();
        }
        catch (Exception ex)
        {
          string str1 = ex.Data == null ? "" : ex.Data.ToString();
          string str2 = ex.HelpLink == null ? "" : ex.HelpLink.ToString();
          string str3 = ex.InnerException == null ? "" : ex.InnerException.ToString();
          string message = ex.Message;
          string str4 = ex.Source == null ? "" : ex.Source.ToString();
          string str5 = ex.StackTrace == null ? "" : ex.StackTrace.ToString();
          string str6 = ex.TargetSite == (MethodBase) null ? "" : ex.TargetSite.ToString();
          this.GetLink().TablePOST_Reset(this.m_hndPOST);
        }
      }
      else if ((int) this.m_hndPOST != 0)
        this.GetLink().TablePOST_Reset(this.m_hndPOST);
      if ((int) this.m_hndPOST == 0)
        return;
      this.GetLink().TablePOST_CloseHandle(this.m_hndPOST);
      this.m_hndPOST = 0U;
    }

    public override string ToString()
    {
      return this.m_sTableName;
    }

    public enum eFilterCompare : sbyte
    {
      NOTSET,
      EQ,
      NE,
      GT,
      GTE,
      LT,
      LTE,
      OREQ,
      ORNE,
      ORGT,
      ORGTE,
      ORLT,
      ORLTE,
    }

    public enum eSTATUS : byte
    {
      ACTIVE,
      ARCHIVED,
      DELETED,
    }
  }
}
