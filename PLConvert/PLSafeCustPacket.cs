// Decompiled with JetBrains decompiler
// Type: PLConvert.PLSafeCustPacket
// Assembly: PLConvert, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DC1F0050-AC43-49A6-B4BD-95C619E8FF70
// Assembly location: C:\Users\haddocdx\Desktop\Conv DLLs\PLConvert.dll

using System;
using System.Collections.Generic;

namespace PLConvert
{
  public class PLSafeCustPacket : StaticData
  {
    private static Dictionary<string, int> m_MapNNtoID = new Dictionary<string, int>();
    private static Dictionary<int, string> m_MapIDtoNN = new Dictionary<int, string>();
    private static Dictionary<string, int> m_MapExtID1toPLID = new Dictionary<string, int>();
    private static Dictionary<string, int> m_MapExtID2toPLID = new Dictionary<string, int>();
    private static bool bRead = false;
    private CPostItem m_CreationDate;
    private CPostItem m_CreationTime;
    private CPostItem m_ModifiedDate;
    private CPostItem m_ModifiedTime;
    private CPostItem m_LocationID;
    private CPostItem m_Flags;
    private CPostItem m_TerminationDate;
    private CPostItem m_Description;
    private CPostItem m_Notes;

    public int CreationDate
    {
      get
      {
        return this.m_CreationDate.nValue;
      }
      set
      {
        this.m_CreationDate.SetValue(value);
      }
    }

    public int CreationTime
    {
      get
      {
        return this.m_CreationTime.nValue;
      }
      set
      {
        this.m_CreationTime.SetValue(value);
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

    public int Flags
    {
      get
      {
        return this.m_Flags.nValue;
      }
      set
      {
        this.m_Flags.SetValue(value);
      }
    }

    public int LocationID
    {
      get
      {
        return this.m_LocationID.nValue;
      }
      set
      {
        this.m_LocationID.SetValue(value);
      }
    }

    public int ModifiedDate
    {
      get
      {
        return this.m_ModifiedDate.nValue;
      }
      set
      {
        this.m_ModifiedDate.SetValue(value);
      }
    }

    public int ModifiedTime
    {
      get
      {
        return this.m_ModifiedTime.nValue;
      }
      set
      {
        this.m_ModifiedTime.SetValue(value);
      }
    }

    public string Notes
    {
      get
      {
        return this.m_Notes.sValue;
      }
      set
      {
        this.m_Notes.SetValue(value);
      }
    }

    public int TerminationDate
    {
      get
      {
        return this.m_TerminationDate.nValue;
      }
      set
      {
        this.m_TerminationDate.SetValue(value);
      }
    }

    public PLSafeCustPacket()
    {
      this.Initialize();
    }

    public static void AddMapExtID1toPLID(string Key, int Value)
    {
      if ((Key.Equals("") ? 0 : (!PLSafeCustPacket.m_MapExtID1toPLID.ContainsKey(Key) ? 1 : 0)) == 0)
        return;
      PLSafeCustPacket.m_MapExtID1toPLID.Add(Key, Value);
    }

    public static void AddMapExtID2toPLID(string Key, int Value)
    {
      if ((Key.Equals("") ? 0 : (!PLSafeCustPacket.m_MapExtID2toPLID.ContainsKey(Key) ? 1 : 0)) == 0)
        return;
      PLSafeCustPacket.m_MapExtID2toPLID.Add(Key, Value);
    }

    public static void AddMapIDtoNN(int Key, string Value)
    {
      if ((Key.Equals(0) ? 0 : (!PLSafeCustPacket.m_MapIDtoNN.ContainsKey(Key) ? 1 : 0)) == 0)
        return;
      PLSafeCustPacket.m_MapIDtoNN.Add(Key, Value);
    }

    public static void AddMapNNtoID(string Key, int Value)
    {
      Key = Key.ToUpper();
      if ((Key.Equals("") ? 0 : (!PLSafeCustPacket.m_MapNNtoID.ContainsKey(Key) ? 1 : 0)) == 0)
        return;
      PLSafeCustPacket.m_MapNNtoID.Add(Key, Value);
    }

    public override void AddRecord()
    {
      if ((int) this.m_hndPOST == 0)
        this.m_hndPOST = this.GetLink().TablePOST_CreateHandle(this.m_sTableName, 0);
      if (!this.m_NickName.m_bIsSet)
        this.NickName = this.MakeNN(true);
      else if ((this.m_ID.m_bIsSet && this.m_ID.nValue.Equals(0) || !this.m_ID.m_bIsSet) && PLSafeCustPacket.GetIDFromNN(this.NickName) > 0)
        this.NickName = this.MakeNN(true);
      else if ((this.NickName.Length.Equals(0) ? 1 : (this.NickName.Length > 15 ? 1 : 0)) != 0)
        this.NickName = this.MakeNN(true);
      base.AddRecord();
      this.GetLink().TablePOST_AddRecord(this.m_hndPOST);
      PLSafeCustPacket plSafeCustPacket = this;
      plSafeCustPacket.m_lCounter = plSafeCustPacket.m_lCounter + 1;
      if (this.m_lCounter < PLXMLData.m_nMaxCounter)
        return;
      this.Send();
    }

    public static void ClearMapExtID1toPLID()
    {
      if (PLSafeCustPacket.m_MapExtID1toPLID == null)
        return;
      PLSafeCustPacket.m_MapExtID1toPLID.Clear();
      PLSafeCustPacket.m_MapExtID1toPLID = (Dictionary<string, int>) null;
    }

    public static void ClearMapExtID2toPLID()
    {
      if (PLSafeCustPacket.m_MapExtID2toPLID == null)
        return;
      PLSafeCustPacket.m_MapExtID2toPLID.Clear();
      PLSafeCustPacket.m_MapExtID2toPLID = (Dictionary<string, int>) null;
    }

    public static void ClearMapIDtoNN()
    {
      if (PLSafeCustPacket.m_MapIDtoNN == null)
        return;
      PLSafeCustPacket.m_MapIDtoNN.Clear();
      PLSafeCustPacket.m_MapIDtoNN = (Dictionary<int, string>) null;
    }

    public static void ClearMapNNtoID()
    {
      if (PLSafeCustPacket.m_MapNNtoID == null)
        return;
      PLSafeCustPacket.m_MapNNtoID.Clear();
      PLSafeCustPacket.m_MapNNtoID = (Dictionary<string, int>) null;
    }

    public static int GetIDFromExtID1(string Key)
    {
      return PLSafeCustPacket.m_MapExtID1toPLID.ContainsKey(Key) ? Convert.ToInt32(PLSafeCustPacket.m_MapExtID1toPLID[Key]) : 0;
    }

    public static int GetIDFromExtID2(string Key)
    {
      return PLSafeCustPacket.m_MapExtID2toPLID.ContainsKey(Key) ? Convert.ToInt32(PLSafeCustPacket.m_MapExtID2toPLID[Key]) : 0;
    }

    public static int GetIDFromNN(string Key)
    {
      if (!PLSafeCustPacket.bRead)
        PLSafeCustPacket.ReadTable();
      Key = Key.ToUpper();
      return PLSafeCustPacket.m_MapNNtoID.ContainsKey(Key) ? Convert.ToInt32(PLSafeCustPacket.m_MapNNtoID[Key]) : 0;
    }

    public static string GetNNFromID(int nID)
    {
      if (!PLSafeCustPacket.bRead)
        PLSafeCustPacket.ReadTable();
      return PLSafeCustPacket.m_MapIDtoNN.ContainsKey(nID) ? PLSafeCustPacket.m_MapIDtoNN[nID].ToString() : "";
    }

    protected override void Initialize()
    {
      this.m_lCounter = 0;
      this.m_sTableName = "SafeCustPacket";
      this.m_hndPOST = 0U;
      this.m_hndGET = 0U;
      this.m_hndExisting = 0U;
      List<CPostItem> postItems1 = this.PostItems;
      CPostItem cpostItem1 = new CPostItem(CPostItem.DataType.LONG, "SCPacketStatus");
      CPostItem cpostItem2 = cpostItem1;
      this.m_Status = cpostItem1;
      postItems1.Add(cpostItem2);
      List<CPostItem> postItems2 = this.PostItems;
      CPostItem cpostItem3 = new CPostItem(CPostItem.DataType.LONG, "SCPacketID");
      CPostItem cpostItem4 = cpostItem3;
      this.m_ID = cpostItem3;
      postItems2.Add(cpostItem4);
      List<CPostItem> postItems3 = this.PostItems;
      CPostItem cpostItem5 = new CPostItem(CPostItem.DataType.LONG, "SCPacketCreateDate");
      CPostItem cpostItem6 = cpostItem5;
      this.m_CreationDate = cpostItem5;
      postItems3.Add(cpostItem6);
      List<CPostItem> postItems4 = this.PostItems;
      CPostItem cpostItem7 = new CPostItem(CPostItem.DataType.LONG, "SCPacketCreateTime");
      CPostItem cpostItem8 = cpostItem7;
      this.m_CreationTime = cpostItem7;
      postItems4.Add(cpostItem8);
      List<CPostItem> postItems5 = this.PostItems;
      CPostItem cpostItem9 = new CPostItem(CPostItem.DataType.LONG, "SCPacketLastModDate");
      CPostItem cpostItem10 = cpostItem9;
      this.m_ModifiedDate = cpostItem9;
      postItems5.Add(cpostItem10);
      List<CPostItem> postItems6 = this.PostItems;
      CPostItem cpostItem11 = new CPostItem(CPostItem.DataType.LONG, "SCPacketLastModTime");
      CPostItem cpostItem12 = cpostItem11;
      this.m_ModifiedTime = cpostItem11;
      postItems6.Add(cpostItem12);
      List<CPostItem> postItems7 = this.PostItems;
      CPostItem cpostItem13 = new CPostItem(CPostItem.DataType.LONG, "SCPacketLocationID");
      CPostItem cpostItem14 = cpostItem13;
      this.m_LocationID = cpostItem13;
      postItems7.Add(cpostItem14);
      List<CPostItem> postItems8 = this.PostItems;
      CPostItem cpostItem15 = new CPostItem(CPostItem.DataType.LONG, "SCPacketFlags");
      CPostItem cpostItem16 = cpostItem15;
      this.m_Flags = cpostItem15;
      postItems8.Add(cpostItem16);
      List<CPostItem> postItems9 = this.PostItems;
      CPostItem cpostItem17 = new CPostItem(CPostItem.DataType.LONG, "SCPacketTerminateDate");
      CPostItem cpostItem18 = cpostItem17;
      this.m_TerminationDate = cpostItem17;
      postItems9.Add(cpostItem18);
      List<CPostItem> postItems10 = this.PostItems;
      CPostItem cpostItem19 = new CPostItem(CPostItem.DataType.STRING, "SCPacketName");
      CPostItem cpostItem20 = cpostItem19;
      this.m_NickName = cpostItem19;
      postItems10.Add(cpostItem20);
      List<CPostItem> postItems11 = this.PostItems;
      CPostItem cpostItem21 = new CPostItem(CPostItem.DataType.STRING, "SCPacketDescription");
      CPostItem cpostItem22 = cpostItem21;
      this.m_Description = cpostItem21;
      postItems11.Add(cpostItem22);
      List<CPostItem> postItems12 = this.PostItems;
      CPostItem cpostItem23 = new CPostItem(CPostItem.DataType.STRING, "SCPacketNotes");
      CPostItem cpostItem24 = cpostItem23;
      this.m_Notes = cpostItem23;
      postItems12.Add(cpostItem24);
      List<CPostItem> postItems13 = this.PostItems;
      CPostItem cpostItem25 = new CPostItem(CPostItem.DataType.STRING, "SCPacketQuickBooksID");
      CPostItem cpostItem26 = cpostItem25;
      this.m_QuickBooksID = cpostItem25;
      postItems13.Add(cpostItem26);
      List<CPostItem> postItems14 = this.PostItems;
      CPostItem cpostItem27 = new CPostItem(CPostItem.DataType.STRING, "ExternalID_1");
      CPostItem cpostItem28 = cpostItem27;
      this.m_ExternalID_1 = cpostItem27;
      postItems14.Add(cpostItem28);
      List<CPostItem> postItems15 = this.PostItems;
      CPostItem cpostItem29 = new CPostItem(CPostItem.DataType.STRING, "ExternalID_2");
      CPostItem cpostItem30 = cpostItem29;
      this.m_ExternalID_2 = cpostItem29;
      postItems15.Add(cpostItem30);
    }

    public override string MakeNN(bool bSetNickName)
    {
      if (!PLSafeCustPacket.bRead)
        PLSafeCustPacket.ReadTable();
      string str = this.MakeListNN(this.Description, StaticData.m_NNs, (short) 15);
      if (bSetNickName)
        this.NickName = str;
      return str;
    }

    private static void ReadTable()
    {
      if (PLSafeCustPacket.bRead)
        return;
      uint num = 0;
      object szValue = new object();
      uint createHandle = PLLink.GetLink().TableGET_CreateHandle("SafeCustPacket", 0, 0, 0U);
      PLLink.GetLink().TableGET_AddFilter(createHandle, "SCPacketStatus", "EQ", "0", 1);
      while (PLLink.GetLink().TableGET_GetNextRecord(createHandle) == 0)
      {
        PLLink.GetLink().TableGET_RecordField_ValueString(createHandle, "SCPacketName", "", ref szValue);
        string Key = szValue.ToString().ToUpper().Trim();
        int recordFieldValueI32 = PLLink.GetLink().TableGET_RecordField_ValueI32(createHandle, "SCPacketID");
        PLSafeCustPacket.AddMapNNtoID(Key, recordFieldValueI32);
        PLSafeCustPacket.AddMapIDtoNN(recordFieldValueI32, Key);
      }
      PLLink.GetLink().TableGET_CloseHandle(createHandle);
      num = 0U;
      PLSafeCustPacket.bRead = true;
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
      short int16_1 = Convert.ToInt16(nProcessed);
      short int16_2 = Convert.ToInt16(nExceptions);
      PLXMLData.m_lErrorCount += (long) int16_2;
      if (((int) int16_2 > 0 ? 1 : (this.m_lCounter != (int) int16_1 ? 1 : 0)) != 0)
      {
        this.GetLink().TablePOST_DumpExceptionsToLinkLog(this.m_hndPOST);
        PLSafeCustPacket plSafeCustPacket = this;
        plSafeCustPacket.m_lSendErrorCount = plSafeCustPacket.m_lSendErrorCount + 1L;
      }
      while (this.GetLink().TablePOST_GetNextResult(this.m_hndPOST, ref vunIDCreated, ref nExceptionError, ref szExceptionErrorMsg, ref szExceptionSentData) == 0)
      {
        if (Convert.ToInt32(nExceptionError) <= 0)
        {
          int int32 = Convert.ToInt32(vunIDCreated);
          this.GetLink().TablePOST_ResultDataField_String(this.m_hndPOST, this.m_NickName.sLinkName, szDefault, ref szValue);
          PLSafeCustPacket.AddMapIDtoNN(int32, szValue.ToString().ToUpper());
          PLSafeCustPacket.AddMapNNtoID(szValue.ToString().ToUpper(), int32);
          this.GetLink().TablePOST_ResultDataField_String(this.m_hndPOST, this.m_ExternalID_1.sLinkName, szDefault, ref szValue);
          if (!szValue.ToString().Equals(""))
            PLSafeCustPacket.AddMapExtID1toPLID(szValue.ToString(), int32);
          this.GetLink().TablePOST_ResultDataField_String(this.m_hndPOST, this.m_ExternalID_2.sLinkName, szDefault, ref szValue);
          if (!szValue.ToString().Equals(""))
            PLSafeCustPacket.AddMapExtID2toPLID(szValue.ToString(), int32);
        }
      }
      this.GetLink().TablePOST_Reset(this.m_hndPOST);
      this.m_lCounter = 0;
    }
  }
}
