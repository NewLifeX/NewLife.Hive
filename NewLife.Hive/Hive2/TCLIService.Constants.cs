using System;
using System.Collections.Generic;
using Thrift.Collections;

namespace NewLife.Hive2
{
    public static class TCLIServiceConstants
    {
        public static THashSet<TTypeId> PRIMITIVE_TYPES = new THashSet<TTypeId>();
        public static THashSet<TTypeId> COMPLEX_TYPES = new THashSet<TTypeId>();
        public static THashSet<TTypeId> COLLECTION_TYPES = new THashSet<TTypeId>();
        public static Dictionary<TTypeId, String> TYPE_NAMES = new Dictionary<TTypeId, String>();
        public static String CHARACTER_MAXIMUM_LENGTH = "characterMaximumLength";
        public static String PRECISION = "precision";
        public static String SCALE = "scale";

        static TCLIServiceConstants()
        {
            PRIMITIVE_TYPES.Add(TTypeId.BOOLEAN_TYPE);
            PRIMITIVE_TYPES.Add(TTypeId.TINYINT_TYPE);
            PRIMITIVE_TYPES.Add(TTypeId.SMALLINT_TYPE);
            PRIMITIVE_TYPES.Add(TTypeId.INT_TYPE);
            PRIMITIVE_TYPES.Add(TTypeId.BIGINT_TYPE);
            PRIMITIVE_TYPES.Add(TTypeId.FLOAT_TYPE);
            PRIMITIVE_TYPES.Add(TTypeId.DOUBLE_TYPE);
            PRIMITIVE_TYPES.Add(TTypeId.STRING_TYPE);
            PRIMITIVE_TYPES.Add(TTypeId.TIMESTAMP_TYPE);
            PRIMITIVE_TYPES.Add(TTypeId.BINARY_TYPE);
            PRIMITIVE_TYPES.Add(TTypeId.DECIMAL_TYPE);
            PRIMITIVE_TYPES.Add(TTypeId.NULL_TYPE);
            PRIMITIVE_TYPES.Add(TTypeId.DATE_TYPE);
            PRIMITIVE_TYPES.Add(TTypeId.VARCHAR_TYPE);
            PRIMITIVE_TYPES.Add(TTypeId.CHAR_TYPE);
            COMPLEX_TYPES.Add(TTypeId.ARRAY_TYPE);
            COMPLEX_TYPES.Add(TTypeId.MAP_TYPE);
            COMPLEX_TYPES.Add(TTypeId.STRUCT_TYPE);
            COMPLEX_TYPES.Add(TTypeId.UNION_TYPE);
            COMPLEX_TYPES.Add(TTypeId.USER_DEFINED_TYPE);
            COLLECTION_TYPES.Add(TTypeId.ARRAY_TYPE);
            COLLECTION_TYPES.Add(TTypeId.MAP_TYPE);
            TYPE_NAMES[TTypeId.DOUBLE_TYPE] = "DOUBLE";
            TYPE_NAMES[TTypeId.SMALLINT_TYPE] = "SMALLINT";
            TYPE_NAMES[TTypeId.INT_TYPE] = "INT";
            TYPE_NAMES[TTypeId.BOOLEAN_TYPE] = "BOOLEAN";
            TYPE_NAMES[TTypeId.BIGINT_TYPE] = "BIGINT";
            TYPE_NAMES[TTypeId.FLOAT_TYPE] = "FLOAT";
            TYPE_NAMES[TTypeId.TINYINT_TYPE] = "TINYINT";
            TYPE_NAMES[TTypeId.ARRAY_TYPE] = "ARRAY";
            TYPE_NAMES[TTypeId.STRING_TYPE] = "STRING";
            TYPE_NAMES[TTypeId.STRUCT_TYPE] = "STRUCT";
            TYPE_NAMES[TTypeId.TIMESTAMP_TYPE] = "TIMESTAMP";
            TYPE_NAMES[TTypeId.BINARY_TYPE] = "BINARY";
            TYPE_NAMES[TTypeId.UNION_TYPE] = "UNIONTYPE";
            TYPE_NAMES[TTypeId.DECIMAL_TYPE] = "DECIMAL";
            TYPE_NAMES[TTypeId.NULL_TYPE] = "NULL";
            TYPE_NAMES[TTypeId.MAP_TYPE] = "MAP";
            TYPE_NAMES[TTypeId.CHAR_TYPE] = "CHAR";
            TYPE_NAMES[TTypeId.DATE_TYPE] = "DATE";
            TYPE_NAMES[TTypeId.VARCHAR_TYPE] = "VARCHAR";
        }
    }
}