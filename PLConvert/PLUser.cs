// Decompiled with JetBrains decompiler
// Type: PLConvert.PLUser
// Assembly: PLConvert, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DC1F0050-AC43-49A6-B4BD-95C619E8FF70
// Assembly location: C:\Users\haddocdx\Desktop\Conv DLLs\PLConvert.dll

using System;
using System.Collections.Generic;

namespace PLConvert
{
  public class PLUser : StaticData
  {
    private new static List<string> m_NNs = new List<string>();
    private static Dictionary<string, int> m_MapNNtoID = new Dictionary<string, int>();
    private static Dictionary<int, string> m_MapIDtoNN = new Dictionary<int, string>();
    private static Dictionary<string, int> m_MapExtID1toPLID = new Dictionary<string, int>();
    private static Dictionary<string, int> m_MapExtID2toPLID = new Dictionary<string, int>();
    private static bool bRead = false;
    private CPostItem m_GroupID;
    private List<int> m_GroupIDArray;
    private CPostItem m_Name;
    private CPostItem m_Description;
    private CPostItem m_Password;
    private CPostItem m_NewPassword;
    private CPostItem m_EMail;

    public string Description
    {
      get
      {
        return this.m_Description.sValue;
      }
      set
      {
        this.m_Description.SetValue(value);
      }
    }

    public string EMail
    {
      get
      {
        return this.m_EMail.sValue;
      }
      set
      {
        this.m_EMail.SetValue(value);
      }
    }

    public string Name
    {
      get
      {
        return this.m_Name.sValue;
      }
      set
      {
        this.m_Name.SetValue(value);
      }
    }

    public string NewPassword
    {
      get
      {
        return this.m_NewPassword.sValue;
      }
      set
      {
        this.m_NewPassword.SetValue(value);
      }
    }

    public string Password
    {
      get
      {
        return this.m_Password.sValue;
      }
      set
      {
        this.m_Password.SetValue(value);
      }
    }

    public PLUser()
    {
      this.Initialize();
    }

    public void AddGroupID(int nGroupID)
    {
      if (nGroupID == 0)
        return;
      this.m_GroupIDArray.Add(nGroupID);
    }

    public static void AddMapExtID1toPLID(string Key, int Value)
    {
      if ((Key.Equals("") ? 0 : (!PLUser.m_MapExtID1toPLID.ContainsKey(Key) ? 1 : 0)) == 0)
        return;
      PLUser.m_MapExtID1toPLID.Add(Key, Value);
    }

    public static void AddMapExtID2toPLID(string Key, int Value)
    {
      if ((Key.Equals("") ? 0 : (!PLUser.m_MapExtID2toPLID.ContainsKey(Key) ? 1 : 0)) == 0)
        return;
      PLUser.m_MapExtID2toPLID.Add(Key, Value);
    }

    public static void AddMapIDtoNN(int Key, string Value)
    {
      if ((Key.Equals(0) ? 0 : (!PLUser.m_MapIDtoNN.ContainsKey(Key) ? 1 : 0)) == 0)
        return;
      PLUser.m_MapIDtoNN.Add(Key, Value);
    }

    public static void AddMapNNtoID(string Key, int Value)
    {
      Key = Key.ToUpper();
      if ((Key.Equals("") ? 0 : (!PLUser.m_MapNNtoID.ContainsKey(Key) ? 1 : 0)) == 0)
        return;
      PLUser.m_MapNNtoID.Add(Key, Value);
    }

    protected new static void AddNicknameToList(string sNickname)
    {
      if (string.IsNullOrEmpty(sNickname))
        return;
      if (PLUser.m_NNs == null)
        PLUser.m_NNs = new List<string>();
      PLUser.m_NNs.Add(sNickname.ToLower());
    }

    public override void AddRecord()
    {
      base.AddRecord();
      for (int nRepeat = 1; nRepeat <= this.m_GroupIDArray.Count; ++nRepeat)
      {
        if (Convert.ToInt32(this.m_GroupIDArray[nRepeat - 1]) != 0)
        {
          this.m_GroupID.SetValue(Convert.ToInt32(this.m_GroupIDArray[nRepeat - 1]));
          this.m_GroupID.AddRepeatField(this.m_hndPOST, nRepeat);
        }
      }
      this.m_GroupIDArray.Clear();
      this.GetLink().TablePOST_AddRecord(this.m_hndPOST);
      PLUser plUser = this;
      plUser.m_lCounter = plUser.m_lCounter + 1;
      if (this.m_lCounter < PLXMLData.m_nMaxCounter)
        return;
      this.Send();
    }

    public override void Clear()
    {
      base.Clear();
      this.m_GroupID.Clear();
      this.m_GroupIDArray.Clear();
    }

    public static void ClearMapExtID1toPLID()
    {
      if (PLUser.m_MapExtID1toPLID == null)
        return;
      PLUser.m_MapExtID1toPLID.Clear();
      PLUser.m_MapExtID1toPLID = (Dictionary<string, int>) null;
    }

    public static void ClearMapExtID2toPLID()
    {
      if (PLUser.m_MapExtID2toPLID == null)
        return;
      PLUser.m_MapExtID2toPLID.Clear();
      PLUser.m_MapExtID2toPLID = (Dictionary<string, int>) null;
    }

    public static void ClearMapIDtoNN()
    {
      if (PLUser.m_MapIDtoNN == null)
        return;
      PLUser.m_MapIDtoNN.Clear();
      PLUser.m_MapIDtoNN = (Dictionary<int, string>) null;
    }

    public static void ClearMapNNtoID()
    {
      if (PLUser.m_MapNNtoID == null)
        return;
      PLUser.m_MapNNtoID.Clear();
      PLUser.m_MapNNtoID = (Dictionary<string, int>) null;
    }

    public override void GetExistingRecord()
    {
      base.GetExistingRecord();
      int recurringFieldCount = this.GetLink().TableGET_RecordRecurringField_Count(this.m_hndGET, "SecUserGroupIDs");
      for (int nRepeat = 1; nRepeat <= recurringFieldCount; ++nRepeat)
      {
        this.m_GroupID.GetRepeatField(this.m_hndExisting, nRepeat);
        this.AddGroupID(this.m_GroupID.nValue);
      }
    }

    public static int GetIDFromExtID1(string sNN)
    {
      return PLUser.m_MapExtID1toPLID.ContainsKey(sNN) ? Convert.ToInt32(PLUser.m_MapExtID1toPLID[sNN]) : 0;
    }

    public static int GetIDFromExtID2(string sNN)
    {
      return PLUser.m_MapExtID2toPLID.ContainsKey(sNN) ? Convert.ToInt32(PLUser.m_MapExtID2toPLID[sNN]) : 0;
    }

    public static int GetIDFromNN(string Key)
    {
      if (!PLUser.bRead)
        PLUser.ReadTable();
      Key = Key.ToUpper();
      return PLUser.m_MapNNtoID.ContainsKey(Key) ? Convert.ToInt32(PLUser.m_MapNNtoID[Key]) : 0;
    }

    public static string GetNNFromID(int nID)
    {
      if (!PLUser.bRead)
        PLUser.ReadTable();
      return PLUser.m_MapIDtoNN.ContainsKey(nID) ? PLUser.m_MapIDtoNN[nID].ToString() : "";
    }

    public override void GetRecord()
    {
      base.GetRecord();
      int recurringFieldCount = this.GetLink().TableGET_RecordRecurringField_Count(this.m_hndGET, "SecUserGroupIDs");
      for (int nRepeat = 1; nRepeat <= recurringFieldCount; ++nRepeat)
      {
        this.m_GroupID.GetRepeatField(this.m_hndGET, nRepeat);
        this.AddGroupID(this.m_GroupID.nValue);
      }
    }

    protected override void Initialize()
    {
      this.m_lCounter = 0;
      this.m_sTableName = "SecUser";
      this.m_hndPOST = 0U;
      this.m_hndGET = 0U;
      this.m_hndExisting = 0U;
      List<CPostItem> postItems1 = this.PostItems;
      CPostItem cpostItem1 = new CPostItem(CPostItem.DataType.LONG, "SecUserID");
      CPostItem cpostItem2 = cpostItem1;
      this.m_ID = cpostItem1;
      postItems1.Add(cpostItem2);
      List<CPostItem> postItems2 = this.PostItems;
      CPostItem cpostItem3 = new CPostItem(CPostItem.DataType.STRING, "SecUserName");
      CPostItem cpostItem4 = cpostItem3;
      this.m_Name = cpostItem3;
      postItems2.Add(cpostItem4);
      List<CPostItem> postItems3 = this.PostItems;
      CPostItem cpostItem5 = new CPostItem(CPostItem.DataType.STRING, "SecUserDescription");
      CPostItem cpostItem6 = cpostItem5;
      this.m_Description = cpostItem5;
      postItems3.Add(cpostItem6);
      List<CPostItem> postItems4 = this.PostItems;
      CPostItem cpostItem7 = new CPostItem(CPostItem.DataType.STRING, "SecUserPassword");
      CPostItem cpostItem8 = cpostItem7;
      this.m_Password = cpostItem7;
      postItems4.Add(cpostItem8);
      List<CPostItem> postItems5 = this.PostItems;
      CPostItem cpostItem9 = new CPostItem(CPostItem.DataType.STRING, "SecUserNewPassword");
      CPostItem cpostItem10 = cpostItem9;
      this.m_NewPassword = cpostItem9;
      postItems5.Add(cpostItem10);
      List<CPostItem> postItems6 = this.PostItems;
      CPostItem cpostItem11 = new CPostItem(CPostItem.DataType.STRING, "SecUserEMail");
      CPostItem cpostItem12 = cpostItem11;
      this.m_EMail = cpostItem11;
      postItems6.Add(cpostItem12);
      List<CPostItem> postItems7 = this.PostItems;
      CPostItem cpostItem13 = new CPostItem(CPostItem.DataType.STRING, "SecUserNickName");
      CPostItem cpostItem14 = cpostItem13;
      this.m_NickName = cpostItem13;
      postItems7.Add(cpostItem14);
      List<CPostItem> postItems8 = this.PostItems;
      CPostItem cpostItem15 = new CPostItem(CPostItem.DataType.LONG, "SecUserStatus");
      CPostItem cpostItem16 = cpostItem15;
      this.m_Status = cpostItem15;
      postItems8.Add(cpostItem16);
      this.m_ExternalID_1 = new CPostItem(CPostItem.DataType.STRING, "ExternalID_1");
      this.m_ExternalID_2 = new CPostItem(CPostItem.DataType.STRING, "ExternalID_2");
      this.m_GroupIDArray = new List<int>();
      this.m_GroupID = new CPostItem(CPostItem.DataType.RepeatLONG, "SecUserGroupIDs");
    }

    public override string MakeNN(bool bSetNickName)
    {
      if (!PLUser.bRead)
        PLUser.ReadTable();
      string str = this.MakeListNN(this.Name, PLUser.m_NNs, (short) 25);
      if (bSetNickName)
        this.NickName = str;
      return str;
    }

    private static void ReadTable()
    {
      if (PLUser.bRead)
        return;
      uint num = 0;
      object szValue = new object();
      uint createHandle = PLLink.GetLink().TableGET_CreateHandle("SecUser", 0, 0, 0U);
      PLLink.GetLink().TableGET_AddFilter(createHandle, "SecUserStatus", "EQ", "0", 1);
      while (PLLink.GetLink().TableGET_GetNextRecord(createHandle) == 0)
      {
        PLLink.GetLink().TableGET_RecordField_ValueString(createHandle, "SecUserNickName", "", ref szValue);
        string str = szValue.ToString().ToUpper().Trim();
        int recordFieldValueI32 = PLLink.GetLink().TableGET_RecordField_ValueI32(createHandle, "SecUserID");
        PLUser.AddMapNNtoID(str, recordFieldValueI32);
        PLUser.AddMapIDtoNN(recordFieldValueI32, str);
        PLUser.AddNicknameToList(str);
      }
      PLLink.GetLink().TableGET_CloseHandle(createHandle);
      num = 0U;
      PLUser.bRead = true;
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
      string szDefault = "";
      this.m_lSendErrorCount = 0L;
      this.GetLink().TablePOST_Send(this.m_hndPOST, ref nProcessed, ref nExceptions);
      while (this.GetLink().TablePOST_GetNextResult(this.m_hndPOST, ref vunIDCreated, ref nExceptionError, ref szExceptionErrorMsg, ref szExceptionSentData) == 0)
      {
        if (Convert.ToInt32(nExceptionError) <= 0)
        {
          int int32 = Convert.ToInt32(vunIDCreated);
          this.GetLink().TablePOST_ResultDataField_String(this.m_hndPOST, this.m_NickName.sLinkName, szDefault, ref szValue);
          PLDiaryCode.AddMapIDtoNN(int32, szValue.ToString().ToUpper());
          PLDiaryCode.AddMapNNtoID(szValue.ToString().ToUpper(), int32);
          this.GetLink().TablePOST_ResultDataField_String(this.m_hndPOST, this.m_ExternalID_1.sLinkName, szDefault, ref szValue);
          if (!szValue.ToString().Equals(""))
            PLDiaryCode.AddMapExtID1toPLID(szValue.ToString(), int32);
          this.GetLink().TablePOST_ResultDataField_String(this.m_hndPOST, this.m_ExternalID_2.sLinkName, szDefault, ref szValue);
          if (!szValue.ToString().Equals(""))
            PLDiaryCode.AddMapExtID2toPLID(szValue.ToString(), int32);
        }
      }
      short int16_1 = Convert.ToInt16(nProcessed);
      short int16_2 = Convert.ToInt16(nExceptions);
      PLXMLData.m_lErrorCount += (long) int16_2;
      if (((int) int16_2 > 0 ? 1 : (this.m_lCounter != (int) int16_1 ? 1 : 0)) != 0)
      {
        this.GetLink().TablePOST_DumpExceptionsToLinkLog(this.m_hndPOST);
        PLUser plUser = this;
        plUser.m_lSendErrorCount = plUser.m_lSendErrorCount + 1L;
      }
      this.GetLink().TablePOST_Reset(this.m_hndPOST);
      this.m_lCounter = 0;
    }
  }
}
