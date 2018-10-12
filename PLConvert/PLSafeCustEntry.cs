// Decompiled with JetBrains decompiler
// Type: PLConvert.PLSafeCustEntry
// Assembly: PLConvert, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DC1F0050-AC43-49A6-B4BD-95C619E8FF70
// Assembly location: C:\Users\haddocdx\Desktop\Conv DLLs\PLConvert.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace PLConvert
{
  public class PLSafeCustEntry : StaticData
  {
    private CPostItem m_PacketID;
    private CPostItem m_RecordItemNum;
    private CPostItem m_DeedTypeID;
    private CPostItem m_StageID;
    private CPostItem m_StatusID;
    private CPostItem m_UserID;
    private CPostItem m_SCRecStatus;
    private CPostItem m_SCRecDate;
    private CPostItem m_SCRecRemindDate;
    private CPostItem m_SCRecNextReviewDate;
    private CPostItem m_SCRecLastReviewDate;
    private CPostItem m_SCRecTerminateDate;
    private CPostItem m_SCRecAssetValue;
    private CPostItem m_SCRecImagePath;
    private CPostItem m_SCRecDescription;
    private CPostItem m_SCRecNotes;
    private List<int> ArrMatterID;
    private List<int> ArrContactID;
    private List<int> ArrContactRoleID;
    private CPostItem m_MatterID;
    private CPostItem m_ContactID;
    private CPostItem m_ContactRoleID;
    private static Dictionary<string, int> m_MapExtID1toPLID;
    private static Dictionary<string, int> m_MapExtID2toPLID;

    public int DeedTypeID
    {
      get
      {
        return this.m_DeedTypeID.nValue;
      }
      set
      {
        this.m_DeedTypeID.SetValue(value);
      }
    }

    public int PacketID
    {
      get
      {
        return this.m_PacketID.nValue;
      }
      set
      {
        this.m_PacketID.SetValue(value);
      }
    }

    public int RecordItemNum
    {
      get
      {
        return this.m_RecordItemNum.nValue;
      }
      set
      {
        this.m_RecordItemNum.SetValue(value);
      }
    }

    public double SCRecAssetValue
    {
      get
      {
        return this.m_SCRecAssetValue.dValue;
      }
      set
      {
        this.m_SCRecAssetValue.SetValue(value);
      }
    }

    public int SCRecDate
    {
      get
      {
        return this.m_SCRecDate.nValue;
      }
      set
      {
        this.m_SCRecDate.SetValue(value);
      }
    }

    public string SCRecDescription
    {
      get
      {
        return this.m_SCRecDescription.sValue;
      }
      set
      {
        this.m_SCRecDescription.SetValue(value);
      }
    }

    public string SCRecImagePath
    {
      get
      {
        return this.m_SCRecImagePath.sValue;
      }
      set
      {
        this.m_SCRecImagePath.SetValue(value);
      }
    }

    public int SCRecLastReviewDate
    {
      get
      {
        return this.m_SCRecLastReviewDate.nValue;
      }
      set
      {
        this.m_SCRecLastReviewDate.SetValue(value);
      }
    }

    public int SCRecNextReviewDate
    {
      get
      {
        return this.m_SCRecNextReviewDate.nValue;
      }
      set
      {
        this.m_SCRecNextReviewDate.SetValue(value);
      }
    }

    public string SCRecNotes
    {
      get
      {
        return this.m_SCRecNotes.sValue;
      }
      set
      {
        this.m_SCRecNotes.SetValue(value);
      }
    }

    public int SCRecRemindDate
    {
      get
      {
        return this.m_SCRecRemindDate.nValue;
      }
      set
      {
        this.m_SCRecRemindDate.SetValue(value);
      }
    }

    public PLXMLData.eSTATUS SCRecStatus
    {
      get
      {
        return (PLXMLData.eSTATUS) this.m_SCRecStatus.nValue;
      }
      set
      {
        this.m_SCRecStatus.SetValue((int) value);
      }
    }

    public int SCRecTerminateDate
    {
      get
      {
        return this.m_SCRecTerminateDate.nValue;
      }
      set
      {
        this.m_SCRecTerminateDate.SetValue(value);
      }
    }

    public int StageID
    {
      get
      {
        return this.m_StageID.nValue;
      }
      set
      {
        this.m_StageID.SetValue(value);
      }
    }

    public int StatusID
    {
      get
      {
        return this.m_StatusID.nValue;
      }
      set
      {
        this.m_StatusID.SetValue(value);
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

    public PLSafeCustEntry()
    {
      this.Initialize();
    }

    public void AddContact(int nContID, int nRoleId)
    {
      if (nContID.Equals(0) || this.ArrContactID.Contains(nContID))
        return;
      this.ArrContactID.Add(nContID);
      this.ArrContactRoleID.Add(nRoleId);
    }

    public void AddContact(int nContID)
    {
      if (nContID.Equals(0))
        return;
      this.AddContact(nContID, 0);
    }

    public void AddContact(string sContactExternalID1)
    {
      if (PLContact.GetIDFromExtID1(sContactExternalID1).Equals(0))
        return;
      this.AddContact(PLContact.GetIDFromExtID1(sContactExternalID1), 0);
    }

    public void AddContact(int nContID, string sRoleNN)
    {
      if (nContID.Equals(0))
        return;
      this.AddContact(nContID, PLContactType.GetIDFromNN(sRoleNN));
    }

    public static void AddMapExtID1toPLID(string Key, int Value)
    {
      if ((string.IsNullOrEmpty(Key) ? 0 : (!Value.Equals(0) ? 1 : 0)) == 0)
        return;
      if (PLSafeCustEntry.m_MapExtID1toPLID == null)
        PLSafeCustEntry.m_MapExtID1toPLID = new Dictionary<string, int>();
      if (!PLSafeCustEntry.m_MapExtID1toPLID.ContainsKey(Key))
        PLSafeCustEntry.m_MapExtID1toPLID.Add(Key, Value);
    }

    public static void AddMapExtID2toPLID(string Key, int Value)
    {
      if ((string.IsNullOrEmpty(Key) ? 0 : (!Value.Equals(0) ? 1 : 0)) == 0)
        return;
      if (PLSafeCustEntry.m_MapExtID2toPLID == null)
        PLSafeCustEntry.m_MapExtID2toPLID = new Dictionary<string, int>();
      if (!PLSafeCustEntry.m_MapExtID2toPLID.ContainsKey(Key))
        PLSafeCustEntry.m_MapExtID2toPLID.Add(Key, Value);
    }

    public void AddMatter(int nMattID)
    {
      if (nMattID.Equals(0) || this.ArrMatterID.Contains(nMattID))
        return;
      this.ArrMatterID.Add(nMattID);
    }

    public void AddMatter(string sMattNN)
    {
      this.AddMatter(PLMatter.GetIDFromNN(sMattNN));
    }

    public override void AddRecord()
    {
      if ((int) this.m_hndPOST == 0)
        this.m_hndPOST = this.GetLink().TablePOST_CreateHandle(this.m_sTableName, 0);
      foreach (CPostItem postItem in this.PostItems)
        postItem.AddField(this.m_hndPOST);
      for (int nRepeat = 1; nRepeat <= this.ArrMatterID.Count; ++nRepeat)
      {
        this.m_MatterID.SetValue(Convert.ToInt32(this.ArrMatterID[nRepeat - 1]));
        this.m_MatterID.AddRepeatField(this.m_hndPOST, nRepeat);
      }
      for (int nRepeat = 1; nRepeat <= this.ArrContactID.Count; ++nRepeat)
      {
        this.m_ContactID.SetValue(Convert.ToInt32(this.ArrContactID[nRepeat - 1]));
        this.m_ContactID.AddRepeatField(this.m_hndPOST, nRepeat);
        if (Convert.ToInt32(this.ArrContactRoleID[nRepeat - 1]) != 0)
        {
          this.m_ContactRoleID.SetValue(Convert.ToInt32(this.ArrContactID[nRepeat - 1]));
          this.m_ContactRoleID.AddRepeatField(this.m_hndPOST, nRepeat);
        }
      }
      this.GetLink().TablePOST_AddRecord(this.m_hndPOST);
      PLSafeCustEntry plSafeCustEntry = this;
      plSafeCustEntry.m_lCounter = plSafeCustEntry.m_lCounter + 1;
      if (this.m_lCounter >= PLXMLData.m_nMaxCounter)
        this.Send();
      this.Clear();
    }

    public override void Clear()
    {
      base.Clear();
      this.ArrMatterID.Clear();
      this.ArrContactID.Clear();
      this.ArrContactRoleID.Clear();
    }

    public static void ClearMapExtID1toPLID()
    {
      if (PLSafeCustEntry.m_MapExtID1toPLID == null)
        return;
      PLSafeCustEntry.m_MapExtID1toPLID.Clear();
      PLSafeCustEntry.m_MapExtID1toPLID = (Dictionary<string, int>) null;
    }

    public static void ClearMapExtID2toPLID()
    {
      if (PLSafeCustEntry.m_MapExtID2toPLID == null)
        return;
      PLSafeCustEntry.m_MapExtID2toPLID.Clear();
      PLSafeCustEntry.m_MapExtID2toPLID = (Dictionary<string, int>) null;
    }

    public int GetContactCount()
    {
      return this.ArrContactID.Count;
    }

    public override void GetExistingRecord()
    {
      throw new NotImplementedException();
    }

    public static int GetIDFromExtID1(string Key)
    {
      return !string.IsNullOrEmpty(Key) ? (PLSafeCustEntry.m_MapExtID1toPLID == null ? 0 : (PLSafeCustEntry.m_MapExtID1toPLID.ContainsKey(Key) ? Convert.ToInt32(PLSafeCustEntry.m_MapExtID1toPLID[Key]) : 0)) : 0;
    }

    public static int GetIDFromExtID2(string Key)
    {
      return !string.IsNullOrEmpty(Key) ? (PLSafeCustEntry.m_MapExtID2toPLID == null ? 0 : (PLSafeCustEntry.m_MapExtID2toPLID.ContainsKey(Key) ? Convert.ToInt32(PLSafeCustEntry.m_MapExtID2toPLID[Key]) : 0)) : 0;
    }

    public int GetMatterCount()
    {
      return this.ArrMatterID.Count;
    }

    public override void GetRecord()
    {
      this.Clear();
      if ((int) this.m_hndGET == 0)
        this.m_hndGET = this.GetLink().TableGET_CreateHandle(this.m_sTableName, 0, 0, 0U);
      foreach (CPostItem postItem in this.PostItems)
        postItem.GetField(this.m_hndGET);
    }

    protected override void Initialize()
    {
      this.m_sTableName = "SafeCustEntry";
      this.m_hndPOST = 0U;
      this.m_hndGET = 0U;
      this.m_hndExisting = 0U;
      List<CPostItem> postItems1 = this.PostItems;
      CPostItem cpostItem1 = new CPostItem(CPostItem.DataType.LONG, "SCRecID");
      CPostItem cpostItem2 = cpostItem1;
      this.m_ID = cpostItem1;
      postItems1.Add(cpostItem2);
      List<CPostItem> postItems2 = this.PostItems;
      CPostItem cpostItem3 = new CPostItem(CPostItem.DataType.LONG, "PacketID");
      CPostItem cpostItem4 = cpostItem3;
      this.m_PacketID = cpostItem3;
      postItems2.Add(cpostItem4);
      List<CPostItem> postItems3 = this.PostItems;
      CPostItem cpostItem5 = new CPostItem(CPostItem.DataType.LONG, "SCRecItemNumber");
      CPostItem cpostItem6 = cpostItem5;
      this.m_RecordItemNum = cpostItem5;
      postItems3.Add(cpostItem6);
      List<CPostItem> postItems4 = this.PostItems;
      CPostItem cpostItem7 = new CPostItem(CPostItem.DataType.LONG, "DeedTypeID");
      CPostItem cpostItem8 = cpostItem7;
      this.m_DeedTypeID = cpostItem7;
      postItems4.Add(cpostItem8);
      List<CPostItem> postItems5 = this.PostItems;
      CPostItem cpostItem9 = new CPostItem(CPostItem.DataType.LONG, "StageID");
      CPostItem cpostItem10 = cpostItem9;
      this.m_StageID = cpostItem9;
      postItems5.Add(cpostItem10);
      List<CPostItem> postItems6 = this.PostItems;
      CPostItem cpostItem11 = new CPostItem(CPostItem.DataType.LONG, "StatusID");
      CPostItem cpostItem12 = cpostItem11;
      this.m_StatusID = cpostItem11;
      postItems6.Add(cpostItem12);
      List<CPostItem> postItems7 = this.PostItems;
      CPostItem cpostItem13 = new CPostItem(CPostItem.DataType.LONG, "UserID");
      CPostItem cpostItem14 = cpostItem13;
      this.m_UserID = cpostItem13;
      postItems7.Add(cpostItem14);
      List<CPostItem> postItems8 = this.PostItems;
      CPostItem cpostItem15 = new CPostItem(CPostItem.DataType.LONG, "SCRecStatus");
      CPostItem cpostItem16 = cpostItem15;
      this.m_SCRecStatus = cpostItem15;
      postItems8.Add(cpostItem16);
      List<CPostItem> postItems9 = this.PostItems;
      CPostItem cpostItem17 = new CPostItem(CPostItem.DataType.LONG, "SCRecDate");
      CPostItem cpostItem18 = cpostItem17;
      this.m_SCRecDate = cpostItem17;
      postItems9.Add(cpostItem18);
      List<CPostItem> postItems10 = this.PostItems;
      CPostItem cpostItem19 = new CPostItem(CPostItem.DataType.LONG, "SCRecRemindDate");
      CPostItem cpostItem20 = cpostItem19;
      this.m_SCRecRemindDate = cpostItem19;
      postItems10.Add(cpostItem20);
      List<CPostItem> postItems11 = this.PostItems;
      CPostItem cpostItem21 = new CPostItem(CPostItem.DataType.LONG, "SCRecNextReviewDate");
      CPostItem cpostItem22 = cpostItem21;
      this.m_SCRecNextReviewDate = cpostItem21;
      postItems11.Add(cpostItem22);
      List<CPostItem> postItems12 = this.PostItems;
      CPostItem cpostItem23 = new CPostItem(CPostItem.DataType.LONG, "SCRecLastReviewDate");
      CPostItem cpostItem24 = cpostItem23;
      this.m_SCRecLastReviewDate = cpostItem23;
      postItems12.Add(cpostItem24);
      List<CPostItem> postItems13 = this.PostItems;
      CPostItem cpostItem25 = new CPostItem(CPostItem.DataType.LONG, "SCRecTerminateDate");
      CPostItem cpostItem26 = cpostItem25;
      this.m_SCRecTerminateDate = cpostItem25;
      postItems13.Add(cpostItem26);
      List<CPostItem> postItems14 = this.PostItems;
      CPostItem cpostItem27 = new CPostItem(CPostItem.DataType.DOUBLE, "SCRecAssetValue");
      CPostItem cpostItem28 = cpostItem27;
      this.m_SCRecAssetValue = cpostItem27;
      postItems14.Add(cpostItem28);
      List<CPostItem> postItems15 = this.PostItems;
      CPostItem cpostItem29 = new CPostItem(CPostItem.DataType.STRING, "SCRecImagePath");
      CPostItem cpostItem30 = cpostItem29;
      this.m_SCRecImagePath = cpostItem29;
      postItems15.Add(cpostItem30);
      List<CPostItem> postItems16 = this.PostItems;
      CPostItem cpostItem31 = new CPostItem(CPostItem.DataType.STRING, "SCRecDescription");
      CPostItem cpostItem32 = cpostItem31;
      this.m_SCRecDescription = cpostItem31;
      postItems16.Add(cpostItem32);
      List<CPostItem> postItems17 = this.PostItems;
      CPostItem cpostItem33 = new CPostItem(CPostItem.DataType.STRING, "SCRecNotes");
      CPostItem cpostItem34 = cpostItem33;
      this.m_SCRecNotes = cpostItem33;
      postItems17.Add(cpostItem34);
      List<CPostItem> postItems18 = this.PostItems;
      CPostItem cpostItem35 = new CPostItem(CPostItem.DataType.STRING, "m_ExternalID_1");
      CPostItem cpostItem36 = cpostItem35;
      this.m_ExternalID_1 = cpostItem35;
      postItems18.Add(cpostItem36);
      List<CPostItem> postItems19 = this.PostItems;
      CPostItem cpostItem37 = new CPostItem(CPostItem.DataType.STRING, "m_ExternalID_2");
      CPostItem cpostItem38 = cpostItem37;
      this.m_ExternalID_2 = cpostItem37;
      postItems19.Add(cpostItem38);
      this.m_MatterID = new CPostItem(CPostItem.DataType.RepeatLONG, "MatterID");
      this.m_ContactID = new CPostItem(CPostItem.DataType.RepeatLONG, "ContactID");
      this.m_ContactRoleID = new CPostItem(CPostItem.DataType.RepeatLONG, "ContactRoleID");
      this.ArrMatterID = new List<int>();
      this.ArrContactID = new List<int>();
      this.ArrContactRoleID = new List<int>();
    }

    public override string MakeNN(bool bSetNickName)
    {
      throw new NotImplementedException();
    }

    public override void Send()
    {
      object nProcessed = new object();
      object nExceptions = new object();
      object vunIDCreated = new object();
      object nExceptionError = new object();
      object szExceptionErrorMsg = new object();
      object szExceptionSentData = new object();
      object szValue = new object();
      string empty1 = string.Empty;
      string empty2 = string.Empty;
      this.m_lSendErrorCount = 0L;
      string str1;
      string str2;
      string str3;
      string message;
      string str4;
      string str5;
      string str6;
      try
      {
        this.GetLink().TablePOST_Send(this.m_hndPOST, ref nProcessed, ref nExceptions);
      }
      catch (NullReferenceException ex)
      {
        str1 = ex.Data == null ? string.Empty : ex.Data.ToString();
        str2 = ex.HelpLink == null ? string.Empty : ex.HelpLink.ToString();
        str3 = ex.InnerException == null ? string.Empty : ex.InnerException.ToString();
        message = ex.Message;
        str4 = ex.Source == null ? string.Empty : ex.Source.ToString();
        str5 = ex.StackTrace == null ? string.Empty : ex.StackTrace.ToString();
        str6 = ex.TargetSite == (MethodBase) null ? string.Empty : ex.TargetSite.ToString();
        this.GetLink().TablePOST_Reset(this.m_hndPOST);
        return;
      }
      catch (AccessViolationException ex)
      {
        str1 = ex.Data == null ? string.Empty : ex.Data.ToString();
        str2 = ex.HelpLink == null ? string.Empty : ex.HelpLink.ToString();
        str3 = ex.InnerException == null ? "" : ex.InnerException.ToString();
        message = ex.Message;
        str4 = ex.Source == null ? "" : ex.Source.ToString();
        str5 = ex.StackTrace == null ? "" : ex.StackTrace.ToString();
        str6 = ex.TargetSite == (MethodBase) null ? "" : ex.TargetSite.ToString();
        this.GetLink().TablePOST_Reset(this.m_hndPOST);
        return;
      }
      catch (FormatException ex)
      {
        str1 = ex.Data == null ? "" : ex.Data.ToString();
        str2 = ex.HelpLink == null ? "" : ex.HelpLink.ToString();
        str3 = ex.InnerException == null ? "" : ex.InnerException.ToString();
        message = ex.Message;
        str4 = ex.Source == null ? "" : ex.Source.ToString();
        str5 = ex.StackTrace == null ? "" : ex.StackTrace.ToString();
        str6 = ex.TargetSite == (MethodBase) null ? "" : ex.TargetSite.ToString();
        this.GetLink().TablePOST_Reset(this.m_hndPOST);
        return;
      }
      catch (Exception ex)
      {
        str1 = ex.Data == null ? "" : ex.Data.ToString();
        str2 = ex.HelpLink == null ? "" : ex.HelpLink.ToString();
        str3 = ex.InnerException == null ? "" : ex.InnerException.ToString();
        message = ex.Message;
        str4 = ex.Source == null ? "" : ex.Source.ToString();
        str5 = ex.StackTrace == null ? "" : ex.StackTrace.ToString();
        str6 = ex.TargetSite == (MethodBase) null ? "" : ex.TargetSite.ToString();
        this.GetLink().TablePOST_Reset(this.m_hndPOST);
        this.m_lCounter = 0;
        return;
      }
      try
      {
        while (this.GetLink().TablePOST_GetNextResult(this.m_hndPOST, ref vunIDCreated, ref nExceptionError, ref szExceptionErrorMsg, ref szExceptionSentData) == 0)
        {
          if (Convert.ToInt32(nExceptionError) <= 0)
          {
            int int32 = Convert.ToInt32(vunIDCreated);
            this.GetLink().TablePOST_ResultDataField_String(this.m_hndPOST, this.m_ExternalID_1.sLinkName, empty2, ref szValue);
            PLSafeCustEntry.AddMapExtID1toPLID(szValue.ToString(), int32);
            this.GetLink().TablePOST_ResultDataField_String(this.m_hndPOST, this.m_ExternalID_2.sLinkName, empty2, ref szValue);
            PLSafeCustEntry.AddMapExtID2toPLID(szValue.ToString(), int32);
          }
        }
        short int16_1 = Convert.ToInt16(nProcessed);
        short int16_2 = Convert.ToInt16(nExceptions);
        PLXMLData.m_lErrorCount += (long) int16_2;
        if (((int) int16_2 > 0 ? 1 : (this.m_lCounter != (int) int16_1 ? 1 : 0)) != 0)
        {
          this.GetLink().TablePOST_DumpExceptionsToLinkLog(this.m_hndPOST);
          PLSafeCustEntry plSafeCustEntry = this;
          plSafeCustEntry.m_lSendErrorCount = plSafeCustEntry.m_lSendErrorCount + 1L;
        }
        this.GetLink().TablePOST_Reset(this.m_hndPOST);
        this.m_lCounter = 0;
      }
      catch (Exception ex)
      {
        str1 = ex.Data == null ? "" : ex.Data.ToString();
        str2 = ex.HelpLink == null ? "" : ex.HelpLink.ToString();
        str3 = ex.InnerException == null ? "" : ex.InnerException.ToString();
        message = ex.Message;
        str4 = ex.Source == null ? "" : ex.Source.ToString();
        str5 = ex.StackTrace == null ? "" : ex.StackTrace.ToString();
        str6 = ex.TargetSite == (MethodBase) null ? "" : ex.TargetSite.ToString();
        this.GetLink().TablePOST_Reset(this.m_hndPOST);
        this.m_lCounter = 0;
      }
    }
  }
}
