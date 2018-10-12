// Decompiled with JetBrains decompiler
// Type: PLConvert.PLTask
// Assembly: PLConvert, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DC1F0050-AC43-49A6-B4BD-95C619E8FF70
// Assembly location: C:\Users\haddocdx\Desktop\Conv DLLs\PLConvert.dll

using System;
using System.Collections.Generic;

namespace PLConvert
{
  public class PLTask : StaticData
  {
    private new static List<string> m_NNs = new List<string>();
    private static Dictionary<string, int> m_MapNNtoID = new Dictionary<string, int>();
    private static Dictionary<int, string> m_MapIDtoNN = new Dictionary<int, string>();
    private static Dictionary<string, int> m_MapExtID1toPLID = new Dictionary<string, int>();
    private static Dictionary<string, int> m_MapExtID2toPLID = new Dictionary<string, int>();
    private static bool bRead = false;
    private CPostItem m_ParentTaskID;
    private CPostItem m_RateID;
    private CPostItem m_Category;
    private CPostItem m_Description;
    private CPostItem m_Name;
    private CPostItem m_RateAmount;
    private CPostItem m_TypeOfLawID;
    private CPostItem m_IsBillable;
    private CPostItem m_IsGeneral;
    private CPostItem m_IsWaiting;
    private CPostItem m_IsTravel;
    private CPostItem m_IsUseDefRate;
    private CPostItem m_StatusNeverBill;
    private static Dictionary<int, string> m_MapPLIDtoQBID;

    public PLTask.eCATEGORY Category
    {
      get
      {
        return (PLTask.eCATEGORY) this.m_Category.nValue;
      }
      set
      {
        this.m_Category.SetValue((int) value);
      }
    }

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

    public bool IsBillable
    {
      get
      {
        return this.m_IsBillable.bValue;
      }
      set
      {
        this.m_IsBillable.SetValue(value);
      }
    }

    public bool IsGeneral
    {
      get
      {
        return this.m_IsGeneral.bValue;
      }
      set
      {
        this.m_IsGeneral.SetValue(value);
      }
    }

    public bool IsTravel
    {
      get
      {
        return this.m_IsTravel.bValue;
      }
      set
      {
        this.m_IsTravel.SetValue(value);
      }
    }

    public bool IsUseDefRate
    {
      get
      {
        return this.m_IsUseDefRate.bValue;
      }
      set
      {
        this.m_IsUseDefRate.SetValue(value);
      }
    }

    public bool IsWaiting
    {
      get
      {
        return this.m_IsWaiting.bValue;
      }
      set
      {
        this.m_IsWaiting.SetValue(value);
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

    public string ParentTaskNN
    {
      get
      {
        return PLTask.GetNNFromID(this.m_ParentTaskID.nValue);
      }
      set
      {
        this.m_ParentTaskID.SetValue(PLTask.GetIDFromNN(value));
      }
    }

    public double RateAmount
    {
      get
      {
        return this.m_RateAmount.dValue;
      }
      set
      {
        this.m_RateAmount.SetValue(value);
      }
    }

    public string RateNN
    {
      get
      {
        return PLTask.GetNNFromID(this.m_RateID.nValue);
      }
      set
      {
        this.m_RateID.SetValue(PLTask.GetIDFromNN(value));
      }
    }

    public bool StatusNeverBill
    {
      get
      {
        return this.m_StatusNeverBill.bValue;
      }
      set
      {
        this.m_StatusNeverBill.SetValue(value);
      }
    }

    public int TypeOfLawID
    {
      get
      {
        return this.m_TypeOfLawID.nValue;
      }
      set
      {
        this.m_TypeOfLawID.SetValue(value);
      }
    }

    public string TypeOfLawNN
    {
      get
      {
        return PLTypeOfLaw.GetNNFromID(this.m_TypeOfLawID.nValue);
      }
      set
      {
        this.m_TypeOfLawID.SetValue(PLTypeOfLaw.GetIDFromNN(value));
      }
    }

    public PLTask()
    {
      this.Initialize();
    }

    public static void AddMapExtID1toPLID(string Key, int Value)
    {
      if ((Key.Equals("") ? 0 : (!PLTask.m_MapExtID1toPLID.ContainsKey(Key) ? 1 : 0)) == 0)
        return;
      PLTask.m_MapExtID1toPLID.Add(Key, Value);
    }

    public static void AddMapExtID2toPLID(string Key, int Value)
    {
      if ((Key.Equals("") ? 0 : (!PLTask.m_MapExtID2toPLID.ContainsKey(Key) ? 1 : 0)) == 0)
        return;
      PLTask.m_MapExtID2toPLID.Add(Key, Value);
    }

    public static void AddMapIDtoNN(int Key, string Value)
    {
      if ((Key.Equals(0) ? 0 : (!PLTask.m_MapIDtoNN.ContainsKey(Key) ? 1 : 0)) == 0)
        return;
      PLTask.m_MapIDtoNN.Add(Key, Value);
    }

    public static void AddMapNNtoID(string Key, int Value)
    {
      Key = Key.ToUpper();
      if ((Key.Equals("") ? 0 : (!PLTask.m_MapNNtoID.ContainsKey(Key) ? 1 : 0)) == 0)
        return;
      PLTask.m_MapNNtoID.Add(Key, Value);
    }

    public static void AddMapPLIDtoQBID(int Key, string Value)
    {
      if ((Key.Equals(0) ? 0 : (!Value.Equals("") ? 1 : 0)) == 0)
        return;
      if (PLTask.m_MapPLIDtoQBID == null)
        PLTask.m_MapPLIDtoQBID = new Dictionary<int, string>();
      if (PLTask.m_MapPLIDtoQBID.ContainsKey(Key))
        PLTask.m_MapPLIDtoQBID.Remove(Key);
      PLTask.m_MapPLIDtoQBID.Add(Key, Value);
    }

    protected new static void AddNicknameToList(string sNickname)
    {
      if (string.IsNullOrEmpty(sNickname))
        return;
      if (PLTask.m_NNs == null)
        PLTask.m_NNs = new List<string>();
      PLTask.m_NNs.Add(sNickname.ToLower());
    }

    public override void AddRecord()
    {
      PLTask.AddNicknameToList(this.NickName);
      base.AddRecord();
      this.GetLink().TablePOST_AddRecord(this.m_hndPOST);
      PLTask plTask = this;
      plTask.m_lCounter = plTask.m_lCounter + 1;
      if (this.m_lCounter < PLXMLData.m_nMaxCounter)
        return;
      this.Send();
    }

    public static void ClearMapExtID1toPLID()
    {
      if (PLTask.m_MapExtID1toPLID == null)
        return;
      PLTask.m_MapExtID1toPLID.Clear();
      PLTask.m_MapExtID1toPLID = (Dictionary<string, int>) null;
    }

    public static void ClearMapExtID2toPLID()
    {
      if (PLTask.m_MapExtID2toPLID == null)
        return;
      PLTask.m_MapExtID2toPLID.Clear();
      PLTask.m_MapExtID2toPLID = (Dictionary<string, int>) null;
    }

    public static void ClearMapIDtoNN()
    {
      if (PLTask.m_MapIDtoNN == null)
        return;
      PLTask.m_MapIDtoNN.Clear();
      PLTask.m_MapIDtoNN = (Dictionary<int, string>) null;
    }

    public static void ClearMapNNtoID()
    {
      if (PLTask.m_MapNNtoID == null)
        return;
      PLTask.m_MapNNtoID.Clear();
      PLTask.m_MapNNtoID = (Dictionary<string, int>) null;
    }

    public static void ClearMapPLIDtoQBID()
    {
      if (PLTask.m_MapPLIDtoQBID == null)
        return;
      PLTask.m_MapPLIDtoQBID.Clear();
      PLTask.m_MapPLIDtoQBID = (Dictionary<int, string>) null;
    }

    public override void GetExistingRecord()
    {
    }

    public static int GetIDFromExtID1(string Key)
    {
      return PLTask.m_MapExtID1toPLID.ContainsKey(Key) ? Convert.ToInt32(PLTask.m_MapExtID1toPLID[Key]) : 0;
    }

    public static int GetIDFromExtID2(string Key)
    {
      return PLTask.m_MapExtID2toPLID.ContainsKey(Key) ? Convert.ToInt32(PLTask.m_MapExtID2toPLID[Key]) : 0;
    }

    public static int GetIDFromNN(string Key)
    {
      if (!PLTask.bRead)
        PLTask.ReadTable();
      Key = Key.ToUpper();
      return PLTask.m_MapNNtoID.ContainsKey(Key) ? Convert.ToInt32(PLTask.m_MapNNtoID[Key]) : 0;
    }

    public static string GetNNFromID(int Key)
    {
      if (!PLTask.bRead)
        PLTask.ReadTable();
      return PLTask.m_MapIDtoNN.ContainsKey(Key) ? PLTask.m_MapIDtoNN[Key].ToString() : "";
    }

    public static int GetPLIDFromQBID(string sQBID)
    {
      int num1;
      if (!sQBID.Equals(""))
      {
        if (!PLTask.bRead)
          PLTask.ReadTable();
        if (PLTask.m_MapPLIDtoQBID == null)
          num1 = 0;
        else if (PLTask.m_MapPLIDtoQBID.ContainsValue(sQBID))
        {
          int num2 = 0;
          Dictionary<int, string>.Enumerator enumerator = PLTask.m_MapPLIDtoQBID.GetEnumerator();
          while (enumerator.MoveNext())
          {
            Dictionary<int, string> mapPliDtoQbid = PLTask.m_MapPLIDtoQBID;
            KeyValuePair<int, string> current = enumerator.Current;
            if (mapPliDtoQbid[current.Key].ToUpper().CompareTo(sQBID.ToUpper()) == 0)
            {
              current = enumerator.Current;
              num2 = current.Key;
            }
          }
          num1 = num2;
        }
        else
          num1 = 0;
      }
      else
        num1 = 0;
      return num1;
    }

    public static string GetQBIDFromPLID(int nID)
    {
      string str;
      if (!nID.Equals(0))
      {
        if (!PLTask.bRead)
          PLTask.ReadTable();
        str = PLTask.m_MapPLIDtoQBID == null ? "" : (PLTask.m_MapPLIDtoQBID.ContainsKey(nID) ? Convert.ToString(PLTask.m_MapPLIDtoQBID[nID]) : "");
      }
      else
        str = "";
      return str;
    }

    public override void GetRecord()
    {
      base.GetRecord();
    }

    protected override void Initialize()
    {
      this.m_sTableName = "Task";
      List<CPostItem> postItems1 = this.PostItems;
      CPostItem cpostItem1 = new CPostItem(CPostItem.DataType.LONG, "ParentID");
      CPostItem cpostItem2 = cpostItem1;
      this.m_ParentTaskID = cpostItem1;
      postItems1.Add(cpostItem2);
      List<CPostItem> postItems2 = this.PostItems;
      CPostItem cpostItem3 = new CPostItem(CPostItem.DataType.LONG, "RateID");
      CPostItem cpostItem4 = cpostItem3;
      this.m_RateID = cpostItem3;
      postItems2.Add(cpostItem4);
      List<CPostItem> postItems3 = this.PostItems;
      CPostItem cpostItem5 = new CPostItem(CPostItem.DataType.LONG, "TaskCategory");
      CPostItem cpostItem6 = cpostItem5;
      this.m_Category = cpostItem5;
      postItems3.Add(cpostItem6);
      List<CPostItem> postItems4 = this.PostItems;
      CPostItem cpostItem7 = new CPostItem(CPostItem.DataType.STRING, "TaskExplanation");
      CPostItem cpostItem8 = cpostItem7;
      this.m_Description = cpostItem7;
      postItems4.Add(cpostItem8);
      List<CPostItem> postItems5 = this.PostItems;
      CPostItem cpostItem9 = new CPostItem(CPostItem.DataType.LONG, "TaskID");
      CPostItem cpostItem10 = cpostItem9;
      this.m_ID = cpostItem9;
      postItems5.Add(cpostItem10);
      List<CPostItem> postItems6 = this.PostItems;
      CPostItem cpostItem11 = new CPostItem(CPostItem.DataType.STRING, "TaskName");
      CPostItem cpostItem12 = cpostItem11;
      this.m_Name = cpostItem11;
      postItems6.Add(cpostItem12);
      List<CPostItem> postItems7 = this.PostItems;
      CPostItem cpostItem13 = new CPostItem(CPostItem.DataType.STRING, "TaskNickName");
      CPostItem cpostItem14 = cpostItem13;
      this.m_NickName = cpostItem13;
      postItems7.Add(cpostItem14);
      List<CPostItem> postItems8 = this.PostItems;
      CPostItem cpostItem15 = new CPostItem(CPostItem.DataType.DOUBLE, "TaskRateAmount");
      CPostItem cpostItem16 = cpostItem15;
      this.m_RateAmount = cpostItem15;
      postItems8.Add(cpostItem16);
      List<CPostItem> postItems9 = this.PostItems;
      CPostItem cpostItem17 = new CPostItem(CPostItem.DataType.LONG, "TaskStatus");
      CPostItem cpostItem18 = cpostItem17;
      this.m_Status = cpostItem17;
      postItems9.Add(cpostItem18);
      List<CPostItem> postItems10 = this.PostItems;
      CPostItem cpostItem19 = new CPostItem(CPostItem.DataType.LONG, "TypeOfLawID");
      CPostItem cpostItem20 = cpostItem19;
      this.m_TypeOfLawID = cpostItem19;
      postItems10.Add(cpostItem20);
      List<CPostItem> postItems11 = this.PostItems;
      CPostItem cpostItem21 = new CPostItem(CPostItem.DataType.LONG, "TaskTransactionChangeID");
      CPostItem cpostItem22 = cpostItem21;
      this.m_TransactionChgID = cpostItem21;
      postItems11.Add(cpostItem22);
      List<CPostItem> postItems12 = this.PostItems;
      CPostItem cpostItem23 = new CPostItem(CPostItem.DataType.LONG, "TaskTransNewID");
      CPostItem cpostItem24 = cpostItem23;
      this.m_TransactionNewID = cpostItem23;
      postItems12.Add(cpostItem24);
      List<CPostItem> postItems13 = this.PostItems;
      CPostItem cpostItem25 = new CPostItem(CPostItem.DataType.STRING, "TaskQuickBooksID");
      CPostItem cpostItem26 = cpostItem25;
      this.m_QuickBooksID = cpostItem25;
      postItems13.Add(cpostItem26);
      List<CPostItem> postItems14 = this.PostItems;
      CPostItem cpostItem27 = new CPostItem(CPostItem.DataType.STRING, "TaskIsBillable");
      CPostItem cpostItem28 = cpostItem27;
      this.m_IsBillable = cpostItem27;
      postItems14.Add(cpostItem28);
      List<CPostItem> postItems15 = this.PostItems;
      CPostItem cpostItem29 = new CPostItem(CPostItem.DataType.BOOL, "TaskIsGeneral");
      CPostItem cpostItem30 = cpostItem29;
      this.m_IsGeneral = cpostItem29;
      postItems15.Add(cpostItem30);
      List<CPostItem> postItems16 = this.PostItems;
      CPostItem cpostItem31 = new CPostItem(CPostItem.DataType.BOOL, "TaskIsWaiting");
      CPostItem cpostItem32 = cpostItem31;
      this.m_IsWaiting = cpostItem31;
      postItems16.Add(cpostItem32);
      List<CPostItem> postItems17 = this.PostItems;
      CPostItem cpostItem33 = new CPostItem(CPostItem.DataType.BOOL, "TaskIsTravel");
      CPostItem cpostItem34 = cpostItem33;
      this.m_IsTravel = cpostItem33;
      postItems17.Add(cpostItem34);
      List<CPostItem> postItems18 = this.PostItems;
      CPostItem cpostItem35 = new CPostItem(CPostItem.DataType.BOOL, "TaskIsUseDefRate");
      CPostItem cpostItem36 = cpostItem35;
      this.m_IsUseDefRate = cpostItem35;
      postItems18.Add(cpostItem36);
      List<CPostItem> postItems19 = this.PostItems;
      CPostItem cpostItem37 = new CPostItem(CPostItem.DataType.BOOL, "TaskHoldStatusNeverBill");
      CPostItem cpostItem38 = cpostItem37;
      this.m_StatusNeverBill = cpostItem37;
      postItems19.Add(cpostItem38);
      this.m_ExternalID_1 = new CPostItem(CPostItem.DataType.STRING, "ExternalID_1");
      this.m_ExternalID_2 = new CPostItem(CPostItem.DataType.STRING, "ExternalID_2");
    }

    public override string MakeNN(bool bSetNickName)
    {
        return this.NickName;
    }

    private static void ReadTable()
    {
      if (PLTask.bRead)
        return;
      uint num = 0;
      object szValue = new object();
      uint createHandle = PLLink.GetLink().TableGET_CreateHandle("Task", 0, 0, 0U);
      PLLink.GetLink().TableGET_AddFilter(createHandle, "TaskStatus", "EQ", "0", 1);
      while (PLLink.GetLink().TableGET_GetNextRecord(createHandle) == 0)
      {
        PLLink.GetLink().TableGET_RecordField_ValueString(createHandle, "TaskNickName", "", ref szValue);
        string str1 = szValue.ToString().ToUpper().Trim();
        int recordFieldValueI32 = PLLink.GetLink().TableGET_RecordField_ValueI32(createHandle, "TaskID");
        PLTask.AddMapNNtoID(str1, recordFieldValueI32);
        PLTask.AddMapIDtoNN(recordFieldValueI32, str1);
        PLTask.AddNicknameToList(str1);
        PLLink.GetLink().TableGET_RecordField_ValueString(createHandle, "TaskQuickBooksID", "", ref szValue);
        string str2 = szValue.ToString().ToUpper().Trim();
        if (!str2.Equals(""))
          PLTask.AddMapPLIDtoQBID(recordFieldValueI32, str2);
      }
      PLLink.GetLink().TableGET_CloseHandle(createHandle);
      num = 0U;
      PLTask.bRead = true;
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
      this.GetLink().TablePOST_Send(this.m_hndPOST, ref nProcessed, ref nExceptions);
      while (this.GetLink().TablePOST_GetNextResult(this.m_hndPOST, ref vunIDCreated, ref nExceptionError, ref szExceptionErrorMsg, ref szExceptionSentData) == 0)
      {
        if (Convert.ToInt32(nExceptionError) <= 0)
        {
          int int32 = Convert.ToInt32(vunIDCreated);
          this.GetLink().TablePOST_ResultDataField_String(this.m_hndPOST, this.m_NickName.sLinkName, szDefault, ref szValue);
          PLTask.AddMapIDtoNN(int32, szValue.ToString().ToUpper());
          PLTask.AddMapNNtoID(szValue.ToString().ToUpper(), int32);
          this.GetLink().TablePOST_ResultDataField_String(this.m_hndPOST, this.m_ExternalID_1.sLinkName, szDefault, ref szValue);
          if (!szValue.ToString().Equals(""))
            PLTask.AddMapExtID1toPLID(szValue.ToString(), Convert.ToInt32(vunIDCreated));
          this.GetLink().TablePOST_ResultDataField_String(this.m_hndPOST, this.m_ExternalID_2.sLinkName, szDefault, ref szValue);
          if (!szValue.ToString().Equals(""))
            PLTask.AddMapExtID2toPLID(szValue.ToString(), Convert.ToInt32(vunIDCreated));
          this.GetLink().TablePOST_ResultDataField_String(this.m_hndPOST, "TaskQuickBooksID", szDefault, ref szValue);
          PLTask.AddMapPLIDtoQBID(Convert.ToInt32(vunIDCreated), szValue.ToString());
        }
      }
      short int16_1 = Convert.ToInt16(nProcessed);
      short int16_2 = Convert.ToInt16(nExceptions);
      PLXMLData.m_lErrorCount += (long) int16_2;
      if (((int) int16_2 > 0 ? 1 : (this.m_lCounter != (int) int16_1 ? 1 : 0)) != 0)
        this.GetLink().TablePOST_DumpExceptionsToLinkLog(this.m_hndPOST);
      this.GetLink().TablePOST_Reset(this.m_hndPOST);
      this.m_lCounter = 0;
    }

    public enum eCATEGORY : short
    {
      BILLABLE = 1,
      WRITE_UP_DOWN = 1000,
      NON_BILLABLE = 2000,
    }
  }
}
