// Decompiled with JetBrains decompiler
// Type: PLConvert.PLMatter
// Assembly: PLConvert, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DC1F0050-AC43-49A6-B4BD-95C619E8FF70
// Assembly location: C:\Users\haddocdx\Desktop\Conv DLLs\PLConvert.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace PLConvert
{
  public class PLMatter : StaticData
  {
    private static bool m_bRead = false;
    public PLAddress BillAddress1;
    public PLAddress BillAddress2;
    public PLAddress ClientAddress;
    public PLName ClientName;
    public PLName BillName1;
    public PLName BillName2;
    public PLPhone BillPhone1;
    public PLPhone BillPhone2;
    public PLPhone ClientPhone;
    private CPostItem m_ClientID;
    private CPostItem m_ClientNN;
    private CPostItem m_ClientContactID;
    private CPostItem m_MajorClientID;
    private CPostItem m_MajorClientNN;
    private CPostItem m_TransactionChangeID;
    private CPostItem m_LawyerRespID;
    private CPostItem m_LawyerAssignedID;
    private CPostItem m_LawyerCLIntroID;
    private List<PLMatter.IntroLawyer> m_IntroLawyers;
    private CPostItem m_LawyerMatIntroID;
    private CPostItem m_LawyerMatIntroPCT;
    private CPostItem m_AutoAllocFees;
    private CPostItem m_AutoTransferTrustAtBilling;
    private CPostItem m_BillCostOnlyOnMassBill;
    private CPostItem m_BillingFrequency;
    private CPostItem m_BudgetFees;
    private CPostItem m_IntCalcFromGraceDate;
    private CPostItem m_InterestStartDate;
    private List<PLMatter.LawyerExceptionRate> m_ExceptionRates;
    private CPostItem m_ExceptionLwrID;
    private CPostItem m_ExceptionTaskID;
    private CPostItem m_ExceptionLwrRateAmount;
    private CPostItem m_ExceptionLwrRateID;
    private List<PLMatter.LawyerFeeSplit> m_SplitLawyerCharges;
    private CPostItem m_InvFeeAllocLwrID;
    private CPostItem m_InvFeeAllocLwrFeePrcnt;
    private CPostItem m_CollectionMemos;
    private CPostItem m_PreBillMemos;
    private CPostItem m_BillMemos;
    private CPostItem m_Contingency;
    private CPostItem m_CourtIdentifier;
    private CPostItem m_CrossReference;
    private CPostItem m_DateClosed;
    private CPostItem m_DateOpened;
    private CPostItem m_Description;
    private CPostItem m_DisbMarkupPct;
    private CPostItem m_DiscountFeePercent;
    private CPostItem m_DoNotChargeTAF;
    private CPostItem m_FileLocation;
    private CPostItem m_FormatBilling;
    private CPostItem m_FormatReminder;
    private CPostItem m_ChargeInterest;
    private CPostItem m_InterestGraceDays;
    private CPostItem m_InterestRate;
    private CPostItem m_InterestRateUseDefault;
    private CPostItem m_InterestUseSimple;
    private CPostItem m_IsInactive;
    private CPostItem m_IsOnCreditHold;
    private CPostItem m_IsOnTrustHold;
    private CPostItem m_Judge;
    private CPostItem m_Jurisdiction;
    private CPostItem m_Memos;
    private CPostItem m_ProduceReminders;
    private CPostItem m_Exportable;
    private CPostItem m_QuotedAmount;
    private CPostItem m_QuotedType;
    private CPostItem m_RateAmount;
    private CPostItem m_RateID;
    private CPostItem m_OtherStaffID;
    private CPostItem m_TaskID;
    private CPostItem m_TypeOfLawIDTaskList;
    private CPostItem m_DepartmentID;
    private CPostItem m_TypeOfLawID;
    private CPostItem m_ReferredBy;
    private CPostItem m_UseTaskBasedBilling;
    private CPostItem m_GSTCategory;
    private CPostItem m_GSTRateFees;
    private CPostItem m_GSTRateDisb;
    private CPostItem m_PSTRateFees;
    private CPostItem m_PSTRateDisb;
    private CPostItem m_UseUKLegalAid;
    private CPostItem m_BillAllowSettingOverrides;
    private CPostItem m_BillDefBillSettingsNN;
    private CPostItem m_BillMaxTotalFees;
    private CPostItem m_BillFeesLessThan;
    private CPostItem m_BillDisbsLessThan;
    private CPostItem m_BillChargesLessThan;
    private CPostItem m_BillARBalanceOver;
    private CPostItem m_BillApplyToEveryBill;
    private CPostItem m_BillNumBills;
    private CPostItem m_BillUseFeeDiscount;
    private CPostItem m_BillPayExistingInvOnTT;
    private CPostItem m_BillAskForRetainer;
    private CPostItem m_BillIgnoreBillSelections;
    private CPostItem m_BillIncludeIfARBalOver;
    private CPostItem m_ContactID;
    private CPostItem m_RoleID;
    private static List<PLMatter.MatterContact> listContacts;
    public static int m_nMatterNN;
    private CPostItem m_TotalHours;
    private CPostItem m_TotalHoursBilled;
    private CPostItem m_TotalAR;
    private CPostItem m_TotalFees;
    private CPostItem m_TotalFeesBilled;
    private CPostItem m_TotalDisb;
    private CPostItem m_TotalDisbBilled;
    private CPostItem m_TotalReceipts;
    private CPostItem m_TotalReceiptsBilled;
    private CPostItem m_TrustBalance;
    private CPostItem m_TotalTaxFees;
    private CPostItem m_TotalTaxDisb;
    private List<int> m_TrustBankAcctountIDArray;
    private List<double> m_TrustAccountBalanceArray;
    private CPostItem m_TrustBankAcctID;
    private CPostItem m_TrustBankBalance;
    private static Dictionary<string, int> m_MapNNtoID;
    private static Dictionary<int, string> m_MapIDtoNN;
    private static Dictionary<int, List<int>> m_MapIDtoContacts;
    private static Dictionary<string, int> m_MapExtID1toPLID;
    private static Dictionary<string, int> m_MapExtID2toPLID;
    private static Dictionary<int, int> m_MapIDtoTypeofLaw;
    private static Dictionary<int, int> m_MapIDtoResp;
    private static Dictionary<int, string> m_MapIDtoStatus;
    private static Dictionary<int, string> m_MapIDtoQuickBooksID;

    public bool AutoAllocFees
    {
      get
      {
        return this.m_AutoAllocFees.bValue;
      }
      set
      {
        this.m_AutoAllocFees.SetValue(value);
      }
    }

    public bool AutoTransferTrustAtBilling
    {
      get
      {
        return this.m_AutoTransferTrustAtBilling.bValue;
      }
      set
      {
        this.m_AutoTransferTrustAtBilling.SetValue(value);
      }
    }

    public bool BillAllowSettingOverrides
    {
      get
      {
        return this.m_BillAllowSettingOverrides.bValue;
      }
      set
      {
        this.m_BillAllowSettingOverrides.SetValue(value);
      }
    }

    public bool BillApplyToEveryBill
    {
      get
      {
        return this.m_BillApplyToEveryBill.bValue;
      }
      set
      {
        this.m_BillApplyToEveryBill.SetValue(value);
      }
    }

    public double BillARBalanceOver
    {
      get
      {
        return this.m_BillARBalanceOver.dValue;
      }
      set
      {
        this.m_BillARBalanceOver.SetValue(value);
      }
    }

    public bool BillAskForRetainer
    {
      get
      {
        return this.m_BillAskForRetainer.bValue;
      }
      set
      {
        this.m_BillAskForRetainer.SetValue(value);
      }
    }

    public double BillChargesLessThan
    {
      get
      {
        return this.m_BillChargesLessThan.dValue;
      }
      set
      {
        this.m_BillChargesLessThan.SetValue(value);
      }
    }

    public bool BillCostOnlyOnMassBill
    {
      get
      {
        return this.m_BillCostOnlyOnMassBill.bValue;
      }
      set
      {
        this.m_BillCostOnlyOnMassBill.SetValue(value);
      }
    }

    public string BillDefBillSettingsNN
    {
      get
      {
        return this.m_BillDefBillSettingsNN.sValue;
      }
      set
      {
        this.m_BillDefBillSettingsNN.SetValue(value);
      }
    }

    public double BillDisbsLessThan
    {
      get
      {
        return this.m_BillDisbsLessThan.dValue;
      }
      set
      {
        this.m_BillDisbsLessThan.SetValue(value);
      }
    }

    public double BillFeesLessThan
    {
      get
      {
        return this.m_BillFeesLessThan.dValue;
      }
      set
      {
        this.m_BillFeesLessThan.SetValue(value);
      }
    }

    public bool BillIgnoreBillSelections
    {
      get
      {
        return this.m_BillIgnoreBillSelections.bValue;
      }
      set
      {
        this.m_BillIgnoreBillSelections.SetValue(value);
      }
    }

    public bool BillIncludeIfARBalOver
    {
      get
      {
        return this.m_BillIncludeIfARBalOver.bValue;
      }
      set
      {
        this.m_BillIncludeIfARBalOver.SetValue(value);
      }
    }

    public double BillMaxTotalFees
    {
      get
      {
        return this.m_BillMaxTotalFees.dValue;
      }
      set
      {
        this.m_BillMaxTotalFees.SetValue(value);
      }
    }

    public string BillMemos
    {
      get
      {
        return this.m_BillMemos.sValue;
      }
      set
      {
        this.m_BillMemos.SetValue(value);
      }
    }

    public int BillNumBills
    {
      get
      {
        return this.m_BillNumBills.nValue;
      }
      set
      {
        this.m_BillNumBills.SetValue(value);
      }
    }

    public bool BillPayExistingInvOnTT
    {
      get
      {
        return this.m_BillPayExistingInvOnTT.bValue;
      }
      set
      {
        this.m_BillPayExistingInvOnTT.SetValue(value);
      }
    }

    public bool BillUseFeeDiscount
    {
      get
      {
        return this.m_BillUseFeeDiscount.bValue;
      }
      set
      {
        this.m_BillUseFeeDiscount.SetValue(value);
      }
    }

    public double BudgetFees
    {
      get
      {
        return this.m_BudgetFees.dValue;
      }
      set
      {
        this.m_BudgetFees.SetValue(value);
        this.m_BudgetFees.m_bIsSet = true;
      }
    }

    public bool ChargeInterest
    {
      get
      {
        return this.m_ChargeInterest.bValue;
      }
      set
      {
        this.m_ChargeInterest.SetValue(value);
      }
    }

    public int ClientContactID
    {
      get
      {
        return this.m_ClientContactID.nValue;
      }
      set
      {
        this.m_ClientContactID.SetValue(value);
      }
    }

    public int ClientID
    {
      get
      {
        return this.m_ClientID.nValue;
      }
      set
      {
        this.m_ClientID.SetValue(value);
      }
    }

    public string ClientNN
    {
      get
      {
        return this.m_ClientNN.sValue;
      }
      set
      {
        this.m_ClientNN.SetValue(value);
        int idFromNn = PLClient.GetIDFromNN(this.m_ClientNN.sValue);
        if (idFromNn.Equals(0))
          return;
        this.ClientID = idFromNn;
      }
    }

    public string CollectionMemos
    {
      get
      {
        return this.m_CollectionMemos.sValue;
      }
      set
      {
        this.m_CollectionMemos.SetValue(value);
      }
    }

    public bool Contingency
    {
      get
      {
        return this.m_Contingency.bValue;
      }
      set
      {
        this.m_Contingency.SetValue(value);
      }
    }

    public string Court
    {
      get
      {
        return this.m_CourtIdentifier.sValue;
      }
      set
      {
        this.m_CourtIdentifier.SetValue(value);
      }
    }

    public string CrossReference
    {
      get
      {
        return this.m_CrossReference.sValue;
      }
      set
      {
        this.m_CrossReference.SetValue(value);
      }
    }

    public int DateClosed
    {
      get
      {
        return this.m_DateClosed.nValue;
      }
      set
      {
        if ((value < 19820101 ? 1 : (value > 21991231 ? 1 : 0)) != 0)
          this.m_DateClosed.SetValue(19820101);
        else
          this.m_DateClosed.SetValue(value);
      }
    }

    public int DateOpened
    {
      get
      {
        return this.m_DateOpened.nValue;
      }
      set
      {
        if ((value < 19820101 ? 1 : (value > 21991231 ? 1 : 0)) != 0)
          this.m_DateOpened.SetValue(20061231);
        else
          this.m_DateOpened.SetValue(value);
      }
    }

    public int DepartmentID
    {
      get
      {
        return this.m_DepartmentID.nValue;
      }
      set
      {
        this.m_DepartmentID.SetValue(value);
      }
    }

    public string DepartmentNN
    {
      get
      {
        return PLDepartment.GetNNFromID(this.m_DepartmentID.nValue);
      }
      set
      {
        this.m_DepartmentID.SetValue(PLDepartment.GetIDFromNN(value));
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

    public bool DisbMarkupPct
    {
      get
      {
        return this.m_DisbMarkupPct.bValue;
      }
      set
      {
        this.m_DisbMarkupPct.SetValue(value);
      }
    }

    public double DiscountFeePercent
    {
      get
      {
        return this.m_DiscountFeePercent.dValue;
      }
      set
      {
        this.m_DiscountFeePercent.SetValue(value);
      }
    }

    public bool DoNotChargeTAF
    {
      get
      {
        return this.m_DoNotChargeTAF.bValue;
      }
      set
      {
        this.m_DoNotChargeTAF.SetValue(value);
      }
    }

    private int ExceptionLwrID
    {
      get
      {
        return this.m_ExceptionLwrID.nValue;
      }
      set
      {
        this.m_ExceptionLwrID.SetValue(value);
      }
    }

    private double ExceptionLwrRateAmount
    {
      get
      {
        return this.m_ExceptionLwrRateAmount.dValue;
      }
      set
      {
        this.m_ExceptionLwrRateAmount.SetValue(value);
      }
    }

    private int ExceptionLwrRateID
    {
      get
      {
        return this.m_ExceptionLwrRateID.nValue;
      }
      set
      {
        this.m_ExceptionLwrRateID.SetValue(value);
      }
    }

    private int ExceptionTaskID
    {
      get
      {
        return this.m_ExceptionTaskID.nValue;
      }
      set
      {
        this.m_ExceptionTaskID.SetValue(value);
      }
    }

    public bool Exportable
    {
      get
      {
        return this.m_Exportable.bValue;
      }
      set
      {
        this.m_Exportable.SetValue(value);
      }
    }

    public string FileLocation
    {
      get
      {
        return this.m_FileLocation.sValue;
      }
      set
      {
        this.m_FileLocation.SetValue(value);
      }
    }

    public string FormatBilling
    {
      get
      {
        return this.m_FormatBilling.sValue;
      }
      set
      {
        this.m_FormatBilling.SetValue(value);
      }
    }

    public string FormatReminder
    {
      get
      {
        return this.m_FormatReminder.sValue;
      }
      set
      {
        this.m_FormatReminder.SetValue(value);
      }
    }

    public PLMatter.eFREQUENCY Frequency
    {
      get
      {
        return (PLMatter.eFREQUENCY) this.m_BillingFrequency.nValue;
      }
      set
      {
        this.m_BillingFrequency.SetValue((int) value);
      }
    }

    public PLMatter.eGST_CAT GSTCat
    {
      get
      {
        return (PLMatter.eGST_CAT) this.m_GSTCategory.nValue;
      }
      set
      {
        this.m_GSTCategory.SetValue((int) value);
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

    public bool IntCalcFromGraceDate
    {
      get
      {
        return this.m_IntCalcFromGraceDate.bValue;
      }
      set
      {
        this.m_IntCalcFromGraceDate.SetValue(value);
      }
    }

    public int InterestGraceDays
    {
      get
      {
        return this.m_InterestGraceDays.nValue;
      }
      set
      {
        this.m_InterestGraceDays.SetValue(value);
      }
    }

    public double InterestRate
    {
      get
      {
        return this.m_InterestRate.dValue;
      }
      set
      {
        this.m_InterestRate.SetValue(value);
      }
    }

    public bool InterestRateUseDefault
    {
      get
      {
        return this.m_InterestRateUseDefault.bValue;
      }
      set
      {
        this.m_InterestRateUseDefault.SetValue(value);
      }
    }

    public int InterestStartDate
    {
      get
      {
        return this.m_InterestStartDate.nValue;
      }
      set
      {
        this.m_InterestStartDate.SetValue(value);
      }
    }

    public bool InterestUseSimple
    {
      get
      {
        return this.m_InterestUseSimple.bValue;
      }
      set
      {
        this.m_InterestUseSimple.SetValue(value);
      }
    }

    private double InvFeeAllocLwrFeePrcnt
    {
      get
      {
        return this.m_InvFeeAllocLwrFeePrcnt.dValue;
      }
      set
      {
        this.m_InvFeeAllocLwrFeePrcnt.SetValue(value);
      }
    }

    private double InvFeeAllocLwrID
    {
      get
      {
        return this.m_InvFeeAllocLwrID.dValue;
      }
      set
      {
        this.m_InvFeeAllocLwrID.SetValue(value);
      }
    }

    public bool IsInactive
    {
      get
      {
        return this.m_IsInactive.bValue;
      }
      set
      {
        this.m_IsInactive.SetValue(value);
      }
    }

    public bool IsOnCreditHold
    {
      get
      {
        return this.m_IsOnCreditHold.bValue;
      }
      set
      {
        this.m_IsOnCreditHold.SetValue(value);
      }
    }

    public bool IsOnTrustHold
    {
      get
      {
        return this.m_IsOnTrustHold.bValue;
      }
      set
      {
        this.m_IsOnTrustHold.SetValue(value);
      }
    }

    public string Judge
    {
      get
      {
        return this.m_Judge.sValue;
      }
      set
      {
        this.m_Judge.SetValue(value);
      }
    }

    public string Jurisdiction
    {
      get
      {
        return this.m_Jurisdiction.sValue;
      }
      set
      {
        this.m_Jurisdiction.SetValue(value);
      }
    }

    public int LwrAssignID
    {
      get
      {
        return this.m_LawyerAssignedID.nValue;
      }
      set
      {
        this.m_LawyerAssignedID.SetValue(value);
      }
    }

    public string LwrAssignNN
    {
      get
      {
        return PLLawyer.GetNNFromID(this.m_LawyerAssignedID.nValue);
      }
      set
      {
        this.m_LawyerAssignedID.SetValue(PLLawyer.GetIDFromNN(value));
      }
    }

    public string LwrCLIntroNN
    {
      get
      {
        return PLLawyer.GetNNFromID(this.m_LawyerCLIntroID.nValue);
      }
      set
      {
        this.m_LawyerCLIntroID.SetValue(PLLawyer.GetIDFromNN(value));
      }
    }

    public int LwrRespID
    {
      get
      {
        return this.m_LawyerRespID.nValue;
      }
      set
      {
        this.m_LawyerRespID.SetValue(value);
      }
    }

    public string LwrRespNN
    {
      get
      {
        return PLLawyer.GetNNFromID(this.m_LawyerRespID.nValue);
      }
      set
      {
        this.m_LawyerRespID.SetValue(PLLawyer.GetIDFromNN(value));
      }
    }

    public int MajorClientID
    {
      get
      {
        return this.m_MajorClientID.nValue;
      }
      set
      {
        this.m_MajorClientID.SetValue(value);
      }
    }

    public string MajorClientNN
    {
      get
      {
        return this.m_MajorClientNN.sValue;
      }
      set
      {
        this.m_MajorClientNN.SetValue(value);
      }
    }

    public int MatterID
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

    public string Memos
    {
      get
      {
        return this.m_Memos.sValue;
      }
      set
      {
        this.m_Memos.SetValue(value);
      }
    }

    public int OtherStaffID
    {
      get
      {
        return this.m_OtherStaffID.nValue;
      }
      set
      {
        this.m_OtherStaffID.SetValue(value);
      }
    }

    public string OtherStaffNN
    {
      get
      {
        return PLUser.GetNNFromID(this.m_OtherStaffID.nValue);
      }
      set
      {
        this.m_OtherStaffID.SetValue(PLUser.GetIDFromNN(value));
      }
    }

    public string PreBillMemos
    {
      get
      {
        return this.m_PreBillMemos.sValue;
      }
      set
      {
        this.m_PreBillMemos.SetValue(value);
      }
    }

    public bool ProduceReminders
    {
      get
      {
        return this.m_ProduceReminders.bValue;
      }
      set
      {
        this.m_ProduceReminders.SetValue(value);
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

    public double QuotedAmount
    {
      get
      {
        return this.m_QuotedAmount.dValue;
      }
      set
      {
        this.m_QuotedAmount.SetValue(value);
      }
    }

    public PLMatter.eQUOTE_TYPE QuoteType
    {
      get
      {
        return (PLMatter.eQUOTE_TYPE) this.m_QuotedType.nValue;
      }
      set
      {
        this.m_QuotedType.SetValue((int) value);
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

    public int RateID
    {
      get
      {
        return this.m_RateID.nValue;
      }
      set
      {
        this.m_RateID.SetValue(value);
      }
    }

    public string RateNN
    {
      get
      {
        return PLRate.GetNNFromID(this.m_RateID.nValue);
      }
      set
      {
        this.m_RateID.SetValue(PLRate.GetIDFromNN(value));
      }
    }

    public string ReferredBy
    {
      get
      {
        return this.m_ReferredBy.sValue;
      }
      set
      {
        this.m_ReferredBy.SetValue(value);
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

    public double TotalAR
    {
      get
      {
        return this.m_TotalAR.dValue;
      }
    }

    public double TotalDisb
    {
      get
      {
        return this.m_TotalDisb.dValue;
      }
    }

    public double TotalDisbBilled
    {
      get
      {
        return this.m_TotalDisbBilled.dValue;
      }
    }

    public double TotalFees
    {
      get
      {
        return this.m_TotalFees.dValue;
      }
    }

    public double TotalFeesBilled
    {
      get
      {
        return this.m_TotalFeesBilled.dValue;
      }
    }

    public double TotalHours
    {
      get
      {
        return this.m_TotalHours.dValue;
      }
    }

    public double TotalHoursBilled
    {
      get
      {
        return this.m_TotalHoursBilled.dValue;
      }
    }

    public double TotalReceipts
    {
      get
      {
        return this.m_TotalReceipts.dValue;
      }
    }

    public double TotalReceiptsBilled
    {
      get
      {
        return this.m_TotalReceiptsBilled.dValue;
      }
    }

    public double TotalTaxDisb
    {
      get
      {
        return this.m_TotalTaxDisb.dValue;
      }
    }

    public double TotalTaxFees
    {
      get
      {
        return this.m_TotalTaxFees.dValue;
      }
    }

    public int TransactionChangeID
    {
      get
      {
        return this.m_TransactionChangeID.nValue;
      }
      set
      {
        this.m_TransactionChangeID.SetValue(value);
      }
    }

    public double TrustBalance
    {
      get
      {
        return this.m_TrustBalance.dValue;
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

    public int TypeOfLawIDTaskList
    {
      get
      {
        return this.m_TypeOfLawIDTaskList.nValue;
      }
      set
      {
        this.m_TypeOfLawIDTaskList.SetValue(value);
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

    public string TypeOfLawNNTaskList
    {
      get
      {
        return PLTypeOfLaw.GetNNFromID(this.m_TypeOfLawIDTaskList.nValue);
      }
      set
      {
        this.m_TypeOfLawIDTaskList.SetValue(PLTypeOfLaw.GetIDFromNN(value));
      }
    }

    public bool UseTaskBasedBilling
    {
      get
      {
        return this.m_UseTaskBasedBilling.bValue;
      }
      set
      {
        this.m_UseTaskBasedBilling.SetValue(value);
      }
    }

    public bool UseUKLegalAid
    {
      get
      {
        return this.m_UseUKLegalAid.bValue;
      }
      set
      {
        this.m_UseUKLegalAid.SetValue(value);
      }
    }

    public PLMatter()
    {
      this.Initialize();
    }

    public void AddContact(int nContID, int nRoleId)
    {
      if (nContID.Equals(0) || this.IsContactAssociated(nContID))
        return;
      PLMatter.listContacts.Add(new PLMatter.MatterContact(nContID, nRoleId));
    }

    public void AddContact(int nContID, string sRole)
    {
      this.AddContact(nContID, PLContactType.GetIDFromNN(sRole));
    }

    public void AddContact(int nContID)
    {
      this.AddContact(nContID, 0);
    }

    public void AddInvoiceFeeAllocationOverride(int LawyerID, double PCT)
    {
      if (LawyerID.Equals(0))
        return;
      PCT = Math.Round(PCT, 2);
      if ((PCT > 100.0 ? 1 : (PCT < 0.0 ? 1 : 0)) != 0)
        PCT = 0.0;
      for (int index = 0; index < this.m_SplitLawyerCharges.Count; ++index)
      {
        if (this.m_SplitLawyerCharges[index].LawyerID == LawyerID)
        {
          this.m_SplitLawyerCharges[index].SplitPercent = PCT;
          return;
        }
      }
      this.m_SplitLawyerCharges.Add(new PLMatter.LawyerFeeSplit(LawyerID, PCT));
    }

    public void AddInvoiceFeeAllocationOverride(string LawyerNN, double PCT)
    {
      if (LawyerNN.Equals(""))
        return;
      int idFromNn = PLLawyer.GetIDFromNN(LawyerNN);
      if (!idFromNn.Equals(0))
        this.AddInvoiceFeeAllocationOverride(idFromNn, PCT);
    }

    private void AddLawyerTaskException(int LawyerID, int TaskID, double dAmount, int RateID)
    {
      if ((!LawyerID.Equals(0) ? 1 : (!TaskID.Equals(0) ? 1 : 0)) == 0)
        return;
      for (int index = 0; index < this.m_ExceptionRates.Count; ++index)
      {
        if ((LawyerID != this.m_ExceptionRates[index].LawyerID ? 1 : (TaskID != this.m_ExceptionRates[index].TaskID ? 1 : 0)) == 0)
        {
          this.m_ExceptionRates[index].RateAmount = dAmount;
          this.m_ExceptionRates[index].RateID = RateID;
          return;
        }
      }
      this.m_ExceptionRates.Add(new PLMatter.LawyerExceptionRate(LawyerID, TaskID, dAmount, RateID));
    }

    public void AddLawyerTaskException(int nLawyerID, int TaskID, double dAmount)
    {
      this.AddLawyerTaskException(nLawyerID, TaskID, dAmount, 0);
    }

    public void AddLawyerTaskException(int nLawyerID, int TaskID, int RateID)
    {
      this.AddLawyerTaskException(nLawyerID, TaskID, 0.0, RateID);
    }

    public void AddLawyerTaskException(int nLawyerID, int TaskID, string sRateNN)
    {
      this.AddLawyerTaskException(nLawyerID, TaskID, 0.0, PLRate.GetIDFromNN(sRateNN));
    }

    public static void AddMapExtID1toPLID(string Key, int Value)
    {
      if ((string.IsNullOrEmpty(Key) ? 0 : (!Value.Equals(0) ? 1 : 0)) == 0)
        return;
      if (PLMatter.m_MapExtID1toPLID == null)
        PLMatter.m_MapExtID1toPLID = new Dictionary<string, int>();
      if (!PLMatter.m_MapExtID1toPLID.ContainsKey(Key))
        PLMatter.m_MapExtID1toPLID.Add(Key, Value);
    }

    public static void AddMapExtID2toPLID(string Key, int Value)
    {
      if ((string.IsNullOrEmpty(Key) ? 0 : (!Value.Equals(0) ? 1 : 0)) == 0)
        return;
      if (PLMatter.m_MapExtID2toPLID == null)
        PLMatter.m_MapExtID2toPLID = new Dictionary<string, int>();
      if (!PLMatter.m_MapExtID2toPLID.ContainsKey(Key))
        PLMatter.m_MapExtID2toPLID.Add(Key, Value);
    }

    public static void AddMapIDtoContacts(int Key, int Value)
    {
      if ((Key.Equals(0) ? 0 : (!Value.Equals(0) ? 1 : 0)) == 0)
        return;
      if (PLMatter.m_MapIDtoContacts == null)
        PLMatter.m_MapIDtoContacts = new Dictionary<int, List<int>>();
      List<int> intList = new List<int>();
      if (PLMatter.m_MapIDtoContacts.ContainsKey(Key))
      {
        intList = PLMatter.m_MapIDtoContacts[Key];
        PLMatter.m_MapIDtoContacts.Remove(Key);
      }
      intList.Add(Value);
      PLMatter.m_MapIDtoContacts.Add(Key, intList);
    }

    public static void AddMapIDtoNN(int Key, string Value)
    {
      if ((Key.Equals(0) ? 0 : (!string.IsNullOrEmpty(Value) ? 1 : 0)) == 0)
        return;
      if (PLMatter.m_MapIDtoNN == null)
        PLMatter.m_MapIDtoNN = new Dictionary<int, string>();
      if (!PLMatter.m_MapIDtoNN.ContainsKey(Key))
        PLMatter.m_MapIDtoNN.Add(Key, Value);
    }

    public static void AddMapIDtoQuickBooksID(int Key, string Value)
    {
      if ((Key.Equals(0) ? 0 : (!string.IsNullOrEmpty(Value) ? 1 : 0)) == 0)
        return;
      if (PLMatter.m_MapIDtoQuickBooksID == null)
        PLMatter.m_MapIDtoQuickBooksID = new Dictionary<int, string>();
      if (!PLMatter.m_MapIDtoQuickBooksID.ContainsKey(Key))
        PLMatter.m_MapIDtoQuickBooksID.Add(Key, Value);
    }

    public static void AddMapIDtoResp(int Key, int Value)
    {
      if ((Key.Equals(0) ? 0 : (!Value.Equals(0) ? 1 : 0)) == 0)
        return;
      if (PLMatter.m_MapIDtoResp == null)
        PLMatter.m_MapIDtoResp = new Dictionary<int, int>();
      if (!PLMatter.m_MapIDtoResp.ContainsKey(Key))
        PLMatter.m_MapIDtoResp.Add(Key, Value);
    }

    public static void AddMapIDtoStatus(int Key, string Value)
    {
      if ((Key.Equals(0) ? 0 : (!string.IsNullOrEmpty(Value) ? 1 : 0)) == 0)
        return;
      if (PLMatter.m_MapIDtoStatus == null)
        PLMatter.m_MapIDtoStatus = new Dictionary<int, string>();
      if (!PLMatter.m_MapIDtoStatus.ContainsKey(Key))
        PLMatter.m_MapIDtoStatus.Add(Key, Value);
    }

    public static void AddMapIDtoTypeofLaw(int Key, int Value)
    {
      if ((Key.Equals(0) ? 0 : (!Value.Equals(0) ? 1 : 0)) == 0)
        return;
      if (PLMatter.m_MapIDtoTypeofLaw == null)
        PLMatter.m_MapIDtoTypeofLaw = new Dictionary<int, int>();
      if (!PLMatter.m_MapIDtoTypeofLaw.ContainsKey(Key))
        PLMatter.m_MapIDtoTypeofLaw.Add(Key, Value);
    }

    public static void AddMapNNtoID(string Key, int Value)
    {
      Key = Key.ToUpper();
      if (string.IsNullOrEmpty(Key))
        return;
      if (PLMatter.m_MapNNtoID == null)
        PLMatter.m_MapNNtoID = new Dictionary<string, int>();
      if (!PLMatter.m_MapNNtoID.ContainsKey(Key))
        PLMatter.m_MapNNtoID.Add(Key, Value);
    }

    public void AddMattIntroLawyer(int nLawyerID, double dPCT)
    {
      if (nLawyerID.Equals(0))
        return;
      if (dPCT > 100.0)
        dPCT = 0.0;
      this.m_IntroLawyers.Add(new PLMatter.IntroLawyer(nLawyerID, dPCT));
    }

    public void AddMattIntroLawyer(string sNN, double dPCT)
    {
      this.AddMattIntroLawyer(PLLawyer.GetIDFromNN(sNN), dPCT);
    }

    public override void AddRecord()
    {
      if ((int) this.m_hndPOST == 0)
        this.m_hndPOST = this.GetLink().TablePOST_CreateHandle(this.m_sTableName, 0);
      if (this.m_NickName.m_bIsSet && (!this.m_ID.m_bIsSet ? 1 : (this.m_ID.nValue.Equals(0) ? 1 : 0)) != 0)
      {
        bool flag = false;
        if (string.IsNullOrEmpty(this.NickName))
          flag = true;
        if ((flag || !this.m_ID.nValue.Equals(0) ? 0 : (PLMatter.GetIDFromNN(this.NickName) > 0 ? 1 : 0)) != 0)
          flag = true;
        if (!flag)
        {
          if (this.m_Status.m_bIsSet && this.Status == PLXMLData.eSTATUS.ARCHIVED)
          {
            if ((!this.m_NickName.sValue.StartsWith("A*") ? 0 : (this.NickName.Length > 21 ? 1 : 0)) != 0)
              flag = true;
            if ((this.m_NickName.sValue.StartsWith("A*") ? 0 : (this.NickName.Length > 12 ? 1 : 0)) != 0)
              flag = true;
          }
          else if (this.NickName.Length > 12)
            flag = true;
        }
        if (flag)
        {
          ++PLMatter.m_nMatterNN;
          string str = PLMatter.m_nMatterNN.ToString();
          if ((!this.m_Status.m_bIsSet ? 1 : (this.Status != PLXMLData.eSTATUS.ARCHIVED ? 1 : 0)) != 0)
            this.NickName = "~" + str;
          else
            this.NickName = ("A*~" + str + "                    ").Insert(20, "1").Trim();
        }
        else if ((!this.m_Status.m_bIsSet ? 0 : (this.Status == PLXMLData.eSTATUS.ARCHIVED ? 1 : 0)) != 0 && !this.NickName.StartsWith("A*"))
          this.NickName = ("A*" + this.NickName + "                    ").Insert(20, "1").Trim();
      }
      if ((this.m_ClientContactID.m_bIsSet || this.m_ClientID.m_bIsSet ? 0 : (this.m_ClientNN.m_bIsSet ? 1 : 0)) != 0 && (string.IsNullOrEmpty(this.m_ClientNN.sValue) ? 1 : (this.m_ClientNN.sValue.Length > 6 ? 1 : 0)) != 0)
      {
        ++PLClient.m_nClientNN;
        string str = PLClient.m_nClientNN.ToString();
        while (str.Length < 5)
          str = "0" + str;
        this.ClientNN = "~" + str;
      }
      if ((this.m_ClientContactID.m_bIsSet ? 0 : (!this.m_ClientID.m_bIsSet ? 1 : 0)) != 0)
      {
        if (this.ClientName.IsCorp)
        {
          if (string.IsNullOrEmpty(this.ClientName.Company))
            this.ClientName.Company = "---Company Name Not Supplied";
        }
        else if (string.IsNullOrEmpty(this.ClientName.Last))
          this.ClientName.Last = "---Last Name Not Supplied";
      }
      if (this.TaskID.Equals(0))
        this.TaskNN = "BW";
      if (this.TaskID.Equals(0))
        this.TaskID = 1;
      this.ClientAddress.AddFields(this.m_hndPOST);
      this.BillAddress1.AddFields(this.m_hndPOST);
      this.BillAddress2.AddFields(this.m_hndPOST);
      this.ClientName.AddFields(this.m_hndPOST);
      this.BillName1.AddFields(this.m_hndPOST);
      this.BillName2.AddFields(this.m_hndPOST);
      this.BillPhone1.AddFields(this.m_hndPOST);
      this.BillPhone2.AddFields(this.m_hndPOST);
      this.m_ClientContactID.AddField(this.m_hndPOST);
      if ((!this.m_ClientID.m_bIsSet ? 1 : (this.m_ClientID.nValue.Equals(0) ? 1 : 0)) != 0)
        this.m_ClientNN.AddField(this.m_hndPOST);
      else
        this.m_ClientID.AddField(this.m_hndPOST);
      this.m_ID.AddField(this.m_hndPOST);
      this.m_MajorClientNN.AddField(this.m_hndPOST);
      this.m_LawyerAssignedID.AddField(this.m_hndPOST);
      this.m_LawyerCLIntroID.AddField(this.m_hndPOST);
      if (this.ID.Equals(0))
      {
        if (this.m_IntroLawyers.Count > 0)
        {
          double num = 0.0;
          for (int index = 1; index <= this.m_IntroLawyers.Count; ++index)
            num += Math.Round(this.m_IntroLawyers[index - 1].Percent, 2);
          if (Math.Round(num, 2) != 100.0)
            this.m_IntroLawyers[0].Percent = Math.Round(this.m_IntroLawyers[0].Percent + 100.0 - num, 2);
        }
        for (int nRepeat = 1; nRepeat <= this.m_IntroLawyers.Count; ++nRepeat)
        {
          if (this.m_IntroLawyers[nRepeat - 1].LawyerID != 0)
          {
            this.m_LawyerMatIntroID.SetValue(this.m_IntroLawyers[nRepeat - 1].LawyerID);
            this.m_LawyerMatIntroID.AddRepeatField(this.m_hndPOST, nRepeat);
            this.m_LawyerMatIntroPCT.SetValue(this.m_IntroLawyers[nRepeat - 1].Percent);
            this.m_LawyerMatIntroPCT.AddRepeatField(this.m_hndPOST, nRepeat);
          }
        }
        this.m_IntroLawyers.Clear();
        for (int nRepeat = 1; nRepeat <= this.m_ExceptionRates.Count; ++nRepeat)
        {
          bool flag = false;
          if (this.m_ExceptionRates[nRepeat - 1].LawyerID != 0)
          {
            this.ExceptionLwrID = this.m_ExceptionRates[nRepeat - 1].LawyerID;
            this.m_ExceptionLwrID.AddRepeatField(this.m_hndPOST, nRepeat);
            flag = true;
          }
          if (this.m_ExceptionRates[nRepeat - 1].TaskID != 0)
          {
            this.ExceptionTaskID = this.m_ExceptionRates[nRepeat - 1].TaskID;
            this.m_ExceptionTaskID.AddRepeatField(this.m_hndPOST, nRepeat);
            flag = true;
          }
          if (flag)
          {
            if (this.m_ExceptionRates[nRepeat - 1].RateID.Equals(0))
            {
              this.ExceptionLwrRateAmount = this.m_ExceptionRates[nRepeat - 1].RateAmount;
              this.m_ExceptionLwrRateAmount.AddRepeatField(this.m_hndPOST, nRepeat);
            }
            else
            {
              this.ExceptionLwrRateID = this.m_ExceptionRates[nRepeat - 1].RateID;
              this.m_ExceptionLwrRateID.AddRepeatField(this.m_hndPOST, nRepeat);
            }
          }
        }
        this.m_ExceptionRates.Clear();
        for (int nRepeat = 1; nRepeat <= this.m_SplitLawyerCharges.Count; ++nRepeat)
        {
          this.InvFeeAllocLwrID = (double) this.m_SplitLawyerCharges[nRepeat - 1].LawyerID;
          this.m_InvFeeAllocLwrID.AddRepeatField(this.m_hndPOST, nRepeat);
          this.InvFeeAllocLwrFeePrcnt = this.m_SplitLawyerCharges[nRepeat - 1].SplitPercent;
          this.m_InvFeeAllocLwrFeePrcnt.AddRepeatField(this.m_hndPOST, nRepeat);
        }
      }
      this.m_SplitLawyerCharges.Clear();
      this.m_TransactionChangeID.AddField(this.m_hndPOST);
      this.m_QuickBooksID.AddField(this.m_hndPOST);
      this.m_LawyerRespID.AddField(this.m_hndPOST);
      if ((!this.m_LawyerAssignedID.m_bIsSet ? 1 : (this.m_LawyerAssignedID.Equals((object) 0) ? 1 : 0)) != 0)
        this.LwrAssignID = this.LwrRespID;
      this.m_LawyerAssignedID.AddField(this.m_hndPOST);
      if ((this.m_UseTaskBasedBilling.m_bIsSet || this.m_TypeOfLawIDTaskList.m_bIsSet || (this.m_BillUseFeeDiscount.m_bIsSet || this.m_DiscountFeePercent.m_bIsSet) || (this.m_BudgetFees.m_bIsSet || this.m_QuotedType.m_bIsSet || (this.m_QuotedAmount.m_bIsSet || this.m_BillApplyToEveryBill.m_bIsSet)) || (this.m_BillNumBills.m_bIsSet || this.m_BillMaxTotalFees.m_bIsSet || (this.m_BillingFrequency.m_bIsSet || this.m_FormatBilling.m_bIsSet) || (this.m_AutoAllocFees.m_bIsSet || this.m_BillCostOnlyOnMassBill.m_bIsSet || (this.m_AutoTransferTrustAtBilling.m_bIsSet || this.m_BillPayExistingInvOnTT.m_bIsSet))) || (this.m_BillAskForRetainer.m_bIsSet || this.m_BillAskForRetainer.m_bIsSet || (this.m_BillFeesLessThan.m_bIsSet || this.m_BillDisbsLessThan.m_bIsSet) || (this.m_BillChargesLessThan.m_bIsSet || this.m_BillARBalanceOver.m_bIsSet || (this.m_ProduceReminders.m_bIsSet || this.m_FormatReminder.m_bIsSet)) || (this.m_ChargeInterest.m_bIsSet || this.m_IntCalcFromGraceDate.m_bIsSet || (this.m_InterestStartDate.m_bIsSet || this.m_InterestGraceDays.m_bIsSet) || this.m_InterestRateUseDefault.m_bIsSet)) ? 1 : (this.m_InterestRate.m_bIsSet ? 1 : 0)) != 0)
        this.BillAllowSettingOverrides = true;
      this.m_AutoAllocFees.AddField(this.m_hndPOST);
      this.m_AutoTransferTrustAtBilling.AddField(this.m_hndPOST);
      this.m_BillCostOnlyOnMassBill.AddField(this.m_hndPOST);
      if (!this.m_BillingFrequency.m_bIsSet)
        this.Frequency = PLMatter.eFREQUENCY.Include;
      this.m_BillingFrequency.AddField(this.m_hndPOST);
      this.m_BudgetFees.AddField(this.m_hndPOST);
      this.m_IntCalcFromGraceDate.AddField(this.m_hndPOST);
      this.m_InterestStartDate.AddField(this.m_hndPOST);
      this.m_CollectionMemos.AddField(this.m_hndPOST);
      this.m_BillMemos.AddField(this.m_hndPOST);
      this.m_PreBillMemos.AddField(this.m_hndPOST);
      this.m_Contingency.AddField(this.m_hndPOST);
      this.m_CourtIdentifier.AddField(this.m_hndPOST);
      this.m_CrossReference.AddField(this.m_hndPOST);
      this.m_DateClosed.AddField(this.m_hndPOST);
      this.m_DateOpened.AddField(this.m_hndPOST);
      this.m_Description.AddField(this.m_hndPOST);
      this.m_DisbMarkupPct.AddField(this.m_hndPOST);
      this.m_DiscountFeePercent.AddField(this.m_hndPOST);
      this.m_DoNotChargeTAF.AddField(this.m_hndPOST);
      this.m_FileLocation.AddField(this.m_hndPOST);
      this.m_FormatBilling.AddField(this.m_hndPOST);
      this.m_FormatReminder.AddField(this.m_hndPOST);
      this.m_ChargeInterest.AddField(this.m_hndPOST);
      this.m_InterestGraceDays.AddField(this.m_hndPOST);
      this.m_InterestRate.AddField(this.m_hndPOST);
      this.m_InterestRateUseDefault.AddField(this.m_hndPOST);
      this.m_IsInactive.AddField(this.m_hndPOST);
      this.m_IsOnCreditHold.AddField(this.m_hndPOST);
      this.m_IsOnTrustHold.AddField(this.m_hndPOST);
      this.m_InterestUseSimple.AddField(this.m_hndPOST);
      this.m_Judge.AddField(this.m_hndPOST);
      this.m_Jurisdiction.AddField(this.m_hndPOST);
      this.m_Memos.AddField(this.m_hndPOST);
      this.m_Status.AddField(this.m_hndPOST);
      this.m_NickName.AddField(this.m_hndPOST);
      this.m_ProduceReminders.AddField(this.m_hndPOST);
      this.m_Exportable.AddField(this.m_hndPOST);
      this.m_QuotedAmount.AddField(this.m_hndPOST);
      this.m_QuotedType.AddField(this.m_hndPOST);
      this.m_RateAmount.AddField(this.m_hndPOST);
      this.m_RateID.AddField(this.m_hndPOST);
      this.m_OtherStaffID.AddField(this.m_hndPOST);
      if ((!this.m_TaskID.m_bIsSet ? 1 : (this.m_TaskID.nValue == 0 ? 1 : 0)) != 0)
        this.TaskNN = "BW";
      this.m_TaskID.AddField(this.m_hndPOST);
      this.m_DepartmentID.AddField(this.m_hndPOST);
      if ((!this.m_TypeOfLawID.m_bIsSet ? 1 : (this.m_TypeOfLawID.nValue.Equals(0) ? 1 : 0)) != 0)
      {
        this.TypeOfLawNN = "NA~";
        if (this.m_TypeOfLawID.nValue.Equals(0))
        {
          PLTypeOfLaw plTypeOfLaw = new PLTypeOfLaw();
          plTypeOfLaw.NickName = "NA~";
          plTypeOfLaw.Name = "Not Supplied";
          plTypeOfLaw.SendLast();
          this.TypeOfLawNN = "NA~";
        }
      }
      this.m_TypeOfLawID.AddField(this.m_hndPOST);
      this.m_ReferredBy.AddField(this.m_hndPOST);
      this.m_UseTaskBasedBilling.AddField(this.m_hndPOST);
      this.m_TypeOfLawIDTaskList.AddField(this.m_hndPOST);
      this.m_GSTCategory.AddField(this.m_hndPOST);
      this.m_GSTRateFees.AddField(this.m_hndPOST);
      this.m_GSTRateDisb.AddField(this.m_hndPOST);
      this.m_PSTRateFees.AddField(this.m_hndPOST);
      this.m_PSTRateDisb.AddField(this.m_hndPOST);
      this.m_UseUKLegalAid.AddField(this.m_hndPOST);
      this.m_BillMaxTotalFees.AddField(this.m_hndPOST);
      this.m_BillFeesLessThan.AddField(this.m_hndPOST);
      this.m_BillDisbsLessThan.AddField(this.m_hndPOST);
      this.m_BillChargesLessThan.AddField(this.m_hndPOST);
      this.m_BillARBalanceOver.AddField(this.m_hndPOST);
      this.m_BillApplyToEveryBill.AddField(this.m_hndPOST);
      this.m_BillNumBills.AddField(this.m_hndPOST);
      this.m_BillUseFeeDiscount.AddField(this.m_hndPOST);
      this.m_BillPayExistingInvOnTT.AddField(this.m_hndPOST);
      this.m_BillAskForRetainer.AddField(this.m_hndPOST);
      this.m_BillIgnoreBillSelections.AddField(this.m_hndPOST);
      this.m_BillDefBillSettingsNN.AddField(this.m_hndPOST);
      this.m_BillIncludeIfARBalOver.AddField(this.m_hndPOST);
      this.m_BillAllowSettingOverrides.AddField(this.m_hndPOST);
      for (int nRepeat = 1; nRepeat <= PLMatter.listContacts.Count; ++nRepeat)
      {
        this.m_ContactID.SetValue(PLMatter.listContacts[nRepeat - 1].ContactID);
        this.m_ContactID.AddRepeatField(this.m_hndPOST, nRepeat);
        if (PLMatter.listContacts[nRepeat - 1].RollID != 0)
        {
          this.m_RoleID.SetValue(PLMatter.listContacts[nRepeat - 1].RollID);
          this.m_RoleID.AddRepeatField(this.m_hndPOST, nRepeat);
        }
      }
      PLMatter.listContacts.Clear();
      this.m_ExternalID_1.AddField(this.m_hndPOST);
      this.m_ExternalID_2.AddField(this.m_hndPOST);
      this.GetLink().TablePOST_AddRecord(this.m_hndPOST);
      PLMatter plMatter = this;
      plMatter.m_lCounter = plMatter.m_lCounter + 1;
      if (this.m_lCounter < PLXMLData.m_nMaxCounter)
        return;
      this.Send();
    }

    public override void Clear()
    {
      this.ClientAddress.Clear();
      this.BillAddress1.Clear();
      this.BillAddress2.Clear();
      this.ClientName.Clear();
      this.BillName1.Clear();
      this.BillName2.Clear();
      this.BillPhone1.Clear();
      this.BillPhone2.Clear();
      this.m_ClientID.Clear();
      this.m_ClientContactID.Clear();
      this.m_ID.Clear();
      this.m_ClientNN.Clear();
      this.m_MajorClientNN.Clear();
      this.m_LawyerAssignedID.Clear();
      this.m_LawyerCLIntroID.Clear();
      this.m_LawyerMatIntroID.Clear();
      this.m_IntroLawyers.Clear();
      this.m_LawyerMatIntroPCT.Clear();
      this.m_LawyerRespID.Clear();
      this.m_TransactionChangeID.Clear();
      this.m_QuickBooksID.Clear();
      this.m_AutoAllocFees.Clear();
      this.m_AutoTransferTrustAtBilling.Clear();
      this.m_BillCostOnlyOnMassBill.Clear();
      this.m_BillingFrequency.Clear();
      this.m_BudgetFees.Clear();
      this.m_IntCalcFromGraceDate.Clear();
      this.m_InterestStartDate.Clear();
      this.m_ExceptionRates.Clear();
      this.m_InvFeeAllocLwrFeePrcnt.Clear();
      this.m_SplitLawyerCharges.Clear();
      this.m_ExceptionLwrRateAmount.Clear();
      this.m_ExceptionLwrRateID.Clear();
      this.m_CollectionMemos.Clear();
      this.m_BillMemos.Clear();
      this.m_PreBillMemos.Clear();
      this.m_Contingency.Clear();
      this.m_CourtIdentifier.Clear();
      this.m_CrossReference.Clear();
      this.m_DateClosed.Clear();
      this.m_DateOpened.Clear();
      this.m_Description.Clear();
      this.m_DisbMarkupPct.Clear();
      this.m_DiscountFeePercent.Clear();
      this.m_DoNotChargeTAF.Clear();
      this.m_FileLocation.Clear();
      this.m_FormatBilling.Clear();
      this.m_FormatReminder.Clear();
      this.m_ChargeInterest.Clear();
      this.m_InterestGraceDays.Clear();
      this.m_InterestRate.Clear();
      this.m_InterestRateUseDefault.Clear();
      this.m_IsInactive.Clear();
      this.m_IsOnCreditHold.Clear();
      this.m_IsOnTrustHold.Clear();
      this.m_InterestUseSimple.Clear();
      this.m_Judge.Clear();
      this.m_Jurisdiction.Clear();
      this.m_Memos.Clear();
      this.m_NickName.Clear();
      this.m_ProduceReminders.Clear();
      this.m_Exportable.Clear();
      this.m_QuotedAmount.Clear();
      this.m_QuotedType.Clear();
      this.m_RateAmount.Clear();
      this.m_RateID.Clear();
      this.m_OtherStaffID.Clear();
      this.m_TaskID.Clear();
      this.m_DepartmentID.Clear();
      this.m_TypeOfLawID.Clear();
      this.m_ReferredBy.Clear();
      this.m_Status.Clear();
      this.m_UseTaskBasedBilling.Clear();
      this.m_TypeOfLawIDTaskList.Clear();
      this.m_GSTCategory.Clear();
      this.m_GSTRateFees.Clear();
      this.m_GSTRateDisb.Clear();
      this.m_PSTRateFees.Clear();
      this.m_PSTRateDisb.Clear();
      this.m_UseUKLegalAid.Clear();
      this.m_BillMaxTotalFees.Clear();
      this.m_BillFeesLessThan.Clear();
      this.m_BillDisbsLessThan.Clear();
      this.m_BillChargesLessThan.Clear();
      this.m_BillARBalanceOver.Clear();
      this.m_BillApplyToEveryBill.Clear();
      this.m_BillNumBills.Clear();
      this.m_BillUseFeeDiscount.Clear();
      this.m_BillPayExistingInvOnTT.Clear();
      this.m_BillAskForRetainer.Clear();
      this.m_BillIgnoreBillSelections.Clear();
      this.m_BillDefBillSettingsNN.Clear();
      this.m_BillIncludeIfARBalOver.Clear();
      this.m_BillAllowSettingOverrides.Clear();
      this.m_TotalHours.Clear();
      this.m_TotalHoursBilled.Clear();
      this.m_TotalAR.Clear();
      this.m_TotalFees.Clear();
      this.m_TotalFeesBilled.Clear();
      this.m_TotalDisb.Clear();
      this.m_TotalDisbBilled.Clear();
      this.m_TotalReceipts.Clear();
      this.m_TotalReceiptsBilled.Clear();
      this.m_TrustBalance.Clear();
      this.m_TotalTaxFees.Clear();
      this.m_TotalTaxDisb.Clear();
      this.m_TrustBankAcctountIDArray.Clear();
      this.m_TrustAccountBalanceArray.Clear();
      PLMatter.listContacts.Clear();
    }

    public static void ClearMapExtID1toPLID()
    {
      if (PLMatter.m_MapExtID1toPLID == null)
        return;
      PLMatter.m_MapExtID1toPLID.Clear();
      PLMatter.m_MapExtID1toPLID = (Dictionary<string, int>) null;
    }

    public static void ClearMapExtID2toPLID()
    {
      if (PLMatter.m_MapExtID2toPLID == null)
        return;
      PLMatter.m_MapExtID2toPLID.Clear();
      PLMatter.m_MapExtID2toPLID = (Dictionary<string, int>) null;
    }

    public static void ClearMapIDtoContacts()
    {
      if (PLMatter.m_MapIDtoContacts == null)
        return;
      foreach (KeyValuePair<int, List<int>> mapIdtoContact in PLMatter.m_MapIDtoContacts)
        mapIdtoContact.Value.Clear();
      PLMatter.m_MapIDtoContacts.Clear();
      PLMatter.m_MapIDtoContacts = (Dictionary<int, List<int>>) null;
    }

    public static void ClearMapIDtoNN()
    {
      if (PLMatter.m_MapIDtoNN == null)
        return;
      PLMatter.m_MapIDtoNN.Clear();
      PLMatter.m_MapIDtoNN = (Dictionary<int, string>) null;
    }

    public static void ClearMapIDtoQuickBooksID()
    {
      if (PLMatter.m_MapIDtoQuickBooksID == null)
        return;
      PLMatter.m_MapIDtoQuickBooksID.Clear();
      PLMatter.m_MapIDtoQuickBooksID = (Dictionary<int, string>) null;
    }

    public static void ClearMapIDtoResp()
    {
      if (PLMatter.m_MapIDtoResp == null)
        return;
      PLMatter.m_MapIDtoResp.Clear();
      PLMatter.m_MapIDtoResp = (Dictionary<int, int>) null;
    }

    public static void ClearMapIDtoStatus()
    {
      if (PLMatter.m_MapIDtoStatus == null)
        return;
      PLMatter.m_MapIDtoStatus.Clear();
      PLMatter.m_MapIDtoStatus = (Dictionary<int, string>) null;
    }

    public static void ClearMapIDtoTypeofLaw()
    {
      if (PLMatter.m_MapIDtoTypeofLaw == null)
        return;
      PLMatter.m_MapIDtoTypeofLaw.Clear();
      PLMatter.m_MapIDtoTypeofLaw = (Dictionary<int, int>) null;
    }

    public static void ClearMapNNtoID()
    {
      if (PLMatter.m_MapNNtoID == null)
        return;
      PLMatter.m_MapNNtoID.Clear();
      PLMatter.m_MapNNtoID = (Dictionary<string, int>) null;
    }

    public double GetBalanceOfTrustAccount(int nRepeat)
    {
      return (this.m_TrustBankAcctountIDArray == null ? 0 : (this.m_TrustAccountBalanceArray != null ? 1 : 0)) == 0 ? 0.0 : ((nRepeat > this.m_TrustBankAcctountIDArray.Count || nRepeat > this.m_TrustAccountBalanceArray.Count ? 0 : (nRepeat != 0 ? 1 : 0)) != 0 ? Convert.ToDouble(this.m_TrustAccountBalanceArray[nRepeat - 1]) : 0.0);
    }

    public void GetContact(int nRepeat, ref int nContID, ref int nRoleId)
    {
      if ((nRepeat < 1 ? 1 : (nRepeat > PLMatter.listContacts.Count ? 1 : 0)) != 0)
      {
        nContID = 0;
        nRoleId = 0;
      }
      else
      {
        nContID = PLMatter.listContacts[nRepeat - 1].ContactID;
        nRoleId = PLMatter.listContacts[nRepeat - 1].RollID;
      }
    }

    public int GetContactCount()
    {
      return PLMatter.listContacts.Count;
    }

    public List<int> GetContactsArray()
    {
      List<int> intList = new List<int>();
      for (int index = 0; index < PLMatter.listContacts.Count; ++index)
        intList.Add(PLMatter.listContacts[1].ContactID);
      return intList;
    }

    public static List<int> GetContactsFromID(int nID)
    {
      List<int> intList;
      if (!nID.Equals(0))
      {
        if (!PLMatter.m_bRead)
          PLMatter.ReadTable();
        intList = !PLMatter.m_MapIDtoContacts.ContainsKey(nID) ? (List<int>) null : PLMatter.m_MapIDtoContacts[nID];
      }
      else
        intList = (List<int>) null;
      return intList;
    }

    public static int GetCount()
    {
      if (!PLMatter.m_bRead)
        PLMatter.ReadTable();
      return PLMatter.m_MapNNtoID.Count;
    }

    public override void GetExistingRecord()
    {
      this.Clear();
      this.ClientAddress.GetRecord(this.m_hndExisting);
      this.BillAddress1.GetRecord(this.m_hndExisting);
      this.BillAddress2.GetRecord(this.m_hndExisting);
      this.ClientName.GetRecord(this.m_hndExisting);
      this.BillName1.GetRecord(this.m_hndExisting);
      this.BillName2.GetRecord(this.m_hndExisting);
      this.BillPhone1.GetRecord(this.m_hndExisting);
      this.BillPhone2.GetRecord(this.m_hndExisting);
      this.m_ClientID.GetField(this.m_hndExisting);
      this.m_ClientNN.GetField(this.m_hndExisting);
      this.m_ClientContactID.GetField(this.m_hndExisting);
      this.m_ID.GetField(this.m_hndExisting);
      this.m_MajorClientNN.GetField(this.m_hndExisting);
      this.m_LawyerAssignedID.GetField(this.m_hndExisting);
      this.m_LawyerCLIntroID.GetField(this.m_hndExisting);
      int recurringFieldCount1 = this.GetLink().TableGET_RecordRecurringField_Count(this.m_hndExisting, "LawyerIDIntro");
      for (int nRepeat = 1; nRepeat <= recurringFieldCount1; ++nRepeat)
      {
        this.m_LawyerMatIntroID.GetRepeatField(this.m_hndExisting, nRepeat);
        this.m_LawyerMatIntroPCT.GetRepeatField(this.m_hndExisting, nRepeat);
        this.AddMattIntroLawyer(PLLawyer.GetNNFromID(this.m_LawyerMatIntroID.nValue), this.m_LawyerMatIntroPCT.dValue);
      }
      int recurringFieldCount2 = this.GetLink().TableGET_RecordRecurringField_Count(this.m_hndGET, "LawyerIDCharge");
      for (int nRepeat = 1; nRepeat <= recurringFieldCount2; ++nRepeat)
      {
        this.m_ExceptionLwrID.GetRepeatField(this.m_hndGET, nRepeat);
        this.m_ExceptionTaskID.GetRepeatField(this.m_hndGET, nRepeat);
        this.m_ExceptionLwrRateAmount.GetRepeatField(this.m_hndGET, nRepeat);
        this.m_ExceptionLwrRateID.GetRepeatField(this.m_hndGET, nRepeat);
        this.AddLawyerTaskException(this.m_ExceptionLwrID.nValue, this.m_ExceptionTaskID.nValue, this.m_ExceptionLwrRateAmount.dValue, this.m_ExceptionLwrRateID.nValue);
      }
      int recurringFieldCount3 = this.GetLink().TableGET_RecordRecurringField_Count(this.m_hndGET, "MatterLwrAllocLwrID");
      for (int nRepeat = 1; nRepeat <= recurringFieldCount3; ++nRepeat)
      {
        this.m_InvFeeAllocLwrID.GetRepeatField(this.m_hndGET, nRepeat);
        this.m_InvFeeAllocLwrFeePrcnt.GetRepeatField(this.m_hndGET, nRepeat);
        this.AddInvoiceFeeAllocationOverride(this.m_InvFeeAllocLwrID.nValue, this.m_InvFeeAllocLwrFeePrcnt.dValue);
      }
      this.m_LawyerRespID.GetField(this.m_hndExisting);
      this.m_TransactionChangeID.GetField(this.m_hndExisting);
      this.m_QuickBooksID.GetField(this.m_hndExisting);
      this.m_AutoAllocFees.GetField(this.m_hndExisting);
      this.m_AutoTransferTrustAtBilling.GetField(this.m_hndExisting);
      this.m_BillCostOnlyOnMassBill.GetField(this.m_hndExisting);
      this.m_BillingFrequency.GetField(this.m_hndExisting);
      this.m_BudgetFees.GetField(this.m_hndExisting);
      this.m_IntCalcFromGraceDate.GetField(this.m_hndExisting);
      this.m_InterestStartDate.GetField(this.m_hndExisting);
      this.m_CollectionMemos.GetField(this.m_hndExisting);
      this.m_BillMemos.GetField(this.m_hndExisting);
      this.m_PreBillMemos.GetField(this.m_hndExisting);
      this.m_Contingency.GetField(this.m_hndExisting);
      this.m_CourtIdentifier.GetField(this.m_hndExisting);
      this.m_CrossReference.GetField(this.m_hndExisting);
      this.m_DateClosed.GetField(this.m_hndExisting);
      this.m_DateOpened.GetField(this.m_hndExisting);
      this.m_Description.GetField(this.m_hndExisting);
      this.m_DisbMarkupPct.GetField(this.m_hndExisting);
      this.m_DiscountFeePercent.GetField(this.m_hndExisting);
      this.m_DoNotChargeTAF.GetField(this.m_hndExisting);
      this.m_FileLocation.GetField(this.m_hndExisting);
      this.m_FormatBilling.GetField(this.m_hndExisting);
      this.m_FormatReminder.GetField(this.m_hndExisting);
      this.m_ChargeInterest.GetField(this.m_hndExisting);
      this.m_InterestGraceDays.GetField(this.m_hndExisting);
      this.m_InterestRate.GetField(this.m_hndExisting);
      this.m_InterestRateUseDefault.GetField(this.m_hndExisting);
      this.m_IsInactive.GetField(this.m_hndExisting);
      this.m_IsOnCreditHold.GetField(this.m_hndExisting);
      this.m_IsOnTrustHold.GetField(this.m_hndExisting);
      this.m_InterestUseSimple.GetField(this.m_hndExisting);
      this.m_Judge.GetField(this.m_hndExisting);
      this.m_Jurisdiction.GetField(this.m_hndExisting);
      this.m_Memos.GetField(this.m_hndExisting);
      this.m_NickName.GetField(this.m_hndExisting);
      this.m_ProduceReminders.GetField(this.m_hndExisting);
      this.m_Exportable.GetField(this.m_hndExisting);
      this.m_QuotedAmount.GetField(this.m_hndExisting);
      this.m_QuotedType.GetField(this.m_hndExisting);
      this.m_RateAmount.GetField(this.m_hndExisting);
      this.m_RateID.GetField(this.m_hndExisting);
      this.m_OtherStaffID.GetField(this.m_hndExisting);
      this.m_TaskID.GetField(this.m_hndExisting);
      this.m_DepartmentID.GetField(this.m_hndExisting);
      this.m_TypeOfLawID.GetField(this.m_hndExisting);
      this.m_ReferredBy.GetField(this.m_hndExisting);
      this.m_Status.GetField(this.m_hndExisting);
      this.m_UseTaskBasedBilling.GetField(this.m_hndExisting);
      this.m_TypeOfLawIDTaskList.GetField(this.m_hndExisting);
      this.m_GSTCategory.GetField(this.m_hndExisting);
      this.m_GSTRateFees.GetField(this.m_hndExisting);
      this.m_GSTRateDisb.GetField(this.m_hndExisting);
      this.m_PSTRateFees.GetField(this.m_hndExisting);
      this.m_PSTRateDisb.GetField(this.m_hndExisting);
      this.m_UseUKLegalAid.GetField(this.m_hndExisting);
      this.m_BillMaxTotalFees.GetField(this.m_hndExisting);
      this.m_BillFeesLessThan.GetField(this.m_hndExisting);
      this.m_BillDisbsLessThan.GetField(this.m_hndExisting);
      this.m_BillChargesLessThan.GetField(this.m_hndExisting);
      this.m_BillARBalanceOver.GetField(this.m_hndExisting);
      this.m_BillApplyToEveryBill.GetField(this.m_hndExisting);
      this.m_BillNumBills.GetField(this.m_hndExisting);
      this.m_BillUseFeeDiscount.GetField(this.m_hndExisting);
      this.m_BillPayExistingInvOnTT.GetField(this.m_hndExisting);
      this.m_BillAskForRetainer.GetField(this.m_hndExisting);
      this.m_BillIgnoreBillSelections.GetField(this.m_hndExisting);
      this.m_BillDefBillSettingsNN.GetField(this.m_hndExisting);
      this.m_BillIncludeIfARBalOver.GetField(this.m_hndExisting);
      this.m_BillAllowSettingOverrides.GetField(this.m_hndExisting);
      this.m_TotalHours.GetField(this.m_hndExisting);
      this.m_TotalHoursBilled.GetField(this.m_hndExisting);
      this.m_TotalAR.GetField(this.m_hndExisting);
      this.m_TotalFees.GetField(this.m_hndExisting);
      this.m_TotalFeesBilled.GetField(this.m_hndExisting);
      this.m_TotalDisb.GetField(this.m_hndExisting);
      this.m_TotalDisbBilled.GetField(this.m_hndExisting);
      this.m_TotalReceipts.GetField(this.m_hndExisting);
      this.m_TotalReceiptsBilled.GetField(this.m_hndExisting);
      this.m_TrustBalance.GetField(this.m_hndExisting);
      this.m_TotalTaxFees.GetField(this.m_hndExisting);
      this.m_TotalTaxDisb.GetField(this.m_hndExisting);
      int recurringFieldCount4 = this.GetLink().TableGET_RecordRecurringField_Count(this.m_hndExisting, "ContactID");
      for (int nRepeat = 1; nRepeat <= recurringFieldCount4; ++nRepeat)
      {
        this.m_ContactID.GetRepeatField(this.m_hndExisting, nRepeat);
        this.m_RoleID.GetRepeatField(this.m_hndExisting, nRepeat);
        this.AddContact(this.m_ContactID.nValue, this.m_RoleID.nValue);
      }
    }

    public static int GetIDFromExtID1(string Key)
    {
      return !string.IsNullOrEmpty(Key) ? (PLMatter.m_MapExtID1toPLID == null ? 0 : (PLMatter.m_MapExtID1toPLID.ContainsKey(Key) ? Convert.ToInt32(PLMatter.m_MapExtID1toPLID[Key]) : 0)) : 0;
    }

    public static int GetIDFromExtID2(string Key)
    {
      return !string.IsNullOrEmpty(Key) ? (PLMatter.m_MapExtID2toPLID == null ? 0 : (PLMatter.m_MapExtID2toPLID.ContainsKey(Key) ? Convert.ToInt32(PLMatter.m_MapExtID2toPLID[Key]) : 0)) : 0;
    }

    public static int GetIDFromNN(string Key)
    {
      Key = Key.ToUpper();
      int num;
      if (!string.IsNullOrEmpty(Key))
      {
        if (!PLMatter.m_bRead)
          PLMatter.ReadTable();
        num = PLMatter.m_MapNNtoID == null ? 0 : (PLMatter.m_MapNNtoID.ContainsKey(Key) ? Convert.ToInt32(PLMatter.m_MapNNtoID[Key]) : 0);
      }
      else
        num = 0;
      return num;
    }

    public int GetIDOfTrustAccount(int nRepeat)
    {
      return (this.m_TrustBankAcctountIDArray == null ? 0 : (this.m_TrustAccountBalanceArray != null ? 1 : 0)) == 0 ? 0 : ((nRepeat > this.m_TrustBankAcctountIDArray.Count || nRepeat > this.m_TrustAccountBalanceArray.Count ? 0 : (nRepeat != 0 ? 1 : 0)) != 0 ? Convert.ToInt32(this.m_TrustBankAcctountIDArray[nRepeat - 1]) : 0);
    }

    public static string GetNextMatterNN()
    {
      string empty = string.Empty;
      object szNextMatter = new object();
      PLLink.GetLink().GetNextAvailFirmMatter(ref szNextMatter);
      return szNextMatter.ToString();
    }

    public static string GetNextMatterNN(int nClientID)
    {
      string empty = string.Empty;
      object szNextMatter = new object();
      PLLink.GetLink().GetNextAvailClientMatter(nClientID, ref szNextMatter);
      return szNextMatter.ToString();
    }

    public static string GetNNFromID(int nID)
    {
      if (!PLMatter.m_bRead)
        PLMatter.ReadTable();
      return PLMatter.m_MapIDtoNN.ContainsKey(nID) ? PLMatter.m_MapIDtoNN[nID].ToString() : string.Empty;
    }

    public int GetNumberOfTrustAccounts()
    {
      return this.m_TrustBankAcctountIDArray != null ? this.m_TrustBankAcctountIDArray.Count : 0;
    }

    public static int GetPLIDFromQBID(string sQBID)
    {
      int num1;
      if (!sQBID.Equals(""))
      {
        if (!PLMatter.m_bRead)
          PLMatter.ReadTable();
        if (PLMatter.m_MapIDtoQuickBooksID == null)
          num1 = 0;
        else if (PLMatter.m_MapIDtoQuickBooksID.ContainsValue(sQBID))
        {
          int num2 = 0;
          Dictionary<int, string>.Enumerator enumerator = PLMatter.m_MapIDtoQuickBooksID.GetEnumerator();
          while (enumerator.MoveNext())
          {
            Dictionary<int, string> idtoQuickBooksId = PLMatter.m_MapIDtoQuickBooksID;
            KeyValuePair<int, string> current = enumerator.Current;
            if (idtoQuickBooksId[current.Key].ToUpper().CompareTo(sQBID.ToUpper()) == 0)
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

    public static string GetQuickBooksIDFromMattID(int Key)
    {
      string str;
      if (!Key.Equals(0))
      {
        if (!PLMatter.m_bRead)
          PLMatter.ReadTable();
        str = PLMatter.m_MapIDtoQuickBooksID == null ? string.Empty : (PLMatter.m_MapIDtoQuickBooksID.ContainsKey(Key) ? Convert.ToString(PLMatter.m_MapIDtoQuickBooksID[Key]) : string.Empty);
      }
      else
        str = string.Empty;
      return str;
    }

    public override void GetRecord()
    {
      this.Clear();
      if ((int) this.m_hndGET == 0)
        this.m_hndGET = this.GetLink().TableGET_CreateHandle(this.m_sTableName, 0, 0, 0U);
      this.ClientAddress.GetRecord(this.m_hndGET);
      this.BillAddress1.GetRecord(this.m_hndGET);
      this.BillAddress2.GetRecord(this.m_hndGET);
      this.ClientName.GetRecord(this.m_hndGET);
      this.BillName1.GetRecord(this.m_hndGET);
      this.BillName2.GetRecord(this.m_hndGET);
      this.BillPhone1.GetRecord(this.m_hndGET);
      this.BillPhone2.GetRecord(this.m_hndGET);
      this.m_ClientID.GetField(this.m_hndGET);
      this.m_ClientContactID.GetField(this.m_hndGET);
      this.m_ClientNN.GetField(this.m_hndGET);
      this.m_ID.GetField(this.m_hndGET);
      this.m_MajorClientNN.GetField(this.m_hndGET);
      this.m_LawyerAssignedID.GetField(this.m_hndGET);
      this.m_LawyerCLIntroID.GetField(this.m_hndGET);
      int recurringFieldCount1 = this.GetLink().TableGET_RecordRecurringField_Count(this.m_hndGET, "LawyerIDIntro");
      for (int nRepeat = 1; nRepeat <= recurringFieldCount1; ++nRepeat)
      {
        this.m_LawyerMatIntroID.GetRepeatField(this.m_hndGET, nRepeat);
        this.m_LawyerMatIntroPCT.GetRepeatField(this.m_hndGET, nRepeat);
        this.AddMattIntroLawyer(this.m_LawyerMatIntroID.nValue, this.m_LawyerMatIntroPCT.dValue);
      }
      int recurringFieldCount2 = this.GetLink().TableGET_RecordRecurringField_Count(this.m_hndGET, "LawyerIDCharge");
      for (int nRepeat = 1; nRepeat <= recurringFieldCount2; ++nRepeat)
      {
        this.m_ExceptionLwrID.GetRepeatField(this.m_hndGET, nRepeat);
        this.m_ExceptionTaskID.GetRepeatField(this.m_hndGET, nRepeat);
        this.m_ExceptionLwrRateAmount.GetRepeatField(this.m_hndGET, nRepeat);
        this.m_ExceptionLwrRateID.GetRepeatField(this.m_hndGET, nRepeat);
        this.AddLawyerTaskException(this.m_ExceptionLwrID.nValue, this.m_ExceptionTaskID.nValue, this.m_ExceptionLwrRateAmount.dValue, this.m_ExceptionLwrRateID.nValue);
      }
      int recurringFieldCount3 = this.GetLink().TableGET_RecordRecurringField_Count(this.m_hndGET, "MatterLwrAllocLwrID");
      for (int nRepeat = 1; nRepeat <= recurringFieldCount3; ++nRepeat)
      {
        this.m_InvFeeAllocLwrID.GetRepeatField(this.m_hndGET, nRepeat);
        this.m_InvFeeAllocLwrFeePrcnt.GetRepeatField(this.m_hndGET, nRepeat);
        this.AddInvoiceFeeAllocationOverride(this.m_InvFeeAllocLwrID.nValue, this.m_InvFeeAllocLwrFeePrcnt.dValue);
      }
      this.m_LawyerRespID.GetField(this.m_hndGET);
      this.m_TransactionChangeID.GetField(this.m_hndGET);
      this.m_QuickBooksID.GetField(this.m_hndGET);
      this.m_AutoAllocFees.GetField(this.m_hndGET);
      this.m_AutoTransferTrustAtBilling.GetField(this.m_hndGET);
      this.m_BillCostOnlyOnMassBill.GetField(this.m_hndGET);
      this.m_BillingFrequency.GetField(this.m_hndGET);
      this.m_BudgetFees.GetField(this.m_hndGET);
      this.m_IntCalcFromGraceDate.GetField(this.m_hndGET);
      this.m_InterestStartDate.GetField(this.m_hndGET);
      this.m_CollectionMemos.GetField(this.m_hndGET);
      this.m_BillMemos.GetField(this.m_hndGET);
      this.m_PreBillMemos.GetField(this.m_hndGET);
      this.m_Contingency.GetField(this.m_hndGET);
      this.m_CourtIdentifier.GetField(this.m_hndGET);
      this.m_CrossReference.GetField(this.m_hndGET);
      this.m_DateClosed.GetField(this.m_hndGET);
      this.m_DateOpened.GetField(this.m_hndGET);
      this.m_Description.GetField(this.m_hndGET);
      this.m_DisbMarkupPct.GetField(this.m_hndGET);
      this.m_DiscountFeePercent.GetField(this.m_hndGET);
      this.m_DoNotChargeTAF.GetField(this.m_hndGET);
      this.m_FileLocation.GetField(this.m_hndGET);
      this.m_FormatBilling.GetField(this.m_hndGET);
      this.m_FormatReminder.GetField(this.m_hndGET);
      this.m_ChargeInterest.GetField(this.m_hndGET);
      this.m_InterestGraceDays.GetField(this.m_hndGET);
      this.m_InterestRate.GetField(this.m_hndGET);
      this.m_InterestRateUseDefault.GetField(this.m_hndGET);
      this.m_IsInactive.GetField(this.m_hndGET);
      this.m_IsOnCreditHold.GetField(this.m_hndGET);
      this.m_IsOnTrustHold.GetField(this.m_hndGET);
      this.m_InterestUseSimple.GetField(this.m_hndGET);
      this.m_Judge.GetField(this.m_hndGET);
      this.m_Jurisdiction.GetField(this.m_hndGET);
      this.m_Memos.GetField(this.m_hndGET);
      this.m_NickName.GetField(this.m_hndGET);
      this.m_ProduceReminders.GetField(this.m_hndGET);
      this.m_Exportable.GetField(this.m_hndGET);
      this.m_QuotedAmount.GetField(this.m_hndGET);
      this.m_QuotedType.GetField(this.m_hndGET);
      this.m_RateAmount.GetField(this.m_hndGET);
      this.m_RateID.GetField(this.m_hndGET);
      this.m_OtherStaffID.GetField(this.m_hndGET);
      this.m_TaskID.GetField(this.m_hndGET);
      this.m_DepartmentID.GetField(this.m_hndGET);
      this.m_TypeOfLawID.GetField(this.m_hndGET);
      this.m_ReferredBy.GetField(this.m_hndGET);
      this.m_Status.GetField(this.m_hndGET);
      this.m_UseTaskBasedBilling.GetField(this.m_hndGET);
      this.m_TypeOfLawIDTaskList.GetField(this.m_hndGET);
      this.m_GSTCategory.GetField(this.m_hndGET);
      this.m_GSTRateFees.GetField(this.m_hndGET);
      this.m_GSTRateDisb.GetField(this.m_hndGET);
      this.m_PSTRateFees.GetField(this.m_hndGET);
      this.m_PSTRateDisb.GetField(this.m_hndGET);
      this.m_UseUKLegalAid.GetField(this.m_hndGET);
      this.m_BillMaxTotalFees.GetField(this.m_hndGET);
      this.m_BillFeesLessThan.GetField(this.m_hndGET);
      this.m_BillDisbsLessThan.GetField(this.m_hndGET);
      this.m_BillChargesLessThan.GetField(this.m_hndGET);
      this.m_BillARBalanceOver.GetField(this.m_hndGET);
      this.m_BillApplyToEveryBill.GetField(this.m_hndGET);
      this.m_BillNumBills.GetField(this.m_hndGET);
      this.m_BillUseFeeDiscount.GetField(this.m_hndGET);
      this.m_BillPayExistingInvOnTT.GetField(this.m_hndGET);
      this.m_BillAskForRetainer.GetField(this.m_hndGET);
      this.m_BillIgnoreBillSelections.GetField(this.m_hndGET);
      this.m_BillDefBillSettingsNN.GetField(this.m_hndGET);
      this.m_BillIncludeIfARBalOver.GetField(this.m_hndGET);
      this.m_BillAllowSettingOverrides.GetField(this.m_hndGET);
      this.m_TotalHours.GetField(this.m_hndGET);
      this.m_TotalHoursBilled.GetField(this.m_hndGET);
      this.m_TotalAR.GetField(this.m_hndGET);
      this.m_TotalFees.GetField(this.m_hndGET);
      this.m_TotalFeesBilled.GetField(this.m_hndGET);
      this.m_TotalDisb.GetField(this.m_hndGET);
      this.m_TotalDisbBilled.GetField(this.m_hndGET);
      this.m_TotalReceipts.GetField(this.m_hndGET);
      this.m_TotalReceiptsBilled.GetField(this.m_hndGET);
      this.m_TrustBalance.GetField(this.m_hndGET);
      this.m_TotalTaxFees.GetField(this.m_hndGET);
      this.m_TotalTaxDisb.GetField(this.m_hndGET);
      int recurringFieldCount4 = this.GetLink().TableGET_RecordRecurringField_Count(this.m_hndGET, "ContactID");
      for (int nRepeat = 1; nRepeat <= recurringFieldCount4; ++nRepeat)
      {
        this.m_ContactID.GetRepeatField(this.m_hndGET, nRepeat);
        this.m_RoleID.GetRepeatField(this.m_hndGET, nRepeat);
        this.AddContact(this.m_ContactID.nValue, this.m_RoleID.nValue);
      }
    }

    public static int GetRespFromMattID(int Key)
    {
      int num;
      if (!Key.Equals(0))
      {
        if (!PLMatter.m_bRead)
          PLMatter.ReadTable();
        num = PLMatter.m_MapIDtoResp == null ? 0 : (PLMatter.m_MapIDtoResp.ContainsKey(Key) ? Convert.ToInt32(PLMatter.m_MapIDtoResp[Key]) : 0);
      }
      else
        num = 0;
      return num;
    }

    public static string GetStatusFromMattID(int Key)
    {
      string str;
      if (!Key.Equals(0))
      {
        if (!PLMatter.m_bRead)
          PLMatter.ReadTable();
        str = PLMatter.m_MapIDtoStatus == null ? string.Empty : (PLMatter.m_MapIDtoStatus.ContainsKey(Key) ? PLMatter.m_MapIDtoStatus[Key].ToString() : string.Empty);
      }
      else
        str = string.Empty;
      return str;
    }

    public static int GetTypeofLawFromMattID(int Key)
    {
      int num;
      if (!Key.Equals(0))
      {
        if (!PLMatter.m_bRead)
          PLMatter.ReadTable();
        num = PLMatter.m_MapIDtoTypeofLaw == null ? 0 : (PLMatter.m_MapIDtoTypeofLaw.ContainsKey(Key) ? Convert.ToInt32(PLMatter.m_MapIDtoTypeofLaw[Key]) : 0);
      }
      else
        num = 0;
      return num;
    }

    protected override void Initialize()
    {
      this.m_sTableName = "Matter";
      PLMatter.m_nMatterNN = 0;
      this.ClientAddress = new PLAddress(PLAddress.eAddType.CLNT_onMAT);
      this.BillAddress1 = new PLAddress(PLAddress.eAddType.MAT_BILL1);
      this.BillAddress2 = new PLAddress(PLAddress.eAddType.MAT_BILL2);
      this.ClientName = new PLName(PLName.eNameType.CLNT_onMAT);
      this.BillName1 = new PLName(PLName.eNameType.MAT_BILL1);
      this.BillName2 = new PLName(PLName.eNameType.MAT_BILL2);
      this.BillPhone1 = new PLPhone(PLPhone.ePhoneType.MAT_BILL1);
      this.BillPhone2 = new PLPhone(PLPhone.ePhoneType.MAT_BILL2);
      this.ClientPhone = new PLPhone(PLPhone.ePhoneType.MatCLIENT);
      this.m_ClientID = new CPostItem(CPostItem.DataType.LONG, "ClientID");
      this.m_ClientContactID = new CPostItem(CPostItem.DataType.LONG, "ClientPersonContactID");
      this.m_MajorClientID = new CPostItem(CPostItem.DataType.LONG, "ClientIDMajor");
      this.m_ID = new CPostItem(CPostItem.DataType.LONG, "MatterID");
      this.m_ClientNN = new CPostItem(CPostItem.DataType.STRING, "ClientNum");
      this.m_MajorClientNN = new CPostItem(CPostItem.DataType.STRING, "ClientMajorNN");
      this.m_LawyerAssignedID = new CPostItem(CPostItem.DataType.LONG, "LawyerIDAssigned");
      this.m_LawyerCLIntroID = new CPostItem(CPostItem.DataType.LONG, "LawyerIDClient");
      this.m_IntroLawyers = new List<PLMatter.IntroLawyer>();
      this.m_LawyerMatIntroID = new CPostItem(CPostItem.DataType.RepeatLONG, "LawyerIDIntro");
      this.m_LawyerMatIntroPCT = new CPostItem(CPostItem.DataType.RepeatDOUBLE, "LawyerIntroPercent");
      this.m_LawyerRespID = new CPostItem(CPostItem.DataType.LONG, "LawyerIDResponsible");
      this.m_TransactionChangeID = new CPostItem(CPostItem.DataType.LONG, "MatterTransactionModified");
      this.m_QuickBooksID = new CPostItem(CPostItem.DataType.STRING, "MatterQuickBooksID");
      this.m_AutoAllocFees = new CPostItem(CPostItem.DataType.BOOL, "MatterAutoFeeAllocation");
      this.m_AutoTransferTrustAtBilling = new CPostItem(CPostItem.DataType.BOOL, "MatterAutoTransferTrustAtBilling");
      this.m_BillCostOnlyOnMassBill = new CPostItem(CPostItem.DataType.BOOL, "MatterBillCostOnlyOnMassBill");
      this.m_BillingFrequency = new CPostItem(CPostItem.DataType.LONG, "MatterBillingFrequency");
      this.m_BudgetFees = new CPostItem(CPostItem.DataType.DOUBLE, "MatterBudgetFees");
      this.m_IntCalcFromGraceDate = new CPostItem(CPostItem.DataType.BOOL, "MatterCalcFromGraceDate");
      this.m_InterestStartDate = new CPostItem(CPostItem.DataType.LONG, "MatterInterestStartDate");
      this.m_ExceptionRates = new List<PLMatter.LawyerExceptionRate>();
      this.m_ExceptionLwrID = new CPostItem(CPostItem.DataType.RepeatLONG, "LawyerIDCharge");
      this.m_ExceptionTaskID = new CPostItem(CPostItem.DataType.RepeatLONG, "MatterSplTaskID");
      this.m_ExceptionLwrRateAmount = new CPostItem(CPostItem.DataType.RepeatDOUBLE, "MatterChargeRateAmount");
      this.m_ExceptionLwrRateID = new CPostItem(CPostItem.DataType.RepeatDOUBLE, "LawyerRateID");
      this.m_InvFeeAllocLwrID = new CPostItem(CPostItem.DataType.RepeatDOUBLE, "MatterLwrAllocLwrID");
      this.m_SplitLawyerCharges = new List<PLMatter.LawyerFeeSplit>();
      this.m_InvFeeAllocLwrFeePrcnt = new CPostItem(CPostItem.DataType.RepeatDOUBLE, "MatterChrargeFeeAllocation");
      this.m_CollectionMemos = new CPostItem(CPostItem.DataType.STRING, "MatterCollectionMemos");
      this.m_BillMemos = new CPostItem(CPostItem.DataType.STRING, "MatterBillMemos");
      this.m_PreBillMemos = new CPostItem(CPostItem.DataType.STRING, "MatterPreBillMemos");
      this.m_Contingency = new CPostItem(CPostItem.DataType.BOOL, "MatterContingency");
      this.m_CourtIdentifier = new CPostItem(CPostItem.DataType.STRING, "MatterCourtNumber");
      this.m_CrossReference = new CPostItem(CPostItem.DataType.STRING, "MatterCrossReference");
      this.m_DateClosed = new CPostItem(CPostItem.DataType.LONG, "MatterDateClosed");
      this.m_DateOpened = new CPostItem(CPostItem.DataType.LONG, "MatterDateOpened");
      this.m_Description = new CPostItem(CPostItem.DataType.STRING, "MatterDescription");
      this.m_DisbMarkupPct = new CPostItem(CPostItem.DataType.DOUBLE, "MatterDisbMarkupPct");
      this.m_DiscountFeePercent = new CPostItem(CPostItem.DataType.DOUBLE, "MatterDiscountFeePercent");
      this.m_DoNotChargeTAF = new CPostItem(CPostItem.DataType.BOOL, "  MatterDoNotChargeTAF");
      this.m_FileLocation = new CPostItem(CPostItem.DataType.STRING, "MatterFileLocation");
      this.m_FormatBilling = new CPostItem(CPostItem.DataType.STRING, "MatterFormatBilling");
      this.m_FormatReminder = new CPostItem(CPostItem.DataType.STRING, "MatterFormatReminder");
      this.m_ChargeInterest = new CPostItem(CPostItem.DataType.BOOL, "MatterInterestCharge");
      this.m_InterestGraceDays = new CPostItem(CPostItem.DataType.LONG, "MatterInterestGraceDays");
      this.m_InterestRate = new CPostItem(CPostItem.DataType.DOUBLE, "MatterInterestRatePercent");
      this.m_InterestRateUseDefault = new CPostItem(CPostItem.DataType.BOOL, "MatterInterestRateUseDefault");
      this.m_IsInactive = new CPostItem(CPostItem.DataType.BOOL, "MatterIsInactive");
      this.m_IsOnCreditHold = new CPostItem(CPostItem.DataType.BOOL, "MatterIsOnCreditHold");
      this.m_IsOnTrustHold = new CPostItem(CPostItem.DataType.BOOL, "MatterIsOnTrustHold");
      this.m_InterestUseSimple = new CPostItem(CPostItem.DataType.BOOL, "MatterIsSimpleInterest");
      this.m_Judge = new CPostItem(CPostItem.DataType.STRING, "MatterJudge");
      this.m_Jurisdiction = new CPostItem(CPostItem.DataType.STRING, "MatterJurisdiction");
      this.m_Memos = new CPostItem(CPostItem.DataType.STRING, "MatterMemos");
      this.m_NickName = new CPostItem(CPostItem.DataType.STRING, "MatterNumber");
      this.m_ProduceReminders = new CPostItem(CPostItem.DataType.BOOL, "MatterProduceReminders");
      this.m_Exportable = new CPostItem(CPostItem.DataType.BOOL, "MatterExportable");
      this.m_QuotedAmount = new CPostItem(CPostItem.DataType.DOUBLE, "MatterQuotedAmount");
      this.m_QuotedType = new CPostItem(CPostItem.DataType.LONG, "MatterQuotedType");
      this.m_RateAmount = new CPostItem(CPostItem.DataType.DOUBLE, "MatterRateAmount");
      this.m_RateID = new CPostItem(CPostItem.DataType.LONG, "RateID");
      this.m_OtherStaffID = new CPostItem(CPostItem.DataType.LONG, "OtherStaffID");
      this.m_TaskID = new CPostItem(CPostItem.DataType.LONG, "TaskID");
      this.m_DepartmentID = new CPostItem(CPostItem.DataType.LONG, "DepartmentID");
      this.m_TypeOfLawID = new CPostItem(CPostItem.DataType.LONG, "TypeOfLawID");
      this.m_ReferredBy = new CPostItem(CPostItem.DataType.STRING, "MatterReferredBy");
      this.m_Status = new CPostItem(CPostItem.DataType.LONG, "MatterStatus");
      this.m_UseTaskBasedBilling = new CPostItem(CPostItem.DataType.BOOL, "MatterTaskBasedBilling");
      this.m_TypeOfLawIDTaskList = new CPostItem(CPostItem.DataType.LONG, "TypeOfLawIDTaskList");
      this.m_GSTCategory = new CPostItem(CPostItem.DataType.LONG, "MatterTaxFedCategory");
      this.m_GSTRateFees = new CPostItem(CPostItem.DataType.DOUBLE, "MatterTaxFedFeesPercent");
      this.m_GSTRateDisb = new CPostItem(CPostItem.DataType.DOUBLE, "MatterTaxFedDisbPercent");
      this.m_PSTRateFees = new CPostItem(CPostItem.DataType.DOUBLE, "MatterTaxStateFeesPercent");
      this.m_PSTRateDisb = new CPostItem(CPostItem.DataType.DOUBLE, "MatterTaxStateDisbPercent");
      this.m_UseUKLegalAid = new CPostItem(CPostItem.DataType.BOOL, "MatterUKLegalAid");
      this.m_ContactID = new CPostItem(CPostItem.DataType.RepeatLONG, "ContactID");
      this.m_RoleID = new CPostItem(CPostItem.DataType.RepeatLONG, "ContactRoleID");
      this.m_BillMaxTotalFees = new CPostItem(CPostItem.DataType.DOUBLE, "MattBillMaxTotalFees");
      this.m_BillFeesLessThan = new CPostItem(CPostItem.DataType.DOUBLE, "MattBillFeesLessThan");
      this.m_BillDisbsLessThan = new CPostItem(CPostItem.DataType.DOUBLE, "MattBillDisbsLessThan");
      this.m_BillChargesLessThan = new CPostItem(CPostItem.DataType.DOUBLE, "MattBillChargesLessThan");
      this.m_BillARBalanceOver = new CPostItem(CPostItem.DataType.DOUBLE, "MattBillARBalanceOver");
      this.m_BillApplyToEveryBill = new CPostItem(CPostItem.DataType.BOOL, "MattBillApplyToEveryBill");
      this.m_BillNumBills = new CPostItem(CPostItem.DataType.LONG, "MattBillNumBills");
      this.m_BillUseFeeDiscount = new CPostItem(CPostItem.DataType.BOOL, "MattBillUseFeeDiscount");
      this.m_BillPayExistingInvOnTT = new CPostItem(CPostItem.DataType.BOOL, "MattBillPayExistingInvOnTT");
      this.m_BillAskForRetainer = new CPostItem(CPostItem.DataType.BOOL, "MattBillAskForRetainer");
      this.m_BillIgnoreBillSelections = new CPostItem(CPostItem.DataType.BOOL, "MattBillIgnoreBillSelections");
      this.m_BillDefBillSettingsNN = new CPostItem(CPostItem.DataType.STRING, "MattBillDefBillSettingsNN");
      this.m_BillIncludeIfARBalOver = new CPostItem(CPostItem.DataType.BOOL, "MattBillIncludeIfARBalOver");
      this.m_BillAllowSettingOverrides = new CPostItem(CPostItem.DataType.BOOL, "MattBillAllowSettingOverrides");
      PLMatter.listContacts = new List<PLMatter.MatterContact>();
      this.m_ExternalID_1 = new CPostItem(CPostItem.DataType.STRING, "ExternalID_1");
      this.m_ExternalID_2 = new CPostItem(CPostItem.DataType.STRING, "ExternalID_2");
      this.m_TotalHours = new CPostItem(CPostItem.DataType.DOUBLE, "MatterTotalHours");
      this.m_TotalHoursBilled = new CPostItem(CPostItem.DataType.DOUBLE, "MatterTotalHoursBilled");
      this.m_TotalAR = new CPostItem(CPostItem.DataType.DOUBLE, "MatterTotalAR");
      this.m_TotalFees = new CPostItem(CPostItem.DataType.DOUBLE, "MatterTotalFees");
      this.m_TotalFeesBilled = new CPostItem(CPostItem.DataType.DOUBLE, "MatterTotalFeesBilled");
      this.m_TotalDisb = new CPostItem(CPostItem.DataType.DOUBLE, "MatterTotalDisb");
      this.m_TotalDisbBilled = new CPostItem(CPostItem.DataType.DOUBLE, "MatterTotalDisbBilled");
      this.m_TotalReceipts = new CPostItem(CPostItem.DataType.DOUBLE, "MatterTotalReceipts");
      this.m_TotalReceiptsBilled = new CPostItem(CPostItem.DataType.DOUBLE, "MatterTotalReceiptsBilled");
      this.m_TrustBalance = new CPostItem(CPostItem.DataType.DOUBLE, "MatterTrustBalance");
      this.m_TotalTaxFees = new CPostItem(CPostItem.DataType.DOUBLE, "MatterTotalTaxFees");
      this.m_TotalTaxDisb = new CPostItem(CPostItem.DataType.DOUBLE, "MatterTotalTaxDisb");
      this.m_TrustBankAcctountIDArray = new List<int>();
      this.m_TrustAccountBalanceArray = new List<double>();
      this.m_TrustBankAcctID = new CPostItem(CPostItem.DataType.RepeatLONG, "TrustBankAcctID");
      this.m_TrustBankBalance = new CPostItem(CPostItem.DataType.RepeatDOUBLE, "TrustBankBalance");
    }

    public bool IsContactAssociated(int nContactID)
    {
      int index = 0;
      while (true)
      {
        if (index < PLMatter.listContacts.Count)
        {
          if (nContactID != PLMatter.listContacts[index].ContactID)
            ++index;
          else
            goto label_4;
        }
        else
          break;
      }
      bool flag = false;
      goto label_6;
label_4:
      flag = true;
label_6:
      return flag;
    }

    public override string MakeNN(bool bSetNickName)
    {
      throw new NotImplementedException();
    }

    private static void ReadTable()
    {
      if (PLMatter.m_bRead)
        return;
      uint num1 = 0;
      object szValue = new object();
      int num2 = 0;
      string empty = string.Empty;
      uint createHandle = PLLink.GetLink().TableGET_CreateHandle("Matter", 0, 0, 0U);
      PLLink.GetLink().TableGET_AddFilter(createHandle, "MatterStatus", "LTE", "1", 1);
      PLLink.GetLink().TableGET_AddDirective(createHandle, "FieldList", "MatterID|MatterNumber|TypeOfLawID|LawyerIDResponsible|ContactID|MatterStatus|MatterIsInactive|MatterQuickBooksID");
      while (PLLink.GetLink().TableGET_GetNextRecord(createHandle) == 0)
      {
        PLLink.GetLink().TableGET_RecordField_ValueString(createHandle, "MatterNumber", "", ref szValue);
        string Key = szValue.ToString().ToUpper().Trim();
        int recordFieldValueI32_1 = PLLink.GetLink().TableGET_RecordField_ValueI32(createHandle, "MatterID");
        PLMatter.AddMapNNtoID(Key, recordFieldValueI32_1);
        PLMatter.AddMapIDtoNN(recordFieldValueI32_1, Key);
        int recordFieldValueI32_2 = PLLink.GetLink().TableGET_RecordField_ValueI32(createHandle, "TypeOfLawID");
        PLMatter.AddMapIDtoTypeofLaw(recordFieldValueI32_1, recordFieldValueI32_2);
        int recordFieldValueI32_3 = PLLink.GetLink().TableGET_RecordField_ValueI32(createHandle, "LawyerIDResponsible");
        PLMatter.AddMapIDtoResp(recordFieldValueI32_1, recordFieldValueI32_3);
        string str = PLLink.GetLink().TableGET_RecordField_ValueI32(createHandle, "MatterStatus").Equals(0) ? (!PLLink.GetLink().TableGET_RecordField_ValueBOOL(createHandle, "MatterIsInactive").Equals(0) ? "Inactive" : "Active") : "Arcived";
        PLMatter.AddMapIDtoStatus(recordFieldValueI32_1, str);
        num2 = PLLink.GetLink().TableGET_RecordField_ValueString(createHandle, "MatterQuickBooksID", "", ref szValue);
        PLMatter.AddMapIDtoQuickBooksID(recordFieldValueI32_1, szValue.ToString());
        int recurringFieldCount = PLLink.GetLink().TableGET_RecordRecurringField_Count(createHandle, "ContactID");
        for (int nIndex = 1; nIndex <= recurringFieldCount; ++nIndex)
        {
          int recurringFieldValueI32 = PLLink.GetLink().TableGET_RecordRecurringField_ValueI32(createHandle, "ContactID", nIndex);
          PLMatter.AddMapIDtoContacts(recordFieldValueI32_1, recurringFieldValueI32);
        }
      }
      PLLink.GetLink().TableGET_CloseHandle(createHandle);
      num1 = 0U;
      PLMatter.m_bRead = true;
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
            this.GetLink().TablePOST_ResultDataField_String(this.m_hndPOST, this.m_NickName.sLinkName, empty2, ref szValue);
            PLMatter.AddMapIDtoNN(int32, szValue.ToString().ToUpper());
            PLMatter.AddMapNNtoID(szValue.ToString().ToUpper(), int32);
            this.GetLink().TablePOST_ResultDataField_String(this.m_hndPOST, this.m_ExternalID_1.sLinkName, empty2, ref szValue);
            PLMatter.AddMapExtID1toPLID(szValue.ToString(), int32);
            this.GetLink().TablePOST_ResultDataField_String(this.m_hndPOST, this.m_ExternalID_2.sLinkName, empty2, ref szValue);
            PLMatter.AddMapExtID2toPLID(szValue.ToString(), int32);
            this.GetLink().TablePOST_ResultDataField_String(this.m_hndPOST, this.m_TypeOfLawID.sLinkName, empty2, ref szValue);
            if (!szValue.ToString().Equals(""))
              PLMatter.AddMapIDtoTypeofLaw(int32, Convert.ToInt32(szValue));
            this.GetLink().TablePOST_ResultDataField_String(this.m_hndPOST, this.m_Status.sLinkName, empty2, ref szValue);
            int num = szValue.ToString().Equals("") ? 0 : Convert.ToInt32(szValue);
            string str7;
            if (!num.Equals(0))
            {
              str7 = "Archived";
            }
            else
            {
              this.GetLink().TablePOST_ResultDataField_String(this.m_hndPOST, this.m_IsInactive.sLinkName, empty2, ref szValue);
              num = !string.IsNullOrEmpty(szValue.ToString().Trim()) ? Convert.ToInt32(szValue) : 0;
              str7 = !num.Equals(0) ? "Inactive" : "Active";
            }
            PLMatter.AddMapIDtoStatus(int32, str7);
            this.GetLink().TablePOST_ResultDataField_String(this.m_hndPOST, this.m_QuickBooksID.sLinkName, empty2, ref szValue);
            PLMatter.AddMapIDtoQuickBooksID(int32, szValue.ToString());
            this.GetLink().TablePOST_ResultDataField_String(this.m_hndPOST, this.m_LawyerRespID.sLinkName, empty2, ref szValue);
            if (!szValue.ToString().Equals(""))
              PLMatter.AddMapIDtoResp(int32, Convert.ToInt32(szValue));
          }
        }
        short int16_1 = Convert.ToInt16(nProcessed);
        short int16_2 = Convert.ToInt16(nExceptions);
        PLXMLData.m_lErrorCount += (long) int16_2;
        if (((int) int16_2 > 0 ? 1 : (this.m_lCounter != (int) int16_1 ? 1 : 0)) != 0)
        {
          this.GetLink().TablePOST_DumpExceptionsToLinkLog(this.m_hndPOST);
          PLMatter plMatter = this;
          plMatter.m_lSendErrorCount = plMatter.m_lSendErrorCount + 1L;
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

    public enum eFREQUENCY
    {
      NotSet = 0,
      Annually = 65,
      Cycle6 = 69,
      Cycle4 = 70,
      Cycle3 = 72,
      Include = 73,
      Monthly = 77,
      Cycle1 = 79,
      Quarterly = 81,
      SemiAnnually = 83,
      Cycle2 = 84,
      Cycle5 = 86,
      Exclude = 88,
    }

    public enum eGST_CAT
    {
      NOT_SET = 0,
      BOTH = 98,
      NO = 110,
      PST = 112,
      YES = 121,
    }

    public enum eQUOTE_TYPE : byte
    {
      CONTINGENCY,
      ESTIMATE,
      FIXEDFEE,
      NO_QUOTE,
      TARGETWIP,
      MONTHLY_FEE,
      MONTHLY_MINIMUM,
      TOTAL_FEE,
      BILL_IN_ADVANCE,
      MAX_PER_BILL,
    }

    public class IntroLawyer
    {
      public int LawyerID;
      public double Percent;

      public IntroLawyer(int lawyerID, double Pct)
      {
        this.LawyerID = lawyerID;
        this.Percent = Pct;
      }
    }

    public class LawyerExceptionRate
    {
      public int LawyerID;
      public int TaskID;
      public double RateAmount;
      public int RateID;

      public LawyerExceptionRate(int lawyerID, int taskID, double rateAmount, int rateID)
      {
        this.LawyerID = lawyerID;
        this.TaskID = taskID;
        this.RateAmount = rateAmount;
        this.RateID = rateID;
      }
    }

    public class LawyerFeeSplit
    {
      public int LawyerID;
      public double SplitPercent;

      public LawyerFeeSplit(int lawyerID, double splitPercent)
      {
        this.LawyerID = lawyerID;
        this.SplitPercent = splitPercent;
      }
    }

    public class MatterContact
    {
      public int ContactID;
      public int RollID;

      public MatterContact(int contactID, int rollID)
      {
        this.ContactID = contactID;
        this.RollID = rollID;
      }
    }
  }
}
