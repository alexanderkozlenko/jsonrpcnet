﻿namespace System.Data.JsonRpc
{
    /// <summary>Represents RPC identifier.</summary>
    public struct JsonRpcId
    {
        /// <summary>Represents not specified identifier.</summary>
        public static readonly JsonRpcId None = default;

        private readonly long _valueNumber;
        private readonly string _valueString;

        /// <summary>Initializes a new instance of the <see cref="JsonRpcId" /> structure.</summary>
        /// <param name="value">The identifier value.</param>
        public JsonRpcId(long value)
        {
            _valueNumber = value;
            _valueString = default;

            Type = JsonRpcIdType.Number;
        }

        /// <summary>Initializes a new instance of the <see cref="JsonRpcId" /> structure.</summary>
        /// <param name="value">The identifier value.</param>
        /// <exception cref="ArgumentNullException"><paramref name="value" /> is <see langword="null" />.</exception>
        public JsonRpcId(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            _valueNumber = default;
            _valueString = value;

            Type = JsonRpcIdType.String;
        }

        /// <summary>Returns the hash code for this instance.</summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            switch (Type)
            {
                case JsonRpcIdType.Number:
                    {
                        return _valueNumber.GetHashCode();
                    }
                case JsonRpcIdType.String:
                    {
                        return _valueString.GetHashCode();
                    }
                default:
                    {
                        return base.GetHashCode();
                    }
            }
        }

        /// <summary>Determines whether the specified object is equal to the current object.</summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><see langword="true" /> if the specified object is equal to the current object; otherwise, <see langword="false" />.</returns>
        public override bool Equals(object obj)
        {
            switch (obj)
            {
                case JsonRpcId other:
                    {
                        if (Type != other.Type)
                        {
                            return false;
                        }

                        switch (Type)
                        {
                            case JsonRpcIdType.Number:
                                {
                                    return object.Equals(_valueNumber, other._valueNumber);
                                }
                            case JsonRpcIdType.String:
                                {
                                    return object.Equals(_valueString, other._valueString);
                                }
                            default:
                                {
                                    return true;
                                }
                        }
                    }
                case long other:
                    {
                        return object.Equals(_valueNumber, other);
                    }
                case string other:
                    {
                        return object.Equals(_valueString, other);
                    }
                default:
                    {
                        return false;
                    }
            }
        }

        /// <summary>Converts the value of this instance to its equivalent string representation.</summary>
        /// <returns>The string representation of the value of this instance.</returns>
        public override string ToString()
        {
            switch (Type)
            {
                case JsonRpcIdType.Number:
                    {
                        return _valueNumber.ToString();
                    }
                case JsonRpcIdType.String:
                    {
                        return _valueString;
                    }
                default:
                    {
                        return "(none)";
                    }
            }
        }

        /// <summary>Overloads == operator.</summary>
        /// <param name="obj1">The left <see cref="JsonRpcId" /> operand.</param>
        /// <param name="obj2">The right <see cref="JsonRpcId" /> operand.</param>
        /// <returns>The result of == operation.</returns>
        public static bool operator ==(JsonRpcId obj1, JsonRpcId obj2) =>
            object.Equals(obj1, obj2);

        /// <summary>Overloads != operator.</summary>
        /// <param name="obj1">The left <see cref="JsonRpcId" /> operand.</param>
        /// <param name="obj2">The right <see cref="JsonRpcId" /> operand.</param>
        /// <returns>The result of != operation.</returns>
        public static bool operator !=(JsonRpcId obj1, JsonRpcId obj2) =>
            !(obj1 == obj2);

        /// <summary>Performs an implicit conversion from <see cref="ulong" /> to <see cref="JsonRpcId" />.</summary>
        /// <param name="value">The value to create a <see cref="JsonRpcId" />.</param>
        public static implicit operator JsonRpcId(long value) =>
            new JsonRpcId(value);

        /// <summary>Performs an implicit conversion from <see cref="string" /> to <see cref="JsonRpcId" />.</summary>
        /// <param name="value">The value to create a <see cref="JsonRpcId" />.</param>
        public static implicit operator JsonRpcId(string value) =>
            new JsonRpcId(value);

        /// <summary>Performs an implicit conversion from <see cref="JsonRpcId" /> to <see cref="long" />.</summary>
        /// <param name="value">The value to create a <see cref="long" />.</param>
        public static explicit operator long(JsonRpcId value) =>
            value.Type == JsonRpcIdType.Number ? value._valueNumber : throw new InvalidOperationException("Value is not a number");

        /// <summary>Performs an implicit conversion from <see cref="JsonRpcId" /> to <see cref="string" />.</summary>
        /// <param name="value">The value to create a <see cref="string" />.</param>
        public static explicit operator string(JsonRpcId value) =>
            value.Type == JsonRpcIdType.String ? value._valueString : throw new InvalidOperationException("Value is not a string");

        /// <summary>Gets the identifier type.</summary>
        public JsonRpcIdType Type { get; }
    }
}