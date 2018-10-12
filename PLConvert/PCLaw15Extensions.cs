// Decompiled with JetBrains decompiler
// Type: PLConvert.PCLaw15Extensions
// Assembly: PLConvert, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DC1F0050-AC43-49A6-B4BD-95C619E8FF70
// Assembly location: C:\Users\haddocdx\Desktop\Conv DLLs\PLConvert.dll

using PLXMLLnkLib;
using System.Collections.Generic;
using System.IO;

namespace PLConvert
{
  public static class PCLaw15Extensions
  {
    public static bool ValidateSuccess(PCLawATL link, uint handle, ref List<string> errors, ref object exceptions, ref string localId)
    {
      localId = string.Empty;
      bool flag = false;
      object vunIDCreated = new object();
      object szExceptionErrorMsg = new object();
      object szExceptionSentData = new object();
      if ((int) exceptions > 0)
      {
        for (int nextResult = link.TablePOST_GetNextResult(handle, ref vunIDCreated, ref exceptions, ref szExceptionErrorMsg, ref szExceptionSentData); nextResult == 0; nextResult = link.TablePOST_GetNextResult(handle, ref vunIDCreated, ref exceptions, ref szExceptionErrorMsg, ref szExceptionSentData))
        {
          if (!string.IsNullOrWhiteSpace((string) szExceptionErrorMsg))
            errors.Add((string) szExceptionErrorMsg);
        }
      }
      else
      {
        link.TablePOST_GetNextResult(handle, ref vunIDCreated, ref exceptions, ref szExceptionErrorMsg, ref szExceptionSentData);
        localId = vunIDCreated.ToString();
        flag = true;
      }
      return flag;
    }

    public static void writeErrorLog(string text)
    {
      using (StreamWriter streamWriter = new StreamWriter("C:\\errors.log", true))
        streamWriter.WriteLine(text);
    }
  }
}
