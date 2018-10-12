// Decompiled with JetBrains decompiler
// Type: PLConvert.TransactionData
// Assembly: PLConvert, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DC1F0050-AC43-49A6-B4BD-95C619E8FF70
// Assembly location: C:\Users\haddocdx\Desktop\Conv DLLs\PLConvert.dll

using System;
using System.Reflection;

namespace PLConvert
{
  public abstract class TransactionData : PLXMLData
  {
    protected CPostItem m_ReverseEntryID;
    protected bool m_bUseReverseEntryID;

    public int ReverseEntryID
    {
      get
      {
        return this.m_ReverseEntryID.nValue;
      }
      set
      {
        this.m_ReverseEntryID.SetValue(value);
      }
    }

    public bool UseReverseEntryID
    {
      get
      {
        return this.m_bUseReverseEntryID;
      }
      set
      {
        this.m_bUseReverseEntryID = value;
      }
    }

    public TransactionData()
    {
      this.m_bUseReverseEntryID = false;
    }

    public override void Send()
    {
      object nProcessed = new object();
      object nExceptions = new object();
      this.m_lSendErrorCount = 0L;
      try
      {
        this.GetLink().TablePOST_Send(this.m_hndPOST, ref nProcessed, ref nExceptions);
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
        this.ResetPOSTHandle();
        this.m_lCounter = 0;
        return;
      }
      short int16_1 = Convert.ToInt16(nProcessed);
      short int16_2 = Convert.ToInt16(nExceptions);
      PLXMLData.m_lErrorCount += (long) int16_2;
      if (((int) int16_2 > 0 ? 1 : (this.m_lCounter != (int) int16_1 ? 1 : 0)) != 0)
      {
        this.GetLink().TablePOST_DumpExceptionsToLinkLog(this.m_hndPOST);
        TransactionData transactionData = this;
        transactionData.m_lSendErrorCount = transactionData.m_lSendErrorCount + 1L;
      }
      if ((!this.UseReverseEntryID ? 0 : (this.m_ReverseEntryID != null ? 1 : 0)) != 0)
      {
        object vunIDCreated = new object();
        object nExceptionError = new object();
        object szExceptionErrorMsg = new object();
        object szExceptionSentData = new object();
        object szValue = new object();
        string empty = string.Empty;
        if (this.GetLink().TablePOST_GetNextResult(this.m_hndPOST, ref vunIDCreated, ref nExceptionError, ref szExceptionErrorMsg, ref szExceptionSentData) == 0)
        {
          this.GetLink().TablePOST_ResultDataField_String(this.m_hndPOST, this.m_ReverseEntryID.sLinkName, empty, ref szValue);
          this.ReverseEntryID = Convert.ToInt32(szValue);
        }
        else
        {
          this.GetLink().TablePOST_DumpExceptionsToLinkLog(this.m_hndPOST);
          this.ResetPOSTHandle();
          TransactionData transactionData = this;
          transactionData.m_lSendErrorCount = transactionData.m_lSendErrorCount + 1L;
        }
      }
      this.ResetPOSTHandle();
      this.m_lCounter = 0;
    }

    public override void SendLast()
    {
      if (this.m_lCounter > 0)
        this.Send();
      if ((int) this.m_hndPOST == 0)
        return;
      this.GetLink().TablePOST_CloseHandle(this.m_hndPOST);
      this.m_hndPOST = 0U;
    }

    public enum eGST_CAT
    {
      NOT_SET = 0,
      BOTH = 98,
      EXEMPT = 101,
      NO = 110,
      PST = 112,
      YES = 121,
      ZERO = 122,
    }
  }
}
