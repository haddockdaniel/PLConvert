// Decompiled with JetBrains decompiler
// Type: PLConvert.PLCustomTab
// Assembly: PLConvert, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DC1F0050-AC43-49A6-B4BD-95C619E8FF70
// Assembly location: C:\Users\haddocdx\Desktop\Conv DLLs\PLConvert.dll

using System;
using System.Collections;
using System.Reflection;

namespace PLConvert
{
  public class PLCustomTab : StaticData
  {
    private static bool bRead = false;
    private CPostItem m_Flags;
    private CPostItem m_Flags2;
    private CPostItem m_TabType;
    private CPostItem m_Template;
    private CPostItem m_Description;
    private CPostItem m_XMLName;
    private CPostItem m_TypeOfLawID;
    private CPostItem m_IsElecBilling;
    private CPostItem m_HasRequiredFields;
    private CPostItem m_ShowbyDefaultLawtype;
    private CPostItem m_MustShowLawtype;
    private CPostItem m_IsOriginalCustomTab;
    private CPostItem m_ShowForMatter;
    private CPostItem m_ShowForClient;
    private CPostItem m_ShowForContact;
    private CPostItem m_ShowForVendor;
    private CPostItem m_FieldID;
    private CPostItem m_FieldStatus;
    private CPostItem m_FieldOrder;
    private CPostItem m_FieldRequired;
    private CPostItem m_FieldLabel;
    private CPostItem m_FieldToolTip;
    private CPostItem m_FieldType;
    private CPostItem m_FieldLen;
    private CPostItem m_FieldRangeMin;
    private CPostItem m_FieldRangeMax;
    private ArrayList m_FieldIDArr;
    private ArrayList m_FieldStatusArr;
    private ArrayList m_FieldOrderArr;
    private ArrayList m_FieldRequiredArr;
    private ArrayList m_FieldLabelArr;
    private ArrayList m_FieldToolTipArr;
    private ArrayList m_FieldTypeArr;
    private ArrayList m_FieldLenArr;
    private ArrayList m_FieldRangeMinArr;
    private ArrayList m_FieldRangeMaxArr;
    private static int m_nNN;
    private static Hashtable m_MapNNtoID;
    private static Hashtable m_MapIDtoNN;
    private static Hashtable m_MapExtID1toPLID;
    private static Hashtable m_MapExtID2toPLID;

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

    public int Flags2
    {
      get
      {
        return this.m_Flags2.nValue;
      }
      set
      {
        this.m_Flags2.SetValue(value);
      }
    }

    public bool HasRequiredFields
    {
      get
      {
        return this.m_HasRequiredFields.bValue;
      }
      set
      {
        this.m_HasRequiredFields.SetValue(value);
      }
    }

    public bool IsElecBilling
    {
      get
      {
        return this.m_IsElecBilling.bValue;
      }
      set
      {
        this.m_IsElecBilling.SetValue(value);
      }
    }

    public bool IsOriginalCustomTab
    {
      get
      {
        return this.m_IsOriginalCustomTab.bValue;
      }
      set
      {
        this.m_IsOriginalCustomTab.SetValue(value);
      }
    }

    public bool MustShowLawtype
    {
      get
      {
        return this.m_MustShowLawtype.bValue;
      }
      set
      {
        this.m_MustShowLawtype.SetValue(value);
      }
    }

    public bool ShowbyDefaultLawtype
    {
      get
      {
        return this.m_ShowbyDefaultLawtype.bValue;
      }
      set
      {
        this.m_ShowbyDefaultLawtype.SetValue(value);
      }
    }

    public bool ShowForClient
    {
      get
      {
        return this.m_ShowForClient.bValue;
      }
      set
      {
        this.m_ShowForClient.SetValue(value);
      }
    }

    public bool ShowForContact
    {
      get
      {
        return this.m_ShowForContact.bValue;
      }
      set
      {
        this.m_ShowForContact.SetValue(value);
      }
    }

    public bool ShowForMatter
    {
      get
      {
        return this.m_ShowForMatter.bValue;
      }
      set
      {
        this.m_ShowForMatter.SetValue(value);
      }
    }

    public bool ShowForVendor
    {
      get
      {
        return this.m_ShowForVendor.bValue;
      }
      set
      {
        this.m_ShowForVendor.SetValue(value);
      }
    }

    public PLCustomTab.eTabType TabType
    {
      get
      {
        return (PLCustomTab.eTabType) this.m_TabType.nValue;
      }
      set
      {
        this.m_TabType.SetValue((int) value);
      }
    }

    public string Template
    {
      get
      {
        return this.m_Template.sValue;
      }
      set
      {
        this.m_Template.SetValue(value);
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

    public string XMLName
    {
      get
      {
        return this.m_XMLName.sValue;
      }
      set
      {
        this.m_XMLName.SetValue(value);
      }
    }

    public PLCustomTab()
    {
      this.Initialize();
    }

    public void AddCustomTabField(int nFldID, int nFldStatus, int nFldOrder, bool bFldReq, string sFldLabel, string sFldToolTip, int nType, int nFldLen, string sRangeMin, string sRangeMax)
    {
      this.m_FieldIDArr.Add((object) nFldID);
      this.m_FieldStatusArr.Add((object) nFldStatus);
      this.m_FieldOrderArr.Add((object) nFldOrder);
      this.m_FieldRequiredArr.Add((object) bFldReq);
      this.m_FieldLabelArr.Add((object) sFldLabel);
      this.m_FieldToolTipArr.Add((object) sFldToolTip);
      this.m_FieldTypeArr.Add((object) nType);
      this.m_FieldLenArr.Add((object) nFldLen);
      this.m_FieldRangeMinArr.Add((object) sRangeMin);
      this.m_FieldRangeMaxArr.Add((object) sRangeMax);
    }

    public static void AddMapExtID1toPLID(string Key, int Value)
    {
      if ((Key.Equals("") ? 0 : (!Value.Equals(0) ? 1 : 0)) == 0)
        return;
      if (PLCustomTab.m_MapExtID1toPLID == null)
        PLCustomTab.m_MapExtID1toPLID = new Hashtable();
      if (!PLCustomTab.m_MapExtID1toPLID.ContainsKey((object) Key))
        PLCustomTab.m_MapExtID1toPLID.Add((object) Key, (object) Value);
    }

    public static void AddMapExtID2toPLID(string Key, int Value)
    {
      if ((Key.Equals("") ? 0 : (!Value.Equals(0) ? 1 : 0)) == 0)
        return;
      if (PLCustomTab.m_MapExtID2toPLID == null)
        PLCustomTab.m_MapExtID2toPLID = new Hashtable();
      if (!PLCustomTab.m_MapExtID2toPLID.ContainsKey((object) Key))
        PLCustomTab.m_MapExtID2toPLID.Add((object) Key, (object) Value);
    }

    public static void AddMapIDtoNN(int Key, string Value)
    {
      if ((Key.Equals(0) ? 0 : (!Value.Equals("") ? 1 : 0)) == 0)
        return;
      if (PLCustomTab.m_MapIDtoNN == null)
        PLCustomTab.m_MapIDtoNN = new Hashtable();
      if (!PLCustomTab.m_MapIDtoNN.ContainsKey((object) Key))
        PLCustomTab.m_MapIDtoNN.Add((object) Key, (object) Value);
    }

    public static void AddMapNNtoID(string Key, int Value)
    {
      Key = Key.ToUpper();
      if ((Key.Equals("") ? 0 : (!Value.Equals(0) ? 1 : 0)) == 0)
        return;
      if (PLCustomTab.m_MapNNtoID == null)
        PLCustomTab.m_MapNNtoID = new Hashtable();
      if (!PLCustomTab.m_MapNNtoID.ContainsKey((object) Key))
        PLCustomTab.m_MapNNtoID.Add((object) Key, (object) Value);
    }

    public override void AddRecord()
    {
      if ((int) this.m_hndPOST == 0)
        this.m_hndPOST = this.GetLink().TablePOST_CreateHandle(this.m_sTableName, 0);
      if ((!this.m_NickName.m_bIsSet || !this.m_ID.m_bIsSet ? 0 : (this.m_ID.nValue.Equals(0) ? 1 : 0)) != 0 && (PLCustomTab.GetIDFromNN(this.NickName) > 0 || string.IsNullOrEmpty(this.NickName) ? 1 : (this.NickName.Length > 20 ? 1 : 0)) != 0)
      {
        ++PLCustomTab.m_nNN;
        string str = PLCustomTab.m_nNN.ToString();
        while (str.Length < 20)
          str = "0" + str;
        this.NickName = str;
      }
      StaticData.AddNicknameToList(this.NickName);
      this.m_ID.AddField(this.m_hndPOST);
      this.m_Status.AddField(this.m_hndPOST);
      this.m_Flags.AddField(this.m_hndPOST);
      this.m_Flags2.AddField(this.m_hndPOST);
      this.m_TabType.AddField(this.m_hndPOST);
      this.m_Template.AddField(this.m_hndPOST);
      this.m_NickName.AddField(this.m_hndPOST);
      this.m_Description.AddField(this.m_hndPOST);
      this.m_XMLName.AddField(this.m_hndPOST);
      this.m_TypeOfLawID.AddField(this.m_hndPOST);
      this.m_IsElecBilling.AddField(this.m_hndPOST);
      this.m_HasRequiredFields.AddField(this.m_hndPOST);
      this.m_ShowbyDefaultLawtype.AddField(this.m_hndPOST);
      this.m_MustShowLawtype.AddField(this.m_hndPOST);
      this.m_IsOriginalCustomTab.AddField(this.m_hndPOST);
      this.m_ShowForMatter.AddField(this.m_hndPOST);
      this.m_ShowForClient.AddField(this.m_hndPOST);
      this.m_ShowForContact.AddField(this.m_hndPOST);
      this.m_ShowForVendor.AddField(this.m_hndPOST);
      for (short index = 1; (int) index <= this.m_FieldIDArr.Count; ++index)
      {
        this.m_FieldID.SetValue(Convert.ToInt32(this.m_FieldIDArr[(int) index - 1]));
        this.m_FieldID.AddRepeatField(this.m_hndPOST, (int) index);
        this.m_FieldStatus.SetValue(Convert.ToInt32(this.m_FieldStatusArr[(int) index - 1]));
        this.m_FieldStatus.AddRepeatField(this.m_hndPOST, (int) index);
        this.m_FieldOrder.SetValue(Convert.ToInt32(this.m_FieldOrderArr[(int) index - 1]));
        this.m_FieldOrder.AddRepeatField(this.m_hndPOST, (int) index);
        this.m_FieldRequired.SetValue(Convert.ToBoolean(this.m_FieldRequiredArr[(int) index - 1]));
        this.m_FieldRequired.AddRepeatField(this.m_hndPOST, (int) index);
        this.m_FieldLabel.SetValue(Convert.ToString(this.m_FieldLabelArr[(int) index - 1]));
        this.m_FieldLabel.AddRepeatField(this.m_hndPOST, (int) index);
        this.m_FieldToolTip.SetValue(Convert.ToString(this.m_FieldToolTipArr[(int) index - 1]));
        this.m_FieldToolTip.AddRepeatField(this.m_hndPOST, (int) index);
        this.m_FieldType.SetValue(Convert.ToInt32(this.m_FieldTypeArr[(int) index - 1]));
        this.m_FieldType.AddRepeatField(this.m_hndPOST, (int) index);
        this.m_FieldLen.SetValue(Convert.ToInt32(this.m_FieldLenArr[(int) index - 1]));
        this.m_FieldLen.AddRepeatField(this.m_hndPOST, (int) index);
        this.m_FieldRangeMin.SetValue(Convert.ToString(this.m_FieldRangeMinArr[(int) index - 1]));
        this.m_FieldRangeMin.AddRepeatField(this.m_hndPOST, (int) index);
        this.m_FieldRangeMax.SetValue(Convert.ToString(this.m_FieldRangeMaxArr[(int) index - 1]));
        this.m_FieldRangeMax.AddRepeatField(this.m_hndPOST, (int) index);
      }
      this.m_FieldIDArr.Clear();
      while (this.m_FieldIDArr.Count > 0)
        this.m_FieldIDArr.RemoveAt(0);
      this.m_FieldStatusArr.Clear();
      while (this.m_FieldStatusArr.Count > 0)
        this.m_FieldStatusArr.RemoveAt(0);
      this.m_FieldOrderArr.Clear();
      while (this.m_FieldOrderArr.Count > 0)
        this.m_FieldOrderArr.RemoveAt(0);
      this.m_FieldRequiredArr.Clear();
      while (this.m_FieldRequiredArr.Count > 0)
        this.m_FieldRequiredArr.RemoveAt(0);
      this.m_FieldLabelArr.Clear();
      while (this.m_FieldLabelArr.Count > 0)
        this.m_FieldLabelArr.RemoveAt(0);
      this.m_FieldToolTipArr.Clear();
      while (this.m_FieldToolTipArr.Count > 0)
        this.m_FieldToolTipArr.RemoveAt(0);
      this.m_FieldTypeArr.Clear();
      while (this.m_FieldTypeArr.Count > 0)
        this.m_FieldTypeArr.RemoveAt(0);
      this.m_FieldLenArr.Clear();
      while (this.m_FieldLenArr.Count > 0)
        this.m_FieldLenArr.RemoveAt(0);
      this.m_FieldRangeMinArr.Clear();
      while (this.m_FieldRangeMinArr.Count > 0)
        this.m_FieldRangeMinArr.RemoveAt(0);
      this.m_FieldRangeMaxArr.Clear();
      while (this.m_FieldRangeMaxArr.Count > 0)
        this.m_FieldRangeMaxArr.RemoveAt(0);
      this.m_ExternalID_1.AddField(this.m_hndPOST);
      this.m_ExternalID_2.AddField(this.m_hndPOST);
      this.GetLink().TablePOST_AddRecord(this.m_hndPOST);
      PLCustomTab plCustomTab = this;
      plCustomTab.m_lCounter = plCustomTab.m_lCounter + 1;
      if (this.m_lCounter < PLXMLData.m_nMaxCounter)
        return;
      this.Send();
    }

    public override void Clear()
    {
      this.m_ID.Clear();
      this.m_Status.Clear();
      this.m_Flags.Clear();
      this.m_Flags2.Clear();
      this.m_TabType.Clear();
      this.m_Template.Clear();
      this.m_NickName.Clear();
      this.m_Description.Clear();
      this.m_XMLName.Clear();
      this.m_TypeOfLawID.Clear();
      this.m_IsElecBilling.Clear();
      this.m_HasRequiredFields.Clear();
      this.m_ShowbyDefaultLawtype.Clear();
      this.m_MustShowLawtype.Clear();
      this.m_IsOriginalCustomTab.Clear();
      this.m_ShowForMatter.Clear();
      this.m_ShowForClient.Clear();
      this.m_ShowForContact.Clear();
      this.m_ShowForVendor.Clear();
      this.m_FieldIDArr.Clear();
      while (this.m_FieldIDArr.Count > 0)
        this.m_FieldIDArr.RemoveAt(0);
      this.m_FieldStatusArr.Clear();
      while (this.m_FieldStatusArr.Count > 0)
        this.m_FieldStatusArr.RemoveAt(0);
      this.m_FieldOrderArr.Clear();
      while (this.m_FieldOrderArr.Count > 0)
        this.m_FieldOrderArr.RemoveAt(0);
      this.m_FieldRequiredArr.Clear();
      while (this.m_FieldRequiredArr.Count > 0)
        this.m_FieldRequiredArr.RemoveAt(0);
      this.m_FieldLabelArr.Clear();
      while (this.m_FieldLabelArr.Count > 0)
        this.m_FieldLabelArr.RemoveAt(0);
      this.m_FieldToolTipArr.Clear();
      while (this.m_FieldToolTipArr.Count > 0)
        this.m_FieldToolTipArr.RemoveAt(0);
      this.m_FieldTypeArr.Clear();
      while (this.m_FieldTypeArr.Count > 0)
        this.m_FieldTypeArr.RemoveAt(0);
      this.m_FieldLenArr.Clear();
      while (this.m_FieldLenArr.Count > 0)
        this.m_FieldLenArr.RemoveAt(0);
      this.m_FieldRangeMinArr.Clear();
      while (this.m_FieldRangeMinArr.Count > 0)
        this.m_FieldRangeMinArr.RemoveAt(0);
      this.m_FieldRangeMaxArr.Clear();
      while (this.m_FieldRangeMaxArr.Count > 0)
        this.m_FieldRangeMaxArr.RemoveAt(0);
    }

    public static void ClearMapExtID1toPLID()
    {
      if (PLCustomTab.m_MapExtID1toPLID == null)
        return;
      PLCustomTab.m_MapExtID1toPLID.Clear();
      PLCustomTab.m_MapExtID1toPLID = (Hashtable) null;
    }

    public static void ClearMapExtID2toPLID()
    {
      if (PLCustomTab.m_MapExtID2toPLID == null)
        return;
      PLCustomTab.m_MapExtID2toPLID.Clear();
      PLCustomTab.m_MapExtID2toPLID = (Hashtable) null;
    }

    public static void ClearMapIDtoNN()
    {
      if (PLCustomTab.m_MapIDtoNN == null)
        return;
      PLCustomTab.m_MapIDtoNN.Clear();
      PLCustomTab.m_MapIDtoNN = (Hashtable) null;
    }

    public static void ClearMapNNtoID()
    {
      if (PLCustomTab.m_MapNNtoID == null)
        return;
      PLCustomTab.m_MapNNtoID.Clear();
      PLCustomTab.m_MapNNtoID = (Hashtable) null;
    }

    public override void GetExistingRecord()
    {
      this.Clear();
      this.m_ID.GetField(this.m_hndExisting);
      this.m_Status.GetField(this.m_hndExisting);
      this.m_Flags.GetField(this.m_hndExisting);
      this.m_Flags2.GetField(this.m_hndExisting);
      this.m_TabType.GetField(this.m_hndExisting);
      this.m_Template.GetField(this.m_hndExisting);
      this.m_NickName.GetField(this.m_hndExisting);
      this.m_Description.GetField(this.m_hndExisting);
      this.m_XMLName.GetField(this.m_hndExisting);
      this.m_TypeOfLawID.GetField(this.m_hndExisting);
      this.m_IsElecBilling.GetField(this.m_hndExisting);
      this.m_HasRequiredFields.GetField(this.m_hndExisting);
      this.m_ShowbyDefaultLawtype.GetField(this.m_hndExisting);
      this.m_MustShowLawtype.GetField(this.m_hndExisting);
      this.m_IsOriginalCustomTab.GetField(this.m_hndExisting);
      this.m_ShowForMatter.GetField(this.m_hndExisting);
      this.m_ShowForClient.GetField(this.m_hndExisting);
      this.m_ShowForContact.GetField(this.m_hndExisting);
      this.m_ShowForVendor.GetField(this.m_hndExisting);
      this.m_ExternalID_1.GetField(this.m_hndExisting);
      this.m_ExternalID_2.GetField(this.m_hndExisting);
      int recurringFieldCount = this.GetLink().TableGET_RecordRecurringField_Count(this.m_hndExisting, "CustomTabFieldID");
      for (int nRepeat = 0; nRepeat < recurringFieldCount; ++nRepeat)
      {
        this.m_FieldID.GetRepeatField(this.m_hndExisting, nRepeat);
        this.m_FieldStatus.GetRepeatField(this.m_hndExisting, nRepeat);
        this.m_FieldOrder.GetRepeatField(this.m_hndExisting, nRepeat);
        this.m_FieldRequired.GetRepeatField(this.m_hndExisting, nRepeat);
        this.m_FieldLabel.GetRepeatField(this.m_hndExisting, nRepeat);
        this.m_FieldToolTip.GetRepeatField(this.m_hndExisting, nRepeat);
        this.m_FieldType.GetRepeatField(this.m_hndExisting, nRepeat);
        this.m_FieldLen.GetRepeatField(this.m_hndExisting, nRepeat);
        this.m_FieldRangeMin.GetRepeatField(this.m_hndExisting, nRepeat);
        this.m_FieldRangeMax.GetRepeatField(this.m_hndExisting, nRepeat);
        this.AddCustomTabField(this.m_FieldID.nValue, this.m_FieldStatus.nValue, this.m_FieldOrder.nValue, this.m_FieldRequired.bValue, this.m_FieldLabel.sValue, this.m_FieldToolTip.sValue, this.m_FieldType.nValue, this.m_FieldLen.nValue, this.m_FieldRangeMin.sValue, this.m_FieldRangeMax.sValue);
      }
    }

    public static int GetIDFromExtID1(string Key)
    {
      return !Key.Equals("") ? (PLCustomTab.m_MapExtID1toPLID == null ? 0 : (PLCustomTab.m_MapExtID1toPLID.ContainsKey((object) Key) ? Convert.ToInt32(PLCustomTab.m_MapExtID1toPLID[(object) Key]) : 0)) : 0;
    }

    public static int GetIDFromExtID2(string Key)
    {
      return !Key.Equals("") ? (PLCustomTab.m_MapExtID2toPLID == null ? 0 : (PLCustomTab.m_MapExtID2toPLID.ContainsKey((object) Key) ? Convert.ToInt32(PLCustomTab.m_MapExtID2toPLID[(object) Key]) : 0)) : 0;
    }

    public static int GetIDFromNN(string Key)
    {
      Key = Key.ToUpper();
      int num;
      if (!Key.Equals(""))
      {
        if (!PLCustomTab.bRead)
          PLCustomTab.ReadTable();
        num = PLCustomTab.m_MapNNtoID == null ? 0 : (PLCustomTab.m_MapNNtoID.ContainsKey((object) Key) ? Convert.ToInt32(PLCustomTab.m_MapNNtoID[(object) Key]) : 0);
      }
      else
        num = 0;
      return num;
    }

    public static string GetNNFromID(int nID)
    {
      string str;
      if (!nID.Equals(0))
      {
        if (!PLCustomTab.bRead)
          PLCustomTab.ReadTable();
        str = PLCustomTab.m_MapIDtoNN == null ? "" : (PLCustomTab.m_MapIDtoNN.ContainsKey((object) nID) ? PLCustomTab.m_MapIDtoNN[(object) nID].ToString() : "");
      }
      else
        str = "";
      return str;
    }

    public override void GetRecord()
    {
      this.Clear();
      if ((int) this.m_hndGET == 0)
        this.m_hndGET = this.GetLink().TableGET_CreateHandle(this.m_sTableName, 0, 0, 0U);
      this.m_ID.GetField(this.m_hndGET);
      this.m_Status.GetField(this.m_hndGET);
      this.m_Flags.GetField(this.m_hndGET);
      this.m_Flags2.GetField(this.m_hndGET);
      this.m_TabType.GetField(this.m_hndGET);
      this.m_Template.GetField(this.m_hndGET);
      this.m_NickName.GetField(this.m_hndGET);
      this.m_Description.GetField(this.m_hndGET);
      this.m_XMLName.GetField(this.m_hndGET);
      this.m_TypeOfLawID.GetField(this.m_hndGET);
      this.m_IsElecBilling.GetField(this.m_hndGET);
      this.m_HasRequiredFields.GetField(this.m_hndGET);
      this.m_ShowbyDefaultLawtype.GetField(this.m_hndGET);
      this.m_MustShowLawtype.GetField(this.m_hndGET);
      this.m_IsOriginalCustomTab.GetField(this.m_hndGET);
      this.m_ShowForMatter.GetField(this.m_hndGET);
      this.m_ShowForClient.GetField(this.m_hndGET);
      this.m_ShowForContact.GetField(this.m_hndGET);
      this.m_ShowForVendor.GetField(this.m_hndGET);
      int recurringFieldCount = this.GetLink().TableGET_RecordRecurringField_Count(this.m_hndGET, "CustomTabFieldID");
      for (int nRepeat = 1; nRepeat <= recurringFieldCount; ++nRepeat)
      {
        this.m_FieldID.GetRepeatField(this.m_hndGET, nRepeat);
        this.m_FieldIDArr.Add((object) this.m_FieldID.nValue);
        this.m_FieldID.Clear();
        this.m_FieldStatus.GetRepeatField(this.m_hndGET, nRepeat);
        this.m_FieldStatusArr.Add((object) this.m_FieldStatus.nValue);
        this.m_FieldStatus.Clear();
        this.m_FieldOrder.GetRepeatField(this.m_hndGET, nRepeat);
        this.m_FieldOrderArr.Add((object) this.m_FieldOrder.nValue);
        this.m_FieldOrder.Clear();
        this.m_FieldRequired.GetRepeatField(this.m_hndGET, nRepeat);
        this.m_FieldRequiredArr.Add((object) this.m_FieldRequired.bValue);
        this.m_FieldRequired.Clear();
        this.m_FieldLabel.GetRepeatField(this.m_hndGET, nRepeat);
        this.m_FieldLabelArr.Add((object) this.m_FieldLabel.sValue);
        this.m_FieldLabel.Clear();
        this.m_FieldToolTip.GetRepeatField(this.m_hndGET, nRepeat);
        this.m_FieldToolTipArr.Add((object) this.m_FieldToolTip.sValue);
        this.m_FieldToolTip.Clear();
        this.m_FieldType.GetRepeatField(this.m_hndGET, nRepeat);
        this.m_FieldTypeArr.Add((object) this.m_FieldType.nValue);
        this.m_FieldType.Clear();
        this.m_FieldLen.GetRepeatField(this.m_hndGET, nRepeat);
        this.m_FieldLenArr.Add((object) this.m_FieldLen.nValue);
        this.m_FieldLen.Clear();
        this.m_FieldRangeMin.GetRepeatField(this.m_hndGET, nRepeat);
        this.m_FieldRangeMinArr.Add((object) this.m_FieldRangeMin.sValue);
        this.m_FieldRangeMin.Clear();
        this.m_FieldRangeMax.GetRepeatField(this.m_hndGET, nRepeat);
        this.m_FieldRangeMaxArr.Add((object) this.m_FieldRangeMax.sValue);
        this.m_FieldRangeMax.Clear();
      }
    }

    protected override void Initialize()
    {
      this.m_lCounter = 0;
      this.m_sTableName = "CustomTab";
      this.m_hndPOST = 0U;
      this.m_hndGET = 0U;
      this.m_hndExisting = 0U;
      this.m_ID = new CPostItem(CPostItem.DataType.LONG, "CustomTabID");
      this.m_Status = new CPostItem(CPostItem.DataType.LONG, "CustomTabStatus");
      this.m_Flags = new CPostItem(CPostItem.DataType.LONG, "CustomTabFlags");
      this.m_Flags2 = new CPostItem(CPostItem.DataType.LONG, "CustomTabFlags2");
      this.m_TabType = new CPostItem(CPostItem.DataType.LONG, "CustomTabEntryType");
      this.m_Template = new CPostItem(CPostItem.DataType.STRING, "CustomTabTemplate");
      this.m_NickName = new CPostItem(CPostItem.DataType.STRING, "CustomTabName");
      this.m_Description = new CPostItem(CPostItem.DataType.STRING, "CustomTabDescription");
      this.m_XMLName = new CPostItem(CPostItem.DataType.STRING, "CustomTabXMLName");
      this.m_TypeOfLawID = new CPostItem(CPostItem.DataType.LONG, "TypeOfLaw");
      this.m_IsElecBilling = new CPostItem(CPostItem.DataType.BOOL, "CustomTabIsElecBilling");
      this.m_HasRequiredFields = new CPostItem(CPostItem.DataType.BOOL, "CustomTabHasRequiredFields");
      this.m_ShowbyDefaultLawtype = new CPostItem(CPostItem.DataType.BOOL, "CustomTabShowbyDefaultLawtype");
      this.m_MustShowLawtype = new CPostItem(CPostItem.DataType.BOOL, "CustomTabMustShowLawtype");
      this.m_IsOriginalCustomTab = new CPostItem(CPostItem.DataType.BOOL, "CustomTabIsOriginalCustomTab");
      this.m_ShowForMatter = new CPostItem(CPostItem.DataType.BOOL, "CustomTabShowForMatter");
      this.m_ShowForClient = new CPostItem(CPostItem.DataType.BOOL, "CustomTabShowForClient");
      this.m_ShowForContact = new CPostItem(CPostItem.DataType.BOOL, "CustomTabShowForContact");
      this.m_ShowForVendor = new CPostItem(CPostItem.DataType.BOOL, "CustomTabShowForVendor");
      this.m_FieldID = new CPostItem(CPostItem.DataType.RepeatLONG, "CustomTabFieldID");
      this.m_FieldStatus = new CPostItem(CPostItem.DataType.RepeatLONG, "CustomTabFieldStatus");
      this.m_FieldOrder = new CPostItem(CPostItem.DataType.RepeatLONG, "CustomTabFieldOrder");
      this.m_FieldRequired = new CPostItem(CPostItem.DataType.RepeatBOOL, "CustomTabFieldRequired");
      this.m_FieldLabel = new CPostItem(CPostItem.DataType.RepeatSTRING, "CustomTabFieldLabel");
      this.m_FieldToolTip = new CPostItem(CPostItem.DataType.RepeatSTRING, "CustomTabFieldToolTip");
      this.m_FieldType = new CPostItem(CPostItem.DataType.RepeatLONG, "CustomTabFieldType");
      this.m_FieldLen = new CPostItem(CPostItem.DataType.RepeatLONG, "CustomTabFieldLen");
      this.m_FieldRangeMin = new CPostItem(CPostItem.DataType.RepeatSTRING, "CustomTabFieldRangeMin");
      this.m_FieldRangeMax = new CPostItem(CPostItem.DataType.RepeatSTRING, "CustomTabFieldRangeMax");
      this.m_ExternalID_1 = new CPostItem(CPostItem.DataType.STRING, "ExternalID_1");
      this.m_ExternalID_2 = new CPostItem(CPostItem.DataType.STRING, "ExternalID_2");
      this.m_FieldIDArr = new ArrayList();
      this.m_FieldStatusArr = new ArrayList();
      this.m_FieldOrderArr = new ArrayList();
      this.m_FieldRequiredArr = new ArrayList();
      this.m_FieldLabelArr = new ArrayList();
      this.m_FieldToolTipArr = new ArrayList();
      this.m_FieldTypeArr = new ArrayList();
      this.m_FieldLenArr = new ArrayList();
      this.m_FieldRangeMinArr = new ArrayList();
      this.m_FieldRangeMaxArr = new ArrayList();
    }

    public override string MakeNN(bool bSetNickName)
    {
      return "";
    }

    private static void ReadTable()
    {
      if (PLCustomTab.bRead)
        return;
      uint num = 0;
      object szValue = new object();
      uint createHandle = PLLink.GetLink().TableGET_CreateHandle("CustomTab", 0, 0, 0U);
      PLLink.GetLink().TableGET_AddFilter(createHandle, "CustomTabStatus", "EQ", "0", 1);
      while (PLLink.GetLink().TableGET_GetNextRecord(createHandle) == 0)
      {
        PLLink.GetLink().TableGET_RecordField_ValueString(createHandle, "CustomTabName", "", ref szValue);
        string str = szValue.ToString().ToUpper().Trim();
        int recordFieldValueI32 = PLLink.GetLink().TableGET_RecordField_ValueI32(createHandle, "CustomTabID");
        PLCustomTab.AddMapNNtoID(str, recordFieldValueI32);
        PLCustomTab.AddMapIDtoNN(recordFieldValueI32, str);
        StaticData.AddNicknameToList(str);
      }
      PLLink.GetLink().TableGET_CloseHandle(createHandle);
      num = 0U;
      PLCustomTab.bRead = true;
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
      string str1;
      string str2;
      string str3;
      string str4;
      string str5;
      string str6;
      try
      {
        this.GetLink().TablePOST_Send(this.m_hndPOST, ref nProcessed, ref nExceptions);
      }
      catch (AccessViolationException ex)
      {
        str1 = ex.Data == null ? "" : ex.Data.ToString();
        str2 = ex.HelpLink == null ? "" : ex.HelpLink.ToString();
        str3 = ex.InnerException == null ? "" : ex.InnerException.ToString();
        string message = ex.Message;
        str4 = ex.Source == null ? "" : ex.Source.ToString();
        str5 = ex.StackTrace == null ? "" : ex.StackTrace.ToString();
        str6 = ex.TargetSite == (MethodBase) null ? "" : ex.TargetSite.ToString();
        this.GetLink().LinkLog_AddLinkLogMessage("AccessViolationException Execption: " + message);
        this.GetLink().TablePOST_DumpExceptionsToLinkLog(this.m_hndPOST);
        this.GetLink().TablePOST_Reset(this.m_hndPOST);
        return;
      }
      catch (FormatException ex)
      {
        str1 = ex.Data == null ? "" : ex.Data.ToString();
        str2 = ex.HelpLink == null ? "" : ex.HelpLink.ToString();
        str3 = ex.InnerException == null ? "" : ex.InnerException.ToString();
        string message = ex.Message;
        str4 = ex.Source == null ? "" : ex.Source.ToString();
        str5 = ex.StackTrace == null ? "" : ex.StackTrace.ToString();
        str6 = ex.TargetSite == (MethodBase) null ? "" : ex.TargetSite.ToString();
        this.GetLink().LinkLog_AddLinkLogMessage("Format Execption: " + message);
        this.GetLink().TablePOST_DumpExceptionsToLinkLog(this.m_hndPOST);
        this.GetLink().TablePOST_Reset(this.m_hndPOST);
        return;
      }
      catch (Exception ex)
      {
        str1 = ex.Data == null ? "" : ex.Data.ToString();
        str2 = ex.HelpLink == null ? "" : ex.HelpLink.ToString();
        str3 = ex.InnerException == null ? "" : ex.InnerException.ToString();
        string message = ex.Message;
        str4 = ex.Source == null ? "" : ex.Source.ToString();
        str5 = ex.StackTrace == null ? "" : ex.StackTrace.ToString();
        str6 = ex.TargetSite == (MethodBase) null ? "" : ex.TargetSite.ToString();
        this.GetLink().LinkLog_AddLinkLogMessage("Catch All Execption: " + message);
        this.GetLink().TablePOST_DumpExceptionsToLinkLog(this.m_hndPOST);
        this.GetLink().TablePOST_Reset(this.m_hndPOST);
        this.m_lCounter = 0;
        return;
      }
      try
      {
        short int16_1 = Convert.ToInt16(nProcessed);
        short int16_2 = Convert.ToInt16(nExceptions);
        PLXMLData.m_lErrorCount += (long) int16_2;
        if (((int) int16_2 > 0 ? 1 : (this.m_lCounter != (int) int16_1 ? 1 : 0)) != 0)
        {
          this.GetLink().TablePOST_DumpExceptionsToLinkLog(this.m_hndPOST);
          PLCustomTab plCustomTab = this;
          plCustomTab.m_lSendErrorCount = plCustomTab.m_lSendErrorCount + 1L;
        }
        while (this.GetLink().TablePOST_GetNextResult(this.m_hndPOST, ref vunIDCreated, ref nExceptionError, ref szExceptionErrorMsg, ref szExceptionSentData) == 0)
        {
          if (Convert.ToInt32(nExceptionError) <= 0)
          {
            this.GetLink().TablePOST_ResultDataField_String(this.m_hndPOST, this.m_ExternalID_1.sLinkName, szDefault, ref szValue);
            PLCustomTab.AddMapExtID1toPLID(szValue.ToString(), Convert.ToInt32(vunIDCreated));
            this.GetLink().TablePOST_ResultDataField_String(this.m_hndPOST, this.m_ExternalID_2.sLinkName, szDefault, ref szValue);
            PLCustomTab.AddMapExtID2toPLID(szValue.ToString(), Convert.ToInt32(vunIDCreated));
          }
        }
        PLCustomTab.ClearMapIDtoNN();
        PLCustomTab.ClearMapNNtoID();
        PLCustomTab.bRead = false;
        PLCustomTab.ReadTable();
        this.GetLink().TablePOST_Reset(this.m_hndPOST);
        this.m_lCounter = 0;
      }
      catch (Exception ex)
      {
        str1 = ex.Data == null ? "" : ex.Data.ToString();
        str2 = ex.HelpLink == null ? "" : ex.HelpLink.ToString();
        str3 = ex.InnerException == null ? "" : ex.InnerException.ToString();
        string message = ex.Message;
        str4 = ex.Source == null ? "" : ex.Source.ToString();
        str5 = ex.StackTrace == null ? "" : ex.StackTrace.ToString();
        str6 = ex.TargetSite == (MethodBase) null ? "" : ex.TargetSite.ToString();
        this.GetLink().LinkLog_AddLinkLogMessage("Catch All Execption: " + message);
        this.GetLink().TablePOST_DumpExceptionsToLinkLog(this.m_hndPOST);
        this.GetLink().TablePOST_Reset(this.m_hndPOST);
        this.m_lCounter = 0;
      }
    }

    public enum eTabFieldInputType
    {
      HT_NONE = 0,
      HT_TEXT = 0,
      HT_DATE = 1,
      HT_LAWYER = 2,
      HT_LAWYER_ALL = 3,
      HT_GLACCOUNT = 4,
      HT_TYPEOFLAW = 5,
      HT_TASKCODE = 6,
      HT_MATTER = 7,
      HT_MATTER_ALL = 8,
      HT_MATTER_NEW = 9,
      HT_CLIENT = 10,
      HT_CLIENT_ALL = 11,
      HT_CLIENT_NEW = 12,
      HT_CLIENT_MAJOR = 13,
      HT_VENDOR = 14,
      HT_VENDOR_ALL = 15,
      HT_VENDOR_NEW = 16,
      HT_AMOUNT = 17,
      HT_VALUE = 18,
      HT_PERCENT = 19,
      HT_EXPLCODE = 20,
      HT_PREFIX = 21,
      HT_USERNAME = 22,
      HT_RATE = 23,
      HT_CONTACT = 24,
      HT_CHOICE = 25,
      HT_YESNO = 26,
      HT_BILLINGFREQ = 27,
    }

    public enum eTabType
    {
      CUSTOMTAB,
      QUICKTAB_MATTER,
      QUICKTAB_LEDGER,
      QUICKTAB_INSTANTMESSAGE,
      QUICKTAB_DEEDS,
      QUICKTAB_PACKETS,
    }
  }
}
