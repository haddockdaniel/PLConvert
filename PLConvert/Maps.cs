// Decompiled with JetBrains decompiler
// Type: PLConvert.Maps
// Assembly: PLConvert, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DC1F0050-AC43-49A6-B4BD-95C619E8FF70
// Assembly location: C:\Users\haddocdx\Desktop\Conv DLLs\PLConvert.dll

using System.Collections;

namespace PLConvert
{
  public class Maps : Hashtable
  {
    public override void Add(object key, object value)
    {
      base.Add((object) key.ToString().Trim(), (object) value.ToString().Trim());
    }
  }
}
