using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SR;

namespace ListUp
{
    public class Reflector<T>
    {

        protected bool IsNumber(System.Reflection.FieldInfo field)
        {
            switch (Type.GetTypeCode(field.FieldType))
            {
                case TypeCode.Byte:
                case TypeCode.SByte:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Single:
                    return true;
                default:
                    return false;
            }
        }

        protected bool IsTarget(System.Reflection.FieldInfo field)
        {
            // 例外
            if (field.IsSpecialName) return false;
            if (field.IsStatic) return false;
            if (field.Name.Equals("pKey")) return false;

            // 目標
            if (field.FieldType.IsEnum) return true;
            if (IsNumber(field)) return true;
            if (field.FieldType.Equals(typeof(string))) return true;

            // 一般のオブジェクト
            return false;
        }

        protected FieldInfo[] GetFieldInfos(Type type)
        {
            return type.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
        }

        public List<string> GetHeader()
        {
            List<string> rv = new List<string>();

            Type type = typeof(T);
            foreach (var fields in GetFieldInfos(type))
            {
                if (!IsTarget(fields)) continue;
                rv.Add(fields.Name);
            }

            return rv;
        }

        public Dictionary<string, string> GetTargetValues(T obj)
        {
            Dictionary<string, string> rv = new Dictionary<string, string>();

            Type type = typeof(T);
            foreach (var fields in GetFieldInfos(type))
            {
                if (!IsTarget(fields)) continue;
                rv[fields.Name] = fields.GetValue(obj).ToString();
            }

            return rv;
        }

    }
}
