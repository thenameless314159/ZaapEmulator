/**
 * <auto-generated>
 * Autogenerated by Thrift Compiler (0.17.0)
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 * </auto-generated>
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Thrift;
using Thrift.Collections;
using Thrift.Protocol;
using Thrift.Protocol.Entities;
using Thrift.Protocol.Utilities;
using Thrift.Transport;
using Thrift.Transport.Client;
using Thrift.Transport.Server;
using Thrift.Processor;


#pragma warning disable IDE0079  // remove unnecessary pragmas
#pragma warning disable IDE0017  // object init can be simplified
#pragma warning disable IDE0028  // collection init can be simplified
#pragma warning disable IDE1006  // parts of the code use IDL spelling
#pragma warning disable CA1822   // empty DeepCopy() methods still non-static
#pragma warning disable IDE0083  // pattern matching "that is not SomeType" requires net5.0 but we still support earlier versions

namespace ZaapProtocol
{

  public partial class connect_result : TBase
  {
    private string _success;
    private global::ZaapProtocol.ZaapError _error;

    public string Success
    {
      get
      {
        return _success;
      }
      set
      {
        __isset.success = true;
        this._success = value;
      }
    }

    public global::ZaapProtocol.ZaapError Error
    {
      get
      {
        return _error;
      }
      set
      {
        __isset.error = true;
        this._error = value;
      }
    }


    public Isset __isset;
    public struct Isset
    {
      public bool success;
      public bool error;
    }

    public connect_result()
    {
    }

    public connect_result DeepCopy()
    {
      var tmp10 = new connect_result();
      if((Success != null) && __isset.success)
      {
        tmp10.Success = this.Success;
      }
      tmp10.__isset.success = this.__isset.success;
      if((Error != null) && __isset.error)
      {
        tmp10.Error = (global::ZaapProtocol.ZaapError)this.Error.DeepCopy();
      }
      tmp10.__isset.error = this.__isset.error;
      return tmp10;
    }

    public async global::System.Threading.Tasks.Task ReadAsync(TProtocol iprot, CancellationToken cancellationToken)
    {
      iprot.IncrementRecursionDepth();
      try
      {
        TField field;
        await iprot.ReadStructBeginAsync(cancellationToken);
        while (true)
        {
          field = await iprot.ReadFieldBeginAsync(cancellationToken);
          if (field.Type == TType.Stop)
          {
            break;
          }

          switch (field.ID)
          {
            case 1:
              if (field.Type == TType.String)
              {
                Success = await iprot.ReadStringAsync(cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 2:
              if (field.Type == TType.Struct)
              {
                Error = new global::ZaapProtocol.ZaapError();
                await Error.ReadAsync(iprot, cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            default: 
              await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              break;
          }

          await iprot.ReadFieldEndAsync(cancellationToken);
        }

        await iprot.ReadStructEndAsync(cancellationToken);
      }
      finally
      {
        iprot.DecrementRecursionDepth();
      }
    }

    public async global::System.Threading.Tasks.Task WriteAsync(TProtocol oprot, CancellationToken cancellationToken)
    {
      oprot.IncrementRecursionDepth();
      try
      {
        var tmp11 = new TStruct("connect_result");
        await oprot.WriteStructBeginAsync(tmp11, cancellationToken);
        var tmp12 = new TField();
        if((Success != null) && __isset.success)
        {
          tmp12.Name = "success";
          tmp12.Type = TType.String;
          tmp12.ID = 1;
          await oprot.WriteFieldBeginAsync(tmp12, cancellationToken);
          await oprot.WriteStringAsync(Success, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if((Error != null) && __isset.error)
        {
          tmp12.Name = "error";
          tmp12.Type = TType.Struct;
          tmp12.ID = 2;
          await oprot.WriteFieldBeginAsync(tmp12, cancellationToken);
          await Error.WriteAsync(oprot, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        await oprot.WriteFieldStopAsync(cancellationToken);
        await oprot.WriteStructEndAsync(cancellationToken);
      }
      finally
      {
        oprot.DecrementRecursionDepth();
      }
    }

    public override bool Equals(object that)
    {
      if (!(that is connect_result other)) return false;
      if (ReferenceEquals(this, other)) return true;
      return ((__isset.success == other.__isset.success) && ((!__isset.success) || (global::System.Object.Equals(Success, other.Success))))
        && ((__isset.error == other.__isset.error) && ((!__isset.error) || (global::System.Object.Equals(Error, other.Error))));
    }

    public override int GetHashCode() {
      int hashcode = 157;
      unchecked {
        if((Success != null) && __isset.success)
        {
          hashcode = (hashcode * 397) + Success.GetHashCode();
        }
        if((Error != null) && __isset.error)
        {
          hashcode = (hashcode * 397) + Error.GetHashCode();
        }
      }
      return hashcode;
    }

    public override string ToString()
    {
      var tmp13 = new StringBuilder("connect_result(");
      int tmp14 = 0;
      if((Success != null) && __isset.success)
      {
        if(0 < tmp14++) { tmp13.Append(", "); }
        tmp13.Append("Success: ");
        Success.ToString(tmp13);
      }
      if((Error != null) && __isset.error)
      {
        if(0 < tmp14++) { tmp13.Append(", "); }
        tmp13.Append("Error: ");
        Error.ToString(tmp13);
      }
      tmp13.Append(')');
      return tmp13.ToString();
    }
  }

}
