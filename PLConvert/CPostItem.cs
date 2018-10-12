// Decompiled with JetBrains decompiler
// Type: PLConvert.CPostItem
// Assembly: PLConvert, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DC1F0050-AC43-49A6-B4BD-95C619E8FF70
// Assembly location: C:\Users\haddocdx\Desktop\Conv DLLs\PLConvert.dll

using ConvHelper;
using PLXMLLnkLib;

namespace PLConvert
{
  public class CPostItem
  {
    public bool m_bIsSet;
    public CPostItem.DataType eDataType;
    public string sValue;
    public int nValue;
    public double dValue;
    public bool bValue;
    public string sLinkName;

    public CPostItem(CPostItem.DataType eType, string sLinkNm)
    {
      this.sValue = "";
      this.nValue = 0;
      this.dValue = 0.0;
      this.bValue = false;
      this.m_bIsSet = false;
      this.eDataType = eType;
      this.sLinkName = sLinkNm;
    }

    public void AddField(uint handle)
    {
      if (!this.m_bIsSet || (int) handle == 0)
        return;
      switch (this.eDataType)
      {
        case CPostItem.DataType.STRING:
          this.sValue = StringManip.RemInvalidChar(this.sValue);
          this.GetLink().TablePOST_AddRecordField_ValueString(handle, this.sLinkName, this.sValue);
          break;
        case CPostItem.DataType.LONG:
          this.GetLink().TablePOST_AddRecordField_ValueI32(handle, this.sLinkName, this.nValue);
          break;
        case CPostItem.DataType.DOUBLE:
          this.GetLink().TablePOST_AddRecordField_ValueDOUBLE(handle, this.sLinkName, this.dValue);
          break;
        case CPostItem.DataType.BOOL:
          this.GetLink().TablePOST_AddRecordField_ValueBOOL(handle, this.sLinkName, this.bValue ? 1 : 0);
          break;
      }
      this.Clear();
    }

    public void AddRepeatField(uint handle, int nRepeat)
    {
      if (!this.m_bIsSet || (int) handle == 0)
        return;
      switch (this.eDataType)
      {
        case CPostItem.DataType.RepeatSTRING:
          this.sValue = StringManip.RemInvalidChar(this.sValue);
          this.GetLink().TablePOST_AddRecurringField_ValueString(handle, this.sLinkName, nRepeat, this.sValue);
          break;
        case CPostItem.DataType.RepeatLONG:
          this.GetLink().TablePOST_AddRecurringField_ValueI32(handle, this.sLinkName, nRepeat, this.nValue);
          break;
        case CPostItem.DataType.RepeatDOUBLE:
          this.GetLink().TablePOST_AddRecurringField_ValueDOUBLE(handle, this.sLinkName, nRepeat, this.dValue);
          break;
        case CPostItem.DataType.RepeatBOOL:
          this.GetLink().TablePOST_AddRecurringField_ValueBOOL(handle, this.sLinkName, nRepeat, this.bValue ? 1 : 0);
          break;
      }
      this.Clear();
    }

    public void Clear()
    {
      this.sValue = "";
      this.nValue = 0;
      this.dValue = 0.0;
      this.bValue = false;
      this.m_bIsSet = false;
    }

    public void GetField(uint handle)
    {
      object szValue = new object();
      if ((int) handle == 0)
        return;
      this.m_bIsSet = false;
      switch (this.eDataType)
      {
        case CPostItem.DataType.STRING:
          this.GetLink().TableGET_RecordField_ValueString(handle, this.sLinkName, "", ref szValue);
          this.sValue = szValue.ToString();
          this.sValue = StringManip.RemInvalidChar(this.sValue);
          this.m_bIsSet = true;
          break;
        case CPostItem.DataType.LONG:
          this.nValue = this.GetLink().TableGET_RecordField_ValueI32(handle, this.sLinkName);
          this.m_bIsSet = true;
          break;
        case CPostItem.DataType.DOUBLE:
          this.dValue = this.GetLink().TableGET_RecordField_ValueDOUBLE(handle, this.sLinkName);
          this.m_bIsSet = true;
          break;
        case CPostItem.DataType.BOOL:
          this.bValue = this.GetLink().TableGET_RecordField_ValueBOOL(handle, this.sLinkName) != 0;
          this.m_bIsSet = true;
          break;
      }
    }

    private PCLawATLClass GetLink()
    {
      return PLLink.GetLink();
    }

    public void GetRepeatField(uint handle, int nRepeat)
    {
      object szValue = new object();
      if ((int) handle == 0)
        return;
      this.m_bIsSet = false;
      switch (this.eDataType)
      {
        case CPostItem.DataType.RepeatSTRING:
          this.GetLink().TableGET_RecordRecurringField_ValueString(handle, this.sLinkName, nRepeat, "", ref szValue);
          this.sValue = szValue.ToString();
          this.sValue = StringManip.RemInvalidChar(this.sValue);
          this.m_bIsSet = true;
          break;
        case CPostItem.DataType.RepeatLONG:
          this.nValue = this.GetLink().TableGET_RecordRecurringField_ValueI32(handle, this.sLinkName, nRepeat);
          this.m_bIsSet = true;
          break;
        case CPostItem.DataType.RepeatDOUBLE:
          this.dValue = this.GetLink().TableGET_RecordRecurringField_ValueDOUBLE(handle, this.sLinkName, nRepeat);
          this.m_bIsSet = true;
          break;
        case CPostItem.DataType.RepeatBOOL:
          this.bValue = this.GetLink().TableGET_RecordRecurringField_ValueBOOL(handle, this.sLinkName, nRepeat) != 0;
          this.m_bIsSet = true;
          break;
      }
    }

    public void SetValue(string Val)
    {
      this.sValue = Val;
      this.m_bIsSet = true;
    }

    public void SetValue(bool Val)
    {
      this.bValue = Val;
      this.m_bIsSet = true;
    }

    public void SetValue(double Val)
    {
      this.dValue = Val;
      this.m_bIsSet = true;
    }

    public void SetValue(int Val)
    {
      this.nValue = Val;
      this.m_bIsSet = true;
    }

    public enum DataType : byte
    {
      NotSet,
      STRING,
      LONG,
      DOUBLE,
      BOOL,
      RepeatSTRING,
      RepeatLONG,
      RepeatDOUBLE,
      RepeatBOOL,
    }
  }
}
