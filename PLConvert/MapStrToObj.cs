// Decompiled with JetBrains decompiler
// Type: PLConvert.MapStrToObj
// Assembly: PLConvert, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DC1F0050-AC43-49A6-B4BD-95C619E8FF70
// Assembly location: C:\Users\haddocdx\Desktop\Conv DLLs\PLConvert.dll

namespace PLConvert
{
  public class MapStrToObj : Maps
  {
    public override void Add(object key, object value)
    {
      base.Add((object) key.ToString(), value);
    }

    public override bool Contains(object key)
    {
      return base.Contains((object) key.ToString());
    }

    protected override int GetHash(object key)
    {
      return base.GetHash((object) key.ToString());
    }
  }
}
